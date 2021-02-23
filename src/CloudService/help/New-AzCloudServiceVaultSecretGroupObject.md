---
external help file:
Module Name: Az.CloudService
online version: https://docs.microsoft.com/powershell/module/az.CloudService/new-AzCloudServiceVaultSecretGroupObject
schema: 2.0.0
---

# New-AzCloudServiceVaultSecretGroupObject

## SYNOPSIS
Create a in-memory object for Vault Secret Group

## SYNTAX

```
New-AzCloudServiceVaultSecretGroupObject [-CertificateUrl <String[]>] [-Id <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Secret Group

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

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultSecretGroup

## NOTES

ALIASES

## RELATED LINKS

