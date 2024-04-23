---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/set-azsynapsesparkjobdefinition
schema: 2.0.0
---

# Set-AzSynapseSparkJobDefinition

## SYNOPSIS
Creates a Spark job definition in workspace.

## SYNTAX

### SetByName (Default)
```
Set-AzSynapseSparkJobDefinition -WorkspaceName <String> -Name <String> -DefinitionFile <String>
 [-FolderPath <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByObject
```
Set-AzSynapseSparkJobDefinition -WorkspaceObject <PSSynapseWorkspace> -Name <String> -DefinitionFile <String>
 [-FolderPath <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSynapseSparkJobDefinition** cmdlet creates a Spark job definition in workspace.

## EXAMPLES

### Example 1
```powershell
Set-AzSynapseSparkJobDefinition -WorkspaceName ContosoWorkspace -Name ContosoSparkJobDefinition -DefinitionFile "C:\sparkJobDefinition.json"
```

This command creates a Spark job definition named ContosoSparkJobDefinition in the workspace named ContosoWorkspace.
The command bases the Spark job definition on information in the sparkJobDefinition.json file.

### Example 2
```powershell
Set-AzSynapseSparkJobDefinition -WorkspaceName ContosoWorkspace -Name ContosoSparkJobDefinition -DefinitionFile "C:\sparkJobDefinition.json" -FolderPath ContosoFolder
```

This command creates a Spark job definition named ContosoSparkJobDefinition and specify a folder path ContosoFolder where the spark job definition will be placed in the workspace named ContosoWorkspace.
The command bases the Spark job definition on information in the sparkJobDefinition.json file.

### Example 3
```powershell
Set-AzSynapseSparkJobDefinition -WorkspaceName ContosoWorkspace -Name ContosoSparkJobDefinition -DefinitionFile "C:\sparkJobDefinition.json" -FolderPath ContosoFolder/SubFolder
```

This command creates a Spark job definition named ContosoSparkJobDefinition and specify a multi-level folder path ContosoFolder/SubFolder where the spark job definition will be placed in the workspace named ContosoWorkspace.
The command bases the Spark job definition on information in the sparkJobDefinition.json file.

### Example 4
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Set-AzSynapseSparkJobDefinition -Name ContosoSparkJobDefinition -DefinitionFile "C:\sparkJobDefinition.json"
```

This command creates a Spark job definition named ContosoSparkJobDefinition in the workspace named ContosoWorkspace through pipeline.
The command bases the Spark job definition on information in the sparkJobDefinition.json file.

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

### -FolderPath
The folder that this Spark job definition is in. If specify a multi-level path such as [rootFolder/subFolder], the Spark job definition will appear at the bottom level. If not specified, this Spark job definition will appear at the root level.

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

### -Name
The Spark job definition name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SparkJobDefinitionName

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
Parameter Sets: SetByName
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
Parameter Sets: SetByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSSparkJobDefinitionResource

## NOTES

## RELATED LINKS
