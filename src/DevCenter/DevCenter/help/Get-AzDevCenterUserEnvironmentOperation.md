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
 [-UserId <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] -OperationId <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserEnvironmentOperation -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironmentOperation -DevCenterName <String> -EnvironmentName <String> -ProjectName <String>
 [-UserId <String>] -OperationId <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an environment action result.

## EXAMPLES

### Example 1: List operations on the environment by endpoint
```powershell
Get-AzDevCenterUserEnvironmentOperation -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject
```

This command lists the operations on the environment "myEnvironment".

### Example 2: List operations on the environment by dev center
```powershell
Get-AzDevCenterUserEnvironmentOperation -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject
```

This command lists the operations on the environment "myEnvironment".

### Example 3: Get an operation on the environment by endpoint
```powershell
Get-AzDevCenterUserEnvironmentOperation -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
```

This command gets the operation "d0954a94-3550-4919-bcbe-1c94ed79e0cd" for the environment "myEnvironment".

### Example 4: Get an operation on the environment by dev center
```powershell
Get-AzDevCenterUserEnvironmentOperation -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
```

This command gets the operation "d0954a94-3550-4919-bcbe-1c94ed79e0cd" for the environment "myEnvironment".

### Example 5: Get an operation on the environment by endpoint and InputObject
```powershell
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "OperationId" = "d0954a94-3550-4919-bcbe-1c94ed79e0cd"}
Get-AzDevCenterUserEnvironmentOperation -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $environmentInput
```

This command gets the operation "d0954a94-3550-4919-bcbe-1c94ed79e0cd" for the environment "myEnvironment".

### Example 6: Get an operation on the environment by dev center and InputObject
```powershell
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "OperationId" = "d0954a94-3550-4919-bcbe-1c94ed79e0cd"}
Get-AzDevCenterUserEnvironmentOperation -DevCenterName Contoso -InputObject $environmentInput
```

This command gets the operation "d0954a94-3550-4919-bcbe-1c94ed79e0cd" for the environment "myEnvironment".

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
Type: System.String
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
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
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
Type: System.String
Parameter Sets: Get, GetByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IEnvironmentOperation

## NOTES

## RELATED LINKS
