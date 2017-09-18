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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ProtectedFileProviderTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleConcurrentReadsAllowed()
        {
            bool oldMockSupport = TestMockSupport.RunningMocked;
            TestMockSupport.RunningMocked = true;
            try
            {
                MemoryDataStore store = new MemoryDataStore();
                string protectedFile = "myFile.txt";
                using (var tempStream = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream)
                using (var stream1 = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream)
                using (var stream2 = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream)
                using (var stream3 = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream)
                using (var stream4 = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream)
                {
                    Assert.NotNull(tempStream);
                    Assert.NotNull(stream1);
                    Assert.NotNull(stream2);
                    Assert.NotNull(stream3);
                    Assert.NotNull(stream4);
                    Assert.Throws<UnauthorizedAccessException>(() => ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.ExclusiveWrite, store).Stream);
                    var stream5 = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream;
                    stream5.Close();
                }

                Assert.NotNull(ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.ExclusiveWrite, store).Stream);
            }
            finally
            {
                TestMockSupport.RunningMocked = oldMockSupport;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteAccessIsExclusive()
        {
            bool oldMockSupport = TestMockSupport.RunningMocked;
            TestMockSupport.RunningMocked = true;
            try
            {
                MemoryDataStore store = new MemoryDataStore();
                string protectedFile = "myFile.txt";
                using (var tempStream = ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.ExclusiveWrite, store).Stream)
                {
                    Assert.Throws<UnauthorizedAccessException>(() => ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.ExclusiveWrite, store).Stream);
                    Assert.Throws<UnauthorizedAccessException>(() => ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream);
                }

                Assert.NotNull(ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store).Stream);
            }
            finally
            {
                TestMockSupport.RunningMocked = oldMockSupport;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FileProviderThrowsOnInvalidInputs()
        {
            Assert.Throws(typeof(ArgumentNullException), () => ProtectedFileProvider.CreateFileProvider(string.Empty, FileProtection.SharedRead, null));
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => ProtectedFileProvider.CreateFileProvider(string.Empty, FileProtection.SharedRead, new MemoryDataStore()));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LockFailureThrowsGoodException()
        {
            string protectedFile = "myFile.txt";
            Mock<IDataStore> store = new Mock<IDataStore>();
            store.Setup(d => d.FileExists(It.IsAny<string>())).Returns(true);
            store.Setup(d => d.OpenForExclusiveWrite(It.IsAny<string>())).Throws(new IOException("File is in use"));
            store.Setup(d => d.OpenForSharedRead(It.IsAny<string>())).Throws(new IOException("File is in use"));
            bool oldMockSupport = TestMockSupport.RunningMocked;
            TestMockSupport.RunningMocked = true;
            try
            {

                Assert.Contains(protectedFile, Assert.Throws<UnauthorizedAccessException>(() => ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.SharedRead, store.Object).Stream).Message);
                store.Verify(d => d.OpenForSharedRead(It.IsAny<string>()), Times.Exactly(ProtectedFileProvider.MaxTries + 1));
                Assert.Contains(protectedFile, Assert.Throws<UnauthorizedAccessException>(() => ProtectedFileProvider.CreateFileProvider(protectedFile, FileProtection.ExclusiveWrite, store.Object).Stream).Message);
                store.Verify(d => d.OpenForExclusiveWrite(It.IsAny<string>()), Times.Exactly(ProtectedFileProvider.MaxTries + 1));
            }
            finally
            {
                TestMockSupport.RunningMocked = oldMockSupport;
            }
        }
    }
}
