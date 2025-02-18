---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewsystemscanrulesetlatest
schema: 2.0.0
---

# Get-AzPurviewSystemScanRulesetLatest

## SYNOPSIS
Get the latest version of a system scan ruleset

## SYNTAX

```
Get-AzPurviewSystemScanRulesetLatest -Endpoint <String> [-DataSourceType <DataSourceType>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the latest version of a system scan ruleset

## EXAMPLES

### Example 1: Get latest system scan ruleset available for a data source
```powershell
Get-AzPurviewSystemScanRulesetLatest -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'
```

```output
Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 4
```

Get latest system scan ruleset available for a data source

## PARAMETERS

### -DataSourceType
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.DataSourceType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.ISystemScanRuleset

## NOTES

## RELATED LINKS

