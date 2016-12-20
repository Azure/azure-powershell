---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: B8F735C7-9F53-4236-B5AE-6013FB551C8A
---

# Get-ACSBlobServiceMetric

## SYNOPSIS
Gets metrics for a storage blob service.

## SYNTAX

```
Get-ACSBlobServiceMetric [-FarmName] <String> [[-TimeGrain] <TimeGrain>] [[-StartTime] <DateTime>]
 [[-EndTime] <DateTime>] [-MetricNames <String[]>] [-DetailedOutput] [[-SubscriptionId] <String>]
 [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSBlobServiceMetric** cmdlet returns metrics for a storage blob service.
Metrics are usage information for a storage service component.
For example, you can retrieve information about the total number of requests made to a storage service component as well as information about the percentage of requests that were successfully filled.
You can use this cmdlet to return metrics for a specified timeframe, or you can use this cmdlet to return all the available metrics for a component.

**Get-ACSBlobServiceMetric** returns the actual metric values for a storage blob service.
To return information about the blob service metrics available for use, including a definition of each metric, use the Get-ACSBlobServiceMetricDefinition cmdlet.

## EXAMPLES

### Example 1: Get blob service metrics
```
PS C:\> Get-ACSBlobServiceMetric -FarmName "ContosoFarm" -ResourceGroupName "ContosoResourceGroup"
```

This command returns metrics for the blob service associated with the storage farm ContosoFarm.

## PARAMETERS

### -FarmName
Specifies the name of the storage farm associated with the target blob service.
For example:

`-FarmName "ContosoFarm01"`

A storage farm is a collection of storage resources that provides load balancing and redundancy.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartTime
Specifies the starting date and time for queries using a designated time interval.
For example, if you want to return information only for the period March 1, 2016 through March 8, 2016 the *StartTime* is configured similar to this, depending on your computer's Region settings:

`-StartTime "3/1/2016"`

If you use the *StartTime* parameter you must also use the *EndTime* parameter, and the *StartTime* must be earlier than the *EndTime*.
If you do not use these parameters then **Get-ACSBlobServiceMetric** returns all the available data regardless of date.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndTime
Specifies the end date and time for queries using a designated time interval.
For example, if you want to return information only for the period March 1, 2016 through March 8, 2016 the *EndTime* is configured similar to this, depending on your computer's Region setings:

-EndTime "3/8/2016"

If you use the *EndTime* you must also use the *StartTime* parameter, and the EndTime must be later than the *StartTime*.
If you do not use these parameters then **Get-ACSBlobServiceMetric** returns all the available data regardless of date.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TimeGrain
Specifies the time interval used for summarizing the returned data.
Allowed values are:

- Daily
- Hourly
- Minutely

The *TimeGrain* determines the number of data points returned by your query.
For example, if *TimeGrain* is set to Daily you get back one data point for each day.
If *TimeGrain* is set to Hourly you get back 24 data points per day, one for each hour in the day.

```yaml
Type: TimeGrain
Parameter Sets: (All)
Aliases: 

Required: False
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MetricNames
Specifies the names of the metrics to be returned.
For example:

`-MetricNames "TotalRequests"`

To specify multiple metrics, separate the metric names by using commas:

`-MetricNames "TotalRequests", "PercentSuccess"`

If this parameter is not included information is returned for all the available metrics.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the Azure subscription ID.
For example:

`-SubscriptionID "81c87063-04a3-4abf-8e4c-736569bc1f60"`

If the Azure environment has already been configured by using the **Set-AzureRmEnvironment** cmdlet then you do not need to use this parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Token
Specifies the authentication token for the service administrator.
This parameter is not required if you have configured your environment by using the **Set-AzureRmEnvironment** cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdminUri
Specifies the location of the Resource Manager endpoint.
If you configured your environment by using the Set-AzureRMEnvironment cmdlet, you do not have to specify this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group associated with the target storage blob service.
For example:

`-ResourceGroupName "ContosoResourceGroup"`

Resource groups categorize items to help simplify inventory management and overall Azure administration.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipCertificateValidation
Indicates that the command proceeds without validating the Secure Sockets Layer (SSL) certificate.
By default, storage service commands require certification validation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailedOutput
Indicates that complete information, including all the available metadata, is returned for each metric.
By default, **Get-ACSBlobServiceMetric** returns only partial data for each metric.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-ACSBlobService](./Get-ACSBlobService.md)

[Get-ACSBlobServiceMetricDefinition](./Get-ACSBlobServiceMetricDefinition.md)


