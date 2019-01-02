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

using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Text;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Threading;
using Microsoft.Azure.Commands.Common;

namespace Microsoft.Azure.Management.Internal.Resources.Utilities
{
    /// <summary>
    /// Extension methods for ResourceManager cmdlets
    /// </summary>
    public static class ResourcesExtensions
    {
        /// <summary>
        /// Add resource group metadata to a deployment result
        /// </summary>
        /// <param name="result">The result to augment</param>
        /// <param name="resourceGroup">Metadata on the resource group for the deployment</param>
        /// <returns>A ResourceGroupDeployment object combining the metadata about the deployment and the resource group it is deployed to</returns>
        public static ResourceGroupDeployment ToPSResourceGroupDeployment(this DeploymentExtended result, string resourceGroup)
        {
            ResourceGroupDeployment deployment = new ResourceGroupDeployment();

            if (result != null)
            {
                deployment = CreatePSResourceGroupDeployment(result.Name, resourceGroup, result.Properties);
            }

            return deployment;
        }

        /// <summary>
        /// Create a text formatted table for deployment variable values
        /// </summary>
        /// <param name="dictionary">Key value pairs for each of the deployment variables</param>
        /// <returns>A string representing the given deployment variables in tabular form</returns>
        public static string ConstructDeploymentVariableTable(Dictionary<string, DeploymentVariable> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            StringBuilder result = new StringBuilder();

            if (dictionary.Count > 0)
            {
                string rowFormat = "{0, -15}  {1, -25}  {2, -10}\r\n";
                result.AppendLine();
                result.AppendFormat(rowFormat, "Name", "Type", "Value");
                result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(15, "="), GeneralUtilities.GenerateSeparator(25, "="), GeneralUtilities.GenerateSeparator(10, "="));

                foreach (KeyValuePair<string, DeploymentVariable> pair in dictionary)
                {
                    result.AppendFormat(rowFormat, pair.Key, pair.Value.Type, pair.Value.Value);
                }
            }

            return result.ToString();

        }

        /// <summary>
        /// Create a tabular format for resource tags metadata
        /// </summary>
        /// <param name="tags">The dictionary of tags</param>
        /// <returns>A string representation of the tags formatted as a table</returns>
        public static string ConstructTagsTable(Hashtable tags)
        {
            if (tags == null || tags.Count == 0)
            {
                return null;
            }

            StringBuilder resourcesTable = new StringBuilder();

            var tagsDictionary = TagsConversionHelper.CreateTagDictionary(tags, false);

            int maxNameLength = Math.Max("Name".Length, tagsDictionary.Max(tag => tag.Key.Length));
            int maxValueLength = Math.Max("Value".Length, tagsDictionary.Max(tag => tag.Value.Length));

            string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
            resourcesTable.AppendLine();
            resourcesTable.AppendFormat(rowFormat, "Name", "Value");
            resourcesTable.AppendFormat(rowFormat,
                GeneralUtilities.GenerateSeparator(maxNameLength, "="),
                GeneralUtilities.GenerateSeparator(maxValueLength, "="));

            foreach (var tag in tagsDictionary)
            {
                if (tag.Key.StartsWith(TagsClient.ExecludedTagPrefix))
                {
                    continue;
                }

                resourcesTable.AppendFormat(rowFormat, tag.Key, tag.Value);
            }

            return resourcesTable.ToString();
        }

        private static ResourceGroupDeployment CreatePSResourceGroupDeployment(
            string name,
            string gesourceGroup,
            DeploymentPropertiesExtended properties)
        {
            ResourceGroupDeployment deploymentObject = new ResourceGroupDeployment();

            deploymentObject.DeploymentName = name;
            deploymentObject.ResourceGroupName = gesourceGroup;

            if (properties != null)
            {
                deploymentObject.Mode = properties.Mode;
                deploymentObject.ProvisioningState = properties.ProvisioningState;
                deploymentObject.TemplateLink = properties.TemplateLink;
                deploymentObject.Timestamp = properties.Timestamp;
                deploymentObject.CorrelationId = properties.CorrelationId;

                if (properties.DebugSetting != null && !string.IsNullOrEmpty(properties.DebugSetting.DetailLevel))
                {
                    deploymentObject.DeploymentDebugLogLevel = properties.DebugSetting.DetailLevel;
                }

                if (properties.Outputs != null && !string.IsNullOrEmpty(properties.Outputs.ToString()))
                {
                    Dictionary<string, DeploymentVariable> outputs = JsonConvert.DeserializeObject<Dictionary<string, DeploymentVariable>>(properties.Outputs.ToString());
                    deploymentObject.Outputs = outputs;
                }

                if (properties.Parameters != null && !string.IsNullOrEmpty(properties.Parameters.ToString()))
                {
                    Dictionary<string, DeploymentVariable> parameters = JsonConvert.DeserializeObject<Dictionary<string, DeploymentVariable>>(properties.Parameters.ToString());
                    deploymentObject.Parameters = parameters;
                }

                if (properties.TemplateLink != null)
                {
                    deploymentObject.TemplateLinkString = ConstructTemplateLinkView(properties.TemplateLink);
                }
            }

            return deploymentObject;
        }

        private static string ConstructTemplateLinkView(TemplateLink templateLink)
        {
            if (templateLink == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine();
            result.AppendLine(string.Format("{0, -15}: {1}", "Uri", templateLink.Uri));
            result.AppendLine(string.Format("{0, -15}: {1}", "ContentVersion", templateLink.ContentVersion));

            return result.ToString();
        }
    }
}