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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    /// <summary>
    /// Class for holding constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The <c>Microsoft.Resource</c> namespace.
        /// </summary>
        public static readonly string MicrosoftResourceNamesapce = "Microsoft.Resources";

        /// <summary>
        /// The <c>Microsoft.Authorization</c> namespace.
        /// </summary>
        public static readonly string MicrosoftAuthorizationNamespace = "Microsoft.Authorization";

        /// <summary>
        /// The string literal <c>ResourceGroups</c>
        /// </summary>
        public static readonly string ResourceGroups = "ResourceGroups";

        /// <summary>
        /// The string literal <c>Providers</c>
        /// </summary>
        public static readonly string Providers = "Providers";

        /// <summary>
        /// The string literal <c>Subscriptions</c>
        /// </summary>
        public static readonly string Subscriptions = "Subscriptions";

        /// <summary>
        /// The string literal <c>Location</c>
        /// </summary>
        public static readonly string Location = "Location";

        /// <summary>
        /// The default API version.
        /// </summary>
        public static readonly string DefaultApiVersion = "2015-01-01";

        /// <summary>
        /// The default policy API version.
        /// </summary>
        public static readonly string PolicyApiVersion = "2016-04-01";

        /// <summary>
        /// The default providers API version.
        /// </summary>
        public static readonly string ProvidersApiVersion = "2016-07-01";

        /// <summary>
        /// The default Lock API version.
        /// </summary>
        public static readonly string LockApiVersion = "2015-01-01";

        /// <summary>
        /// The default deployment operation API version.
        /// </summary>
        public static readonly string DeploymentOperationApiVersion = "2016-02-01";

        /// <summary>
        /// The move action.
        /// </summary>
        public static readonly string MoveResources = "moveResources";

        /// <summary>
        /// The export action.
        /// </summary>
        public static readonly string ExportTemplate = "exportTemplate";

        /// <summary>
        /// The locks resource type.
        /// </summary>
        public static readonly string MicrosoftAuthorizationLocksType = "Microsoft.Authorization/locks";

        /// <summary>
        /// The deployment operations resource type.
        /// </summary>
        public static readonly string MicrosoftResourcesDeploymentOperationsType = Constants.MicrosoftResourceNamesapce + "/deployments/operations";

        /// <summary>
        /// The deployments resource type.
        /// </summary>
        public static readonly string MicrosoftResourcesDeploymentType = Constants.MicrosoftResourceNamesapce + "/deployments";

        /// <summary>
        /// The policy definition resource type.
        /// </summary>
        public static readonly string MicrosoftAuthorizationPolicyDefinitionType = Constants.MicrosoftAuthorizationNamespace + "/policydefinitions";

        /// <summary>
        /// The policy definition resource type.
        /// </summary>
        public static readonly string MicrosoftAuthorizationPolicyAssignmentType = Constants.MicrosoftAuthorizationNamespace + "/policyassignments";

        /// <summary>
        /// The type name of the generic resource.
        /// </summary>
        public static readonly string MicrosoftAzureResource = "Microsoft.Azure.Resource";
    }
}
