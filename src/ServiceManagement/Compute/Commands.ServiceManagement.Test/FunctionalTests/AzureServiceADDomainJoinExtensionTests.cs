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
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class AzureServiceADDomainJoinExtensionTests:ServiceManagementTest
    {
        private string _serviceName;
        private string _deploymentName;
        private string _deploymentLabel;
        private string _packageName;
        private string _configName;
        private string _rdpCertName;
        private X509Certificate2 _cert;

        private FileInfo _packagePath1;
        private FileInfo _configPath1;
        private FileInfo _rdpCertPath;
        private PSCredential _cred;

        const string DomainName = "djtest.com";
        const string ThumbprintAlgorithm = "sha1";

        const string DeploymentNamePrefix = "psdeployment";
        const string DeploymentLabelPrefix = "psdeploymentlabel";
        private const string DomainUserName = "pstestuser@djtest.com";
        private const string AffinityGroupName = "WestUsAffinityGroup";

        private const string WorkgroupName = "WORKGROUP1";

        // Choose the package and config files from local machine
        readonly string[] _role = { "WebRole1" };

        [TestInitialize]
        public void Initialize()
        {
            _serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            _deploymentName = Utilities.GetUniqueShortName(DeploymentNamePrefix);
            _deploymentLabel = Utilities.GetUniqueShortName(DeploymentLabelPrefix);

            pass = false;

            // Choose the package and config files from local machine
            _packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            _configName = Convert.ToString(TestContext.DataRow["configName"]);
            _rdpCertName = Convert.ToString(TestContext.DataRow["rdpCertName"]);
            _packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + _packageName);
            _configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + _configName);
            _rdpCertPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + _rdpCertName);
            _cert = new X509Certificate2(_rdpCertPath.FullName, password);
            _cred = new PSCredential(DomainUserName, Utilities.convertToSecureString(password));

            CheckIfPackageAndConfigFilesExists();
            testStartTime = DateTime.Now;
        }

        #region join domain cmdlet tests
        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDefaultParamterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName);
            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    joinOption: 35,
                    restart:true,
                    serviceName:_serviceName,
                    slot: DeploymentSlotType.Production);
                Console.WriteLine("Servie {0} added to domain {1} successfully.", _serviceName, DomainName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDomainJoinParmaterSetAndJoinOptionsTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domian with DomainJoinParmaterSet with JoinOptions.JoinDomain
                Console.WriteLine("Joining domain with domain join parameter set with JoinOptions.JoinDomain");

                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    options: JoinOptions.JoinDomain,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: _role);

                Console.WriteLine("Servie {0} added to domain {1} successfully using join option.", _serviceName, DomainName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDomainParmaterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                NewAzureDeployment();

                //Join Domian with DomainParmaterSet
                Console.WriteLine("Joining domain with domian parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    options: null,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: _role,
                    x509Certificate: _cert,
                    thumbprintAlgorithm: ThumbprintAlgorithm);
                Console.WriteLine("Servie {0} added to domain {1} successfully.", _serviceName, DomainName);
                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDomainJoinParmaterSetAndCertificateTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                NewAzureDeployment();

                //Join Domian with DomainJoinParmaterSet and certificate
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential:_cred,
                    options:JoinOptions.JoinDomain,
                    restart: true,
                    serviceName:_serviceName,
                    slot: DeploymentSlotType.Production,
                    role:_role,
                    x509Certificate:_cert,
                    thumbprintAlgorithm: ThumbprintAlgorithm);

                Console.WriteLine("Servie {0} added to domain {1} successfully.", _serviceName, DomainName);
                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDomainThumbprintParameterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join domain with DomainThumbprintParameterSet
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    options: null,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: _role,
                    certificateThumbprint: _cert.Thumbprint,
                    thumbprintAlgorithm: ThumbprintAlgorithm);

                Console.WriteLine("Servie {0} added to domain {1} successfully.", _serviceName, DomainName);
                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDefaultParameterSet35Test()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join domain with DomainJoinThumbprintParameterSet
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    joinOption: 35,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: _role);
                Console.WriteLine("Servie {0} added to domain {1} successfully", _serviceName, DomainName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithDomainJoinThumbprintParameterSetAndJoinOption35Test()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join domain with DomainJoinThumbprintParameterSet and join oprtion 35
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    joinOption: 35,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: _role,
                    certificateThumbprint: _cert.Thumbprint,
                    thumbprintAlgorithm: ThumbprintAlgorithm);
                Console.WriteLine("Servie {0} added to domain {1} successfully using join option 35", _serviceName, DomainName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewAzureServiceDomainJoinExtensionConfigWithDefaultParmateSetTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with default parameter set
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    x509Certificate: null,
                    options: null,
                    oUPath: null,
                    unjoinDomainCredential: null,
                    role: _role,
                    thumbprintAlgorithm: null,
                    restart: true,
                    credential: _cred);

                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewDomainJoinExtConfigWithDefaultParmateSetAndJoinOptionsTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with default parameter set and one of the join options
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    x509Certificate: null,
                    options: JoinOptions.JoinDomain,
                    oUPath: null,
                    unjoinDomainCredential: null,
                    role: null,
                    thumbprintAlgorithm: null,
                    restart: true,
                    credential: _cred);

                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment(domainJoinExtensionConfig);
                GetAzureServiceDomainJoinExtension();
                RemoveAzureServiceDomainJoinExtesnion();
                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);

                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewDomainJoinExtConfigWithDomainParmateSetTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with DomainParameterSet (using only X509certicate2)
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    x509Certificate: _cert,
                    //options: null,
                    //oUPath: null,
                    unjoinDomainCredential: null,
                    role: null,
                    thumbprintAlgorithm: null,
                    restart: true,
                    credential:_cred);

                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);

                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewDomainJoinExtConfigWithDomainParameterSetAndCertTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    x509Certificate: _cert,
                    options: JoinOptions.JoinDomain,
                    oUPath: null,
                    unjoinDomainCredential: null,
                    role: null,
                    thumbprintAlgorithm: null,
                    restart: true,
                    credential: _cred);

                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewDomainJoinExtConfigWithDomianThumbprintParameterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with DomianThumbprintParameterSet
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    certificateThumbprint: _cert.Thumbprint,
                    joinOption: null,
                    oUPath: null,
                    unjoinDomainCredential: null,
                    role:_role,
                    thumbprintAlgorithm: ThumbprintAlgorithm,
                    restart: true,
                    credential: _cred);

                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewDomainJoinExtConfigWithDefaultParmateSetAndJoinOption35Test()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with default parameter set and joinOption 35
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    certificateThumbprint: null,
                    joinOption: 35,
                    oUPath: null,
                    unjoinDomainCredential: null,
                    role:_role,
                    thumbprintAlgorithm: null,
                    restart: true,
                    credential:_cred);
                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);

                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewDomainJoinExtConfigWithDomianJoinThumbprintParameterSetTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName: DomainName,
                    certificateThumbprint: _cert.Thumbprint,
                    oUPath: null,
                    unjoinDomainCredential: null,
                    role: _role,
                    thumbprintAlgorithm: ThumbprintAlgorithm,
                    joinOption: 35,
                    restart: true,
                    credential: _cred);

                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);

                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }
        #endregion join domain cmdlet tests

        #region join workgroup cmdlet tests
        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithWorkGroupDefaultParamterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName);
            try
            {                
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with Workgroup default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: WorkgroupName,
                    serviceName: _serviceName);

                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, WorkgroupName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void UpdateWorkGroupWithSetAzureDomainJoinExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName);
            try
            {
                const string workgroup2 = "WORKGROUP2";
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with Workgroup default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: WorkgroupName,
                    serviceName: _serviceName,
                    credential: _cred);
                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, WorkgroupName);

                GetAzureServiceDomainJoinExtension();

                Console.WriteLine("Joining domain with Workgroup default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: workgroup2,
                    serviceName: _serviceName);
                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, workgroup2);

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void JoinDomainAndUpdateToWorkGroupWithSetAzureDomainJoinExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName);
            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with default parameter set");
                
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    joinOption: 35,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: null,
                    unjoinDomainCredential: _cred);
                Console.WriteLine("Servie {0} added to domain {1} successfully.", _serviceName, DomainName);

                GetAzureServiceDomainJoinExtension();

                //Join workgroup
                Console.WriteLine("Joining domain with Workgroup default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: WorkgroupName,
                    serviceName: _serviceName);
                //vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(workgroup1, _serviceName, DeploymentSlotType.Production, null, restart: true);
                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, WorkgroupName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void JoinWorkgroupAndThenJoinDomainWithSetAzureDomainJoinExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName); 
            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join workgroup
                Console.WriteLine("Joining domain with Workgroup default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: WorkgroupName,
                    serviceName: _serviceName);
                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, WorkgroupName);

                GetAzureServiceDomainJoinExtension();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with default parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName: DomainName,
                    credential: _cred,
                    joinOption: 35,
                    restart: true,
                    serviceName: _serviceName,
                    slot: DeploymentSlotType.Production,
                    role: null,
                    unjoinDomainCredential: _cred);
                Console.WriteLine("Servie {0} added to domain {1} successfully.", _serviceName, DomainName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithWorkGroupThumbprintParamterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName);
            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with Workgroup thumbprint parameter set");

                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: WorkgroupName,
                    serviceName:_serviceName,
                    slot: DeploymentSlotType.Production,
                    role: _role,
                    certificateThumbprint: _cert.Thumbprint,
                    thumbprintAlgorithm: ThumbprintAlgorithm,
                    restart: true);
                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, WorkgroupName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceADDomainExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void SetAzureServiceDomainJoinExtensionwithWorkGroupCertificateParamterSetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            Console.WriteLine(_cred.UserName);
            try
            {
                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment();

                //Join Domain with default parameter set.
                Console.WriteLine("Joining domain with Workgroup certificate parameter set");
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName: WorkgroupName,
                    serviceName: _serviceName,
                    x509Certificate: _cert);

                Console.WriteLine("Servie {0} added to workgroup {1} successfully.", _serviceName, WorkgroupName);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion();

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewAzureServiceDomainJoinExtensionConfigWithWorkgroupDefaultParmateSetTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with workgroup default parameter set
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    workGroupName: WorkgroupName,
                    x509Certificate: null,
                    credential: _cred);

                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewAzureServiceDomainJoinExtensionConfigWithWorkgroupThumbprintParmateSetTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with workgroup default parameter set
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    workGroupName: WorkgroupName,
                    certificateThumbprint: _cert.Thumbprint,
                    role: null,
                    restart: true,
                    thumbprintAlgorithm: ThumbprintAlgorithm);

                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory("ADDomain"), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New)-AzureServiceADDomainExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageADDomain.csv", "packageADDomain#csv", DataAccessMethod.Sequential)]
        public void NewAzureServiceDomainJoinExtensionConfigWithWorkgroupCertificateParmateSetTests()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //Prepare a new domain join config with workgroup default parameter set
                ExtensionConfigurationInput domainJoinExtensionConfig = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    workGroupName: WorkgroupName,
                    x509Certificate: _cert,
                    restart: true);

                //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
                NewAzureDeployment(domainJoinExtensionConfig);

                GetAzureServiceDomainJoinExtension();

                RemoveAzureServiceDomainJoinExtesnion(_role);

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);
                //TO DO: add test cases to test cmdlet with UnjoinCrednetial patameter.
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        #endregion join workgroup cmdlet tests

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            // Remove the service
            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                CleanupService(_serviceName);
            }
        }

        #region Helper Methods
        private void NewAzureDeployment(ExtensionConfigurationInput domainJoinExtensionConfig = null)
        {
            //Create a new Azure Iaas VM and set Domain Join extension, get domain join extension and then remove domain join extension
            Console.WriteLine("Creating a new Azure Iaas VM");

            vmPowershellCmdlets.NewAzureService(_serviceName, _serviceName, null, AffinityGroupName);

            Console.WriteLine("Service, {0}, is created.", _serviceName);

            vmPowershellCmdlets.AddAzureCertificate(_serviceName, _rdpCertPath.FullName, password);

            if (domainJoinExtensionConfig == null)
            {
                vmPowershellCmdlets.NewAzureDeployment(_serviceName, _packagePath1.FullName, _configPath1.FullName, DeploymentSlotType.Production, _deploymentLabel, _deploymentName, false, false);
                Console.WriteLine("New deployment created successfully.");
            }
            else
            {
                vmPowershellCmdlets.NewAzureDeployment(_serviceName, _packagePath1.FullName, _configPath1.FullName, DeploymentSlotType.Production, _deploymentLabel, _deploymentName, false, false, domainJoinExtensionConfig);
                Console.WriteLine("{0}:New deployment {1} with domain join {2} created successfully.", DateTime.Now, _serviceName, domainJoinExtensionConfig.Type);
            }
        }

        private void GetAzureServiceDomainJoinExtension()
        {
            var domianContext = vmPowershellCmdlets.GetAzureServiceDomainJoinExtension(_serviceName, DeploymentSlotType.Production);
            Utilities.PrintContext(domianContext);
            Assert.IsFalse(string.IsNullOrEmpty(domianContext.Extension), "Extension is empty or null.");
            Console.WriteLine("Service domain join extension fetched successfully.");
        }

        private void RemoveAzureServiceDomainJoinExtesnion(string[] roles = null, bool uninstallConfig = false)
        {
            Console.WriteLine("Removing the domian join extension.");
            vmPowershellCmdlets.RemoveAzureServiceDomainJoinExtension(_serviceName, DeploymentSlotType.Production, roles, uninstallConfig);
            Console.WriteLine("Removed domain join extension for the deployment {0} succefully.", _deploymentName);
        }

        private void CheckIfPackageAndConfigFilesExists()
        {
            Assert.IsTrue(File.Exists(_packagePath1.FullName), "VHD file not exist={0}", _packagePath1);
            Assert.IsTrue(File.Exists(_configPath1.FullName), "VHD file not exist={0}", _configPath1);
        }
        #endregion Helper Methods
    }
}
