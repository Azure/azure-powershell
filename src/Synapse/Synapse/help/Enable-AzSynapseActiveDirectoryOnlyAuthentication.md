---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/enable-azsynapseactivedirectoryonlyauthentication
schema: 2.0.0
---

# Enable-AzSynapseActiveDirectoryOnlyAuthentication

## SYNOPSIS
Enables Microsoft Entra-only authentication for a specific Synapse workspace.

## SYNTAX

### EnableByNameParameterSet (Default)
```
Enable-AzSynapseActiveDirectoryOnlyAuthentication [-ResourceGroupName <String>] -WorkspaceName <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### EnableByParentObjectParameterSet
```
Enable-AzSynapseActiveDirectoryOnlyAuthentication -WorkspaceObject <PSSynapseWorkspace>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### EnableByResourceIdParameterSet
```
Enable-AzSynapseActiveDirectoryOnlyAuthentication -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Enable-AzSynapseActiveDirectoryOnlyAuthentication** cmdlet enables Microsoft Entra-only authentication for a specific Synapse workspace.

## EXAMPLES

### Example 1
```powershell
Enable-AzSynapseActiveDirectoryOnlyAuthentication -WorkspaceName ContosoWorkspace
```

```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                               True Consistent 3/23/2022 8:27:47 AM
```

This command enables Microsoft Entra-only authentication for workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -WorkspaceName ContosoWorkspace
$ws | Enable-AzSynapseActiveDirectoryOnlyAuthentication
```

```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                               True Consistent 3/23/2022 8:27:47 AM
```

This command enables Microsoft Entra-only authentication for workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
Enable-AzSynapseActiveDirectoryOnlyAuthentication -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd/resourceGroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace
```

```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                               True Consistent 3/23/2022 8:27:47 AM
```

This command enables Microsoft Entra-only authentication for workspace ContosoWorkspace by ResourceId.

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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: EnableByNameParameterSet
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
Parameter Sets: EnableByResourceIdParameterSet
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
Parameter Sets: EnableByNameParameterSet
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
Parameter Sets: EnableByParentObjectParameterSet
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

### Microsoft.Azure.Commands.Synapse.Models.PSAzureADOnlyAuthentication

## NOTES

## RELATED LINKS
