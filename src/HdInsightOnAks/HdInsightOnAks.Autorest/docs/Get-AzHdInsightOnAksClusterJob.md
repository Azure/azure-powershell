---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksclusterjob
schema: 2.0.0
---

# Get-AzHdInsightOnAksClusterJob

## SYNOPSIS
Get jobs of HDInsight on AKS cluster.

## SYNTAX

```
Get-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get jobs of HDInsight on AKS cluster.

## EXAMPLES

### Example 1: Get a job list for a cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
Get-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName
```

```output
Id                                                                                                                                                                      Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt Syste                                                                                                                                             ---- ------------------- ------------------- ----------------------- ------------------------ ----- 
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/ps-test-pool/clusters/flinkcluster/jobs/job1
```

Get a job list for a cluster.

## PARAMETERS

### -ClusterName
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterPoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The system query option to filter job returned in the response.
Allowed value is 'jobName eq {jobName}' or 'jarName eq {jarName}'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob

## NOTES

## RELATED LINKS

