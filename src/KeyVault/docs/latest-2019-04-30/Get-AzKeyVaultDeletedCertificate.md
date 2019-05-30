---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/get-azkeyvaultdeletedcertificate
schema: 2.0.0
---

# Get-AzKeyVaultDeletedCertificate

## SYNOPSIS
The GetDeletedCertificates operation retrieves the certificates in the current vault which are in a deleted state and ready for recovery or purging.
This operation includes deletion-specific information.
This operation requires the certificates/get/list permission.
This operation can only be enabled on soft-delete enabled vaults.

## SYNTAX

### Get (Default)
```
Get-AzKeyVaultDeletedCertificate [-VaultBaseUrl <String>] [-Maxresult <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzKeyVaultDeletedCertificate -CertificateName <String> [-VaultBaseUrl <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKeyVaultDeletedCertificate -InputObject <IKeyVaultIdentity> [-VaultBaseUrl <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The GetDeletedCertificates operation retrieves the certificates in the current vault which are in a deleted state and ready for recovery or purging.
This operation includes deletion-specific information.
This operation requires the certificates/get/list permission.
This operation can only be enabled on soft-delete enabled vaults.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CertificateName
The name of the certificate

```yaml
Type: System.String
Parameter Sets: Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Maxresult
Maximum number of results to return in a page.
If not specified the service will return up to 25 results.

```yaml
Type: System.Int32
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultBaseUrl
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedCertificateItem

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedCertificateBundle

## ALIASES

## RELATED LINKS

