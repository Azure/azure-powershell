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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common.Cmdlet
{
    [TestClass]
    public class SetAzureStorageServiceHourMetricsTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public SetAzureStorageServiceMetricsCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new SetAzureStorageServiceMetricsCommand
            {
                CommandRuntime = new MockCommandRuntime()
            };
        }

        [TestCleanup]
        public void CleanCommand()
        {
            command = null;
        }

        [TestMethod]
        public void GetMetricsLevelTest()
        {
            Assert.AreEqual(MetricsLevel.None, command.GetMetricsLevel("none"));
            Assert.AreEqual(MetricsLevel.Service, command.GetMetricsLevel("Service"));
            Assert.AreEqual(MetricsLevel.ServiceAndApi, command.GetMetricsLevel("ServiceAndApi"));
            AssertThrows<ArgumentException>(() => command.GetMetricsLevel("stdio"));
        }
    }
}
