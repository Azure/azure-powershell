// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License").

extern alias BackupSdk;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using BackupClient = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupClient;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class PolicyRetrievalTests
    {
        private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
        private const string VaultId = "/subscriptions/" + SubscriptionId +
            "/resourceGroups/test-rg/providers/Microsoft.RecoveryServices/vaults/test-vault";

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("MSSQLInstance", null, "AzureWorkload")]
        [InlineData("MSSQLInstance", "AzureWorkload", "AzureWorkload")]
        [InlineData("MSSQL", null, "AzureWorkload")]
        [InlineData("MSSQL", "AzureWorkload", "AzureWorkload")]
        [InlineData("AzureVM", null, "AzureIaasVM")]
        [InlineData("AzureVM", "AzureVM", "AzureIaasVM")]
        [InlineData("AzureFiles", null, "AzureStorage")]
        [InlineData("AzureFiles", "AzureStorage", "AzureStorage")]
        [InlineData("AzureSQLDatabase", null, "AzureSql")]
        public void PolicyLookupPreservesProviderFilters(string workload, string management, string provider)
        {
            AzureSessionInitializer.InitializeAzureSession();
            bool hadTelemetry = AzureSession.Instance.TryGetComponent(
                AuthenticationTelemetry.Name, out AuthenticationTelemetry telemetry);
            if (!hadTelemetry)
            {
                AzureSession.Instance.RegisterComponent(AuthenticationTelemetry.Name, () => new AuthenticationTelemetry());
            }
            var originalFactory = AzureSession.Instance.ClientFactory;
            var handler = new PolicyListHandler();
            using (var client = new BackupClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var profile = new AzureRmProfile
                    {
                        DefaultContext = new AzureContext(
                            new AzureSubscription { Id = SubscriptionId },
                            new AzureAccount { Id = "test-account", Type = AzureAccount.AccountType.User },
                            AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                            new AzureTenant { Id = "22222222-2222-2222-2222-222222222222" })
                    };
                    var state = InitialSessionState.CreateDefault2();
                    state.Commands.Add(new SessionStateCmdletEntry(
                        "Get-TestPolicy", typeof(GetAzureRmRecoveryServicesBackupProtectionPolicy), null));
                    using (var powershell = System.Management.Automation.PowerShell.Create(state))
                    {
                        powershell.AddCommand("Get-TestPolicy").AddParameter("WorkloadType", workload)
                            .AddParameter("VaultId", VaultId).AddParameter("DefaultProfile", profile);
                        if (management != null)
                        {
                            powershell.AddParameter("BackupManagementType", management);
                        }
                        var results = powershell.Invoke();

                        Assert.False(powershell.HadErrors, string.Join("; ", powershell.Streams.Error));
                        Assert.Empty(results);
                    }
                    Assert.NotNull(handler.RequestUri);
                    Assert.Equal(VaultId + "/backupPolicies", handler.RequestUri.AbsolutePath);
                    string query = Uri.UnescapeDataString(handler.RequestUri.Query);
                    Assert.Contains("api-version=2026-10-01", query);
                    Assert.Contains("backupManagementType eq '" + provider + "'", query);
                    if (workload == "MSSQLInstance")
                    {
                        Assert.Contains("workloadType eq 'SQLInstance'", query);
                    }
                    else
                    {
                        Assert.DoesNotContain("workloadType", query);
                    }
                    Assert.Equal(provider, ServiceClientHelpers.GetServiceClientProviderType(
                        (WorkloadType)Enum.Parse(typeof(WorkloadType), workload)));
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                    if (!hadTelemetry)
                    {
                        AzureSession.Instance.UnregisterComponent<AuthenticationTelemetry>(AuthenticationTelemetry.Name);
                    }
                }
            }
        }

        private class PolicyListHandler : DelegatingHandler
        {
            public Uri RequestUri { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal(HttpMethod.Get, request.Method);
                RequestUri = request.RequestUri;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent("{\"value\":[]}", Encoding.UTF8, "application/json")
                });
            }
        }
    }
}
