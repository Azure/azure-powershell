---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenterdevenvironment
schema: 2.0.0
---

# New-AzDevCenterDevEnvironment

## SYNOPSIS
Creates or updates an environment.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDevCenterDevEnvironment -Endpoint <String> -Name <String> -ProjectName <String> -CatalogName <String>
 -EnvironmentDefinitionName <String> -EnvironmentType <String> [-UserId <String>] [-Parameter <IAny>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzDevCenterDevEnvironment -Endpoint <String> -Name <String> -ProjectName <String> -Body <IEnvironment>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateByDevCenter
```
New-AzDevCenterDevEnvironment -DevCenter <String> -Name <String> -ProjectName <String> -Body <IEnvironment>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpandedByDevCenter
```
New-AzDevCenterDevEnvironment -DevCenter <String> -Name <String> -ProjectName <String> -CatalogName <String>
 -EnvironmentDefinitionName <String> -EnvironmentType <String> [-UserId <String>] [-Parameter <IAny>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzDevCenterDevEnvironment -Endpoint <String> -InputObject <IDevCenterIdentity> -Body <IEnvironment>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityByDevCenter
```
New-AzDevCenterDevEnvironment -DevCenter <String> -InputObject <IDevCenterIdentity> -Body <IEnvironment>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDevCenterDevEnvironment -Endpoint <String> -InputObject <IDevCenterIdentity> -CatalogName <String>
 -EnvironmentDefinitionName <String> -EnvironmentType <String> [-Parameter <IAny>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpandedByDevCenter
```
New-AzDevCenterDevEnvironment -DevCenter <String> -InputObject <IDevCenterIdentity> -CatalogName <String>
 -EnvironmentDefinitionName <String> -EnvironmentType <String> [-Parameter <IAny>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IEnvironment
Parameter Sets: Create, CreateByDevCenter, CreateViaIdentity, CreateViaIdentityByDevCenter
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
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter, CreateViaIdentityExpanded, CreateViaIdentityExpandedByDevCenter
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
Parameter Sets: CreateByDevCenter, CreateExpandedByDevCenter, CreateViaIdentityByDevCenter, CreateViaIdentityExpandedByDevCenter
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
Parameter Sets: Create, CreateExpanded, CreateViaIdentity, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter, CreateViaIdentityExpanded, CreateViaIdentityExpandedByDevCenter
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
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter, CreateViaIdentityExpanded, CreateViaIdentityExpandedByDevCenter
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityByDevCenter, CreateViaIdentityExpanded, CreateViaIdentityExpandedByDevCenter
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
Parameter Sets: Create, CreateByDevCenter, CreateExpanded, CreateExpandedByDevCenter
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IAny
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter, CreateViaIdentityExpanded, CreateViaIdentityExpandedByDevCenter
Aliases:

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
Parameter Sets: Create, CreateByDevCenter, CreateExpanded, CreateExpandedByDevCenter
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
Parameter Sets: Create, CreateByDevCenter, CreateExpanded, CreateExpandedByDevCenter
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IEnvironment

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

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
  - `[Parameter <IAny>]`: Parameters object for the environment.
  - `[Code <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  - `[Detail <ICloudErrorBody[]>]`: A list of additional details about the error.
    - `Code <String>`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
    - `Message <String>`: A message describing the error, intended to be suitable for display in a user interface.
    - `[Detail <ICloudErrorBody[]>]`: A list of additional details about the error.
    - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.
  - `[Message <String>]`: A message describing the error, intended to be suitable for display in a user interface.
  - `[OperationLocation <String>]`: 
  - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.

`INPUTOBJECT <IDevCenterIdentity>`: Identity Parameter
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

