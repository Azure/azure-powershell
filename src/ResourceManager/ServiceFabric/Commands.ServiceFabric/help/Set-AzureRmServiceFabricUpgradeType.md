---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmServiceFabricUpgradeType

## SYNOPSIS
Set ServiceFabric upgrade type of the cluster

## SYNTAX

### Automatic
```
Set-AzureRmServiceFabricUpgradeType [-ResourceGroupName] <String> [-ClusterName] <String>
 -UpgradeMode <ClusterUpgradeMode> [<CommonParameters>]
```

### Manual
```
Set-AzureRmServiceFabricUpgradeType [-ResourceGroupName] <String> [-ClusterName] <String>
 -UpgradeMode <ClusterUpgradeMode> -Version <String> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmServiceFabricUpgradeType** set upgrade type to automatic or manual with specific ServiceFabric code version

## EXAMPLES

### Example 1
```
PS c:> Set-AzureRmServiceFabricUpgradeType -ResourceGroupName myResourceGroup -ClusterName myCluster -UpgradeMode Automatic
```

This command will set the cluster upgrade mode to automatic

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

### -UpgradeMode
ClusterUpgradeMode

```yaml
Type: ClusterUpgradeMode
Parameter Sets: (All)
Aliases: 
Accepted values: Automatic, Manual

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Cluster code version

```yaml
Type: String
Parameter Sets: Manual
Aliases: ClusterCodeVersion

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.ClusterUpgradeMode
System.String

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PsCluster

## NOTES

## RELATED LINKS

