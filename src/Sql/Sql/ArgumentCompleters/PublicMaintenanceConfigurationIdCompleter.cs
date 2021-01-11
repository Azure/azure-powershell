using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using Microsoft.Azure.Management.Sql;
using System;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.ArgumentCompleters
{
    public class PublicMaintenanceConfigurationIdCompleterAttribute : ArgumentCompleterAttribute
    {
        private static int _timeout = 3;

        public PublicMaintenanceConfigurationIdCompleterAttribute(string resourceGroupParameter, string serverParameter) : base(CreateScriptBlock(resourceGroupParameter, serverParameter))
        {
        }

        
        public static string[] FindResources(string serverResourceGroup, string serverName)
        {
            if (string.IsNullOrEmpty(serverResourceGroup) || string.IsNullOrEmpty(serverName))
            {
                return new string[0];
            }

            try
            {
                return GetPublicMaintenanceConfigurations(serverResourceGroup, serverName);
            }
            catch (Exception)
            {
            }

            return new string[0];
        }

        private static string[] GetPublicMaintenanceConfigurations(string resourceGroup, string serverName)
        {
            IAzureContext context = AzureRmProfileProvider.Instance?.Profile?.DefaultContext;
            MaintenanceManagementClient maintenanceClient = AzureSession.Instance.ClientFactory.CreateArmClient<MaintenanceManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager);
            SqlManagementClient sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager);

            var allConfigurationsTask = maintenanceClient.PublicMaintenanceConfigurations.ListAsync();
            var serverTask = sqlClient.Servers.GetAsync(resourceGroup, serverName);

            if (!Task.WaitAll(new Task[] { allConfigurationsTask, serverTask }, TimeSpan.FromSeconds(_timeout))
                || allConfigurationsTask.Result == null || serverTask.Result == null)
            {
                return new string[0];
            }

            // filter SQL DB public maintenance configurations
            // filter by server location (SQL_Default is universal)
            return allConfigurationsTask.Result
                .Where(cfg => cfg.MaintenanceScope == MaintenanceScope.SQLDB)
                .Where(cfg => string.Equals(cfg.Location, serverTask.Result.Location, StringComparison.OrdinalIgnoreCase)
                                || string.Equals(cfg.Name, Constants.DefaultPublicMaintenanceConfiguration, StringComparison.OrdinalIgnoreCase))
                .Select(cfg => cfg.Name)
                .ToArray();
        }

        /// <summary>
        /// Create ScriptBlock that registers the correct location for tab completetion of the -Location parameter
        /// </summary>
        /// <param name="resourceGroupParameter"></param>
        /// <param name="serverParameter"></param>
        /// <returns></returns>
        private static ScriptBlock CreateScriptBlock(string resourceGroupParameter, string serverParameter)
        {
            return ScriptBlock.Create(
                @"param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)
                  $serverResourceGroup = $fakeBoundParameters[" + $"\"{resourceGroupParameter}\"" + @"];
                  $serverName = $fakeBoundParameters[" + $"\"{serverParameter}\"" + @"];

                  $resources = [Microsoft.Azure.Commands.Sql.ArgumentCompleters.PublicMaintenanceConfigurationIdCompleterAttribute]::FindResources($serverResourceGroup, $serverName);
                  $resources | Where-Object { $_ -Like ""*$wordToComplete*"" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }");
        }
    }
}
