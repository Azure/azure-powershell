namespace PowerShellSetup.Tests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;


    /// <summary>
    /// Set of tests to run against signed MSI
    /// These set of tests are especially for scenario like:
    ///     1) Layout errors, things getting copied to the wrong location
    ///     2) Checking if files in the MSI including the MSI are signed
    ///     3) 
    /// 
    /// </summary>
    public class MsiLayoutTests: MsiTestBase
    {
        const string MSI_NAME = "AzurePowerShell.msi";
        const string MSI_EXTRACT_DIR_NAME = "msiContents";
        string _procOutput;
        string _procErr;

        //ITestOutputHelper xunitTestOutput;

        public MsiLayoutTests(ITestOutputHelper testOutput) : base(testOutput)
        {
            _procOutput = string.Empty;
            _procErr = string.Empty;
            //xunitTestOutput = testOutput;
        }

        [Fact]
        [Trait(Category.SignedBuild, Category.BVT)]
        public void VerifyMsiExecExists()
        {
            ProcessStartInfo psi = GetInitializedPSI();
            psi.FileName = "Msiexec.exe";
            psi.Arguments = "/qr /x:1234";

            this.ExecuteShellCmd(psi, out _procOutput, out _procErr);
            Assert.NotEmpty(_procOutput);
        }

        [Fact]
        [Trait(Category.SignedBuild, Category.BVT)]
        public void VerifyFilesAreSigned()
        {
            List<string> expectedSignatureAlgos = new List<string>() { "sha1RSA", "sha2RSA" };
            //var testLoc = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            //var codebasePath = Uri.UnescapeDataString(testLoc.AbsolutePath);
            //var dirPath = Path.GetDirectoryName(codebasePath);
            //string msiFullPath = Path.Combine(dirPath, "AzurePowerShell.msi");
            //string msiFullPath = GetMsiDirectory();
            //string msiContentsDirPath = Path.Combine(dirPath, MSI_EXTRACT_DIR_NAME);
            //Assert.True(File.Exists(msiFullPath));
            
            string msiContentsDir = this.ExtractMsiContents(out _procErr);
            Assert.True(Directory.Exists(msiContentsDir));
            Assert.True(string.IsNullOrEmpty(_procErr));

            IEnumerable<string>msiFiles = Directory.EnumerateFiles(msiContentsDir, "*", SearchOption.AllDirectories);
            Assert.NotNull(msiFiles);
            List<string> msiFileList = msiFiles.ToList<string>();
            Assert.True(msiFileList.Count > 0);
            List<string> unsignedFiles = GetUnsignedFiles(msiFileList, expectedSignatureAlgos);

            foreach(string unsigFile in unsignedFiles)
            {
                TestLog.WriteLine(unsigFile);
            }

            Assert.True(unsignedFiles.Count == 0);
        }

        //private void ExecuteShellCmd(ProcessStartInfo psi, out string procOutput, out string procErr)
        //{
        //    procOutput = string.Empty;
        //    procErr = string.Empty;
        //    Process proc = Process.Start(psi);
            
        //    while (!proc.StandardOutput.EndOfStream)
        //    {
        //        procOutput = proc.StandardOutput.ReadToEnd();
        //        procOutput = procOutput.Replace("\0", string.Empty);
        //    }

        //    while (!proc.StandardError.EndOfStream)
        //    {
        //        procErr = proc.StandardError.ReadToEnd();
        //        procErr = procErr.Replace("\0", string.Empty);
        //    }

        //    proc.WaitForExit(5000);
        //}

        //private ProcessStartInfo GetInitializedPSI()
        //{
        //    ProcessStartInfo psi = new ProcessStartInfo();
        //    psi.RedirectStandardError = true;
        //    psi.RedirectStandardInput = true;
        //    psi.RedirectStandardOutput = true;
        //    psi.UseShellExecute = false;
        //    psi.CreateNoWindow = true;
        //    return psi;
        //}

        private List<string> GetUnsignedFiles(List<string> signedFiles, List<string>expectedAlgorithmList)
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
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyNoJavaScriptFiles()
        {
            string procErr = string.Empty;
            string msiContentsDirPath = ExtractMsiContents(out procErr);
            IEnumerable<string> msiFiles = Directory.EnumerateFiles(msiContentsDirPath, "*.js", SearchOption.AllDirectories);

            Assert.True(msiFiles.Count<string>() == 0);
        }
    }
}
