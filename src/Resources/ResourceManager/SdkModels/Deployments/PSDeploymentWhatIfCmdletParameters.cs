namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections;
    using System.IO;
    using Commands.Common.Authentication.Abstractions;
    using Management.ResourceManager.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using WindowsAzure.Commands.Common;

    public class PSDeploymentWhatIfCmdletParameters
    {
        private string deploymentName;

        public string DeploymentName
        {
            get => this.deploymentName ?? (this.deploymentName = this.GenerateDeployName());
            set => this.deploymentName = value;
        }

        public string Location { get; set; }

        public DeploymentMode Mode { get; set; }

        public string  ResourceGroupName { get; set; }

        public string TemplateSpecId { get; set; }

        public string TemplateUri { get; set; }

        public string TemplateParametersUri { get; set; }

        public Hashtable TemplateObject { get; set; }

        public Hashtable TemplateParametersObject { get; set; }

        public WhatIfResultFormat ResultFormat { get; set; }

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
                    : JsonConvert.SerializeObject(this.TemplateObject);
                properties.Template = JObject.Parse(templateContent);
            }

            // Populate template parameters properties.
            if (Uri.IsWellFormedUriString(this.TemplateParametersUri, UriKind.Absolute))
            {
                properties.ParametersLink = new ParametersLink(this.TemplateParametersUri);
            }
            else
            {
                string parametersContent = this.TemplateParametersObject != null
                    ? JsonConvert.SerializeObject(this.TemplateParametersObject.ToDictionary(false))
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

