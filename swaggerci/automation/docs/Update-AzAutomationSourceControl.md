---
external help file:
Module Name: Az.Automation
online version: https://docs.microsoft.com/en-us/powershell/module/az.automation/update-azautomationsourcecontrol
schema: 2.0.0
---

# Update-AzAutomationSourceControl

## SYNOPSIS
Update a source control.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAutomationSourceControl -AutomationAccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AutoSync] [-Branch <String>] [-Description <String>] [-FolderPath <String>]
 [-PublishRunbook] [-SecurityTokenAccessToken <String>] [-SecurityTokenRefreshToken <String>]
 [-SecurityTokenType <TokenType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAutomationSourceControl -InputObject <IAutomationIdentity> [-AutoSync] [-Branch <String>]
 [-Description <String>] [-FolderPath <String>] [-PublishRunbook] [-SecurityTokenAccessToken <String>]
 [-SecurityTokenRefreshToken <String>] [-SecurityTokenType <TokenType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a source control.

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoSync
The auto sync of the source control.
Default is false.

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

### -Branch
The repo branch of the source control.

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

### -Description
The user description of the source control.

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

### -FolderPath
The folder path of the source control.
Path must be relative.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.IAutomationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The source control name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SourceControlName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublishRunbook
The auto publish of the source control.
Default is true.

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
Name of an Azure Resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityTokenAccessToken
The access token.

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

### -SecurityTokenRefreshToken
The refresh token.

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

### -SecurityTokenType
The token type.
Must be either PersonalAccessToken or Oauth.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Support.TokenType
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.IAutomationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20200113Preview.ISourceControl

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

## RELATED LINKS

