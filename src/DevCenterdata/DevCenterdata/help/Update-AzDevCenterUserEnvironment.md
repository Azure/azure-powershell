---
external help file: Az.DevCenterdata-help.xml
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/update-azdevcenteruserenvironment
schema: 2.0.0
---

# Update-AzDevCenterUserEnvironment

## SYNOPSIS
Partially updates an environment.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 [-ExpirationDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Patch
```
Update-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 -Body <IEnvironmentPatchProperties> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzDevCenterUserEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-ExpirationDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzDevCenterUserEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 -Body <IEnvironmentPatchProperties> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Partially updates an environment.

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

### -Body
Properties of an environment.
These properties can be updated via PATCH after the resource has been created.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironmentPatchProperties
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationDate
The time the expiration date will be triggered (UTC), after which theenvironment and associated resources will be deleted.

```yaml
Type: System.DateTime
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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
Parameter Sets: PatchViaIdentityExpanded, PatchViaIdentity
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
Parameter Sets: PatchExpanded, Patch
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
Parameter Sets: PatchExpanded, Patch
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
Parameter Sets: PatchExpanded, Patch
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
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironmentPatchProperties
### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironment
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BODY \<IEnvironmentPatchProperties\>: Properties of an environment.
These properties can be updated via PATCH after the resource has been created.
  \[ExpirationDate \<DateTime?\>\]: The time the expiration date will be triggered (UTC), after which the         environment and associated resources will be deleted.

INPUTOBJECT \<IDevCenterdataIdentity\>: Identity Parameter
  \[ActionName \<String\>\]: The name of the action.
  \[AddOnName \<String\>\]: Name of the dev box addon.
  \[CatalogName \<String\>\]: Name of the catalog.
  \[CustomizationGroupName \<String\>\]: Name of the customization group.
  \[CustomizationTaskId \<String\>\]: A customization task ID.
  \[DefinitionName \<String\>\]: Name of the environment definition.
  \[DevBoxName \<String\>\]: Display name for the Dev Box.
  \[EnvironmentName \<String\>\]: Environment name.
  \[EnvironmentTypeName \<String\>\]: Name of the environment type.
  \[Id \<String\>\]: Resource identity path
  \[ImageBuildLogId \<String\>\]: An imaging build log id.
  \[OperationId \<String\>\]: Unique identifier for the Dev Box operation.
  \[PoolName \<String\>\]: Pool name.
  \[ProjectName \<String\>\]: Name of the project.
  \[ScheduleName \<String\>\]: Display name for the Schedule.
  \[SnapshotId \<String\>\]: The id of the snapshot.
Should be treated as opaque string.
  \[TaskName \<String\>\]: Full name of the task: {catalogName}/{taskName}.
  \[UserId \<String\>\]: The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenterdata/update-azdevcenteruserenvironment](https://learn.microsoft.com/powershell/module/az.devcenterdata/update-azdevcenteruserenvironment)
