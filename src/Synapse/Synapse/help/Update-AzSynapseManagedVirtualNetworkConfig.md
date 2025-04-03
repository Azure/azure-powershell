---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/update-azsynapsemanagedvirtualnetworkconfig
schema: 2.0.0
---

# Update-AzSynapseManagedVirtualNetworkConfig

## SYNOPSIS
Updates managed virtual network configuration to workspace.

## SYNTAX

```
Update-AzSynapseManagedVirtualNetworkConfig -WorkspaceObject <PSSynapseWorkspace>
 [-PreventDataExfiltration <Boolean>] [-AllowedAadTenantIdsForLinking <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSynapseManagedVirtualNetworkConfig** cmdlet updates managed virtual network configuration to workspace.

## EXAMPLES

### Example 1
```powershell
$ws = Get-AzSynapseWorkspace -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace 
$ws = $ws | Update-AzSynapseManagedVirtualNetworkConfig -AllowedAadTenantIdsForLinking 00001111-aaaa-2222-bbbb-3333cccc4444 
$ws | Update-AzSynapseWorkspace
```

The first command retrieves a workspace object. The second command updates the allowed AAD tenant IDs. The third command updates the workspace.

## PARAMETERS

### -AllowedAadTenantIdsForLinking
The allowed AAD tenant IDs for linking.

```yaml
Type: System.String[]
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

### -PreventDataExfiltration
Indicates whether to prevent data exfiltration.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceObject
workspace input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## NOTES

## RELATED LINKS
