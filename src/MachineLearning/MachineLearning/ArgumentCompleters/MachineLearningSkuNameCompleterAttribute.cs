namespace Microsoft.Azure.Commands.MachineLearning
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.MachineLearning.WebServices;
    using Microsoft.Azure.Management.MachineLearning.CommitmentPlans;

    public class MachineLearningSkuNameCompleterAttribute : ArgumentCompleterAttribute
    {
        public MachineLearningSkuNameCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = new ArgumentCompleterUtility.ScriptBuilder();
            "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$skuNames = [Microsoft.Azure.Commands.MachineLearning.MachineLearningSkuNameCompleterAttribute]::GetSkuNames()\n" +
                "$locations | Where-Object { $_ -Like \"*$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames()
        {
            lock (_lock)
            {
                IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                var contextHash = HashContext(context);

                try
                {
                    var client = AzureSession.Instance.ClientFactory.CreateArmClient<AzureMLCommitmentPlansManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                    var task = client.
                    var skus = ReadAllPages(task, nextPageLink => client.ResourceSkus.ListNextAsync(nextPageLink));
                    var skuNames = skus.Select(sku => sku.Name);
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
