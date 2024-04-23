---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/invoke-azdevcenteruserdelaydevboxaction
schema: 2.0.0
---

# Invoke-AzDevCenterUserDelayDevBoxAction

## SYNOPSIS
Delays the occurrence of an action.

## SYNTAX

### Delay1 (Default)
```
Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -DelayTime <TimeSpan> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Delay
```
Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -Name <String> -DelayTime <TimeSpan> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Delay1ByDevCenter
```
Invoke-AzDevCenterUserDelayDevBoxAction -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -DelayTime <TimeSpan> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DelayByDevCenter
```
Invoke-AzDevCenterUserDelayDevBoxAction -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -Name <String> -DelayTime <TimeSpan> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delays the occurrence of an action.

## EXAMPLES

### Example 1: Delay all actions on the dev box by endpoint
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -UserId "me" -ProjectName DevProject -DelayTime "01:30"
```

This command delays all actions on the dev box "myDevBox" to the time 1 hour and 30 minutes from the earliest scheduled action.

### Example 2: Delay all actions on the dev box by dev center
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -DevCenterName Contoso -DevBoxName myDevBox -ProjectName DevProject -DelayTime "02:00"
```

This command delays all actions on the dev box "myDevBox" to the time 2 hours from the earliest scheduled action.

### Example 3: Delay an action on the dev box by endpoint
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -ProjectName DevProject -Name "schedule-default" -DelayTime "00:30"
```

This command delays the action "schedule-default" for the dev box "myDevBox" for 30 minutes.

### Example 4: Delay an action on the dev box by dev center
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -DevCenterName Contoso -DevBoxName myDevBox -UserId "me" -ProjectName DevProject -Name "schedule-default" -DelayTime "05:15"
```

This command delays the action "schedule-default" for the dev box "myDevBox" for 5 hours and 15 minutes.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DelayTime
The delayed timespan from the scheduled action time.
Format HH:MM.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevBoxName
The name of a Dev Box.

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Delay1ByDevCenter, DelayByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: Delay1, Delay
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of an action that will take place on a Dev Box.

```yaml
Type: System.String
Parameter Sets: Delay, DelayByDevCenter
Aliases: ActionName

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

### -ProjectName
The DevCenter Project upon which to execute operations.

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

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "me"
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IDevBoxAction

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IDevBoxActionDelayResult

## NOTES

## RELATED LINKS
