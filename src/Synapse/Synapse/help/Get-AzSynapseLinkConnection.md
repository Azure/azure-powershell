---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/powershell/module/az.synapse/get-azsynapselinkconnection
schema: 2.0.0
---

# Get-AzSynapseLinkConnection

## SYNOPSIS
Gets information about link connections in workspace.

## SYNTAX

### GetByName (Default)
```
Get-AzSynapseLinkConnection -WorkspaceName <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByObject
```
Get-AzSynapseLinkConnection -WorkspaceObject <PSSynapseWorkspace> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSynapseLinkConnection** cmdlet gets information about link connections in a workspace. If you specify the name of a link connection, the cmdlet gets information about that link connection. If you do not specify a name, the cmdlet gets information about all link connections in the workspace.

## EXAMPLES

### Example 1
```powershell
Get-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace
```

Gets a list of all link connections in the workspace ContosoWorkspace.

### Example 2
```powershell
Get-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
```

Gets a single link connection named ContosoLinkConnection in the workspace ContosoWorkspace.

### Example 3
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Get-AzSynapseLinkConnection
```

This command gets all link connections under a workspace through pipeline.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Synapse link connection name for Azure Sql Database.

```yaml
Type: String
Parameter Sets: (All)
Aliases: LinkConnectionName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: String
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
Type: PSSynapseWorkspace
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

### Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource

## NOTES

## RELATED LINKS
