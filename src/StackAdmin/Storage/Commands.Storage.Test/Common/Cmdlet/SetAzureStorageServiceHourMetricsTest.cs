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
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common.Cmdlet
{
    public class SetAzureStorageServiceHourMetricsTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public SetAzureStorageServiceMetricsCommand command = null;

        public SetAzureStorageServiceHourMetricsTest()
        {
            command = new SetAzureStorageServiceMetricsCommand
            {
                CommandRuntime = new MockCommandRuntime()
            };
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMetricsLevelTest()
        {
            Assert.Equal(MetricsLevel.None, command.GetMetricsLevel("none"));
            Assert.Equal(MetricsLevel.Service, command.GetMetricsLevel("Service"));
            Assert.Equal(MetricsLevel.ServiceAndApi, command.GetMetricsLevel("ServiceAndApi"));
            AssertThrows<ArgumentException>(() => command.GetMetricsLevel("stdio"));
        }
    }
}
