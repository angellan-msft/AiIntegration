# ChatBot

This bot has been created using [Bot Framework](https://dev.botframework.com), it demonstrates how to create a simple bot, integrated with Semantic Kernel, that answers user questions by retrieving data from an internal knowledge base.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) version 8.0

  ```bash
  # determine dotnet version
  dotnet --version
  ```

## Deploy the Bot to Azure

### How to set up resources
1. Create a User Assigned Managed identity (MSI) resource and note down the client id.
2. Create an Azure Bot resource, choose User-Assigned Managed Identity as the Type of App and provide the client id of MSI as the App ID.
3. Create a Web App resource. After creating it, please go to "Settings - Identity" section and upload the MSI you just created. Also, please go to "Overview" section, find the default domain and note down the URL "https://default-domain/api/messages". Then go to the Azure Bot resource and put the URL in the "Settings - Configuration - Messaging endpoint" field.
4. Follow [Quickstart: Create and manage Communication Services resources](https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp) to create Azure Communication Service resource, a user and a user token.
5. Enable ACS Chat Channel for your Azure Bot resource and write down bot's ACS ID.

### How to build and deploy this bot web app

1. **Open your project in Visual Studio Code.** Ensure you use VS Code, as it supports AAD Authentication in code deployment.
2. **Install the Azure App Service extension in Visual Studio Code**.
3. **Sign in to your Azure account** in Visual Studio Code by clicking the Azure icon in the Activity Bar on the side of the window.
4. **Build the project in Release mode** and output the generated files to the `./bin/Publish` folder within your project directory by running the following command in the integrated terminal. You need to navigate to the specific project folder (which should contain the `.csproj` file) before running the command:
```
dotnet publish -c Release -o ./bin/Publish
```
* This command will generate two folders, "bin" and "obj". (Please remove these two folders before you commit the code changes to Chat Gateway repo. They don't need to be included in source control.)
5. **Deploy to Web App** by right-clicking on the newly created `/bin/Publish` folder and selecting "Deploy to Web App."
6. **Choose the Azure App Service web app** you want to deploy the application to and confirm deployment.
7. **Visit your web app's URL** once the deployment is complete. You'll see a notification in Visual Studio Code, and you can visit your web app's URL to see the updated application running live.

## How to run the demo
1. Create a chat thread with 2 participant IDs, the ones created in "How to set up resources" step 4 (non-bot user id) and step 5 (bot user id). Also note down the thread id.
2. Access the [ACS Chat Thread UI](https://azure.github.io/communication-ui-library/?path=/story/composites-chatcomposite-join-existing-chat-thread--join-existing-chat-thread)
3. Provide the required information to join an existing Chat Thread. Then you can type the below 3 question. AI will retrieve the hardcoded data relevant to the semantics of the user's question and provided an answer based on the data.
- My user ID is 110. I bought a laptop several days ago. Could you help to track the delivery?
- I’ve requested a return for my Power Bank. Any updates?
- I bought Bluetooth Earphones 2 days ago, but they haven’t been shipped yet. Why?


## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)