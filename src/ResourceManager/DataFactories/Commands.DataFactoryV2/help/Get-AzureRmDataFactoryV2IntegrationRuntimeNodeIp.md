---
external help file: Microsoft.Azure.Commands.DataFactoryV2.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datafactories/get-azurermdatafactoryv2integrationruntimenodeip
schema: 2.0.0
---

# Get-AzureRmDataFactoryV2IntegrationRuntimeNodeIp

## SYNOPSIS
Get IP address of a self-hosted integration runtime node.

## SYNTAX

### ByIntegrationRuntimeName (Default)
```
Get-AzureRmDataFactoryV2IntegrationRuntimeNodeIp -NodeName <String> [-IntegrationRuntimeName] <String>
 [-ResourceGroupName] <String> [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzureRmDataFactoryV2IntegrationRuntimeNodeIp -NodeName <String> [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByIntegrationRuntimeObject
```
Get-AzureRmDataFactoryV2IntegrationRuntimeNodeIp -NodeName <String> [-InputObject] <PSIntegrationRuntime>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmDataFactoryV2IntegrationRuntimeNodeIp cmdlet gets the IP address of self-hosted integration runtime node.

## EXAMPLES

### Example 1: Get self-hosted integration runtime node IP address
```
PS C:\> Get-AzureRmDataFactoryV2IntegrationRuntimeNodeIp -ResourceGroupName 'rg-test-dfv2' -DataFactoryName 'test-df-eu2'  -IntegrationRuntimeName 'test-selfhost-ir' -NodeName 'Node_1'

IpAddress
---------
167.220.1.167
```

The cmdlet gets IP address of node named 'Node_1' in self-hosted integration runtime 'test-selfhost-ir' in data factory 'test-df-eu2'.

## PARAMETERS

### -DataFactoryName
The data factory name.

```yaml
Type: String
Parameter Sets: ByIntegrationRuntimeName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -InputObject
The integration runtime object.

```yaml
Type: PSIntegrationRuntime
Parameter Sets: ByIntegrationRuntimeObject
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IntegrationRuntimeName
The integration runtime name.

```yaml
Type: String
Parameter Sets: ByIntegrationRuntimeName
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NodeName
The integration runtime node name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByIntegrationRuntimeName
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
Type: String
Parameter Sets: ByResourceId
Aliases: Id

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
Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime

## OUTPUTS

### Microsoft.Azure.Management.DataFactory.Models.IntegrationRuntimeNodeIpAddress

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories, copy, activities, integration runtime

## RELATED LINKS

[Get-AzureRmDataFactoryV2IntegrationRuntime]()

