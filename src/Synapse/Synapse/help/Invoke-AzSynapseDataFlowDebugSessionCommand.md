---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/invoke-azsynapsedataflowdebugsessioncommand
schema: 2.0.0
---

# Invoke-AzSynapseDataFlowDebugSessionCommand

## SYNOPSIS
Invoke debug action in data flow debug session.

## SYNTAX

### InvokeByName (Default)
```
Invoke-AzSynapseDataFlowDebugSessionCommand -WorkspaceName <String> -SessionId <String> -Command <String>
 -StreamName <String> [-RowLimit <Int32>] [-Expression <String>]
 [-Column <System.Collections.Generic.List`1[System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InvokeByObject
```
Invoke-AzSynapseDataFlowDebugSessionCommand -WorkspaceObject <PSSynapseWorkspace> -SessionId <String>
 -Command <String> -StreamName <String> [-RowLimit <Int32>] [-Expression <String>]
 [-Column <System.Collections.Generic.List`1[System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This command executes data preview/stats preview/expression preview for different streams of data flow in debug session. The PowerShell command sequence for data flow debug workflow should be:

Start-AzSynapseDataFlowDebugSession  
Add-AzSynapseDataFlowDebugSessionPackage  
Invoke-AzSynapseDataFlowDebugSessionCommand (repeat this step for different commands/targets, or repeat step 2-3 in order to change the package file)  
Stop-AzSynapseDataFlowDebugSession  

## EXAMPLES

### Example 1
<!-- Skip: Output cannot be splitted from code -->


```powershell
$result = Invoke-AzSynapseDataFlowDebugSessionCommand -WorkspaceName ContosoWorkspace -Command executePreviewQuery -SessionId 3afb278e-ac5f-469f-a0b6-2f04c3ab59bc -StreamName source1 -RowLimit 100 -AsJob
$result | Format-Table -wrap

Id     Name                       PSJobTypeName          State         HasMoreData     Location         Command
--     ----                       -------------          -----         -----------     --------         -------
1      Long Running Operation     AzureLongRunningJob`1  Completed     True            localhost        Invoke-AzSynapseDataFlowDebugSessionCommand
       for 'Invoke-AzSynapseD                                                             
       ataFlowDebugSessionCommand'            

$output = ConvertFrom-Json($result.Output.Data)
$output.output

    {
      "schema": "output(ResourceAgencyNum as string, PublicName as string)" ,
      "data": [["4445679354", "Syrian Refugee Information", 1], ["44456793", "Syrian Refugee Information", 1]]
    }
```

This example invokes data preview command for debug session "3afb278e-ac5f-469f-a0b6-2f04c3ab59bc" in Synapse workspace "ContosoWorkspace" and then convert the JSON output into readable string.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Invoke-AzSynapseDataFlowDebugSessionCommand -Command executePreviewQuery -SessionId 3afb278e-ac5f-469f-a0b6-2f04c3ab59bc -StreamName source1 -RowLimit 100
```

This example invokes data preview command for debug session "3afb278e-ac5f-469f-a0b6-2f04c3ab59bc" in Synapse workspace "ContosoWorkspace" through pipeline. 

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

### -Column
The column list for data flow statistics preview.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Command
The data flow debug command.
Optionals are executePreviewQuery, executeStatisticsQuery and executeExpressionQuery.

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

### -Expression
The expression for data flow expression preview.

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

### -RowLimit
The row limit for data flow data preview.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionId
Identifier for Synapse data flow debug session.

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

### -StreamName
The stream name of data flow for debugging.

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
Parameter Sets: InvokeByName
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
Parameter Sets: InvokeByObject
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

### Microsoft.Azure.Commands.Synapse.Models.PSDataFlowDebugCommandResponse

## NOTES

## RELATED LINKS
