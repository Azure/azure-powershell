---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sftp.dll-Help.xml
Module Name: Az.Sftp
online version: https://learn.microsoft.com/powershell/module/az.sftp/new-azsftpcertificate
schema: 2.0.0
---

# New-AzSftpCertificate

## SYNOPSIS
Generate SSH certificates for SFTP authentication using Microsoft Entra credentials.

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
The New-AzSftpCertificate cmdlet generates SSH certificates for SFTP authentication using your current Microsoft Entra credentials. This cmdlet provides the same authentication methods and parameter sets as the Az.Ssh module, ensuring consistency across Azure PowerShell modules.

The cmdlet supports four authentication modes that align with the SSH module:

**Default Mode (Microsoft Entra Authentication)**: When no specific key files are provided, the cmdlet automatically generates a new SSH key pair and creates a certificate signed by Microsoft Entra's trusted CA. This is the simplest approach for getting started with SFTP authentication.

**FromPublicKey Mode**: When a public key file is provided, the cmdlet generates a certificate for that specific key using Microsoft Entra credentials. This is useful when you already have SSH public keys and want to use them for Azure Storage SFTP access.

**FromPrivateKey Mode**: When a private key file is provided, the cmdlet generates the corresponding public key and creates a certificate using Microsoft Entra credentials. This is helpful when you have existing private keys and want to create certificates for them.

**LocalUser Mode**: When a local user is specified, the cmdlet generates a certificate suitable for local user authentication on storage accounts. This can be combined with existing private keys or generate new ones, matching the SSH module's local user certificate capabilities.

The generated certificates are typically valid for 1 hour and can be used with any SFTP client that supports SSH certificate authentication. The certificates are signed by Microsoft Entra's trusted CA and will be accepted by Azure Storage accounts where your Microsoft Entra identity has appropriate permissions.

You must be signed in to Azure with an account that has appropriate RBAC permissions (such as Storage Blob Data Contributor or Storage Blob Data Owner) on the target storage accounts.

## EXAMPLES

### Example 1: Generate certificate with automatic key generation
```powershell
New-AzSftpCertificate
```

This command generates a new SSH key pair and creates a certificate signed by Microsoft Entra. The key pair and certificate are saved in the system temp directory with auto-generated filenames. This is the simplest way to get started with SFTP authentication.

### Example 2: Generate certificate with custom path
```powershell
New-AzSftpCertificate -CertificatePath "C:\certs\azure-sftp.cert"
```

This command generates a new SSH key pair and creates a certificate, saving the certificate to the specified path. The private and public keys will be saved in the same directory with corresponding names (azure-sftp and azure-sftp.pub).

### Example 3: Generate certificate from existing private key
```powershell
New-AzSftpCertificate -PrivateKeyFile "C:\keys\id_rsa" -CertificatePath "C:\certs\id_rsa.cert"
```

This command generates a certificate from an existing SSH private key. The cmdlet will automatically derive the public key from the private key and create a certificate signed by Microsoft Entra. This is useful when you have existing private keys and want to create certificates for them.

### Example 4: Generate certificate from existing public key
```powershell
New-AzSftpCertificate -PublicKeyFile "C:\keys\id_rsa.pub" -CertificatePath "C:\certs\id_rsa.cert"
```

This command generates a certificate from an existing SSH public key. This is useful when you want to create certificates for existing public keys that are already configured on storage accounts.

### Example 5: Generate certificate for local user authentication
```powershell
New-AzSftpCertificate -LocalUser "sftpuser" -CertificatePath "C:\certs\localuser.cert"
```

This command generates a certificate suitable for local user authentication on storage accounts. A new key pair is generated and the certificate is configured for the specified local user. This aligns with the SSH module's local user authentication capabilities.

### Example 6: Generate certificate for local user with existing private key
```powershell
New-AzSftpCertificate -LocalUser "sftpuser" -PrivateKeyFile "C:\keys\existing_key" -CertificatePath "C:\certs\localuser.cert"
```

This command generates a certificate for local user authentication using an existing private key. This is useful when you want to use specific keys for local user authentication on storage accounts.

### Example 7: Generate certificate with automatic paths
```powershell
$cert = New-AzSftpCertificate
Write-Host "Certificate: $($cert.CertificatePath)"
Write-Host "Private Key: $($cert.PrivateKeyPath)"
Write-Host "Valid Until: $($cert.ValidUntil)"
```

This command generates a certificate with automatic key generation and temporary file paths. The returned object contains all the file paths and certificate information, making it easy to use programmatically.

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

## PARAMETERS

### -CertificatePath
Path to write SSH certificate to.

```yaml
Type: System.String
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalUser
Username for a local user in the target storage account.

```yaml
Type: System.String
Parameter Sets: LocalUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyFile
Path to private key file.

```yaml
Type: System.String
Parameter Sets: FromPrivateKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Default, LocalUser
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicKeyFile
Path to public key file.

```yaml
Type: System.String
Parameter Sets: FromPublicKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshClientFolder
Directory containing SSH executables (ssh-keygen).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

## OUTPUTS

### Microsoft.Azure.Commands.Sftp.Models.PSCertificateInfo

## NOTES

## RELATED LINKS

[Connect-AzSftp](./Connect-AzSftp.md)

[Azure Storage SFTP Support](https://docs.microsoft.com/en-us/azure/storage/blobs/secure-file-transfer-protocol-support)

[OpenSSH Certificate Authentication](https://www.openssh.com/txt/release-5.4)
