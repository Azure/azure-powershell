---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmServiceFabricClientCertificate

## SYNOPSIS
Remove client certificate from the cluster

## SYNTAX

### SingleUpdateWithCommonName
```
Remove-AzureRmServiceFabricClientCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -CommonName <String> -IssuerThumbprint <String> [<CommonParameters>]
```

### SingleUpdateWithThumbprint
```
Remove-AzureRmServiceFabricClientCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -Thumbprint <String> [<CommonParameters>]
```

### MultipleUpdatesWithCommonName
```
Remove-AzureRmServiceFabricClientCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -CommonNameIssuersAndFlags <Hashtable> [<CommonParameters>]
```

### MultipleUpdatesWithThumbprint
```
Remove-AzureRmServiceFabricClientCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -ThumbprintsAndFlags <Hashtable> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmServiceFabricClientCertificate** can remove the certificate either by common name and issuer thumbprint or certificate thumbprint

## EXAMPLES

### Example 1
```
PS c:> Remove-AzureRmServiceFabricApplicationCertificate -ResourceGroupName myResourceGroup -ClusterName myCluster -Thumbprint 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A
```

This command will remove thumbprint 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A from the cluster

### Example 2
```
PS c:> $table = @{"abc.com;AF06E4BFCBA05DCB59C42720136EC19DBA0A8E9F"=$true}
PS c:>Remove-AzureRmServiceFabricClientCertificate -CommonNameIssuersAndFlags $table -ClusterName myclustername -ResourceGroupName myresourcegroup
```

This command will remove common name with abc.com and issue thumbprint with 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A from the cluster

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

### -CommonName
Specify client certificate common name

```yaml
Type: String
Parameter Sets: SingleUpdateWithCommonName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CommonNameIssuersAndFlags
Specify client common name and issuer thumbprint(use ';' to separate) and flag

```yaml
Type: Hashtable
Parameter Sets: MultipleUpdatesWithCommonName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IssuerThumbprint
Specify client certificate issuer thumbprint

```yaml
Type: String
Parameter Sets: SingleUpdateWithCommonName
Aliases: 

Required: True
Position: Named
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
Specify client certificate thumbprint

```yaml
Type: String
Parameter Sets: SingleUpdateWithThumbprint
Aliases: ClientCertificateThumbprint

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ThumbprintsAndFlags
Specify client certificate thumbprint and flag

```yaml
Type: Hashtable
Parameter Sets: MultipleUpdatesWithThumbprint
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Collections.Hashtable
System.String
System.Boolean

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PsCluster

## NOTES

## RELATED LINKS

[Add-AzureRmServiceFabricClientCertificate](./[Add-AzureRmServiceFabricClientCertificate.md)
