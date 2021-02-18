---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactoryV2.dll-Help.xml
Module Name: Az.DataFactory
online version: https://docs.microsoft.com/powershell/module/az.datafactory/add-azdatafactoryv2dataflowdebugsessionpackage
schema: 2.0.0
---

# Add-AzDataFactoryV2DataFlowDebugSessionPackage

## SYNOPSIS
Add data flow resource and its dependencies into specific data flow debug session.

## SYNTAX

### ByFactoryName (Default)
```
Add-AzDataFactoryV2DataFlowDebugSessionPackage [-PackageFile] <String> [-PassThru]
 [-ResourceGroupName] <String> [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByFactoryObject
```
Add-AzDataFactoryV2DataFlowDebugSessionPackage [-PackageFile] <String> [-PassThru]
 [-DataFactory] <PSDataFactory> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceId
```
Add-AzDataFactoryV2DataFlowDebugSessionPackage [-PackageFile] <String> [-PassThru] [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command attaches data flow resource and its dependencies to the specific debug session
The PowerShell command sequence for data flow debug workflow should be:
1. Start-AzDataFactoryV2DataFlowDebugSession
1. Add-AzDataFactoryV2DataFlowDebugSessionPackage
1. Invoke-AzDataFactoryV2DataFlowDebugSessionCommand (repeat this step for different commands/targets, or repeat step 2-3 in order to change the package file)
1. Stop-AzDataFactoryV2DataFlowDebugSession

## EXAMPLES

### Example 1
```powershell
PS C:\WINDOWS\system32> Add-AzDataFactoryV2DataFlowDebugSessionPackage -ResourceGroupName adf -DataFactoryName WikiADF -PackageFile "D:\dataflowps\addpackage.json" -SessionId 550effe4-93a3-485c-8525-eaf25259efbd
```

Add data flow package into debug session "550effe4-93a3-485c-8525-eaf25259efbd" of "WikiADF" data factory.
Pakcage file contains data flow debug resource, list of dataset debug resouce, list of linked service debug resource, debug setting and session ID. For instance:

{
  "dataFlow": {
    "name": "dataflow5",
    "properties": {
      "type": "MappingDataFlow",
      "typeProperties": {
        "sources": [
          {
            "dataset": {
              "referenceName": "DelimitedTextInput",
              "type": "DatasetReference"
            },
            "name": "source1",
            "typeProperties": {}
          }
        ],
        "sinks": [],
        "transformations": [],
        "script": "\n\nsource(output(\n\t\tResourceAgencyNum as string,\n\t\tPublicName as string\n\t),\n\tallowSchemaDrift: true,\n\tvalidateSchema: false) ~> source1"
      }
    }
  },
  "datasets": [
    {
      "name": "DelimitedTextInput",
      "properties": {
        "linkedServiceName": {
          "referenceName": "AzureBlobStorage1",
          "type": "LinkedServiceReference"
        },
        "annotations": [],
        "type": "DelimitedText",
        "typeProperties": {
          "location": {
            "type": "AzureBlobStorageLocation",
            "container": "20192019"
          },
          "columnDelimiter": ",",
          "escapeChar": "\\",
          "firstRowAsHeader": true,
          "quoteChar": "\""
        },
        "schema": [
          {
            "name": "ResourceAgencyNum",
            "type": "String"
          },
          {
            "name": "PublicName",
            "type": "String"
          }
        ]
      },
      "type": "Microsoft.DataFactory/factories/datasets"
    }
  ],
  "linkedServices": [
    {
      "name": "AzureBlobStorage1",
      "type": "Microsoft.DataFactory/factories/linkedservices",
      "properties": {
        "annotations": [],
        "type": "AzureBlobStorage",
        "typeProperties": {
          "connectionString": "DefaultEndpointsProtocol=https;AccountName=name;AccountKey=key;EndpointSuffix=core.windows.net"
        }
      }
    }
  ],
  "debugSettings": {
    "sourceSettings": [
      {
        "sourceName": "source1",
        "rowLimit": 1000
      }
    ]
  },
  "sessionId": "4f988caf-e765-47d2-82cd-430334a6b135"
}

SessionID parameter is used to replace the existing sessionId property in the package file.

## PARAMETERS

### -DataFactory
The data factory object.

```yaml
Type: Microsoft.Azure.Commands.DataFactoryV2.Models.PSDataFactory
Parameter Sets: ByFactoryObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DataFactoryName
The data factory name.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -PackageFile
The JSON file path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: File

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
If specified will write true in case operation succeeds. This parameter is optional.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### -ResourceId
The Azure resource ID.

```yaml
Type: System.String
Parameter Sets: ByResourceId
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSDataFactory

## OUTPUTS

### System.Void

### System.Boolean

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Start-AzDataFactoryV2DataFlowDebugSession](./Start-AzDataFactoryV2DataFlowDebugSession.md)

[Get-AzDataFactoryV2DataFlowDebugSession](./Get-AzDataFactoryV2DataFlowDebugSession.md)

[Invoke-AzDataFactoryV2DataFlowDebugSessionCommand](./Invoke-AzDataFactoryV2DataFlowDebugSessionCommand.md)

[Stop-AzDataFactoryV2DataFlowDebugSession](./Stop-AzDataFactoryV2DataFlowDebugSession.md)
