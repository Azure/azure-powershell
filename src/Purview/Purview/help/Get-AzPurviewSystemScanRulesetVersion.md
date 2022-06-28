---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.purview/get-azpurviewsystemscanrulesetversion
schema: 2.0.0
---

# Get-AzPurviewSystemScanRulesetVersion

## SYNOPSIS
List system scan ruleset versions in Data catalog

## SYNTAX

```
Get-AzPurviewSystemScanRulesetVersion -Endpoint <String> [-DataSourceType <DataSourceType>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List system scan ruleset versions in Data catalog

## EXAMPLES

### Example 1: Get all versions of system scanruleset available for a data source
```powershell
Get-AzPurviewSystemScanRulesetVersion -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'
```

```output
Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 4

Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 3

Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 2

Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 1
```

Get all versions of system scanruleset available for a data source

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.ISystemScanRuleset

## NOTES

ALIASES

## RELATED LINKS
