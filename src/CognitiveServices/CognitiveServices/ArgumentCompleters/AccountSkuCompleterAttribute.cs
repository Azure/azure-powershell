namespace Microsoft.Azure.Commands.Management.CognitiveServices.ArgumentCompleters
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.CognitiveServices;
    using Microsoft.Azure.Management.CognitiveServices.Models;

    public class AccountSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public AccountSkuCompleterAttribute(string locationParameter, string typeParameter)
               : base(CreateScriptBlock(locationParameter, typeParameter))
        {
        }

        private static ScriptBlock CreateScriptBlock(string locationParameter, string typeParameter)
        {
            string script = new ArgumentCompleterHelper.ScriptBuilder(
                new string[] { locationParameter, typeParameter },
                typeof(AccountSkuCompleterAttribute).Namespace,
                typeof(AccountSkuCompleterAttribute).Name,
                nameof(AccountSkuCompleterAttribute.GetSkuNames)
            ).ToString();
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames(string location, string type)
        {
            lock (_lock)
            {
                IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                var contextHash = ArgumentCompleterHelper.HashContext(context);

                string[] names = new string[] { };

                if (_completionHistory.ContainsKey(contextHash))
                {
                    names = _completionHistory[contextHash];
                }
                else
                {
                    try
                    {
                        names = GetSkusFromClient(context).Where(resourceSku =>
                            (string.IsNullOrWhiteSpace(type) || resourceSku.Kind == type)
                            && (string.IsNullOrWhiteSpace(location) || resourceSku.Locations.Any(x => string.Compare(x, location, StringComparison.OrdinalIgnoreCase) == 0))
                        ).Select(sku => sku.Name).ToArray();
                        _completionHistory.Add(contextHash, names);
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

        private static List<ResourceSku> GetSkusFromClient(IAzureContext context)
        {
            var client = new CognitiveServicesManagementClientWrapper(context).CognitiveServicesManagementClient;
            return ArgumentCompleterHelper.ReadAllPages(client.ResourceSkus.ListAsync(), nextPageLink => client.ResourceSkus.ListNextAsync(nextPageLink));
        }

    }
}
