---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/stop-azsynapsedataflowdebugsession
schema: 2.0.0
---

# Stop-AzSynapseDataFlowDebugSession

## SYNOPSIS
Stops a data flow debug session in a workspace.

## SYNTAX

### StopByName (Default)
```
Stop-AzSynapseDataFlowDebugSession -WorkspaceName <String> -SessionId <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### StoptByObject
```
Stop-AzSynapseDataFlowDebugSession -WorkspaceObject <PSSynapseWorkspace> -SessionId <String> [-PassThru]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzSynapseDataFlowDebugSession** cmdlet stops a data flow debug session in a workspace specified with the SessionId.

## EXAMPLES

### Example 1
```powershell
Stop-AzSynapseDataFlowDebugSession -workspacename ContosoWorkspace -sessionid c744f68d-a101-4115-9cd5-8b11314fe4b8
```

```output
Confirm
Are you sure you want to stop data flow debug session 'c744f68d-a101-4115-9cd5-8b11314fe4b8' in workspace 'ContosoWorkspace'?
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): y
```

This command stops the data flow debug session "c744f68d-a101-4115-9cd5-8b11314fe4b8" in the workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace -ResourceGroupName ContosoGroup
$ws | Stop-AzSynapseDataFlowDebugSession -sessionid c744f68d-a101-4115-9cd5-8b11314fe4b8
```

```output
Confirm
Are you sure you want to stop data flow debug session 'c744f68d-a101-4115-9cd5-8b11314fe4b8' in workspace 'ContosoWorkspace'?
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): y
```

This command stops the data flow debug session "c744f68d-a101-4115-9cd5-8b11314fe4b8" through pipeline.

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

### -Force
Do not ask for confirmation.

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

### -PassThru
This Cmdlet does not return an object by default.
If this switch is specified, it returns true if successful.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionId
Identifier of Spark session.

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

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: StopByName
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
Parameter Sets: StoptByObject
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
