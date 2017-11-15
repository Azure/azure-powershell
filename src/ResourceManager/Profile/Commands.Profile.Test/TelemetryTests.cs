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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Common.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TelemetryTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashOfNullOrWhitespaceValueReturnsEmptyString()
        {
            Assert.Equal(string.Empty, MetricHelper.GenerateSha256HashString(null));
            Assert.Equal(string.Empty, MetricHelper.GenerateSha256HashString(string.Empty));
            Assert.Equal(string.Empty, MetricHelper.GenerateSha256HashString(" "));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashofNullNetworkMACAddressIsNull()
        {
            Mock<INetworkHelper> helper = new Mock<INetworkHelper>();
            helper.Setup((f) => f.GetMACAddress()).Returns(() => null);
            var metricHelper = new MetricHelper(helper.Object);
            metricHelper.HashMacAddress = string.Empty;
            try
            {
                // verify that initialization happens only once and
                // there are no issues with retrieving the value
                Assert.Null(metricHelper.HashMacAddress);
                Assert.Null(metricHelper.HashMacAddress);
                helper.Verify((f) => f.GetMACAddress(), Times.Once);
            }
            finally
            {
                metricHelper.HashMacAddress = string.Empty;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashofEmptyNetworkMACAddressIsNull()
        {
            Mock<INetworkHelper> helper = new Mock<INetworkHelper>();
            helper.Setup((f) => f.GetMACAddress()).Returns(string.Empty);
            var metricHelper = new MetricHelper(helper.Object);
            metricHelper.HashMacAddress = string.Empty;
            try
            {
                Assert.Null(metricHelper.HashMacAddress);
                Assert.Null(metricHelper.HashMacAddress);
                helper.Verify((f) => f.GetMACAddress(), Times.Once);
            }
            finally
            {
                metricHelper.HashMacAddress = string.Empty;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashMacAddressOnThrowIsNull()
        {
            Mock<INetworkHelper> helper = new Mock<INetworkHelper>();
            helper.Setup((f) => f.GetMACAddress()).Throws(new InvalidOperationException("This exception should be handled"));
            var metricHelper = new MetricHelper(helper.Object);
            metricHelper.HashMacAddress = string.Empty;
            try
            {
                Assert.Null(metricHelper.HashMacAddress);
                Assert.Null(metricHelper.HashMacAddress);
                helper.Verify((f) => f.GetMACAddress(), Times.Once);
            }
            finally
            {
                metricHelper.HashMacAddress = string.Empty;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashOfValidValueSucceeds()
        {
            string inputValue = "Sample value to hash of suitable length and complexity.";
            var hash = MetricHelper.GenerateSha256HashString(inputValue);
            Assert.NotNull(hash);
            Assert.True(hash.Length > 0);
            Assert.NotEqual<string>(inputValue, hash, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataCollectionHandlesSerializationErrors()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            MemoryDataStore dataStore;
            string oldFileValue = null;
            var dataCollectionPath = Path.Combine(AzureSession.Instance.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
            var oldDataStore = AzureSession.Instance.DataStore;
            var memoryStore = oldDataStore as MemoryDataStore;
            if (memoryStore != null)
            {
                dataStore = memoryStore;
                if (dataStore.VirtualStore.ContainsKey(dataCollectionPath))
                {
                    oldFileValue = dataStore.VirtualStore[dataCollectionPath];
                }
            }
            else
            {
                dataStore = new MemoryDataStore();
            }

            dataStore.VirtualStore.Add(dataCollectionPath, "{{{{{{{{{{}}}--badly-formatted-file");
            AzureSession.Instance.DataStore = dataStore;
            try
            {
                var controller = DataCollectionController.Create(AzureSession.Instance);
                var profile = controller.GetProfile(() => { });
                DataCollectionController.WritePSDataCollectionProfile(AzureSession.Instance, profile);
            }
            finally
            {
                dataStore.VirtualStore[dataCollectionPath] = oldFileValue;
                AzureSession.Instance.DataStore = oldDataStore;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataCollectionHandlesIOErrors()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            Mock<IDataStore> mock = new Mock<IDataStore>();
            mock.Setup(f => f.DirectoryExists(It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.FileExists(It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.DeleteFile(It.IsAny<string>())).Throws(new IOException("This should not be raised"));
            var oldDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = mock.Object;
            try
            {
                var controller = DataCollectionController.Create(AzureSession.Instance);
                var profile = controller.GetProfile(() => { });
                DataCollectionController.WritePSDataCollectionProfile(AzureSession.Instance, profile);
            }
            finally
            {
                AzureSession.Instance.DataStore = oldDataStore;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataCollectionHandlesFileExistenceErrors()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            Mock<IDataStore> mock = new Mock<IDataStore>();
            mock.Setup(f => f.DirectoryExists(It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.FileExists(It.IsAny<string>())).Throws(new IOException("This should not be raised"));
            mock.Setup(f => f.DeleteFile(It.IsAny<string>()));
            var oldDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = mock.Object;
            try
            {
                var controller = DataCollectionController.Create(AzureSession.Instance);
                var profile = controller.GetProfile(() => { });
                DataCollectionController.WritePSDataCollectionProfile(AzureSession.Instance, profile);
            }
            finally
            {
                AzureSession.Instance.DataStore = oldDataStore;
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataCollectionHandlesDirectoryExistenceErrors()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            Mock<IDataStore> mock = new Mock<IDataStore>();
            mock.Setup(f => f.DirectoryExists(It.IsAny<string>())).Throws(new IOException("This should not be raised"));
            mock.Setup(f => f.FileExists(It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.DeleteFile(It.IsAny<string>()));
            var oldDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = mock.Object;
            try
            {
                var controller = DataCollectionController.Create(AzureSession.Instance);
                var profile = controller.GetProfile(() => { });
                DataCollectionController.WritePSDataCollectionProfile(AzureSession.Instance, profile);
            }
            finally
            {
                AzureSession.Instance.DataStore = oldDataStore;
            }

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataCollectionHandlesWriteErrors()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            Mock<IDataStore> mock = new Mock<IDataStore>();
            mock.Setup(f => f.DirectoryExists(It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.FileExists(It.IsAny<string>())).Returns(false);
            mock.Setup(f => f.DeleteFile(It.IsAny<string>()));
            mock.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>())).Throws(new ArgumentException("This exception should be caught"));
            mock.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>())).Throws(new ArgumentException("This exception should be caught"));
            mock.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Encoding>())).Throws(new ArgumentException("This exception should be caught"));
            var oldDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = mock.Object;
            try
            {
                DataCollectionController.WritePSDataCollectionProfile(AzureSession.Instance, new AzurePSDataCollectionProfile(true));
            }
            finally
            {
                AzureSession.Instance.DataStore = oldDataStore;
            }
        }

    }
}
