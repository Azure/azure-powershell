using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Xunit;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.NetAppFiles.Account;
using Microsoft.Azure.Commands.NetAppFiles.Cache;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Volume;
using Microsoft.Azure.Commands.NetAppFiles.VolumeGroup;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;

namespace Microsoft.Azure.Commands.NetAppFiles.UnitTest
{
    public class AccountExtensionTest
    {
        public AccountExtensionTest()
        {
            AzureSessionInitializer.InitializeAzureSession();
        }

        [Fact]
        public void VolumeBackupStatusUsesCurrentApiAndPreservesOutput()
        {
            const string volumePath = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/capacityPools/test-pool/volumes/test-volume";
            int requests = 0;
            using var handler = new RequestHandler(request =>
            {
                requests++;
                Assert.Equal(HttpMethod.Get, request.Method);
                Assert.Equal("?api-version=2026-09-01", request.RequestUri.Query);
                if (requests == 1)
                {
                    Assert.Equal(volumePath, request.RequestUri.AbsolutePath);
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(@"{""location"":""westus2""}")
                    };
                }

                Assert.Equal(volumePath + "/latestBackupStatus/current", request.RequestUri.AbsolutePath);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{
                        ""healthy"":false,""relationshipStatus"":""Failed"",""mirrorState"":""Broken"",
                        ""unhealthyReason"":""Transfer failed"",""errorMessage"":""Backup unavailable"",
                        ""lastTransferSize"":123,""lastTransferType"":""Incremental"",""totalTransferBytes"":456
                    }")
                };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            var runtime = new MockCommandRuntime();
            var cmdlet = new GetAzureRmNetAppFilesVolumeBackupStatus
            {
                AzureNetAppFilesManagementClient = client, CommandRuntime = runtime,
                ResourceGroupName = "test-rg", AccountName = "test-account",
                PoolName = "test-pool", Name = "test-volume"
            };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(2, requests);
            var status = Assert.IsType<PSNetAppFilesVolumeBackupStatus>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal(false, status.Healthy);
            Assert.Equal("Failed", status.RelationshipStatus);
            Assert.Equal("Broken", status.MirrorState);
            Assert.Equal("Transfer failed", status.UnhealthyReason);
            Assert.Equal("Backup unavailable", status.ErrorMessage);
            Assert.Equal(123L, status.LastTransferSize);
            Assert.Equal("Incremental", status.LastTransferType);
            Assert.Equal(456L, status.TotalTransferBytes);
        }

        [Theory]
        [InlineData("New")]
        [InlineData("Set")]
        [InlineData("Update")]
        public void AccountCmdletsSendLdapConfigurationAndPreservePartialUpdates(string operation)
        {
            int writes = 0;
            using var handler = new RequestHandler(request =>
            {
                if (request.Method == HttpMethod.Get)
                {
                    Assert.Equal("New", operation);
                    return new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(@"{""error"":{""code"":""ResourceNotFound"",""message"":""Account does not exist.""}}")
                    };
                }

                writes++;
                Assert.Equal(operation == "Update" ? new HttpMethod("PATCH") : HttpMethod.Put, request.Method);
                Assert.Equal("?api-version=2026-09-01", request.RequestUri.Query);
                var body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                var ldap = body["properties"]["ldapConfiguration"];
                Assert.Equal("rotated-secret", (string)ldap["bindPasswordAkvConfig"]["secretName"]);
                if (operation == "Update")
                {
                    Assert.True(JToken.DeepEquals(
                        JObject.Parse(@"{""bindPasswordAkvConfig"":{""secretName"":""rotated-secret""}}"), ldap));
                    Assert.Null(body["location"]);
                    Assert.Null(body["properties"]["activeDirectories"]);
                    Assert.Null(body["properties"]["encryption"]);
                }
                else
                {
                    Assert.Equal("example.com", (string)ldap["domain"]);
                    Assert.Equal("192.0.2.10", (string)ldap["ldapServers"][0]);
                    Assert.Equal("Simple", (string)ldap["bindAuthenticationLevel"]);
                    Assert.Equal("cn=bind,dc=example,dc=com", (string)ldap["bindDN"]);
                    Assert.Equal("https://example.vault.azure.net/", (string)ldap["bindPasswordAkvConfig"]["azureKeyVaultUri"]);
                    Assert.Equal("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity",
                        (string)ldap["bindPasswordAkvConfig"]["userAssignedIdentity"]);
                }

                body["id"] = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account";
                body["name"] = "test-account";
                body["location"] = "westus2";
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(body.ToString()) };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            var configuration = new PSNetAppFilesLdapConfiguration
            {
                BindPasswordAkvConfig = new PSNetAppFilesBindPasswordAkvConfig { SecretName = "rotated-secret" }
            };
            if (operation != "Update")
            {
                configuration.Domain = "example.com";
                configuration.LdapServers = new[] { "192.0.2.10" };
                configuration.BindAuthenticationLevel = "Simple";
                configuration.BindDn = "cn=bind,dc=example,dc=com";
                configuration.BindPasswordAkvConfig.AzureKeyVaultUri = "https://example.vault.azure.net/";
                configuration.BindPasswordAkvConfig.UserAssignedIdentity = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            }

            AzureNetAppFilesCmdletBase cmdlet = operation switch
            {
                "New" => new NewAzureRmNetAppFilesAccount
                {
                    ResourceGroupName = "test-rg", Name = "test-account", Location = "westus2",
                    LdapConfiguration = configuration
                },
                "Set" => new SetAzureRmNetAppFilesAccount
                {
                    ResourceGroupName = "test-rg", Name = "test-account", Location = "westus2",
                    LdapConfiguration = configuration
                },
                "Update" => new UpdateAzureRmNetAppFilesAccount
                {
                    ResourceGroupName = "test-rg", Name = "test-account",
                    LdapConfiguration = configuration
                },
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };
            var runtime = new MockCommandRuntime();
            cmdlet.AzureNetAppFilesManagementClient = client;
            cmdlet.CommandRuntime = runtime;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, writes);
            var account = Assert.IsType<PSNetAppFilesAccount>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal("rotated-secret", account.LdapConfiguration.BindPasswordAkvConfig.SecretName);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void VolumeCmdletsSendNewSettingsAndReturnThem(bool update)
        {
            int requests = 0;
            using var handler = new RequestHandler(request =>
            {
                requests++;
                Assert.Equal(update ? new HttpMethod("PATCH") : HttpMethod.Put, request.Method);
                Assert.Equal("?api-version=2026-09-01", request.RequestUri.Query);
                var body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.Equal("Disabled", (string)body["properties"]["smbOplocks"]);
                if (update)
                {
                    Assert.Null(body["properties"]["ldapServerType"]);
                }
                else
                {
                    Assert.Equal("OpenLdap", (string)body["properties"]["ldapServerType"]);
                    Assert.True((bool)body["properties"]["ldapEnabled"]);
                }

                body["id"] = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/capacityPools/test-pool/volumes/test-volume";
                body["name"] = "test-volume";
                body["location"] = "westus2";
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(body.ToString()) };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            AzureNetAppFilesCmdletBase cmdlet = update
                ? new UpdateAzureRmNetAppFilesVolume
                {
                    ResourceGroupName = "test-rg", AccountName = "test-account", PoolName = "test-pool",
                    Name = "test-volume", SmbOplock = "Disabled"
                }
                : new NewAzureRmNetAppFilesVolume
                {
                    ResourceGroupName = "test-rg", AccountName = "test-account", PoolName = "test-pool",
                    Name = "test-volume", Location = "westus2", CreationToken = "test-volume",
                    SubnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/test-subnet",
                    UsageThreshold = 107374182400, LdapEnabled = true, LdapServerType = "OpenLdap", SmbOplock = "Disabled"
                };
            var runtime = new MockCommandRuntime();
            cmdlet.AzureNetAppFilesManagementClient = client;
            cmdlet.CommandRuntime = runtime;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, requests);
            var volume = Assert.IsType<PSNetAppFilesVolume>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal("Disabled", volume.SmbOplocks);
            if (!update)
            {
                Assert.Equal("OpenLdap", volume.LdapServerType);
            }
        }

        [Fact]
        public void NewCacheSendsOplockAndOpenLdapSettings()
        {
            int requests = 0;
            using var handler = new RequestHandler(request =>
            {
                requests++;
                Assert.Equal(HttpMethod.Put, request.Method);
                Assert.Equal("?api-version=2026-09-01", request.RequestUri.Query);
                var body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.Equal("OpenLdap", (string)body["properties"]["ldapServerType"]);
                Assert.Equal("Enabled", (string)body["properties"]["ldap"]);
                Assert.True(JToken.DeepEquals(JObject.Parse(@"{""smbOplocks"":""Disabled""}"),
                    body["properties"]["smbSettings"]));
                body["id"] = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/capacityPools/test-pool/caches/test-cache";
                body["name"] = "test-cache";
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(body.ToString()) };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            var runtime = new MockCommandRuntime();
            var cmdlet = new NewAzureRmNetAppFilesCache
            {
                AzureNetAppFilesManagementClient = client, CommandRuntime = runtime,
                ResourceGroupName = "test-rg", AccountName = "test-account", PoolName = "test-pool",
                Name = "test-cache", Location = "westus2", FilePath = "test-cache", Size = 107374182400,
                CacheSubnetResourceId = "cache-subnet", PeeringSubnetResourceId = "peering-subnet",
                EncryptionKeySource = "Microsoft.NetApp", OriginPeerClusterName = "origin",
                OriginPeerAddress = new[] { "192.0.2.10" }, OriginPeerVserverName = "origin-svm",
                OriginPeerVolumeName = "origin-volume", Ldap = "Enabled", LdapServerType = "OpenLdap",
                SmbOplock = "Disabled"
            };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, requests);
            var cache = Assert.IsType<PSNetAppFilesCache>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal("Disabled", cache.SmbSettings.SmbOplocks);
            Assert.Equal("OpenLdap", cache.LdapServerType);
        }

        [Theory]
        [InlineData("SAP-HANA")]
        [InlineData("ORACLE")]
        public void VolumeGroupSendsNewSettingsForEveryGeneratedVolume(string applicationType)
        {
            int writes = 0;
            using var handler = new RequestHandler(request =>
            {
                if (request.Method == HttpMethod.Get)
                {
                    return request.RequestUri.AbsolutePath.EndsWith("/capacityPools/test-pool", StringComparison.Ordinal)
                        ? new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(@"{
                                ""id"":""/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/capacityPools/test-pool"",
                                ""location"":""westus2"",""properties"":{""size"":4398046511104,""serviceLevel"":""Premium""}
                            }")
                        }
                        : new HttpResponseMessage(HttpStatusCode.NotFound)
                        {
                            Content = new StringContent(@"{""error"":{""code"":""ResourceNotFound"",""message"":""Group does not exist.""}}")
                        };
                }

                writes++;
                Assert.Equal(HttpMethod.Put, request.Method);
                Assert.Equal("?api-version=2026-09-01", request.RequestUri.Query);
                var body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                var volumes = Assert.IsType<JArray>(body["properties"]["volumes"]);
                Assert.True(volumes.Count > 1);
                Assert.All(volumes, volume =>
                {
                    Assert.Equal("OpenLdap", (string)volume["properties"]["ldapServerType"]);
                    Assert.Equal("Disabled", (string)volume["properties"]["smbOplocks"]);
                });
                body["id"] = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/volumeGroups/test-group";
                body["name"] = "test-group";
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(body.ToString()) };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            var runtime = new MockCommandRuntime();
            var cmdlet = new NewAzureRmNetAppFilesVolumeGroup
            {
                AzureNetAppFilesManagementClient = client, CommandRuntime = runtime,
                ResourceGroupName = "test-rg", AccountName = "test-account", PoolName = "test-pool",
                Name = "test-group", Location = "westus2", Vnet = "test-vnet", SubnetId = "test-subnet",
                ApplicationType = applicationType, ApplicationIdentifier = "SH1", NodeMemory = 100,
                OracleDatabaseSize = 1024, OracleDatabaseThroughput = 1024,
                LdapServerType = "OpenLdap", SmbOplock = "Disabled"
            };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, writes);
            var group = Assert.IsType<PSNetAppFilesVolumeGroupDetail>(Assert.Single(runtime.OutputPipeline));
            Assert.All(group.Volumes, volume =>
            {
                Assert.Equal("OpenLdap", volume.LdapServerType);
                Assert.Equal("Disabled", volume.SmbOplocks);
            });
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void RefreshLdapBindPasswordWaitsForCompletionAndHonorsPassThru(bool passThru)
        {
            int requests = 0;
            using var handler = new RequestHandler(request =>
            {
                requests++;
                if (requests == 1)
                {
                    Assert.Equal(HttpMethod.Post, request.Method);
                    Assert.EndsWith("/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/refreshLdapBindPassword",
                        request.RequestUri.AbsolutePath);
                    Assert.Equal("?api-version=2026-09-01", request.RequestUri.Query);
                    var response = new HttpResponseMessage(HttpStatusCode.Accepted);
                    response.Headers.Add("Azure-AsyncOperation", "https://management.azure.com/operations/test");
                    response.Headers.Add("Retry-After", "0");
                    return response;
                }

                Assert.Equal(HttpMethod.Get, request.Method);
                Assert.Equal("/operations/test", request.RequestUri.AbsolutePath);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""status"":""Succeeded""}")
                };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000",
                LongRunningOperationRetryTimeout = 0
            };
            var runtime = new MockCommandRuntime();
            var cmdlet = new UpdateAzureRmNetAppFilesAccountLdapBindPassword
            {
                AzureNetAppFilesManagementClient = client,
                CommandRuntime = runtime,
                ResourceGroupName = "test-rg",
                Name = "test-account",
                PassThru = passThru
            };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(2, requests);
            if (passThru)
            {
                Assert.Equal(true, Assert.Single(runtime.OutputPipeline));
            }
            else
            {
                Assert.Empty(runtime.OutputPipeline);
            }
        }

        [Fact]
        public void RefreshLdapBindPasswordDoesNotReportSuccessOnServiceError()
        {
            using var handler = new RequestHandler(request => new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(@"{""error"":{""code"":""BadRequest"",""message"":""Bind secret is unavailable.""}}")
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            var runtime = new MockCommandRuntime();
            var cmdlet = new UpdateAzureRmNetAppFilesAccountLdapBindPassword
            {
                AzureNetAppFilesManagementClient = client,
                CommandRuntime = runtime,
                ResourceGroupName = "test-rg",
                Name = "test-account",
                PassThru = true
            };

            var error = Assert.Throws<CloudException>(() => cmdlet.ExecuteCmdlet());

            Assert.Contains("Bind secret is unavailable.", error.Message);
            Assert.Empty(runtime.OutputPipeline);
        }

        [Fact]
        public void UpdateCacheSendsOplockWhenItIsTheOnlySmbSetting()
        {
            int requests = 0;
            using var handler = new RequestHandler(request =>
            {
                requests++;
                Assert.Equal(new HttpMethod("PATCH"), request.Method);
                var body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(JToken.DeepEquals(
                    JObject.Parse(@"{""smbOplocks"":""Disabled""}"),
                    body["properties"]["smbSettings"]));
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{
                        ""id"":""/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account/capacityPools/test-pool/caches/test-cache"",
                        ""name"":""test-cache"",""location"":""westus2"",
                        ""properties"":{""smbSettings"":{""smbOplocks"":""Disabled""}}
                    }")
                };
            });
            using var httpClient = new HttpClient(handler);
            using var client = new NetAppManagementClient(new TokenCredentials("unit-test"), httpClient, false)
            {
                SubscriptionId = "00000000-0000-0000-0000-000000000000"
            };
            var runtime = new MockCommandRuntime();
            var cmdlet = new UpdateAzureRmNetAppFilesCache
            {
                AzureNetAppFilesManagementClient = client,
                CommandRuntime = runtime,
                ResourceGroupName = "test-rg",
                AccountName = "test-account",
                PoolName = "test-pool",
                Name = "test-cache",
                SmbOplock = "Disabled"
            };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, requests);
            Assert.Equal("Disabled", Assert.IsType<PSNetAppFilesCache>(Assert.Single(runtime.OutputPipeline)).SmbSettings.SmbOplocks);
        }

        private sealed class RequestHandler : DelegatingHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> respond;

            public RequestHandler(Func<HttpRequestMessage, HttpResponseMessage> respond)
            {
                this.respond = respond;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(respond(request));
            }
        }

        [Fact]
        public void LdapConfigurationRoundTripPreservesAllProperties()
        {
            var configuration = new PSNetAppFilesLdapConfiguration
            {
                Domain = "example.com",
                LdapServers = new[] { "192.0.2.10", "192.0.2.11" },
                SecureLdapType = "LdapOverTLS",
                ServerCaCertificate = "certificate",
                CertificateCnHost = "ldap.example.com",
                DnsServers = new[] { "192.0.2.12" },
                LdapPort = 636,
                UserDn = "ou=users,dc=example,dc=com",
                GroupDn = "ou=groups,dc=example,dc=com",
                NetGroupDn = "ou=netgroups,dc=example,dc=com",
                BindAuthenticationLevel = "Simple",
                BindDn = "cn=bind,dc=example,dc=com",
                BindPasswordAkvConfig = new PSNetAppFilesBindPasswordAkvConfig
                {
                    AzureKeyVaultUri = "https://example.vault.azure.net/",
                    SecretName = "ldap-bind",
                    UserAssignedIdentity = "/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test"
                }
            };

            var sdkConfiguration = configuration.ConvertFromPs();
            var roundTrip = sdkConfiguration.ConvertToPs();
            Assert.True(JToken.DeepEquals(JObject.FromObject(configuration), JObject.FromObject(roundTrip)));
            Assert.True(JToken.DeepEquals(JObject.FromObject(sdkConfiguration), JObject.FromObject(configuration.ConvertToPatchFromPs())));

            var account = new NetAppAccount(location: "westus2",
                id: "/subscriptions/test/resourceGroups/test/providers/Microsoft.NetApp/netAppAccounts/test")
            {
                Identity = new ManagedServiceIdentity(),
                LdapConfiguration = sdkConfiguration
            };
            Assert.Equal(configuration.BindDn, account.ConvertToPs().LdapConfiguration.BindDn);
            Assert.Equal(configuration.BindDn, account.ToPsNetAppFilesAccount().LdapConfiguration.BindDn);
        }

        [Fact]
        public void LdapPatchAllowsUpdatingOnlyTheBindSecret()
        {
            var patch = new PSNetAppFilesLdapConfiguration
            {
                BindPasswordAkvConfig = new PSNetAppFilesBindPasswordAkvConfig { SecretName = "rotated-secret" }
            }.ConvertToPatchFromPs();

            patch.Validate();
            var json = JObject.FromObject(patch, JsonSerializer.Create(new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
            Assert.True(JToken.DeepEquals(JObject.Parse(@"{""bindPasswordAkvConfig"":{""secretName"":""rotated-secret""}}"), json));
        }

        [Fact]
        public void AccountPatchConvertsWritableEncryptionAndActiveDirectoryFields()
        {
            var encryption = new PSNetAppFilesAccountEncryption
            {
                KeySource = "Microsoft.KeyVault",
                Identity = new PSEncryptionIdentity
                {
                    PrincipalId = "read-only-principal",
                    UserAssignedIdentity = "identity",
                    FederatedClientId = "client"
                },
                KeyVaultProperties = new PSNetAppFilesKeyVaultProperties
                {
                    KeyVaultUri = "https://example.vault.azure.net/",
                    KeyVaultResourceId = "vault-resource",
                    KeyName = "key",
                    KeyVaultId = "read-only-id",
                    Status = "read-only-status"
                }
            }.ConvertToPatchFromPs();

            var json = JObject.FromObject(encryption);
            Assert.Null(json["identity"]["principalId"]);
            Assert.Null(json["keyVaultProperties"]["keyVaultId"]);
            Assert.Null(json["keyVaultProperties"]["status"]);
            Assert.Equal("identity", encryption.Identity.UserAssignedIdentity);
            Assert.Equal("client", encryption.Identity.FederatedClientId);
            Assert.Equal("key", encryption.KeyVaultProperties.KeyName);
            Assert.Equal("vault-resource", encryption.KeyVaultProperties.KeyVaultResourceId);
            Assert.Equal("https://example.vault.azure.net/", encryption.KeyVaultProperties.KeyVaultUri);

            var directories = new[] { new PSNetAppFilesActiveDirectory
            {
                ActiveDirectoryId = "directory-id",
                Domain = "example.com",
                AesEncryption = false,
                LdapSearchScope = new PSNetAppFilesLdapSearchScopeOpt { UserDN = "ou=users,dc=example,dc=com" },
                PreferredServersForLdapClient = new List<string> { "192.0.2.10", "192.0.2.11" }
            }}.ConvertFromPs().ConvertToPatch();
            Assert.Equal("directory-id", directories[0].ActiveDirectoryId);
            Assert.Equal("example.com", directories[0].Domain);
            Assert.False(directories[0].AesEncryption);
            Assert.Equal("192.0.2.10,192.0.2.11", directories[0].PreferredServersForLdapClient);
            Assert.Equal("ou=users,dc=example,dc=com", directories[0].LdapSearchScope.UserDn);
        }

        [Fact]
        public void AccountShouldNotError()
        {
            string jsonAccountBody = @"{
  ""id"": ""/subscriptions/xxxxx-xxxx-xxxx-xxxx-xxxxx/resourceGroups/someGroup/providers/Microsoft.NetApp/netAppAccounts/someAccount"",
  ""name"": ""KTBNetAppProduction"",
  ""type"": ""Microsoft.NetApp/netAppAccounts"",
  ""etag"": ""W/\""datetime'2023-05-30T18%3A08%3A22.2706822Z'\"""",
  ""location"": ""eastus2"",
  ""tags"": {
    ""App"": ""Azure NetApp Files"",
    ""Env"": ""PRD"",
    ""FunctionalArea"": ""Datacenter"",
    ""Region"": ""AMER"",
    ""SubWorkstream"": ""OPS"",
    ""Workstream"": ""INF""
  },
  ""properties"": {
    ""provisioningState"": ""Succeeded"",
    ""activeDirectories"": [
      {
        ""backupOperators"": [
          ""svc-ANF""
        ],
        ""activeDirectoryId"": ""*********-****-****-****-************"",
        ""username"": ""svc-ANF"",
        ""password"": ""****************"",
        ""domain"": ""fk.fakebrand.com"",
        ""dns"": ""10.16.0.11,10.16.0.12"",
        ""status"": ""InUse"",
        ""smbServerName"": ""smbServer"",
        ""organizationalUnit"": ""OU=AzureNetAppFiles,OU=Servers,OU=fk""
      }
    ],
    ""encryption"": {
      ""keySource"": ""Microsoft.NetApp""
    }
  }
}";


            Newtonsoft.Json.JsonSerializerSettings DeserializationSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new Microsoft.Rest.Serialization.ReadOnlyJsonContractResolver(),
                Converters = new System.Collections.Generic.List<Newtonsoft.Json.JsonConverter>
                    {
                        new Microsoft.Rest.Serialization.Iso8601TimeSpanConverter()
                    }
            };

            DeserializationSettings.Converters.Add(new Microsoft.Rest.Serialization.TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new Microsoft.Rest.Azure.CloudErrorJsonConverter());

            NetAppAccount netAppAccount = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<NetAppAccount>(jsonAccountBody, DeserializationSettings);
            PSNetAppFilesAccount pSNetAppFilesAccount = netAppAccount.ConvertToPs();                        
            Assert.NotNull(pSNetAppFilesAccount);
        }
    }
}
