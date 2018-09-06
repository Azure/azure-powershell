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

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    /// <summary>
    /// Parameter set names
    /// </summary>
    public static class ParameterSetNames
    {
        public const string ManagementGroupScope = "ManagementGroupScope";
        public const string SubscriptionScope = "SubscriptionScope";
        public const string ResourceGroupScope = "ResourceGroupScope";
        public const string ResourceScope = "ResourceScope";
        public const string PolicySetDefinitionScope = "PolicySetDefinitionScope";
        public const string PolicyDefinitionScope = "PolicyDefinitionScope";
        public const string SubscriptionLevelPolicyAssignmentScope = "SubscriptionLevelPolicyAssignmentScope";
        public const string ResourceGroupLevelPolicyAssignmentScope = "ResourceGroupLevelPolicyAssignmentScope";
    }
}
