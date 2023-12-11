---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/invoke-azdevcenteruserdelayenvironmentaction
schema: 2.0.0
---

# Invoke-AzDevCenterUserDelayEnvironmentAction

## SYNOPSIS
Delays the occurrence of an action.

## SYNTAX

### Delay (Default)
```
Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint <String> -Name <String> -EnvironmentName <String>
 -ProjectName <String> [-UserId <String>] -DelayTime <TimeSpan> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DelayByDevCenter
```
Invoke-AzDevCenterUserDelayEnvironmentAction -DevCenterName <String> -Name <String> -EnvironmentName <String>
 -ProjectName <String> [-UserId <String>] -DelayTime <TimeSpan> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delays the occurrence of an action.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -Name "myEnvironment-Delete" -DelayTime "00:30"
```

### EXAMPLE 2
```
Invoke-AzDevCenterUserDelayEnvironmentAction -DevCenterName Contoso -EnvironmentName myEnvironment -UserId "me" -ProjectName DevProject -Name "myEnvironment-Delete" -DelayTime "05:15"
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
Type: TimeSpan
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
Type: String
Parameter Sets: DelayByDevCenter
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
Type: String
Parameter Sets: Delay
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of an action that will take place on an Environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ActionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: String
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IEnvironmentAction
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenter/invoke-azdevcenteruserdelayenvironmentaction](https://learn.microsoft.com/powershell/module/az.devcenter/invoke-azdevcenteruserdelayenvironmentaction)

