using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Support.Helpers;
using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.Support.ArgumentCompleters
{
    public class ServiceIdCompleter : ArgumentCompleterAttribute
    {
        private static int _timeout = 3;

        public ServiceIdCompleter() : base(CreateScriptBlock())
        {
        }

        public static PSSupportService[] FindResources()
        {
            try
            {
                var ids = GetServices();

                return ids.ToArray();
            }
            catch (Exception)
            {
            }

            return new PSSupportService[0];
        }

        public static List<PSSupportService> GetServices()
        {
            var context = AzureRmProfileProvider.Instance?.Profile?.DefaultContext;
            var supportClient = AzureSession.Instance.ClientFactory.CreateArmClient<MicrosoftSupportClient>(context, AzureEnvironment.Endpoint.ResourceManager);

            var allProviders = supportClient.Services.ListAsync();

            var timeoutDuration = TimeSpan.FromSeconds(_timeout);
            var hasNotTimedOut = allProviders.Wait(timeoutDuration);
            var hasResult = allProviders.Result != null;
            var isSuccessful = hasNotTimedOut && hasResult;

            return isSuccessful
                ? allProviders.Result.Select(resource => resource.ToPSSupportService()).ToList()
                : new List<PSSupportService>();
        }


        /// <summary>
        /// Create ScriptBlock that registers the correct location for tab completetion of the -Location parameter
        /// </summary>
        /// <returns></returns>
        public static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)\n";

            script += "$resources = [Microsoft.Azure.PowerShell.Cmdlets.Support.ArgumentCompleters.ServiceIdCompleter]::FindResources()\n" +
                "$resources | Where-Object { $_.DisplayName -Like \"$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_.Id, $_.DisplayName, 'ParameterValue', $_.DisplayName) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}
