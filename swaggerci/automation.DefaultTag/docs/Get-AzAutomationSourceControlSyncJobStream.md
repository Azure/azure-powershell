---
external help file:
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/get-azautomationsourcecontrolsyncjobstream
schema: 2.0.0
---

# Get-AzAutomationSourceControlSyncJobStream

## SYNOPSIS
Retrieve a sync job stream identified by stream id.

## SYNTAX

### List (Default)
```
Get-AzAutomationSourceControlSyncJobStream -AutomationAccountName <String> -ResourceGroupName <String>
 -SourceControlName <String> -SourceControlSyncJobId <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAutomationSourceControlSyncJobStream -AutomationAccountName <String> -ResourceGroupName <String>
 -SourceControlName <String> -SourceControlSyncJobId <String> -StreamId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAutomationSourceControlSyncJobStream -InputObject <IAutomationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieve a sync job stream identified by stream id.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AutomationAccountName
The name of the automation account.

```yaml
Type: System.String
Parameter Sets: Get, List
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
The filter to apply on the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.IAutomationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of an Azure Resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceControlName
The source control name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceControlSyncJobId
The source control sync job id.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamId
The id of the sync job stream.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.IAutomationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api202208.ISourceControlSyncJobStream

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api202208.ISourceControlSyncJobStreamById

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAutomationIdentity>`: Identity Parameter
  - `[ActivityName <String>]`: The name of activity.
  - `[AutomationAccountName <String>]`: The name of the automation account.
  - `[CertificateName <String>]`: The name of certificate.
  - `[CompilationJobName <String>]`: The DSC configuration Id.
  - `[ConfigurationName <String>]`: The configuration name.
  - `[ConnectionName <String>]`: The name of connection.
  - `[ConnectionTypeName <String>]`: The name of connection type.
  - `[CountType <CountType?>]`: The type of counts to retrieve
  - `[CredentialName <String>]`: The name of credential.
  - `[HybridRunbookWorkerGroupName <String>]`: The hybrid runbook worker group name
  - `[HybridRunbookWorkerId <String>]`: The hybrid runbook worker id
  - `[Id <String>]`: Resource identity path
  - `[JobId <String>]`: The job id.
  - `[JobName <String>]`: The name of the job to be created.
  - `[JobScheduleId <String>]`: The job schedule name.
  - `[JobStreamId <String>]`: The job stream id.
  - `[ModuleName <String>]`: The name of module.
  - `[NodeConfigurationName <String>]`: The Dsc node configuration name.
  - `[NodeId <String>]`: The node id.
  - `[PackageName <String>]`: The python package name.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ReportId <String>]`: The report id.
  - `[ResourceGroupName <String>]`: Name of an Azure Resource group.
  - `[RunbookName <String>]`: The runbook name.
  - `[ScheduleName <String>]`: The schedule name.
  - `[SoftwareUpdateConfigurationMachineRunId <String>]`: The Id of the software update configuration machine run.
  - `[SoftwareUpdateConfigurationName <String>]`: The name of the software update configuration to be created.
  - `[SoftwareUpdateConfigurationRunId <String>]`: The Id of the software update configuration run.
  - `[SourceControlName <String>]`: The source control name.
  - `[SourceControlSyncJobId <String>]`: The source control sync job id.
  - `[StreamId <String>]`: The id of the sync job stream.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[TypeName <String>]`: The name of type.
  - `[VariableName <String>]`: The variable name.
  - `[WatcherName <String>]`: The watcher name.
  - `[WebhookName <String>]`: The webhook name.

## RELATED LINKS

