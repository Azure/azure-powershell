---
external help file: Microsoft.Azure.Commands.ApplicationInsights.dll-Help.xml
Module Name: AzureRM.ApplicationInsights
online version: 
schema: 2.0.0
---

# New-AzureRmApplicationInsightsContinuousExport

## SYNOPSIS
Create a new application insights continuous export configuration for an application insights resource

## SYNTAX

```
New-AzureRmApplicationInsightsContinuousExport [-ResourceGroupName] <String> [-Name] <String>
 [-DocumentTypes] <String[]> [-DestinationStorageAccountId] <String> [-DestinationStorageLocationId] <String>
 [-DestinationStorageSASToken] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create a new application insights continuous export configuration for an application insights resource

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmApplicationInsightsContinuousExport -ResourceGroupName "testgroup" -Name "test"
 -DocumentTypes "Rdd","Messages" -DestinationStorageAccountId "/subscriptions/50359d91-7b9d-4823-85af-eb298a61ba96/resourceGroups/testgroup/providers/Microsoft.Storage/storageAccounts/teststorageaccount" -DestinationStorageLocationId sourcecentralus
 -DestinationStorageSASToken "https://teststorageaccount.blob.core.windows.net/testcontainer?sv=2015-04-05&sr=c&sig=xxxxxxxxx"
```

Create a new application insights continuous export configuration to export "Rdd" and "Messages" document types to storage contain "testcontainer" in storage account "teststorageaccount" in resource group "testgroup".

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationStorageAccountId
Destination Storage Account Id.

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

### -DestinationStorageLocationId
Destination Storage Location Id.

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

### -DestinationStorageSASToken
Destination Storage SAS token.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DocumentTypes
Document types that need exported.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: ApplicationKind
Accepted values: Requests, Exceptions, Event, Messages, Metrics, PageViewPerformance, PageViews, Rdd, Availability, PerformanceCounters

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Component Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ApplicationInsightsComponentName, ComponentName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.ApplicationInsights.Models.PSExportConfiguration

## NOTES

## RELATED LINKS

