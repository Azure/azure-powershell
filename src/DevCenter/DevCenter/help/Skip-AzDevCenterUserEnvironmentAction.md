---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/skip-azdevcenteruserenvironmentaction
schema: 2.0.0
---

# Skip-AzDevCenterUserEnvironmentAction

## SYNOPSIS
Skips an occurrence of an action.

## SYNTAX

### Skip (Default)
```
Skip-AzDevCenterUserEnvironmentAction -Endpoint <String> -Name <String> -EnvironmentName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SkipViaIdentity
```
Skip-AzDevCenterUserEnvironmentAction -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SkipViaIdentityByDevCenter
```
Skip-AzDevCenterUserEnvironmentAction -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SkipByDevCenter
```
Skip-AzDevCenterUserEnvironmentAction -DevCenterName <String> -Name <String> -EnvironmentName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Skips an occurrence of an action.

## EXAMPLES

### EXAMPLE 1
```
Skip-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -Name "myEnvironment-Delete"
```

### EXAMPLE 2
```
Skip-AzDevCenterUserEnvironmentAction -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject -Name "myEnvironment-Delete"
```

### EXAMPLE 3
```
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "myEnvironment-Delete"}
Skip-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $environmentInput
```

### EXAMPLE 4
```
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "myEnvironment-Delete"}
Skip-AzDevCenterUserEnvironmentAction -DevCenterName Contoso -InputObject $environmentInput
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
Parameter Sets: SkipViaIdentityByDevCenter, SkipByDevCenter
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
Parameter Sets: Skip, SkipViaIdentity
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
Parameter Sets: Skip, SkipByDevCenter
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
Parameter Sets: SkipViaIdentity, SkipViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of an action that will take place on an Environment.

```yaml
Type: String
Parameter Sets: Skip, SkipByDevCenter
Aliases: ActionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: String
Parameter Sets: Skip, SkipByDevCenter
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
Parameter Sets: Skip, SkipByDevCenter
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

### System.Boolean
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

[https://learn.microsoft.com/powershell/module/az.devcenter/skip-azdevcenteruserenvironmentaction](https://learn.microsoft.com/powershell/module/az.devcenter/skip-azdevcenteruserenvironmentaction)

