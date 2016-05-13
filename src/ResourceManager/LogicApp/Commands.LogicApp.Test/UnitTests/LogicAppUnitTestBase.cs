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

namespace Microsoft.Azure.Commands.LogicApp.Test.UnitTests
{
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

    /// <summary>
    /// Base class for the Logic app command tests
    /// </summary>
    public class LogicAppUnitTestBase : RMTestBase
    {
        /// <summary>
        /// Name of the workflow used for testing.
        /// </summary>
        protected const string Name = "TestWorkflow";

        /// <summary>
        /// Definition file name present in Resource folder
        /// </summary>
        protected const string DefinitionFilePath = @"LogicAppDefinition.json";

        /// <summary>
        /// Parameter file name present in Resource folder
        /// </summary>
        protected const string ParameterFilePath = @"LogicAppParameter.json";

        /// <summary>
        /// Name of the resource group used for testing
        /// </summary>
        protected const string ResourceGroupName = "TestResourceGroup";

    }
}
