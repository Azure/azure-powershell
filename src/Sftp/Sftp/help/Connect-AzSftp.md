---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sftp.dll-Help.xml
Module Name: Az.Sftp
online version: https://docs.microsoft.com/powershell/module/az.sftp/connect-azsftp
schema: 2.0.0
---

# Connect-AzSftp

## SYNOPSIS
Connect to Azure Storage Account via SFTP protocol.

## SYNTAX

### Default (Default)
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] [-PrivateKeyFile <String>] [-PublicKeyFile <String>]
 [-SftpArg <String[]>] [-SshClientFolder <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### CertificateAuth
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] -CertificateFile <String> -PrivateKeyFile <String>
 [-SftpArg <String[]>] [-SshClientFolder <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### PublicKeyAuth
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] -PublicKeyFile <String> [-SftpArg <String[]>]
 [-SshClientFolder <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### LocalUserAuth
```
Connect-AzSftp -StorageAccount <String> [-Port <Int32>] -LocalUser <String> [-PrivateKeyFile <String>]
 [-SftpArg <String[]>] [-SshClientFolder <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Connect-AzSftp cmdlet establishes an SFTP connection to an Azure Storage account. These commands allow you to connect to Azure Storage Accounts using SFTP with multiple authentication modes that align with the Az.Ssh module capabilities.

The cmdlet supports four authentication modes:

**Azure AD Authentication (Recommended)**: When no authentication parameters are specified, the cmdlet automatically generates a short-lived SSH certificate using your current Azure AD credentials. This certificate is valid for authentication to SFTP-enabled storage accounts where your Azure AD identity has appropriate permissions. The certificate is temporarily stored alongside the generated private key for proper SSH client discovery.

**Certificate-based Authentication**: Use existing SSH certificates that have been signed by Azure AD's trusted CA, along with the corresponding private key. This is equivalent to the SSH module's certificate authentication. The certificate file must be positioned correctly relative to the private key for SSH client auto-discovery.

**SSH Key Authentication**: Use SSH public key authentication with keys that are configured on the storage account's local users. This matches the SSH module's key-based authentication.

**Local User Authentication**: Connect to local user accounts configured on the storage account. You can provide a private key for key-based authentication or rely on interactive authentication (username/password) for the local user.

The target storage account must have SFTP enabled and hierarchical namespace (HNS) enabled. For Azure AD authentication, your Azure AD identity must have appropriate RBAC permissions such as Storage Blob Data Contributor or Storage Blob Data Owner.

## PARAMETERS

### -StorageAccount
Specifies the Azure Storage account name for SFTP connection. The storage account must have SFTP enabled and hierarchical namespace (HNS) enabled.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
Specifies the SFTP port. If not specified, uses SSH default port (22). Most Azure Storage accounts use the default SFTP port.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 22
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateFile
Specifies the path to SSH certificate file for authentication. This should be an OpenSSH certificate (typically with .cert or -cert.pub extension) that was signed by an Azure AD trusted CA. Must be used with -PrivateKeyFile parameter.

```yaml
Type: String
Parameter Sets: CertificateAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyFile
Specifies the path to SSH private key file for authentication. 

- **Required for CertificateAuth parameter set**: Must be used with -CertificateFile parameter.
- **Optional for Default parameter set**: When provided without certificate, a certificate will be generated automatically from this key using Azure AD.
- **Optional for LocalUserAuth parameter set**: Used for SSH key authentication with local user accounts. If not provided, falls back to interactive authentication.

The private key must correspond to any associated certificate or public key and should be protected with appropriate file permissions.

```yaml
Type: String
Parameter Sets: CertificateAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Default, LocalUserAuth
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicKeyFile
Specifies the path to SSH public key file for authentication.

- **Required for PublicKeyAuth parameter set**: Used for traditional SSH key authentication when the public key is configured on the storage account's local users.
- **Optional for Default parameter set**: When provided without certificate, a certificate will be generated automatically from this key using Azure AD.

The cmdlet can automatically generate a certificate from this key when needed for Azure AD authentication.

```yaml
Type: String
Parameter Sets: PublicKeyAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalUser
Specifies the username for a local user account configured on the storage account. When this parameter is used, the cmdlet will connect using local user authentication instead of Azure AD authentication.

- Can be combined with -PrivateKeyFile for SSH key-based authentication
- If no -PrivateKeyFile is provided, falls back to interactive authentication (username/password)
- The local user must be properly configured on the target storage account

```yaml
Type: String
Parameter Sets: LocalUserAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SftpArg
Specifies additional arguments to pass to the underlying sftp command. Common options include:
- `-v` for verbose output
- `-b <batchfile>` for batch commands
- `-o <option>` for SSH options like ConnectTimeout, StrictHostKeyChecking
- `-P <port>` for custom port (alternative to -Port parameter)

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshClientFolder
Specifies the folder path that contains SSH executables (ssh-keygen, sftp). If not specified, the cmdlet searches for SSH executables in the following order:
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

### System.Diagnostics.Process
Returns the SFTP client process object for the active connection. This allows you to monitor the connection status and interact with the SFTP session.

## NOTES
- Requires SFTP to be enabled on the target Azure Storage account
- Storage account must have hierarchical namespace (HNS) enabled
- When using automatic Azure AD authentication, temporary certificate files are created in the system temp directory and cleaned up automatically
- The cmdlet launches an interactive SFTP session unless batch commands are provided via -SftpArg
- Azure AD-generated certificates are typically valid for 1 hour for security purposes
- For local user authentication, the user account must be properly configured on the storage account
- Interactive authentication (username/password) is available when using -LocalUser without -PrivateKeyFile
- This cmdlet now provides the same authentication methods as the Az.Ssh module for consistency

### Common Authentication Issues
If you encounter "Permission denied (publickey,password)" errors:

1. **For Azure AD authentication**: Ensure you are logged in with `Connect-AzAccount` and have the appropriate RBAC permissions (Storage Blob Data Contributor or Storage Blob Data Owner) on the storage account.

2. **For certificate authentication**: Verify that both the certificate and private key files exist and are accessible. The certificate should be signed by Azure AD's trusted CA.

3. **For SSH key authentication**: Ensure the public key is properly configured on the storage account's local users and the corresponding private key is available.

4. **Storage account configuration**: Verify that SFTP is enabled and hierarchical namespace is enabled on the storage account.

## EXAMPLES

### Example 1: Connect using Azure AD authentication (automatic)
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount"
```

This command connects to the storage account using your current Azure AD credentials. A temporary SSH certificate is automatically generated and used for authentication. This is the recommended approach as it requires no manual certificate management and matches the SSH module's default authentication.

### Example 2: Connect using existing certificate and private key
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -CertificateFile "C:\certs\azure-sftp.cert" -PrivateKeyFile "C:\certs\azure-sftp-key"
```

This command connects to the storage account using an existing SSH certificate and private key. The certificate should have been generated using Azure AD credentials and signed by Azure's trusted CA. This matches the SSH module's certificate-based authentication. Ensure that the private key file is securely stored and not accessible to unauthorized users.

### Example 3: Connect using SSH public key authentication
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -PublicKeyFile "C:\keys\id_rsa.pub"
```

This command connects to the storage account using SSH key authentication with a public key. The public key must be configured on the storage account's local users. The corresponding private key must be available in the default SSH location or SSH agent. This is equivalent to the SSH module's key-based authentication.

### Example 4: Connect to local user with SSH key authentication
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -LocalUser "sftpuser" -PrivateKeyFile "C:\keys\id_rsa"
```

This command connects to a local user account on the storage account using SSH key authentication. The private key must correspond to a public key configured for the specified local user. This matches the SSH module's local user authentication with keys.

### Example 5: Connect to local user with interactive authentication
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -LocalUser "sftpuser"
```

This command connects to a local user account using interactive authentication. The user will be prompted for a password when the SFTP connection is established. This is equivalent to the SSH module's interactive authentication for local users.

### Example 6: Connect with custom port and verbose output
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -Port 2022 -SftpArg "-v"
```

This command connects to the storage account using a non-default SFTP port (2022) and enables verbose output to help with troubleshooting connection issues.

### Example 7: Connect with batch commands
```powershell
# Create batch file with SFTP commands
@"
cd uploads
put C:\local\file.txt
ls -la
quit
"@ | Out-File -FilePath "C:\temp\batch.sftp" -Encoding ASCII

# Execute batch commands
Connect-AzSftp -StorageAccount "mystorageaccount" -SftpArg "-b", "C:\temp\batch.sftp"
```

This command connects to the storage account and executes a series of SFTP commands from a batch file, including changing directory, uploading a file, listing contents, and quitting.

### Example 8: Connect with custom SSH client location
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -SshClientFolder "C:\Program Files\OpenSSH"
```

This command connects to the storage account using SSH executables from a custom location. This is useful when you have multiple SSH implementations installed or when the SSH client is not in the default PATH.

### Example 9: Connect with advanced SSH options
```powershell
Connect-AzSftp -StorageAccount "mystorageaccount" -SftpArg "-o", "ConnectTimeout=30", "-o", "StrictHostKeyChecking=no", "-v"
```

This command connects with a custom connection timeout of 30 seconds, disables strict host key checking for this session, and enables verbose output for debugging.

### Example 10: Connect with certificate from existing SSH keys
```powershell
# Use existing SSH keys to generate a certificate automatically
Connect-AzSftp -StorageAccount "mystorageaccount" -PrivateKeyFile "C:\keys\id_rsa" -PublicKeyFile "C:\keys\id_rsa.pub"
```

This command connects to the storage account using existing SSH keys. The cmdlet will automatically generate a certificate from the provided keys using Azure AD authentication.

### Example 11: Troubleshoot authentication issues
```powershell
# Check Azure AD authentication status
Get-AzContext

# Test certificate generation explicitly
$cert = New-AzSftpCertificate -CertificatePath "C:\temp\test-cert.pub"
Write-Host "Certificate generated: $($cert.CertificatePath)"
Write-Host "Principal: $($cert.Principal)"

# Connect using the generated certificate
Connect-AzSftp -StorageAccount "mystorageaccount" -CertificateFile $cert.CertificatePath -PrivateKeyFile $cert.PrivateKeyPath -SftpArg "-v"
```

This example shows how to troubleshoot authentication issues by explicitly generating a certificate first and using verbose SFTP output to diagnose connection problems.

## RELATED LINKS

[New-AzSftpCertificate](./New-AzSftpCertificate.md)

[Azure Storage SFTP Support](https://docs.microsoft.com/en-us/azure/storage/blobs/secure-file-transfer-protocol-support)

[Az.Storage Module](https://docs.microsoft.com/en-us/powershell/module/az.storage/)
