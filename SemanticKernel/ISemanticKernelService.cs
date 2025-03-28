// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace ChatBot.SemanticKernel
{
    public interface ISemanticKernelService
    {
        Task<string> GetResponseAsync(string userInput);
    }
}