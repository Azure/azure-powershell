using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Common.Strategies.Json;
using Microsoft.Azure.Commands.Common.Strategies.Templates;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    static class StrategyCmdlet
    {
        public static async Task<TModel> RunAsync<TModel>(
            IClient client,
            IParameters<TModel> parameters,
            string resourceGroupName,
            IAsyncCmdlet asyncCmdlet,
            CancellationToken cancellationToken)
            where TModel : class
        {
            var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(resourceGroupName);

            // create a DAG of configs.
            var config = await parameters.CreateConfigAsync(resourceGroup);

            // reade current Azure state.
            var current = await config.GetStateAsync(client, cancellationToken);

            // update location.
            parameters.Location = current.UpdateLocation(parameters.Location, config);

            // update a DAG of configs.
            config = await parameters.CreateConfigAsync(resourceGroup);

            if (parameters.AsArmTemplate)
            {
                // create target state
                var templateEngine = new TemplateEngine(client);
                var target = config.GetTargetState(current, templateEngine, parameters.Location);

                var template = config.CreateTemplate(client, target, templateEngine);
                template.parameters = templateEngine
                    .SecureStrings
                    .Keys
                    .ToDictionary(
                        k => k,
                        _ => new Parameter { type = "secureString" });
                template.outputs = new Dictionary<string, Output>
                {
                    {
                        "result",
                        new Output
                        {
                            type = "object",
                            value = 
                                "[reference('" 
                                + config.GetIdFromResourceGroup().IdToString() + 
                                "', '" + 
                                config.Strategy.GetApiVersion(client) + 
                                "')]"
                        }
                    }
                };
                var templateResult = new Converters().Serialize(template).ToString();
                asyncCmdlet.WriteObject(templateResult);

                // deployment
                /*
                // create a resource group.
                await resourceGroup
                    .UpdateStateAsync(
                        client,
                        target,
                        new CancellationToken(),
                        new ShouldProcess(asyncCmdlet),
                        asyncCmdlet.ReportTaskProgress);

                var rmClient = client.GetClient<ResourceManagementClient>();
                var deployment = new Deployment
                {
                    Properties = new DeploymentProperties
                    {
                        Template = template,
                        Parameters = templateEngine
                            .SecureStrings
                            .ToDictionary(
                                kv => kv.Key,
                                kv => new DeploymentParameter
                                {
                                    value = new NetworkCredential(string.Empty, kv.Value).Password
                                })
                    }
                };

                var validation = await rmClient.Deployments.ValidateAsync(
                    resourceGroupName: config.ResourceGroup.Name,
                    deploymentName: config.Name,
                    parameters: deployment);

                var tResult = await rmClient.Deployments.CreateOrUpdateAsync(
                    resourceGroupName: config.ResourceGroup.Name,
                    deploymentName: config.Name,
                    parameters: deployment);

                var output = ((tResult.Properties.Outputs as JObject)["result"] as JObject)
                    .ToObject<Output>();

                return output.GetModel<TModel>();
                */
                return null;
            }
            else
            {
                var engine = new SdkEngine(client.SubscriptionId);
                var target = config.GetTargetState(current, engine, parameters.Location);

                // apply target state
                var newState = await config.UpdateStateAsync(
                    client,
                    target,
                    cancellationToken,
                    new ShouldProcess(asyncCmdlet),
                    asyncCmdlet.ReportTaskProgress);

                return newState.Get(config) ?? current.Get(config);
            }
        }
    }
}
