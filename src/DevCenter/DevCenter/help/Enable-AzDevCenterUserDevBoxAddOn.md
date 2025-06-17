---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/enable-azdevcenteruserdevboxaddon
schema: 2.0.0
---

# Enable-AzDevCenterUserDevBoxAddOn

## SYNOPSIS
Enable a Dev Box addon.

## SYNTAX

### Enable (Default)
```
Enable-AzDevCenterUserDevBoxAddOn -Endpoint <String> -AddOnName <String> -DevBoxName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableViaIdentity
```
Enable-AzDevCenterUserDevBoxAddOn -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### EnableByDevCenter
```
Enable-AzDevCenterUserDevBoxAddOn -DevCenterName <String> -AddOnName <String> -DevBoxName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableViaIdentityByDevCenter
```
Enable-AzDevCenterUserDevBoxAddOn -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Enable a Dev Box addon.

## EXAMPLES

### Example 1: Enable a Dev Box add-on by endpoint
```powershell
Enable-AzDevCenterUserDevBoxAddOn `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -DevBoxName "myDevBox" `
  -AddOnName "devboxtunnel-sys-default"
```

This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the specified user using the endpoint.

### Example 2: Enable a Dev Box add-on by dev center
```powershell
Enable-AzDevCenterUserDevBoxAddOn `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -DevBoxName "myDevBox" `
  -AddOnName "devboxtunnel-sys-default"
```

This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the specified user using the dev center name.

### Example 3: Enable a Dev Box add-on by endpoint and InputObject
```powershell
$addOnInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
Enable-AzDevCenterUserDevBoxAddOn `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $addOnInput
```

This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the endpoint and an identity object.

### Example 4: Enable a Dev Box add-on by dev center and InputObject
```powershell
$addOnInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
Enable-AzDevCenterUserDevBoxAddOn `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $addOnInput
```

This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the dev center name and an identity object.

## PARAMETERS

### -AddOnName
Name of the dev box addon.

```yaml
Type: System.String
Parameter Sets: Enable, EnableByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DevBoxName
Display name for the Dev Box.

```yaml
Type: System.String
Parameter Sets: Enable, EnableByDevCenter
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
Parameter Sets: EnableByDevCenter, EnableViaIdentityByDevCenter
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
Parameter Sets: Enable, EnableViaIdentity
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
Parameter Sets: EnableViaIdentity, EnableViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Name of the project.

```yaml
Type: System.String
Parameter Sets: Enable, EnableByDevCenter
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
Parameter Sets: Enable, EnableByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IOperationStatus

## NOTES

## RELATED LINKS
