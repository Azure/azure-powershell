---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version: https://docs.microsoft.com/powershell/module/az.monitor/new-azdatacollectionruleassociation
schema: 2.0.0
---

# New-AzDataCollectionRuleAssociation

## SYNOPSIS
Create data collection rule association.

## SYNTAX

### ByDataCollectionRuleId (Default)
```
New-AzDataCollectionRuleAssociation -TargetResourceId <String> -AssociationName <String> -RuleId <String>
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
New-AzDataCollectionRuleAssociation -TargetResourceId <String> -AssociationName <String>
 [-Description <String>] -InputObject <PSDataCollectionRuleResource> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDataCollectionRuleAssociation** cmdlet creates a data collection rules association (DCRA).

To apply a DCR to a virtual machine, you create an association for the virtual machine. A virtual machine may have an association to multiple DCRs, and a DCR may have multiple virtual machines associated to it. This allows you to define a set of DCRs, each matching a particular requirement, and apply them to only the virtual machines where they apply. Here is the ["Configure data collection for the Azure Monitor agent"](https://docs.microsoft.com/azure/azure-monitor/platform/data-collection-rule-azure-monitor-agent) using DCRA article.

## EXAMPLES

### Example 1: Create data collection rule association
```powershell
$dcr = Get-AzDataCollectionRule -ResourceGroupName $rg -RuleName $dcrName
$vmId = '/subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}'
New-AzDataCollectionRuleAssociation -TargetResourceId $vmId -AssociationName "dcrAssoc" -RuleId $dcr.Id
```

```output
Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/dcrAssoc
Name                 : dcrAssoc
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```

This command creates a data collection rule association for given rule and target resource ID.

### Example 2: Create data collection rule association from a DCR object
```powershell
$dcr = Get-AzDataCollectionRule -ResourceGroupName $rg -RuleName $dcrName
$vmId = '/subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}'
$dcr | New-AzDataCollectionRuleAssociation -TargetResourceId $vmId -AssociationName "dcrAssocInput"
```

```output
Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/dcrAssocInput
Name                 : dcrAssocInput
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```

This command creates a data collection rule association for given rule and target resource ID.

## PARAMETERS

### -AssociationName
The resource name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Description
The resource description

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
PSDataCollectionRuleResource Object

```yaml
Type: Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RuleId
The data collection rule ID

```yaml
Type: System.String
Parameter Sets: ByDataCollectionRuleId
Aliases: DataCollectionRuleId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
The resource ID to associate

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceUri

Required: True
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleAssociationProxyOnlyResource

## NOTES

## RELATED LINKS

[Remove-AzDataCollectionRuleAssociation](./Remove-AzDataCollectionRuleAssociation.md)
[Get-AzDataCollectionRuleAssociation](./Get-AzDataCollectionRuleAssociation.md)
