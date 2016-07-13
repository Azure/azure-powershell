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

using System;
using Microsoft.Azure.Management.Logic;

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Logic.Models;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using Microsoft.Azure.Management.WebSites.Models;

    /// <summary>
    /// Helper class for the logic app commands 
    /// </summary>
    public static class CmdletHelper
    {
        /// <summary>
        /// Creates the definition object from file.
        /// </summary>
        /// <param name="definitionFilePath">File path of the definition</param>
        /// <returns>Json model defintion object</returns>
        internal static JToken GetDefinitionFromFile(string definitionFilePath)
        {
            JToken definition = null;

            if (!string.IsNullOrEmpty(definitionFilePath))
            {
                if (!(new FileInfo(definitionFilePath)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                        Properties.Resource.FileDoesNotExist, definitionFilePath));
                }

                definition = JToken.Parse(File.ReadAllText(definitionFilePath));
            }

            return definition;
        }

        /// <summary>
        /// Get file content.
        /// </summary>
        /// <param name="filePath">The File path.</param>
        /// <returns>String content</returns>
        internal static string GetContentFromFile(string filePath)
        {
            string content = string.Empty;

            if (!string.IsNullOrEmpty(filePath))
            {
                if (!(new FileInfo(filePath)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                        Properties.Resource.FileDoesNotExist, filePath));
                }

                content = File.ReadAllText(filePath);
            }

            return content;
        }

        /// <summary>
        /// Check if file exists
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Boolean result indicating whether file exists.</returns>
        internal static bool FileExists(string filePath)
        {
            if (!(new FileInfo(filePath)).Exists)
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.FileDoesNotExist, filePath));
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Convert string content to AgreementContent object.
        /// </summary>
        /// <param name="content">The agreement content.</param>
        /// <returns>AgreementContent object.</returns>
        internal static AgreementContent ConvertToAgreementContent(string content)
        {
            AgreementContent agreementContent = null;

            if (!string.IsNullOrEmpty(content))
            {
                agreementContent = JsonConvert.DeserializeObject<AgreementContent>(content);
            }

            return agreementContent;
        }

        /// <summary>
        /// Build App service plan id using plan name and resourcegroup name
        /// Null check for parameter not needed as both these parameters are required parameters.
        /// </summary>
        /// <param name="planName">App service plan name</param>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="subscriptionId">Subscription id</param>
        /// <returns>App service plan id</returns>
        internal static string BuildAppServicePlanId(string planName, string resourceGroupName, string subscriptionId)
        {
            return string.Format(CultureInfo.InvariantCulture,
                Properties.Resource.ApplicationServicePlanIdFormat, subscriptionId, resourceGroupName, planName);
        }

        /// <summary>
        /// Converts IEnumerator to IEnumerable
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="enumerator">Enumerator to be converted</param>
        /// <returns>IEnumerable collection</returns>
        public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        /// <summary>
        /// Convert object to business identity list.
        /// </summary>
        /// <param name="businessIdentityObject">business identity object.</param>
        /// <returns>List of business identity.</returns>
        internal static IList<BusinessIdentity> ConvertToBusinessIdentityList(object businessIdentityObject)
        {
            IList<BusinessIdentity> identities = null;
            if (businessIdentityObject is Hashtable)
            {
                var collection = businessIdentityObject as Hashtable;
                identities = new List<BusinessIdentity>();

                foreach (var key in collection.Keys)
                {
                    identities.Add(new BusinessIdentity()
                    {
                        Qualifier = key.ToString(),
                        Value = collection[key].ToString()
                    });
                }
            }

            return identities;
        }

        /// <summary>
        /// Convert the valid metadata object.
        /// </summary>
        /// <param name="metadata">The metadata object.</param>
        /// <returns>Json object</returns>
        internal static JObject ConvertToMetadataJObject(object metadata)
        {
            try
            {
                return JObject.Parse(metadata.ToString());                
            }
            catch 
            {
                throw new PSArgumentException(Properties.Resource.InvalidMetadata);
            }
        }

        /// <summary>
        /// Creates the dictionary collection from the parameter file
        /// </summary>
        /// <param name="parametersFilePath">Parameter file path</param>
        /// <returns>Workflow parameter dictionary</returns>
        internal static Dictionary<string, WorkflowParameter> GetParametersFromFile(string parametersFilePath)
        {
            Dictionary<string, WorkflowParameter> inputParameters = null;

            if (!string.IsNullOrEmpty(parametersFilePath))
            {
                if (!(new FileInfo(parametersFilePath)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                        Properties.Resource.FileDoesNotExist, parametersFilePath));
                }

                var inputParametersObject = JObject.Parse(File.ReadAllText(parametersFilePath));
                var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(inputParametersObject.ToString());

                inputParameters = new Dictionary<string, WorkflowParameter>();

                foreach (var parameter in values)
                {
                    var workflowParameter = JsonConvert.DeserializeObject<WorkflowParameter>(parameter.Value.ToString());
                    inputParameters.Add(parameter.Key, workflowParameter);
                }
            }
            return inputParameters;
        }

        /// <summary>
        /// Convert object to WorkflowParameter dictionary.
        /// </summary>
        /// <param name="parametersObject">Parameters object</param>
        /// <returns>Workflow parameter dictionary</returns>
        internal static Dictionary<string, WorkflowParameter> ConvertToWorkflowParameterDictionary(
            object parametersObject)
        {
            Dictionary<string, WorkflowParameter> workflowParameters = null;
            if (parametersObject is Hashtable)
            {
                var collection = parametersObject as Hashtable;
                var inputParameters = new Dictionary<string, WorkflowParameter>();

                foreach (var key in collection.Keys)
                {
                    inputParameters.Add(key.ToString(), new WorkflowParameter
                    {
                        Value = collection[key].ToString()
                    });
                }
                workflowParameters = inputParameters;
            }
            else if (parametersObject is Dictionary<string, WorkflowParameter>)
            {
                workflowParameters = parametersObject as Dictionary<string, WorkflowParameter>;
            }
            return workflowParameters;
        }
    }
}