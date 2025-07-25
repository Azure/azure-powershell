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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using Microsoft.Azure.Commands.Common.Strategies;

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class NewBatchPoolCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private NewBatchPoolCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchPoolCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchPoolCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchPoolParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "testPool";
            cmdlet.VirtualMachineSize = "small";

            // Don't go to the service on an Add CloudPool call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                PoolAddParameter,
                PoolAddOptions,
                AzureOperationHeaderResponse<PoolAddHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchPoolParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testPool";
            cmdlet.ApplicationLicenses = new List<string>() { "foo", "bar" };
            cmdlet.CertificateReferences = new PSCertificateReference[]
            {
                new PSCertificateReference()
                {
                    StoreLocation = Azure.Batch.Common.CertStoreLocation.LocalMachine,
                    Thumbprint = "thumbprint",
                    ThumbprintAlgorithm = "sha1",
                    StoreName = "My",
                    Visibility = Azure.Batch.Common.CertificateVisibility.StartTask
                }
            };
            cmdlet.CloudServiceConfiguration = new PSCloudServiceConfiguration("4", "*");
            cmdlet.DisplayName = "display name";
            cmdlet.InterComputeNodeCommunicationEnabled = true;
            cmdlet.TaskSlotsPerNode = 4;
            cmdlet.Metadata = new Dictionary<string, string> { { "meta1", "value1" } };
            cmdlet.ResourceTag = new Dictionary<string, string> { { "resource1", "value1" } };
            cmdlet.ResizeTimeout = TimeSpan.FromMinutes(20);
            cmdlet.StartTask = new PSStartTask("cmd /c echo start task");
            cmdlet.TargetDedicatedComputeNodes = 3;
            cmdlet.TargetLowPriorityComputeNodes = 2;
            cmdlet.TargetNodeCommunicationMode = Microsoft.Azure.Batch.Common.NodeCommunicationMode.Simplified;
            cmdlet.TaskSchedulingPolicy = new PSTaskSchedulingPolicy(Azure.Batch.Common.ComputeNodeFillType.Spread);
            cmdlet.UpgradePolicy = new PSUpgradePolicy(Azure.Batch.Common.UpgradeMode.Automatic);
            cmdlet.VirtualMachineConfiguration = new PSVirtualMachineConfiguration(new PSImageReference("offer", "publisher", "sku"), "node agent");
            cmdlet.VirtualMachineConfiguration.Extensions = new List<PSVMExtension>
            {
                new PSVMExtension("sample-extension", "sample-publisher", "sample-type") { EnableAutomaticUpgrade = true },
            };
            cmdlet.VirtualMachineConfiguration.ContainerConfiguration = new PSContainerConfiguration() { Type = "CriCompatible" };
            cmdlet.VirtualMachineConfiguration.SecurityProfile = new PSSecurityProfile();
            cmdlet.VirtualMachineConfiguration.SecurityProfile.SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch;
            cmdlet.VirtualMachineConfiguration.SecurityProfile.EncryptionAtHost = true;
            cmdlet.VirtualMachineConfiguration.SecurityProfile.UefiSettings = new PSUefiSettings();
            cmdlet.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled = true;
            cmdlet.VirtualMachineConfiguration.SecurityProfile.UefiSettings.VTpmEnabled = true;
            cmdlet.VirtualMachineConfiguration.ServiceArtifactReference = new PSServiceArtifactReference("testid");
            cmdlet.VirtualMachineSize = "small";
            cmdlet.MountConfiguration = new[] {
                new PSMountConfiguration(new PSAzureBlobFileSystemConfiguration("foo", "bar", "baz", AzureStorageAuthenticationKey.FromAccountKey("abc"))),
                new PSMountConfiguration(new PSAzureBlobFileSystemConfiguration("foo2", "bar2", "baz2", new PSComputeNodeIdentityReference(new Azure.Batch.ComputeNodeIdentityReference { ResourceId = "fake-identity"})))
            };

            PoolAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                PoolAddParameter,
                PoolAddOptions,
                AzureOperationHeaderResponse<PoolAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.ApplicationLicenses[0], requestParameters.ApplicationLicenses[0]);
            Assert.Equal(cmdlet.ApplicationLicenses[1], requestParameters.ApplicationLicenses[1]);
            Assert.Equal(cmdlet.CertificateReferences.Length, requestParameters.CertificateReferences.Count);
            Assert.Equal(cmdlet.CertificateReferences[0].StoreName, requestParameters.CertificateReferences[0].StoreName);
            Assert.Equal(cmdlet.CertificateReferences[0].Thumbprint, requestParameters.CertificateReferences[0].Thumbprint);
            Assert.Equal(cmdlet.CertificateReferences[0].ThumbprintAlgorithm, requestParameters.CertificateReferences[0].ThumbprintAlgorithm);
            Assert.Equal(cmdlet.CloudServiceConfiguration.OSFamily, requestParameters.CloudServiceConfiguration.OsFamily);
            Assert.Equal(cmdlet.CloudServiceConfiguration.OSVersion, requestParameters.CloudServiceConfiguration.OsVersion);
            Assert.Equal(cmdlet.DisplayName, requestParameters.DisplayName);
            Assert.Equal(cmdlet.InterComputeNodeCommunicationEnabled, requestParameters.EnableInterNodeCommunication);
            Assert.Equal(cmdlet.TaskSlotsPerNode, requestParameters.TaskSlotsPerNode);
            Assert.Equal(cmdlet.Metadata.Count, requestParameters.Metadata.Count);
            Assert.Equal(cmdlet.Metadata["meta1"], requestParameters.Metadata[0].Value);
            Assert.Equal(cmdlet.ResourceTag.Count, requestParameters.ResourceTags.Count);
            Assert.Equal(cmdlet.ResourceTag["resource1"], requestParameters.ResourceTags["resource1"]);
            Assert.Equal(cmdlet.ResizeTimeout, requestParameters.ResizeTimeout);
            Assert.Equal(cmdlet.StartTask.CommandLine, requestParameters.StartTask.CommandLine);
            Assert.Equal(cmdlet.TargetDedicatedComputeNodes, requestParameters.TargetDedicatedNodes);
            Assert.Equal(cmdlet.TargetLowPriorityComputeNodes, requestParameters.TargetLowPriorityNodes);
            Assert.Equal(cmdlet.TaskSchedulingPolicy.ComputeNodeFillType.ToString(), requestParameters.TaskSchedulingPolicy.NodeFillType.ToString());
            Assert.Equal(cmdlet.UpgradePolicy.Mode.ToString(), requestParameters.UpgradePolicy.Mode.ToString());
            Assert.Equal(cmdlet.TargetNodeCommunicationMode.ToString(), NodeCommunicationMode.Simplified.ToString());
            Assert.Equal(cmdlet.VirtualMachineConfiguration.NodeAgentSkuId, requestParameters.VirtualMachineConfiguration.NodeAgentSKUId);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.ImageReference.Publisher, requestParameters.VirtualMachineConfiguration.ImageReference.Publisher);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.ImageReference.Offer, requestParameters.VirtualMachineConfiguration.ImageReference.Offer);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.ImageReference.Sku, requestParameters.VirtualMachineConfiguration.ImageReference.Sku);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.SecurityProfile.SecurityType.ToString(), requestParameters.VirtualMachineConfiguration.SecurityProfile.SecurityType.ToString());
            Assert.Equal(cmdlet.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled, requestParameters.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.Extensions[0].Name, requestParameters.VirtualMachineConfiguration.Extensions[0].Name);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.Extensions[0].Publisher, requestParameters.VirtualMachineConfiguration.Extensions[0].Publisher);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.Extensions[0].Type, requestParameters.VirtualMachineConfiguration.Extensions[0].Type);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.Extensions[0].EnableAutomaticUpgrade, requestParameters.VirtualMachineConfiguration.Extensions[0].EnableAutomaticUpgrade);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.ContainerConfiguration.Type, requestParameters.VirtualMachineConfiguration.ContainerConfiguration.Type);
            Assert.Equal(cmdlet.VirtualMachineConfiguration.ServiceArtifactReference.Id, requestParameters.VirtualMachineConfiguration.ServiceArtifactReference.Id);
            Assert.Equal(cmdlet.VirtualMachineSize, requestParameters.VmSize);
            Assert.Equal(cmdlet.MountConfiguration[0].AzureBlobFileSystemConfiguration.AccountName, requestParameters.MountConfiguration[0].AzureBlobFileSystemConfiguration.AccountName);
            Assert.Equal(cmdlet.MountConfiguration[0].AzureBlobFileSystemConfiguration.AccountKey, requestParameters.MountConfiguration[0].AzureBlobFileSystemConfiguration.AccountKey);
            Assert.Equal(cmdlet.MountConfiguration[0].AzureBlobFileSystemConfiguration.ContainerName, requestParameters.MountConfiguration[0].AzureBlobFileSystemConfiguration.ContainerName);
            Assert.Equal(cmdlet.MountConfiguration[0].AzureBlobFileSystemConfiguration.RelativeMountPath, requestParameters.MountConfiguration[0].AzureBlobFileSystemConfiguration.RelativeMountPath);
            Assert.Equal(cmdlet.MountConfiguration[1].AzureBlobFileSystemConfiguration.AccountName, requestParameters.MountConfiguration[1].AzureBlobFileSystemConfiguration.AccountName);
            Assert.Equal(cmdlet.MountConfiguration[1].AzureBlobFileSystemConfiguration.IdentityReference.ResourceId, requestParameters.MountConfiguration[1].AzureBlobFileSystemConfiguration.IdentityReference.ResourceId);
            Assert.Equal(cmdlet.MountConfiguration[1].AzureBlobFileSystemConfiguration.ContainerName, requestParameters.MountConfiguration[1].AzureBlobFileSystemConfiguration.ContainerName);
            Assert.Equal(cmdlet.MountConfiguration[1].AzureBlobFileSystemConfiguration.RelativeMountPath, requestParameters.MountConfiguration[1].AzureBlobFileSystemConfiguration.RelativeMountPath);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchPoolAutoScaleHandledProperlyTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testPool";
            cmdlet.AutoScaleEvaluationInterval = TimeSpan.FromMinutes(15);
            cmdlet.AutoScaleFormula = "$TargetDedicated=3";

            PoolAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                PoolAddParameter,
                PoolAddOptions,
                AzureOperationHeaderResponse<PoolAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.AutoScaleEvaluationInterval, requestParameters.AutoScaleEvaluationInterval);
            Assert.Equal(cmdlet.AutoScaleFormula, requestParameters.AutoScaleFormula);
            Assert.True(requestParameters.EnableAutoScale);
            Assert.Null(requestParameters.TargetDedicatedNodes);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchPoolNetworkConfigurationParameterTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            var networkConfiguration = new PSNetworkConfiguration();
            networkConfiguration.SubnetId = "fakeSubnetId";
            networkConfiguration.EnableAcceleratedNetworking = true;

            cmdlet.Id = "testPool";
            cmdlet.VirtualMachineSize = "small";
            cmdlet.NetworkConfiguration = networkConfiguration;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);

            string subnetId = null;
            bool? enableAcceleratedNetworking = null;

            Action<BatchRequest<
                PoolAddParameter,
                PoolAddOptions,
                AzureOperationHeaderResponse<PoolAddHeaders>>> extractPoolAction =
                (request) =>
                {
                    subnetId = request.Parameters.NetworkConfiguration.SubnetId;
                    enableAcceleratedNetworking = request.Parameters.NetworkConfiguration.EnableAcceleratedNetworking;
                };

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(requestAction: extractPoolAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.NetworkConfiguration.SubnetId, subnetId);
            Assert.Equal(cmdlet.NetworkConfiguration.EnableAcceleratedNetworking, enableAcceleratedNetworking);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchPoolUserAccountsGetPassedToRequest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testPool";
            cmdlet.CloudServiceConfiguration = new PSCloudServiceConfiguration("4", "*");
            cmdlet.TargetDedicatedComputeNodes = 3;

            PSUserAccount adminUser = new PSUserAccount("admin", "password1", Azure.Batch.Common.ElevationLevel.Admin);
            PSUserAccount nonAdminUser = new PSUserAccount("user2", "password2", Azure.Batch.Common.ElevationLevel.NonAdmin);
            PSUserAccount sshUser = new PSUserAccount("user3", "password3", linuxUserConfiguration: new PSLinuxUserConfiguration(uid: 1, gid: 2, sshPrivateKey: "my ssh key"));
            cmdlet.UserAccount = new[] { adminUser, nonAdminUser, sshUser };

            PoolAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                PoolAddParameter,
                PoolAddOptions,
                AzureOperationHeaderResponse<PoolAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(3, requestParameters.UserAccounts.Count);
            Assert.Equal(adminUser.Name, requestParameters.UserAccounts[0].Name);
            Assert.Equal(adminUser.Password, requestParameters.UserAccounts[0].Password);
            Assert.Equal(adminUser.ElevationLevel.ToString().ToLowerInvariant(),
                requestParameters.UserAccounts[0].ElevationLevel.ToString().ToLowerInvariant());
            Assert.Equal(nonAdminUser.Name, requestParameters.UserAccounts[1].Name);
            Assert.Equal(nonAdminUser.Password, requestParameters.UserAccounts[1].Password);
            Assert.Equal(nonAdminUser.ElevationLevel.ToString().ToLowerInvariant(),
                requestParameters.UserAccounts[1].ElevationLevel.ToString().ToLowerInvariant());
            Assert.Equal(sshUser.Name, requestParameters.UserAccounts[2].Name);
            Assert.Equal(sshUser.Password, requestParameters.UserAccounts[2].Password);
            Assert.Equal(sshUser.ElevationLevel.ToString().ToLowerInvariant(),
                requestParameters.UserAccounts[2].ElevationLevel.ToString().ToLowerInvariant());
            Assert.Equal(sshUser.LinuxUserConfiguration.Uid, requestParameters.UserAccounts[2].LinuxUserConfiguration.Uid);
            Assert.Equal(sshUser.LinuxUserConfiguration.Gid, requestParameters.UserAccounts[2].LinuxUserConfiguration.Gid);
            Assert.Equal(sshUser.LinuxUserConfiguration.SshPrivateKey, requestParameters.UserAccounts[2].LinuxUserConfiguration.SshPrivateKey);
        }
    }
}
