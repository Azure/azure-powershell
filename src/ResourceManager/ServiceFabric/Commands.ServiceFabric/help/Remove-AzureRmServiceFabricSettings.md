---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmServiceFabricSettings

## SYNOPSIS
Remove one or multiple ServiceFabric settings from the cluster

## SYNTAX

### OneSetting
```
Remove-AzureRmServiceFabricSettings [-Section] <String> [-Parameter] <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

### BatchSettings
```
Remove-AzureRmServiceFabricSettings [-SettingsSectionDescriptions] <PSSettingsSectionDescription[]>
 [-ClusterName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmServiceFabricSettings** can remove ServiceFabric settings from the cluster

## EXAMPLES

### Example 1
```
PS c:> Remove-AzureRmServiceFabricSettings -ResourceGroupName myResourceGroup -ClusterName myCluster -Section EseStore -Parameter Maxcursors
```

This command will remove parameter Maxcursors under section EseStore

## PARAMETERS

### -ClusterName
Specifies the name of the cluster

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Parameter
Parameter

```yaml
Type: String
Parameter Sets: OneSetting
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group.

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

### -Section
Section

```yaml
Type: String
Parameter Sets: OneSetting
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SettingsSectionDescriptions
Client authentication type

```yaml
Type: PSSettingsSectionDescription[]
Parameter Sets: BatchSettings
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.ServiceFabric.Models.PSSettingsSectionDescription[]

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PsCluster

## NOTES

## RELATED LINKS

