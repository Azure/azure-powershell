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
using Microsoft.Azure.Commands.CodeSigning.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.CodeSigning.Test
{
    public class CodeSigningUnitTestBase : RMTestBase
    {
        protected const string subscriptionId = "subscriptionid";

        protected const string ResourceGroupName = "rg-dawang";

        protected const string Location = "southcentralus";

        protected const string AccountName = "dawang-acct-testcanary1";

        protected const string ProfileName = "dawang-acct-testcanary1privatecertificate10";

        protected const string EndPointUrl = "https://scus.codesigning.azure.net/";

        protected Mock<ICodeSigningServiceClient> codeSigningServiceClientMock;

        protected Mock<ICommandRuntime> commandRuntimeMock;

        public virtual void SetupTest()
        {
            codeSigningServiceClientMock = new Mock<ICodeSigningServiceClient>();

            commandRuntimeMock = new Mock<ICommandRuntime>();
        }
    }
}
