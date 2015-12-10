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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class GetWAPackVMTemplateTests : CmdletTestBase
    {
        public const string cmdletName = "Get-WAPackVMTemplate";

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVMTemplateWithNoParam()
        {
            var allTemplates = this.InvokeCmdlet(cmdletName, null);
            Assert.IsTrue(allTemplates.Any());
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVMTemplatesFromName()
        {
            string expectedTemplateName = WAPackConfigurationFactory.Win7_64TemplateName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedTemplateName}
            };
            var templateFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, templateFromName.Count);
            var actualtemplateName = templateFromName.First().Properties["Name"].Value;

            Assert.AreEqual(expectedTemplateName, actualtemplateName);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVMTemplatesFromIdAndName()
        {
            string expectedTemplateName = WAPackConfigurationFactory.Win7_64TemplateName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedTemplateName}
            };
            var templateFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, templateFromName.Count);
            var expectedtemplateId = templateFromName.First().Properties["Id"].Value;

            inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedtemplateId}
            };
            var templateFromId = this.InvokeCmdlet(cmdletName, inputParams);

            var actualtemplateFromId = templateFromId.First().Properties["Id"].Value;
            Assert.AreEqual(expectedtemplateId, actualtemplateFromId);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVMTemplates()
        {
            string expectedTemplateName = WAPackConfigurationFactory.Win7_64TemplateName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedTemplateName}
            };
            var templateFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, templateFromName.Count);
            var actualtemplateName = templateFromName.First().Properties["Name"].Value;

            Assert.AreEqual(expectedTemplateName, actualtemplateName);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVMTemplateByNameDoesNotExist()
        {
            string expectedTemplateName = "WAPackVMTemplateDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedTemplateName}
            };
            var templateFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(0, templateFromName.Count);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVMTemplateByIdDoesNotExist()
        {
            var expectedVmId = Guid.NewGuid().ToString();
            var expectedError = string.Format(Utilities.Properties.Resources.ResourceNotFound, expectedVmId);
            var inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedVmId}
            };
            var vmFromName = this.InvokeCmdlet(cmdletName, inputParams, expectedError);
            Assert.AreEqual(0, vmFromName.Count);
        }
    }
}
