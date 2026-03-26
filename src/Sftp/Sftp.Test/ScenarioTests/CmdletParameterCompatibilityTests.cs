using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.SftpCommands;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models;
using Xunit;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Test suite to ensure PowerShell cmdlet parameters and behavior
    /// exactly match Azure CLI command parameters and behavior.
    /// Owner: johnli1
    /// </summary>
    public class CmdletParameterCompatibilityTests
    {
        [Fact]
        public void TestNewAzSftpCertificateParametersMatchAzureCLI()
        {
            // Test that New-AzSftpCertificate parameters match 'az sftp cert' exactly
            
            // Arrange
            var command = new NewAzSftpCertificateCommand();

            // Act & Assert - Check that all parameter names and aliases match Azure CLI
            
            // Azure CLI: --output-file, -o
            // PowerShell: -CertificatePath, -OutputFile, -o
            Assert.NotNull(command.GetType().GetProperty("CertificatePath"));
            
            // Azure CLI: --public-key-file, -p  
            // PowerShell: -PublicKeyFile, -p
            Assert.NotNull(command.GetType().GetProperty("PublicKeyFile"));
            
            // Azure CLI: --ssh-client-folder
            // PowerShell: -SshClientFolder
            Assert.NotNull(command.GetType().GetProperty("SshClientFolder"));

            // Check that aliases are properly defined
            var certPathProp = command.GetType().GetProperty("CertificatePath");
            var aliases = certPathProp?.GetCustomAttributes(typeof(AliasAttribute), false);
            Assert.NotNull(aliases);
            Assert.True(aliases.Length > 0);
            
            var aliasAttr = aliases[0] as AliasAttribute;
            Assert.NotNull(aliasAttr);
            Assert.Contains("OutputFile", aliasAttr.AliasNames);
            Assert.Contains("o", aliasAttr.AliasNames);
        }

        [Fact]
        public void TestConnectAzSftpParametersMatchAzureCLI()
        {
            // Test that Connect-AzSftp parameters match 'az sftp connect' exactly
            
            // Arrange
            var command = new ConnectAzSftpCommand();

            // Act & Assert - Check that all parameter names and aliases match Azure CLI
            
            // Azure CLI: --storage-account, -s (position 0, required)
            // PowerShell: -StorageAccount, -s (position 0, mandatory)
            Assert.NotNull(command.GetType().GetProperty("StorageAccount"));
            
            // Azure CLI: --port
            // PowerShell: -Port
            Assert.NotNull(command.GetType().GetProperty("Port"));
            
            // Azure CLI: --certificate-file, -c
            // PowerShell: -CertificateFile, -c
            Assert.NotNull(command.GetType().GetProperty("CertificateFile"));
            
            // Azure CLI: --private-key-file, -i
            // PowerShell: -PrivateKeyFile, -i
            Assert.NotNull(command.GetType().GetProperty("PrivateKeyFile"));
            
            // Azure CLI: --public-key-file, -p
            // PowerShell: -PublicKeyFile, -p
            Assert.NotNull(command.GetType().GetProperty("PublicKeyFile"));
            
            // Azure CLI: --sftp-args
            // PowerShell: -SftpArg
            Assert.NotNull(command.GetType().GetProperty("SftpArg"));
            
            // Azure CLI: --ssh-client-folder
            // PowerShell: -SshClientFolder
            Assert.NotNull(command.GetType().GetProperty("SshClientFolder"));

            // Check Parameter attributes match Azure CLI behavior
            var storageAccountProp = command.GetType().GetProperty("StorageAccount");
            var parameterAttrs = storageAccountProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            Assert.NotNull(parameterAttrs);
            Assert.True(parameterAttrs.Length > 0);
            
            var parameterAttr = parameterAttrs[0] as ParameterAttribute;
            Assert.NotNull(parameterAttr);
            Assert.True(parameterAttr.Mandatory); // Required in Azure CLI
            Assert.Equal(0, parameterAttr.Position); // Position 0 in Azure CLI
        }

        [Fact]
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
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);
            
            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(string.IsNullOrEmpty(paramAttr.HelpMessage));
            
            // Help message should mention the same concepts as Azure CLI
            Assert.True(paramAttr.HelpMessage.Contains("SSH cert") || 
                         paramAttr.HelpMessage.Contains("certificate"));
        }

        [Fact]
        public void TestOutputTypesMatchAzureCLI()
        {
            // Test that cmdlet output types match Azure CLI behavior
            
            // Azure CLI 'az sftp cert' outputs success/failure messages, no object
            var newCertCommand = new NewAzSftpCertificateCommand();
            var outputTypeAttrs = newCertCommand.GetType().GetCustomAttributes(typeof(OutputTypeAttribute), false);
            Assert.NotNull(outputTypeAttrs);
            Assert.True(outputTypeAttrs.Length > 0);
            
            var outputTypeAttr = outputTypeAttrs[0] as OutputTypeAttribute;
            Assert.NotNull(outputTypeAttr);
            // Should output PSCertificateInfo containing certificate information
            Assert.True(Array.Exists(outputTypeAttr.Type, t => t.Type == typeof(PSCertificateInfo)));
            
            // Connect-AzSftp returns a Process object for the SFTP session
            var connectCommand = new ConnectAzSftpCommand();
            outputTypeAttrs = connectCommand.GetType().GetCustomAttributes(typeof(OutputTypeAttribute), false);
            Assert.NotNull(outputTypeAttrs);
            Assert.True(outputTypeAttrs.Length > 0);
            
            outputTypeAttr = outputTypeAttrs[0] as OutputTypeAttribute;
            Assert.NotNull(outputTypeAttr);
            // Should output Process object for the SFTP session
            Assert.True(Array.Exists(outputTypeAttr.Type, t => t.Type == typeof(System.Diagnostics.Process)));
        }

        [Fact]
        public void TestCmdletVerbsMatchAzureConventions()
        {
            // Test that PowerShell verbs follow Azure PowerShell conventions
            // while maintaining functional parity with Azure CLI
            
            // 'az sftp cert' -> 'New-AzSftpCertificate' (New verb for creating)
            var newCertCommand = new NewAzSftpCertificateCommand();
            var cmdletAttr = newCertCommand.GetType().GetCustomAttributes(typeof(CmdletAttribute), false)[0] as CmdletAttribute;
            Assert.NotNull(cmdletAttr);
            Assert.Equal(VerbsCommon.New, cmdletAttr.VerbName);
            Assert.Equal("AzSftpCertificate", cmdletAttr.NounName);
            
            // 'az sftp connect' -> 'Connect-AzSftp' (Connect verb for establishing connection)
            var connectCommand = new ConnectAzSftpCommand();
            cmdletAttr = connectCommand.GetType().GetCustomAttributes(typeof(CmdletAttribute), false)[0] as CmdletAttribute;
            Assert.NotNull(cmdletAttr);
            Assert.Equal(VerbsCommunications.Connect, cmdletAttr.VerbName);
            Assert.Equal("AzSftp", cmdletAttr.NounName);
        }

        [Fact]
        public void TestParameterValidationMatchesAzureCLI()
        {
            // Test that parameter validation attributes match Azure CLI validation behavior
            
            var connectCommand = new ConnectAzSftpCommand();
            
            // StorageAccount should be validated as not null/empty (like Azure CLI)
            var storageAccountProp = connectCommand.GetType().GetProperty("StorageAccount");
            var validationAttrs = storageAccountProp?.GetCustomAttributes(typeof(ValidateNotNullOrEmptyAttribute), false);
            Assert.NotNull(validationAttrs);
            Assert.True(validationAttrs.Length > 0);
            
            // Port should be validated if present (like Azure CLI checks for valid port range)
            var portProp = connectCommand.GetType().GetProperty("Port");
            Assert.NotNull(portProp);
            Assert.Equal(typeof(int?), portProp.PropertyType); // Should be nullable int
        }

        [Fact]
        public void TestDefaultBehaviorMatchesAzureCLI()
        {
            // Test that default parameter behavior matches Azure CLI
            
            var connectCommand = new ConnectAzSftpCommand();
            
            // Port should default to null (Azure CLI uses SSH default of 22)
            Assert.Null(connectCommand.Port);
            
            // Certificate, private key, and public key files should default to null
            // (Azure CLI auto-generates if not provided)
            Assert.Null(connectCommand.CertificateFile);
            Assert.Null(connectCommand.PrivateKeyFile);
            Assert.Null(connectCommand.PublicKeyFile);
            
            // SftpArg should default to null (Azure CLI defaults to empty)
            Assert.Null(connectCommand.SftpArg);
            
            // SshClientFolder should default to null (Azure CLI auto-detects)
            Assert.Null(connectCommand.SshClientFolder);
        }

        [Fact]
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
            Assert.False(certFileParam?.Mandatory ?? true);
            
            var privateKeyProp = connectCommand.GetType().GetProperty("PrivateKeyFile");
            var privateKeyParam = privateKeyProp?.GetCustomAttributes(typeof(ParameterAttribute), false)[0] as ParameterAttribute;
            Assert.False(privateKeyParam?.Mandatory ?? true);
            
            var publicKeyProp = connectCommand.GetType().GetProperty("PublicKeyFile");
            var publicKeyParam = publicKeyProp?.GetCustomAttributes(typeof(ParameterAttribute), false)[0] as ParameterAttribute;
            Assert.False(publicKeyParam?.Mandatory ?? true);
        }

        #region BufferSizeInBytes Parameter Tests

        [Fact]
        public void TestBufferSizeInBytesParameterExists()
        {
            // Test that BufferSizeInBytes parameter exists on Connect-AzSftp
            var connectCommand = new ConnectAzSftpCommand();
            
            var bufferSizeProp = connectCommand.GetType().GetProperty("BufferSizeInBytes");
            Assert.NotNull(bufferSizeProp);
            Assert.Equal(typeof(int), bufferSizeProp.PropertyType);
        }

        [Fact]
        public void TestBufferSizeInBytesDefaultValue()
        {
            // Test that BufferSizeInBytes has correct default value (256 * 1024 = 262144)
            var connectCommand = new ConnectAzSftpCommand();
            
            Assert.Equal(256 * 1024, connectCommand.BufferSizeInBytes);
            Assert.Equal(262144, connectCommand.BufferSizeInBytes);
        }

        [Fact]
        public void TestBufferSizeInBytesHasValidateRangeAttribute()
        {
            // Test that BufferSizeInBytes has proper validation
            var connectCommand = new ConnectAzSftpCommand();
            
            var bufferSizeProp = connectCommand.GetType().GetProperty("BufferSizeInBytes");
            var validateAttrs = bufferSizeProp?.GetCustomAttributes(typeof(ValidateRangeAttribute), false);
            
            Assert.NotNull(validateAttrs);
            Assert.True(validateAttrs.Length > 0);
            
            var validateRange = validateAttrs[0] as ValidateRangeAttribute;
            Assert.NotNull(validateRange);
            Assert.Equal(1, validateRange.MinRange);  // Minimum should be 1
        }

        [Fact]
        public void TestBufferSizeInBytesHasHelpMessage()
        {
            // Test that BufferSizeInBytes has helpful documentation
            var connectCommand = new ConnectAzSftpCommand();
            
            var bufferSizeProp = connectCommand.GetType().GetProperty("BufferSizeInBytes");
            var paramAttrs = bufferSizeProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);
            
            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(string.IsNullOrEmpty(paramAttr.HelpMessage));
            Assert.Contains("buffer", paramAttr.HelpMessage.ToLower());
        }

        [Fact]
        public void TestBufferSizeInBytesIsOptional()
        {
            // Test that BufferSizeInBytes is not mandatory (has default value)
            var connectCommand = new ConnectAzSftpCommand();
            
            var bufferSizeProp = connectCommand.GetType().GetProperty("BufferSizeInBytes");
            var paramAttrs = bufferSizeProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);
            
            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(paramAttr.Mandatory);
        }

        #endregion

        #region StorageAccountEndpoint Parameter Tests

        [Fact]
        public void TestStorageAccountEndpointParameterExists()
        {
            // Test that StorageAccountEndpoint parameter exists on Connect-AzSftp
            var connectCommand = new ConnectAzSftpCommand();
            
            var endpointProp = connectCommand.GetType().GetProperty("StorageAccountEndpoint");
            Assert.NotNull(endpointProp);
            Assert.Equal(typeof(string), endpointProp.PropertyType);
        }

        [Fact]
        public void TestStorageAccountEndpointDefaultValue()
        {
            // Test that StorageAccountEndpoint defaults to null (auto-detect from Azure environment)
            var connectCommand = new ConnectAzSftpCommand();
            
            Assert.Null(connectCommand.StorageAccountEndpoint);
        }

        [Fact]
        public void TestStorageAccountEndpointHasValidateNotNullOrEmptyAttribute()
        {
            // Test that StorageAccountEndpoint has proper validation when provided
            var connectCommand = new ConnectAzSftpCommand();
            
            var endpointProp = connectCommand.GetType().GetProperty("StorageAccountEndpoint");
            var validateAttrs = endpointProp?.GetCustomAttributes(typeof(ValidateNotNullOrEmptyAttribute), false);
            
            Assert.NotNull(validateAttrs);
            Assert.True(validateAttrs.Length > 0);
        }

        [Fact]
        public void TestStorageAccountEndpointHasHelpMessage()
        {
            // Test that StorageAccountEndpoint has helpful documentation
            var connectCommand = new ConnectAzSftpCommand();
            
            var endpointProp = connectCommand.GetType().GetProperty("StorageAccountEndpoint");
            var paramAttrs = endpointProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);
            
            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(string.IsNullOrEmpty(paramAttr.HelpMessage));
            Assert.Contains("endpoint", paramAttr.HelpMessage.ToLower());
        }

        [Fact]
        public void TestStorageAccountEndpointIsOptional()
        {
            // Test that StorageAccountEndpoint is not mandatory (uses auto-detection by default)
            var connectCommand = new ConnectAzSftpCommand();
            
            var endpointProp = connectCommand.GetType().GetProperty("StorageAccountEndpoint");
            var paramAttrs = endpointProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);
            
            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(paramAttr.Mandatory);
        }

        [Fact]
        public void TestStorageAccountEndpointAvailableInAllParameterSets()
        {
            // Test that StorageAccountEndpoint is available in all parameter sets
            var connectCommand = new ConnectAzSftpCommand();
            
            var endpointProp = connectCommand.GetType().GetProperty("StorageAccountEndpoint");
            var paramAttrs = endpointProp?.GetCustomAttributes(typeof(ParameterAttribute), false);
            
            Assert.NotNull(paramAttrs);
            // Should have multiple Parameter attributes (one for each parameter set)
            Assert.True(paramAttrs.Length >= 4, "StorageAccountEndpoint should be available in all parameter sets");
        }

        #endregion
    }
}
