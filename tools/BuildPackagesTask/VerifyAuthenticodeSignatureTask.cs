namespace Microsoft.Azure.Build.Tasks
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;

    /// <summary>
    /// Authenticode Signature task
    /// Flow:
    ///         FilesToCheckAuthCodeSignature:
    ///             Support 1 or many files provided
    ///         ProbingDirectory:
    ///             When provided value to this property, we will ignore FilesToCheckAuthCodeSignature property
    ///         FileFilterPattern:
    ///             This is applicable when probingDirectory is specified and you want to filter selected group of files from contents of the directory (recurrsively searched)
    ///             E.g. if FileFilterPattern specified = "microsoft.*.dll;system.*.dll;*.exe"
    ///             We will first find all the files microsoft*.dll, then system.*.dll and finally *.exe
    ///             All three set of search results will be combined and will then be verified for Authenticode Signature
    /// </summary>
    public class VerifyAuthenticodeSignatureTask : Task
    {
        /// <summary>
        /// Gets or sets the assembly on which authenticode signature verification is performed.
        /// </summary>        
        //public ITaskItem SignedFilePath { get; set; }

        /// <summary>
        /// Gets or sets list of files/assemblies for which authenticode signature verification is performed
        /// If ProbingDirectory is specified, FilesToCheckAuthCodeSignature collection is ignored
        /// </summary>
        public ITaskItem[] FilesToCheckAuthCodeSignature { get; set; }

        /// <summary>
        /// Specify Directory path under which all the files will be verified for Authenticode Signature
        /// 
        /// </summary>
        public string ProbingDirectory { get; set; }

        /// <summary>
        /// Specifiy file filter pattern (e.g. *.dll,*.ps1)
        /// In above example, we will first find all dll files, then combine with all the ps1 files that are found
        /// </summary>
        public string FileFilterPattern { get; set; }
        
        /// <summary>
        /// Returns True if any error occurs, False if no AutheticodeSignature occured
        /// </summary>
        [Output]
        public bool AuthCodeSignTaskErrorsDetected { get; private set; }


        private List<string> ErrorList { get; set; }
        private bool IsFileSigned { get; set; }

        /// <summary>
        /// Execute VerifyAuthenticodeSignature task
        /// </summary>
        /// <returns>True: if files are authenticode signed, False: if any of the files provided are not authenticode signed</returns>
        public override bool Execute()
        {
            ErrorList = new List<string>();
            AuthCodeSignTaskErrorsDetected = false;
            IsFileSigned = true;

            string[] filesToCheck = GetFilesToVerifyAuthCodeSignature();
            IsFileSigned = VerifyAllFiles(filesToCheck);

            if (ErrorList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                IsFileSigned = false;
                AuthCodeSignTaskErrorsDetected = true;

                ErrorList.ForEach((err) => sb.AppendLine(err));

                Log.LogError("Errors detected during AuthenticodeSignature Verification");
                Log.LogError(sb.ToString());
            }
            
            return IsFileSigned;    
        }

        /// <summary>
        /// Get set of files that will ultimately be verified for AuthCode Signature
        /// If we find user has sepcified a probing directory, we will give priority to it and will ignore FilesToCheckAuthCodeSignature collection
        /// </summary>
        /// <returns></returns>
        private string[] GetFilesToVerifyAuthCodeSignature()
        {
            bool isProbingDirValid = false;
            string[] filesToCheck = null;

            //First priority to probing directory
            if (!string.IsNullOrEmpty(ProbingDirectory))
            {
                if (Directory.Exists(ProbingDirectory))
                {
                    isProbingDirValid = true;
                    filesToCheck = ApplyFileFilter(ProbingDirectory);
                }
            }

            //if Probing directory is not specified then we honor all the files provided
            if ((isProbingDirValid == false) && (FilesToCheckAuthCodeSignature != null))
            {
                if (FilesToCheckAuthCodeSignature.Length > 0)
                {
                    filesToCheck = FilesToCheckAuthCodeSignature.Select<ITaskItem, string>((item) => item.ItemSpec).ToArray<string>();
                }
            }

            return filesToCheck;
        }

        /// <summary>
        /// Apply filters to filter list of files that will be checked for authenticode signed
        /// </summary>
        /// <param name="dirToProbeForFiles"></param>
        /// <returns></returns>
        private string[] ApplyFileFilter(string dirToProbeForFiles)
        {
            string[] filteredFiles = null;
            IEnumerable<string> startupCollection = new string[] { "" };
            IEnumerable<string> files = startupCollection.Except<string>(new string[] { "" });  //we do this to construct an empty IEnumerable (TODO: is there a better way)

            if (string.IsNullOrEmpty(FileFilterPattern))
            {
                files = Directory.EnumerateFiles(dirToProbeForFiles, "*", SearchOption.AllDirectories);
            }
            else
            {
                string[] listOfFilters = FileFilterPattern.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string filter in listOfFilters)
                {
                    files = files.Concat<string>(Directory.EnumerateFiles(dirToProbeForFiles, filter, SearchOption.AllDirectories));
                }
            }

            if (files.Any<string>() || files != null)
                filteredFiles = files.ToArray<string>();

            return filteredFiles;
        }

        /// <summary>
        /// Verify if file is Authenticode Signed using PS cmdLet Get-AuthenticodeSignature
        /// </summary>
        /// <returns>True: If signature status is Valid, False: if signature status is other than Valid</returns>
        private bool VerifyAllFiles(string[] signedFilesArray)
        {
            bool isSigned = true;
            if (signedFilesArray.Length > 0)
            {
                bool authSigned = false;
                for (int i = 0; i <= signedFilesArray.Length - 1; i++)
                {
                    authSigned = VerifyAuthenticodeSignature(signedFilesArray[i]);
                    isSigned = isSigned && authSigned;
                }
            }

            return isSigned;
        }

        /// <summary>
        /// Check for Authenticode Signature
        /// </summary>
        /// <param name="providedFilePath"></param>
        /// <returns></returns>
        private bool VerifyAuthenticodeSignature(string providedFilePath)
        {
            bool isSigned = true;
            string fileName = Path.GetFileName(providedFilePath);
            string calculatedFullPath = Path.GetFullPath(providedFilePath);
            
            if (File.Exists(calculatedFullPath))
            {
                Log.LogMessage(string.Format("Verifying file '{0}'", calculatedFullPath));
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
                            ErrorList.Add(string.Format("!!!AuthenticodeSignature status is '{0}' for file '{1}' !!!", s.Status.ToString(), calculatedFullPath));
                        }
                        else
                        {
                            Log.LogMessage(string.Format("!!!AuthenticodeSignature status is '{0}' for file '{1}' !!!", s.Status.ToString(), calculatedFullPath));
                        }
                        break;
                    }
                }
            }
            else
            {
                ErrorList.Add(string.Format("File '{0}' does not exist. Unable to verify AuthenticodeSignature", calculatedFullPath));
                isSigned = false;
            }

            return isSigned;
        }
    }
}