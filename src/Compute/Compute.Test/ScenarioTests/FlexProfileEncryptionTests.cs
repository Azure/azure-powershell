// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class FlexProfileEncryptionTests
    {
        private const string ResourceGroup = "flex-rg";
        private const string VMName = "flex-vm";
        private const string PreferredSize = "Standard_D2s_v5";
        private const string DeployedSize = "Standard_D4s_v5";
        private const string IdentityId = "/subscriptions/test/resourceGroups/flex-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/flex-identity";
        private const string SecretUrl = "https://flex-vault.vault.azure.net/secrets/disk-key/version";

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableEncryptionPreservesProfilesOnEveryVmRebuild(bool reencrypt, bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);
            var command = CreateEncryptionCommand(harness);
            var osType = typeof(SetAzureDiskEncryptionExtensionCommand)
                .GetField("currentOSType", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(osType);
            osType.SetValue(command, OperatingSystemTypes.Windows);

            var result = InvokePrivate(command, "UpdateVmEncryptionSettings",
                new DiskEncryptionSettings { Enabled = reencrypt });

            Assert.IsType<AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>>(result);
            Assert.Equal(reencrypt ? 2 : 1, harness.Requests.Count);
            Assert.Equal(reencrypt ? new bool?[] { false, true } : new bool?[] { true },
                harness.EncryptionEnabled);
            foreach (var request in harness.Requests)
            {
                Assert.NotSame(harness.VM, request);
                harness.AssertProfiles(request);
            }
            Assert.Equal(SecretUrl, harness.VM.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey.SecretUrl);
            harness.AssertProfiles(harness.VM);
            harness.Operations.Verify(o => o.GetWithHttpMessagesAsync(ResourceGroup, VMName, null, null,
                It.IsAny<CancellationToken>()), Times.Exactly(reencrypt ? 3 : 1));
            harness.Operations.Verify(o => o.DeallocateWithHttpMessagesAsync(ResourceGroup, VMName,
                null, null, null, It.IsAny<CancellationToken>()), reencrypt ? Times.Once() : Times.Never());
            harness.Operations.Verify(o => o.StartWithHttpMessagesAsync(ResourceGroup, VMName,
                null, It.IsAny<CancellationToken>()), reencrypt ? Times.Once() : Times.Never());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableEncryptionPreservesProfilesOnVmRebuild(bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);
            var command = new DisableAzureDiskEncryptionCommand
            {
                ComputeClient = harness.Client,
                ResourceGroupName = ResourceGroup,
                VMName = VMName
            };

            InvokePrivate(command, "UpdateVmEncryptionSettings");

            var request = Assert.Single(harness.Requests);
            Assert.NotSame(harness.VM, request);
            harness.AssertProfiles(request);
            Assert.False(request.StorageProfile.OsDisk.EncryptionSettings.Enabled);
            Assert.Null(request.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey);
            harness.AssertProfiles(harness.VM);
        }

        [Theory]
        [InlineData("UpdateVmEncryptionSettingsForMigration", false)]
        [InlineData("UpdateVmEncryptionSettingsForMigration", true)]
        [InlineData("ClearVmEncryptionSettingsForMigration", false)]
        [InlineData("ClearVmEncryptionSettingsForMigration", true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MigrationPreservesProfilesOnDirectVmSend(string method, bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);

            InvokePrivate(CreateEncryptionCommand(harness), method);

            var request = Assert.Single(harness.Requests);
            Assert.Same(harness.VM, request);
            harness.AssertProfiles(request);
            if (method == "ClearVmEncryptionSettingsForMigration")
            {
                Assert.Null(request.StorageProfile.OsDisk.EncryptionSettings);
            }
            else
            {
                Assert.False(request.StorageProfile.OsDisk.EncryptionSettings.Enabled);
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EncryptionIdentityPreservesProfilesOnDirectVmSend(bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);
            harness.VM.Identity = new VirtualMachineIdentity
            {
                Type = ResourceIdentityType.UserAssigned,
                UserAssignedIdentities = new Dictionary<string, UserAssignedIdentitiesValue>
                {
                    { IdentityId, new UserAssignedIdentitiesValue() }
                }
            };
            var command = CreateEncryptionCommand(harness);
            command.EncryptionIdentity = IdentityId;
            command.CommandRuntime = new Mock<ICommandRuntime>().Object;

            Assert.True((bool)InvokePrivate(command, "UpdateVmEncryptionIdentity"));

            var request = Assert.Single(harness.Requests);
            Assert.Same(harness.VM, request);
            harness.AssertProfiles(request);
            Assert.Equal(IdentityId, request.SecurityProfile.EncryptionIdentity.UserAssignedIdentityResourceId);
            Assert.Same(harness.VM.Identity, request.Identity);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AemIdentityUpdatePreservesProfilesAndExistingIdentity(bool userAssigned, bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm) { StopAfterRequest = true };
            harness.VM.Identity = new VirtualMachineIdentity
            {
                Type = userAssigned ? ResourceIdentityType.SystemAssigned : ResourceIdentityType.UserAssigned,
                UserAssignedIdentities = userAssigned ? null : new Dictionary<string, UserAssignedIdentitiesValue>
                {
                    { IdentityId, new UserAssignedIdentitiesValue() }
                }
            };
            var command = new SetAzureRmVMAEMExtension
            {
                ComputeClient = harness.Client,
                ResourceGroupName = ResourceGroup,
                VMName = VMName,
                PathUserIdentity = userAssigned ? IdentityId : null
            };

            // Stop at the VM send: subsequent authorization and extension deployment are unrelated to profile preservation.
            var error = Assert.Throws<TargetInvocationException>(() =>
                InvokePrivate(command, "SetNewExtension", harness.VM, new VirtualMachineInstanceView()));
            Assert.IsType<RequestCapturedException>(error.InnerException);

            var request = Assert.Single(harness.Requests);
            harness.AssertProfiles(request);
            Assert.NotNull(request.Identity);
            Assert.Equal(ResourceIdentityType.SystemAssignedUserAssigned, request.Identity.Type);
            Assert.True(request.Identity.UserAssignedIdentities.ContainsKey(IdentityId));
            harness.AssertProfiles(harness.VM);
        }

        private static SetAzureDiskEncryptionExtensionCommand CreateEncryptionCommand(VmUpdateHarness harness)
        {
            return new SetAzureDiskEncryptionExtensionCommand
            {
                ComputeClient = harness.Client,
                ResourceGroupName = ResourceGroup,
                VMName = VMName,
                Name = AzureDiskEncryptionExtensionContext.ExtensionDefaultName,
                DiskEncryptionKeyVaultId = "/subscriptions/test/resourceGroups/flex-rg/providers/Microsoft.KeyVault/vaults/flex-vault"
            };
        }

        private static object InvokePrivate(object command, string name, params object[] arguments)
        {
            var method = command.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            return method.Invoke(command, arguments);
        }

        private sealed class RequestCapturedException : Exception
        {
        }

        private sealed class VmUpdateHarness
        {
            private readonly bool flowVm;

            public VirtualMachine VM { get; }
            public ComputeClient Client { get; }
            public Mock<IVirtualMachinesOperations> Operations { get; }
            public List<VirtualMachine> Requests { get; } = new List<VirtualMachine>();
            public List<bool?> EncryptionEnabled { get; } = new List<bool?>();
            public bool StopAfterRequest { get; set; }

            public VmUpdateHarness(bool flowVm)
            {
                this.flowVm = flowVm;
                VM = new VirtualMachine
                {
                    Name = VMName,
                    Location = "eastus2",
                    HardwareProfile = new HardwareProfile(DeployedSize,
                        new VMSizeProperties(2, 1), "Deterministic"),
                    FlexProfile = flowVm ? new FlexProfile(PreferredSize) : null,
                    StorageProfile = new StorageProfile
                    {
                        OsDisk = new OSDisk
                        {
                            OsType = OperatingSystemTypes.Windows,
                            EncryptionSettings = new DiskEncryptionSettings { Enabled = true }
                        }
                    }
                };
                Operations = new Mock<IVirtualMachinesOperations>(MockBehavior.Strict);
                Operations.Setup(o => o.GetWithHttpMessagesAsync(ResourceGroup, VMName, null, null,
                    It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(new AzureOperationResponse<VirtualMachine> { Body = VM }));
                Operations.Setup(o => o.CreateOrUpdateWithHttpMessagesAsync(ResourceGroup, VMName,
                    It.IsAny<VirtualMachine>(), null, null, null, It.IsAny<CancellationToken>()))
                    .Returns((string group, string name, VirtualMachine request, string ifMatch,
                        string ifNoneMatch, Dictionary<string, List<string>> headers, CancellationToken token) =>
                    {
                        Requests.Add(request);
                        EncryptionEnabled.Add(request.StorageProfile.OsDisk.EncryptionSettings?.Enabled);
                        AssertProfiles(request);
                        if (StopAfterRequest)
                        {
                            throw new RequestCapturedException();
                        }
                        return Task.FromResult(new AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>
                        {
                            Body = request,
                            Response = new HttpResponseMessage(HttpStatusCode.OK),
                            Headers = new VirtualMachinesCreateOrUpdateHeaders()
                        });
                    });
                Operations.Setup(o => o.DeallocateWithHttpMessagesAsync(ResourceGroup, VMName, null, null,
                    null, It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new AzureOperationResponse()));
                Operations.Setup(o => o.StartWithHttpMessagesAsync(ResourceGroup, VMName, null,
                    It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new AzureOperationResponse()));
                var extensions = new Mock<IVirtualMachineExtensionsOperations>(MockBehavior.Strict);
                extensions.Setup(o => o.GetWithHttpMessagesAsync(ResourceGroup, VMName,
                    AzureDiskEncryptionExtensionContext.ExtensionDefaultName, "instanceView", null,
                    It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new AzureOperationResponse<VirtualMachineExtension>
                    {
                        Body = new VirtualMachineExtension
                        {
                            Publisher = AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                            VirtualMachineExtensionType = AzureDiskEncryptionExtensionContext.ExtensionDefaultType,
                            InstanceView = new VirtualMachineExtensionInstanceView
                            {
                                Statuses = new List<InstanceViewStatus>
                                {
                                    new InstanceViewStatus { Code = "ProvisioningState/succeeded", Message = SecretUrl }
                                }
                            }
                        }
                    }));
                var client = new Mock<IComputeManagementClient>(MockBehavior.Strict);
                client.SetupGet(c => c.VirtualMachines).Returns(Operations.Object);
                client.SetupGet(c => c.VirtualMachineExtensions).Returns(extensions.Object);
                Client = new ComputeClient(client.Object);
            }

            public void AssertProfiles(VirtualMachine request)
            {
                Assert.Equal(flowVm ? PreferredSize : null, request.FlexProfile?.PreferredVMSize);
                if (!flowVm)
                {
                    Assert.Null(request.FlexProfile);
                }
                Assert.NotNull(request.HardwareProfile);
                Assert.Equal(DeployedSize, request.HardwareProfile.VmSize);
                Assert.Equal(2, request.HardwareProfile.VmSizeProperties.VCPUsAvailable);
                Assert.Equal(1, request.HardwareProfile.VmSizeProperties.VCPUsPerCore);
                Assert.Equal("Deterministic", request.HardwareProfile.ProcessorMode);
            }
        }
    }
}
