---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sftp.dll-Help.xml
Module Name: Az.Sftp
online version: https://learn.microsoft.com/powershell/module/az.sftp/connect-azsftp
schema: 2.0.0
---

# Connect-AzSftp

## SYNOPSIS
Starts an interactive SFTP session to an Azure Storage Account.
Users can login using Microsoft Entra accounts, or local user accounts via standard SSH authentication. Use Microsoft Entra account login for the best security and convenience.

## SYNTAX

### Default (Default)
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] [-PrivateKeyFile <String>] [-PublicKeyFile <String>]
 [-SftpArg <String[]>] [-SshClientFolder <String>] [-BufferSizeInBytes <Int32>] [-StorageAccountEndpoint <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CertificateAuth
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] -CertificateFile <String> -PrivateKeyFile <String>
 [-SftpArg <String[]>] [-SshClientFolder <String>] [-BufferSizeInBytes <Int32>] [-StorageAccountEndpoint <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PublicKeyAuth
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] -PublicKeyFile <String> [-SftpArg <String[]>]
 [-SshClientFolder <String>] [-BufferSizeInBytes <Int32>] [-StorageAccountEndpoint <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### LocalUserAuth
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] -LocalUser <String> [-PrivateKeyFile <String>]
 [-SftpArg <String[]>] [-SshClientFolder <String>] [-BufferSizeInBytes <Int32>] [-StorageAccountEndpoint <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Start interactive SFTP session to an Azure Storage Account.
Users can login using Microsoft Entra issued certificates or using local user credentials. We recommend login using Microsoft Entra issued certificates when possible.
The target storage account must have SFTP enabled and hierarchical namespace (HNS) enabled. For Microsoft Entra authentication, your Microsoft Entra identity must have appropriate RBAC permissions such as Storage Blob Data Contributor or Storage Blob Data Owner.

## EXAMPLES

### Example 1: Connect to Azure Storage Account using Microsoft Entra issued certificates
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount"
```

When a -LocalUser is not supplied, the cmdlet will attempt to login using Microsoft Entra ID. This is the recommended approach as it requires no manual certificate management.

### Example 2: Connect to Local User on Azure Storage Account using SSH private key for authentication
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -LocalUser "sftpuser" -PrivateKeyFile "./id_rsa"
```

### Example 3: Connect to Local User on Azure Storage Account using SSH private key for authentication
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -LocalUser "sftpuser" -PrivateKeyFile "./id_rsa"
```

### Example 4: Connect to Local User on Azure Storage Account using interactive username and password authentication
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -LocalUser "sftpuser"
```

### Example 5: Connect with custom port and verbose output
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -Port 2022 -SftpArg "-v"
```

### Example 6: Connect with batch commands
```powershell
# Create batch file with SFTP commands
@"
cd uploads
put C:\local\file.txt
ls -la
quit
"@ | Out-File -FilePath "C:\temp\batch.sftp" -Encoding ([System.Text.Encoding]::ASCII)

# Execute batch commands
Connect-AzSftp -StorageAccount "mystorageaccount" -SftpArg "-b", "C:\temp\batch.sftp"
```

### Example 7: Connect with custom SSH client location
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -SshClientFolder "C:\Program Files\OpenSSH"
```

### Example 8: Connect with advanced SSH options
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -SftpArg "-o", "ConnectTimeout=30", "-o", "StrictHostKeyChecking=no", "-v"
```

### Example 9: Connect with certificate from existing SSH keys
```powershell
# Use existing SSH keys to generate a certificate automatically
Connect-AzSftp -StorageAccount "mystorageaccount" -PrivateKeyFile "C:\keys\id_rsa" -PublicKeyFile "C:\keys\id_rsa.pub"
```

### Example 10: Troubleshoot authentication issues
```powershell
# Check Microsoft Entra authentication status
Get-AzContext

# Test certificate generation explicitly
$cert = New-AzSftpCertificate -CertificatePath "C:\temp\test-cert.pub"
Write-Host "Certificate generated: $($cert.CertificatePath)"
Write-Host "Principal: $($cert.Principal)"

# Connect using the generated certificate
Connect-AzSftp -StorageAccount "mystorageaccount" -CertificateFile $cert.CertificatePath -PrivateKeyFile $cert.PrivateKeyPath -SftpArg "-v"
```

### Example 11: Full workflow example
```powershell
# Generate certificate for SFTP authentication
$cert = New-AzSftpCertificate -CertificatePath "C:\certs\sftp-auth.cert"

# Connect to storage account using the generated certificate
$sftpProcess = Connect-AzSftp -StorageAccount "mystorageaccount" -CertificateFile $cert.CertificatePath -PrivateKeyFile $cert.PrivateKeyPath

# Display connection information
Write-Host "SFTP connection established using certificate: $($cert.CertificatePath)"
Write-Host "Process ID: $($sftpProcess.Id)"
```

### Example 12: Connect to multiple storage accounts
```powershell
# Array of storage accounts to connect to
$storageAccounts = @("account1", "account2", "account3")

# Generate a certificate once for reuse
$cert = New-AzSftpCertificate -CertificatePath "C:\certs\shared-cert.cert"

# Connect to each storage account
foreach ($account in $storageAccounts) {
    Write-Host "Connecting to $account..."
    $process = Connect-AzSftp -StorageAccount $account -CertificateFile $cert.CertificatePath -PrivateKeyFile $cert.PrivateKeyPath -SftpArg "-b", "C:\scripts\sftp-commands.txt"
    Write-Host "Connected to $account (Process ID: $($process.Id))"
}
```

### Example 13: Connect using existing certificate and private key
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -CertificateFile "C:\certs\azure-sftp.cert" -PrivateKeyFile "C:\certs\azure-sftp-key"
```

## PARAMETERS

### -BufferSizeInBytes
Buffer size in bytes for SFTP file transfers. Default: 262144 (256 KB).

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 262144
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateFile
SSH Certificate to be used to authenticate to local user account.

```yaml
Type: System.String
Parameter Sets: CertificateAuth
Aliases:

Required: True
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
Parameter Sets: LocalUserAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
Port to connect to on the remote host.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyFile
Path to private key file.

```yaml
Type: System.String
Parameter Sets: CertificateAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Default, LocalUserAuth
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
Parameter Sets: PublicKeyAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SftpArg
Additional SFTP arguments passed to OpenSSH.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshClientFolder
Directory containing SSH executables (ssh-keygen, sftp).

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

### -StorageAccount
Name of the target Azure Storage Account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountEndpoint
Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).

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

### System.String

## OUTPUTS

### System.Diagnostics.Process

## NOTES

## RELATED LINKS

[New-AzSftpCertificate](./New-AzSftpCertificate.md)

[Azure Storage SFTP Support](https://docs.microsoft.com/en-us/azure/storage/blobs/secure-file-transfer-protocol-support)

[Az.Storage Module](https://learn.microsoft.com/en-us/powershell/module/az.storage/)
