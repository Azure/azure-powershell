---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironment
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironment

## SYNOPSIS
Gets an environment

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserEnvironment -Endpoint <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironment -DevCenter <String> -Name <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserEnvironment -DevCenter <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDevCenterUserEnvironment -Endpoint <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1ByDevCenter
```
Get-AzDevCenterUserEnvironment -DevCenter <String> -ProjectName <String> -UserId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserEnvironment -DevCenter <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an environment

## EXAMPLES

### Example 1: List environments by endpoint and project
```powershell

```

```powershell
 Get-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
 ```
This command lists environments under the project "DevProject".

### Example 2: List environments by dev center and project
```powershell
Get-AzDevCenterUserEnvironment -DevCenter Contoso -ProjectName DevProject
```

This command lists environments under the project "DevProject".

### Example 3: List environments by endpoint, user id, and project
```powershell
Get-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId "me" 
```

This command lists environments under the project "DevProject" assigned to the currently signed-in user.

### Example 4: List environments by dev center, user id, and project
```powershell
Get-AzDevCenterUserEnvironment -DevCenter Contoso -ProjectName DevProject -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```

This command lists environments under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 5: Get an environment by endpoint
```powershell
Get-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId "me"  -Name myEnv
```

This command gets the environment "myEnv" under the project "DevProject" assigned to the currently signed-in user.

### Example 6: Get an environment by dev center
```powershell
Get-AzDevCenterUserEnvironment -DevCenter Contoso -ProjectName DevProject -UserId "786a823c-8037-48ab-89b8-8599901e67d0" -Name myEnv
```

This command gets the environment "myEnv" under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 7: Get an environment by endpoint and InputObject
```powershell
$envInput = @{"UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject"; "EnvironmentName" = "myEnv" }
Get-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput
```

This command gets the environment "myEnv" under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 8: Get an environment by dev center and InputObject
```powershell
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "myEnv" }
Get-AzDevCenterUserEnvironment -DevCenter Contoso -InputObject $envInput
```

This command gets the environment "myEnv" under the project "DevProject" assigned to the currently signed-in user.

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

### -DevCenter
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter, List1ByDevCenter, ListByDevCenter
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
Parameter Sets: Get, GetViaIdentity, List, List1
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
The name of the environment.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
Aliases: EnvironmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter, List, List1, List1ByDevCenter, ListByDevCenter
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
Parameter Sets: Get, GetByDevCenter, List1, List1ByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20230401.IEnvironment

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

