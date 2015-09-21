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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    [TestClass]
    public class GetAzureStorageShareTest : StorageFileTestBase<GetAzureStorageShare>
    {
        [TestMethod]
        public void GetShareByNameTest()
        {
            this.MockChannel.SetsAvailableShare("share");

            this.CmdletInstance.RunCmdlet(
                Constants.SpecificParameterSetName,
                new KeyValuePair<string, object>("Name", "share"));

            this.MockCmdRunTime.OutputPipeline.Cast<CloudFileShare>().AssertSingleObject(x => x.Name == "share");
        }

        [TestMethod]
        public void GetNonExistingShareByNameTest()
        {
            this.CmdletInstance.RunCmdlet(
                Constants.SpecificParameterSetName,
                new KeyValuePair<string, object>("Name", "share"));

            this.MockCmdRunTime.ErrorStream.AssertMockupException("ShareNotExist");
        }

        [TestMethod]
        public void GetShareByPrefixTest()
        {
            var expectedShares = Enumerable.Range(0, 10).Select(x => string.Format(CultureInfo.InvariantCulture, "share{0}", x)).ToArray();
            this.MockChannel.SetsAvailableShare(expectedShares.Concat(Enumerable.Range(0, 5).Select(x => string.Format(CultureInfo.InvariantCulture, "nonshare{0}", x))).ToArray());

            this.CmdletInstance.RunCmdlet(
                Constants.MatchingPrefixParameterSetName,
                new KeyValuePair<string, object>("Prefix", "share"));

            this.MockCmdRunTime.OutputPipeline.AssertShares(expectedShares);
        }

        [TestMethod]
        public void GetShareByPrefixTest_NoShareMatchingPrefix()
        {
            this.MockChannel.SetsAvailableShare(Enumerable.Range(0, 5).Select(x => string.Format(CultureInfo.InvariantCulture, "nonshare{0}", x)).ToArray());

            this.CmdletInstance.RunCmdlet(
                Constants.MatchingPrefixParameterSetName,
                new KeyValuePair<string, object>("Prefix", "share"));

            Assert.AreEqual(0, this.MockCmdRunTime.OutputPipeline.Count, "Should be no result returned.");
        }
    }
}
