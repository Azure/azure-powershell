---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/add-azsynapsedataflowdebugsessionpackage
schema: 2.0.0
---

# Add-AzSynapseDataFlowDebugSessionPackage

## SYNOPSIS
Add data flow resource and its dependencies into specific data flow debug session.

## SYNTAX

### AddByName (Default)
```
Add-AzSynapseDataFlowDebugSessionPackage -WorkspaceName <String> -PackageFile <String> [-SessionId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AddByObject
```
Add-AzSynapseDataFlowDebugSessionPackage -WorkspaceObject <PSSynapseWorkspace> -PackageFile <String>
 [-SessionId <String>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command attaches data flow resource and its dependencies to the specific debug session. The PowerShell command sequence for data flow debug workflow should be:

Start-AzSynapseDataFlowDebugSession  
Add-AzSynapseDataFlowDebugSessionPackage  
Invoke-AzSynapseDataFlowDebugSessionCommand (repeat this step for different commands/targets, or repeat step 2-3 in order to change the package file)  
Stop-AzSynapseDataFlowDebugSession

## EXAMPLES

### Example 1
```powershell
Add-AzSynapseDataFlowDebugSessionPackage -WorkspaceName ContosoWorkspace -PackageFile "D:\dataflowps\addpackage.json" -SessionId 3afb278e-ac5f-469f-a0b6-2f04c3ab59bc
```

Add data flow package into debug session "3afb278e-ac5f-469f-a0b6-2f04c3ab59bc" under Synapse workspace "ContosoWorkspace". Pakcage file contains data flow debug resource, list of dataset debug resource, list of linked service debug resource, debug setting and session ID. [-SessionId] parameter is optional, if it is specified, it will replace the existing sessionId property in the package file.  

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Add-AzSynapseDataFlowDebugSessionPackage -PackageFile "D:\dataflowps\addpackage.json" -SessionId 3afb278e-ac5f-469f-a0b6-2f04c3ab59bc
```

Add data flow package into debug session "3afb278e-ac5f-469f-a0b6-2f04c3ab59bc" under Synapse workspace "ContosoWorkspace" through pipeline.

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

### -PackageFile
The JSON file path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: File

Required: True
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
Identifier for Synapse data flow debug session.

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

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: AddByName
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
Parameter Sets: AddByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSAddDataFlowToDebugSessionResponse

## NOTES

## RELATED LINKS
