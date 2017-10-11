---
external help file: Microsoft.Azure.Commands.DataFactories.dll-Help.xml
ms.assetid: 352A4B94-E433-413B-91D1-6AA347563959
online version: 
schema: 2.0.0
---

# New-AzureRmDataFactoryDataset

## SYNOPSIS
Creates a dataset in Data Factory.

## SYNTAX

### ByFactoryName (Default)
```
New-AzureRmDataFactoryDataset [-DataFactoryName] <String> [[-Name] <String>] [-File] <String> [-Force]
 [-ResourceGroupName] <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByFactoryObject
```
New-AzureRmDataFactoryDataset [-DataFactory] <PSDataFactory> [[-Name] <String>] [-File] <String> [-Force]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmDataFactoryDataset** cmdlet creates a dataset in Azure Data Factory.
If you specify a name for a dataset that already exists, this cmdlet prompts you for confirmation before it replaces the dataset.
If you specify the *Force* parameter, the cmdlet replaces the existing dataset without confirmation.

Perform these operations in the following order: 

- Create a data factory. 
- Create linked services. 
- Create datasets. 
- Create a pipeline.

If a dataset with the same name already exists in the data factory, this cmdlet prompts you to confirm whether to overwrite the existing dataset with the new dataset.
If you confirm to overwrite the existing dataset, the dataset definition is also replaced.

## EXAMPLES

### Example 1: Create a dataset
```
PS C:\>New-AzureRmDataFactoryDataset -ResourceGroupName "ADF" -DataFactoryName "WikiADF" -Name "DAWikipediaClickEvents" -File "C:\\samples\\WikiSample\\DA_WikipediaClickEvents.json"
DatasetName         : DAWikipediaClickEvents
ResourceGroupName : ADF
DataFactoryName   : WikiADF
Availability      : Microsoft.DataFactories.Availability
Location          : Microsoft.DataFactories.AzureBlobLocation
Policy            : Microsoft.DataFactories.Policy
Structure         : {}
```

This command creates a dataset named DA_WikipediaClickEvents in the data factory named WikiADF.
The command bases the dataset on information in the DAWikipediaClickEvents.json file.

### Example 2: View availability for a new dataset
```
PS C:\>$Dataset = New-AzureRmDataFactoryDataset -ResourceGroupName "ADF" -DataFactoryName "WikiADF" -Name "DAWikipediaClickEvents" -File "C:\\samples\\WikiSample\\DA_WikipediaClickEvents.json"
PS C:\> $Dataset.Availability
AnchorDateTime : 
Frequency      : Hour
Interval       : 1
Offset         : 
WaitOnExternal : Microsoft.DataFactories.WaitOnExternal
```

The first command creates a dataset named DA_WikipediaClickEvents, as in a previous example, and then assigns that dataset to the $Dataset variable.

The second command uses standard dot notation to display details about the Availability property of the dataset.

### Example 3: View location for a new dataset
```
PS C:\>$Dataset = New-AzureRmDataFactoryDataset -ResourceGroupName "ADF" -DataFactoryName "WikiADF" -Name "DAWikipediaClickEvents" -File "C:\\samples\\WikiSample\\DA_WikipediaClickEvents.json"
PS C:\> $Dataset.Location
BlobPath          : wikidatagateway/wikisampledatain/
FilenamePrefix    : 
Format            : 
LinkedServiceName : LinkedServiceWikipediaClickEvents
PartitionBy       : {}
```

The first command creates a dataset named DA_WikipediaClickEvents, as in a previous example, and then assigns that dataset to the $Dataset variable.

The second command displays details about the Location property of the dataset.

### Example 4: View validation rules for a new dataset
```
PS C:\>$Dataset = New-AzureRmDataFactoryDataset -ResourceGroupName "ADF" -DataFactoryName "WikiADF" -Name "DAWikipediaClickEvents" -File "C:\\samples\\WikiSample\\DA_WikipediaClickEvents.json"
PS C:\> $Dataset.Policy.Validation | Format-List $dataset.Location
BlobPath          : wikidatagateway/wikisampledatain/
FilenamePrefix    : 
Format            : 
LinkedServiceName : LinkedServiceWikipediaClickEvents
PartitionBy       : {}

MinimumRows   : 
MinimumSizeMB : 1
```

The first command creates a dataset named DA_WikipediaClickEvents, as in a previous example, and then assigns that dataset to the $Dataset variable.

The second command gets details about the validation rules for the dataset, and then passes them to the Format-List cmdlet by using the pipeline operator.
That Windows PowerShell cmdlet formats the results.
For more information, type `Get-Help Format-List`.

## PARAMETERS

### -DataFactory
Specifies a **PSDataFactory** object.
This cmdlet creates a dataset in the data factory that this parameter specifies.

```yaml
Type: PSDataFactory
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
This cmdlet creates a dataset in the data factory that this parameter specifies.

```yaml
Type: String
Parameter Sets: ByFactoryName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -File
Specifies the full path of the JavaScript Object Notation (JSON) file that contains the description of the dataset.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Indicates that this cmdlet replaces an existing dataset without prompting you for confirmation.

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

### -Name
Specifies the name of the dataset to create.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of an Azure resource group.
This cmdlet creates a dataset in the group that this parameter specifies.

```yaml
Type: String
Parameter Sets: ByFactoryName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Utilities.PSDataset

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Get-AzureRmDataFactoryDataset](./Get-AzureRmDataFactoryDataset.md)

[Remove-AzureRmDataFactoryDataset](./Remove-AzureRmDataFactoryDataset.md)


