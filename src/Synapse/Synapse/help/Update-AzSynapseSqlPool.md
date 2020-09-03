---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/en-us/powershell/module/az.synapse/update-azsynapsesqlpool
schema: 2.0.0
---

# Update-AzSynapseSqlPool

## SYNOPSIS
Updates a Synapse Analytics SQL pool.

## SYNTAX

### UpdateByNameParameterSet (Default)
```
Update-AzSynapseSqlPool [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String> [-Version <Int32>]
 [-Tag <Hashtable>] [-PerformanceLevel <String>] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PauseByNameParameterSet
```
Update-AzSynapseSqlPool [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String> [-Version <Int32>]
 [-Suspend] [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResumeByNameParameterSet
```
Update-AzSynapseSqlPool [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String> [-Version <Int32>]
 [-Resume] [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateByParentObjectParameterSet
```
Update-AzSynapseSqlPool -Name <String> [-Version <Int32>] -WorkspaceObject <PSSynapseWorkspace>
 [-Tag <Hashtable>] [-PerformanceLevel <String>] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PauseByParentObjectParameterSet
```
Update-AzSynapseSqlPool -Name <String> [-Version <Int32>] [-Suspend] -WorkspaceObject <PSSynapseWorkspace>
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeByParentObjectParameterSet
```
Update-AzSynapseSqlPool -Name <String> [-Version <Int32>] [-Resume] -WorkspaceObject <PSSynapseWorkspace>
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PauseByInputObjectParameterSet
```
Update-AzSynapseSqlPool [-Version <Int32>] [-Suspend] -InputObject <PSSynapseSqlPool> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PauseByResourceIdParameterSet
```
Update-AzSynapseSqlPool [-Version <Int32>] [-Suspend] -ResourceId <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeByInputObjectParameterSet
```
Update-AzSynapseSqlPool [-Version <Int32>] [-Resume] -InputObject <PSSynapseSqlPool> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeByResourceIdParameterSet
```
Update-AzSynapseSqlPool [-Version <Int32>] [-Resume] -ResourceId <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObjectParameterSet
```
Update-AzSynapseSqlPool [-Version <Int32>] -InputObject <PSSynapseSqlPool> [-Tag <Hashtable>]
 [-PerformanceLevel <String>] [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateByResourceIdParameterSet
```
Update-AzSynapseSqlPool [-Version <Int32>] -ResourceId <String> [-Tag <Hashtable>] [-PerformanceLevel <String>]
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSynapseSqlPool** cmdlet updates an Azure Synapse Analytics SQL pool.

## EXAMPLES

### Example 1
```powershell
PS C:\> Update-AzSynapseSqlPool -WorkspaceName ContosoWorkspace -Name ContosoSqlPool -Tag @{'key'='value'} -PerformanceLevel DW300c
```

This command updates an Azure Synapse Analytics SQL pool.

### Example 2
```powershell
PS C:\> $ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
PS C:\> $ws | Update-AzSynapseSqlPool -Name ContosoSqlPool -Tag @{'key'='value1'}
```

This command updates an Azure Synapse Analytics SQL pool through pipeline.

### Example 3
```powershell
PS C:\> $pool = Get-AzSynapseSqlPool -WorkspaceName ContosoWorkspace -Name ContosoSqlPool
PS C:\> $pool | Update-AzSynapseSqlPool -Tag @{'key'='value2'}
```

This command updates an Azure Synapse Analytics SQL pool through pipeline.

### Example 4
```powershell
PS C:\> Update-AzSynapseSqlPool -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd3/resourceGroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace/sqlPools/ContosoSqlPool -Tag @{'key'='value3'}
```

This command updates an Azure Synapse Analytics SQL pool with resource ID.

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

### -InputObject
SQL pool input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseSqlPool
Parameter Sets: PauseByInputObjectParameterSet, ResumeByInputObjectParameterSet, UpdateByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Synapse SQL pool.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, PauseByNameParameterSet, ResumeByNameParameterSet, UpdateByParentObjectParameterSet, PauseByParentObjectParameterSet, ResumeByParentObjectParameterSet
Aliases:

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

### -PerformanceLevel
The SQL Service tier and performance level to assign to the SQL pool.
For example, DW2000c.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet, UpdateByParentObjectParameterSet, UpdateByInputObjectParameterSet, UpdateByResourceIdParameterSet
Aliases:

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
Parameter Sets: UpdateByNameParameterSet, PauseByNameParameterSet, ResumeByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource identifier of Synapse SQL Pool.

```yaml
Type: System.String
Parameter Sets: PauseByResourceIdParameterSet, ResumeByResourceIdParameterSet, UpdateByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resume
Indicates to resume the SQL pool

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ResumeByNameParameterSet, ResumeByParentObjectParameterSet, ResumeByInputObjectParameterSet, ResumeByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Suspend
Indicates to pause the SQL pool

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PauseByNameParameterSet, PauseByParentObjectParameterSet, PauseByInputObjectParameterSet, PauseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A string,string dictionary of tags associated with the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateByNameParameterSet, UpdateByParentObjectParameterSet, UpdateByInputObjectParameterSet, UpdateByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of Synapse SQL pool. For example, 2 or 3.

```yaml
Type: System.Int32
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
Parameter Sets: UpdateByNameParameterSet, PauseByNameParameterSet, ResumeByNameParameterSet
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
Parameter Sets: UpdateByParentObjectParameterSet, PauseByParentObjectParameterSet, ResumeByParentObjectParameterSet
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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseSqlPool

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseSqlPool

## NOTES

## RELATED LINKS
