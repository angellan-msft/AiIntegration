# EchoBot (TODO: Rename the bot)

This bot has been created using [Bot Framework](https://dev.botframework.com), it demonstrates how to create a simple bot, integrated with Semantic Kernel, that answers user questions by retrieving data from an internal knowledge base.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) version 8.0

  ```bash
  # determine dotnet version
  dotnet --version
  ```

## Deploy the Bot to Azure

### MSI auth for bot web app

Update appsettings.json on the following properties:
- MicrosoftAppType: Leave it as blank
- MicrosoftAppId: Client ID of the web app registration
- MicrosoftAppPassword: Password of the web app registration
- MicrosoftAppTenantId: Tenant ID of the bot

### How to build and deploy this bot web app

1. **OPTIONAL: Drag the GenevaSyntheticsBot project folder out of async_spool_chat repo** and continue. The deployment may fail when the folder is within the async_spool_chat repo.
2. **Open your project in Visual Studio Code.** Ensure you use VS Code, as it supports AAD Authentication in code deployment.
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

## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Activity processing](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-activity-processing?view=azure-bot-service-4.0)
- [Azure Bot Service Introduction](https://docs.microsoft.com/azure/bot-service/bot-service-overview-introduction?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)
- [.NET Core CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest)
- [Azure Portal](https://portal.azure.com)
- [Channels and Bot Connector Service](https://docs.microsoft.com/en-us/azure/bot-service/bot-concepts?view=azure-bot-service-4.0)