---
external help file: Microsoft.Azure.Commands.Consumption.dll-Help.xml
Module Name: AzureRM.Consumption
online version:
schema: 2.0.0
---

# Get-AzureRmConsumptionPriceSheet

## SYNOPSIS
Get price sheets of the subscription.

## SYNTAX

```
Get-AzureRmConsumptionPriceSheet [-BillingPeriodName <String>] [-Expand <String>] [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmConsumptionPriceSheet** cmdlet gets price sheets of the subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmConsumptionPriceSheet
```

Get price sheets in the result.

### Example 2
```powershell
PS C:\> Get-AzureRmConsumptionPriceSheet -Expand MeterDetails
```

Get price sheets with expand of MeterDetails in the result.

### Example 3
```powershell
PS C:\> Get-AzureRmConsumptionPriceSheet -BillingPeriodName 201712
```

Get price sheets of BillingPeriodName in the result.

### Example 4
```powershell
PS C:\> Get-AzureRmConsumptionPriceSheet -Top 5
```

Get top 5 records of price sheets in the result.

## PARAMETERS

### -BillingPeriodName
Name of a specific billing period to get the price sheets that associate with.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expand
Expand the price sheets based on MeterDetails.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Determine the maximum number of records to return.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.Consumption.Models.PSPriceSheet
System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Consumption.Models.PSPriceSheetProperty, Microsoft.Azure.Commands.Consumption, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS
