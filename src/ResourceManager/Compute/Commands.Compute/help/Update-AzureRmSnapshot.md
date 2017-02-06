---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmSnapshot

## SYNOPSIS
Updates a snapshot.

## SYNTAX

### InvokeByDynamicParameters (Default)
```
Update-AzureRmSnapshot [-WhatIf] [-Confirm] [-ResourceGroupName] <String> [-SnapshotName] <String>
 [-SnapshotUpdate] <SnapshotUpdate> [<CommonParameters>]
```

### InvokeByDynamicParametersForFriendMethod
```
Update-AzureRmSnapshot [-WhatIf] [-Confirm] [-ResourceGroupName] <String> [-SnapshotName] <String>
 [-Snapshot] <Snapshot> [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzureRmSnapshot** cmdlet updates a snapshot.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ResourceGroupName
Specifies the name of a resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Snapshot
Specifies a local snapshot object.

```yaml
Type: Snapshot
Parameter Sets: InvokeByDynamicParametersForFriendMethod
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SnapshotName
Specifies the name of a snapshot.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SnapshotUpdate
Specifies a local snapshot update object.

```yaml
Type: SnapshotUpdate
Parameter Sets: InvokeByDynamicParameters
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Management.Compute.Models.SnapshotUpdate
Microsoft.Azure.Management.Compute.Models.Snapshot

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

