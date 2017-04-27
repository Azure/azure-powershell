---
external help file: Microsoft.Azure.Commands.Billing.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmBillingPeriod

## SYNOPSIS
Get billing periods of the subscription.

## SYNTAX

### List (Default)
```
Get-AzureRmBillingPeriod [-MaxCount <Int32>]
```

### Single
```
Get-AzureRmBillingPeriod -Name <System.Collections.Generic.List`1[System.String]>
```

## DESCRIPTION
The **Get-AzureRmBillingPeriod** cmdlet gets billing periods of the subscription.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmBillingPeriod
```

Get all available billing periods of the subscription.

### Example 2
```
PS C:\> Get-AzureRmBillingPeriod -Name 201704-1
```

Get the billing period of the subscription with the specified name.

### Example 3
```
PS C:\> Get-AzureRmBillingPeriod -MaxCount 2
```

Get at most 2 billing periods of the subscription.

## PARAMETERS

### -MaxCount
Determine the maximum number of records to return.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of a specific billing period to get.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: Single
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Billing.Models.PSBillingPeriod, Microsoft.Azure.Commands.Billing, Version=0.12.0.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.Billing.Models.PSBillingPeriod


## NOTES

## RELATED LINKS

