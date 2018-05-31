---
external help file: Microsoft.Azure.Commands.Consumption.dll-Help.xml
Module Name: AzureRM.Consumption
online version:
schema: 2.0.0
---

# Get-AzureRmConsumptionMarketplace

## SYNOPSIS
Get marketplaces of the subscription.

## SYNTAX

```
Get-AzureRmConsumptionMarketplace [-BillingPeriodName <String>] [-EndDate <DateTime>] [-InstanceId <String>]
 [-InstanceName <String>] [-ResourceGroup <String>] [-StartDate <DateTime>] [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmConsumptionMarketplace** cmdlet gets marketplaces of the subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmConsumptionMarketplace -Top 10
```

Get top 10 records of marketplaces in the result.

### Example 2
```powershell
PS C:\> Get-AzureRmConsumptionMarketplace -StartDate 2018-01-03 -EndDate 2018-01-20 -Top 10
```

Get top 10 records of marketplaces with date range in the result.

### Example 3
```powershell
PS C:\> Get-AzureRmConsumptionMarketplace -BillingPeriodName 201801-1 -Top 10
```

Get top 10 records of marketplaces of BillingPeriodName in the result.

### Example 4
```powershell
PS C:\> Get-AzureRmConsumptionMarketplace -InstanceName TestVM -Top 10
```

Get top 10 records of marketplaces with InstanceName filter in the result.

## PARAMETERS

### -BillingPeriodName
Name of a specific billing period to get the marketplace that associate with.

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

### -EndDate
The end date (in UTC) of the marketplaces to filter.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceId
The instance id of the marketplaces to filter.

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

### -InstanceName
The instance name of the marketplaces to filter.

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

### -ResourceGroup
The resource group of the marketplaces to filter.

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

### -StartDate
The start date (in UTC) of the marketplaces to filter.

```yaml
Type: DateTime
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

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Consumption.Models.PSMarketplace, Microsoft.Azure.Commands.Consumption, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS
