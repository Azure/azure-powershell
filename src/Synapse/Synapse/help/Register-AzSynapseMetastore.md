---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/powershell/module/az.synapse/register-azsynapsemetastore
schema: 2.0.0
---

# Register-AzSynapseMetastore

## SYNOPSIS
Registers files in Syms.

## SYNTAX

### RegisterByName (Default)
```
Register-AzSynapseMetastore -WorkspaceName <String> -DatabaseName <String> -InputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegisterByObject
```
Register-AzSynapseMetastore -WorkspaceObject <PSSynapseWorkspace> -DatabaseName <String> -InputFolder <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Register-AzSynapseMetastore** cmdlet registers files in Syms.

## EXAMPLES

### Example 1
```powershell
PS C:\> Register-AzSynapseMetastore -WorkspaceName ContosoWorkspace -DatabaseName ContosoDatabase -InputFolder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/"
```

This command creates a database named ContosoDatabase and registers files under folder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/" in the workspace named ContosoWorkspace.

### Example 2
```powershell
PS C:\> $ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
PS C:\> $ws | Register-AzSynapseMetastore -DatabaseName ContosoDatabase -InputFolder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/"
```

This command creates a database named ContosoDatabase and registers files under folder "https://testsymsstorage.dfs.core.windows.net/testsymscontainer/CDM/" in the workspace named ContosoWorkspace through pipeline.

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
The name of the database to be created.
The name can contain only alphanumeric characters and should not exceed 24 characters.

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

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: RegisterByName
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
Parameter Sets: RegisterByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSMetastore

## NOTES

## RELATED LINKS
