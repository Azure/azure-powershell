using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Management.Storage;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Storage.ArgumentCompleters
{
    public class StorageAccountSkuNameCompleterAttribute : ArgumentCompleterAttribute
    {
        public StorageAccountSkuNameCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = new ArgumentCompleterHelper.ScriptBuilder(
                new string[] { },
                typeof(StorageAccountSkuNameCompleterAttribute).Namespace,
                typeof(StorageAccountSkuNameCompleterAttribute).Name,
                nameof(StorageAccountSkuNameCompleterAttribute.GetSkuNames)
            ).ToString();
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames()
        {
            lock (_lock)
            {
                var names = new string[] { };

                IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                var contextHash = ArgumentCompleterHelper.HashContext(context);

                if (_completionHistory.ContainsKey(contextHash))
                {
                    names = _completionHistory[contextHash];
                }
                else
                {

                    try
                    {
                        names = GetSkuNamesFromClient(context);
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

        private static string[] GetSkuNamesFromClient(IAzureContext context)
        {
            var client = new StorageManagementClientWrapper(context).StorageManagementClient.Skus;
            return client.List()
                .Select(sku => sku.Name)
                .ToArray();
        }
    }
}