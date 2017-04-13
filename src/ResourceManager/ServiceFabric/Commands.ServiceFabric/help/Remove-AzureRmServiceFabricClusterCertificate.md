---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmServiceFabricClusterCertificate

## SYNOPSIS
Remove cluster certificate

## SYNTAX

```
Remove-AzureRmServiceFabricClusterCertificate [-Thumbprint] <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmServiceFabricClusterCertificate** can remove a secondary cluster certificate from the cluster

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmServiceFabricClusterCertificate -ResourceGroupName myResourceGroup -ClusterName myCluster -Thumbprint 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A
```

This command will remove the certificate with thumbprint 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A fromt the cluster certificate

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

### -Thumbprint
Specify the cluster thumbprint which to be removed

```yaml
Type: String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PsCluster

## NOTES

## RELATED LINKS

