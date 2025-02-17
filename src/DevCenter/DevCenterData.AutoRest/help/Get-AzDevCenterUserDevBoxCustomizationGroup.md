---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboxcustomizationgroup
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxCustomizationGroup

## SYNOPSIS
Gets a customization group.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-Include <ListCustomizationGroupsIncludeProperty>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -CustomizationGroupName <String>
 -DevBoxName <String> -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName <String> -CustomizationGroupName <String>
 -DevBoxName <String> -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-Include <ListCustomizationGroupsIncludeProperty>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a customization group.

## EXAMPLES

### Example 1: List customization groups by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -DevBoxName MyDevBox
```

This command lists customization groups for the dev box "MyDevBox" in the project "DevProject".

### Example 2: List customization groups by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -DevBoxName MyDevBox -Include tasks
```

This command lists customization groups for the dev box "MyDevBox" in the project "DevProject".

### Example 3: Get a customization group by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CustomizationGroupName Provisioning -DevBoxName MyDevBox
```

This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

### Example 4: Get a customization group by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -CustomizationGroupName Provisioning -DevBoxName MyDevBox
```

This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

### Example 5: Get a customization group by endpoint and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" ="DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "me" }
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationGroupInput
```

This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

### Example 6: Get a customization group by dev center and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" = "DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0" }
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -InputObject $customizationGroupInput 
```

This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

## PARAMETERS

### -CustomizationGroupName
Name of the customization group.

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
Parameter Sets: Get, GetByDevCenter, List, ListByDevCenter
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
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter, ListByDevCenter
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
Parameter Sets: Get, GetViaIdentity, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Optional query parameter to specify what properties should be included in the response.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Support.ListCustomizationGroupsIncludeProperty
Parameter Sets: List, ListByDevCenter
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
Parameter Sets: Get, GetByDevCenter, List, ListByDevCenter
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
Parameter Sets: Get, GetByDevCenter, List, ListByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.ICustomizationGroup

## NOTES

## RELATED LINKS

