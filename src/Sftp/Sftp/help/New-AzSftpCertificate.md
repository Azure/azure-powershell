---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sftp.dll-Help.xml
Module Name: Az.Sftp
online version: https://docs.microsoft.com/powershell/module/az.sftp/new-azsftpcertificate
schema: 2.0.0
---

# New-AzSftpCertificate

## SYNOPSIS
Generate SSH certificates for SFTP authentication using Azure AD credentials.

## SYNTAX

### Default (Default)
```
New-AzSftpCertificate [-CertificatePath <String>] [-PrivateKeyFile <String>] [-SshClientFolder <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### FromPublicKey
```
New-AzSftpCertificate [-CertificatePath <String>] -PublicKeyFile <String> [-SshClientFolder <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### FromPrivateKey
```
New-AzSftpCertificate [-CertificatePath <String>] -PrivateKeyFile <String> [-SshClientFolder <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### LocalUser
```
New-AzSftpCertificate [-CertificatePath <String>] -LocalUser <String> [-PrivateKeyFile <String>]
 [-SshClientFolder <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzSftpCertificate cmdlet generates SSH certificates for SFTP authentication using your current Azure AD credentials. This cmdlet now provides the same authentication methods and parameter sets as the Az.Ssh module, ensuring consistency across Azure PowerShell modules.

The cmdlet supports four authentication modes that align with the SSH module:

**Default Mode (Azure AD Authentication)**: When no specific key files are provided, the cmdlet automatically generates a new SSH key pair and creates a certificate signed by Azure AD's trusted CA. This is the simplest approach for getting started with SFTP authentication.

**FromPublicKey Mode**: When a public key file is provided, the cmdlet generates a certificate for that specific key using Azure AD credentials. This is useful when you already have SSH public keys and want to use them for Azure Storage SFTP access.

**FromPrivateKey Mode**: When a private key file is provided, the cmdlet generates the corresponding public key and creates a certificate using Azure AD credentials. This is helpful when you have existing private keys and want to create certificates for them.

**LocalUser Mode**: When a local user is specified, the cmdlet generates a certificate suitable for local user authentication on storage accounts. This can be combined with existing private keys or generate new ones, matching the SSH module's local user certificate capabilities.

The generated certificates are typically valid for 1 hour and can be used with any SFTP client that supports SSH certificate authentication. The certificates are signed by Azure AD's trusted CA and will be accepted by Azure Storage accounts where your Azure AD identity has appropriate permissions.

You must be signed in to Azure with an account that has appropriate RBAC permissions (such as Storage Blob Data Contributor or Storage Blob Data Owner) on the target storage accounts.

## PARAMETERS

### -CertificatePath
Specifies the path where the SSH certificate will be saved. If not specified, the certificate is saved in the system temp directory with an auto-generated filename. The certificate file will have a .cert extension and contains the public certificate that can be used for SFTP authentication.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicKeyFile
Specifies the path to an existing SSH public key file for which to generate a certificate using Azure AD. The public key should be in OpenSSH format (typically .pub extension). When this parameter is provided, the cmdlet generates a certificate for the specified public key rather than creating a new key pair.

```yaml
Type: String
Parameter Sets: FromPublicKey
Aliases: p

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyFile
Specifies the path to an existing SSH private key file.

- **Required for FromPrivateKey parameter set**: The cmdlet will generate a certificate for the corresponding public key derived from this private key.
- **Optional for Default parameter set**: When provided, uses this private key instead of generating a new one for Azure AD certificate generation.
- **Optional for LocalUser parameter set**: When provided with LocalUser, creates a certificate suitable for local user authentication using this private key.

The private key should be in OpenSSH format and properly secured with appropriate file permissions.

```yaml
Type: String
Parameter Sets: FromPrivateKey
Aliases: i

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Default, LocalUser
Aliases: i

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalUser
Specifies the username for local user certificate generation. When this parameter is provided, the cmdlet generates a certificate that is suitable for authenticating to local user accounts configured on storage accounts. This parameter aligns with the SSH module's local user authentication capabilities.

Can be combined with an existing private key or used to generate a new key pair specifically for local user authentication.

```yaml
Type: String
Parameter Sets: LocalUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshClientFolder
Specifies the folder path that contains SSH executables (ssh-keygen). If not specified, the cmdlet searches for SSH executables in the following order:
1. SSH executables in PATH environment variable
2. C:\Windows\System32\OpenSSH (Windows default)
3. C:\Program Files\OpenSSH (Windows alternative)
4. /usr/bin (Linux/macOS default)

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept pipeline input.

## OUTPUTS

### Microsoft.Azure.Commands.Sftp.Models.PSCertificateInfo
Returns an object containing information about the generated certificate, including:
- CertificatePath: Path to the generated certificate file
- PublicKeyPath: Path to the public key file (if generated or used)
- PrivateKeyPath: Path to the private key file (if generated or used)  
- ValidFrom: Certificate validity start time
- ValidUntil: Certificate expiration time
- Principal: Azure AD principal used for certificate generation
- ParameterSet: The parameter set used for certificate generation
- LocalUser: Local user name (if applicable)
- IsValid: Whether the certificate is currently valid
- TimeRemaining: Time remaining before certificate expires

## NOTES
- Requires an active Azure AD session (Connect-AzAccount)
- Generated certificates are typically valid for 1 hour for security purposes
- Private keys (when generated) contain sensitive information and should be handled securely
- The certificate can be used with any SFTP client that supports SSH certificate authentication
- This cmdlet now provides the same authentication methods as the Az.Ssh module for consistency
- Certificates are signed by Azure AD's trusted CA and automatically trusted by Azure Storage SFTP endpoints
- Local user certificates can be used for authentication to storage account local users
- All parameter sets support both automatic key generation and using existing keys

## EXAMPLES

### Example 1: Generate certificate with automatic key generation
```powershell
New-AzSftpCertificate
```

This command generates a new SSH key pair and creates a certificate signed by Azure AD. The key pair and certificate are saved in the system temp directory with auto-generated filenames. This is the simplest way to get started with SFTP authentication.

### Example 2: Generate certificate with custom path
```powershell
New-AzSftpCertificate -CertificatePath "C:\certs\azure-sftp.cert"
```

This command generates a new SSH key pair and creates a certificate, saving the certificate to the specified path. The private and public keys will be saved in the same directory with corresponding names (azure-sftp and azure-sftp.pub).

### Example 3: Generate certificate from existing private key
```powershell
New-AzSftpCertificate -PrivateKeyFile "C:\keys\id_rsa" -CertificatePath "C:\certs\id_rsa.cert"
```

This command generates a certificate from an existing SSH private key. The cmdlet will automatically derive the public key from the private key and create a certificate signed by Azure AD. This is useful when you have existing private keys and want to create certificates for them.

### Example 4: Generate certificate for local user authentication
```powershell
New-AzSftpCertificate -LocalUser "sftpuser" -CertificatePath "C:\certs\localuser.cert"
```

This command generates a certificate suitable for local user authentication on storage accounts. A new key pair is generated and the certificate is configured for the specified local user. This aligns with the SSH module's local user authentication capabilities.

### Example 5: Generate certificate for local user with existing private key
```powershell
New-AzSftpCertificate -LocalUser "sftpuser" -PrivateKeyFile "C:\keys\existing_key" -CertificatePath "C:\certs\localuser.cert"
```

This command generates a certificate for local user authentication using an existing private key. This is useful when you want to use specific keys for local user authentication on storage accounts.

### Example 6: Generate certificate with automatic paths
```powershell
$cert = New-AzSftpCertificate
Write-Host "Certificate: $($cert.CertificatePath)"
Write-Host "Private Key: $($cert.PrivateKeyPath)"
Write-Host "Valid Until: $($cert.ValidUntil)"
```

This command generates a certificate with automatic key generation and temporary file paths. The returned object contains all the file paths and certificate information, making it easy to use programmatically.

### Example 7: Compare different authentication methods
```powershell
# Azure AD authentication (default)
$aadCert = New-AzSftpCertificate -CertificatePath "C:\certs\aad-cert.pub"
Write-Host "Azure AD cert for principal: $($aadCert.Principal)"

# Local user authentication  
$localCert = New-AzSftpCertificate -LocalUser "sftpuser" -CertificatePath "C:\certs\local-cert.pub"
Write-Host "Local user cert for: $($localCert.LocalUser)"

# Using existing private key
$existingKeyCert = New-AzSftpCertificate -PrivateKeyFile "C:\keys\existing.key" -CertificatePath "C:\certs\existing-cert.pub"
Write-Host "Certificate from existing key: $($existingKeyCert.CertificatePath)"
```

This example demonstrates the different authentication methods available, showing how each parameter set creates certificates for different scenarios.

### Example 8: Generate certificate and use with Connect-AzSftp
```powershell
# Generate certificate for local user
$cert = New-AzSftpCertificate -LocalUser "sftpuser" -CertificatePath "C:\certs\sftp-auth.cert"

# Use the certificate to connect to storage account
$process = Connect-AzSftp -StorageAccount "mystorageaccount" -LocalUser "sftpuser" -PrivateKeyFile $cert.PrivateKeyPath

# Display connection info
Write-Host "SFTP connection established using certificate: $($cert.CertificatePath)"
Write-Host "Process ID: $($process.Id)"
```

This example demonstrates the full workflow of generating a certificate and immediately using it for SFTP connection, showing the integration between the two cmdlets.

### Example 9: Generate certificate with custom SSH client location
```powershell
New-AzSftpCertificate -CertificatePath "C:\certs\custom-cert.pub" -SshClientFolder "C:\Program Files\OpenSSH"
```

This command generates a certificate using SSH executables from a specific location. This is useful when you have multiple SSH implementations installed or when ssh-keygen is not in the default PATH.

## RELATED LINKS

[Connect-AzSftp](./Connect-AzSftp.md)

[Azure Storage SFTP Support](https://docs.microsoft.com/en-us/azure/storage/blobs/secure-file-transfer-protocol-support)

[OpenSSH Certificate Authentication](https://www.openssh.com/txt/release-5.4)
