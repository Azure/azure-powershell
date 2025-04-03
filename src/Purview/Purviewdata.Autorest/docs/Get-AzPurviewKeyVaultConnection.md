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

## DESCRIPTION
Gets key vault information

## EXAMPLES

### Example 1: Get key vault connection by name
```powershell
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection1'
```

```output
BaseUrl           : https://datascantestcases.vault.azure.net/
Description       : This is a Key Vault connection
Id                : keyVaults/KeyVaultConnection1
Name              : KeyVaultConnection1
```

Get key vault connection named 'KeyVaultConnection1'

### Example 2: Get all key vault connections
```powershell
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/'
```

```output
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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IAzureKeyVault

## NOTES

## RELATED LINKS

