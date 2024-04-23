---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/set-azsynapsemanagedidentitysqlcontrolsetting
schema: 2.0.0
---

# Set-AzSynapseManagedIdentitySqlControlSetting

## SYNOPSIS
Updates managed identity SQL control settings to workspace.

## SYNTAX

### ByNameParameterSet (Default)
```
Set-AzSynapseManagedIdentitySqlControlSetting [-ResourceGroupName <String>] -WorkspaceName <String>
 -Enabled <Boolean> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Set-AzSynapseManagedIdentitySqlControlSetting -WorkspaceObject <PSSynapseWorkspace> -Enabled <Boolean>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Set-AzSynapseManagedIdentitySqlControlSetting -ResourceId <String> -Enabled <Boolean>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSynapseManagedIdentitySqlControlSetting** updates managed identity SQL control settings to workspace.

## EXAMPLES

### Example 1
```powershell
Set-AzSynapseManagedIdentitySqlControlSetting -WorkspaceName ContosoWorkspace -Enabled $true
```

This command enables managed identity SQL control settings to workspace for workspace ContosoWorkspace.

### Example 2
```powershell
Set-AzSynapseManagedIdentitySqlControlSetting -WorkspaceName ContosoWorkspace -Enabled $false
```

This command disables managed identity SQL control settings to workspace for workspace ContosoWorkspace.

### Example 3
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Set-AzSynapseManagedIdentitySqlControlSetting -Enabled $true
```

This command enables managed identity SQL control settings to workspace for workspace ContosoWorkspace through pipeline.

### Example 4
```powershell
Set-AzSynapseManagedIdentitySqlControlSetting -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd3/resourcegroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace -Enabled $true
```

This command enables managed identity SQL control settings to workspace for workspace ContosoWorkspace through the workspace's resource ID.

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

### -Enabled
Indicates whether to enable managed identity SQL control setting.
Specify $True to enable managed identity SQL control setting, or $False to disable managed identity SQL control setting.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource identifier of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
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
Parameter Sets: ByNameParameterSet
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
Parameter Sets: ByParentObjectParameterSet
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

### Microsoft.Azure.Commands.Synapse.Models.PSManagedIdentitySqlControlSettingsModel

## NOTES

## RELATED LINKS
