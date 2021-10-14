---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/powershell/module/az.synapse/update-azsynapsemetastore
schema: 2.0.0
---

# Update-AzSynapseMetastore

## SYNOPSIS
Updates files in Syms.

## SYNTAX

### UpdateByName (Default)
```
Update-AzSynapseMetastore -WorkspaceName <String> -DatabaseName <String> -InputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByObject
```
Update-AzSynapseMetastore -WorkspaceObject <PSSynapseWorkspace> -DatabaseName <String> -InputFolder <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObject
```
Update-AzSynapseMetastore -InputObject <PSMetastore> -InputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSynapseMetastore** cmdlet updates files in Syms.

## EXAMPLES

### Example 1
```powershell
PS C:\> Update-AzSynapseMetastore -WorkspaceName ContosoWorkspace -DatabaseName ContosoDatabase -InputFolder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/"
```

This command updates files in Syms using files under folder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/" in the database named ContosoDatabase.

### Example 2
```powershell
PS C:\> $ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
PS C:\> $ws | Update-AzSynapseMetastore -DatabaseName ContosoDatabase -InputFolder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/"
```

This command updates files in Syms using files under folder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/" in the database named ContosoDatabase through pipeline.

### Example 3
```powershell
PS C:\> $metastore = Get-AzSynapseMetastore -WorkspaceName ContosoWorkspace -DatabaseName ContosoDatabase
PS C:\> $metastore | Update-AzSynapseMetastore -InputFolder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/"
```

This command updates files in Syms using files under folder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/" in the database named ContosoDatabase through pipeline.

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

### -DatabaseName
The name of the database to be updated.

```yaml
Type: System.String
Parameter Sets: UpdateByName, UpdateByObject
Aliases:

Required: True
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

### -InputFolder
The input folder containing CDM files.

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

### -InputObject
The dataset object.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSMetastore
Parameter Sets: UpdateByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: UpdateByName
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
Parameter Sets: UpdateByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSMetastore

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSMetastore

## NOTES

## RELATED LINKS
