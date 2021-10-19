---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactoryV2.dll-Help.xml
Module Name: Az.DataFactory
online version: https://docs.microsoft.com/powershell/module/az.datafactory/set-azdatafactoryv2pipeline
schema: 2.0.0
---

# Set-AzDataFactoryV2PrivateEndpointConnection

## SYNOPSIS
Creates a PrivateEndpointConnection in the data factory.

## SYNTAX

### ByFactoryName (Default)
```
Set-AzDataFactoryV2PrivateEndpointConnection [-Name] <String> [-DefinitionFile] <String> [-Force]
 [-ResourceGroupName] <String> [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Set-AzDataFactoryV2PrivateEndpointConnection [-DefinitionFile] <String> [-Force] [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzDataFactoryV2PrivateEndpointConnection cmdlet creates a PrivateEndpointConnection to Azure Data Factory.
If you specify a name for a PrivateEndpointConnection that already exists, this cmdlet prompts you for confirmation before it replaces the PrivateEndpointConnection.
If you specify the Force parameter, the cmdlet replaces the existing PrivateEndpointConnection without confirmation.

## EXAMPLES

### Example 1: Create a PrivateEndpointConnection
```
PS C:\> Set-AzDataFactoryV2PrivateEndpointConnection -ResourceGroupName "ADF" -DataFactoryName "WikiADF" -Name "PrivateEndpointConnectionCuratedWikiData" -File "C:\\samples\\WikiSample\\PrivateEndpointConnectionCuratedWikiData.json" | Format-List
 
    PrivateEndpointConnectionName : PrivateEndpointConnectionCuratedWikiData
    ResourceGroupName             : ADF
    DataFactoryName               : WikiADF
    Properties                    : Microsoft.Azure.Management.DataFactory.Models.RemotePrivateEndpointConnection
```

This command creates PrivateEndpointConnection named PrivateEndpointConnectionCuratedWikiData in the data factory named WikiADF.
The command passes the result to the Format-List cmdlet by using the pipeline operator.
That Windows PowerShell cmdlet formats the results.
For more information, type Get-Help Format-List.

## PARAMETERS

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

### -DefinitionFile
The JSON file path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: File

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Don't ask for confirmation.

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

### -Name
PrivateEndpointConnectionName

```yaml
Type: System.String
Parameter Sets: ByFactoryName
Aliases: The privateEndpointConnection object.

Required: True
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

## OUTPUTS

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSPrivateEndpointConnection

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Get-AzDataFactoryV2PrivateEndpointConnection]()

[Remove-AzDataFactoryV2PrivateEndpointConnection]()
