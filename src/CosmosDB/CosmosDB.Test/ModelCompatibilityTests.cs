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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.CosmosDB.Test
{
    public class ModelCompatibilityTests
    {
        [Fact]
        public void PermissionRetainsPositionalAndNamedConstructors()
        {
            var actions = new List<string> { "read" };

            Assert.Same(actions, new PSPermission(actions).DataActions);
            Assert.Same(actions, new PSPermission(dataActions: actions).DataActions);
            Assert.Null(new PSPermission(null).DataActions);
            Assert.Null(new PSPermission().DataActions);
            Assert.Equal(new[] { typeof(List<string>) },
                typeof(PSPermission).GetConstructors()
                    .Single(constructor => constructor.GetParameters().Length != 0)
                    .GetParameters().Select(parameter => parameter.ParameterType));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void RoleDefinitionPermissionsBindToPowerShellParameters(bool table)
        {
            var permissions = CreateRoleDefinitionOutput(table, new List<Permission> { CreatePermission() });

            using (var powerShell = System.Management.Automation.PowerShell.Create())
            {
                var results = powerShell.AddScript(@"
param($permissions)
function Test-PermissionBinding {
    param([System.Collections.Generic.List[Microsoft.Azure.Commands.CosmosDB.Models.PSPermission]] $Permission)
    $Permission
}
Test-PermissionBinding -Permission $permissions")
                    .AddArgument(permissions)
                    .Invoke();

                Assert.False(powerShell.HadErrors,
                    string.Join(System.Environment.NewLine, powerShell.Streams.Error));
                var permission = Assert.IsType<PSPermission>(Assert.Single(results).BaseObject);
                Assert.Equal(new[] { "read", "write" }, permission.DataActions);
                Assert.Equal("permission-id", permission.Id);
                Assert.Equal(new[] { "delete" }, permission.NotDataActions);
            }
        }

        [Fact]
        public void PermissionRoundTripPreservesAllFieldsAndRequestShape()
        {
            var sdkPermission = CreatePermission();
            var psPermission = PSPermission.FromSDKModel(sdkPermission);
            var roundTrip = PSPermission.ToSDKModel(psPermission);

            Assert.Equal(sdkPermission.Id, psPermission.Id);
            Assert.Equal(sdkPermission.DataActions, psPermission.DataActions);
            Assert.Equal(sdkPermission.NotDataActions, psPermission.NotDataActions);
            Assert.True(JToken.DeepEquals(
                JObject.FromObject(sdkPermission), JObject.FromObject(roundTrip)));
            Assert.NotSame(sdkPermission.DataActions, psPermission.DataActions);
            Assert.NotSame(sdkPermission.NotDataActions, psPermission.NotDataActions);
            Assert.NotSame(psPermission.DataActions, roundTrip.DataActions);
            Assert.NotSame(psPermission.NotDataActions, roundTrip.NotDataActions);
        }

        [Fact]
        public void PermissionRetainsNullFields()
        {
            Assert.Null(PSPermission.FromSDKModel(null));
            Assert.Null(PSPermission.ToSDKModel(null));

            var psPermission = PSPermission.FromSDKModel(new Permission());
            var roundTrip = PSPermission.ToSDKModel(psPermission);
            Assert.Null(psPermission.Id);
            Assert.Null(psPermission.DataActions);
            Assert.Null(psPermission.NotDataActions);
            Assert.Null(roundTrip.Id);
            Assert.Null(roundTrip.DataActions);
            Assert.Null(roundTrip.NotDataActions);
        }

        [Fact]
        public void PermissionRetainsEmptyCollections()
        {
            var permission = new PSPermission
            {
                DataActions = new List<string>(),
                NotDataActions = new List<string>()
            };
            var roundTrip = PSPermission.FromSDKModel(PSPermission.ToSDKModel(permission));

            Assert.Empty(roundTrip.DataActions);
            Assert.Empty(roundTrip.NotDataActions);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void RoleDefinitionOutputRoundTripsThroughPermissionInput(bool table)
        {
            var sdkPermission = CreatePermission();
            var permissions = new List<Permission> { sdkPermission };
            var output = CreateRoleDefinitionOutput(table, permissions);

            Assert.IsType<PSPermission>(Assert.Single(output));
            Assert.Equal(sdkPermission.Id, output[0].Id);
            Assert.Equal(sdkPermission.DataActions, output[0].DataActions);
            Assert.Equal(sdkPermission.NotDataActions, output[0].NotDataActions);
            Assert.True(JToken.DeepEquals(JArray.FromObject(permissions),
                JArray.FromObject(output.Select(PSPermission.ToSDKModel))));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void RoleDefinitionRetainsNullAndEmptyPermissions(bool table)
        {
            Assert.Null(CreateRoleDefinitionOutput(table, null));
            Assert.Empty(CreateRoleDefinitionOutput(table, new List<Permission>()));
            Assert.Null(Assert.Single(CreateRoleDefinitionOutput(table, new List<Permission> { null })));
        }

        [Theory]
        [InlineData(typeof(NewAzCosmosDBSqlRoleDefinition))]
        [InlineData(typeof(UpdateAzCosmosDBSqlRoleDefinition))]
        [InlineData(typeof(NewAzCosmosDBTableRoleDefinition))]
        [InlineData(typeof(UpdateAzCosmosDBTableRoleDefinition))]
        public void RoleDefinitionCmdletsAcceptTheOutputPermissionModel(System.Type cmdletType)
        {
            Assert.Equal(typeof(List<PSPermission>),
                cmdletType.GetProperty("Permission").PropertyType);
            Assert.All(cmdletType.GetProperty("Permission").GetCustomAttributes(typeof(ParameterAttribute), false)
                .Cast<ParameterAttribute>(), attribute =>
                {
                    Assert.Equal(int.MinValue, attribute.Position);
                    Assert.False(attribute.ValueFromPipeline);
                    Assert.False(attribute.ValueFromPipelineByPropertyName);
                    Assert.Equal(cmdletType.Name.StartsWith("New", System.StringComparison.Ordinal), attribute.Mandatory);
                });
            Assert.Equal(typeof(IList<PSPermission>),
                typeof(PSSqlRoleDefinitionGetResults).GetProperty("Permissions").PropertyType);
            Assert.Equal(typeof(IList<PSPermission>),
                typeof(PSTableRoleDefinitionGetResults).GetProperty("Permissions").PropertyType);
        }

        [Fact]
        public void PermissionPropertiesDoNotExposeGeneratedSdkTypes()
        {
            Assert.Equal(new[] { "DataActions", "Id", "NotDataActions" },
                typeof(PSPermission).GetProperties().Select(property => property.Name).OrderBy(name => name));
            Assert.All(typeof(PSPermission).GetProperties(), property =>
                Assert.True(property.PropertyType == typeof(string) ||
                            property.PropertyType == typeof(IList<string>)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Standard")]
        public void AccountOfferTypeRetainsItsPowerShellValue(string offerType)
        {
            var sdkAccount = new DatabaseAccountGetResults(
                databaseAccountOfferType: offerType == null
                    ? (DatabaseAccountGetPropertiesDatabaseAccountOfferType?)null
                    : DatabaseAccountGetPropertiesDatabaseAccountOfferType.Standard,
                backupPolicy: new PeriodicModeBackupPolicy
                {
                    PeriodicModeProperties = new PeriodicModeProperties()
                });

            var account = new PSDatabaseAccountGetResults(sdkAccount);

            Assert.Equal(typeof(string),
                typeof(PSDatabaseAccountGetResults).GetProperty("DatabaseAccountOfferType").PropertyType);
            Assert.Equal(offerType, account.DatabaseAccountOfferType);
        }

        private static Permission CreatePermission()
        {
            return new Permission
            {
                Id = "permission-id",
                DataActions = new List<string> { "read", "write" },
                NotDataActions = new List<string> { "delete" }
            };
        }

        private static IList<PSPermission> CreateRoleDefinitionOutput(bool table, IList<Permission> permissions)
        {
            if (table)
            {
                return new PSTableRoleDefinitionGetResults(new TableRoleDefinitionResource
                {
                    Permissions = permissions,
                    AssignableScopes = new List<string>()
                }).Permissions;
            }

            return new PSSqlRoleDefinitionGetResults(new SqlRoleDefinitionGetResults
            {
                Permissions = permissions,
                AssignableScopes = new List<string>()
            }).Permissions;
        }
    }
}
