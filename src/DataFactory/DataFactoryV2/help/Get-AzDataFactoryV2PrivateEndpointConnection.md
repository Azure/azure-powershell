---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactoryV2.dll-Help.xml
Module Name: Az.DataFactory
online version: https://docs.microsoft.com/powershell/module/az.datafactory/get-azdatafactoryv2pipelinerun
schema: 2.0.0
---

# Get-AzDataFactoryV2PrivateEndpointConnection

## SYNOPSIS
Gets information about PrivateEndpointConnection in Azure Data Factory.

## SYNTAX

### ByFactoryName (Default)
```
Get-AzDataFactoryV2PrivateEndpointConnection [[-Name] <String>] [-ResourceGroupName] <String>
 [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByFactoryObject
```
Get-AzDataFactoryV2PrivateEndpointConnection [[-Name] <String>] [-DataFactory] <PSDataFactory>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzDataFactoryV2PrivateEndpointConnection [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzDataFactoryV2PrivateEndpointConnection cmdlet gets information about PrivateEndpointConnection in an Azure resource group.
If you specify the name of a PrivateEndpointConnection, this cmdlet gets information about that PrivateEndpointConnection.
If you do not specify a name, this cmdlet gets information about all of the PrivateEndpointConnections in an Azure resource group.

## EXAMPLES

### Example 1: Get all PrivateEndpointConnections in the Azure subscription
```
PS C:\> Get-AzDataFactoryV2 -ResourceGroupName "ADF" -DataFactoryName "WikiADF"

    PrivateEndpointConnectionName : PrivateEndpointConnectionNameWikiADF
    ResourceGroupName             : ADF
    DataFactoryName               : WikiADF
    Properties                    : Microsoft.Azure.Management.DataFactory.Models.RemotePrivateEndpointConnection
```

Displays information about all PrivateEndpointConnections in the Azure subscription.

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

### -Name
The linked service name.

```yaml
Type: System.String
Parameter Sets: ByFactoryName, ByFactoryObject
Aliases: PrivateEndpointConnectionName

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSDataFactory

## OUTPUTS

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSPrivateEndpointConnection

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Set-AzDataFactoryV2PrivateEndpointConnection]()

[Remove-AzDataFactoryV2PrivateEndpointConnection]()
