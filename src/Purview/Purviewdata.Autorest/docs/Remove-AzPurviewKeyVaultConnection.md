---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/remove-azpurviewkeyvaultconnection
schema: 2.0.0
---

# Remove-AzPurviewKeyVaultConnection

## SYNOPSIS
Deletes the key vault connection associated with the account

## SYNTAX

<<<<<<< HEAD
### Delete (Default)
=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```
Remove-AzPurviewKeyVaultConnection -Endpoint <String> -KeyVaultName <String> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

<<<<<<< HEAD
### DeleteViaIdentity
```
Remove-AzPurviewKeyVaultConnection -Endpoint <String> -InputObject <IPurviewdataIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## DESCRIPTION
Deletes the key vault connection associated with the account

## EXAMPLES

### Example 1: Remove a key vault connection
```powershell
<<<<<<< HEAD
Remove-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection5'
```

```output
=======
PS C:\> Remove-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection5'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection5
Name              : KeyVaultConnection5
```

Remove key vault connection named 'KeyVaultConnection5'

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
```

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
### -KeyVaultName
.

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: Delete
=======
Parameter Sets: (All)
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

<<<<<<< HEAD
### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IAzureKeyVault

## NOTES

ALIASES

<<<<<<< HEAD
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IPurviewdataIdentity>: Identity Parameter
  - `[ClassificationRuleName <String>]`: 
  - `[ClassificationRuleVersion <Int32?>]`: 
  - `[DataSourceName <String>]`: 
  - `[DataSourceType <DataSourceType?>]`: 
  - `[Id <String>]`: Resource identity path
  - `[KeyVaultName <String>]`: 
  - `[RunId <String>]`: 
  - `[ScanName <String>]`: 
  - `[ScanRulesetName <String>]`: 
  - `[Version <Int32?>]`: 

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## RELATED LINKS

