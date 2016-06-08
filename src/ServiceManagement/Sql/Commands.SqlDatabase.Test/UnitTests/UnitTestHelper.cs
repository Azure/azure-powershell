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
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests
{
    /// <summary>
    /// Common helper functions for SqlDatabase UnitTests.
    /// </summary>
    public static class UnitTestHelper
    {
        /// <summary>
        /// The subscription name used in the unit tests.
        /// </summary>
        private static readonly string UnitTestEnvironmentName = "SqlUnitTestEnvironment";

        /// <summary>
        /// The subscription name used in the unit tests.
        /// </summary>
        private static readonly string UnitTestSubscriptionName = "SqlUnitTestSubscription";

        /// <summary>
        /// The subscription Id used in the unit tests.
        /// </summary>
        private static readonly string UnitTestSubscriptionId = "00000000-0000-0000-0001-000000000001";

        /// <summary>
        /// The SSL certificate used in the unit tests.
        /// </summary>
        private static readonly string UnitTestSSLCertFile = "PowershellTestSSLCert.pfx";

        /// <summary>
        /// The password for the SSL certificate file.
        /// </summary>
        private static readonly string UnitTestSSLCertPassword = "=8e0l5H|~$|=(TGA_9#v";

        /// <summary>
        /// The client certificate used in the unit tests.
        /// </summary>
        private static readonly string UnitTestClientCertFile = "PowershellTestClientCert.pfx";

        /// <summary>
        /// The password for the client certificate file.
        /// </summary>
        private static readonly string UnitTestClientCertPassword = "vIFEKSeSxP?RUh`#-t,?";

        /// <summary>
        /// Verifies the ConfirmImpact level on a cmdlet.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to check.</param>
        /// <param name="confirmImpact">The expected confirm impact.</param>
        public static void CheckConfirmImpact(Type cmdlet, ConfirmImpact confirmImpact)
        {
            object[] cmdletAttributes = cmdlet.GetCustomAttributes(typeof(CmdletAttribute), true);
            Assert.AreEqual(1, cmdletAttributes.Length);
            CmdletAttribute attribute = (CmdletAttribute)cmdletAttributes[0];
            Assert.AreEqual(confirmImpact, attribute.ConfirmImpact);
        }

        /// <summary>
        /// Verifies if a cmdlet is suppose to modify data or not.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to check.</param>
        /// <param name="supportsShouldProcess">Whether or not the cmdlet is expected to modify data.</param>
        public static void CheckCmdletModifiesData(Type cmdlet, bool supportsShouldProcess)
        {
            // If the Cmdlet modifies data, SupportsShouldProcess should be set to true.
            object[] cmdletAttributes = cmdlet.GetCustomAttributes(typeof(CmdletAttribute), true);
            Assert.AreEqual(1, cmdletAttributes.Length);
            CmdletAttribute attribute = (CmdletAttribute)cmdletAttributes[0];
            Assert.AreEqual(supportsShouldProcess, attribute.SupportsShouldProcess);

            if (supportsShouldProcess)
            {
                // If the Cmdlet modifies data, there needs to be a Force property to bypass
                // ShouldProcess.
                Assert.AreNotEqual(
                    null,
                    cmdlet.GetProperty("Force"),
                    "Force property is expected for Cmdlets that modifies data.");
            }
        }

        public static AzureSubscription CreateUnitTestSubscription()
        {
            return new AzureSubscription
            {
                Name = "TestSubscription",
                Id = new Guid("00000000-0000-0000-0000-000000000000")
            };
        }

        /// <summary>
        /// Retrieve the client certificate used in the unittest.
        /// </summary>
        /// <returns>A <see cref="X509Certificate2"/> containing the client certificate</returns>
        public static X509Certificate2 GetUnitTestClientCertificate()
        {
            return ReadCertificateFromResource(
                UnitTestClientCertFile,
                UnitTestClientCertPassword);
        }

        /// <summary>
        /// Retrieve the SSL certificate used in the unittest.
        /// </summary>
        /// <returns>A <see cref="X509Certificate2"/> containing the SSL certificate</returns>
        public static X509Certificate2 GetUnitTestSSLCertificate()
        {
            return ReadCertificateFromResource(
                UnitTestSSLCertFile,
                UnitTestSSLCertPassword);
        }

        /// <summary>
        /// Use reflection to invoke a private member of an object.
        /// </summary>
        /// <param name="instance">The object on which to invoke the method.</param>
        /// <param name="methodName">The name of the method to invoke.</param>
        /// <param name="paramerters">An array of parameters for this method.</param>
        /// <returns>The return value for the method.</returns>
        public static object InvokePrivate(
            object instance,
            string methodName,
            params object[] paramerters)
        {
            Type cmdletType = instance.GetType();
            MethodInfo getManageUrlMethod = cmdletType.GetMethod(
                methodName,
                BindingFlags.Instance | BindingFlags.NonPublic);

            try
            {
                return getManageUrlMethod.Invoke(instance, paramerters);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        public static void SetFieldValue(
            Type type,
            string fieldName,
            object value)
        {
            FieldInfo field = type.GetField(fieldName);
            field.SetValue(null, value);
        }

        /// <summary>
        /// Invokes an array of scripts using the specified powershell instance.
        /// </summary>
        /// <param name="powershell">The powershell instance that executes the scripts.</param>
        /// <param name="scripts">An array of script to execute.</param>
        public static Collection<PSObject> InvokeBatchScript(
            this System.Management.Automation.PowerShell powershell,
            params string[] scripts)
        {
            if (powershell == null)
            {
                throw new ArgumentNullException("powershell");
            }

            powershell.Commands.Clear();

            foreach (string script in scripts)
            {
                Console.Error.WriteLine(script);
                powershell.AddScript(script);
            }

            Collection<PSObject> results = powershell.Invoke();
            powershell.DumpStreams();
            return results;
        }

        /// <summary>
        /// Dumps all powershell streams to the console.
        /// </summary>
        /// <param name="powershell">The powershell instance containing the streams.</param>
        public static void DumpStreams(this System.Management.Automation.PowerShell powershell)
        {
            if (powershell == null)
            {
                throw new ArgumentNullException("powershell");
            }

            foreach (ProgressRecord record in powershell.Streams.Progress)
            {
                Console.Out.WriteLine("Progress: {0}", record.ToString());
            }

            foreach (DebugRecord record in powershell.Streams.Debug)
            {
                Console.Out.WriteLine("Debug: {0}", record.ToString());
            }

            foreach (VerboseRecord record in powershell.Streams.Verbose)
            {
                Console.Out.WriteLine("Verbose: {0}", record.ToString());
            }

            foreach (WarningRecord record in powershell.Streams.Warning)
            {
                Console.Error.WriteLine("Warning: {0}", record.ToString());
            }

            foreach (ErrorRecord record in powershell.Streams.Error)
            {
                Console.Error.WriteLine("Error: {0}", record.ToString());
            }
        }

        /// <summary>
        /// Imports the Azure Manifest to the given <paramref name="powershell"/> instance.
        /// </summary>
        /// <param name="powershell">An instance of the <see cref="PowerShell"/> object.</param>
        public static void ImportAzureModule(System.Management.Automation.PowerShell powershell)
        {
            // Import the test manifest file
            powershell.InvokeBatchScript(@"Import-Module ..\..\..\..\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1");
            powershell.InvokeBatchScript(@"Import-Module ..\..\..\..\Package\Debug\Storage\Azure.Storage\Azure.Storage.psd1");
            powershell.InvokeBatchScript(@"Import-Module ..\..\..\..\Package\Debug\ServiceManagement\Azure\Azure.psd1");
            Assert.IsTrue(powershell.Streams.Error.Count == 0);
        }

        /// <summary>
        /// Creates the $credential object in the given <paramref name="powershell"/> instance with
        /// user name "testuser" and password "testpass".
        /// </summary>
        /// <param name="powershell">An instance of the <see cref="PowerShell"/> object.</param>
        public static void CreateTestCredential(System.Management.Automation.PowerShell powershell)
        {
            CreateTestCredential(powershell, "testuser", "testp@ss1");
        }

        /// <summary>
        /// Creates the $credential object in the given <paramref name="powershell"/> instance with
        /// the given user name and password.
        /// </summary>
        /// <param name="powershell">An instance of the <see cref="PowerShell"/> object.</param>
        public static void CreateTestCredential(System.Management.Automation.PowerShell powershell, string username, string password)
        {
            password = password.Replace("$", "`$");

            // Create the test credential
            powershell.InvokeBatchScript(
                string.Format(@"$user = ""{0}""", username),
                string.Format(@"$pass = ""{0}"" | ConvertTo-SecureString -asPlainText -Force", password),
                @"$credential = New-Object System.Management.Automation.PSCredential($user, $pass)");
            Assert.IsTrue(powershell.Streams.Error.Count == 0);
        }

        /// <summary>
        /// Common helper method for other tests to create a unit test subscription
        /// that connects to the mock server.
        /// </summary>
        /// <param name="powershell">The powershell instance used for the test.</param>
        public static AzureSubscription SetupUnitTestSubscription(System.Management.Automation.PowerShell powershell)
        {
            UnitTestHelper.ImportAzureModule(powershell);

            X509Certificate2 certificate = UnitTestHelper.GetUnitTestClientCertificate();
            Guid subscriptionId = new Guid(UnitTestSubscriptionId);

            // Set the client certificate used in the subscription
            powershell.Runspace.SessionStateProxy.SetVariable(
                "clientCertificate",
                certificate);

            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ProfileClient client = new ProfileClient(profile);
            client.AddOrSetEnvironment(new AzureEnvironment
                {
                    Name = UnitTestEnvironmentName,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        {AzureEnvironment.Endpoint.ServiceManagement, MockHttpServer.DefaultHttpsServerPrefixUri.AbsoluteUri},
                        {AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, ".database.windows.net"}
                    }
                });
            
            var account = new AzureAccount
            {
                Id = certificate.Thumbprint,
                Type = AzureAccount.AccountType.Certificate
            };

            var subscription = new AzureSubscription
            {
                Id = subscriptionId,
                Name = UnitTestSubscriptionName,
                Environment = UnitTestEnvironmentName,
                Account = account.Id
            };

            client.AddOrSetAccount(account);
            client.AddOrSetSubscription(subscription);
            client.SetSubscriptionAsDefault(subscriptionId, account.Id);
            client.Profile.Save();

            return subscription;
        }

        /// <summary>
        /// Retrieve a certificate from embedded resource.
        /// </summary>
        /// <param name="resourceName">The logical name of the embedded resource.</param>
        /// <param name="password">The password for the certificate.</param>
        /// <returns>A <see cref="X509Certificate2"/> containing the specified certificate.</returns>
        private static X509Certificate2 ReadCertificateFromResource(
            string resourceName,
            string password)
        {
            using (Stream certFile = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (BinaryReader certFileReader = new BinaryReader(certFile))
            {
                return new X509Certificate2(
                    certFileReader.ReadBytes((int)certFile.Length),
                    password,
                    X509KeyStorageFlags.PersistKeySet |
                    X509KeyStorageFlags.MachineKeySet);
            }
        }
    }
}
