---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/invoke-azsynapsetriggerrun
schema: 2.0.0
---

# Invoke-AzSynapseTriggerRun

## SYNOPSIS
Invokes another instance of a trigger run.

## SYNTAX

### InvokeByName (Default)
```
Invoke-AzSynapseTriggerRun -WorkspaceName <String> -Name <String> -TriggerRunId <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InvokByInputObject
```
Invoke-AzSynapseTriggerRun -InputObject <PSTriggerRun> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeByWorkspaceObject
```
Invoke-AzSynapseTriggerRun -WorkspaceObject <PSSynapseWorkspace> -Name <String> -TriggerRunId <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzSynapseTriggerRun command starts another instance of a trigger run with a new trigger run id.

## EXAMPLES

### Example 1
```powershell
Invoke-AzSynapseTriggerRun -WorkspaceName ContosoWorkspace -Name ContosoTrigger -TriggerRunId 000111222333abc
```

Starts another instance of a trigger run with a new trigger run id, keeping the same windowStartTime and windowEndTime as the original trigger run.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Invoke-AzSynapseTriggerRun -Name ContosoTrigger -TriggerRunId 000111222333abc
```

Starts another instance of a trigger run with a new trigger run id in the Synapse workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
$triggerun = Get-AzSynapseTriggerRun -WorkspaceName ContosoWorkspace -Name ContosoTrigger -RunStartedAfter "2018-09-01T21:00" -RunStartedBefore "2019-09-01T21:00"
$triggerun | Invoke-AzSynapseTriggerRun
```

Starts another instance of a trigger run with a new trigger run id in the Synapse workspace ContosoWorkspace through pipeline.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
The information about the trigger run.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSTriggerRun
Parameter Sets: InvokByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The trigger name.

```yaml
Type: System.String
Parameter Sets: InvokeByName, InvokeByWorkspaceObject
Aliases: TriggerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.

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

### -TriggerRunId
The Run ID of the trigger.

```yaml
Type: System.String
Parameter Sets: InvokeByName, InvokeByWorkspaceObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: InvokeByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceObject
workspace input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace
Parameter Sets: InvokeByWorkspaceObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Synapse.Models.PSTriggerRun

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
