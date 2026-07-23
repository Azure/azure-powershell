---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmenttypeability
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironmentTypeAbility

## SYNOPSIS
Gets the signed-in user's permitted abilities in an environment type.

## SYNTAX

### Get (Default)
```
Get-AzDevCenterUserEnvironmentTypeAbility -Endpoint <String> -EnvironmentTypeName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserEnvironmentTypeAbility -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironmentTypeAbility -DevCenterName <String> -EnvironmentTypeName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserEnvironmentTypeAbility -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the signed-in user's permitted abilities in an environment type.

## EXAMPLES

### Example 1: Get the signed-in user's abilities for an environment type by endpoint
```powershell
Get-AzDevCenterUserEnvironmentTypeAbility `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -EnvironmentTypeName "DevTest"
```

This command gets the permitted abilities for the signed-in user in the "DevTest" environment type for the project "DevProject" using the endpoint.

### Example 2: Get a specific user's abilities for an environment type by dev center name
```powershell
Get-AzDevCenterUserEnvironmentTypeAbility `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -EnvironmentTypeName "DevTest" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```

This command gets the permitted abilities for user "786a823c-8037-48ab-89b8-8599901e67d0" in the "DevTest" environment type for the project "DevProject" using the dev center name.

### Example 3: Get the signed-in user's abilities for an environment type using InputObject and endpoint
```powershell
$envTypeInput = @{
    ProjectName = "DevProject"
    EnvironmentTypeName = "DevTest"
}
Get-AzDevCenterUserEnvironmentTypeAbility `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $envTypeInput
```

This command gets the permitted abilities for the signed-in user in the "DevTest" environment type using the endpoint and an identity object.

### Example 4: Get the signed-in user's abilities for an environment type using InputObject and dev center name
```powershell
$envTypeInput = @{
    ProjectName = "DevProject"
    EnvironmentTypeName = "DevTest"
}
Get-AzDevCenterUserEnvironmentTypeAbility `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $envTypeInput
```

This command gets the permitted abilities for the signed-in user in the "DevTest" environment type using the dev center name and an identity object.

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
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter
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
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentTypeName
The name of the environment type

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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironmentTypeAbilities

## NOTES

## RELATED LINKS
