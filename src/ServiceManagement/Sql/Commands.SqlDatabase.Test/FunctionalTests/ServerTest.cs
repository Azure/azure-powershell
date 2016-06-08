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
using System.IO;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.FunctionalTests
{
    [TestClass]
    public class ServerTest
    {
        private string subscriptionID;
        private string serializedCert;
        private string serverLocation;
        private string manageUrl;
        private string serverName;
        private string username;
        private string password;

        private const string ServerTestScript = @"Server\CreateGetDeleteServer.ps1";
        private const string FirewallTestScript = @"Server\CreateGetDropFirewall.ps1";
        private const string ResetPasswordScript = @"Server\ResetPassword.ps1";
        private const string FormatValidationScript = @"Server\FormatValidation.ps1";

        /// <summary>
        /// The path to the script for testing get server quota
        /// </summary>
        private const string GetQuotaScript = @"Server\GetServerQuota.ps1";

        /// <summary>
        /// The end point to use for the tests
        /// </summary>
        private const string LocalRdfeEndpoint = @"https://management.dev.mscds.com:12346/";
         
        [TestInitialize]
        public void Setup()
        {
            XElement root = XElement.Load("SqlDatabaseSettings.xml");
            this.subscriptionID = root.Element("SubscriptionId").Value;
            this.serializedCert = root.Element("SerializedCert").Value;
            this.serverLocation = root.Element("ServerLocation").Value;
            this.manageUrl = root.Element("ManageUrl").Value;
            this.username = root.Element("SqlAuthUserName").Value;
            this.password = root.Element("SqlAuthPassword").Value;
            this.serverName = new Uri(this.manageUrl).Host.Split('.')[0];
        }

        [TestMethod]
        [TestCategory("Functional")]
        public void CreateGetDeleteServerTest()
        {            
            string arguments = string.Format(
                "-subscriptionID \"{0}\" -serializedCert \"{1}\" -serverLocation \"{2}\" -Endpoint \"{3}\"", 
                this.subscriptionID, 
                this.serializedCert, 
                this.serverLocation,
                LocalRdfeEndpoint);
            bool testResult = PSScriptExecutor.ExecuteScript(ServerTest.ServerTestScript, arguments);
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("Functional")]
        public void FirewallTest()
        {
            string arguments = string.Format(
                "-subscriptionID \"{0}\" -serializedCert \"{1}\" -serverLocation \"{2}\" -Endpoint \"{3}\"", 
                this.subscriptionID, 
                this.serializedCert,
                this.serverLocation,
                LocalRdfeEndpoint);
            bool testResult = PSScriptExecutor.ExecuteScript(ServerTest.FirewallTestScript, arguments);
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("Functional")]
        public void ResetServerPassword()
        {
            string arguments = string.Format(
                "-subscriptionID \"{0}\" -serializedCert \"{1}\" -serverLocation \"{2}\"", 
                this.subscriptionID, 
                this.serializedCert, 
                this.serverLocation);
            bool testResult = 
                PSScriptExecutor.ExecuteScript(ServerTest.ResetPasswordScript, arguments);
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("Functional")]
        [Ignore]
        public void OutputObjectFormatValidation()
        {
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid() + ".txt");
            string arguments = string.Format(
                "-subscriptionID \"{0}\" -serializedCert \"{1}\" -serverLocation \"{2}\" -OutputFile \"{3}\"", 
                this.subscriptionID, 
                this.serializedCert, 
                this.serverLocation, outputFile);
            bool testResult = 
                PSScriptExecutor.ExecuteScript(ServerTest.FormatValidationScript, arguments);
            Assert.IsTrue(testResult);

            OutputFormatValidator.ValidateOutputFormat(outputFile, @"Server\ExpectedFormat.txt");
        }

        /// <summary>
        /// Test for getting a servers quota
        /// </summary>
        [TestMethod]
        [TestCategory("Functional")]
        public void GetServerQuotaTest()
        {
            string arguments = string.Format(
                "-SloManageUrl \"{0}\" -subscriptionID \"{1}\" -serializedCert \"{2}\" -serverLocation \"{3}\" "
                + " -Endpoint \"{4}\" -Username \"{5}\" -Password \"{6}\"",
                this.manageUrl,
                this.subscriptionID,
                this.serializedCert,
                this.serverLocation,
                LocalRdfeEndpoint,
                this.username,
                this.password);
            bool testResult = PSScriptExecutor.ExecuteScript(ServerTest.GetQuotaScript, arguments);
            Assert.IsTrue(testResult);
        }
    }
}
