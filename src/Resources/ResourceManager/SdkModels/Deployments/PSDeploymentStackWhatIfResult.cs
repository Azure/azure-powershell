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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the result of a Deployment Stack What-If operation.
    /// Maps to the API response from Azure Resource Manager.
    /// </summary>
    public class PSDeploymentStackWhatIfResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public DeploymentStackWhatIfProperties Properties { get; set; }

        public override string ToString()
        {
            return DeploymentStackWhatIfFormatter.Format(this);
        }
    }

    public class DeploymentStackWhatIfProperties
    {
        [JsonProperty("deploymentStackResourceId")]
        public string DeploymentStackResourceId { get; set; }

        [JsonProperty("retentionInterval")]
        public string RetentionInterval { get; set; }

        [JsonProperty("provisioningState")]
        public string ProvisioningState { get; set; }

        [JsonProperty("deploymentStackLastModified")]
        public DateTime? DeploymentStackLastModified { get; set; }

        [JsonProperty("deploymentExtensions")]
        public IList<DeploymentExtension> DeploymentExtensions { get; set; }

        [JsonProperty("changes")]
        public DeploymentStackWhatIfChanges Changes { get; set; }

        [JsonProperty("diagnostics")]
        public IList<DeploymentStackDiagnostic> Diagnostics { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

        [JsonProperty("actionOnUnmanage")]
        public ActionOnUnmanage ActionOnUnmanage { get; set; }

        [JsonProperty("deploymentScope")]
        public string DeploymentScope { get; set; }

        [JsonProperty("denySettings")]
        public DenySettings DenySettings { get; set; }

        [JsonProperty("parametersLink")]
        public ParametersLink ParametersLink { get; set; }

        [JsonProperty("templateLink")]
        public TemplateLink TemplateLink { get; set; }

        [JsonProperty("bypassStackOutOfSyncError")]
        public bool? BypassStackOutOfSyncError { get; set; }
    }

    public class DeploymentExtension
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("configId")]
        public string ConfigId { get; set; }

        [JsonProperty("config")]
        public IDictionary<string, DeploymentStackExtensionConfigItem> Config { get; set; }
    }

    public class DeploymentStackWhatIfChanges
    {
        [JsonProperty("resourceChanges")]
        public IList<DeploymentStackResourceChange> ResourceChanges { get; set; }

        [JsonProperty("deploymentScopeChange")]
        public DeploymentStackChangeBase DeploymentScopeChange { get; set; }

        [JsonProperty("denySettingsChange")]
        public DeploymentStackChangeDeltaRecord DenySettingsChange { get; set; }
    }

    public class DeploymentStackChangeBase
    {
        [JsonProperty("changeType")]
        public string ChangeType { get; set; }

        [JsonProperty("before")]
        public object Before { get; set; }

        [JsonProperty("after")]
        public object After { get; set; }
    }

    public class DeploymentStackResourceChange
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("changeType")]
        public string ChangeType { get; set; }

        [JsonProperty("changeCertainty")]
        public string ChangeCertainty { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("managementStatusChange")]
        public DeploymentStackChangeBase ManagementStatusChange { get; set; }

        [JsonProperty("denyStatusChange")]
        public DeploymentStackChangeBase DenyStatusChange { get; set; }

        [JsonProperty("resourceConfigurationChanges")]
        public ResourceConfigurationChanges ResourceConfigurationChanges { get; set; }

        [JsonProperty("extension")]
        public DeploymentStackExtensionInfo Extension { get; set; }

        [JsonProperty("identifiers")]
        public IDictionary<string, object> Identifiers { get; set; }
    }

    public class ResourceConfigurationChanges
    {
        [JsonProperty("before")]
        public object Before { get; set; }

        [JsonProperty("after")]
        public object After { get; set; }

        [JsonProperty("delta")]
        public IList<DeploymentStackPropertyChange> Delta { get; set; }
    }

    public class DeploymentStackChangeDeltaRecord
    {
        [JsonProperty("before")]
        public object Before { get; set; }

        [JsonProperty("after")]
        public object After { get; set; }

        [JsonProperty("delta")]
        public IList<DeploymentStackPropertyChange> Delta { get; set; }
    }

    public class DeploymentStackPropertyChange
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("changeType")]
        public string ChangeType { get; set; }

        [JsonProperty("before")]
        public object Before { get; set; }

        [JsonProperty("after")]
        public object After { get; set; }

        [JsonProperty("children")]
        public IList<DeploymentStackPropertyChange> Children { get; set; }
    }

    public class DeploymentStackExtensionInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("configId")]
        public string ConfigId { get; set; }

        [JsonProperty("config")]
        public IDictionary<string, DeploymentStackExtensionConfigItem> Config { get; set; }
    }

    public class DeploymentStackExtensionConfigItem
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("keyVaultReference")]
        public DeploymentStackKeyVaultReference KeyVaultReference { get; set; }
    }

    public class DeploymentStackKeyVaultReference
    {
        [JsonProperty("secretName")]
        public string SecretName { get; set; }

        [JsonProperty("secretVersion")]
        public string SecretVersion { get; set; }

        [JsonProperty("keyVault")]
        public DeploymentStackKeyVaultInfo KeyVault { get; set; }
    }

    public class DeploymentStackKeyVaultInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class DeploymentStackDiagnostic
    {
        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }

    public class ActionOnUnmanage
    {
        [JsonProperty("resources")]
        public string Resources { get; set; }

        [JsonProperty("resourceGroups")]
        public string ResourceGroups { get; set; }

        [JsonProperty("managementGroups")]
        public string ManagementGroups { get; set; }

        [JsonProperty("resourcesWithoutDeleteSupport")]
        public string ResourcesWithoutDeleteSupport { get; set; }
    }

    public class DenySettings
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("applyToChildScopes")]
        public bool? ApplyToChildScopes { get; set; }

        [JsonProperty("excludedPrincipals")]
        public IList<string> ExcludedPrincipals { get; set; }

        [JsonProperty("excludedActions")]
        public IList<string> ExcludedActions { get; set; }
    }

    public class ParametersLink
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class TemplateLink
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}