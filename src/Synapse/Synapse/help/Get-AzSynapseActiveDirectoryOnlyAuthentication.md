---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapseactivedirectoryonlyauthentication
schema: 2.0.0
---

# Get-AzSynapseActiveDirectoryOnlyAuthentication

## SYNOPSIS
Gets Microsoft Entra-only authentication for a specific Synapse workspace.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSynapseActiveDirectoryOnlyAuthentication [-ResourceGroupName <String>] -WorkspaceName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSynapseActiveDirectoryOnlyAuthentication -WorkspaceObject <PSSynapseWorkspace>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSynapseActiveDirectoryOnlyAuthentication -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSynapseActiveDirectoryOnlyAuthentication** cmdlet gets Microsoft Entra-only authentication for a specific Synapse workspace.

## EXAMPLES

### Example 1
```powershell
Get-AzSynapseActiveDirectoryOnlyAuthentication -WorkspaceName ContosoWorkspace
```

```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                               True Consistent 3/23/2022 8:27:47 AM
```

This command gets Microsoft Entra-only authentication status for Synapse workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Get-AzSynapseActiveDirectoryOnlyAuthentication
```

```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                               True Consistent 3/23/2022 8:27:47 AM
```

This command gets Microsoft Entra-only authentication status for Synapse workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
Get-AzSynapseActiveDirectoryOnlyAuthentication -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd/resourceGroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace
```

```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                               True Consistent 3/23/2022 8:27:47 AM
```

This command gets Microsoft Entra-only authentication for workspace ContosoWorkspace by ResourceId.

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
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByResourceIdParameterSet
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
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
