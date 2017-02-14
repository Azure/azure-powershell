namespace PowerShellSetup.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Set of tests to run against MSI
    /// These set of tests are especially for scenario like:
    ///     1) Layout errors, things getting copied to the wrong location
    ///     2) Checking if files in the MSI including the MSI are signed
    ///     3) Checking if files included in MSI uses right signing alogirthm
    /// 
    /// </summary>
    public class MsiLayoutTests: MsiTestBase
    {
        const string MSI_NAME = "AzurePowerShell.msi";
        const string MSI_EXTRACT_DIR_NAME = "msiContents";
        string _procOutput;
        string _procErr;

        public MsiLayoutTests(ITestOutputHelper testOutput) : base(testOutput)
        {
            _procOutput = string.Empty;
            _procErr = string.Empty;
        }

        [Fact]
        [Trait("AcceptanceType", "CheckIn")]
        public void VerifyMsiExecExists()
        {
            ProcessStartInfo psi = GetInitializedPSI();
            psi.FileName = "Msiexec.exe";
            psi.Arguments = "/qn /x:1234";

            this.ExecuteShellCmd(psi, out _procOutput, out _procErr);
            Assert.NotEmpty(_procOutput);
        }
        
        [Fact]
        [Trait("AcceptanceType", "CheckIn")]
        public void VerifyNoJavaScriptFiles()
        {
            string procErr = string.Empty;
            string msiContentsDirPath = ExtractMsiContents(out procErr);
            IEnumerable<string> msiFiles = Directory.EnumerateFiles(msiContentsDirPath, "*.js", SearchOption.AllDirectories);
            TestLog.WriteLine("Expecting no *.js files in MSI");            
            foreach (string unsigFile in msiFiles)
            {
                TestLog.WriteLine(unsigFile);
            }
            Assert.Equal(0, msiFiles.Count<string>());
        }

        [Fact]
        [Trait("AcceptanceType", "CheckIn")]
        public void VerifyNoJsonFiles()
        {
            string procErr = string.Empty;
            string msiContentsDirPath = ExtractMsiContents(out procErr);
            IEnumerable<string> msiFiles = Directory.EnumerateFiles(msiContentsDirPath, "*.json", SearchOption.AllDirectories);
            TestLog.WriteLine("Expecting no *.json files in MSI");
            foreach (string unsigFile in msiFiles)
            {
                TestLog.WriteLine(unsigFile);
            }
            Assert.Equal(0, msiFiles.Count<string>());
        }
        
        [Fact]
        [Trait("SignedBuild", "BVT")]
        public void VerifyFilesAreSigned()
        {
            string SHA1 = "sha1RSA";
            string SHA2 = "sha256RSA";

            List<string> expectedSignatureAlgos = new List<string>() { SHA1, SHA2 };
            string msiContentsDir = this.ExtractMsiContents(out _procErr);
            Assert.True(Directory.Exists(msiContentsDir));
            Assert.True(string.IsNullOrEmpty(_procErr));

            IEnumerable<string> msiFiles = Directory.EnumerateFiles(msiContentsDir, "*", SearchOption.AllDirectories);
            //Ignore Newtonsoft, .xml, .msi (need to find out why unsigned msi get's packaged inside the MSI)
            IEnumerable<string> exceptionFiles = Directory.EnumerateFiles(msiContentsDir, "*.xml", SearchOption.AllDirectories)
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "newtonsoft*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "automapper*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "security*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "bouncy*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "*.psd1", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "*.msi", SearchOption.AllDirectories));

            Assert.NotNull(msiFiles);
            IEnumerable<string> filesToVerify = msiFiles.Except<string>(exceptionFiles);

            // Make sure filesToVerify do not have any of the files that are either external to MS 
            // or are not signed (which are expected not to be signed eg. psd1 files)
            List<string> noXmlFiles = filesToVerify.Where<string>((fl) => fl.EndsWith(".xml")).ToList<string>();
            //TestLog.WriteLine("Verifying no .xml files are in the verify list of files");
            Assert.True(noXmlFiles.Count == 0);

            List<string> noNewtonsoftFiles = filesToVerify.Where<string>((fl) => fl.Contains("newtonsoft")).ToList<string>();
            //TestLog.WriteLine("Verifying no 'Newtonsoft*.dll' files are in the verify list of files");
            Assert.True(noNewtonsoftFiles.Count == 0);

            List<string> noMsiFiles = filesToVerify.Where<string>((fl) => fl.EndsWith(".msi")).ToList<string>();
            //TestLog.WriteLine("Verifying no '*.msi' files are in the verify list of files");
            Assert.True(noMsiFiles.Count == 0);

            List<string> noPsd1Files = filesToVerify.Where<string>((fl) => fl.EndsWith(".psd1")).ToList<string>();
            //TestLog.WriteLine("Verifying no '*.psd1' files are in the verify list of files");
            Assert.True(noPsd1Files.Count == 0);

            // Now extract each category of files and verify if they matched to the algorithm they are expected to be signed
            IEnumerable<string> dllFiles = filesToVerify.Where<string>((fl) => fl.EndsWith(".dll")).ToList<string>();
            IEnumerable<string> scriptFiles = filesToVerify.Where<string>((fl) => fl.EndsWith(".ps1"))
                .Union<string>(filesToVerify.Where<string>((fl) => fl.EndsWith(".psm1")))
                .Union<string>(filesToVerify.Where<string>((fl) => fl.EndsWith(".ps1xml")));

            TestLog.WriteLine("Verify number of dlls, script files match");
            Assert.Equal((dllFiles.Count() + scriptFiles.Count()), filesToVerify.Count());

            List<string> unsignedDlls = GetUnsignedFiles(dllFiles, expectedSignatureAlgos);
            TestLog.WriteLine("Verifying if DLLs are properly signed");
            unsignedDlls.ForEach((unsigDll) => TestLog.WriteLine(unsigDll));
            Assert.Equal(unsignedDlls.Count, 0);

            List<string> unsignedScripts = GetUnsignedFiles(scriptFiles, SHA2);
            TestLog.WriteLine("Verifying if SCRIPTS are properly signed");
            unsignedScripts.ForEach((unsigScript) => TestLog.WriteLine(unsigScript));
            Assert.Equal(unsignedScripts.Count, 0);

            // We do this because, we sign MSI as SHA2 with SHA1 hash.
            // Verifying msi under windows --> Rightclick --> Properties will show SHA1
            // Verifying msi with Get-AuthenticodeSignature will return as SHA2
            List<string> unsignedMsi = GetUnsignedFiles(new List<string>() { this.GetAzurePSMsiPath() }, SHA2);
            TestLog.WriteLine("Verifying if MSI is properly signed");
            unsignedMsi.ForEach((unsigMsi) => TestLog.WriteLine(unsigMsi));
            Assert.Equal(unsignedMsi.Count, 0);
        }

        #region Private Functions
        private List<string> GetUnsignedFiles(IEnumerable<string> signedFiles, string expectedAlgorithm)
        {
            List<string> unsignedFiles = new List<string>();
            string unsignedFileStatusFormat = "Expected signature '{0}', Actual '{1}' signature ::: {2}";

            Parallel.ForEach<string>(signedFiles, (providedFilePath) =>
            {
                string sigAlgo = GetFileSignature(providedFilePath);

                if(string.IsNullOrEmpty(sigAlgo))
                {
                    unsignedFiles.Add(string.Format(unsignedFileStatusFormat, expectedAlgorithm, sigAlgo, providedFilePath));
                }
                else if(!sigAlgo.Equals(expectedAlgorithm, StringComparison.OrdinalIgnoreCase))
                {
                    unsignedFiles.Add(string.Format(unsignedFileStatusFormat, expectedAlgorithm, sigAlgo, providedFilePath));
                }
            });

            return unsignedFiles;
        }

        private List<string> GetUnsignedFiles(IEnumerable<string> signedFiles, List<string> expectedSignatureAlgorithmList)
        {
            List<string> unsignedFiles = new List<string>();
            string algoList = string.Join("/", expectedSignatureAlgorithmList);
            string unsignedFileStatusFormat = "Expected signature '{0}', Actual '{1}' signature ::: {2}";

            Parallel.ForEach<string>(signedFiles, (providedFilePath) =>
            {
                string sigAlgo = GetFileSignature(providedFilePath);

                if (string.IsNullOrEmpty(sigAlgo))
                {
                    unsignedFiles.Add(string.Format(unsignedFileStatusFormat, algoList, sigAlgo, providedFilePath));
                }
                else 
                {
                    string match = expectedSignatureAlgorithmList.Find((pn) => pn.Equals(sigAlgo, System.StringComparison.OrdinalIgnoreCase));
                    if (string.IsNullOrEmpty(match))
                    {
                        unsignedFiles.Add(string.Format(unsignedFileStatusFormat, algoList, sigAlgo, providedFilePath));
                    }
                }
            });

            return unsignedFiles;
        }

        /// <summary>
        /// Checks if a file is signed and returns the friendly alogrithm name of the file
        /// Returns the friendly algorithm name of a file
        /// </summary>
        /// <param name="providedFilePath">Full file path for which Signature has to be verified</param>
        /// <returns>Friendly Algorithm name, String.empty if not signed</returns>
        private string GetFileSignature(string providedFilePath)
        {
            string friendlyAlgorithmName = string.Empty;
            if (File.Exists(providedFilePath))
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddCommand("Get-AuthenticodeSignature", true);
                    ps.AddParameter("FilePath", providedFilePath);
                    var cmdLetResults = ps.Invoke();

                    foreach (PSObject result in cmdLetResults)
                    {
                        Signature sig = (Signature)result.BaseObject;
                        if(sig.Status.Equals(SignatureStatus.Valid))
                        {
                            friendlyAlgorithmName = sig.SignerCertificate.SignatureAlgorithm.FriendlyName;
                        }
                        break;
                    }
                }
            }

            return friendlyAlgorithmName;
        }

        //private void CheckFileSignature()
        //{
        //    bool isSigned = true;
        //    string fileName = Path.GetFileName(providedFilePath);
        //    string calculatedFullPath = Path.GetFullPath(providedFilePath);

        //    if (File.Exists(calculatedFullPath))
        //    {
        //        using (PowerShell ps = PowerShell.Create())
        //        {
        //            ps.AddCommand("Get-AuthenticodeSignature", true);
        //            ps.AddParameter("FilePath", calculatedFullPath);
        //            var cmdLetResults = ps.Invoke();

        //            foreach (PSObject result in cmdLetResults)
        //            {
        //                Signature s = (Signature)result.BaseObject;
        //                isSigned = s.Status.Equals(SignatureStatus.Valid);
        //                string unsignedFileStatusFormat = "Signed by {0} algorithm ::: {1}";
        //                string unsignFileStatus = string.Empty;
        //                if (isSigned == true)
        //                {
        //                    string friendlyAlgorithmName = s.SignerCertificate.SignatureAlgorithm.FriendlyName;
        //                    string match = expectedAlgorithmList.Find((pn) => pn.Equals(friendlyAlgorithmName, System.StringComparison.OrdinalIgnoreCase));
        //                    if (string.IsNullOrEmpty(match))
        //                    {
        //                        unsignFileStatus = string.Format(unsignedFileStatusFormat, friendlyAlgorithmName, calculatedFullPath);
        //                        unsignedFiles.Add(unsignFileStatus);
        //                    }
        //                }
        //                else
        //                {
        //                    unsignFileStatus = string.Format(unsignedFileStatusFormat, "NOT SIGNED", calculatedFullPath);
        //                    unsignedFiles.Add(unsignFileStatus);
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
