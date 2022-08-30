---
external help file:
Module Name: Az.Datadog
online version: https://docs.microsoft.com/powershell/module/az.datadog/new-azdatadogsinglesignonconfiguration
schema: 2.0.0
---

# New-AzDatadogSingleSignOnConfiguration

## SYNOPSIS
Configures single-sign-on for this resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDatadogSingleSignOnConfiguration -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnterpriseAppId <String>] [-SingleSignOnState <SingleSignOnStates>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDatadogSingleSignOnConfiguration -InputObject <IDatadogIdentity> [-EnterpriseAppId <String>]
 [-SingleSignOnState <SingleSignOnStates>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Configures single-sign-on for this resource.

## EXAMPLES

### Example 1: Configures single-sign-on for Data monitor resource
```powershell
New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource.

### Example 2: Configures single-sign-on for Data monitor resource by pipeline
```powershell
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId 00000000-0000-0000-0000-000000000000
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource by pipeline.

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

### -EnterpriseAppId
The Id of the Enterprise App used for Single sign-on.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Configuration name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnState
Various states of the SSO resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.SingleSignOnStates
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IDatadogIdentity>`: Identity Parameter
  - `[ConfigurationName <String>]`: Configuration name
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleSetName <String>]`: Rule set name
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

