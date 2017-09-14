// ----------------------------------------------------------------------------------
//
// Copyright 2012 Microsoft Corporation
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
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// Unit test for sas token helper
    /// </summary>
    [TestClass]
    public class SasTokenHelperTest : StorageTestBase
    {
        [TestMethod]
        public void ValidateExistingPolicyTest()
        {
            Dictionary<string, string> policies = new Dictionary<string,string>() 
                { { "test", "test" }, { "Abc", "abc" }, { "123", "123" } };
            SasTokenHelper.GetExistingPolicy<string>(policies, "ABC");
            SasTokenHelper.GetExistingPolicy<string>(policies, "test");
            SasTokenHelper.GetExistingPolicy<string>(policies, "tesT");
            SasTokenHelper.GetExistingPolicy<string>(policies, "123");
            AssertThrows<ArgumentException>(() => SasTokenHelper.GetExistingPolicy<string>(policies, "test1"));
        }

        [TestMethod]
        public void ValidateExistingPolicyWithEmptyPoliciesTest()
        {
            Dictionary<string, string> policies = new Dictionary<string, string>();
            AssertThrows<ArgumentException>(() => SasTokenHelper.GetExistingPolicy<string>(policies, "test1"));
        }

        [TestMethod]
        public void SetupAccessPolicyLifeTimeTest()
        {
            DateTime? start = DateTime.Now;
            DateTime? end = start.Value.AddHours(1.0);
            DateTimeOffset? testStart = null;
            DateTimeOffset? testEnd = null;
            SasTokenHelper.SetupAccessPolicyLifeTime(start, end, out testStart, out testEnd, true);
            Assert.AreEqual(testStart.Value.UtcDateTime.ToString(), start.Value.ToUniversalTime().ToString());
            Assert.AreEqual(testEnd.Value.UtcDateTime.ToString(), end.Value.ToUniversalTime().ToString());
            AssertThrows<ArgumentException>(() => SasTokenHelper.SetupAccessPolicyLifeTime(end, start, out testStart, out testEnd, true));
        }
    }
}
