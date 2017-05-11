---
external help file: Microsoft.Azure.Commands.OperationalInsights.dll-Help.xml
ms.assetid: 4A91EEDA-D8F0-4109-A32E-B83694952C06
online version: 
schema: 2.0.0
---

# Disable-AzureRmOperationalInsightsLinuxSyslogCollection

## SYNOPSIS
Stops collection of syslog data from Linux computers.

## SYNTAX

### ByWorkspaceName (Default)
```
Disable-AzureRmOperationalInsightsLinuxSyslogCollection [-ResourceGroupName] <String> [-WorkspaceName] <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByWorkspaceObject
```
Disable-AzureRmOperationalInsightsLinuxSyslogCollection [-Workspace] <PSWorkspace> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Disable-AzureRmOperationalInsightsLinuxSyslogCollection** cmdlet stops collection of syslog data from connected Linux computers in a workspace.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -ResourceGroupName
Specifies the name of a resource group that contains Linux computers.

```yaml
Type: String
Parameter Sets: ByWorkspaceName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Workspace
Specifies a workspace in which this cmdlet operates.

```yaml
Type: PSWorkspace
Parameter Sets: ByWorkspaceObject
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Specifies the name of a workspace in which this cmdlet operates.

```yaml
Type: String
Parameter Sets: ByWorkspaceName
Aliases: 

Required: True
Position: 2
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

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, operational, insights

## RELATED LINKS

[Enable-AzureRmOperationalInsightsLinuxSyslogCollection](./Enable-AzureRmOperationalInsightsLinuxSyslogCollection.md)

[New-AzureRmOperationalInsightsLinuxSyslogDataSource](./New-AzureRmOperationalInsightsLinuxSyslogDataSource.md)


