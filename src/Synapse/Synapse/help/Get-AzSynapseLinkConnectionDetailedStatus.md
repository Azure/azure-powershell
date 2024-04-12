---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapselinkconnectiondetailedstatus
schema: 2.0.0
---

# Get-AzSynapseLinkConnectionDetailedStatus

## SYNOPSIS
Gets detail status about a link connection in workspace.

## SYNTAX

### GetByName (Default)
```
Get-AzSynapseLinkConnectionDetailedStatus -WorkspaceName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByObject
```
Get-AzSynapseLinkConnectionDetailedStatus -WorkspaceObject <PSSynapseWorkspace> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSynapseLinkConnectionDetailedStatus** cmdlet gets detail status about a link connection in workspace. After starting/stopping a link connection, you can use this cmdlet to get the status of the link connection.

## EXAMPLES

### Example 1
```powershell
Get-AzSynapseLinkConnectionDetailedStatus -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
```

Gets detail status about link connection ContosoLinkConnection in the workspace ContosoWorkspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Get-AzSynapseLinkConnectionDetailedStatus -Name ContosoLinkConnection
```

This command gets detail status about link connection ContosoLinkConnection under a workspace through pipeline.

### Example 3
```powershell
Start-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
Get-AzSynapseLinkConnectionDetailedStatus -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
```

Starts a link connection named ContosoLinkConnection in workspace ContosoWorkspace, it will cost some time to start, then you can call **Get-AzSynapseLinkConnectionDetailedStatus** to monitor its status.

### Example 4
```powershell
Stop-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
Get-AzSynapseLinkConnectionDetailedStatus -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
```

Stops a link connection named ContosoLinkConnection in workspace ContosoWorkspace, it will cost some time from running to stop, then you can call **Get-AzSynapseLinkConnectionDetailedStatus** to monitor its status.

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
The Synapse link connection name for Azure Sql Database.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LinkConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionDetailedStatus

## NOTES

## RELATED LINKS
