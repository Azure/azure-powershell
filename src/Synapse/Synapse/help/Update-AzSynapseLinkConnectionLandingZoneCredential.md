---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/update-azsynapselinkconnectionlandingzonecredential
schema: 2.0.0
---

# Update-AzSynapseLinkConnectionLandingZoneCredential

## SYNOPSIS
Updates the landing zone credential of a link connection.

## SYNTAX

### UpdateByName (Default)
```
Update-AzSynapseLinkConnectionLandingZoneCredential -WorkspaceName <String> -LinkConnectionName <String>
 -SasToken <SecureString> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByObject
```
Update-AzSynapseLinkConnectionLandingZoneCredential -WorkspaceObject <PSSynapseWorkspace>
 -LinkConnectionName <String> -SasToken <SecureString> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObject
```
Update-AzSynapseLinkConnectionLandingZoneCredential -InputObject <PSLinkConnectionResource>
 -SasToken <SecureString> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSynapseLinkConnectionLandingZoneCredential** cmdlet updates the landing zone credential of a link connection.

## EXAMPLES

### Example 1
```powershell
Update-AzSynapseLinkConnectionLandingZoneCredential -WorkspaceName ContosoWorkspace -LinkConnectionName ContosoLinkConnection -SasToken "SampleSasToken"
```

This command updates the landing zone credential with sas token "exampleSasToken" of link connection ContosoLinkConnection in workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Update-AzSynapseLinkConnectionLandingZoneCredential -LinkConnectionName ContosoLinkConnection -SasToken "SampleSasToken"
```

This command updates the landing zone credential with sas token "exampleSasToken" of link connection ContosoLinkConnection in workspace ContosoWorkspace through pipeline.

### Example 3
```powershell
$lc = Get-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
$lc | Update-AzSynapseLinkConnectionLandingZoneCredential -SasToken "SampleSasToken"
```

This command updates the landing zone credential with sas token "exampleSasToken" of a link connection through pipeline.

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
Parameter Sets: UpdateByInputObject
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
Parameter Sets: UpdateByName, UpdateByObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasToken
Landing zone's sas token.

```yaml
Type: Azure.Analytics.Synapse.Artifacts.Models.SecureString
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
Parameter Sets: UpdateByName
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
Parameter Sets: UpdateByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
