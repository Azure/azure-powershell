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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// unit test for operation context
    /// </summary>
    public class CmdletOperationContextTest : StorageTestBase
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitTest()
        {
            CmdletOperationContext.Init();
            Assert.NotNull(CmdletOperationContext.StartTime);
            Assert.NotNull(CmdletOperationContext.ClientRequestId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetClientRequestIDTest()
        {
            string id = CmdletOperationContext.GenClientRequestID();
            Assert.NotNull(id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetRunningMillisecondsTest()
        {
            CmdletOperationContext.Init();
            double msTime = CmdletOperationContext.GetRunningMilliseconds();
            Assert.True(msTime >= 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CmdletOperationContextInitTwiceTest()
        {
            CmdletOperationContext.Init();
            DateTime snapshotTime = CmdletOperationContext.StartTime;
            int sleepInterval = 1 * 1000;
            Thread.Sleep(sleepInterval);
            CmdletOperationContext.Init();
            DateTime snapshotTime2 = CmdletOperationContext.StartTime;
            Assert.Equal(snapshotTime, snapshotTime2);
        }
    }
}
