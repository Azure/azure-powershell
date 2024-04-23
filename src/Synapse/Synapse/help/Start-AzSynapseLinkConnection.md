---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/start-azsynapselinkconnection
schema: 2.0.0
---

# Start-AzSynapseLinkConnection

## SYNOPSIS
Starts a link connection.

## SYNTAX

### StartByName (Default)
```
Start-AzSynapseLinkConnection -WorkspaceName <String> -Name <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### StartByObject
```
Start-AzSynapseLinkConnection -WorkspaceObject <PSSynapseWorkspace> -Name <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### StartByInputObject
```
Start-AzSynapseLinkConnection -InputObject <PSLinkConnectionResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzSynapseLinkConnection** cmdlet starts a link connection in workspace. It will cost some time from starting to running, after calling this cmdlet you can check the detail status by calling **Get-AzSynapseLinkConnectionDetailedStatus**.

## EXAMPLES

### Example 1
```powershell
Start-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
```

This command starts a link connection named ContosoLinkConnection in workspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Workspacename ContosoWorkspace
$ws | Start-AzSynapseLinkConnection -Name ContosoLinkConnection
```

This command starts a link connection named ContosoLinkConnection in workspace through pipeline.

### Example 3
```powershell
$linkConnection = Get-AzSynapseLinkConnection -Workspacename ContosoWorkspace -Name ContosoLinkConnection
$linkConnection | Start-AzSynapseLinkConnection
```

This command starts a link connection named ContosoLinkConnection in workspace through pipeline.

### Example 4
```powershell
Start-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
Get-AzSynapseLinkConnectionDetailedStatus -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
```

```output
WorkspaceName     : ContosoWorkspace
Id                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name              : ContosoLinkConnection
IsApplyingChanges :
IsPartiallyFailed : False
StartTime         : 2022-03-10T07:57:37.8730044Z
StopTime          :
Status            : Starting
ContinuousRunId   : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Error             :
```

The **Start-AzSynapseLinkConnection** command starts a link connection named ContosoLinkConnection in workspace, then you can call **Get-AzSynapseLinkConnectionDetailedStatus** to get status of the link connection.

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
The Synapse link connection object for Azure Sql Database.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource
Parameter Sets: StartByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Synapse link connection name for Azure Sql Database.

```yaml
Type: System.String
Parameter Sets: StartByName, StartByObject
Aliases: LinkConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
This Cmdlet does not return an object by default.
If this switch is specified, it returns true if successful.

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
Parameter Sets: StartByName
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
Parameter Sets: StartByObject
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
