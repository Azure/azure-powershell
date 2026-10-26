using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.NetAppFiles.Account;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.NetAppFiles.UnitTest
{
    public class LdapConfigurationTests
    {
        [Fact]
        public void LdapConfigurationRoundTripPreservesEveryProperty()
        {
            var configuration = CreateConfiguration();
            var roundTrip = configuration.ConvertFromPs().ConvertToPs();

            Assert.True(JToken.DeepEquals(JObject.FromObject(configuration), JObject.FromObject(roundTrip)));
            Assert.Equal(13, typeof(LdapConfiguration).GetProperties().Length);
            Assert.Equal(3, typeof(BindPasswordAkvConfig).GetProperties().Length);
        }

        [Fact]
        public void LdapPatchPreservesEveryWritableProperty()
        {
            var configuration = CreateConfiguration();
            AssertMatchingProperties(configuration.ConvertFromPs(), configuration.ConvertToPatch());

            using (var client = new NetAppManagementClient(new TokenCredentials("test-token")))
            {
                var body = new NetAppAccountPatch { LdapConfiguration = configuration.ConvertToPatch() };
                var json = JObject.Parse(SafeJsonConvert.SerializeObject(body, client.SerializationSettings));
                Assert.Equal("example.com", (string)json["properties"]["ldapConfiguration"]["domain"]);
                Assert.Equal("ldap-bind-password", (string)json["properties"]["ldapConfiguration"]["bindPasswordAkvConfig"]["secretName"]);
                Assert.Null(json["location"]);
                Assert.Null(json["properties"]["activeDirectories"]);
                Assert.Null(json["properties"]["encryption"]);
            }
        }

        [Fact]
        public void PartialLdapConfigurationDoesNotAddDefaultsOrKeyVaultSettings()
        {
            var configuration = new PSNetAppFilesLdapConfiguration { UserDN = "ou=users,dc=example,dc=com" };
            Assert.Null(configuration.ConvertFromPs().BindPasswordAkvConfig);
            Assert.Null(configuration.ConvertFromPs().LdapPort);
            Assert.Null(configuration.ConvertFromPs().ConvertToPs().SecureLdapType);
            var patch = configuration.ConvertToPatch();
            Assert.Null(patch.BindPasswordAkvConfig);
            Assert.Null(patch.LdapServers);
            Assert.Null(patch.LdapPort);
            Assert.Null(patch.BindAuthenticationLevel);
            Assert.Equal(configuration.UserDN, patch.UserDn);
        }

        [Fact]
        public void LdapHashtableSupportsServerArraysAndNestedKeyVaultConfiguration()
        {
            var value = new Hashtable
            {
                { "LdapServers", new object[] { "10.0.0.4", "10.0.0.5" } },
                { "DnsServers", new object[] { "10.0.0.6" } },
                { "BindPasswordAkvConfig", new Hashtable
                    {
                        { "AzureKeyVaultUri", "https://example.vault.azure.net/" },
                        { "SecretName", "ldap-bind-password" },
                        { "UserAssignedIdentity", "test-identity" }
                    }
                }
            };
            var configuration = (PSNetAppFilesLdapConfiguration)LanguagePrimitives.ConvertTo(value, typeof(PSNetAppFilesLdapConfiguration));
            Assert.Equal(new[] { "10.0.0.4", "10.0.0.5" }, configuration.LdapServers);
            Assert.Equal(new[] { "10.0.0.6" }, configuration.DnsServers);
            Assert.Equal("ldap-bind-password", configuration.BindPasswordAkvConfig.SecretName);
        }

        [Fact]
        public void BothAccountConversionsExposeLdapConfiguration()
        {
            var account = new NetAppAccount(
                location: "westus2",
                id: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account",
                name: "test-account")
            {
                Identity = new ManagedServiceIdentity(),
                LdapConfiguration = CreateConfiguration().ConvertFromPs()
            };
            Assert.Equal("example.com", account.ConvertToPs().LdapConfiguration.Domain);
            Assert.Equal("example.com", account.ToPsNetAppFilesAccount().LdapConfiguration.Domain);

            account.LdapConfiguration = null;
            Assert.Null(account.ConvertToPs().LdapConfiguration);
            Assert.Null(account.ToPsNetAppFilesAccount().LdapConfiguration);
        }

        [Fact]
        public void ActiveDirectoryPatchPreservesAllWritableProperties()
        {
            var activeDirectory = new Management.NetApp.Models.ActiveDirectory
            {
                ActiveDirectoryId = "directory-id",
                Username = "test-user",
                Password = "test-password",
                Domain = "example.com",
                Dns = "10.0.0.4",
                SmbServerName = "test-smb",
                OrganizationalUnit = "ou=servers",
                Site = "test-site",
                BackupOperators = new[] { "backup-user" },
                Administrators = new[] { "admin-user" },
                KdcIP = "10.0.0.5",
                AdName = "test-ad",
                ServerRootCaCertificate = "test-certificate",
                AesEncryption = false,
                LdapSigning = true,
                SecurityOperators = new[] { "security-user" },
                LdapOverTls = false,
                AllowLocalNfsUsersWithLdap = true,
                EncryptDcConnections = false,
                LdapSearchScope = new LdapSearchScopeOpt { UserDn = "ou=users" },
                PreferredServersForLdapClient = "10.0.0.6"
            };
            IList<Management.NetApp.Models.ActiveDirectory> directories =
                new List<Management.NetApp.Models.ActiveDirectory> { activeDirectory };
            var patch = Assert.Single(directories.ConvertToPatch());
            AssertMatchingProperties(activeDirectory, patch);
            Assert.Equal(21, typeof(ActiveDirectoryPatch).GetProperties().Length);
            Assert.Empty(new List<Management.NetApp.Models.ActiveDirectory>().ConvertToPatch());
        }

        [Fact]
        public void EncryptionPatchPreservesWritableSettings()
        {
            var encryption = new PSNetAppFilesAccountEncryption
            {
                KeySource = "Microsoft.KeyVault",
                Identity = new PSEncryptionIdentity
                {
                    UserAssignedIdentity = "test-identity",
                    FederatedClientId = "test-client",
                    PrincipalId = "read-only-principal"
                },
                KeyVaultProperties = new PSNetAppFilesKeyVaultProperties
                {
                    KeyName = "test-key",
                    KeyVaultResourceId = "test-vault-id",
                    KeyVaultUri = "https://example.vault.azure.net/",
                    KeyVaultId = "read-only-vault-id",
                    Status = "read-only-status"
                }
            };
            AssertMatchingProperties(encryption.ConvertFromPs(), encryption.ConvertToPatch());
            var partial = new PSNetAppFilesAccountEncryption { KeySource = "Microsoft.NetApp" }.ConvertToPatch();
            Assert.Null(partial.Identity);
            Assert.Null(partial.KeyVaultProperties);
        }

        [Theory]
        [InlineData(typeof(NewAzureRmNetAppFilesAccount))]
        [InlineData(typeof(SetAzureRmNetAppFilesAccount))]
        [InlineData(typeof(UpdateAzureRmNetAppFilesAccount))]
        public void LdapParameterIsOptionalAndAvailableInEveryParameterSet(Type cmdletType)
        {
            var property = cmdletType.GetProperty("LdapConfiguration");
            Assert.Equal(typeof(PSNetAppFilesLdapConfiguration), property.PropertyType);
            var parameter = Assert.Single(property.GetCustomAttributes(typeof(ParameterAttribute), true).Cast<ParameterAttribute>());
            Assert.False(parameter.Mandatory);
            Assert.Equal(ParameterAttribute.AllParameterSets, parameter.ParameterSetName);
        }

        [Fact]
        public async Task RefreshOperationUsesNewApiVersionAndAccountEndpoint()
        {
            using (var handler = new RefreshRequestHandler())
            using (var client = new NetAppManagementClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                await client.NetAppAccounts.BeginRefreshLdapBindPasswordAsync("test-rg", "test-account");
                Assert.Equal(1, handler.RequestCount);
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task AccountRequestsSerializeLdapConfigurationWithNewApiVersion(bool patch)
        {
            using (var handler = new AccountRequestHandler(patch))
            using (var client = new NetAppManagementClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                var configuration = new PSNetAppFilesLdapConfiguration
                {
                    Domain = "example.com",
                    LdapServers = new[] { "192.0.2.4" },
                    SecureLdapType = "None",
                    BindAuthenticationLevel = "Anonymous"
                };
                NetAppAccount account;
                if (patch)
                {
                    account = await client.Accounts.BeginUpdateAsync("test-rg", "test-account",
                        new NetAppAccountPatch { LdapConfiguration = configuration.ConvertToPatch() });
                }
                else
                {
                    account = await client.Accounts.BeginCreateOrUpdateAsync("test-rg", "test-account",
                        new NetAppAccount("westus2") { LdapConfiguration = configuration.ConvertFromPs() });
                }

                Assert.Equal("example.com", account.ConvertToPs().LdapConfiguration.Domain);
                Assert.Equal(new[] { "192.0.2.4" }, account.ConvertToPs().LdapConfiguration.LdapServers);
                Assert.Equal(1, handler.RequestCount);
            }
        }

        public static IEnumerable<object[]> InvalidLdapConfigurations()
        {
            var cases = new (PSNetAppFilesLdapConfiguration Configuration, string Property)[]
            {
                (new PSNetAppFilesLdapConfiguration { Domain = "" }, "Domain"),
                (new PSNetAppFilesLdapConfiguration { Domain = "invalid domain" }, "Domain"),
                (new PSNetAppFilesLdapConfiguration { Domain = new string('a', 256) }, "Domain"),
                (new PSNetAppFilesLdapConfiguration { LdapPort = -1 }, "LdapPort"),
                (new PSNetAppFilesLdapConfiguration { LdapPort = 0 }, "LdapPort"),
                (new PSNetAppFilesLdapConfiguration { LdapPort = 65536 }, "LdapPort"),
                (new PSNetAppFilesLdapConfiguration { ServerCACertificate = "" }, "ServerCaCertificate"),
                (new PSNetAppFilesLdapConfiguration { ServerCACertificate = new string('a', 10241) }, "ServerCaCertificate"),
                (new PSNetAppFilesLdapConfiguration { CertificateCNHost = new string('a', 256) }, "CertificateCnHost"),
                (new PSNetAppFilesLdapConfiguration { UserDN = new string('a', 1025) }, "UserDn"),
                (new PSNetAppFilesLdapConfiguration { GroupDN = new string('a', 1025) }, "GroupDn"),
                (new PSNetAppFilesLdapConfiguration { NetGroupDN = new string('a', 1025) }, "NetGroupDn"),
                (new PSNetAppFilesLdapConfiguration { BindDN = "" }, "BindDn"),
                (new PSNetAppFilesLdapConfiguration { BindDN = new string('a', 256) }, "BindDn")
            };
            foreach (var patch in new[] { false, true })
            {
                foreach (var testCase in cases)
                {
                    yield return new object[] { patch, testCase.Configuration, testCase.Property };
                }

                foreach (var secretName in new[] { "", "invalid_secret", new string('a', 128) })
                {
                    var configuration = CreateConfiguration();
                    configuration.BindPasswordAkvConfig.SecretName = secretName;
                    yield return new object[] { patch, configuration, "SecretName" };
                }
            }

            var missingVault = CreateConfiguration();
            missingVault.BindPasswordAkvConfig.AzureKeyVaultUri = null;
            yield return new object[] { false, missingVault, "AzureKeyVaultUri" };
            var missingSecret = CreateConfiguration();
            missingSecret.BindPasswordAkvConfig.SecretName = null;
            yield return new object[] { false, missingSecret, "SecretName" };
        }

        [Theory]
        [MemberData(nameof(InvalidLdapConfigurations))]
        public void InvalidLdapConfigurationFailsSdkModelValidation(
            bool patch, PSNetAppFilesLdapConfiguration configuration, string property)
        {
            var error = Assert.Throws<ValidationException>(() =>
            {
                if (patch)
                {
                    new NetAppAccountPatch { LdapConfiguration = configuration.ConvertToPatch() }.Validate();
                }
                else
                {
                    new NetAppAccount("westus2") { LdapConfiguration = configuration.ConvertFromPs() }.Validate();
                }
            });
            Assert.Contains(property, error.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(65536)]
        public async Task InvalidLdapPortIsRejectedBeforeSendingCreateRequest(int port)
        {
            using (var handler = new AccountRequestHandler(false))
            using (var client = new NetAppManagementClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                var configuration = CreateConfiguration();
                configuration.LdapPort = port;
                var error = await Assert.ThrowsAsync<ValidationException>(() =>
                    client.Accounts.BeginCreateOrUpdateAsync("test-rg", "test-account",
                        new NetAppAccount("westus2") { LdapConfiguration = configuration.ConvertFromPs() }));
                Assert.Contains("LdapPort", error.Message);
                Assert.Equal(0, handler.RequestCount);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(65535)]
        public void LdapPortBoundaryValuesRemainValid(int port)
        {
            var configuration = CreateConfiguration();
            configuration.LdapPort = port;
            configuration.ConvertFromPs().Validate();
            configuration.ConvertToPatch().Validate();
        }

        [Fact]
        public void PartialKeyVaultPatchDoesNotRequireUnchangedFields()
        {
            var configuration = new PSNetAppFilesLdapConfiguration
            {
                BindPasswordAkvConfig = new PSNetAppFilesBindPasswordAkvConfig { SecretName = "replacement-password" }
            };
            configuration.ConvertToPatch().Validate();
            Assert.Null(configuration.ConvertToPatch().BindPasswordAkvConfig.AzureKeyVaultUri);
        }

        [Theory]
        [InlineData("PUT", HttpStatusCode.BadRequest)]
        [InlineData("PUT", HttpStatusCode.Forbidden)]
        [InlineData("PUT", HttpStatusCode.NotFound)]
        [InlineData("PATCH", HttpStatusCode.BadRequest)]
        [InlineData("PATCH", HttpStatusCode.Forbidden)]
        [InlineData("PATCH", HttpStatusCode.NotFound)]
        [InlineData("POST", HttpStatusCode.BadRequest)]
        [InlineData("POST", HttpStatusCode.Forbidden)]
        [InlineData("POST", HttpStatusCode.NotFound)]
        public async Task LdapOperationsPreserveSimulatedServiceErrors(string method, HttpStatusCode status)
        {
            using (var handler = new LdapServiceErrorHandler(method, status))
            using (var client = new NetAppManagementClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                var configuration = CreateConfiguration();
                var error = await Assert.ThrowsAsync<ErrorResponseException>(async () =>
                {
                    if (method == "PUT")
                    {
                        await client.Accounts.BeginCreateOrUpdateAsync("test-rg", "test-account",
                            new NetAppAccount("westus2") { LdapConfiguration = configuration.ConvertFromPs() });
                    }
                    else if (method == "PATCH")
                    {
                        await client.Accounts.BeginUpdateAsync("test-rg", "test-account",
                            new NetAppAccountPatch { LdapConfiguration = configuration.ConvertToPatch() });
                    }
                    else
                    {
                        await client.NetAppAccounts.BeginRefreshLdapBindPasswordAsync("test-rg", "test-account");
                    }
                });
                Assert.Equal(status, error.Response.StatusCode);
                Assert.Equal(status.ToString(), error.Body.Error.Code);
                Assert.Equal("Simulated LDAP service failure.", error.Body.Error.Message);
                Assert.Equal(1, handler.RequestCount);
            }
        }

        private static PSNetAppFilesLdapConfiguration CreateConfiguration()
        {
            return new PSNetAppFilesLdapConfiguration
            {
                Domain = "example.com",
                LdapServers = new[] { "10.0.0.4", "10.0.0.5" },
                SecureLdapType = "LdapOverTLS",
                ServerCACertificate = "test-certificate",
                CertificateCNHost = "ldap.example.com",
                DnsServers = new[] { "10.0.0.6" },
                LdapPort = 636,
                UserDN = "ou=users,dc=example,dc=com",
                GroupDN = "ou=groups,dc=example,dc=com",
                NetGroupDN = "ou=netgroups,dc=example,dc=com",
                BindAuthenticationLevel = "Simple",
                BindDN = "cn=bind,dc=example,dc=com",
                BindPasswordAkvConfig = new PSNetAppFilesBindPasswordAkvConfig
                {
                    AzureKeyVaultUri = "https://example.vault.azure.net/",
                    SecretName = "ldap-bind-password",
                    UserAssignedIdentity = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/ldap-identity"
                }
            };
        }

        private static void AssertMatchingProperties(object source, object patch)
        {
            foreach (var property in patch.GetType().GetProperties())
            {
                var original = source.GetType().GetProperty(property.Name);
                Assert.NotNull(original);
                var expected = original.GetValue(source);
                var actual = property.GetValue(patch);
                if (expected != null && actual != null && property.PropertyType.Namespace == typeof(NetAppAccount).Namespace)
                {
                    AssertMatchingProperties(expected, actual);
                }
                else
                {
                    Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
                }
            }
        }

        private sealed class AccountRequestHandler : DelegatingHandler
        {
            private readonly bool patch;

            public AccountRequestHandler(bool patch)
            {
                this.patch = patch;
            }

            public int RequestCount { get; private set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestCount++;
                Assert.Equal(patch ? "PATCH" : "PUT", request.Method.Method);
                Assert.Equal("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account", request.RequestUri.AbsolutePath);
                Assert.Equal("?api-version=2026-08-01", request.RequestUri.Query);
                var body = JObject.Parse(await request.Content.ReadAsStringAsync());
                Assert.Equal("example.com", (string)body["properties"]["ldapConfiguration"]["domain"]);
                Assert.Equal("192.0.2.4", (string)body["properties"]["ldapConfiguration"]["ldapServers"][0]);
                Assert.Equal("Anonymous", (string)body["properties"]["ldapConfiguration"]["bindAuthenticationLevel"]);
                Assert.Equal("None", (string)body["properties"]["ldapConfiguration"]["secureLdapType"]);
                Assert.Null(body["properties"]["ldapConfiguration"]["bindPasswordAkvConfig"]);
                if (patch)
                {
                    Assert.Null(body["location"]);
                    Assert.Null(body["properties"]["encryption"]);
                    Assert.Null(body["properties"]["activeDirectories"]);
                }
                else
                {
                    Assert.Equal("westus2", (string)body["location"]);
                }

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(new JObject
                    {
                        ["id"] = request.RequestUri.AbsolutePath,
                        ["name"] = "test-account",
                        ["location"] = "westus2",
                        ["properties"] = new JObject
                        {
                            ["provisioningState"] = "Succeeded",
                            ["ldapConfiguration"] = body["properties"]["ldapConfiguration"].DeepClone()
                        }
                    }.ToString(), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }

        private sealed class LdapServiceErrorHandler : DelegatingHandler
        {
            private readonly string method;
            private readonly HttpStatusCode status;

            public LdapServiceErrorHandler(string method, HttpStatusCode status)
            {
                this.method = method;
                this.status = status;
            }

            public int RequestCount { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestCount++;
                Assert.Equal(method, request.Method.Method);
                var path = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account";
                Assert.Equal(method == "POST" ? path + "/refreshLdapBindPassword" : path, request.RequestUri.AbsolutePath);
                Assert.Equal("?api-version=2026-08-01", request.RequestUri.Query);
                return Task.FromResult(new HttpResponseMessage(status)
                {
                    RequestMessage = request,
                    Content = new StringContent(new JObject
                    {
                        ["error"] = new JObject
                        {
                            ["code"] = status.ToString(),
                            ["message"] = "Simulated LDAP service failure."
                        }
                    }.ToString(), System.Text.Encoding.UTF8, "application/json")
                });
            }
        }

        private sealed class RefreshRequestHandler : DelegatingHandler
        {
            public int RequestCount { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestCount++;
                Assert.Equal(HttpMethod.Post, request.Method);
                Assert.Equal("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/refreshLdapBindPassword", request.RequestUri.AbsolutePath);
                Assert.Equal("?api-version=2026-08-01", request.RequestUri.Query);
                Assert.Null(request.Content);
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = request
                });
            }
        }
    }
}
