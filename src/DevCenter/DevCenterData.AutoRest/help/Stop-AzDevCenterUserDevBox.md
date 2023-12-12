---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/stop-azdevcenteruserdevbox
schema: 2.0.0
---

# Stop-AzDevCenterUserDevBox

## SYNOPSIS
Stops a Dev Box

## SYNTAX

### Stop (Default)
```
Stop-AzDevCenterUserDevBox -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 [-Hibernate] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopByDevCenter
```
Stop-AzDevCenterUserDevBox -DevCenterName <String> -Name <String> -ProjectName <String> [-UserId <String>]
 [-Hibernate] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzDevCenterUserDevBox -Endpoint <String> -InputObject <IDevCenterdataIdentity> [-Hibernate]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityByDevCenter
```
Stop-AzDevCenterUserDevBox -DevCenterName <String> -InputObject <IDevCenterdataIdentity> [-Hibernate]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Stops a Dev Box

## EXAMPLES

### Example 1: Stop a dev box by endpoint
```powershell
Stop-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0 -Name myDevBox
```

This command stops the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 2: Stop a dev box by dev center
```powershell
Stop-AzDevCenterUserDevBox -DevCenterName Contoso -ProjectName DevProject -UserId "me" -Name myDevBox
```

This command stops the dev box "myDevBox" assigned to the currently signed-in user.

### Example 3: Stop a dev box by endpoint and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
Stop-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```

This command stops the dev box "myDevBox" assigned to the currently signed-in user.

### Example 4: Stop a dev box by dev center and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject" }
Stop-AzDevCenterUserDevBox -DevCenterName Contoso -InputObject $devBoxInput 
```

This command stops the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0".

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: StopByDevCenter, StopViaIdentityByDevCenter
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
Parameter Sets: Stop, StopViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hibernate
Optional parameter to hibernate the dev box.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: StopViaIdentity, StopViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of a Dev Box.

```yaml
Type: System.String
Parameter Sets: Stop, StopByDevCenter
Aliases: DevBoxName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Stop, StopByDevCenter
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
Parameter Sets: Stop, StopByDevCenter
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

### System.Boolean

## NOTES

## RELATED LINKS

