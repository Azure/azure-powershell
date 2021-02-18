namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Commands.Common.Authentication.Abstractions;
    using Management.ResourceManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;

    public class PSDeploymentWhatIfCmdletParameters
    {
        private string deploymentName;

        public PSDeploymentWhatIfCmdletParameters()
        {
        }

        public PSDeploymentWhatIfCmdletParameters(
            DeploymentScopeType scopeType,
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
            this.ScopeType = scopeType;
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

        public string DeploymentName
        {
            get => this.deploymentName ?? (this.deploymentName = this.GenerateDeployName());
            set => this.deploymentName = value;
        }

        public DeploymentScopeType ScopeType { get; set; }

        public string ManagementGroupId { get; set; }

        public string Location { get; set; }

        public DeploymentMode Mode { get; set; }

        public string QueryString { get; set; }

        public string  ResourceGroupName { get; set; }

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

            // Populate template properties.
            if (!string.IsNullOrEmpty(this.TemplateSpecId))
            {
                properties.TemplateLink = new TemplateLink(id: this.TemplateSpecId);
            }
            else if (Uri.IsWellFormedUriString(this.TemplateUri, UriKind.Absolute))
            {
                properties.TemplateLink = new TemplateLink(this.TemplateUri);
            }
            else
            {
                string templateContent = !string.IsNullOrEmpty(this.TemplateUri)
                    ? FileUtilities.DataStore.ReadFileAsText(this.TemplateUri)
                    : PSJsonSerializer.Serialize(this.TemplateObject);
                properties.Template = JObject.Parse(templateContent);
            }

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

