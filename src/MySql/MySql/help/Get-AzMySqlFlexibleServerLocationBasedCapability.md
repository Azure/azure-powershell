---
external help file: Az.MySql-help.xml
Module Name: Az.MySql
online version: https://learn.microsoft.com/powershell/module/az.mysql/get-azmysqlflexibleserverlocationbasedcapability
schema: 2.0.0
---

# Get-AzMySqlFlexibleServerLocationBasedCapability

## SYNOPSIS
Get the available SKU information for the location

## SYNTAX

```
Get-AzMySqlFlexibleServerLocationBasedCapability -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the available SKU information for the location

## EXAMPLES

### Example 1: Get location capabilities by location name
```powershell
Get-AzMySqlFlexibleServerLocationBasedCapability -Location westus2
```

```output
"Please refer to https://aka.ms/mysql-pricing for pricing details"

SKU               Memory Tier            vCore
---               ------ ----            -----
Standard_B1s        1024 Burstable           1
Standard_B1ms       2048 Burstable           1
Standard_B2s        2048 Burstable           2
Standard_D2ds_v4    4096 GeneralPurpose      2
Standard_D4ds_v4    4096 GeneralPurpose      4
Standard_D8ds_v4    4096 GeneralPurpose      8
Standard_D16ds_v4   4096 GeneralPurpose     16
Standard_D32ds_v4   4096 GeneralPurpose     32
Standard_D48ds_v4   4096 GeneralPurpose     48
Standard_D64ds_v4   4096 GeneralPurpose     64
Standard_E2ds_v4    8192 MemoryOptimized     2
Standard_E4ds_v4    8192 MemoryOptimized     4
Standard_E8ds_v4    8192 MemoryOptimized     8
Standard_E16ds_v4   8192 MemoryOptimized    16
Standard_E32ds_v4   8192 MemoryOptimized    32
Standard_E48ds_v4   8192 MemoryOptimized    48
Standard_E64ds_v4   8192 MemoryOptimized    64
```

This cmdlet shows basic sku information of the provided location.

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

### -Location
The name of the location.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20210501.ICapabilityProperties

## NOTES

## RELATED LINKS
