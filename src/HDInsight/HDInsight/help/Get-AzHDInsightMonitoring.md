---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://learn.microsoft.com/powershell/module/az.hdinsight/get-azhdinsightmonitoring
schema: 2.0.0
---

# Get-AzHDInsightMonitoring

## SYNOPSIS
Gets the status of the Classic Azure Monitor logs integration on an HDInsight cluster.

## SYNTAX

```
Get-AzHDInsightMonitoring [-Name] <String> [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzHDInsightMonitoring** cmdlet gets the status of the Classic Azure Monitor logs integration on an HDInsight cluster. If monitoring is enabled then it will also return the log analytics workspace id.

## EXAMPLES

### Example 1
```powershell
Get-AzHDInsightMonitoring -Name testcluster
```

```output
{'ClusterMonitoringEnabled':'true', 'workspaceId':'1d364e89-bb71-4503-aa3d-a23535aea7bd'}
```

Monitoring is enabled on the cluster because the ClusterMonitoringEnabled property is true. The monitoring workspace id where the logs are flowing is 1d364e89-bb71-4503-aa3d-a23535aea7bd

### Example 2
```powershell
Get-AzHDInsightMonitoring -Name testcluster -ResourceGroupName testrg
```

```output
{'ClusterMonitoringEnabled':'true', 'workspaceId':'1d364e89-bb71-4503-aa3d-a23535aea7bd'}
```

Monitoring is enabled on the cluster because the ClusterMonitoringEnabled property is true. The monitoring workspace id where the logs are flowing is 1d364e89-bb71-4503-aa3d-a23535aea7bd

### Example 3
```powershell
Get-AzHDInsightMonitoring -Name testcluster
```

```output
{'ClusterMonitoringEnabled':'false', 'workspaceId': null}
```

Monitoring is disabled on the cluster because the ClusterMonitoringEnabled property is false.

### Example 4
```powershell
Get-AzHDInsightMonitoring -Name testcluster -ResourceGroupName testrg
```

```output
{'ClusterMonitoringEnabled':'false', 'workspaceId': null}
```

Monitoring is disabled on the cluster because the ClusterMonitoringEnabled property is false.

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
The name of the cluster to get the status of monitoring.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.HDInsight.Models.Management.AzureHDInsightMonitoring

## NOTES

## RELATED LINKS
