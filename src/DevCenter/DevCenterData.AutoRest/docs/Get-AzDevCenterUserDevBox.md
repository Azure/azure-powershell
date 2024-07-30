---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevbox
schema: 2.0.0
---

# Get-AzDevCenterUserDevBox

## SYNOPSIS
Gets a Dev Box.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserDevBox -Endpoint <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserDevBox -Endpoint <String> -Name <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBox -DevCenterName <String> -Name <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBox -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBox -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDevCenterUserDevBox -Endpoint <String> -UserId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1ByDevCenter
```
Get-AzDevCenterUserDevBox -DevCenterName <String> -UserId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List2
```
Get-AzDevCenterUserDevBox -Endpoint <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2ByDevCenter
```
Get-AzDevCenterUserDevBox -DevCenterName <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserDevBox -DevCenterName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Dev Box.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/"
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -UserId 786a823c-8037-48ab-89b8-8599901e67d0
```



### -------------------------- EXAMPLE 3 --------------------------
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId "me"
```



### -------------------------- EXAMPLE 4 --------------------------
```powershell
Get-AzDevCenterUserDevBox -DevCenterName Contoso
```



### -------------------------- EXAMPLE 5 --------------------------
```powershell
Get-AzDevCenterUserDevBox -DevCenterName Contoso -UserId "me"
```



### -------------------------- EXAMPLE 6 --------------------------
```powershell
Get-AzDevCenterUserDevBox -DevCenterName Contoso -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0
```



### -------------------------- EXAMPLE 7 --------------------------
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0 -Name myDevBox
```



### -------------------------- EXAMPLE 8 --------------------------
```powershell
Get-AzDevCenterUserDevBox -DevCenterName Contoso -ProjectName DevProject -UserId "me" -Name myDevBox
```



### -------------------------- EXAMPLE 9 --------------------------
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```



### -------------------------- EXAMPLE 10 --------------------------
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserDevBox -DevCenterName Contoso -InputObject $devBoxInput
```



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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter, List1ByDevCenter, List2ByDevCenter, ListByDevCenter
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
Parameter Sets: Get, GetViaIdentity, List, List1, List2
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

### -Name
Display name for the Dev Box.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
Aliases: DevBoxName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter, List2, List2ByDevCenter
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
Parameter Sets: Get, GetByDevCenter, List1, List1ByDevCenter, List2, List2ByDevCenter
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.IDevBox

## NOTES

## RELATED LINKS

