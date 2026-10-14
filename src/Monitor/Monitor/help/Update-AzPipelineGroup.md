---
external help file: Az.PipelineGroup.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azpipelinegroup
schema: 2.0.0
---

# Update-AzPipelineGroup

## SYNOPSIS
Update a pipeline group instance

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPipelineGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DistributionMaxInstancesPerHost <Int32>] [-ExecutionPlacementConstraint <IPlacementConstraint[]>]
 [-Exporter <IExporter[]>] [-PersistencePersistentVolumeName <String>] [-Processor <IProcessor[]>]
 [-Receiver <IReceiver[]>] [-Replica <Int32>] [-ServicePipeline <IPipeline[]>] [-Tag <Hashtable>]
 [-TlsConfiguration <ITlsConfiguration[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzPipelineGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzPipelineGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPipelineGroup -InputObject <IPipelineGroupIdentity> [-DistributionMaxInstancesPerHost <Int32>]
 [-ExecutionPlacementConstraint <IPlacementConstraint[]>] [-Exporter <IExporter[]>]
 [-PersistencePersistentVolumeName <String>] [-Processor <IProcessor[]>] [-Receiver <IReceiver[]>]
 [-Replica <Int32>] [-ServicePipeline <IPipeline[]>] [-Tag <Hashtable>]
 [-TlsConfiguration <ITlsConfiguration[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a pipeline group instance

## EXAMPLES

### Example 1: Update Azure Monitor Pipeline Group
```powershell
Update-AzPipelineGroup -Name testgroup -ResourceGroupName kubetest -SubscriptionId 00000000-0000-0000-0000-000000000000 -Replica 1 -Exporter @{name="gigla1"; type="AzureMonitorWorkspaceLogs"; azureMonitorWorkspaceLog=@{api=@{dataCollectionEndpointUrl="https://myexporter.eastus-1.ingest.monitor.azure.com"; dataCollectionRule="dcr-00000000000000000000000000000000"; stream="Custom-MyTableRawData"; schema=@{recordMap=@(@{from="body"; to="Body"},@{from="severity_text"; to="SeverityText"},@{from="time_unix_nano"; to="TimeGenerated"})}}}} -Processor @{name="batchproc1"; type="Batch"; batch=@{batchSize=10}} -Receiver @(@{name="otlp1"; type="OTLP"; otlp=@{endpoint="0.0.0.0:7777"}}, @{name="mysyslog1"; type="Syslog"; syslog=@{endpoint="0.0.0.0:4444"}}) -ServicePipeline @{name="MyPipeline1"; type="logs"; receiver=@("otlp1", "mysyslog1"); processor=@("batchproc1"); exporter=@("gigla1")}
```

Update Azure Monitor Pipeline Group

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

### -DistributionMaxInstancesPerHost
Maximum number of instances allowed per compute unit (node/VM).
If not specified, default scheduling applies.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionPlacementConstraint
A list of placement constraints to guide where pipelineGroup instances should run.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPlacementConstraint[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exporter
The exporters specified for a pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IExporter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroupIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of pipeline group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: PipelineGroupName

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

### -PersistencePersistentVolumeName
The name of the mounted persistent volume.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Processor
The processors specified for a pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IProcessor[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Receiver
The receivers specified for a pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IReceiver[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Replica
Defines the amount of replicas of the pipeline group instance.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePipeline
Pipelines belonging to a given pipeline group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipeline[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TlsConfiguration
TLS configurations for the pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.ITlsConfiguration[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroupIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroup

## NOTES

## RELATED LINKS
