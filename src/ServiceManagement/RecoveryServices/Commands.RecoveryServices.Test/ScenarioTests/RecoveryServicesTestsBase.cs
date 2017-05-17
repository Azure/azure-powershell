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
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Management.RecoveryServices;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade;
using Microsoft.Azure.Test;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public abstract class RecoveryServicesTestsBase
    {
        private RDFETestEnvironmentFactory rdfeTestFactory;
        private EnvironmentSetupHelper helper;
        protected string vaultSettingsFilePath;
        protected string vaultName;
        protected string location;
        protected string resourceType;
        protected string resourceNamespace;
        protected string targetRgName;
        protected string cloudServiceName;
        private ASRVaultCreds asrVaultCreds = null;

        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }
        public RecoveryServicesManagementClient RecoveryServicesMgmtClient { get; private set; }
        public RecoveryServicesVaultUpgradeManagementClient VaultUpgradeMgmtClient { get; private set; }

        protected RecoveryServicesTestsBase()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VAULT_SETTINGS_FILE_PATH")))
            {
                Environment.SetEnvironmentVariable(
                    "VAULT_SETTINGS_FILE_PATH",
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScenarioTests\\vaultSettings.vaultcredentials"));
            }

            this.vaultSettingsFilePath = Environment.GetEnvironmentVariable("VAULT_SETTINGS_FILE_PATH");
            this.vaultName = "VaultUpgrade";
            this.location = "South India";
            this.resourceType = "HyperVRecoveryManagerVault";
            this.targetRgName = "test-rg";
            this.resourceNamespace = "WAHyperVRecoveryManager";
            this.cloudServiceName = "CS-South-India-RecoveryServices";

            if (string.IsNullOrEmpty(vaultSettingsFilePath))
            {
                throw new Exception("Please set VAULT_SETTINGS_FILE_PATH environment variable before running the tests");
            }

            if (File.Exists(this.vaultSettingsFilePath))
            {
                try
                {
                    var serializer1 = new DataContractSerializer(typeof(ASRVaultCreds));
                    using (var s = new FileStream(
                        this.vaultSettingsFilePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                    {
                        asrVaultCreds = (ASRVaultCreds)serializer1.ReadObject(s);
                    }
                }
                catch (XmlException xmlException)
                {
                    throw new XmlException(
                        "XML is malformed or file is empty", xmlException);
                }
                catch (SerializationException serializationException)
                {
                    throw new SerializationException(
                        "XML is malformed or file is empty", serializationException);
                }
            }
            else
            {
                throw new FileNotFoundException(
                    "Vault settings file not found, please pass the file downloaded from portal");
            }

            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            RecoveryServicesMgmtClient = GetRecoveryServicesManagementClient();
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient();
            VaultUpgradeMgmtClient = GetVaultUpgradeManagementClient();

            helper.SetupManagementClients(RecoveryServicesMgmtClient, SiteRecoveryMgmtClient, VaultUpgradeMgmtClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                this.rdfeTestFactory = new RDFETestEnvironmentFactory();

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement,
                    "ScenarioTests\\" + this.GetType().Name + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        private RecoveryServicesManagementClient GetRecoveryServicesManagementClient()
        {
            return TestBase.GetServiceClient<RecoveryServicesManagementClient>(this.rdfeTestFactory);
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient()
        {
            TestEnvironment environment = this.rdfeTestFactory.GetTestEnvironment();

            if (ServicePointManager.ServerCertificateValidationCallback == null)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    IgnoreCertificateErrorHandler;
            }

            return new SiteRecoveryManagementClient(
                asrVaultCreds.CloudServiceName,
                asrVaultCreds.ResourceName,
                RecoveryServicesMgmtClient.Credentials,
                RecoveryServicesMgmtClient.BaseUri).WithHandler(HttpMockServer.CreateInstance());
        }

        private RecoveryServicesVaultUpgradeManagementClient GetVaultUpgradeManagementClient()
        {
            return new RecoveryServicesVaultUpgradeManagementClient(
                cloudServiceName,
                resourceNamespace,
                resourceType,
                vaultName,
                RecoveryServicesMgmtClient.Credentials,
                RecoveryServicesMgmtClient.BaseUri).WithHandler(HttpMockServer.CreateInstance());
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}