---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version: https://docs.microsoft.com/powershell/module/az.monitor/get-azdatacollectionrule
schema: 2.0.0
---

# Get-AzDataCollectionRule

## SYNOPSIS
Gets data collection rule(s).

## SYNTAX

### BySubscription (Default)
```
Get-AzDataCollectionRule
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

### ByResourceGroup
```
Get-AzDataCollectionRule
   -ResourceGroupName <string>
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

### ByName
```
Get-AzDataCollectionRule
   -ResourceGroupName <string>
   -RuleName <string>
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

### ByResourceId
```
Get-AzDataCollectionRule
   -RuleId <string>
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataCollectionRule** cmdlet gets one or more data collection rules.

Data Collection Rules (DCR) define data coming into Azure Monitor and specify where that data should be sent or stored. Here is the complete [DCR overview article](https://docs.microsoft.com/azure/azure-monitor/platform/data-collection-rule-overview).

## EXAMPLES

### Example 1: Get data collection rules by subscription ID
```
PS C:\>Get-AzDataCollectionRule

Description       : DCR description
DataSources       : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDataSources
Destinations      : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDestinations
DataFlows         : {Microsoft.Azure.Commands.Insights.OutputClasses.PSDataFlow}
ProvisioningState : Succeeded
Etag              : "{etag}"
Id                : /subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr
Name              : testDcr
Type              : Microsoft.Insights/dataCollectionRules
Location          : East US 2 EUAP
Tags              : {[tag2, value2], [tag1, value1]}
```

This command lists all the data collection rules for the current subscription.

### Example 2: Get data collection rules for the given resource group
```
PS C:\>Get-AzDataCollectionRule -ResourceGroup "testgroup"

Description       : DCR description
DataSources       : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDataSources
Destinations      : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDestinations
DataFlows         : {Microsoft.Azure.Commands.Insights.OutputClasses.PSDataFlow}
ProvisioningState : Succeeded
Etag              : "{etag}"
Id                : /subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr
Name              : testDcr
Type              : Microsoft.Insights/dataCollectionRules
Location          : East US 2 EUAP
Tags              : {[tag2, value2], [tag1, value1]}
```

This command lists data collection rules for the given resource group.

### Example 3: Get a data collection rule
```
PS C:\>Get-AzDataCollectionRule -ResourceGroup "testgroup" -RuleName "testDcr"

Description       : DCR description
DataSources       : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDataSources
Destinations      : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDestinations
DataFlows         : {Microsoft.Azure.Commands.Insights.OutputClasses.PSDataFlow}
ProvisioningState : Succeeded
Etag              : "{etag}"
Id                : /subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr
Name              : testDcr
Type              : Microsoft.Insights/dataCollectionRules
Location          : East US 2 EUAP
Tags              : {[tag2, value2], [tag1, value1]}
```

This command lists one (a list with a single element) data collection rule.

### Example 4: Get a data collection rule by Rule ID
```
PS C:\>Get-AzDataCollectionRule -RuleId "/subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr"

Description       : DCR description
DataSources       : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDataSources
Destinations      : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDestinations
DataFlows         : {Microsoft.Azure.Commands.Insights.OutputClasses.PSDataFlow}
ProvisioningState : Succeeded
Etag              : "{etag}"
Id                : /subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr
Name              : testDcr
Type              : Microsoft.Insights/dataCollectionRules
Location          : East US 2 EUAP
Tags              : {[tag2, value2], [tag1, value1]}
```

This command lists one (a list with a single element) data collection rule.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: System.String
Parameter Sets: ByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleId
The ID of the resource.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource

## NOTES

## RELATED LINKS

[Set-AzDataCollectionRule](./Set-AzDataCollectionRule.md)
[Remove-AzDataCollectionRule](./Remove-AzDataCollectionRule.md)
[New-AzDataCollectionRule](./New-AzDataCollectionRule.md)
[Update-AzDataCollectionRule](./Update-AzDataCollectionRule.md)
