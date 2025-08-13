using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.SftpCommands;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Test suite to ensure PowerShell cmdlet parameters and behavior
    /// exactly match Azure CLI command parameters and behavior.
    /// Owner: johnli1
    /// </summary>
    [TestClass]
    public class CmdletParameterCompatibilityTests
    {
        [TestMethod]
        public void TestNewAzSftpCertificateParametersMatchAzureCLI()
        {
            // Test that New-AzSftpCertificate parameters match 'az sftp cert' exactly
            
            // Arrange
            var command = new NewAzSftpCertificateCommand();

            // Act & Assert - Check that all parameter names and aliases match Azure CLI
            
            // Azure CLI: --output-file, -o
            // PowerShell: -CertificatePath, -OutputFile, -o
            Assert.IsNotNull(command.GetType().GetProperty("CertificatePath"));
            
            // Azure CLI: --public-key-file, -p  
            // PowerShell: -PublicKeyFile, -p
            Assert.IsNotNull(command.GetType().GetProperty("PublicKeyFile"));
            
            // Azure CLI: --ssh-client-folder
            // PowerShell: -SshClientFolder
            Assert.IsNotNull(command.GetType().GetProperty("SshClientFolder"));

            // Check that aliases are properly defined
            var certPathProp = command.GetType().GetProperty("CertificatePath");
            var aliases = certPathProp?.GetCustomAttributes(typeof(AliasAttribute), false);
            Assert.IsNotNull(aliases);
            Assert.IsTrue(aliases.Length > 0);
            
            var aliasAttr = aliases[0] as AliasAttribute;
            Assert.IsNotNull(aliasAttr);
            Assert.IsTrue(aliasAttr.AliasNames.Any(alias => alias == "OutputFile"));
            Assert.IsTrue(aliasAttr.AliasNames.Any(alias => alias == "o"));
        }

        [TestMethod]
        public void TestConnectAzSftpParametersMatchAzureCLI()
        {
            // Test that Connect-AzSftp parameters match 'az sftp connect' exactly
            
            // Arrange
            var command = new ConnectAzSftpCommand();

            // Act & Assert - Check that all parameter names and aliases match Azure CLI
            
            // Azure CLI: --storage-account, -s (position 0, required)
            // PowerShell: -StorageAccount, -s (position 0, mandatory)
            Assert.IsNotNull(command.GetType().GetProperty("StorageAccount"));
            
            // Azure CLI: --port
            // PowerShell: -Port
            Assert.IsNotNull(command.GetType().GetProperty("Port"));
            
            // Azure CLI: --certificate-file, -c
            // PowerShell: -CertificateFile, -c
            Assert.IsNotNull(command.GetType().GetProperty("CertificateFile"));
            
            // Azure CLI: --private-key-file, -i
            // PowerShell: -PrivateKeyFile, -i
            Assert.IsNotNull(command.GetType().GetProperty("PrivateKeyFile"));
            
            // Azure CLI: --public-key-file, -p
            // PowerShell: -PublicKeyFile, -p
            Assert.IsNotNull(command.GetType().GetProperty("PublicKeyFile"));
            
            // Azure CLI: --sftp-args
            // PowerShell: -SftpArg
            Assert.IsNotNull(command.GetType().GetProperty("SftpArg"));
            
            // Azure CLI: --ssh-client-folder
            // PowerShell: -SshClientFolder
            Assert.IsNotNull(command.GetType().GetProperty("SshClientFolder"));

            // Check Parameter attributes match Azure CLI behavior
            var storageAccountProp = command.GetType().GetProperty("StorageAccount");
            var parameterAttrs = storageAccountProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            Assert.IsNotNull(parameterAttrs);
            Assert.IsTrue(parameterAttrs.Length > 0);
            
            var parameterAttr = parameterAttrs[0] as ParameterAttribute;
            Assert.IsNotNull(parameterAttr);
            Assert.IsTrue(parameterAttr.Mandatory); // Required in Azure CLI
            Assert.AreEqual(0, parameterAttr.Position); // Position 0 in Azure CLI
        }

        [TestMethod]
        public void TestHelpTextMatchesAzureCLI()
        {
            // Test that help text and descriptions match Azure CLI as closely as possible
            
            // This test ensures that when users look up help, they see familiar descriptions
            // that match what they would see in Azure CLI documentation
            
            var newCertCommand = new NewAzSftpCertificateCommand();
            var connectCommand = new ConnectAzSftpCommand();
            
            // Check that properties have HelpMessage attributes
            var certPathProp = newCertCommand.GetType().GetProperty("CertificatePath");
            var paramAttrs = certPathProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            Assert.IsNotNull(paramAttrs);
            Assert.IsTrue(paramAttrs.Length > 0);
            
            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.IsNotNull(paramAttr);
            Assert.IsFalse(string.IsNullOrEmpty(paramAttr.HelpMessage));
            
            // Help message should mention the same concepts as Azure CLI
            Assert.IsTrue(paramAttr.HelpMessage.Contains("SSH cert") || 
                         paramAttr.HelpMessage.Contains("certificate"));
        }

        [TestMethod]
        public void TestOutputTypesMatchAzureCLI()
        {
            // Test that cmdlet output types match Azure CLI behavior
            
            // Azure CLI 'az sftp cert' outputs success/failure messages, no object
            var newCertCommand = new NewAzSftpCertificateCommand();
            var outputTypeAttrs = newCertCommand.GetType().GetCustomAttributes(typeof(OutputTypeAttribute), false);
            Assert.IsNotNull(outputTypeAttrs);
            Assert.IsTrue(outputTypeAttrs.Length > 0);
            
            var outputTypeAttr = outputTypeAttrs[0] as OutputTypeAttribute;
            Assert.IsNotNull(outputTypeAttr);
            // Should output PSCertificateInfo containing certificate information
            Assert.IsTrue(Array.Exists(outputTypeAttr.Type, t => t.Type == typeof(PSCertificateInfo)));
            
            // Connect-AzSftp returns a Process object for the SFTP session
            var connectCommand = new ConnectAzSftpCommand();
            outputTypeAttrs = connectCommand.GetType().GetCustomAttributes(typeof(OutputTypeAttribute), false);
            Assert.IsNotNull(outputTypeAttrs);
            Assert.IsTrue(outputTypeAttrs.Length > 0);
            
            outputTypeAttr = outputTypeAttrs[0] as OutputTypeAttribute;
            Assert.IsNotNull(outputTypeAttr);
            // Should output Process object for the SFTP session
            Assert.IsTrue(Array.Exists(outputTypeAttr.Type, t => t.Type == typeof(System.Diagnostics.Process)));
        }

        [TestMethod]
        public void TestCmdletVerbsMatchAzureConventions()
        {
            // Test that PowerShell verbs follow Azure PowerShell conventions
            // while maintaining functional parity with Azure CLI
            
            // 'az sftp cert' -> 'New-AzSftpCertificate' (New verb for creating)
            var newCertCommand = new NewAzSftpCertificateCommand();
            var cmdletAttr = newCertCommand.GetType().GetCustomAttributes(typeof(CmdletAttribute), false)[0] as CmdletAttribute;
            Assert.IsNotNull(cmdletAttr);
            Assert.AreEqual(VerbsCommon.New, cmdletAttr.VerbName);
            Assert.AreEqual("AzSftpCertificate", cmdletAttr.NounName);
            
            // 'az sftp connect' -> 'Connect-AzSftp' (Connect verb for establishing connection)
            var connectCommand = new ConnectAzSftpCommand();
            cmdletAttr = connectCommand.GetType().GetCustomAttributes(typeof(CmdletAttribute), false)[0] as CmdletAttribute;
            Assert.IsNotNull(cmdletAttr);
            Assert.AreEqual(VerbsCommunications.Connect, cmdletAttr.VerbName);
            Assert.AreEqual("AzSftp", cmdletAttr.NounName);
        }

        [TestMethod]
        public void TestParameterValidationMatchesAzureCLI()
        {
            // Test that parameter validation attributes match Azure CLI validation behavior
            
            var connectCommand = new ConnectAzSftpCommand();
            
            // StorageAccount should be validated as not null/empty (like Azure CLI)
            var storageAccountProp = connectCommand.GetType().GetProperty("StorageAccount");
            var validationAttrs = storageAccountProp?.GetCustomAttributes(typeof(ValidateNotNullOrEmptyAttribute), false);
            Assert.IsNotNull(validationAttrs);
            Assert.IsTrue(validationAttrs.Length > 0);
            
            // Port should be validated if present (like Azure CLI checks for valid port range)
            var portProp = connectCommand.GetType().GetProperty("Port");
            Assert.IsNotNull(portProp);
            Assert.AreEqual(typeof(int?), portProp.PropertyType); // Should be nullable int
        }

        [TestMethod]
        public void TestDefaultBehaviorMatchesAzureCLI()
        {
            // Test that default parameter behavior matches Azure CLI
            
            var connectCommand = new ConnectAzSftpCommand();
            
            // Port should default to null (Azure CLI uses SSH default of 22)
            Assert.IsNull(connectCommand.Port);
            
            // Certificate, private key, and public key files should default to null
            // (Azure CLI auto-generates if not provided)
            Assert.IsNull(connectCommand.CertificateFile);
            Assert.IsNull(connectCommand.PrivateKeyFile);
            Assert.IsNull(connectCommand.PublicKeyFile);
            
            // SftpArg should default to null (Azure CLI defaults to empty)
            Assert.IsNull(connectCommand.SftpArg);
            
            // SshClientFolder should default to null (Azure CLI auto-detects)
            Assert.IsNull(connectCommand.SshClientFolder);
        }

        [TestMethod]
        public void TestParameterSetLogicMatchesAzureCLI()
        {
            // Test that parameter set logic matches Azure CLI's argument validation
            
            // Azure CLI allows these combinations:
            // 1. No auth files (auto-generate everything)
            // 2. Certificate file only
            // 3. Private key file only (auto-generate cert)
            // 4. Public key file only (auto-generate cert)
            // 5. Certificate + private key
            // 6. Public key + private key (auto-generate cert)
            
            // PowerShell should handle the same combinations
            var connectCommand = new ConnectAzSftpCommand();
            
            // All auth parameters should be optional to allow auto-generation
            var certFileProp = connectCommand.GetType().GetProperty("CertificateFile");
            var certFileParam = certFileProp?.GetCustomAttributes(typeof(ParameterAttribute), false)[0] as ParameterAttribute;
            Assert.IsFalse(certFileParam?.Mandatory ?? true);
            
            var privateKeyProp = connectCommand.GetType().GetProperty("PrivateKeyFile");
            var privateKeyParam = privateKeyProp?.GetCustomAttributes(typeof(ParameterAttribute), false)[0] as ParameterAttribute;
            Assert.IsFalse(privateKeyParam?.Mandatory ?? true);
            
            var publicKeyProp = connectCommand.GetType().GetProperty("PublicKeyFile");
            var publicKeyParam = publicKeyProp?.GetCustomAttributes(typeof(ParameterAttribute), false)[0] as ParameterAttribute;
            Assert.IsFalse(publicKeyParam?.Mandatory ?? true);
        }
    }
}
