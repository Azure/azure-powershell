// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters
{
    using Commands.Common.Authentication.Abstractions;
    using Commands.Common.Authentication;
    using Internal.Subscriptions;
    using Properties;
    using Management.Internal.Resources.Models;
    using Management.Internal.Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Rest.Azure;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using System.Text;
    using Microsoft.Rest.Azure.OData;


    /// <summary>
    /// This attribute will allow the user to autocomplete the -Location parameter of a cmdlet with valid locations (as determined by the list of ResourceTypes given)
    /// </summary>
    public class ResourceNameCompleterAttribute : ArgumentCompleterAttribute
    {
        private static int _timeout = 3;

        /// <summary>
        /// Pass in a list of ResourceTypes and this class will provide a list of locations that are common to all ResourceTypes given. This will then be available to the user to tab through.
        /// Example: ResourceNameCompleter(new string[] { "Microsoft.Batch/operations", "ResourceGroupName" })]
        /// </summary>
        /// <param name="resourceTypes"></param>
        public ResourceNameCompleterAttribute(string resourceType, string[] parentResourceParameterNames) : base(CreateScriptBlock(resourceType, parentResourceParameterNames))
        {
        }

        public static string[] FindResources(string resourceType, string[] parentResources, int timeout)
        {
            _timeout = timeout;
            return FindResources(resourceType, parentResources);
        }

        public static string[] FindResources(string resourceType, string[] parentResources)
        {
            try
            {
                List<ResourceIdentifier> ids = GetResourceIdsFromClient(resourceType, parentResources[0]);

                List<string> output = FilterByParentResource(ids, parentResources);

                return output.ToArray();
            }
            catch (Exception ex)
            {
                if (ex == null) { }
#if DEBUG
                throw ex;
#endif
            }
#if !DEBUG
            return new string[0];
#endif
        }

        /// <summary>
        /// Create ScriptBlock that registers the correct location for tab completetion of the -Location parameter
        /// </summary>
        /// <param name="resourceTypes"></param>
        /// <returns></returns>
        public static ScriptBlock CreateScriptBlock(string resourceType, string[] parentResourceNames)
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$parentResources = @()\n";
            foreach (var parentResourceName in parentResourceNames)
            {
                script += String.Format("$parentResources += $fakeBoundParameter[\"{0}\"]\n", parentResourceName);
            }
            script += String.Format("$resourceType = \"{0}\"\n", resourceType) +
                "$resources = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceNameCompleterAttribute]::FindResources($resourceType, $parentResources)\n" +
                "$resources | Where-Object { $_ -Like \"$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }

        public static string CreateFilter(
            string resourceType,
            string filter)
        {
            var filterStringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(resourceType))
            {
                if (filterStringBuilder.Length > 0)
                {
                    filterStringBuilder.Append(" AND ");
                }

                filterStringBuilder.AppendFormat("resourceType EQ '{0}'", resourceType);
            }

            return filterStringBuilder.Length > 0
                ? filterStringBuilder.ToString()
                : filter.CoalesceString();
        }

        public static List<ResourceIdentifier> GetResourceIdsFromClient(string resourceType, string resourceGroupName)
        {
            IAzureContext context = AzureRmProfileProvider.Instance?.Profile?.DefaultContext;
            IResourceManagementClient client = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            var odataQuery = new ODataQuery<GenericResourceFilter>(r => r.ResourceType == resourceType);

            var allProviders = string.IsNullOrWhiteSpace(resourceGroupName)
                ? client.Resources.ListAsync(odataQuery)
                : client.ResourceGroups.ListResourcesAsync(resourceGroupName, odataQuery);

            var timeoutDuration = _timeout == -1 ? TimeSpan.FromMinutes(5) : TimeSpan.FromSeconds(_timeout);
            var hasNotTimedOut = allProviders.Wait(timeoutDuration);
            var hasResult = allProviders.Result != null;
            var isSuccessful = hasNotTimedOut && hasResult;

#if DEBUG
            if (!isSuccessful)
            {
                throw new InvalidOperationException(!hasResult ? "Result from client.Providers is null" : Resources.TimeOutForProviderList);
            }
#endif

            return isSuccessful
                ? allProviders.Result.Select(resource => new ResourceIdentifier(resource.Id)).ToList()
                : new List<ResourceIdentifier>();
        }

        public static List<string> FilterByParentResource(List<ResourceIdentifier> ids, string[] parentResources)
        {
            return ids.Where(resource =>
            {
                if (resource.ParentResource == null)
                {
                    return true;
                }

                var actualParentResources = resource.ParentResource.Split('/').Where((pr, i) => i % 2 != 0).ToArray();
                var parentResourcesExceptFirst = parentResources.Skip(1).ToArray();
                if (actualParentResources.Count() != parentResourcesExceptFirst.Count())
                {
#if DEBUG
                    throw new InvalidOperationException("Improper number of parent resources were given");
#else
                    return true;
#endif
                }

                for (int i = 0; i < actualParentResources.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(parentResourcesExceptFirst[i]) && !string.Equals(actualParentResources[i], parentResourcesExceptFirst[i], StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }

                return true;
            }).Select(resource => resource.ResourceName).ToList();
        }
    }
}
