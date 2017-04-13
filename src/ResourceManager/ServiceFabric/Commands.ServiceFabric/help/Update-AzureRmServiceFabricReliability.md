---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmServiceFabricReliability

## SYNOPSIS
Update reliability of the cluster

## SYNTAX

```
Update-AzureRmServiceFabricReliability [-ReliabilityLevel] <ReliabilityLevel> [-AutoAddNodes]
 [-ClusterName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzureRmServiceFabricReliability** can update reliability of the cluster

## EXAMPLES

### Example 1
```
PS c:> Add-AzureRmServiceFabricReliability -ResourceGroupName myResourceGroup -ClusterName myCluster -ReliabilityLevel Silver
```

This command will change reliability level of the cluster to silver

## PARAMETERS

### -AutoAddNodes
Automatic adjust nodes number when changing reliability

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: AutoAdjustNodes

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -ReliabilityLevel
VM instance number

```yaml
Type: ReliabilityLevel
Parameter Sets: (All)
Aliases: 
Accepted values: Bronze, Silver, Gold

Required: True
Position: 3
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.ReliabilityLevel
System.Management.Automation.SwitchParameter
System.String

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PsCluster

## NOTES

## RELATED LINKS

