---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/update-aznetappfilesbucket
schema: 2.0.0
---

# Update-AzNetAppFilesBucket

## SYNOPSIS
Updates an existing Azure NetApp Files (ANF) Bucket.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Update-AzNetAppFilesBucket -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 -VolumeName <String> -Name <String> [-Permissions <String>] [-NfsUserId <Int64>] [-NfsGroupId <Int64>]
 [-CifsUserName <String>] [-ServerFqdn <String>] [-ServerCertificateObject <String>]
 [-OnCertificateConflictAction <String>] [-CertificateKeyVaultUri <String>] [-CertificateName <String>]
 [-CredentialsKeyVaultUri <String>] [-CredentialsSecretName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzNetAppFilesBucket [-Name <String>] [-Permissions <String>] [-NfsUserId <Int64>] [-NfsGroupId <Int64>]
 [-CifsUserName <String>] [-ServerFqdn <String>] [-ServerCertificateObject <String>]
 [-OnCertificateConflictAction <String>] [-CertificateKeyVaultUri <String>] [-CertificateName <String>]
 [-CredentialsKeyVaultUri <String>] [-CredentialsSecretName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Update-AzNetAppFilesBucket -ResourceId <String> [-Permissions <String>] [-NfsUserId <Int64>]
 [-NfsGroupId <Int64>] [-CifsUserName <String>] [-ServerFqdn <String>] [-ServerCertificateObject <String>]
 [-OnCertificateConflictAction <String>] [-CertificateKeyVaultUri <String>] [-CertificateName <String>]
 [-CredentialsKeyVaultUri <String>] [-CredentialsSecretName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzNetAppFilesBucket -InputObject <PSNetAppFilesBucket> [-Permissions <String>] [-NfsUserId <Int64>]
 [-NfsGroupId <Int64>] [-CifsUserName <String>] [-ServerFqdn <String>] [-ServerCertificateObject <String>]
 [-OnCertificateConflictAction <String>] [-CertificateKeyVaultUri <String>] [-CertificateName <String>]
 [-CredentialsKeyVaultUri <String>] [-CredentialsSecretName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzNetAppFilesBucket** cmdlet patches an existing ANF Bucket. Only the properties supplied as parameters are modified; all others retain their current values. Use this cmdlet to change permissions, rotate the server certificate (inline or via Azure Key Vault), switch the filesystem user identity, or migrate the bucket from inline certificate management to AKV-managed certificate management.

## EXAMPLES

### Example 1: Change bucket permissions and refresh the inline certificate
```powershell
$newCertObject = [System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes((Get-Content -Raw ./bucket-new.pem)))

Update-AzNetAppFilesBucket -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfBucket" `
    -Permissions "ReadWrite" `
    -ServerCertificateObject $newCertObject `
    -OnCertificateConflictAction "Update"
```

Flips the bucket to ReadWrite and re-applies the server certificate using the new PEM blob.

### Example 2: Migrate certificate management to Azure Key Vault
```powershell
Update-AzNetAppFilesBucket -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfBucket" `
    -CertificateKeyVaultUri "https://anf-bucket-certs.vault.azure.net/" -CertificateName "anf-bucket-cert" `
    -OnCertificateConflictAction "Update"
```

Switches the bucket to fetch its server certificate from Azure Key Vault instead of using an inline PEM.

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateKeyVaultUri
Base URI of the Azure Key Vault used to retrieve the bucket server certificate.

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

### -CertificateName
Name of the bucket server certificate stored in Azure Key Vault.

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

### -CifsUserName
CIFS username accessing the bucket data (mutually exclusive with NfsUserId/NfsGroupId).

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

### -CredentialsKeyVaultUri
Base URI of the Azure Key Vault used to store the bucket credentials.

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

### -CredentialsSecretName
Name of the secret in Azure Key Vault holding the bucket credentials.

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

### -InputObject
The bucket object to update

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBucket
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ANF bucket

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: BucketName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByParentObjectParameterSet
Aliases: BucketName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NfsGroupId
NFS user GID accessing the bucket data.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NfsUserId
NFS user UID accessing the bucket data (mutually exclusive with CifsUserName).

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnCertificateConflictAction
Action when there is a certificate conflict.
Either Update or Fail.

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

### -Permissions
Access permissions for the bucket.
Either ReadOnly or ReadWrite.

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

### -PoolName
The name of the ANF capacity pool

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF bucket

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerCertificateObject
Base64-encoded contents of the PEM file containing the bucket server certificate and private key.

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

### -ServerFqdn
Host part of the bucket URL.

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

### -VolumeName
The name of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBucket

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBucket

## NOTES

## RELATED LINKS
