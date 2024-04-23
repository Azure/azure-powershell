---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapselinkconnectionlinktable
schema: 2.0.0
---

# Get-AzSynapseLinkConnectionLinkTable

## SYNOPSIS
Gets information about link tables under a link connection.

## SYNTAX

### GetByName (Default)
```
Get-AzSynapseLinkConnectionLinkTable -WorkspaceName <String> -LinkConnectionName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByObject
```
Get-AzSynapseLinkConnectionLinkTable -WorkspaceObject <PSSynapseWorkspace> -LinkConnectionName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByInputObject
```
Get-AzSynapseLinkConnectionLinkTable -InputObject <PSLinkConnectionResource>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSynapseLinkConnectionLinkTable** cmdlet gets information about link tables under a link connection.

## EXAMPLES

### Example 1
```powershell
Get-AzSynapseLinkConnectionLinkTable -WorkspaceName ContosoWorkspace -LinkConnectionName ContosoLinkConnection
```

This command gets information about link tables under link connection ContosoLinkConnection in workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Get-AzSynapseLinkConnectionLinkTable -LinkConnectionName ContosoLinkConnection
```

This command gets information about link tables under link connection ContosoLinkConnection in workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
$lc = Get-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
$lc | Get-AzSynapseLinkConnectionLinkTable
```

This command gets information about link tables under a link connection through pipeline.

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

### -InputObject
The information about the link connection.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource
Parameter Sets: GetByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LinkConnectionName
Name of link connection.

```yaml
Type: System.String
Parameter Sets: GetByName, GetByObject
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSLinkTableResource

## NOTES

## RELATED LINKS
