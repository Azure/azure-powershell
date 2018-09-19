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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class PlatformExtensionTest : ServiceManagementTest
    {

        [TestInitialize]
        public void Initialize()
        {
            pass = false;
            testStartTime = DateTime.Now;
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");
        }

        /// <summary>
        /// This test covers New-AzurePlatformExtensionCertificateConfig cmdlet
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet New-AzurePlatformExtensionCertificateConfig)")]
        public void AzurePlatformExtensionCertificateConfigTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // starting the test.
            string storeLocation = "LocalMachine";
            string storeName = "My";
            string thumbprintAlgorithm = "sha1";
            var certConfig = vmPowershellCmdlets.NewAzurePlatformExtensionCertificateConfig(
                storeLocation, storeName, thumbprintAlgorithm, true);

            ValidateExtensionCertificateConfig(certConfig, storeLocation, storeName, thumbprintAlgorithm, true);

            certConfig = vmPowershellCmdlets.NewAzurePlatformExtensionCertificateConfig(
                storeLocation, storeName, thumbprintAlgorithm);

            ValidateExtensionCertificateConfig(certConfig, storeLocation, storeName, thumbprintAlgorithm, false);

            pass = true;
        }

        /// <summary>
        /// This test covers AzurePlatformExtensionEndpoint cmdlets
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the AzurePlatformExtensionEndpoint cmdlets)")]
        public void AzurePlatformExtensionEndpointConfigTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            const string inputEP = "Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput";
            const string internalEP = "Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp";
            const string instanceInputEP = "Microsoft.WindowsAzure.Plugins.RemoteAccess.RdpInstanceInput";
            const string tcpProtocol = "tcp";
            const int port = 3389;
            const string localPort = "*";
            const int minPort = 1;
            const int maxPort = 65535;

            // starting the test.
            var epConfig = vmPowershellCmdlets.NewAzurePlatformExtensionEndpointConfigSet();

            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig,
                inputEP, tcpProtocol, port, localPort);
            ValidateExtensionInputEndpointConfig(epConfig.InputEndpoints, inputEP, tcpProtocol, port, localPort);

            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, internalEP, tcpProtocol, port);
            ValidateExtensionInternalEndpointConfig(epConfig.InternalEndpoints, internalEP, tcpProtocol, port);

            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, instanceInputEP,
                tcpProtocol, localPort, maxPort, minPort);
            ValidateExtensionInstanceInputEndpointConfig(epConfig.InstanceInputEndpoints,
                instanceInputEP, tcpProtocol, localPort, maxPort, minPort);

            const string inputEP2 = "Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput2";
            const string internalEP2 = "Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp2";
            const string instanceInputEP2 = "Microsoft.WindowsAzure.Plugins.RemoteAccess.RdpInstanceInput2";

            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, inputEP2,
                tcpProtocol, port, localPort);
            ValidateExtensionInputEndpointConfig(epConfig.InputEndpoints, inputEP2, tcpProtocol, port, localPort);

            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, internalEP2,
                tcpProtocol, port);
            ValidateExtensionInternalEndpointConfig(epConfig.InternalEndpoints, internalEP2, tcpProtocol, port);

            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, instanceInputEP2,
                tcpProtocol, localPort, maxPort, minPort);
            ValidateExtensionInstanceInputEndpointConfig(epConfig.InstanceInputEndpoints,
               instanceInputEP2, tcpProtocol, localPort, maxPort, minPort);

            // Remove endpoints from config
            epConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionEndpoint(epConfig,
                inputEP, "Input");
            ValidateExtensionInputEndpointConfig(epConfig.InputEndpoints, inputEP2, tcpProtocol, port, localPort);

            epConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionEndpoint(epConfig,
                internalEP, "Internal");
            ValidateExtensionInternalEndpointConfig(epConfig.InternalEndpoints, internalEP2, tcpProtocol, port);

            epConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionEndpoint(epConfig,
               instanceInputEP, "InstanceInput");
            ValidateExtensionInstanceInputEndpointConfig(epConfig.InstanceInputEndpoints,
               instanceInputEP2, tcpProtocol, localPort, maxPort, minPort);

            epConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionEndpoint(epConfig,
                inputEP2, "Input");
            Assert.AreEqual(0, epConfig.InputEndpoints.Count);

            epConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionEndpoint(epConfig,
                internalEP2, "Internal");
            Assert.AreEqual(0, epConfig.InternalEndpoints.Count);

            epConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionEndpoint(epConfig,
               instanceInputEP2, "InstanceInput");
            Assert.AreEqual(0, epConfig.InternalEndpoints.Count);

            pass = true;
        }

        /// <summary>
        /// This test covers AzurePlatformExtensionLocalResource cmdlets
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the AzurePlatformExtensionLocalResource cmdlets)")]
        public void AzurePlatformExtensionLocalResouceConfigTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            const string lrName = "disk space for local caching";
            const int size = 50;

            // starting the test.
            var lrConfig = vmPowershellCmdlets.NewAzurePlatformExtensionLocalResourceConfigSet();

            lrConfig = vmPowershellCmdlets.SetAzurePlatformExtensionLocalResource(lrConfig, lrName, size);
            ValidateExtensionLocalResourceConfig(lrConfig.LocalResources, lrName, size);

            lrConfig = vmPowershellCmdlets.RemoveAzurePlatformExtensionLocalResource(lrConfig, lrName);
            Assert.AreEqual(0, lrConfig.LocalResources.Count);

            pass = true;
        }

        /// <summary>
        /// This test covers AzurePlatformExtensionLocalResource cmdlets
        /// </summary>
        [TestMethod(), TestCategory("PIRTest"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the AzurePlatformExtensionLocalResource cmdlets)")]
        public void PublishAzurePlatformExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string extensionName = "RDP";
            string publisher = "Microsoft.WindowsAzure.Extensions";

            const string version = "1.0.0.1";

            const string hr = "WebRole|WorkerRole";
            Uri media = new Uri("https://rdfeagntextacctsn1prod.blob.core.windows.net/AgentExtensionContainer/RemoteAccessPlugin.zip");
            const string label = "extension-label";

            const  string description = "detailed extension-description";

            const string company = "Microsoft Azure";

            // Certificate Config
            const string storeLocation = "LocalMachine";
            const string storeName = "My";
            const string thumbprintAlgorithm = "sha1";
            ExtensionCertificateConfig certConfig = vmPowershellCmdlets.NewAzurePlatformExtensionCertificateConfig(
                storeLocation, storeName, thumbprintAlgorithm, true);

            // Endpoint Config
            const string inputEP = "Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput";
            const string internalEP = "Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp";
            const string instanceInputEP = "Microsoft.WindowsAzure.Plugins.RemoteAccess.RdpInstanceInput";
            const string tcpProtocol = "tcp";
            const int port = 3389;
            const string localPort1 = "*";
            const string localPort2 = "1111";
            const int minPort = 1;
            const int maxPort = 65535;

            ExtensionEndpointConfigSet epConfig = vmPowershellCmdlets.NewAzurePlatformExtensionEndpointConfigSet();
            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig,
                inputEP, tcpProtocol, port, localPort1);
            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, internalEP, tcpProtocol, port);
            epConfig = vmPowershellCmdlets.SetAzurePlatformExtensionEndpoint(epConfig, instanceInputEP,
                tcpProtocol, localPort2, maxPort, minPort);

            // Local Resource Config
            const string lrName = "disk space for local caching";
            const int size = 50;
            ExtensionLocalResourceConfigSet lrConfig = vmPowershellCmdlets.NewAzurePlatformExtensionLocalResourceConfigSet();
            lrConfig = vmPowershellCmdlets.SetAzurePlatformExtensionLocalResource(lrConfig, lrName, size);

            DateTime publishDate = DateTime.Now;
            const string publicSchema = @"<?xml version=""1.0"" encoding=""utf-8""?>"
                    + @"<xs:schema attributeFormDefault=""unqualified"""
                    + @"  elementFormDefault=""qualified"""
                    + @"  xmlns:xs=""http://www.w3.org/2001/XMLSchema"">"
                    + @"  <xs:element name=""PublicConfig"">"
                    + @"    <xs:complexType>"
                    + @"      <xs:sequence>"
                    + @"        <xs:element name=""UserName"" type=""xs:string"" />"
                    + @"      </xs:sequence>"
                    + @"    </xs:complexType>"
                    + @"  </xs:element>"
                    + @"</xs:schema>";

            const string privateSchema = @"<?xml version=""1.0"" encoding=""utf-8""?>"
                + @"<xs:schema attributeFormDefault=""unqualified"""
                + @"  elementFormDefault=""qualified"""
                + @"  xmlns:xs=""http://www.w3.org/2001/XMLSchema"">"
                + @"  <xs:element name=""PrivateConfig"">"
                + @"    <xs:complexType>"
                + @"      <xs:sequence>"
                + @"        <xs:element name=""Password"" type=""xs:string"" />"
                + @"      </xs:sequence>"
                + @"    </xs:complexType>"
                + @"  </xs:element>"
                + @"</xs:schema>";

            const string sample = "TestSampleConfig";

            const string eula = "http://www.contoso.com/42588280809/eula";
            Uri privacyUri = new Uri("http://www.contoso.com/42588280809/privacy");
            Uri homepage = new Uri("http://www.contoso.com/42588280809/homepage");

            const string os = "Windows";

            const bool blockRole = true;
            const bool disallowUpgrade = true;
            const bool xmlExtension = false;
            const bool force = true;
            const string regions = "West US";

            // starting the test.
            try
            {
               vmPowershellCmdlets.PublishAzurePlatformExtension(
                    extensionName, publisher, version, hr,
                    media, label, description, company,
                    certConfig, epConfig, lrConfig,
                    publishDate, publicSchema, privateSchema, EncodeTo64(sample),
                    eula, privacyUri, homepage, os, regions,
                    blockRole, disallowUpgrade, xmlExtension, force);
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.Message.Contains("ForbiddenError"))
                {
                    Console.WriteLine("Subscription is not a publisher.");
                }
                else
                {
                    throw;
                }
            }

            try
            {
                vmPowershellCmdlets.UnpublishAzurePlatformExtension(extensionName, publisher, version, true);

            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.Message.Contains("ForbiddenError"))
                {
                    Console.WriteLine("Subscription is not a publisher.");
                }
                else
                {
                    throw;
                }
            }

            extensionName = "VMAccessAgent";
            publisher = "Microsoft.Compute";

            try
            {
                vmPowershellCmdlets.PublishAzurePlatformExtension(
                     extensionName, publisher, version, hr,
                     media, label, description, company,
                     certConfig, epConfig, lrConfig,
                     publishDate, publicSchema, privateSchema, EncodeTo64(sample),
                     eula, privacyUri, homepage, os, regions,
                     blockRole, disallowUpgrade, xmlExtension, force);
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.Message.Contains("ForbiddenError"))
                {
                    Console.WriteLine("Subscription is not a publisher.");
                }
                else
                {
                    throw;
                }
            }

            pass = true;
        }

        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes

                  = ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }


        private void ValidateExtensionCertificateConfig (ExtensionCertificateConfig certConfig,
            string storeLocation, string storeName, string thumbAlgorithm, bool thumbRequired)
        {
            Assert.AreEqual(storeLocation, certConfig.StoreLocation);
            Assert.AreEqual(storeName, certConfig.StoreName);
            Assert.AreEqual(thumbAlgorithm, certConfig.ThumbprintAlgorithm);
            Assert.AreEqual(thumbRequired, certConfig.ThumbprintRequired);
        }

        private void ValidateExtensionInputEndpointConfig(
            List<PlatformImageRepository.Model.ExtensionInputEndpoint> inputEPConfig,
            string inputEP, string protocol, int port, string localport)
        {
            var ep = inputEPConfig.FirstOrDefault(e => e.Name.Equals(inputEP));

            if (ep == null)
            {
                Assert.Fail("No endpoint matching");
            }
            else
            {
                Assert.AreEqual(protocol, ep.Protocol);
                Assert.AreEqual(port, ep.Port);
                Assert.AreEqual(localport, ep.LocalPort);
            }
        }

        private void ValidateExtensionInternalEndpointConfig(
            List<PlatformImageRepository.Model.ExtensionInternalEndpoint> internalEPConfig,
            string internalEP, string protocol, int port)
        {
            var ep = internalEPConfig.FirstOrDefault(e => e.Name.Equals(internalEP));

            if (ep == null)
            {
                Assert.Fail("No endpoint matching");
            }
            else
            {
                Assert.AreEqual(protocol, ep.Protocol);
                Assert.AreEqual(port, ep.Port);
            }
        }

        private void ValidateExtensionInstanceInputEndpointConfig(
            List<PlatformImageRepository.Model.ExtensionInstanceInputEndpoint> instanceInputEPConfig,
            string instanceInputEP, string protocol, string localport, int maxPort, int minPort)
        {
            var ep = instanceInputEPConfig.FirstOrDefault(e => e.Name.Equals(instanceInputEP));

            if (ep == null)
            {
                Assert.Fail("No endpoint matching");
            }
            else
            {
                Assert.AreEqual(protocol, ep.Protocol);
                Assert.AreEqual(localport, ep.LocalPort);
                Assert.AreEqual(maxPort, ep.FixedPortMax);
                Assert.AreEqual(minPort, ep.FixedPortMin);
            }
        }

        private void ValidateExtensionLocalResourceConfig(
            List<PlatformImageRepository.Model.ExtensionLocalResourceConfig> lrConfig,
            string name, int size)
        {
            var lr = lrConfig.FirstOrDefault(e => e.Name.Equals(name));

            if (lr == null)
            {
                Assert.Fail("No local resource matching");
            }
            else
            {
                Assert.AreEqual(name, lr.Name);
                Assert.AreEqual(size, lr.SizeInMB);
            }
        }
    }
}
