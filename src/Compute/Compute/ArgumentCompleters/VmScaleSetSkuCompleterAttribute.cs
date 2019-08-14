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

    public class VmScaleSetSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public VmScaleSetSkuCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = new ArgumentCompleterUtility.ScriptBuilder(
                new string[] { },
                typeof(VmScaleSetSkuCompleterAttribute).Namespace,
                typeof(VmScaleSetSkuCompleterAttribute).Name,
                nameof(VmScaleSetSkuCompleterAttribute.GetSkuNames)
            ).ToString();
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames()
        {
            lock (_lock)
            {
                var names = new string[] { };

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
                        names = GetSkuNamesFromClient(context);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return names;
            }
        }

        private static readonly object _lock = new object();
        private static readonly IDictionary<int, string[]> _completionHistory = new ConcurrentDictionary<int, string[]>();

        private static string[] GetSkuNamesFromClient(IAzureContext context)
        {
            string[] output;
            var client = new ComputeClient(context).ComputeManagementClient.ResourceSkus;
            output = ArgumentCompleterUtility.ReadAllPages(client.ListAsync(), nextPageLink => client.ListNextAsync(nextPageLink))
                .Select(sku => sku.Name)
                .ToArray();
            return output;
        }
    }
}
