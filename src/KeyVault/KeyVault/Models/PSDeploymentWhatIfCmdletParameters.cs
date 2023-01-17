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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Common.Exceptions;
    using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
    using PSKeyVaultPropertiesResources = Microsoft.Azure.Commands.KeyVault.Properties.Resources;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;

    public class PSDeploymentWhatIfCmdletParameters
    {
        #region Constants

        private const string DefaultTemplatePath = "Microsoft.Azure.Commands.KeyVault.Resources.keyvaultTemplate.json";

        #endregion
        public PSDeploymentWhatIfCmdletParameters(
            string deploymentName = null,
            DeploymentMode mode = DeploymentMode.Incremental,
            string location = null,
            string managementGroupId = null,
            string queryString = null,
            string resourceGroupName = null,
            string templateUri = null,
            string templateSpecId = null,
            string templateParametersUri = null,
            Hashtable templateObject = null,
            Hashtable templateParametersObject = null,
            WhatIfResultFormat resultFormat = WhatIfResultFormat.FullResourcePayloads,
            string[] excludeChangeTypes = null)
        {
            this.DeploymentName = deploymentName ?? this.GenerateDeployName();
            this.Mode = mode;
            this.Location = location;
            this.ManagementGroupId = managementGroupId;
            this.QueryString = queryString;
            this.ResourceGroupName = resourceGroupName;
            this.TemplateUri = templateUri;
            this.TemplateParametersUri = templateParametersUri;
            this.TemplateObject = templateObject;
            this.TemplateSpecId = templateSpecId;
            this.TemplateParametersObject = templateParametersObject;
            this.ResultFormat = resultFormat;
            this.ExcludeChangeTypes = excludeChangeTypes?
                .Select(changeType => changeType.ToLowerInvariant())
                .Distinct()
                .Select(changeType => (ChangeType)Enum.Parse(typeof(ChangeType), changeType, true));
        }
        private string deploymentName;
        public string DeploymentName
        {
            get => this.deploymentName ?? (this.deploymentName = this.GenerateDeployName());
            set => this.deploymentName = value;
        }

        public string ManagementGroupId { get; set; }

        public string Location { get; set; }

        public DeploymentMode Mode { get; set; }

        public string QueryString { get; set; }

        public string ResourceGroupName { get; set; }

        public string TemplateSpecId { get; set; }

        public string TemplateUri { get; set; }

        public string TemplateParametersUri { get; set; }

        public Hashtable TemplateObject { get; set; }

        public Hashtable TemplateParametersObject { get; set; }

        public WhatIfResultFormat ResultFormat { get; set; }

        public IEnumerable<ChangeType> ExcludeChangeTypes { get; }

        public DeploymentWhatIf ToDeploymentWhatIf()
        {
            var properties = new DeploymentWhatIfProperties
            {
                Mode = this.Mode,
                WhatIfSettings = new DeploymentWhatIfSettings(this.ResultFormat)
            };

            string templateContent = null;
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultTemplatePath))
                using (var reader = new StreamReader(stream))
                {
                    templateContent = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new AzPSArgumentException(string.Format(PSKeyVaultPropertiesResources.FileNotFound, ex.Message), "TemplateFile");
            };
            var temp = JObject.Parse(templateContent);
            temp["resources"][0]["name"] = this.deploymentName;
            properties.Template = temp;

            // Populate template parameters properties.
            if (Uri.IsWellFormedUriString(this.TemplateParametersUri, UriKind.Absolute))
            {
                properties.ParametersLink = new ParametersLink(this.TemplateParametersUri);
            }
            else
            {
                // ToDictionary is needed for extracting value from a secure string. Do not remove it.
                Dictionary<string, object> parametersDictionary = this.TemplateParametersObject?.ToDictionary(false);
                string parametersContent = parametersDictionary != null
                    ? PSJsonSerializer.Serialize(parametersDictionary)
                    : null;
                properties.Parameters = !string.IsNullOrEmpty(parametersContent)
                    ? JObject.Parse(parametersContent)
                    : null;
            }

            return new DeploymentWhatIf(properties, this.Location);
        }

        private string GenerateDeployName()
        {
            return !string.IsNullOrEmpty(this.TemplateUri)
                ? Path.GetFileNameWithoutExtension(this.TemplateUri)
                : Guid.NewGuid().ToString();
        }
    }
}