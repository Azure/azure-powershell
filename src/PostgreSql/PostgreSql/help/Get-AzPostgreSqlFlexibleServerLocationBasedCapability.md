---
external help file: Az.PostgreSql-help.xml
Module Name: Az.PostgreSql
online version: https://learn.microsoft.com/powershell/module/az.postgresql/get-azpostgresqlflexibleserverlocationbasedcapability
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerLocationBasedCapability

## SYNOPSIS
Get the available SKU information for the location

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerLocationBasedCapability -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the available SKU information for the location

## EXAMPLES

### Example 1: Get location capabilities by location name
```powershell
Get-AzPostgreSqlFlexibleServerLocationBasedCapability -Location eastus
```

```output
SKU               Memory vCore Tier
---               ------ ----- ----
Standard_B1ms       2048     1 Burstable
Standard_B2s        2048     2 Burstable
Standard_D2s_v3     4096     2 GeneralPurpose
Standard_D4s_v3     4096     4 GeneralPurpose
Standard_D8s_v3     4096     8 GeneralPurpose
Standard_D16s_v3    4096    16 GeneralPurpose
Standard_D32s_v3    4096    32 GeneralPurpose
Standard_D48s_v3    4096    48 GeneralPurpose
Standard_D64s_v3    4096    64 GeneralPurpose
Standard_D2ds_v4    4096     2 GeneralPurpose
Standard_D4ds_v4    4096     4 GeneralPurpose
Standard_D8ds_v4    4096     8 GeneralPurpose
Standard_D16ds_v4   4096    16 GeneralPurpose
Standard_D32ds_v4   4096    32 GeneralPurpose
Standard_D48ds_v4   4096    48 GeneralPurpose
Standard_D64ds_v4   4096    64 GeneralPurpose
Standard_E2s_v3     8192     2 MemoryOptimized
Standard_E4s_v3     8192     4 MemoryOptimized
Standard_E8s_v3     8192     8 MemoryOptimized
Standard_E16s_v3    8192    16 MemoryOptimized
Standard_E32s_v3    8192    32 MemoryOptimized
Standard_E48s_v3    8192    48 MemoryOptimized
Standard_E64s_v3    6912    64 MemoryOptimized
Standard_E2ds_v4    8192     2 MemoryOptimized
Standard_E4ds_v4    8192     4 MemoryOptimized
Standard_E8ds_v4    8192     8 MemoryOptimized
Standard_E16ds_v4   8192    16 MemoryOptimized
Standard_E20ds_v4   8192    20 MemoryOptimized
Standard_E32ds_v4   8192    32 MemoryOptimized
Standard_E48ds_v4   8192    48 MemoryOptimized
Standard_E64ds_v4   6912    64 MemoryOptimized
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20210601.ICapabilityProperties

## NOTES

## RELATED LINKS
