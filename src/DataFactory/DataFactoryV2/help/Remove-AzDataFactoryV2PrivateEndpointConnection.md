---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactoryV2.dll-Help.xml
Module Name: Az.DataFactory
online version: https://docs.microsoft.com/powershell/module/az.datafactory/remove-azdatafactoryv2pipeline
schema: 2.0.0
---

# Remove-AzDataFactoryV2PrivateEndpointConnection

## SYNOPSIS
Removes a PrivateEndpointConnection from Azure Data Factory.

## SYNTAX

### ByFactoryName (Default)
```
Remove-AzDataFactoryV2PrivateEndpointConnection [-Name] <String> [-Force] [-ResourceGroupName] <String>
 [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByInputObject
```
Remove-AzDataFactoryV2PrivateEndpointConnection [-InputObject] <PSPrivateEndpointConnection> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Remove-AzDataFactoryV2PrivateEndpointConnection [-Force] [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzDataFactoryV2PrivateEndpointConnection cmdlet removes a PrivateEndpointConnection from Azure Data Factory.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-AzDataFactoryV2PrivateEndpointConnection -ResourceGroupName "WikiADF" -DataFactoryName "ADF" -Name "PrivateEndpointConnectionName"

    Confirm
    Are you sure you want to remove privateEndpointConnection 'PrivateEndpointConnectionName' in data factory 'ADF'?
    [Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"):
```

The Remove-AzDataFactoryV2PrivateEndpointConnection cmdlet removes a PrivateEndpointConnection from Azure Data Factory.

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

### -InputObject
The privateEndpointConnection object.

```yaml
Type: Microsoft.Azure.Commands.DataFactoryV2.Models.PSPrivateEndpointConnection
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The privateEndpointConnection object.

```yaml
Type: System.String
Parameter Sets: ByFactoryName
Aliases: PrivateEndpointConnectionName

Required: True
Position: 2
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

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSPrivateEndpointConnection

### System.String

## OUTPUTS

### System.Void

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Get-AzDataFactoryV2PrivateEndpointConnection]()

[Set-AzDataFactoryV2PrivateEndpointConnection]()
