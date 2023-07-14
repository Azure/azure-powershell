---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/deploy-azdevcenterdevenvironment
schema: 2.0.0
---

# Deploy-AzDevCenterDevEnvironment

## SYNOPSIS
Creates or updates an environment.

## SYNTAX

### ReplaceExpanded (Default)
```
Deploy-AzDevCenterDevEnvironment -Endpoint <String> -Name <String> -ProjectName <String> -CatalogName <String>
 -EnvironmentDefinitionName <String> -EnvironmentType <String> [-UserId <String>] [-Parameter <IAny>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Replace
```
Deploy-AzDevCenterDevEnvironment -Endpoint <String> -Name <String> -ProjectName <String> -Body <IEnvironment>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceByDevCenter
```
Deploy-AzDevCenterDevEnvironment -DevCenter <String> -Name <String> -ProjectName <String> -Body <IEnvironment>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceExpandedByDevCenter
```
Deploy-AzDevCenterDevEnvironment -DevCenter <String> -Name <String> -ProjectName <String>
 -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String> [-UserId <String>]
 [-Parameter <IAny>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentity
```
Deploy-AzDevCenterDevEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity> -Name <String>
 -ProjectName <String> -Body <IEnvironment> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentityByDevCenter
```
Deploy-AzDevCenterDevEnvironment -DevCenter <String> -InputObject <IDevCenterdataIdentity> -Name <String>
 -ProjectName <String> -Body <IEnvironment> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentityExpanded
```
Deploy-AzDevCenterDevEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity> -Name <String>
 -ProjectName <String> -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String>
 -Parameter <IAny> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ReplaceViaIdentityExpandedByDevCenter
```
Deploy-AzDevCenterDevEnvironment -DevCenter <String> -InputObject <IDevCenterdataIdentity> -Name <String>
 -ProjectName <String> -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String>
 -Parameter <IAny> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an environment.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Properties of an environment.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20230401.IEnvironment
Parameter Sets: Replace, ReplaceByDevCenter, ReplaceViaIdentity, ReplaceViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of the catalog.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceExpandedByDevCenter, ReplaceViaIdentityExpanded, ReplaceViaIdentityExpandedByDevCenter
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

### -DevCenter
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: ReplaceByDevCenter, ReplaceExpandedByDevCenter, ReplaceViaIdentityByDevCenter, ReplaceViaIdentityExpandedByDevCenter
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
Parameter Sets: Replace, ReplaceExpanded, ReplaceViaIdentity, ReplaceViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentDefinitionName
Name of the environment definition.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceExpandedByDevCenter, ReplaceViaIdentityExpanded, ReplaceViaIdentityExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentType
Environment type.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceExpandedByDevCenter, ReplaceViaIdentityExpanded, ReplaceViaIdentityExpandedByDevCenter
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
Parameter Sets: ReplaceViaIdentity, ReplaceViaIdentityByDevCenter, ReplaceViaIdentityExpanded, ReplaceViaIdentityExpandedByDevCenter
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
Parameter Sets: (All)
Aliases: EnvironmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters object for the environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny
Parameter Sets: ReplaceExpanded, ReplaceExpandedByDevCenter, ReplaceViaIdentityExpanded, ReplaceViaIdentityExpandedByDevCenter
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
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "me"
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20230401.IEnvironment

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IEnvironment>`: Properties of an environment.
  - `CatalogName <String>`: Name of the catalog.
  - `DefinitionName <String>`: Name of the environment definition.
  - `Type <String>`: Environment type.
  - `[Parameter <IEnvironmentUpdatePropertiesParameters>]`: Parameters object for the environment.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Code <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  - `[Detail <ICloudErrorBody[]>]`: A list of additional details about the error.
    - `Code <String>`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
    - `Message <String>`: A message describing the error, intended to be suitable for display in a user interface.
    - `[Detail <ICloudErrorBody[]>]`: A list of additional details about the error.
    - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.
  - `[Message <String>]`: A message describing the error, intended to be suitable for display in a user interface.
  - `[OperationLocation <String>]`: 
  - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.

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

