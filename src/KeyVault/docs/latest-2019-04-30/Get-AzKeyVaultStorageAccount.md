---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/get-azkeyvaultstorageaccount
schema: 2.0.0
---

# Get-AzKeyVaultStorageAccount

## SYNOPSIS
List storage accounts managed by the specified key vault.
This operation requires the storage/list permission.

## SYNTAX

### Get (Default)
```
Get-AzKeyVaultStorageAccount [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-MaxResult <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKeyVaultStorageAccount -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzKeyVaultStorageAccount -Name <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetDeleted
```
Get-AzKeyVaultStorageAccount -InRemovedState [-VaultBaseUrl <String>] [-MaxResult <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetDeleted1
```
Get-AzKeyVaultStorageAccount -Name <String> -InRemovedState [-VaultBaseUrl <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List storage accounts managed by the specified key vault.
This operation requires the storage/list permission.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InRemovedState
Signals that deleted key vault storage accounts should be returned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetDeleted, GetDeleted1
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultDnsSuffix
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity, Get1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxResult
Maximum number of results to return in a page.
If not specified the service will return up to 25 results.

```yaml
Type: System.Int32
Parameter Sets: Get, GetDeleted
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the storage account.

```yaml
Type: System.String
Parameter Sets: Get1, GetDeleted1
Aliases: StorageAccountName

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
Parameter Sets: GetDeleted, GetDeleted1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultName
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity, Get1
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IStorageAccountItem

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IStorageBundle

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api70.IDeletedStorageAccountItem

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api70.IDeletedStorageBundle

## ALIASES

### Get-AzKeyVaultManagedStorageAccount

## NOTES

## RELATED LINKS

