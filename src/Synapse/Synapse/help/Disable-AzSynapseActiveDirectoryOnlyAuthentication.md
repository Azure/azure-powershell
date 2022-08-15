---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/powershell/module/az.synapse/disable-azsynapseactivedirectoryonlyauthentication
schema: 2.0.0
---

# Disable-AzSynapseActiveDirectoryOnlyAuthentication

## SYNOPSIS
Disables Azure Active Directory (Azure AD) only authentication for a specific Synapse workspace.

## SYNTAX

### DisableByNameParameterSet (Default)
```
Disable-AzSynapseActiveDirectoryOnlyAuthentication [-ResourceGroupName <String>] -WorkspaceName <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisableByParentObjectParameterSet
```
Disable-AzSynapseActiveDirectoryOnlyAuthentication -WorkspaceObject <PSSynapseWorkspace>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisableByResourceIdParameterSet
```
Disable-AzSynapseActiveDirectoryOnlyAuthentication -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Disable-AzSynapseActiveDirectoryOnlyAuthentication** cmdlet disables Azure Active Directory (Azure AD) only authentication for a specific Synapse workspace.

## EXAMPLES

### Example 1
```powershell
Disable-AzSynapseActiveDirectoryOnlyAuthentication -WorkspaceName ContosoWorkspace
```
```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                              False Consistent 3/23/2022 8:27:47 AM
```
This command disables Azure AD only authentication for workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -WorkspaceName ContosoWorkspace
$ws | Disable-AzSynapseActiveDirectoryOnlyAuthentication
```
```output
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                              False Consistent 3/23/2022 8:27:47 AM
```
This command disables Azure AD only authentication for workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
Disable-AzSynapseActiveDirectoryOnlyAuthentication -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd/resourceGroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace
```
```outout
WorkspaceName     AzureADOnlyAuthenticationProperty State      CreationDate
-------------     --------------------------------- -----      ------------
ContosoWorkspace                              False Consistent 3/23/2022 8:27:47 AM
```
This command disables Azure AD only authentication for workspace ContosoWorkspace by ResourceId.

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
Parameter Sets: DisableByNameParameterSet
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
Parameter Sets: DisableByResourceIdParameterSet
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
Parameter Sets: DisableByNameParameterSet
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
Parameter Sets: DisableByParentObjectParameterSet
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
