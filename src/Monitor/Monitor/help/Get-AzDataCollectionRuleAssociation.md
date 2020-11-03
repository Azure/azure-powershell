---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-azdatacollectionruleassociation
schema: 2.0.0
---

# Get-AzDataCollectionRuleAssociation

## SYNOPSIS
Gets data collection rule association(s).

## SYNTAX

### ByAssociatedResource (Default)
```
Get-AzDataCollectionRuleAssociation 
   -ResourceUri <string> 
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

### ByRule
```
Get-AzDataCollectionRuleAssociation 
   -ResourceGroupName <string> 
   -DataCollectionRuleName <string> 
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

### ByInputObject
```
Get-AzDataCollectionRuleAssociation 
   -InputObject <PSDataCollectionRuleResource> 
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]
```

### ByName
```
Get-AzDataCollectionRuleAssociation 
   -ResourceUri <string> 
   -Name <string> 
   [-DefaultProfile <IAzureContextContainer>] 
   [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataCollectionRuleAssociation** cmdlet gets one or more data collection rules associations.
[Overview](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/data-collection-rule-overview)

## EXAMPLES

### Example 1: Get data collection rules associations by resource uri (associated virtual machines)
```
PS C:\>$vm = Get-AzVM -ResourceGroupName $rg -Name $vmName
PS C:\>Get-AzDataCollectionRuleAssociation -ResourceUri $vm.Id

Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.I
                       nsights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.C
                       ompute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/{assocName}
Name                 : {assocName}
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```

This command lists all the data collection rules for the given resource id (virtual machine).

### Example 2: Get data collection rules associations by rule (DCR)
```
PS C:\>Get-AzDataCollectionRule -ResourceGroup $rg -DataCollectionRuleName $dcrName

Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.I
                       nsights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.C
                       ompute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/{assocName}
Name                 : {assocName}
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```

This command lists data collection rules associations for the given resource group and rule (DCR).

### Example 3: Get data collection rule associations by input object (PSDataCollectionRuleResource)
```
PS C:\>$dcr = Get-AzDataCollectionRule -ResourceGroupName $rg -Name $dcrName
PS C:\>$dcr | Get-AzDataCollectionRuleAssociation

Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.I
                       nsights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.C
                       ompute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/{assocName}
Name                 : {assocName}
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```

This command lists data collection rules associations for the given input object.

### Example 4: Get a data collection rule association by resource uri (associated virtual machines) and association name
```
PS C:\>Get-AzDataCollectionRuleAssociation -ResourceUri $vm.Id -Name $assocName

Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.I
                       nsights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.C
                       ompute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/{assocName}
Name                 : {assocName}
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```

This command lists one (a list with a single element) data collection rule association.

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
The associated resource id

```yaml
Type: System.String
Parameter Sets: ByAssociatedResource (Default)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: System.String
Parameter Sets: ByRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DataCollectionRuleName
The data collection rule name

```yaml
Type: System.String
Parameter Sets: ByRule
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
Type: Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True
Accept wildcard characters: False
```

### -Name
The name of the association.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
### Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleAssociationProxyOnlyResource

## NOTES

## RELATED LINKS

[Remove-AzDataCollectionRuleAssociation](./Remove-AzDataCollectionRuleAssociation.md)
[New-AzDataCollectionRuleAssociation](./New-AzDataCollectionRuleAssociation.md)
