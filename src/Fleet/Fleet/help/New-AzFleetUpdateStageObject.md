---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/Az.Fleet/new-azfleetupdatestageobject
schema: 2.0.0
---

# New-AzFleetUpdateStageObject

## SYNOPSIS
Create an in-memory object for UpdateStage.

## SYNTAX

```
New-AzFleetUpdateStageObject -Name <String> [-AfterStageWaitInSecond <Int32>] [-Group <IUpdateGroup[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UpdateStage.

## EXAMPLES

### EXAMPLE 1
```
New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600 | Format-List
```

### EXAMPLE 2
```
$a = New-AzFleetUpdateGroupObject -Name 'Group-a'
$b = New-AzFleetUpdateGroupObject -Name 'Group-b'                                                                           
$c = New-AzFleetUpdateGroupObject -Name 'Group-c'                                                                           
New-AzFleetUpdateStageObject -Name stag1 -Group $a,$b,$c -AfterStageWaitInSecond 3600 | Format-List
```

## PARAMETERS

### -AfterStageWaitInSecond
The time in seconds to wait at the end of this stage before starting the next one.
Defaults to 0 seconds if unspecified.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
Defines the groups to be executed in parallel in this stage.
Duplicate groups are not allowed.
Min size: 1.
To construct, see NOTES section for GROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateGroup[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the stage.
Must be unique within the UpdateRun.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.UpdateStage
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

GROUP \<IUpdateGroup\[\]\>: Defines the groups to be executed in parallel in this stage.
Duplicate groups are not allowed.
Min size: 1.
  Name \<String\>: Name of the group. 
It must match a group name of an existing fleet member.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Fleet/new-azfleetupdatestageobject](https://learn.microsoft.com/powershell/module/Az.Fleet/new-azfleetupdatestageobject)

