---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://docs.microsoft.com/en-us/powershell/module/az.hdinsight/get-azhdinsightoperationsmanagementsuite
schema: 2.0.0
---

# Get-AzHDInsightOperationsManagementSuite

## SYNOPSIS
Gets the status of Operations Management Suite (OMS) installation on the cluster.

## SYNTAX

```
Get-AzHDInsightOperationsManagementSuite [-Name] <String> [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzHDInsightOperationsManagementSuite** cmdlet gets the status of OMS installation in an Azure HDInsight cluster. If OMS is enabled then it will also return the OMS workspace id.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzHDInsightOMS -Name testcluster

ClusterMonitoringEnabled

{'ClusterMonitoringEnabled':'true', 'workspaceId':'1d364e89-bb71-4503-aa3d-a23535aea7bd'}
```

Operations Management Suite (OMS) is enabled on the cluster because the ClusterMonitoringEnabled property is true. The OMS workspace id where the logs are flowing is 1d364e89-bb71-4503-aa3d-a23535aea7bd

### Example 2
```
PS C:\> Get-AzHDInsightOMS -Name testcluster -ResourceGroupName testrg

ClusterMonitoringEnabled

{'ClusterMonitoringEnabled':'true', 'workspaceId':'1d364e89-bb71-4503-aa3d-a23535aea7bd'}
```

Operations Management Suite (OMS) is enabled on the cluster because the ClusterMonitoringEnabled property is true. The OMS workspace id where the logs are flowing is 1d364e89-bb71-4503-aa3d-a23535aea7bd

### Example 3
```
PS C:\> Get-AzHDInsightOMS -Name testcluster

ClusterMonitoringEnabled

{'ClusterMonitoringEnabled':'false'}
```

Operations Management Suite (OMS) is disabled on the cluster because the ClusterMonitoringEnabled property is false.

### Example 4
```
PS C:\> Get-AzHDInsightOMS -Name testcluster -ResourceGroupName testrg

ClusterMonitoringEnabled

{'ClusterMonitoringEnabled':'false'}
```

Operations Management Suite (OMS) is disabled on the cluster because the ClusterMonitoringEnabled property is false.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -Name
The name of the cluster to get the status of Operations Management Suite(OMS).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.HDInsight.Models.Management.AzureHDInsightOMS

## NOTES

## RELATED LINKS
