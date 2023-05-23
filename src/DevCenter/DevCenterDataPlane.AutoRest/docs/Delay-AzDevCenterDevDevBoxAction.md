---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/delay-azdevcenterdevdevboxaction
schema: 2.0.0
---

# Delay-AzDevCenterDevDevBoxAction

## SYNOPSIS
Delays the occurrence of an action.

## SYNTAX

### Delay1 (Default)
```
Delay-AzDevCenterDevDevBoxAction -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 -DelayTime <TimeSpan> [-UserId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Delay
```
Delay-AzDevCenterDevDevBoxAction -Endpoint <String> -ActionName <String> -DevBoxName <String>
 -ProjectName <String> -DelayTime <TimeSpan> [-UserId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Delay1ByDevCenter
```
Delay-AzDevCenterDevDevBoxAction -DevCenter <String> -DevBoxName <String> -ProjectName <String>
 -DelayTime <TimeSpan> [-UserId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DelayByDevCenter
```
Delay-AzDevCenterDevDevBoxAction -DevCenter <String> -ActionName <String> -DevBoxName <String>
 -ProjectName <String> -DelayTime <TimeSpan> [-UserId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DelayViaIdentity
```
Delay-AzDevCenterDevDevBoxAction -Endpoint <String> -InputObject <IDevCenterIdentity> -DelayTime <TimeSpan>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DelayViaIdentity1
```
Delay-AzDevCenterDevDevBoxAction -Endpoint <String> -InputObject <IDevCenterIdentity> -DelayTime <TimeSpan>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DelayViaIdentity1ByDevCenter
```
Delay-AzDevCenterDevDevBoxAction -DevCenter <String> -InputObject <IDevCenterIdentity> -DelayTime <TimeSpan>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DelayViaIdentityByDevCenter
```
Delay-AzDevCenterDevDevBoxAction -DevCenter <String> -InputObject <IDevCenterIdentity> -DelayTime <TimeSpan>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delays the occurrence of an action.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ActionName
The name of an action that will take place on a Dev Box.

```yaml
Type: System.String
Parameter Sets: Delay, DelayByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: Delay, Delay1, Delay1ByDevCenter, DelayByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevCenter
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Delay1ByDevCenter, DelayByDevCenter, DelayViaIdentity1ByDevCenter, DelayViaIdentityByDevCenter
Aliases:

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
Parameter Sets: Delay, Delay1, DelayViaIdentity, DelayViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: DelayViaIdentity, DelayViaIdentity1, DelayViaIdentity1ByDevCenter, DelayViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Delay, Delay1, Delay1ByDevCenter, DelayByDevCenter
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
Parameter Sets: Delay, Delay1, Delay1ByDevCenter, DelayByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IDevBoxAction

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IDevBoxActionDelayResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDevCenterIdentity>`: Identity Parameter
  - `[ActionName <String>]`: The name of an action that will take place on a Dev Box.
  - `[CatalogName <String>]`: The name of the catalog
  - `[DefinitionName <String>]`: The name of the environment definition
  - `[DevBoxName <String>]`: The name of a Dev Box.
  - `[EnvironmentName <String>]`: The name of the environment.
  - `[Id <String>]`: Resource identity path
  - `[PoolName <String>]`: The name of a pool of Dev Boxes.
  - `[ProjectName <String>]`: The DevCenter Project upon which to execute operations.
  - `[ScheduleName <String>]`: The name of a schedule.
  - `[UserId <String>]`: The AAD object id of the user. If value is 'me', the identity is taken from the authentication context.

## RELATED LINKS

