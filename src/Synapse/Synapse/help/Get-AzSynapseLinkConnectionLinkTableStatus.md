---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/powershell/module/az.synapse/get-azsynapselinkconnectionlinktablestatus
schema: 2.0.0
---

# Get-AzSynapseLinkConnectionLinkTableStatus

## SYNOPSIS
Gets status of link tables under a link connection.

## SYNTAX

### GetByName (Default)
```
Get-AzSynapseLinkConnectionLinkTableStatus -WorkspaceName <String> -LinkConnectionName <String>
 -MaxSegmentCount <Int32> [-ContinuationToken <Object>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByObject
```
Get-AzSynapseLinkConnectionLinkTableStatus -WorkspaceObject <PSSynapseWorkspace> -LinkConnectionName <String>
 -MaxSegmentCount <Int32> [-ContinuationToken <Object>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByInputObject
```
Get-AzSynapseLinkConnectionLinkTableStatus -MaxSegmentCount <Int32> -InputObject <PSLinkConnectionResource>
 [-ContinuationToken <Object>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSynapseLinkConnectionLinkTablesStatus** cmdlet gets status of link tables under a link connection.

## EXAMPLES

### Example 1
```powershell
Get-AzSynapseLinkConnectionLinkTableStatus -WorkspaceName ContosoWorkspace -LinkConnectionName ContosoLinkConnection -MaxSegmentCount 50
```

This command gets status of link tables with max segment count 50 under link connection ContosoLinkConnection in workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Get-AzSynapseLinkConnectionLinkTableStatus -LinkConnectionName ContosoLinkConnection -MaxSegmentCount 50
```

This command gets status of link tables with max segment count 50 under link connection ContosoLinkConnection in workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
$lc = Get-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
$lc | Get-AzSynapseLinkConnectionLinkTableStatus -MaxSegmentCount 50
```

This command gets status of link tables with max segment count 50 under a link connection through pipeline.

## PARAMETERS

### -ContinuationToken
Continuation token to query table status.

```yaml
Type: Object
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
Type: IAzureContextContainer
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
Type: PSLinkConnectionResource
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
Type: String
Parameter Sets: GetByName, GetByObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxSegmentCount
Max segment count to query table status.

```yaml
Type: Int32
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

### Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionQueryTableStatus

## NOTES

## RELATED LINKS
