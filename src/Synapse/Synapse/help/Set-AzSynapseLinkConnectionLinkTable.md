---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/set-azsynapselinkconnectionlinktables
schema: 2.0.0
---

# Set-AzSynapseLinkConnectionLinkTable

## SYNOPSIS
Edits link tables under a link connection.

## SYNTAX

### SetByName (Default)
```
Set-AzSynapseLinkConnectionLinkTable -WorkspaceName <String> -EditTablesRequestFile <String>
 -LinkConnectionName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByObject
```
Set-AzSynapseLinkConnectionLinkTable -WorkspaceObject <PSSynapseWorkspace> -EditTablesRequestFile <String>
 -LinkConnectionName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByInputObject
```
Set-AzSynapseLinkConnectionLinkTable -EditTablesRequestFile <String> -InputObject <PSLinkConnectionResource>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSynapseLinkConnectionLinkTables** cmdlet edits link tables under a link connection.

## EXAMPLES

### Example 1
```powershell
<#
edittables.json
{ 
  "linkTables": [ 
    { 
      "id": "00000000000000000000000000000000", // please change to your link table Id: a uuid
      "source": { 
        "tableName": "sampleSourceTable", // please change to your source table name
        "schemaName": "sampleSourceSchema" // please change to your source database schema name
      }, 
      "target": { 
        "tableName": "sampleTargetTable", // please change to your target table name
        "schemaName": "sampleTargetSchema", // please change to your target database schema name
        "distributionOptions": { 
          "type": "Round_RoBin", // please choose a type from Hash, Round_RoBin, Replicate
          "distributionColumn": "sampleColumn" // please change to the column name
        }
      }, 
      "operationType": "add" // please choose a value from add, update, remove
    }
  ]
}
#>
Set-AzSynapseLinkConnectionLinkTable -WorkspaceName ContosoWorkspace -LinkConnectionName ContosoLinkConnection -EditTablesRequestFile "C:\samples\edittables.json"
```

This command edits link tables under link connection ContosoLinkConnection in workspace ContosoWorkspace.
The command bases the link tables on information in the edittables.json file.
This file includes information about edited link table.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Set-AzSynapseLinkConnectionLinkTable -LinkConnectionName ContosoLinkConnection -EditTablesRequestFile "C:\samples\edittables.json"
```

This command edits link tables under link connection ContosoLinkConnection in workspace ContosoWorkspace through pipeline.
The command bases the link tables on information in the edittables.json file.
This file includes information about edited link table.

### Example 3
```powershell
$lc = Get-AzSynapseLinkConnection -WorkspaceName ContosoWorkspace -Name ContosoLinkConnection
$lc | Set-AzSynapseLinkConnectionLinkTable -EditTablesRequestFile "C:\samples\edittables.json"
```

This command edits link tables under a link connection through pipeline.
The command bases the link tables on information in the edittables.json file.
This file includes information about edited link table.

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

### -EditTablesRequestFile
Specifies a local file path for a file to edit link tables

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: File

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The information about the link connection.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource
Parameter Sets: SetByInputObject
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
Parameter Sets: SetByName, SetByObject
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
Parameter Sets: SetByName
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
Parameter Sets: SetByObject
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

### System.Void

## NOTES

## RELATED LINKS
