---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactories.dll-Help.xml
Module Name: Az.DataFactory
ms.assetid: 7100B5F0-A07B-4305-BF80-1F52647A03AB
online version: https://docs.microsoft.com/powershell/module/az.datafactory/get-azdatafactoryrun
schema: 2.0.0
---

# Get-AzDataFactoryRun

## SYNOPSIS
Gets runs for a data slice of a dataset in Azure Data Factory.

## SYNTAX

### ByFactoryName (Default)
```
Get-AzDataFactoryRun [-DataFactoryName] <String> [-DatasetName] <String> [-StartDateTime] <DateTime>
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByFactoryObject
```
Get-AzDataFactoryRun [-DataFactory] <PSDataFactory> [-DatasetName] <String> [-StartDateTime] <DateTime>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataFactoryRun** cmdlet gets the runs for a data slice of a dataset in Azure Data Factory.
A dataset in a data factory is composed of slices over the time axis.
The width of a slice is determined by the schedule, either hourly or daily.
A run is a unit of processing for a slice.
There could be one or more runs for a slice in case of retries or in case you rerun your slice due to failures.
A slice is identified by its start time.
To obtain the start time of a slice, use the Get-AzDataFactorySlice cmdlet.
For example, to get a run for the following slice, use the start time 2015-04-02T20:00:00.
ResourceGroupName  : ADF
DataFactoryName : SPDataFactory0924
DatasetName : MarketingCampaignEffectivenessBlobDataset
Start : 5/2/2014 8:00:00 PM
End : 5/3/2014 8:00:00 PM
RetryCount : 0
Status : Ready
LatencyStatus :

## EXAMPLES

### Example 1: Get a dataset
```
PS C:\>Get-AzDataFactoryRun -ResourceGroupName "ADF" -DataFactoryName "WikiADF" -DatasetName "DAWikiAggregatedData" -StartDateTime 2014-05-21T16:00:00Z
Id                  : a7c4913c-9623-49b3-ae1e-3e45e2b68819
ResourceGroupName   : ADF
DataFactoryName     : WikiADF
DatasetName           : DAWikiAggregatedData
PipelineName        : 249ea141-ca00-8597-fad9-a148e5e7bdba
ActivityId          : fcefe2bd-39b1-2d7a-7b35-bcc2b0432300
ResumptionToken     : a7c4913c-9623-49b3-ae1e-3e45e2b68819
ContinuationToken   : 
ProcessingStartTime : 5/21/2014 5:02:41 PM
ProcessingEndTime   : 5/21/2014 5:04:12 PM
PercentComplete     : 100
DataSliceStart      : 5/21/2014 4:00:00 PM
DataSliceEnd        : 5/21/2014 5:00:00 PM
Status              : Succeeded
Timestamp           : 5/21/2014 5:02:41 PM
RetryAttempt        : 0
Properties          : {[errors, ]} 
ErrorMessage        :
```

This command gets all runs for slices of the dataset named DAWikiAggregatedData in the data factory named WikiADF that start from 4 PM GMT on 05/21/2014.

## PARAMETERS

### -DataFactory
Specifies a **PSDataFactory** object.
This cmdlet gets runs for slices that belong to the data factory that this parameter specifies.

```yaml
Type: Microsoft.Azure.Commands.DataFactories.Models.PSDataFactory
Parameter Sets: ByFactoryObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DataFactoryName
Specifies the name of a data factory.
This cmdlet gets runs for slices that belong to the data factory that this parameter specifies.

```yaml
Type: System.String
Parameter Sets: ByFactoryName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatasetName
Specifies the name of the dataset.
This cmdlet gets runs for slices that belong to the dataset that this parameter specifies.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -ResourceGroupName
Specifies the name of an Azure resource group.
This cmdlet gets factory runs for slices that belong to the group that this parameter specifies.

```yaml
Type: System.String
Parameter Sets: ByFactoryName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartDateTime
Specifies the start of a time period as a **DateTime** object.
This cmdlet gets runs for the data slices that match this time period.
*StartDateTime* must be specified in the ISO8601 format, as in the following examples: 
2015-01-01Z
2015-01-01T00:00:00Z
2015-01-01T00:00:00.000Z (UTC) 
2015-01-01T00:00:00-08:00 (Pacific Standard Time)
The default time zone designator is UTC.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.DataFactories.Models.PSDataFactory

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.DataFactories.Models.PSDataSliceRun

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Get-AzDataFactorySlice](./Get-AzDataFactorySlice.md)


