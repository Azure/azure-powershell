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

using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactories.Test
{
    public class DataFactoryUnitTestBase : RMTestBase
    {
        protected const string subscriptionId = "subscriptionid";

        protected const string DataFactoryName = "foo";

        protected const string GatewayName = "foo";

        protected const string ResourceGroupName = "bar";

        protected const string Location = "centralus";

        protected Mock<DataFactoryClient> dataFactoriesClientMock;

        protected Mock<ICommandRuntime> commandRuntimeMock;

        public virtual void SetupTest()
        {
            dataFactoriesClientMock = new Mock<DataFactoryClient>();

            commandRuntimeMock = new Mock<ICommandRuntime>();
        }
    }
}