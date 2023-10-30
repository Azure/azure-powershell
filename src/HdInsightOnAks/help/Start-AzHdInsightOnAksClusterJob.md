---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/start-azhdinsightonaksclusterjob
schema: 2.0.0
---

# Start-AzHdInsightOnAksClusterJob

## SYNOPSIS
Operations on jobs of HDInsight on AKS cluster.

## SYNTAX

### RunExpanded (Default)
```
Start-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Run
```
Start-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterPoolName <String> -ResourceGroupName <String>
 -ClusterJob <IClusterJob> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RunViaIdentity
```
Start-AzHdInsightOnAksClusterJob -InputObject <IHdInsightOnAksIdentity> -ClusterJob <IClusterJob>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RunViaIdentityClusterpool
```
Start-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterpoolInputObject <IHdInsightOnAksIdentity>
 -ClusterJob <IClusterJob> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RunViaIdentityClusterpoolExpanded
```
Start-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterpoolInputObject <IHdInsightOnAksIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RunViaIdentityExpanded
```
Start-AzHdInsightOnAksClusterJob -InputObject <IHdInsightOnAksIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RunViaJsonFilePath
```
Start-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterPoolName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RunViaJsonString
```
Start-AzHdInsightOnAksClusterJob -ClusterName <String> -ClusterPoolName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operations on jobs of HDInsight on AKS cluster.

## EXAMPLES

### Example 1: Start a job in the flink cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
$flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
        -JarName "JarName" -EntryClass "com.microsoft.hilo.flink.job.streaming.SleepJob" `
        -JobJarDirectory "abfs://flinkjob@hilosa.dfs.core.windows.net/jars" `
        -FlinkConfiguration @{parallelism=1}
Start-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterJob $flinkJobProperties
```

```output
Id                           : /providers/Microsoft.HDInsight/locations/WESTUS3/operationStatuses/0d1c65ea-bd83-4e70-87
                               a1-6eac9871416a*93BE3F5F38E851939A0189D16172AE096513F606F83B4B31C7549306E4C696F3
JobType                      : FlinkJob
Name                         : 0d1c65ea-bd83-4e70-87a1-6eac9871416a*93BE3F5F38E851939A0189D16172AE096513F606F83B4B31C75
                               49306E4C696F3
Property                     : {
                                 "jobType": "FlinkJob"
                               }
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :
```

Start a job in the flink cluster.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterJob
Cluster job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob
Parameter Sets: Run, RunViaIdentity, RunViaIdentityClusterpool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: Run, RunExpanded, RunViaIdentityClusterpool, RunViaIdentityClusterpoolExpanded, RunViaJsonFilePath, RunViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterpoolInputObject
Identity Parameter
To construct, see NOTES section for CLUSTERPOOLINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: RunViaIdentityClusterpool, RunViaIdentityClusterpoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterPoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Run, RunExpanded, RunViaJsonFilePath, RunViaJsonString
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: RunViaIdentity, RunViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Run operation

```yaml
Type: System.String
Parameter Sets: RunViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Run operation

```yaml
Type: System.String
Parameter Sets: RunViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
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
Parameter Sets: Run, RunExpanded, RunViaJsonFilePath, RunViaJsonString
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
Type: System.String
Parameter Sets: Run, RunExpanded, RunViaJsonFilePath, RunViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob

## NOTES

## RELATED LINKS

