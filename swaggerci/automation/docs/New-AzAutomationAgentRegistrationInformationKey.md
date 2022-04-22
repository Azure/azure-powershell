---
external help file:
Module Name: Az.Automation
online version: https://docs.microsoft.com/en-us/powershell/module/az.automation/new-azautomationagentregistrationinformationkey
schema: 2.0.0
---

# New-AzAutomationAgentRegistrationInformationKey

## SYNOPSIS
Regenerate a primary or secondary agent registration key

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzAutomationAgentRegistrationInformationKey -AutomationAccountName <String> -ResourceGroupName <String>
 -KeyName <AgentRegistrationKeyName> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Regenerate
```
New-AzAutomationAgentRegistrationInformationKey -AutomationAccountName <String> -ResourceGroupName <String>
 -Parameter <IAgentRegistrationRegenerateKeyParameter> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentity
```
New-AzAutomationAgentRegistrationInformationKey -InputObject <IAutomationIdentity>
 -Parameter <IAgentRegistrationRegenerateKeyParameter> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzAutomationAgentRegistrationInformationKey -InputObject <IAutomationIdentity>
 -KeyName <AgentRegistrationKeyName> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Regenerate a primary or secondary agent registration key

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
Parameter Sets: Regenerate, RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.IAutomationIdentity
Parameter Sets: RegenerateViaIdentity, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyName
Gets or sets the agent registration key name - primary or secondary.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Support.AgentRegistrationKeyName
Parameter Sets: RegenerateExpanded, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters supplied to the regenerate keys operation.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20200113Preview.IAgentRegistrationRegenerateKeyParameter
Parameter Sets: Regenerate, RegenerateViaIdentity
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
Parameter Sets: Regenerate, RegenerateExpanded
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
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20200113Preview.IAgentRegistrationRegenerateKeyParameter

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.IAutomationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20200113Preview.IAgentRegistration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAutomationIdentity>: Identity Parameter
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

PARAMETER <IAgentRegistrationRegenerateKeyParameter>: The parameters supplied to the regenerate keys operation.
  - `KeyName <AgentRegistrationKeyName>`: Gets or sets the agent registration key name - primary or secondary.

## RELATED LINKS

