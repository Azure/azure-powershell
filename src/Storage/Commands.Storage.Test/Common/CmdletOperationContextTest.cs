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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// unit test for operation context
    /// </summary>
    [TestClass]
    public class CmdletOperationContextTest : StorageTestBase
    {
        [TestMethod]
        public void InitTest()
        {
            CmdletOperationContext.Init();
            Assert.IsNotNull(CmdletOperationContext.StartTime);
            Assert.IsNotNull(CmdletOperationContext.ClientRequestId);
        }

        [TestMethod]
        public void GetClientRequestIDTest()
        {
            string id = CmdletOperationContext.GenClientRequestID();
            Assert.IsNotNull(id);
        }

        [TestMethod]
        public void GetRunningMillisecondsTest()
        {
            CmdletOperationContext.Init();
            double msTime = CmdletOperationContext.GetRunningMilliseconds();
            Assert.IsTrue(msTime >= 0);
        }

        [TestMethod]
        public void CmdletOperationContextInitTwiceTest()
        {
            CmdletOperationContext.Init();
            DateTime snapshotTime = CmdletOperationContext.StartTime;
            int sleepInterval = 1 * 1000;
            Thread.Sleep(sleepInterval);
            CmdletOperationContext.Init();
            DateTime snapshotTime2 = CmdletOperationContext.StartTime;
            Assert.AreEqual(snapshotTime, snapshotTime2, "The start time should be equal after many times init");
        }
    }
}
