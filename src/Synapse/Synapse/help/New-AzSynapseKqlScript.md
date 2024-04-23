---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/new-azsynapsekqlscript
schema: 2.0.0
---

# New-AzSynapseKqlScript

## SYNOPSIS
Creates or updates a KQL script in a workspace.

## SYNTAX

### SetByName (Default)
```
New-AzSynapseKqlScript -WorkspaceName <String> [-Name <String>] -DefinitionFile <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByNameAndKustoPoolDatabase
```
New-AzSynapseKqlScript -WorkspaceName <String> [-Name <String>] -KustoPoolName <String>
 -KustoPoolDatabaseName <String> -DefinitionFile <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByObject
```
New-AzSynapseKqlScript -WorkspaceObject <PSSynapseWorkspace> [-Name <String>] -DefinitionFile <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByObjectAndKustoPoolDatabase
```
New-AzSynapseKqlScript -WorkspaceObject <PSSynapseWorkspace> [-Name <String>] -KustoPoolName <String>
 -KustoPoolDatabaseName <String> -DefinitionFile <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSynapseKqlScript** cmdlet creates or updates a KQL script in a workspace.

## EXAMPLES

### Example 1
```powershell
New-AzSynapseKqlScript -WorkspaceName ContosoWorkspace -DefinitionFile "C:\samples\KqlScript.kql"
```

This command creates or updates a KQL script from Kusto query file KqlScript.kql in the workspace named ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | New-AzSynapseKqlScript -DefinitionFile "C:\samples\KqlScript.kql"
```

This command creates or updates a KQL script from Kusto query file KqlScript.kql in the workspace named ContosoWorkspace through pipeline.

### Example 3
```powershell
New-AzSynapseKqlScript -WorkspaceName ContosoWorkspace -DefinitionFile "C:\samples\KqlScript.kql" -KustoPoolName ContosoKustoPool -KustoPoolDatabaseName ContosoKustoPoolDatabase
```

This command creates or updates a KqlScript from Kusto query file KqlScript.kql which attaches to ContosoKustoPoolDatabase in the workspace named ContosoWorkspace.

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
The KQL file path.

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

### -KustoPoolDatabaseName
Name of Synapse Kusto database.

```yaml
Type: System.String
Parameter Sets: SetByNameAndKustoPoolDatabase, SetByObjectAndKustoPoolDatabase
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KustoPoolName
Name of Synapse Kusto pool.

```yaml
Type: System.String
Parameter Sets: SetByNameAndKustoPoolDatabase, SetByObjectAndKustoPoolDatabase
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
KQL script name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: KqlScriptName

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
Parameter Sets: SetByName, SetByNameAndKustoPoolDatabase
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
Parameter Sets: SetByObject, SetByObjectAndKustoPoolDatabase
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

### Microsoft.Azure.Commands.Synapse.Models.PSKqlScriptResource

## NOTES

## RELATED LINKS
