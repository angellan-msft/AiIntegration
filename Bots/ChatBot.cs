// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using ChatBot.SemanticKernel;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace ChatBot.Bots
{
    public class ChatBot : ActivityHandler
    {
        private readonly ILogger _logger;
        private readonly ISemanticKernelService _semanticKernelService;

        public ChatBot(ILogger<ChatBot> logger, ISemanticKernelService semanticKernelService)
        {
            _logger = logger;
            _semanticKernelService = semanticKernelService;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var customerQuestion = turnContext.Activity.Text;
            _logger.LogInformation("Received customer question: {Message}", customerQuestion);

            try
            {
                // Call Semantic Kernel Service to get AI-generated response
                var responseStr = await _semanticKernelService.GetResponseAsync(customerQuestion);

                _logger.LogInformation("Received Semantic Kernel Response: {Message}", responseStr);

                // Send response back to the user
                await turnContext.SendActivityAsync(MessageFactory.Text(responseStr), cancellationToken);
            }    
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message: {Message}", customerQuestion);
                await turnContext.SendActivityAsync(MessageFactory.Text("Sorry, something went wrong."), cancellationToken);
            }
        }
    }
}