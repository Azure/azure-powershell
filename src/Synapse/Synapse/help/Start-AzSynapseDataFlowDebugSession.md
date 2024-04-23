---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/start-azsynapsedataflowdebugsession
schema: 2.0.0
---

# Start-AzSynapseDataFlowDebugSession

## SYNOPSIS
Starts a Synapse Analytics data flow debug session in Synapse Workspace.

## SYNTAX

### StartByName (Default)
```
Start-AzSynapseDataFlowDebugSession -WorkspaceName <String> [-IntegrationRuntimeFile <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### StartByObject
```
Start-AzSynapseDataFlowDebugSession -WorkspaceObject <PSSynapseWorkspace> [-IntegrationRuntimeFile <String>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This long running command starts a data flow debug session for the upcoming debug commands. This command can attach with an integration runtime definition to configure the size/type of debug session cluster.
The PowerShell command sequence for data flow debug workflow should be:  
1. Start-AzSynapseDataFlowDebugSession  
2. Add-AzSynapseDataFlowDebugSessionPackage  
3. Invoke-AzSynapseDataFlowDebugSessionCommand (repeat this step for different commands/targets, or repeat step 2-3 in order to change the package file)  
4. Stop-AzSynapseDataFlowDebugSession  

## EXAMPLES

### Example 1
```powershell
Start-AzSynapseDataFlowDebugSession -WorkspaceName ContosoWorkspace
```

This command starts an Azure Synapse Analytics data flow debug session.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Workspacename ContosoWorkspace -ResourceGroupName GroupName  
$result = $ws | Start-AzSynapseDataFlowDebugSession  
$result
```

```output
SessionId
---------
b75f917c-1a5e-432e-a1b9-ec6aabb1f546
```

This command starts an Azure Synapse Analytics data flow debug session through pipeline.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntegrationRuntimeFile
The JSON file path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: File

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

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: StartByName
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
Parameter Sets: StartByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSCreateDataFlowDebugSessionResponse

## NOTES

## RELATED LINKS
