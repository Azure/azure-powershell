---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewkeyvaultconnection
schema: 2.0.0
---

# Get-AzPurviewKeyVaultConnection

## SYNOPSIS
Gets key vault information

## SYNTAX

### List (Default)
```
Get-AzPurviewKeyVaultConnection -Endpoint <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPurviewKeyVaultConnection -Endpoint <String> -KeyVaultName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

<<<<<<< HEAD
### GetViaIdentity
```
Get-AzPurviewKeyVaultConnection -Endpoint <String> -InputObject <IPurviewdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## DESCRIPTION
Gets key vault information

## EXAMPLES

### Example 1: Get key vault connection by name
```powershell
<<<<<<< HEAD
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection1'
```

```output
=======
PS C:\> Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection1'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
BaseUrl           : https://datascantestcases.vault.azure.net/
Description       : This is a Key Vault connection
Id                : keyVaults/KeyVaultConnection1
Name              : KeyVaultConnection1
```

Get key vault connection named 'KeyVaultConnection1'

### Example 2: Get all key vault connections
```powershell
<<<<<<< HEAD
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/'
```

```output
=======
PS C:\> Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
BaseUrl           : https://datascantestcases.vault.azure.net/
Description       : This is a Key Vault connection
Id                : keyVaults/KeyVaultConnection1
Name              : KeyVaultConnection1

BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection2
Name              : KeyVaultConnection2
```

Get all key vault connections

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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
Aliases:

Required: True
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

