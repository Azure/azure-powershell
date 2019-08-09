namespace Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
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
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$location = $fakeBoundParameter['Location']\n" +
                "$type = $fakeBoundParameter['Type']\n" +
                "$skuNames = [Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters.VmssSkuCompleterAttribute]::GetSkuNames()\n" +
                "$locations | Where-Object { $_ -Like \"*$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
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
                    var client = AzureSession.Instance.ClientFactory.CreateArmClient<ComputeManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                    var task = client.ResourceSkus.ListAsync();
                    ReadAllPages(task, nextPageLink => client.ResourceSkus.ListNextAsync(nextPageLink));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return new string[] { };
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
            while (!string.IsNullOrEmpty(page.NextPageLink)) {
                task = nextTaskCreator(page.NextPageLink);
                task.Wait();
                page = task.Result;
                results.AddRange(page);
            }
            return results;
        }
    }
}
