//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters
{
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Compute;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Compute;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// A SKU name completer for general VM scale set.
    /// </summary>
    public class VmScaleSetSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public VmScaleSetSkuCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = new ArgumentCompleterHelper.ScriptBuilder(
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
                string[] names;

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
            var client = new ComputeClient(context).ComputeManagementClient.ResourceSkus;
            return ArgumentCompleterHelper.ReadAllPages(client.ListAsync(), nextPageLink => client.ListNextAsync(nextPageLink))
                .Select(sku => sku.Name)
                .ToArray();
        }
    }
}
