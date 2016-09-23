namespace Microsoft.Azure.Build.Tasks
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Collections.Generic;
    using System.Text;

    public class VerifyAuthenticodeSignatureTask : Task
    {
        /// <summary>
        /// Gets or sets the assembly on which authenticode signature verification is performed.
        /// </summary>        
        public ITaskItem SignedFilePath { get; set; }
        
        /// <summary>
        /// Gets or sets list of files/assemblies for which authenticode signature verification is performed
        /// </summary>
        public ITaskItem[] SignedFiles { get; set; }

        /// <summary>
        /// Returns True if any error occurs, False if no AutheticodeSignature occured
        /// </summary>
        [Output]
        public bool AuthCodeSignTaskErrorsDetected { get; private set; }


        private List<string> ErrorList { get; set; }
        private bool IsFileSigned { get; set; }


        public override bool Execute()
        {
            ErrorList = new List<string>();
            AuthCodeSignTaskErrorsDetected = false;
            IsFileSigned = true;

            if (SignedFilePath != null)
            {
                IsFileSigned = VerifyAuthenticodeSignature(SignedFilePath.ItemSpec);
            }

            if(SignedFiles != null)
            {
                IsFileSigned = VerifyAllFiles(SignedFiles);
            }

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
        /// Verify if file is Authenticode Signed using PS cmdLet Get-AuthenticodeSignature
        /// </summary>
        /// <returns>True: If signature status is Valid, False: if signature status is other than Valid</returns>
        private bool VerifyAllFiles(ITaskItem[] signedFilesArray)
        {
            bool isSigned = true;
            if (signedFilesArray.Length > 0)
            {
                bool authSigned = false;
                for (int i = 0; i <= signedFilesArray.Length - 1; i++)
                {
                    authSigned = VerifyAuthenticodeSignature(signedFilesArray[i].ItemSpec);
                    isSigned = isSigned && authSigned;
                }
            }

            return isSigned;
        }

        private bool VerifyAuthenticodeSignature(string providedFilePath)
        {
            bool isSigned = true;
            string fileName = Path.GetFileName(providedFilePath);
            string calculatedFullPath = Path.GetFullPath(providedFilePath);

            //if (IsMicrosoftShippedFile(fileName))
            //{
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
            //}

            return isSigned;
        }

        /// <summary>
        /// This function will check validity of Digital Signature
        /// </summary>
        /// <returns>True: If Certificate is valid, False:If Certificate is invalid or expired</returns>
        private bool CheckCertificate()
        {
            string assemblyPath = SignedFilePath.ItemSpec;
            string assemblyFullPath = Path.GetFileName(assemblyPath);
            string assemblyName = Path.GetFileName(assemblyFullPath);

            AuthCodeSignTaskErrorsDetected = false;
            try
            {
                Log.LogMessage("Verifying Authenticode Signature for '{0}' - '{1}'", assemblyFullPath, assemblyPath);
                X509Certificate cert = X509Certificate.CreateFromSignedFile(assemblyPath);
                if ((assemblyFullPath.ToLower().StartsWith("microsoft")) || (assemblyFullPath.ToLower().StartsWith("system")))
                {
                    if (cert.Issuer.ToLower().Contains("microsoft"))
                    {
                        // Verify if the certificate by which it was signed is not expired
                        DateTime notAfter = DateTime.Parse(cert.GetExpirationDateString());
                        if (notAfter < DateTime.Today)
                            throw new System.Security.Cryptography.CryptographicException("'{0}' has been signed with an expired certificate", assemblyPath);

                        Log.LogMessage("Verified: '{0}' has been signed using valid cerificate issued by Microsoft", assemblyFullPath);
                    }
                    else
                    {
                        throw new System.Security.Cryptography.CryptographicUnexpectedOperationException(string.Format("'{0}' - '{1}' assembly is not signed using Microsoft certificate", assemblyFullPath, assemblyPath));
                    }
                }

                return true;
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                Log.LogError(string.Format("'{0}' is not authenticode signed..... exiting build", assemblyPath));
                AuthCodeSignTaskErrorsDetected = true;
                return false;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                AuthCodeSignTaskErrorsDetected = true;
                return false;
            }
        }

        private bool IsMicrosoftShippedFile(string fileName)
        {
            return ((fileName.ToLower().StartsWith("microsoft")) || (fileName.ToLower().StartsWith("system")));
        }
    }
}