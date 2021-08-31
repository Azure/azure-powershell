---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version:
schema: 2.0.0
---

# Invoke-AzSynapseTriggerRun

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### InvokeByName (Default)
```
Invoke-AzSynapseTriggerRun -WorkspaceName <String> -Name <String> -TriggerRunId <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokByInputObject
```
Invoke-AzSynapseTriggerRun -InputObject <PSTriggerRun> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeByWorkspaceObject
```
Invoke-AzSynapseTriggerRun -WorkspaceObject <PSSynapseWorkspace> -Name <String> -TriggerRunId <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
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
Type: PSTriggerRun
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
Type: String
Parameter Sets: InvokeByName, InvokeByWorkspaceObject
Aliases: TriggerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
{{ Fill PassThru Description }}

```yaml
Type: SwitchParameter
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
Type: String
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
Type: String
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
Type: PSSynapseWorkspace
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
Type: SwitchParameter
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
Type: SwitchParameter
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
