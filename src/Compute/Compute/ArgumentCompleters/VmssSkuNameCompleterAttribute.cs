namespace Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Compute;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Rest.Azure;

    public class VmssSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public VmssSkuCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = new ArgumentCompleterUtility.ScriptBuilder(new[] { "Location", "Type" },
                "Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters",
                "VmssSkuCompleterAttribute", "GetSkuNames").ToString();
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames(string resourceGroupName, string vmssName)
        {
            lock (_lock)
            {
                IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                var contextHash = HashContext(context);

                try
                {
                    var client = new ComputeClient(context).ComputeManagementClient.VirtualMachineScaleSets;
                    if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(vmssName))
                    {
                        return new string[] { };
                    }
                    var skus = ReadAllPages(client.ListSkusAsync(resourceGroupName, vmssName), nextPageLink => client.ListSkusNextAsync(nextPageLink));
                    var skuNames = skus.Select(sku => sku.Sku.Name);
                    return skuNames.ToArray();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static readonly object _lock = new object();

        private static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }

        private static List<TItem> ReadAllPages<TItem>(Task<IPage<TItem>> task, Func<string, Task<IPage<TItem>>> nextTaskCreator)
        {
            var results = new List<TItem>();
            task.Wait();
            var page = task.Result;
            results.AddRange(task.Result);
            while (!string.IsNullOrEmpty(page.NextPageLink))
            {
                task = nextTaskCreator(page.NextPageLink);
                task.Wait();
                page = task.Result;
                results.AddRange(page);
            }
            return results;
        }
    }
}
