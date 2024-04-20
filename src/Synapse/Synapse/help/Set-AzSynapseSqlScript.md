---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/set-azsynapsesqlscript
schema: 2.0.0
---

# Set-AzSynapseSqlScript

## SYNOPSIS
Creates or updates a SQL script in a workspace.

## SYNTAX

### SetByName (Default)
```
Set-AzSynapseSqlScript -WorkspaceName <String> [-Name <String>] -DefinitionFile <String> [-ResultLimit <Int32>]
 [-FolderPath <String>] [-Description <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByNameAndSqlPool
```
Set-AzSynapseSqlScript -WorkspaceName <String> -SqlPoolName <String> -SqlDatabaseName <String> [-Name <String>]
 -DefinitionFile <String> [-ResultLimit <Int32>] [-FolderPath <String>] [-Description <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByObject
```
Set-AzSynapseSqlScript -WorkspaceObject <PSSynapseWorkspace> [-Name <String>] -DefinitionFile <String>
 [-ResultLimit <Int32>] [-FolderPath <String>] [-Description <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByObjectAndSqlPool
```
Set-AzSynapseSqlScript -WorkspaceObject <PSSynapseWorkspace> -SqlPoolName <String> -SqlDatabaseName <String>
 [-Name <String>] -DefinitionFile <String> [-ResultLimit <Int32>] [-FolderPath <String>]
 [-Description <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSynapseSqlScript** cmdlet creates or updates a SQL script in a workspace.

## EXAMPLES

### Example 1
```powershell
Set-AzSynapseSqlScript -WorkspaceName ContosoWorkspace -DefinitionFile "C:\\samples\\sqlscript.sql"
```

This command creates or updates a SQL script from SQL script file sqlscript.sql in the workspace named ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Set-AzSynapseSqlScript -DefinitionFile "C:\\samples\\sqlscript.sql"
```

This command creates or updates a SQL script from SQL script file sqlscript.sql in the workspace named ContosoWorkspace.

### Example 3
```powershell
Set-AzSynapseSqlScript -WorkspaceName ContosoWorkspace -DefinitionFile "C:\\samples\\sqlscript.sql"  -SqlPoolName Contososqlpool -SqlDatabaseName Contosodatabase
```

This command creates or updates a SQL script from SQL script file sqlscript.sql which connects to ContosoSqlPool and uses the database named Contosodatabase in the workspace named ContosoWorkspace.

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

### -DefinitionFile
The SQL file path.

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

### -Description
The description of the SQL script.

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

### -FolderPath
The folder that this SQL script is in.
If specify a multi-level path such as \[rootFolder/subFolder\], the SqlScript will appear at the bottom level.
If not specified, this SQL script will appear at the root level.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FolderName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The sql script name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SqlScriptName

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

### -ResultLimit
Limit of results, '-1' for no limit.

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

### -SqlDatabaseName
Which database the sql script is going to use.

```yaml
Type: System.String
Parameter Sets: SetByNameAndSqlPool, SetByObjectAndSqlPool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlPoolName
Which sql pool the sql script is going to connect to.

```yaml
Type: System.String
Parameter Sets: SetByNameAndSqlPool, SetByObjectAndSqlPool
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
Parameter Sets: SetByName, SetByNameAndSqlPool
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
Parameter Sets: SetByObject, SetByObjectAndSqlPool
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

### Microsoft.Azure.Commands.Synapse.Models.PSSqlScriptResource

## NOTES

## RELATED LINKS

[Export-AzSynapseSqlScript](./Export-AzSynapseSqlScript.md)

[Get-AzSynapseSqlScript](./Get-AzSynapseSqlScript.md)

[Remove-AzSynapseSqlScript](./Remove-AzSynapseSqlScript.md)