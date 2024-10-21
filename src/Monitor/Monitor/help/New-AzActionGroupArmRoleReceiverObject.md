---
external help file: Az.ActionGroup.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongrouparmrolereceiverobject
schema: 2.0.0
---

# New-AzActionGroupArmRoleReceiverObject

## SYNOPSIS
Create an in-memory object for ArmRoleReceiver.

## SYNTAX

```
New-AzActionGroupArmRoleReceiverObject -Name <String> -RoleId <String> [-UseCommonAlertSchema <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ArmRoleReceiver.

## EXAMPLES

### Example 1: create action group arm role receiver
```powershell
New-AzActionGroupArmRoleReceiverObject -Name "sample arm role" -RoleId "8e3af657-a8ff-443c-a75c-2fe8c4bcb635" -UseCommonAlertSchema $true
```

```output
Name            RoleId                               UseCommonAlertSchema
----            ------                               --------------------
sample arm role 8e3af657-a8ff-443c-a75c-2fe8c4bcb635                 True
```

This command creates action group arm role receiver object.

## PARAMETERS

### -Name
The name of the arm role receiver.
Names must be unique across all receivers within an action group.

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

### -RoleId
The arm role id.

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

### -UseCommonAlertSchema
Indicates whether to use common alert schema.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ArmRoleReceiver

## NOTES

## RELATED LINKS
