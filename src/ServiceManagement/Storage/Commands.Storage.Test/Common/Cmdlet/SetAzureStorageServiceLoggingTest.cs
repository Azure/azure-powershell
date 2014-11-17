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
    public class SetAzureStorageServiceLoggingTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public SetAzureStorageServiceLoggingCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new SetAzureStorageServiceLoggingCommand
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
        public void GetLoggingOperationsTest()
        { 
            Assert.AreEqual(LoggingOperations.None, command.GetLoggingOperations("none"));
            Assert.AreEqual(LoggingOperations.All, command.GetLoggingOperations("all"));
            Assert.AreEqual(LoggingOperations.Read, command.GetLoggingOperations("Read"));
            Assert.AreEqual(LoggingOperations.Write, command.GetLoggingOperations("WrIte"));
            Assert.AreEqual(LoggingOperations.Delete, command.GetLoggingOperations("DELETE"));
            Assert.AreEqual(LoggingOperations.Read | LoggingOperations.Delete,
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
