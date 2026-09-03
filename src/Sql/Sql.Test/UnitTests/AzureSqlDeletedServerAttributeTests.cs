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

using Microsoft.Azure.Commands.Sql.Server.Cmdlet;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlDeletedServerAttributeTests
    {
        public AzureSqlDeletedServerAttributeTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlDeletedServerAttributes()
        {
            Type type = typeof(GetAzSqlDeletedServer);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "Location", isMandatory: false, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: false, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDeletedServerModelHandlesIncompleteResourceIds()
        {
            var deletedServer = new DeletedServer(
                id: "/subscriptions",
                name: "testserver");

            var model = new AzureSqlDeletedServerAdapter(null).CreateDeletedServerModelFromResponse(deletedServer);

            Assert.Null(model.SubscriptionId);
            Assert.Null(model.Location);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDeletedServerModelNormalizesLocation()
        {
            var deletedServer = new DeletedServer(
                id: "/subscriptions/subscriptionId/providers/Microsoft.Sql/locations/Central US/deletedServers/testserver",
                name: "testserver");

            var model = new AzureSqlDeletedServerAdapter(null).CreateDeletedServerModelFromResponse(deletedServer);

            Assert.Equal("subscriptionId", model.SubscriptionId);
            Assert.Equal("centralus", model.Location);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDeletedServerModelGetsResourceGroupFromOriginalIdWhenPropertyIsMissing()
        {
            var deletedServer = new DeletedServer(
                name: "testserver",
                originalId: "/subscriptions/subscriptionId/resourceGroups/testResourceGroup/providers/Microsoft.Sql/servers/testserver");

            var model = new AzureSqlDeletedServerAdapter(null).CreateDeletedServerModelFromResponse(deletedServer);

            Assert.Equal("testResourceGroup", model.ResourceGroupName);
        }
    }
}