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

using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests
{
    public class NewAzureDenyAssignmentCommandTests : RMTestBase
    {
        private static readonly MethodInfo ValidateOptions = typeof(NewAzureDenyAssignmentCommand)
            .GetMethod("ValidateDenyAssignmentOptions", BindingFlags.NonPublic | BindingFlags.Static);

        [Theory]
        [InlineData("EveryoneParameterSet")]
        [InlineData("PerPrincipalParameterSet")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExcludedPrincipalsAreOptionalInBothParameterSets(string parameterSet)
        {
            var metadata = new CommandMetadata(typeof(NewAzureDenyAssignmentCommand));

            Assert.False(metadata.Parameters["ExcludePrincipalId"].ParameterSets[parameterSet].IsMandatory);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidParametersReachShouldProcess(bool perPrincipal, bool includeExclusions)
        {
            var runtime = new Mock<ICommandRuntime>(MockBehavior.Strict);
            var cmdlet = new NewAzureDenyAssignmentCommand
            {
                CommandRuntime = runtime.Object,
                DenyAssignmentName = "Optional exclusions",
                Scope = "/subscriptions/" + Guid.NewGuid() + "/resourceGroups/unit-test",
                Action = new[] { "Microsoft.Storage/storageAccounts/write" },
                ExcludePrincipalId = includeExclusions ? new[] { Guid.NewGuid().ToString() } : null,
                PrincipalId = perPrincipal ? Guid.NewGuid().ToString() : null,
                PrincipalType = perPrincipal ? "ServicePrincipal" : null
            };
            runtime.Setup(r => r.ShouldProcess(cmdlet.Scope, It.IsAny<string>())).Returns(false);

            cmdlet.ExecuteCmdlet();

            runtime.Verify(r => r.ShouldProcess(cmdlet.Scope, It.IsAny<string>()), Times.Once);
            runtime.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("")]
        [InlineData(",\"excludePrincipalIds\":null")]
        [InlineData(",\"excludePrincipalIds\":[]")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EveryoneInputFileOptionsAllowMissingNullOrEmptyExclusions(string exclusions)
        {
            var options = JsonConvert.DeserializeObject<CreateDenyAssignmentOptions>(
                "{\"denyAssignmentName\":\"Optional exclusions\"," +
                "\"actions\":[\"Microsoft.Storage/storageAccounts/write\"]" + exclusions + "}");

            ValidateOptions.Invoke(null, new object[] { options });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExclusionTypesWithoutPrincipalsAreRejected()
        {
            var options = new CreateDenyAssignmentOptions
            {
                Actions = new List<string> { "Microsoft.Storage/storageAccounts/write" },
                ExcludePrincipalTypes = new List<string> { "User" }
            };

            var exception = Assert.Throws<TargetInvocationException>(
                () => ValidateOptions.Invoke(null, new object[] { options }));

            Assert.Equal("ExcludePrincipalTypes must not be specified without ExcludePrincipalIds.",
                Assert.IsType<PSArgumentException>(exception.InnerException).Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MismatchedExclusionTypeCountsAreRejected()
        {
            var options = new CreateDenyAssignmentOptions
            {
                Actions = new List<string> { "Microsoft.Storage/storageAccounts/write" },
                ExcludePrincipalIds = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                ExcludePrincipalTypes = new List<string> { "User", "Group", "ServicePrincipal" }
            };

            var exception = Assert.Throws<TargetInvocationException>(
                () => ValidateOptions.Invoke(null, new object[] { options }));

            Assert.Contains("ExcludePrincipalTypes must specify either 1 value",
                Assert.IsType<PSArgumentException>(exception.InnerException).Message);
        }
    }
}
