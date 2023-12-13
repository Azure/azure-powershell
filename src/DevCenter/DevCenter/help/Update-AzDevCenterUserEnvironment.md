---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteruserenvironment
schema: 2.0.0
---

# Update-AzDevCenterUserEnvironment

## SYNOPSIS
Partially updates an environment

## SYNTAX

### PatchExpanded (Default)
```
Update-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 [-ExpirationDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzDevCenterUserEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-ExpirationDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PatchExpandedByDevCenter
```
Update-AzDevCenterUserEnvironment -DevCenterName <String> -Name <String> -ProjectName <String>
 [-UserId <String>] [-ExpirationDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PatchViaIdentityExpandedByDevCenter
```
Update-AzDevCenterUserEnvironment -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-ExpirationDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Partially updates an environment

## EXAMPLES

### EXAMPLE 1
```
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)
```

Update-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -Name "envtest" -ProjectName DevProject -ExpirationDate $dateIn8Months

### EXAMPLE 2
```
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)
```

Update-AzDevCenterUserEnvironment -DevCenterName Contoso -Name "envtest" -ProjectName DevProject -ExpirationDate $dateIn8Months

### EXAMPLE 3
```
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)
```

Update-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput -ExpirationDate $dateIn8Months

### EXAMPLE 4
```
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)
```

$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }

Update-AzDevCenterUserEnvironment -DevCenterName Contoso -InputObject $envInput -ExpirationDate $dateIn8Months

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
Parameter Sets: PatchExpandedByDevCenter, PatchViaIdentityExpandedByDevCenter
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
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationDate
The time the expiration date will be triggered (UTC), after which the environment and associated resources will be deleted.

```yaml
Type: DateTime
Parameter Sets: (All)
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
Type: IDevCenterdataIdentity
Parameter Sets: PatchViaIdentityExpanded, PatchViaIdentityExpandedByDevCenter
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
Type: String
Parameter Sets: PatchExpanded, PatchExpandedByDevCenter
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
Type: String
Parameter Sets: PatchExpanded, PatchExpandedByDevCenter
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
Parameter Sets: PatchExpanded, PatchExpandedByDevCenter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IEnvironment
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

[https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteruserenvironment](https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteruserenvironment)

