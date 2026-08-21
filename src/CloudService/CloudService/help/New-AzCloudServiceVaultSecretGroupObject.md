---
external help file: Az.CloudService-help.xml
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/Az.CloudService/new-azcloudservicevaultsecretgroupobject
schema: 2.0.0
---

# New-AzCloudServiceVaultSecretGroupObject

## SYNOPSIS
Create an in-memory object for CloudServiceVaultSecretGroup.

## SYNTAX

```
New-AzCloudServiceVaultSecretGroupObject [-Id <String>] [-CertificateUrl <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CloudServiceVaultSecretGroup.

## EXAMPLES

### Example 1: Create vault secret group object
```powershell
$keyVault = Get-AzKeyVault -VaultName 'ContosoKeyVault'
$certificate = Get-AzKeyVaultCertificate -VaultName 'ContosoKeyVault' -Name 'ContosoCert'
$secretGroup = New-AzCloudServiceVaultSecretGroupObject -Id $keyVault.ResourceId -CertificateUrl $certificate.SecretId
```

This command creates vault secret group object which is used for creating or updating a cloud service.
For more details see New-AzCloudService.

## PARAMETERS

### -CertificateUrl
This is the URL of a certificate that has been uploaded to Key Vault as a secret.

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

### -Id
Key Vault Resource Id.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.CloudServiceVaultSecretGroup

## NOTES

## RELATED LINKS
