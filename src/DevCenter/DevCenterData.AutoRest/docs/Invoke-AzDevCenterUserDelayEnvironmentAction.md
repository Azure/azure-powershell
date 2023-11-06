---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/invoke-azdevcenteruserdelayenvironmentaction
schema: 2.0.0
---

# Invoke-AzDevCenterUserDelayEnvironmentAction

## SYNOPSIS
Delays the occurrence of an action.

## SYNTAX

### Delay (Default)
```
Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint <String> -ActionName <String> -EnvironmentName <String>
 -ProjectName <String> -DelayTime <TimeSpan> [-UserId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DelayByDevCenter
```
Invoke-AzDevCenterUserDelayEnvironmentAction -DevCenter <String> -ActionName <String>
 -EnvironmentName <String> -ProjectName <String> -DelayTime <TimeSpan> [-UserId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DelayViaIdentity
```
Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 -DelayTime <TimeSpan> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DelayViaIdentityByDevCenter
```
Invoke-AzDevCenterUserDelayEnvironmentAction -DevCenter <String> -InputObject <IDevCenterdataIdentity>
 -DelayTime <TimeSpan> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delays the occurrence of an action.

## EXAMPLES

### Example 1: Delay an action on the environment by endpoint
```powershell
Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -ActionName "myEnvironment-Delete" -DelayTime "00:30"
```

This command delays the action "schedule-default" for the environment "myEnvironment" for 30 minutes.

### Example 2: Delay an action on the environment by dev center
```powershell
Invoke-AzDevCenterUserDelayEnvironmentAction -DevCenter Contoso -EnvironmentName myEnvironment -UserId "me" -ProjectName DevProject -ActionName "myEnvironment-Delete" -DelayTime "05:15"
```

This command delays the action "myEnvironment-Delete" for the environment "myEnvironment" for 5 hours and 15 minutes.

## PARAMETERS

### -ActionName
The name of an action that will take place on an Environment.

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

### -DevCenter
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: DelayByDevCenter, DelayViaIdentityByDevCenter
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
Parameter Sets: Delay, DelayViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
The name of the environment.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: DelayViaIdentity, DelayViaIdentityByDevCenter
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
Parameter Sets: Delay, DelayByDevCenter
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
Parameter Sets: Delay, DelayByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IEnvironmentAction

## NOTES

## RELATED LINKS

