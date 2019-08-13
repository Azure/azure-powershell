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
    using System.Reflection;

    public class VmssSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public VmssSkuCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = new ArgumentCompleterUtility.ScriptBuilder(
                new[] { "Location", "Type" },
                typeof(VmssSkuCompleterAttribute).Namespace,
                typeof(VmssSkuCompleterAttribute).Name,
                nameof(VmssSkuCompleterAttribute.GetSkuNames)
            ).ToString();
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames(string resourceGroupName, string vmssName)
        {
            lock (_lock)
            {
                var names = new string[] { };
                if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(vmssName))
                {

                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    var contextHash = ArgumentCompleterUtility.HashContext(context);

                    if (!_completionHistory.ContainsKey(contextHash))
                    {
                        names = _completionHistory[contextHash];
                    }
                    else
                    {

                        try
                        {
                            names = GetSkuNamesFromClient(resourceGroupName, vmssName, context);
                        }
                        catch (Exception ex)
                        {
#if DEBUG
                            throw ex;
#endif
                        }
                    }
                }
                return names;
            }
        }

        private static readonly object _lock = new object();
        private static readonly IDictionary<int, string[]> _completionHistory = new ConcurrentDictionary<int, string[]>();

        private static string[] GetSkuNamesFromClient(string resourceGroupName, string vmssName, IAzureContext context)
        {
            string[] output;
            var client = new ComputeClient(context).ComputeManagementClient.VirtualMachineScaleSets;
            output = ArgumentCompleterUtility.ReadAllPages(client.ListSkusAsync(resourceGroupName, vmssName), nextPageLink => client.ListSkusNextAsync(nextPageLink))
                .Select(sku => sku.Sku.Name)
                .ToArray();
            return output;
        }
    }
}
