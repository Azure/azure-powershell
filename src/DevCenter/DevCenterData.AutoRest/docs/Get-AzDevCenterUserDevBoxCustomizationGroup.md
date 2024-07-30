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

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



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

