---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/get-azkeyvaultdeletedstoragedeletedsasdefinition
schema: 2.0.0
---

# Get-AzKeyVaultDeletedStorageDeletedSasDefinition

## SYNOPSIS
The Get Deleted Sas Definitions operation returns the SAS definitions that have been deleted for a vault enabled for soft-delete.
This operation requires the storage/listsas permission.

## SYNTAX

### Get (Default)
```
Get-AzKeyVaultDeletedStorageDeletedSasDefinition -StorageAccountName <String> [-VaultBaseUrl <String>]
 [-Maxresult <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzKeyVaultDeletedStorageDeletedSasDefinition -StorageAccountName <String> -SasDefinitionName <String>
 [-VaultBaseUrl <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzKeyVaultDeletedStorageDeletedSasDefinition -InputObject <IKeyVaultIdentity> [-VaultBaseUrl <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKeyVaultDeletedStorageDeletedSasDefinition -InputObject <IKeyVaultIdentity> [-VaultBaseUrl <String>]
 [-Maxresult <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The Get Deleted Sas Definitions operation returns the SAS definitions that have been deleted for a vault enabled for soft-delete.
This operation requires the storage/listsas permission.

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
Parameter Sets: GetViaIdentity1, GetViaIdentity
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
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SasDefinitionName
The name of the SAS definition.

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

### -StorageAccountName
The name of the storage account.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api70.IDeletedSasDefinitionItem

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api70.IDeletedSasDefinitionBundle

## ALIASES

## RELATED LINKS

