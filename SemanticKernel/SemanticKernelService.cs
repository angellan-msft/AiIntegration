// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Threading.Tasks;

namespace ChatBot.SemanticKernel
{
    public class SemanticKernelService : ISemanticKernelService
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chatCompletionService;
        private readonly ChatHistory _chatHistory;

        public SemanticKernelService()
        {
            _chatHistory = new ChatHistory();

            // Step 1: Create the Kernel Builder
            var kernelBuilder = Kernel.CreateBuilder();

            // Step 2: Add Azure OpenAI chat completion to the Kernel
            var modelId = "ai-integration-fhl";
            var endpoint = "https://ai-integration-fhl.openai.azure.com/";
            var apiKey = "137bf3e02a2c42b8acc2782200891588";
            kernelBuilder.AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

            // Step 3: Add the plugin to the kernel
            kernelBuilder.Plugins.AddFromType<OrderManagementPlugin>("OrderManagement");

            // Step 4: Create the Kernel
            _kernel = kernelBuilder.Build();

            // Step 5: Get the chat completion service
            _chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();    
        }

        public async Task<string> GetResponseAsync(string userInput)
        {
            _chatHistory.AddUserMessage(userInput);

            // The `AllowParallelCalls` option instructs the AI model to call multiple functions in parallel if the model supports parallel function calls.
            FunctionChoiceBehaviorOptions options = new() { AllowParallelCalls = true };

            var openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(options: options)
            };            

            var result = await _chatCompletionService.GetChatMessageContentAsync(
                _chatHistory,
                executionSettings: openAIPromptExecutionSettings,
                kernel: _kernel
            );

            var response = result.Content ?? "No response received from AI.";

            _chatHistory.AddMessage(result.Role, response);

            return response;
        }
    }
}