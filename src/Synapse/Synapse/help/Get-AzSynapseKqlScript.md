---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapsekqlscript
schema: 2.0.0
---

# Get-AzSynapseKqlScript

## SYNOPSIS
Gets information about KQL scripts in a workspace.

## SYNTAX

### GetByName (Default)
```
Get-AzSynapseKqlScript -WorkspaceName <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByObject
```
Get-AzSynapseKqlScript -WorkspaceObject <PSSynapseWorkspace> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSynapseKqlScript** cmdlet gets information about KQL scripts in a workspace. If you specify the name of a KQL script, the cmdlet gets information about that KQL script. If you do not specify a name, the cmdlet gets information about all KQL scripts in the workspace.

## EXAMPLES

### Example 1
```powershell
Get-AzSynapseKqlScript -WorkspaceName ContosoWorkspace
```

Gets a list of all KQL scripts in the workspace ContosoWorkspace.

### Example 2
```powershell
Get-AzSynapseKqlScript -WorkspaceName ContosoWorkspace -Name ContosoKqlScript
```

Gets a single KQL script called ContosoKqlScript in the workspace ContosoWorkspace.

### Example 3
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Get-AzSynapseKqlScript -Name ContosoKqlScript
```

Gets a single KQL script called ContosoKqlScript in the workspace ContosoWorkspace through pipeline.

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

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: GetByName
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
Parameter Sets: GetByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSKqlScriptResource

## NOTES

## RELATED LINKS
