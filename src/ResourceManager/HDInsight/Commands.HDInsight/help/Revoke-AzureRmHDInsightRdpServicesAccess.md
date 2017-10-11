---
external help file: Microsoft.Azure.Commands.HDInsight.dll-Help.xml
ms.assetid: 8C6D9533-68FD-4AFF-91FB-8307A8C8EAEB
online version: 
schema: 2.0.0
---

# Revoke-AzureRmHDInsightRdpServicesAccess

## SYNOPSIS
Disables RDP access to a Windows cluster.

## SYNTAX

```
Revoke-AzureRmHDInsightRdpServicesAccess [-ClusterName] <String> [-ResourceGroupName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Revoke-AzureRmHDInsightRdpServicesAccess** cmdlet disables Remote Desktop Protocol (RDP) access to a Windows-based Azure HDInsight cluster.

## EXAMPLES

### Example 1: Disable RDP access to a specified cluster
```
PS C:\>Revoke-AzureRmHDInsightRdpServicesAccess -ClusterName "your-hadoop-001"
```

This command revokes RDP access to the cluster named your-hadoop-001.

## PARAMETERS

### -ClusterName
Specifies the name of the cluster.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Grant-AzureRmHDInsightRdpServicesAccess](./Grant-AzureRmHDInsightRdpServicesAccess.md)


