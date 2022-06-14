---
external help file:
Module Name: Az.HdInsight
online version: https://docs.microsoft.com/en-us/powershell/module/az.hdinsight/invoke-azhdinsightexecuteclusterscriptaction
schema: 2.0.0
---

# Invoke-AzHdInsightExecuteClusterScriptAction

## SYNOPSIS
Executes script actions on the specified HDInsight cluster.

## SYNTAX

### ExecuteExpanded (Default)
```
Invoke-AzHdInsightExecuteClusterScriptAction -ClusterName <String> -ResourceGroupName <String>
 -PersistOnSuccess [-SubscriptionId <String>] [-ScriptAction <IRuntimeScriptAction[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Execute
```
Invoke-AzHdInsightExecuteClusterScriptAction -ClusterName <String> -ResourceGroupName <String>
 -Parameter <IExecuteScriptActionParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaIdentity
```
Invoke-AzHdInsightExecuteClusterScriptAction -InputObject <IHdInsightIdentity>
 -Parameter <IExecuteScriptActionParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaIdentityExpanded
```
Invoke-AzHdInsightExecuteClusterScriptAction -InputObject <IHdInsightIdentity> -PersistOnSuccess
 [-ScriptAction <IRuntimeScriptAction[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Executes script actions on the specified HDInsight cluster.

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

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: Execute, ExecuteExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.IHdInsightIdentity
Parameter Sets: ExecuteViaIdentity, ExecuteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Parameter
The parameters for the script actions to execute on a running cluster.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IExecuteScriptActionParameters
Parameter Sets: Execute, ExecuteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -PersistOnSuccess
Gets or sets if the scripts needs to be persisted.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ExecuteExpanded, ExecuteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Execute, ExecuteExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptAction
The list of run time script actions.
To construct, see NOTES section for SCRIPTACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IRuntimeScriptAction[]
Parameter Sets: ExecuteExpanded, ExecuteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Execute, ExecuteExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IExecuteScriptActionParameters

### Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.IHdInsightIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IHdInsightIdentity>: Identity Parameter
  - `[ApplicationName <String>]`: The constant value for the application name.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ConfigurationName <String>]`: The name of the cluster configuration.
  - `[ExtensionName <String>]`: The name of the cluster extension.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The Azure location (region) for which to make the request.
  - `[OperationId <String>]`: The long running operation id.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[PrivateLinkResourceName <String>]`: The name of the private link resource.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RoleName <RoleName?>]`: The constant value for the roleName
  - `[ScriptExecutionId <String>]`: The script execution Id
  - `[ScriptName <String>]`: The name of the script.
  - `[SubscriptionId <String>]`: The subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

PARAMETER <IExecuteScriptActionParameters>: The parameters for the script actions to execute on a running cluster.
  - `PersistOnSuccess <Boolean>`: Gets or sets if the scripts needs to be persisted.
  - `[ScriptAction <IRuntimeScriptAction[]>]`: The list of run time script actions.
    - `Name <String>`: The name of the script action.
    - `Role <String[]>`: The list of roles where script will be executed.
    - `Uri <String>`: The URI to the script.
    - `[Parameter <String>]`: The parameters for the script

SCRIPTACTION <IRuntimeScriptAction[]>: The list of run time script actions.
  - `Name <String>`: The name of the script action.
  - `Role <String[]>`: The list of roles where script will be executed.
  - `Uri <String>`: The URI to the script.
  - `[Parameter <String>]`: The parameters for the script

## RELATED LINKS

