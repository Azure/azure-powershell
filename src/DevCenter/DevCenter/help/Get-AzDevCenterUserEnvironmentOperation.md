---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentoperation
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironmentOperation

## SYNOPSIS
Gets an environment action result.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] -OperationId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] -OperationId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an environment action result.

## EXAMPLES

### EXAMPLE 1
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject
```

### EXAMPLE 2
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject
```

### EXAMPLE 3
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
```

### EXAMPLE 4
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
```

### EXAMPLE 5
```
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "OperationId" = "d0954a94-3550-4919-bcbe-1c94ed79e0cd"}
Get-AzDevCenterUserEnvironmentOperation -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $environmentInput
```

### EXAMPLE 6
```
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "OperationId" = "d0954a94-3550-4919-bcbe-1c94ed79e0cd"}
Get-AzDevCenterUserEnvironmentOperation -DevCenterName Contoso -InputObject $environmentInput
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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: String
Parameter Sets: GetViaIdentityByDevCenter, ListByDevCenter, GetByDevCenter
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
Parameter Sets: List, Get, GetViaIdentity
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
Parameter Sets: List, Get, ListByDevCenter, GetByDevCenter
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
Type: IDevCenterdataIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperationId
The id of the operation on an environment.

```yaml
Type: String
Parameter Sets: Get, GetByDevCenter
Aliases:

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
Type: String
Parameter Sets: List, Get, ListByDevCenter, GetByDevCenter
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IEnvironmentOperation
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDevCenterdataIdentity\>: Identity Parameter
  \[ActionName \<String\>\]: The name of an action that will take place on a Dev Box.
  \[CatalogName \<String\>\]: The name of the catalog
  \[CustomizationGroupName \<String\>\]: A customization group name.
  \[CustomizationTaskId \<String\>\]: A customization task ID.
  \[DefinitionName \<String\>\]: The name of the environment definition
  \[DevBoxName \<String\>\]: The name of a Dev Box.
  \[EnvironmentName \<String\>\]: The name of the environment.
  \[Id \<String\>\]: Resource identity path
  \[OperationId \<String\>\]: The id of the operation on a Dev Box.
  \[PoolName \<String\>\]: The name of a pool of Dev Boxes.
  \[ProjectName \<String\>\]: The DevCenter Project upon which to execute operations.
  \[ScheduleName \<String\>\]: The name of a schedule.
  \[TaskName \<String\>\]: A customization task name.
  \[UserId \<String\>\]: The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentoperation](https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentoperation)

