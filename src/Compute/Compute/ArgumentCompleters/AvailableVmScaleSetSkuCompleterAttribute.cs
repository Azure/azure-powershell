namespace Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters
{
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Compute;
    using Microsoft.Azure.Management.Compute;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    public class AvailableVmScaleSetSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public AvailableVmScaleSetSkuCompleterAttribute(string resourceGroupName, string vmScaleSetName)
               : base(CreateScriptBlock(resourceGroupName, vmScaleSetName))
        {
        }

        private static ScriptBlock CreateScriptBlock(string resourceGroupName, string vmScaleSetName)
        {
            string script = new ArgumentCompleterUtility.ScriptBuilder(
                new[] { resourceGroupName, vmScaleSetName },
                typeof(AvailableVmScaleSetSkuCompleterAttribute).Namespace,
                typeof(AvailableVmScaleSetSkuCompleterAttribute).Name,
                nameof(AvailableVmScaleSetSkuCompleterAttribute.GetSkuNames)
            ).ToString();
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames(string resourceGroupName, string vmScaleSetName)
        {
            lock (_lock)
            {
                IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                var contextHash = ArgumentCompleterUtility.HashContext(context);

                string[] names = new string[] { };

                if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(vmScaleSetName))
                {
                    if (_completionHistory.ContainsKey(contextHash))
                    {
                        names = _completionHistory[contextHash];
                    }
                    else
                    {

                        try
                        {
                            names = GetSkuNamesFromClient(resourceGroupName, vmScaleSetName, context);
                            _completionHistory.Add(contextHash, names);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                return names;
            }
        }

        private static readonly object _lock = new object();
        private static readonly IDictionary<int, string[]> _completionHistory = new ConcurrentDictionary<int, string[]>();

        private static string[] GetSkuNamesFromClient(string resourceGroupName, string vmScaleSetName, IAzureContext context)
        {
            string[] output;
            var client = new ComputeClient(context).ComputeManagementClient.VirtualMachineScaleSets;
            output = ArgumentCompleterUtility.ReadAllPages(client.ListSkusAsync(resourceGroupName, vmScaleSetName), nextPageLink => client.ListSkusNextAsync(nextPageLink))
                .Select(sku => sku.Sku.Name)
                .ToArray();
            return output;
        }
    }
}
