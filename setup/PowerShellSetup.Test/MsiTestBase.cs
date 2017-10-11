// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace PowerShellSetup.Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using Xunit.Abstractions;

    public class MsiTestBase
    {
        const string MSI_NAME = "AzurePowerShell.msi";
        const string MSI_EXTRACT_DIR_NAME = "msiContents";
        const string MSIEXEC_NAME = "msiexec.exe";
        const int procTimeoutSeconds = 5000;
        private ITestOutputHelper _testHelperOutput;


        protected ITestOutputHelper TestLog
        {
            get
            {
                return _testHelperOutput;
            }
        }

        public MsiTestBase(ITestOutputHelper testOutput)
        {
            _testHelperOutput = testOutput;
        }


        protected void ExecuteShellCmd(ProcessStartInfo psi, out string procOutput, out string procErr)
        {
            procOutput = string.Empty;
            procErr = string.Empty;
            Process proc = Process.Start(psi);

            while (!proc.StandardOutput.EndOfStream)
            {
                procOutput = proc.StandardOutput.ReadToEnd();
                procOutput = procOutput.Replace("\0", string.Empty);
            }

            while (!proc.StandardError.EndOfStream)
            {
                procErr = proc.StandardError.ReadToEnd();
                procErr = procErr.Replace("\0", string.Empty);
            }

            proc.WaitForExit(procTimeoutSeconds);
        }

        protected ProcessStartInfo GetInitializedPSI()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            return psi;
        }

        protected void ExtractMsiContents(string msiFullPath, string msiContentExtractDirPath, out string procErr)
        {
            string procOutput = string.Empty;
            ProcessStartInfo psi = GetInitializedPSI();
            psi.FileName = MSIEXEC_NAME;
            psi.Arguments = string.Format("/a {0} /qn TargetDir={1}", msiFullPath, msiContentExtractDirPath);

            ExecuteShellCmd(psi, out procOutput, out procErr);

            if(string.IsNullOrEmpty(procOutput))
            {
                TestLog.WriteLine("MSI extract output: {0}", procOutput);
            }
        }

        /// <summary>
        /// Extracts contents of MSI to a predefined MsiContents directory
        /// </summary>
        /// <param name="procErr">Error stream contents occured during MSI extraction</param>
        /// <returns>Msi contents extracted directory path</returns>
        protected string ExtractMsiContents(out string procErr)
        {
            string msiFullPath = GetAzurePSMsiPath();
            string msiContentsPath = Path.Combine(GetAzurePSMsiDirectory(), MSI_EXTRACT_DIR_NAME);

            ExtractMsiContents(msiFullPath, msiContentsPath, out procErr);

            return msiContentsPath;
        }

        protected string GetAzurePSMsiPath()
        {
            //On CI machine, we first check the signed MSI path, if it does not exist
            //Then we get an alternatve path of the MSI from the test output directory.
            string msiFullPath = string.Empty;
            string signedPath = Environment.GetEnvironmentVariable("SignedMsiDir");    //This env. variable is set during build just for test purpose
            if(!string.IsNullOrEmpty(signedPath))
            {
                msiFullPath = Path.Combine(signedPath, MSI_NAME);
            }
            
            if (!File.Exists(msiFullPath))
            {
                string msiDir = GetAzurePSMsiDirectory();
                msiFullPath = Path.Combine(msiDir, MSI_NAME);
            }

            TestLog.WriteLine(string.Format("Msi Path to be used for testing: {0}", msiFullPath));
            return msiFullPath;
        }
        
        protected string GetAzurePSMsiDirectory()
        {
            var testLoc = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codebasePath = Uri.UnescapeDataString(testLoc.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codebasePath);
            return dirPath;
        }
    }

    

}
