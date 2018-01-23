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
    public class SetAzureStorageServiceLoggingTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public SetAzureStorageServiceLoggingCommand command = null;

        public SetAzureStorageServiceLoggingTest()
        {
            command = new SetAzureStorageServiceLoggingCommand
            {
                CommandRuntime = new MockCommandRuntime()
            };
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLoggingOperationsTest()
        { 
            Assert.Equal(LoggingOperations.None, command.GetLoggingOperations("none"));
            Assert.Equal(LoggingOperations.All, command.GetLoggingOperations("all"));
            Assert.Equal(LoggingOperations.Read, command.GetLoggingOperations("Read"));
            Assert.Equal(LoggingOperations.Write, command.GetLoggingOperations("WrIte"));
            Assert.Equal(LoggingOperations.Delete, command.GetLoggingOperations("DELETE"));
            Assert.Equal(LoggingOperations.Read | LoggingOperations.Delete,
                command.GetLoggingOperations("Read, DELETE"));
            AssertThrows<ArgumentException>(() => command.GetLoggingOperations("DELETE,xxx"));
            AssertThrows<ArgumentException>(() => command.GetLoggingOperations("DELETE,all"));
            AssertThrows<ArgumentException>(() => command.GetLoggingOperations("DELETE,none"));
            AssertThrows<ArgumentException>(() => command.GetLoggingOperations("all,none"));
            AssertThrows<ArgumentException>(() => command.GetLoggingOperations("allnone"));
            AssertThrows<ArgumentException>(() => command.GetLoggingOperations("stdio"));
        }
    }
}
