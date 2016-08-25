namespace Microsoft.Azure.Build.Tasks
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;

    public class VerifyAuthenticodeSignatureTask : Task
    {
        /// <summary>
        /// Gets or sets the assembly on which authenticode signature verification is performed.
        /// </summary>
        [Required]
        public ITaskItem Assembly { get; set; }

        [Output]
        public bool AuthTaskErrorsDetected { get; private set; }

        public override bool Execute()
        {
            string assemblyPath = Assembly.ItemSpec;
            string assemblyName = Path.GetFileName(assemblyPath);            
            AuthTaskErrorsDetected = false;
            try
            {
                Log.LogMessage("Verifying Authenticode Signature for '{0}' - '{1}'", assemblyName, assemblyPath);
                X509Certificate cert = X509Certificate.CreateFromSignedFile(assemblyPath);
                if ((assemblyName.ToLower().StartsWith("microsoft")) || (assemblyName.ToLower().StartsWith("system")))
                {
                    if (cert.Issuer.ToLower().Contains("microsoft"))
                    {
                        // Verify if the certificate by which it was signed is not expired
                        DateTime notAfter = DateTime.Parse(cert.GetExpirationDateString());
                        if (notAfter < DateTime.Today)
                            throw new System.Security.Cryptography.CryptographicException("'{0}' has been signed with an expired certificate", assemblyPath);

                        Log.LogMessage("Verified: '{0}' has been signed using valid cerificate issued by Microsoft", assemblyName);
                    }
                    else
                    {
                        throw new System.Security.Cryptography.CryptographicUnexpectedOperationException(string.Format("'{0}' - '{1}' assembly is not signed using Microsoft certificate", assemblyName, assemblyPath));
                    }
                }

                return true;
            }
            catch(System.Security.Cryptography.CryptographicException)
            {
                Log.LogError(string.Format("'{0}' is not authenticode signed..... exiting build", assemblyPath));
                AuthTaskErrorsDetected = true;
                return false;
            }
            catch(Exception ex)
            {
                Log.LogErrorFromException(ex);
                AuthTaskErrorsDetected = true;
                return false;
            }
        }
    }
}
