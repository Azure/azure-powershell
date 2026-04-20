---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilesbucket
schema: 2.0.0
---

# New-AzNetAppFilesBucket

## SYNOPSIS
Creates a new Bucket on an Azure NetApp Files (ANF) Volume.

## SYNTAX

### ByFieldsParameterSet (Default)
```
New-AzNetAppFilesBucket -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 -VolumeName <String> -Name <String> [-Path <String>] [-Permissions <String>] [-NfsUserId <Int64>]
 [-NfsGroupId <Int64>] [-CifsUserName <String>] [-ServerFqdn <String>] [-ServerCertificateObject <String>]
 [-OnCertificateConflictAction <String>] [-CertificateKeyVaultUri <String>] [-CertificateName <String>]
 [-CredentialsKeyVaultUri <String>] [-CredentialsSecretName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzNetAppFilesBucket -Name <String> [-Path <String>] [-Permissions <String>] [-NfsUserId <Int64>]
 [-NfsGroupId <Int64>] [-CifsUserName <String>] [-ServerFqdn <String>] [-ServerCertificateObject <String>]
 [-OnCertificateConflictAction <String>] [-CertificateKeyVaultUri <String>] [-CertificateName <String>]
 [-CredentialsKeyVaultUri <String>] [-CredentialsSecretName <String>] -VolumeObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetAppFilesBucket** cmdlet creates a Bucket on an ANF Volume. Buckets expose volume data to external services (for example, AI services) over an S3-compatible endpoint and require a certificate on the bucket server (provided inline via **ServerCertificateObject** or managed from Azure Key Vault via **CertificateKeyVaultUri** / **CertificateName**).
The filesystem user identity accessing the volume data must be supplied either via **NfsUserId** / **NfsGroupId** (NFS) or **CifsUserName** (SMB).

## EXAMPLES

### Example 1: Create a Bucket with an inline self-signed certificate
```powershell
$certObject = [System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes((Get-Content -Raw ./bucket.pem)))

New-AzNetAppFilesBucket -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfBucket" `
    -Path "/" -Permissions "ReadOnly" `
    -NfsUserId 1000 -NfsGroupId 1000 `
    -ServerFqdn "bucket.contoso.local" `
    -ServerCertificateObject $certObject `
    -OnCertificateConflictAction "Update"
```

Creates a ReadOnly Bucket that exposes the volume root to an NFS user 1000:1000, using an inline PEM-encoded cert+key pair.
Setting **OnCertificateConflictAction** to `Update` allows the bucket server to reuse/refresh an existing certificate without failing.

### Example 2: Create a Bucket with AKV-managed certificate and credentials
```powershell
New-AzNetAppFilesBucket -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfBucket" `
    -Path "/data" -Permissions "ReadWrite" -CifsUserName "anfuser" `
    -ServerFqdn "bucket.contoso.local" -OnCertificateConflictAction "Update" `
    -CertificateKeyVaultUri "https://anf-bucket-certs.vault.azure.net/" -CertificateName "anf-bucket-cert" `
    -CredentialsKeyVaultUri "https://anf-bucket-creds.vault.azure.net/" -CredentialsSecretName "anf-bucket-creds"
```

Creates a ReadWrite Bucket whose server certificate is fetched from Azure Key Vault and whose generated access/secret key pair will be stored back in Azure Key Vault.

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

### -Name
The name of the ANF bucket

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BucketName

Required: True
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

### -Path
The volume path mounted inside the bucket.
Defaults to '/'.

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
Defaults to ReadOnly.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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

### -ServerCertificateObject
Base64-encoded contents of the PEM file containing the bucket server certificate and private key.
Mutually exclusive with the AKV certificate parameters.

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
Host part of the bucket URL, resolving to the bucket IP and allowed by the server certificate.

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

### -VolumeObject
The volume object containing the new bucket

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBucket

## NOTES

## RELATED LINKS
