﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.HDInsight;
using Microsoft.Azure.Commands.HDInsight.ManagementCommands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Test;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using Xunit;

namespace Commands.HDInsight.Test.UnitTests
{
    public class DataLakeStoreDefaultFilesystemTests : HDInsightTestBase
    {
        private NewAzureHDInsightClusterCommand cmdlet;
        private const string StorageAccountResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fakerg/providers/Microsoft.Storage/storageAccounts/dummystorage";
        private const int ClusterSize = 4;
        private Guid ObjectId = new Guid("11111111-1111-1111-1111-111111111111");
        private Guid ApplicationId = new Guid("11111111-1111-1111-1111-111111111111");
        private Guid AadTenantId = new Guid("11111111-1111-1111-1111-111111111111");
        private string Certificate = "";
        private string CertificatePassword = "";
        private byte[] CertificateFileContents = { };
        private readonly PSCredential _httpCred;
        private Mock<AzureHDInsightConfig> AzureHDInsightconfigMock;

        public DataLakeStoreDefaultFilesystemTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
            _httpCred = new PSCredential("hadoopuser", string.Format("Password1!").ConvertToSecureString());
            cmdlet = new NewAzureHDInsightClusterCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object
            };
            AzureHDInsightconfigMock = new Mock<AzureHDInsightConfig>();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateClusterConfigWithDataLakeStoreParameters()
        {
            var newclusteridentitycmdlet = new NewAzureHDInsightClusterConfigCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ObjectId = ObjectId,
                ApplicationId = ApplicationId,
                CertificateFilePath = Certificate,
                AadTenantId = AadTenantId,
                CertificatePassword = CertificatePassword,
                StorageAccountResourceId = StorageAccountResourceId
            };

            newclusteridentitycmdlet.ExecuteCmdlet();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightConfig>(
                            c =>
                                c.AADTenantId == AadTenantId &&
                                c.CertificatePassword == CertificatePassword &&
                                c.ObjectId == ObjectId &&
                                c.ApplicationId == ApplicationId &&
                                c.CertificateFilePath == Certificate &&
                                c.StorageAccountResourceId == StorageAccountResourceId
                                )),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateDataLakeClusterWithCertificateFileContents()
        {
            var clusterIdentityCmdlet = new NewAzureHDInsightClusterConfigCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ObjectId = ObjectId,
                ApplicationId = ApplicationId,
                CertificateFileContents = CertificateFileContents,
                AadTenantId = AadTenantId,
                CertificatePassword = CertificatePassword,
                StorageAccountResourceId = StorageAccountResourceId
            };

            clusterIdentityCmdlet.ExecuteCmdlet();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightConfig>(
                            c =>
                                c.AADTenantId == AadTenantId &&
                                c.CertificatePassword == CertificatePassword &&
                                c.ObjectId == ObjectId &&
                                c.ApplicationId == ApplicationId &&
                                c.CertificateFileContents == CertificateFileContents &&
                                c.StorageAccountResourceId == StorageAccountResourceId
                                )),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldThrowIfCertificateOptionsAreNotPassed()
        {
            var clusterIdentityCmdlet = new AddAzureHDInsightClusterIdentity()
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ObjectId = ObjectId,
                ApplicationId = ApplicationId,
                AadTenantId = AadTenantId,
                CertificatePassword = CertificatePassword
            };

            Assert.Throws<ArgumentException>(() => clusterIdentityCmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldThrowIfBothCertificateOptionsArePassed()
        {
            var clusterIdentityCmdlet = new AddAzureHDInsightClusterIdentity()
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ObjectId = ObjectId,
                ApplicationId = ApplicationId,
                AadTenantId = AadTenantId,
                CertificatePassword = CertificatePassword,
                CertificateFileContents = CertificateFileContents,
                CertificateFilePath = Certificate
            };

            Assert.Throws<ArgumentException>(() => clusterIdentityCmdlet.ExecuteCmdlet());
        }
    }
}

