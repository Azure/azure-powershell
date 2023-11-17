---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboxremoteconnection
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxRemoteConnection

## SYNOPSIS
Gets RDP Connection info

## SYNTAX

### Get (Default)
```
Get-AzDevCenterUserDevBoxRemoteConnection -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxRemoteConnection -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxRemoteConnection -DevCenter <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxRemoteConnection -DevCenter <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets RDP Connection info

## EXAMPLES

### Example 1: Get the remote connection on the dev box by endpoint
```powershell
Get-AzDevCenterUserDevBoxRemoteConnection -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -ProjectName DevProject
```

This commands gets the remote connection for the dev box "myDevBox".

### Example 2: Get the remote connection on the dev box by dev center
```powershell
Get-AzDevCenterUserDevBoxRemoteConnection -DevCenter Contoso -DevBoxName myDevBox -ProjectName DevProject
```

This commands gets the remote connection for the dev box "myDevBox".

### Example 3: Get the remote connection on the dev box by endpoint and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserDevBoxRemoteConnection -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```

This commands gets the remote connection for the dev box "myDevBox".

### Example 4: Get the remote connection on the dev box by dev center and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserDevBoxRemoteConnection -DevCenter Contoso -InputObject $devBoxInput
```

This commands gets the remote connection for the dev box "myDevBox".

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

### -DevBoxName
The name of a Dev Box.

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

### -DevCenter
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityByDevCenter, GetByDevCenter
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
Parameter Sets: Get, GetViaIdentity
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
The DevCenter Project upon which to execute operations.

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

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20230401.IRemoteConnection

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDevCenterdataIdentity>`: Identity Parameter
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
