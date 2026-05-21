---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/set-azstorageadvancedplatformmetric
schema: 2.0.0
---

# Set-AzStorageAdvancedPlatformMetric

## SYNOPSIS
Update the advanced platform metrics rule for the storage account.

## SYNTAX

```
Set-AzStorageAdvancedPlatformMetric -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Enabled] [-RuleConfigFilterType <String>] [-RuleConfigFilterValue <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update the advanced platform metrics rule for the storage account.

## EXAMPLES

### Example 1: Enable advanced platform metrics for all containers
```powershell
Set-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup -RuleConfigFilterType AllContainersFilter -Enabled
```

```output
Enabled                      : True
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
LastModifiedTime             : 5/20/2026 7:00:10 AM
MetricsEmitted               : {ContainerUsedSize, ContainerBlobCount}
Name                         : DefaultAdvancedPlatformMetricsRule
ResourceGroupName            : myresourcegroup
RuleConfigFilterType         : AllContainersFilter
RuleConfigFilterValue        :
RuleType                     : ContainerLevelCapacityMetrics
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Storage/storageAccounts/advancedPlatformMetrics
```

This command enables advanced platform metrics for all containers in the storage account mystorageaccount.

### Example 2: Enable advanced platform metrics with container prefix filter
```powershell
Set-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup -RuleConfigFilterType ContainerPrefixFilter -RuleConfigFilterValue @("logs", "data") -Enabled
```

```output
Enabled                      : True
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
LastModifiedTime             : 5/20/2026 6:57:59 AM
MetricsEmitted               : {ContainerUsedSize, ContainerBlobCount}
Name                         : DefaultAdvancedPlatformMetricsRule
ResourceGroupName            : myresourcegroup
RuleConfigFilterType         : ContainerPrefixFilter
RuleConfigFilterValue        : {logs, data}
RuleType                     : ContainerLevelCapacityMetrics
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Storage/storageAccounts/advancedPlatformMetrics
```

This command enables advanced platform metrics for containers with prefixes "logs" and "data" in the storage account mystorageaccount.

### Example 3: Enable advanced platform metrics with specific container list
```powershell
Set-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup -RuleConfigFilterType ContainerListFilter -RuleConfigFilterValue @("container1", "container2", "container3") -Enabled
```

```output
Enabled                      : True
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
LastModifiedTime             : 5/20/2026 6:46:04 AM
MetricsEmitted               : {ContainerUsedSize, ContainerBlobCount}
Name                         : DefaultAdvancedPlatformMetricsRule
ResourceGroupName            : myresourcegroup
RuleConfigFilterType         : ContainerListFilter
RuleConfigFilterValue        : {container1, container2, container3}
RuleType                     : ContainerLevelCapacityMetrics
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Storage/storageAccounts/advancedPlatformMetrics
```

This command enables advanced platform metrics for specific containers (container1, container2, and container3) in the storage account mystorageaccount.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

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

### -Enabled
A boolean flag which enables the advanced platform metrics rule.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -RuleConfigFilterType
The type of filter applied to the rule.
Possible values include: AllContainersFilter, ContainerPrefixFilter, ContainerListFilter.

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

### -RuleConfigFilterValue
The values for the filter applied to the rule.
If filter type is AllContainersFilter, filter values should be empty.
If filter type is ContainerPrefixFilter, filter values should contain a list of container prefixes.
If filter type is ContainerListFilter, filter values should contain a list of container names.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IAdvancedPlatformMetricsRule

## NOTES

## RELATED LINKS
