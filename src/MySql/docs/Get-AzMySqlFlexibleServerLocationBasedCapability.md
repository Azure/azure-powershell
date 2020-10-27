---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/en-us/powershell/module/az.mysql/get-azmysqlflexibleserverlocationbasedcapability
schema: 2.0.0
---

# Get-AzMySqlFlexibleServerLocationBasedCapability

## SYNOPSIS
Get capabilities at specified location in a given subscription.

## SYNTAX

```
Get-AzMySqlFlexibleServerLocationBasedCapability -LocationName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get capabilities at specified location in a given subscription.

## EXAMPLES

### Example 1: List available SKUs and their properties in the location

```powershell
PS C:\> Get-AzMySqlFlexibleServerLocationBasedCapability -LocationName eastus
For prices please refer to https://aka.ms/mysql-pricing

SKU                Tier             VCore    Memory    Max Disk IOPS
-----------------  ---------------  -------  --------  ---------------
Standard_B1s       Burstable        1        1 GiB     320
Standard_B1ms      Burstable        1        2 GiB     640
Standard_B2s       Burstable        2        4 GiB     1280
Standard_D2ds_v4   GeneralPurpose   2        8 GiB     3200
Standard_D4ds_v4   GeneralPurpose   4        16 GiB    6400
Standard_D8ds_v4   GeneralPurpose   8        32 GiB    12800
Standard_D16ds_v4  GeneralPurpose   16       64 GiB    20000
Standard_D32ds_v4  GeneralPurpose   32       128 GiB   20000
Standard_D48ds_v4  GeneralPurpose   48       192 GiB   20000
Standard_D64ds_v4  GeneralPurpose   64       256 GiB   20000
Standard_E2ds_v4   MemoryOptimized  2        16 GiB    3200
Standard_E4ds_v4   MemoryOptimized  4        32 GiB    6400
Standard_E8ds_v4   MemoryOptimized  8        64 GiB    12800
Standard_E16ds_v4  MemoryOptimized  16       128 GiB   20000
Standard_E32ds_v4  MemoryOptimized  32       256 GiB   20000
Standard_E48ds_v4  MemoryOptimized  48       384 GiB   20000
Standard_E64ds_v4  MemoryOptimized  64       512 GiB   20000
```

Provide available skus in the location

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

### -LocationName
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

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ICapabilityProperties

## NOTES

ALIASES

## RELATED LINKS

