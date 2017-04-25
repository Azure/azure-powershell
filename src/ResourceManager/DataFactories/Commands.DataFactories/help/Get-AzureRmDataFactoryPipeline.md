---
external help file: Microsoft.Azure.Commands.DataFactories.dll-Help.xml
ms.assetid: 5224BDF5-D492-4160-893E-4BB5F76C22F3
online version: 
schema: 2.0.0
---

# Get-AzureRmDataFactoryPipeline

## SYNOPSIS
Gets information about pipelines in Azure Data Factory.

## SYNTAX

### ByFactoryName (Default)
```
Get-AzureRmDataFactoryPipeline [[-Name] <String>] [-DataFactoryName] <String> [-ResourceGroupName] <String>
 [<CommonParameters>]
```

### ByFactoryObject
```
Get-AzureRmDataFactoryPipeline [[-Name] <String>] [-DataFactory] <PSDataFactory> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDataFactoryPipeline** cmdlet gets information about pipelines in Azure Data Factory.
If you specify the name of a pipeline, this cmdlet gets information about that pipeline.
If you do not specify a name, this cmdlet gets information about all the pipelines in the data factory.

## EXAMPLES

### Example 1: Get information about all pipelines
```
PS C:\>Get-AzureRmDataFactoryPipeline -ResourceGroupName "ADF" -DataFactoryName "WikiADF"
```

This command gets information about all pipelines in the data factory named WikiADF.
You can either one of the following example commands.
The second one uses a **DataFactory** object as a parameter.

### Example 2: Get information about a specific pipeline
```
PS C:\>Get-AzureRmDataFactoryPipeline -ResourceGroupName "ADF" -Name "DPWikisample" -DataFactoryName "WikiADF" | Format-List
PipelineName      : DPWikisample
ResourceGroupName : ADF
DataFactoryName   : WikiADF
Properties        : Microsoft.DataFactories.PipelineProperties
```

This command gets information about the pipeline named DPWikisample in the data factory named WikiADF.
The command passes that information to the Format-List cmdlet by using the pipeline operator.
That cmdlet formats the results.
For more information, type `Get-Help Format-List`.

### Example 3: Get the properties for a specific pipeline
```
PS C:\> (Get-AzureRmDataFactoryPipeline -ResourceGroupName "ADF" -Name DPWikisample -DataFactoryName "WikiADF").Properties
Activities  : {WikiHiveActivity, BlobToSqlCopyActivity}
Description : DP Wikipedia Sample Pipelines
End         : 6/6/2014 8:00:00 AM
IsPaused    : 
RuntimeInfo : Microsoft.DataFactories.PipelineRuntimeInfo
Start       : 6/5/2014 8:00:00 PM
```

This command gets information for the pipeline named DPWikisample in the data factory named WikiADF, and then uses standard dot notation to view the **Properties** property associated with that pipeline.

### Example 4: Get the activities for a specific pipeline
```
PS C:\>(Get-AzureRmDataFactoryPipeline -ResourceGroupName "ADF" -Name "DPWikisample" -DataFactoryName "WikiADF").Properties.Activities
Transformation    : Microsoft.DataFactories.HDInsightActivityProperties
Description       : 
Inputs            : {DAWikipediaClickEvents}
LinkedServiceName : HDILinkedService
Name              : WikiHiveActivity
Outputs           : {DACuratedWikiData}
Policy            : Microsoft.DataFactories.ActivityPolicy

Transformation    : Microsoft.DataFactories.CopyActivityProperties
Description       : 
Inputs            : {DACuratedWikiData}
LinkedServiceName : HDILinkedService
Name              : BlobToSqlCopyActivity
Outputs           : {DAWikiAggregatedData}
Policy            : Microsoft.DataFactories.ActivityPolicy
```

This command gets information for the pipeline named DPWikisample in the data factory named WikiADF, and then uses standard dot notation to view the **Activities** property associated with that pipeline.

### Example 5: Get the runtime information for a specific pipeline
```
PS C:\>(Get-AzureRmDataFactoryPipeline -ResourceGroupName "ADF" -Name "DPWikisample" -DataFactoryName "WikiADF").Properties.RuntimeInfo
DeploymentTime
--------------
6/5/2014 10:36:46 PM
```

This command gets information for the pipeline named DPWikisample in the data factory named WikiADF, and then uses standard dot notation to view the **RuntimeInfo** property associated with that pipeline.

### Example 6: Get information about inputs for the first activity
```
PS C:\>(Get-AzureRmDataFactoryPipeline -ResourceGroupName "ADF" -Name "DPWikisample" -DataFactoryName "WikiADF11").Properties.Activities[0].Inputs | Format-List
EndTime   : 
Length    : 
Name      : DAWikipediaClickEvents
StartTime :
```

This command gets information for the pipeline named DPWikisample in the data factory named WikiADF, and then uses standard dot notation to view the **Activities** property associated with that pipeline.
The command displays the **Inputs** property of the first element of the **Activities** array by using **Format-List**.

## PARAMETERS

### -DataFactory
Specifies a **PSDataFactory** object.
This cmdlet gets pipelines that belong to the data factory that this parameter specifies.

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
This cmdlet gets pipelines that belong to the data factory that this parameter specifies.

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

### -Name
Specifies the name of the pipeline about which to get information.

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

### -ResourceGroupName
Specifies the name of an Azure resource group.
This cmdlet gets pipelines that belong to the group that this parameter specifies.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.WindowsAzure.Commands.Utilities.PSPipeline, Microsoft.WindowsAzure.Commands.Utilities, Version=0.8.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]] Microsoft.WindowsAzure.Commands.Utilities.PSPipeline

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[New-AzureRmDataFactoryPipeline](./New-AzureRmDataFactoryPipeline.md)

[Remove-AzureRmDataFactoryPipeline](./Remove-AzureRmDataFactoryPipeline.md)

[Resume-AzureRmDataFactoryPipeline](./Resume-AzureRmDataFactoryPipeline.md)

[Set-AzureRmDataFactoryPipelineActivePeriod](./Set-AzureRmDataFactoryPipelineActivePeriod.md)

[Suspend-AzureRmDataFactoryPipeline](./Suspend-AzureRmDataFactoryPipeline.md)


