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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    internal static class ParameterSet
    {
        /// <summary>
        /// Parameter set to create Logic app with definition object
        /// </summary>
        public const string LogicAppWithDefinition = "LogicAppWithDefinitionParameterSet";

        /// <summary>
        /// Parameter set to create Logic app with definition link
        /// </summary>
        public const string LogicAppWithDefinitionLink = "LogicAppWithDefinitionLinkParameterSet";

        /// <summary>
        /// Parameter set to create Logic app with definition file
        /// </summary>
        public const string LogicAppWithDefinitionFile = "LogicAppWithDefinitionFileParameterSet";

        public const string ByIntegrationAccount = "ByIntegrationAccount";
        public const string ByResourceId = "ByResourceId";
        public const string ByInputObject = "ByInputObject";

        public const string ByInputObjectAndContentLink = "ByInputObjectAndContentLink";
        public const string ByResourceIdAndContentLink = "ByResourceIdAndContentLink";
        public const string ByIntegrationAccountAndContentLink = "ByIntegrationAccountAndContentLink";

        public const string ByInputObjectAndFileBytes = "ByInputObjectAndFileBytes";
        public const string ByResourceIdAndFileBytes = "ByResourceIdAndFileBytes";
        public const string ByIntegrationAccountAndFileBytes = "ByIntegrationAccountAndFileBytes";

        public const string ByInputObjectAndFilePath = "ByInputObjectAndFilePath";
        public const string ByResourceIdAndFilePath = "ByResourceIdAndFilePath";
        public const string ByIntegrationAccountAndFilePath = "ByIntegrationAccountAndFilePath";

        public const string ByInputObjectAndJson = "ByInputObjectAndJson";
        public const string ByResourceIdAndJson = "ByResourceIdAndJson";
        public const string ByIntegrationAccountAndJson = "ByIntegrationAccountAndJson";

        public const string ByInputObjectAndParameters = "ByInputObjectAndParameters";
        public const string ByResourceIdAndParameters = "ByResourceIdAndParameters";
        public const string ByIntegrationAccountAndParameters = "ByIntegrationAccountAndParameters";
    }
}