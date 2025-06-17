---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboxaddon
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxAddon

## SYNOPSIS
Gets a Dev Box addon by Dev Box addon id.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserDevBoxAddon -Endpoint <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserDevBoxAddon -Endpoint <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
 -AddOnName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxAddon -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxAddon -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserDevBoxAddon -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxAddon -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -AddOnName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Dev Box addon by Dev Box addon id.

## EXAMPLES

### Example 1: Get all add-ons for a Dev Box by endpoint and user ID
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```

This command gets all add-ons for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the endpoint.

### Example 2: Get all add-ons for a Dev Box by endpoint and current user
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me"
```

This command gets all add-ons for the dev box "myDevBox" assigned to the current signed-in user using the endpoint.

### Example 3: Get a specific add-on for a Dev Box by dev center and user ID
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -AddOnName "devboxtunnel-sys-default"
```

This command gets the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the dev center name.

### Example 4: Get a specific add-on for a Dev Box by dev center and current user
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -AddOnName "devboxtunnel-sys-default"
```

This command gets the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 5: Get a Dev Box add-on using InputObject
```powershell
$addonInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
Get-AzDevCenterUserDevBoxAddon `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $addonInput
```

This command gets the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the endpoint and an identity object.

## PARAMETERS

### -AddOnName
Name of the dev box addon.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
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

### -DevBoxName
Display name for the Dev Box.

```yaml
Type: System.String
Parameter Sets: List, Get, ListByDevCenter, GetByDevCenter
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
Parameter Sets: GetViaIdentityByDevCenter, ListByDevCenter, GetByDevCenter
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
Parameter Sets: List, Get, GetViaIdentity
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
Parameter Sets: GetViaIdentity, GetViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: List, Get, ListByDevCenter, GetByDevCenter
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
Parameter Sets: List, Get, ListByDevCenter, GetByDevCenter
Aliases:

Required: False
Position: Named
Default value: "me"
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IDevBoxAddOn

## NOTES

## RELATED LINKS
