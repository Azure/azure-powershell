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

using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ServiceBus;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.ServiceBus
{
    
    public class GetAzureSBNamespaceTests : TestBase
    {
        Mock<ServiceBusClientExtensions> client;
        MockCommandRuntime mockCommandRuntime;
        GetAzureSBNamespaceCommand cmdlet;

        public GetAzureSBNamespaceTests()
        {
            new FileSystemHelper(this).CreateAzureSdkDirectoryAndImportPublishSettings();
            client = new Mock<ServiceBusClientExtensions>();
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new GetAzureSBNamespaceCommand()
            {
                CommandRuntime = mockCommandRuntime,
                Client = client.Object
            };
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
        }

        [Fact]
        public void GetAzureSBNamespaceSuccessfull()
        {
            // Setup
            string name = "test";
            cmdlet.Name = name;
            ExtendedServiceBusNamespace expected = new ExtendedServiceBusNamespace { Name = name };
            client.Setup(f => f.GetNamespace(name)).Returns(expected);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            ExtendedServiceBusNamespace actual = mockCommandRuntime.OutputPipeline[0] as ExtendedServiceBusNamespace;
            Assert.Equal<string>(expected.Name, actual.Name);
        }

        [Fact]
        public void ListNamespacesSuccessfull()
        {
            // Setup
            string name1 = "test1";
            string name2 = "test2";
            List<ExtendedServiceBusNamespace> expected = new List<ExtendedServiceBusNamespace>();
            expected.Add(new ExtendedServiceBusNamespace { Name = name1 });
            expected.Add(new ExtendedServiceBusNamespace { Name = name2 });
            client.Setup(f => f.GetNamespace()).Returns(expected);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            List<ExtendedServiceBusNamespace> actual = mockCommandRuntime.OutputPipeline[0] as List<ExtendedServiceBusNamespace>;
            Assert.Equal<int>(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal<string>(expected[i].Name, actual[i].Name);
            }
        }

        [Fact]
        public void GetAzureSBNamespaceWithInvalidNamesFail()
        {
            // Setup
            string[] invalidNames = { "1test", "test#", "test invaid", "-test", "_test" };
            Mock<ServiceBusClientExtensions> client = new Mock<ServiceBusClientExtensions>();

            foreach (string invalidName in invalidNames)
            {
                MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
                GetAzureSBNamespaceCommand cmdlet = new GetAzureSBNamespaceCommand()
                {
                    Name = invalidName,
                    CommandRuntime = mockCommandRuntime,
                    Client = client.Object
                };
                string expected = string.Format("{0}\r\nParameter name: Name", string.Format(Resources.InvalidNamespaceName, invalidName));
                client.Setup(f => f.GetNamespace(invalidName)).Throws(new InvalidOperationException(expected));

                Testing.AssertThrows<InvalidOperationException>(() => cmdlet.ExecuteCmdlet(), expected);
            }
        }
    }
}