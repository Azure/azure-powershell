---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/export-azsynapsekqlscript
schema: 2.0.0
---

# Export-AzSynapseKqlScript

## SYNOPSIS
Exports KQL script.

## SYNTAX

### ExportByName (Default)
```
Export-AzSynapseKqlScript -WorkspaceName <String> [-Name <String>] -OutputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ExportByObject
```
Export-AzSynapseKqlScript -WorkspaceObject <PSSynapseWorkspace> [-Name <String>] -OutputFolder <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ExportByInputObject
```
Export-AzSynapseKqlScript -InputObject <PSKqlScriptResource> -OutputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Export-AzSynapseKqlScript** cmdlet exports an Azure Synapse KQL script to a kusto query (.kql) file. 
The name of the KQL script becomes the name of the exported file. If you specify the name of a KQL script, the cmdlet exports that KQL script. If you do not specify a name, the cmdlet export all KQL scripts in the workspace.

## EXAMPLES

### Example 1
```powershell
Export-AzSynapseKqlScript -WorkspaceName ContosoWorkspace -OutputFolder "C:\KqlScirpt"
```

Exports all KQL scripts in the workspace ContosoWorkspace to the folder "C:\KqlScirpt".

### Example 2
```powershell
Export-AzSynapseKqlScript -WorkspaceName ContosoWorkspace -Name ContosoKqlScript -OutputFolder "C:\KqlScript"
```

Exports a single KQL script called ContosoKqlScript in the workspace ContosoWorkspace to the folder "C:\KqlScript".

### Example 3
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Export-AzSynapseKqlScript -Name ContosoKqlScript -OutputFolder "C:\KqlScript"
```

Exports a single KQL script called ContosoKqlScript in the workspace ContosoWorkspace to the folder "C:\KqlScript" through pipeline.

### Example 4
```powershell
$KqlScript = Get-AzSynapseKqlScript -WorkspaceName ContosoWorkspace -Name ContosoKqlScript
$KqlScript | Export-AzSynapseKqlScript -OutputFolder "C:\KqlScript"
```

Exports a single KQL script called ContosoKqlScript in the workspace ContosoWorkspace to the folder "C:\KqlScript" through pipeline.

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
KQL script object.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSKqlScriptResource
Parameter Sets: ExportByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
KQL script name.

```yaml
Type: System.String
Parameter Sets: ExportByName, ExportByObject
Aliases: KqlScriptName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputFolder
The folder where the KQL script should be placed.

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
Parameter Sets: ExportByName
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
Parameter Sets: ExportByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSKqlScriptResource

## OUTPUTS

### System.IO.FileInfo

## NOTES

## RELATED LINKS
