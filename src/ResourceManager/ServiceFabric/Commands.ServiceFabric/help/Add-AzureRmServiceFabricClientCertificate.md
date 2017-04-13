---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmServiceFabricClientCertificate

## SYNOPSIS
Add common name or thumbprint to the cluster for client authentication

## SYNTAX

### MultipleUpdatesWithThumbprint
```
Add-AzureRmServiceFabricClientCertificate [-ThumbprintsAndFlags] <Hashtable> [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

### MultipleUpdatesWithCommonName
```
Add-AzureRmServiceFabricClientCertificate [-CommonNameIssuersAndFlags] <Hashtable> [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

### SingleUpdateWithThumbprint
```
Add-AzureRmServiceFabricClientCertificate [-Thumbprint] <String> [-IsAdmin] <Boolean> [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

### SingleUpdateWithCommonName
```
Add-AzureRmServiceFabricClientCertificate [-CommonName] <String> [-IssuerThumbprint] <String>
 [-IsAdmin] <Boolean> [-ClusterName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmServiceFabricClientCertificate** can add common name and issuer thumbprint or certificate thumbprint to the cluster, so that the client can use it for authentication

## EXAMPLES

### Example 1
```
PS c:> Add-AzureRmServiceFabricApplicationCertificate -ResourceGroupName myResourceGroup -ClusterName myCluster -Thumbprint 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A -IsAdmin true
```

This command will add thumbprint with 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A to the cluster, and its role is admin, so the client use the certificate to communicate with the cluster

### Example 1
```
PS C:\> $table=@{"abc.com;AF06E4BFCBA05DCB59C42720136EC19DBA0A8E9F"="true";"testdomain.com;5F3660C715EBBDA31DB1FFDCF508302348DE8E7A"="false"}
PS C:\> Add-AzureRmServiceFabricClientCertificate -CommonNameIssuersAndFlags $table -ClusterName testclusterpowershell2 -ResourceGroupName newsftestrg2
```

This command will add two client certificates one with admin access , the other one with readyonly acess by common name and issuer thumbprint to the cluster

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
Position: 3
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
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IsAdmin
Client authentication type

```yaml
Type: Boolean
Parameter Sets: SingleUpdateWithThumbprint, SingleUpdateWithCommonName
Aliases: 

Required: True
Position: 5
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

### -Thumbprint
Specify client certificate thumbprint

```yaml
Type: String
Parameter Sets: SingleUpdateWithThumbprint
Aliases: ClientCertificateThumbprint

Required: True
Position: 3
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
Position: 3
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

[Remove-AzureRmServiceFabricClientCertificate](./[Remove-AzureRmServiceFabricClientCertificate.md)