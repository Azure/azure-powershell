﻿namespace PowerShellSetup.Tests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyMsiExecExists()
        {
            ProcessStartInfo psi = GetInitializedPSI();
            psi.FileName = "Msiexec.exe";
            psi.Arguments = "/qn /x:1234";

            this.ExecuteShellCmd(psi, out _procOutput, out _procErr);
            Assert.NotEmpty(_procOutput);
        }

        [Fact]
        [Trait(Category.SignedBuild, Category.BVT)]
        public void VerifyFilesAreSigned()
        {
            List<string> expectedSignatureAlgos = new List<string>() { "sha1RSA", "sha256RSA" };
            //string msiContentsDir = this.ExtractMsiContents(out _procErr);
            string msiContentsDir = @"E:\MyFork\azure-powershell\setup\PowerShellSetup.Test\bin\Debug\msiContents";
            Assert.True(Directory.Exists(msiContentsDir));
            Assert.True(string.IsNullOrEmpty(_procErr));

            IEnumerable<string>msiFiles = Directory.EnumerateFiles(msiContentsDir, "*", SearchOption.AllDirectories);
            //Ignore Newtonsoft, .xml, .msi (need to find out why unsigned msi get's packaged inside the MSI)
            IEnumerable<string> exceptionFiles = Directory.EnumerateFiles(msiContentsDir, "*.xml", SearchOption.AllDirectories)
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "newtonsoft*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "automapper*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "security*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "bouncy*.dll", SearchOption.AllDirectories))
                .Union<string>(Directory.EnumerateFiles(msiContentsDir, "*.msi", SearchOption.AllDirectories));

            Assert.NotNull(msiFiles);
            IEnumerable<string> filesToVerify = msiFiles.Except<string>(exceptionFiles);

            List<string> noXmlFiles = filesToVerify.Where<string>((fl) => fl.EndsWith(".xml")).ToList<string>();
            TestLog.WriteLine("Verifying no .xml files are in the verify list of files");
            Assert.True(noXmlFiles.Count == 0);

            List<string> noNewtonsoftFiles = filesToVerify.Where<string>((fl) => fl.Contains("newtonsoft")).ToList<string>();
            TestLog.WriteLine("Verifying no 'Newtonsoft*.dll' files are in the verify list of files");
            Assert.True(noNewtonsoftFiles.Count == 0);

            List<string> noMsiFiles = filesToVerify.Where<string>((fl) => fl.EndsWith(".msi")).ToList<string>();
            TestLog.WriteLine("Verifying no '*.msi' files are in the verify list of files");
            Assert.True(noMsiFiles.Count == 0);


            List<string> msiFileList = filesToVerify.ToList<string>();
            Assert.True(msiFileList.Count > 0);
            List<string> unsignedFiles = GetUnsignedFiles(msiFileList, expectedSignatureAlgos);

            foreach(string unsigFile in unsignedFiles)
            {
                TestLog.WriteLine(unsigFile);
            }

            Assert.True(unsignedFiles.Count == 0);
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyNoJavaScriptFiles()
        {
            string procErr = string.Empty;
            string msiContentsDirPath = ExtractMsiContents(out procErr);
            IEnumerable<string> msiFiles = Directory.EnumerateFiles(msiContentsDirPath, "*.js", SearchOption.AllDirectories);

            Assert.True(msiFiles.Count<string>() == 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyNoJsonFiles()
        {
            string procErr = string.Empty;
            string msiContentsDirPath = ExtractMsiContents(out procErr);
            IEnumerable<string> msiFiles = Directory.EnumerateFiles(msiContentsDirPath, "*.json", SearchOption.AllDirectories);

            Assert.True(msiFiles.Count<string>() == 0);
        }

        #region Private Functions
        private List<string> GetUnsignedFiles(List<string> signedFiles, List<string> expectedAlgorithmList)
        {
            List<string> unsignedFiles = new List<string>();

            Parallel.ForEach<string>(signedFiles, (providedFilePath) =>
            {
                bool isSigned = true;
                string fileName = Path.GetFileName(providedFilePath);
                string calculatedFullPath = Path.GetFullPath(providedFilePath);

                if (File.Exists(calculatedFullPath))
                {
                    using (PowerShell ps = PowerShell.Create())
                    {
                        ps.AddCommand("Get-AuthenticodeSignature", true);
                        ps.AddParameter("FilePath", calculatedFullPath);
                        var cmdLetResults = ps.Invoke();

                        foreach (PSObject result in cmdLetResults)
                        {
                            Signature s = (Signature)result.BaseObject;
                            isSigned = s.Status.Equals(SignatureStatus.Valid);
                            string unsignedFileStatusFormat = "Signed by {0} algorithm ::: {1}";
                            string unsignFileStatus = string.Empty;
                            if (isSigned == true)
                            {
                                string friendlyAlgorithmName = s.SignerCertificate.SignatureAlgorithm.FriendlyName;
                                string match = expectedAlgorithmList.Find((pn) => pn.Equals(friendlyAlgorithmName, System.StringComparison.OrdinalIgnoreCase));
                                if (string.IsNullOrEmpty(match))
                                {
                                    unsignFileStatus = string.Format(unsignedFileStatusFormat, friendlyAlgorithmName, calculatedFullPath);
                                    unsignedFiles.Add(unsignFileStatus);
                                }
                            }
                            else
                            {
                                unsignFileStatus = string.Format(unsignedFileStatusFormat, "NOT SIGNED", calculatedFullPath);
                                unsignedFiles.Add(unsignFileStatus);
                            }
                        }
                    }
                }
            });

            return unsignedFiles;
        }
        #endregion
    }
}
