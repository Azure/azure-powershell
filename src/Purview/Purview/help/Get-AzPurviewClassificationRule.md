---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewclassificationrule
schema: 2.0.0
---

# Get-AzPurviewClassificationRule

## SYNOPSIS
Get a classification rule

## SYNTAX

### List (Default)
```
Get-AzPurviewClassificationRule -Endpoint <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPurviewClassificationRule -Endpoint <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a classification rule

## EXAMPLES

### Example 1: Get custom classification rule by name
```powershell
Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/ -Name ClassificationRule1
```

```output
ClassificationAction   : Keep
ClassificationName     : ClassificationName1
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column1"
                         }}
CreatedAt              : 1/27/2022 4:36:25 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{5}$"
                         }}
Description            : This is a description
Id                     : classificationrules/ClassificationRule1
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:36:25 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule1
RuleStatus             : Enabled
Version                : 1
```

Get classification rule named Classification1

### Example 2: Get all custom classification rules
```powershell
Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/
```

```output
ClassificationAction   : Keep
ClassificationName     : ClassificationName1
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column1"
                         }}
CreatedAt              : 1/27/2022 4:36:25 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{5}$"
                         }}
Description            : This is a description
Id                     : classificationrules/ClassificationRule1
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:36:25 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule1
RuleStatus             : Enabled
Version                : 1

ClassificationAction   : Keep
ClassificationName     : ClassificationName2
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column2"
                         }}
CreatedAt              : 1/27/2022 4:37:09 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{6}$"
                         }}
Description            : This is description
Id                     : classificationrules/ClassificationRule2
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:37:09 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule2
RuleStatus             : Enabled
Version                : 1
```

Get all custom classification rules

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

### -Name
.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ClassificationRuleName

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IClassificationRule

## NOTES

## RELATED LINKS
