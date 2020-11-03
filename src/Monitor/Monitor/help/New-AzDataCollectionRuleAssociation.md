---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/new-azdatacollectionruleassociation
schema: 2.0.0
---

# New-AzDataCollectionRuleAssociation

## SYNOPSIS
Create data collection rule association.

## SYNTAX

### ByDataCollectionRuleId (Default)
```
New-AzDataCollectionRuleAssociation
  -ResourceUri <string>
  -Name <string>
  -DataCollectionRuleId <string>
  [-Description <string>]
  [-DefaultProfile <IAzureContextContainer>]
  [-WhatIf]
  [-Confirm]
  [<CommonParameters>]
```

### ByInputObject
```
New-AzDataCollectionRuleAssociation
  -ResourceUri <string>
  -Name <string>
  -InputObject <PSDataCollectionRuleResource>
  [-Description <string>]
  [-DefaultProfile <IAzureContextContainer>]  
  [-WhatIf]   
  [-Confirm]   
  [<CommonParameters>]
```


## DESCRIPTION
The **New-AzDataCollectionRuleAssociation** cmdlet creates a data collection rules association.
[Overview](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/data-collection-rule-overview)

## EXAMPLES

### Example 1: Create data collection rule association
```
PS C:\>$dcr = Get-AzDataCollectionRule -ResourceGroupName $rg -Name $dcrName
PS C:\>$vmId = '/subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}'
PS C:\>New-AzDataCollectionRuleAssociation -ResourceUri $vmId -Name "dcrAssoc" -DataCollectionRuleId $dcr.Id

Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/dcrAssoc
Name                 : dcrAssoc
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
Location             :
Tags                 :
```

This command creates a data collection rule association for the current subscription.



### Example 2: Create data collection rule association from a DCR object
```
PS C:\>$vmId = '/subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}'
PS C:\>Get-AzDataCollectionRule -ResourceGroupName $rg -Name $dcrName | New-AzDataCollectionRuleAssociation -ResourceUri $vmId -Name "dcrAssocInput"

Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/dcrAssocInput
Name                 : dcrAssocInput
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
Location             :
Tags                 :
```

This command creates a data collection rules for the current subscription.

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

### -ResourceUri
The resource id to associate

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
The resource name

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

### -DataCollectionRuleId
The data collection rule id

```yaml
Type: System.String
Parameter Sets: ByDataCollectionRuleId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
PSDataCollectionRuleResource Object

```yaml
Type: System.String
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True
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

[Set-AzDataCollectionRuleAssociation](./Set-AzDataCollectionRuleAssociation.md)
[Remove-AzDataCollectionRuleAssociation](./Remove-AzDataCollectionRuleAssociation.md)
[Get-AzDataCollectionRuleAssociation](./Get-AzDataCollectionRuleAssociation.md)
