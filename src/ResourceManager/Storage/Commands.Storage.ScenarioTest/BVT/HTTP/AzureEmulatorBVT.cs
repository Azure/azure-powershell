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
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.BVT.HTTP
{
    /// <summary>
    /// bvt tests using Azure Emulator and local development storage account
    /// </summary>
    [TestClass]
    class AzureEmulatorBVT : CLICommonBVT
    {
        private static string csRunPath = String.Empty;
        private static string storageCmd = "/devstore:";

        [ClassInitialize()]
        public static void AzureEmulatorBVTClassInitialize(TestContext testContext)
        {
            //first set the storage account
            //second init common bvt
            //third set storage context in powershell
            SetUpStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            CLICommonBVT.CLICommonBVTInitialize(testContext);
            PowerShellAgent.SetLocalStorageContext();
            StartStorageEmulator();
        }

        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void AzureEmulatorBVTCleanup()
        {
            StopStorageEmulator();
            CLICommonBVT.CLICommonBVTCleanup();
        }

        /// <summary>
        /// start azure storage emulator
        /// </summary>
        private static void StartStorageEmulator()
        {
            Test.Info("Start Azure Storage Emulator...");
            string cmd = "start";
            string csrunCmd = storageCmd + cmd;
            CsRun(csrunCmd);
        }

        /// <summary>
        /// stop storage emulator
        /// </summary>
        private static void StopStorageEmulator()
        {
            Test.Info("Stop Azure Storage Emulator...");
            string cmd = "shutdown";
            string csrunCmd = storageCmd + cmd;
            CsRun(csrunCmd);
        }

        /// <summary>
        /// run csrun command
        /// </summary>
        /// <param name="cmd">csrun commnd</param>
        private static void CsRun(string cmd)
        {
            //azure storage emulator settings
            string AzureEmulatorRegistryKey = @"SOFTWARE\Microsoft\Microsoft Azure Emulator";
            string AzureSdkInstallPathRegistryKeyValue = "InstallPath";
            string AzureEmulatorDirectoryName = "Emulator";
            string CsRunExe = "csrun.exe";

            if (String.IsNullOrEmpty(csRunPath))
            {
                var emulatorPath = Registry.GetValue(
                    Path.Combine(Registry.LocalMachine.Name, AzureEmulatorRegistryKey),
                    AzureSdkInstallPathRegistryKeyValue, null);

                if (emulatorPath == null)
                {
                    throw new ArgumentException("Azure Emulator is not installed");
                }

                string AzureEmulatorDirectory = Path.Combine((string)emulatorPath,
                        AzureEmulatorDirectoryName);
                csRunPath = Path.Combine(AzureEmulatorDirectory, CsRunExe);
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = csRunPath;
            startInfo.Arguments = cmd;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            int waitTimeOut = 10 * 60 * 1000; //ten minutes

            try
            {
                if (process.Start())
                {
                    process.WaitForExit(waitTimeOut);
                    Test.Info(process.StandardOutput.ReadToEnd());
                }
                else
                {
                    Test.AssertFail("Can not run csrun command to start/stop azure storage emulator");
                    throw new ArgumentException(String.Format("Can not run {0}", cmd));
                }
            }
            finally
            {
                if (process != null)
                {
                    process.Close();
                }
            }
        }

        [TestMethod()]
        [TestCategory(Tag.BVT)]
        public void MakeSureBvtUsingLocalContext()
        {
            string key = System.Environment.GetEnvironmentVariable(EnvKey);
            Test.Assert(string.IsNullOrEmpty(key), string.Format("env connection string {0} should be null or empty", key));
            Test.Assert(PowerShellAgent.Context != null, "PowerShell context should be not null when running bvt against local storage account");

            //check the container uri is valid for namekey context
            CloudBlobContainer retrievedContainer = CreateAndPsGetARandomContainer();
            string uri = retrievedContainer.Uri.ToString();
            string uriPrefix = "http://127.0.0.1";

            Test.Assert(uri.ToString().StartsWith(uriPrefix), string.Format("The prefix of container uri should be {0}, actually it's {1}", uriPrefix, uri));
        }
    }
}
