namespace PowerShellSetup.Tests
{
    using Microsoft.Azure.Test;
    //using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Microsoft.Azure.Management.Resources;
    using System.Diagnostics;
    using System;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    //using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    /// <summary>
    /// Launch Package Manager Console and execute: Update-Pacakge -reinstall
    /// This will add all the required references to the test project
    /// 
    /// Project References to be added
    ///     1) src\Common\Commands.Common.Authentication\Commands.Common.Authentication.csproj
    ///     2) src\Common\Commands.ResourceManager.Common\Commands.ResourceManager.Common.csproj
    ///     3) src\Common\Commands.ScenarioTests.ResourceManager.Common\Commands.ScenarioTests.ResourceManager.Common.csproj
    ///     
    /// 
    /// </summary>
    public class MsiLayoutTests
    {
        string procOutput = string.Empty;
        string procErr = string.Empty;

        public MsiLayoutTests()
        {
            procOutput = string.Empty;
            procErr = string.Empty;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyMsiExecExists()
        {
            ProcessStartInfo psi = GetInitializedPSI();
            psi.Arguments = "/qr /x:1234";

            ExecuteShellCmd(psi, out procOutput, out procErr);
            Assert.NotEmpty(procOutput);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyFilesAreSigned()
        {
            var testLoc = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codebasePath = Uri.UnescapeDataString(testLoc.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codebasePath);
            string msiFullPath = Path.Combine(dirPath, "AzurePowerShell.msi");
            string msiContentsDirPath = Path.Combine(dirPath, "msiContents");
            Assert.True(File.Exists(msiFullPath));

            ProcessStartInfo psi = GetInitializedPSI();
            
            psi.Arguments = string.Format("/a {0} /qn TargetDir={1}", msiFullPath, msiContentsDirPath);
            ExecuteShellCmd(psi, out procOutput, out procErr);
            Assert.True(string.IsNullOrEmpty(procErr));

            IEnumerable<string>msiFiles = Directory.EnumerateFiles(msiContentsDirPath, "*", SearchOption.AllDirectories);
            Assert.NotNull(msiFiles);
            List<string> msiFileList = msiFiles.ToList<string>();
            Assert.True(msiFileList.Count > 0);
            List<string> unsignedFiles = GetUnsignedFiles(msiFileList);

            Assert.True(unsignedFiles.Count == 0);
        }

        private void ExecuteShellCmd(ProcessStartInfo psi, out string procOutput, out string procErr)
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

            proc.WaitForExit(5000);
        }

        private ProcessStartInfo GetInitializedPSI()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.FileName = "Msiexec.exe";
            return psi;
        }

        private List<string> GetUnsignedFiles(List<string> signedFiles)
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
                            if (isSigned == false)
                            {
                                unsignedFiles.Add(providedFilePath);
                            }
                        }
                    }
                }
            });

            return unsignedFiles;
        }
    }
}
