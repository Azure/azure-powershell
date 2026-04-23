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
    using System.Collections;

    /// <summary>
    /// Parameters for Deployment Stack What-If operation.
    /// </summary>
    public class PSDeploymentStackWhatIfParameters
    {
        public string StackName { get; set; }

        public string ResourceGroupName { get; set; }

        public string ManagementGroupId { get; set; }

        public string Location { get; set; }

        public string TemplateFile { get; set; }

        public string TemplateUri { get; set; }

        public string TemplateSpecId { get; set; }

        public Hashtable TemplateObject { get; set; }

        public string TemplateParameterUri { get; set; }

        public Hashtable TemplateParameterObject { get; set; }

        public string Description { get; set; }

        public string DeploymentScope { get; set; }

        public string ResourcesCleanupAction { get; set; }

        public string ResourceGroupsCleanupAction { get; set; }

        public string ManagementGroupsCleanupAction { get; set; }

        public string DenySettingsMode { get; set; }

        public string[] DenySettingsExcludedPrincipals { get; set; }

        public string[] DenySettingsExcludedActions { get; set; }

        public bool DenySettingsApplyToChildScopes { get; set; }
    }
}