---
external help file: Microsoft.Azure.Commands.HDInsight.dll-Help.xml
Module Name: AzureRM.HDInsight
ms.assetid: 3F321D94-2B0B-48CA-9778-8090373F7FE0
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.hdinsight/grant-azurermhdinsighthttpservicesaccess
schema: 2.0.0
---

# Grant-AzureRmHDInsightHttpServicesAccess

## SYNOPSIS
Grants HTTP access to the cluster.

## SYNTAX

```
Grant-AzureRmHDInsightHttpServicesAccess [-ClusterName] <String> [-HttpCredential] <PSCredential>
 [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Grant-AzureRmHDInsightHttpServicesAccess** cmdlet grants HTTP access to an Azure HDInsight cluster using ODBC, Ambari, Oozie and web services.

## EXAMPLES

### Example 1: Grant HTTP access to an Azure HDInsight cluster
```
PS C:\># Cluster info
PS C:\> $clusterName = "your-hadoop-001"
PS C:\> $clusterCreds = Get-Credential

PS C:\> Grant-AzureRmHDInsightHttpServicesAccess `
            -ClusterName $clusterName `
            -HttpCredential $newClusterCreds
```

This command grants HTTP access to the cluster named your-hadoop-001.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpCredential
Specifies the cluster login (HTTP) credentials for the cluster.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
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

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Management.HDInsight.Models.HttpConnectivitySettings

## NOTES

## RELATED LINKS

[Revoke-AzureRmHDInsightHttpServicesAccess](./Revoke-AzureRmHDInsightHttpServicesAccess.md)


