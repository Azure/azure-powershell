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

using System.Linq;
using System.Management.Automation;
using Castle.Core.Logging;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataSync.Cmdlet;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlElasticJobAgentUnitTests
    {
        public readonly string ValidTestIdentityType = "UserAssigned";
        public readonly string[] ValidUmiIds = new string[] { "/subscriptions/2e7fe4bd-90c7-454e-8bb6-dc44649f27b2/resourcegroups/pstest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstestumi" };

        public AzureSqlElasticJobAgentUnitTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CorrectlyParseJobAgentIdentityFromInputs()
        {
            // Both null return null
            Assert.Null(JobAgentIdentityHelper.GetJobAgentIdentity(null, null));

            // Throw if Identity type is not UserAssigned or None 
            var ex = Assert.Throws<PSArgumentException>(() => JobAgentIdentityHelper.GetJobAgentIdentity("SystemAssigned", null));
            Assert.Contains("Invalid IdentityType. Supported types are:", ex.Message);

            // Throw if Identity type is None but userAssignedIdentities is not null. None means delete all identities therefore userAssignedIdentities should be null from user input.
            ex = Assert.Throws<PSArgumentException>(() => JobAgentIdentityHelper.GetJobAgentIdentity("None", ValidUmiIds));
            Assert.Contains("Invalid IdentityType: UserAssignedIdentityId is only supported for", ex.Message);

            // Validate returns None type with empty Ids when IdentityType is None
            var identity = JobAgentIdentityHelper.GetJobAgentIdentity("None", null);
            Assert.NotNull(identity);
            Assert.Equal("None", identity.Type);
            Assert.Null(identity.UserAssignedIdentities);

            // Throws if identity is UserAssigned but no Ids were passed in
            var ex2 = Assert.Throws<PSArgumentNullException>(() => JobAgentIdentityHelper.GetJobAgentIdentity(ValidTestIdentityType, null));
            Assert.Contains("The list of user assigned identity ids needs to be passed if the IdentityType is UserAssigned.", ex2.Message);

            // Validate returns UserAssigned type and Umi 
            identity = JobAgentIdentityHelper.GetJobAgentIdentity(ValidTestIdentityType, ValidUmiIds);
            Assert.NotNull(identity);
            Assert.Equal(ValidTestIdentityType, identity.Type);
            Assert.True(identity.UserAssignedIdentities.ContainsKey(ValidUmiIds.First()));
        }
    }
}
