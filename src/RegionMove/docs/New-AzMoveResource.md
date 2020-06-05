---
external help file:
Module Name: Az.RegionMove
online version: https://docs.microsoft.com/en-us/powershell/module/az.regionmove/new-azmoveresource
schema: 2.0.0
---

# New-AzMoveResource

## SYNOPSIS


## SYNTAX

### CreateExpanded (Default)
```
New-AzMoveResource -MoveCollectionName <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-DependsOnOverride <IMoveResourceDependencyOverride[]>]
 [-ExistingTargetId <String>] [-MoveStatusCode <String>] [-MoveStatusDetail <ICloudErrorBody[]>]
 [-MoveStatusJobName <String>] [-MoveStatusJobProgress <String>] [-MoveStatusMessage <String>]
 [-MoveStatusMoveState <String>] [-MoveStatusTarget <String>] [-MoveStatusTargetId <String>]
 [-ProvisioningState <String>] [-ResourceSettingResourceType <String>]
 [-ResourceSettingTargetResourceName <String>] [-SourceId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzMoveResource -MoveCollectionName <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> -Body <IMoveResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzMoveResource -InputObject <IRegionMoveIdentity> -Body <IMoveResource> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzMoveResource -InputObject <IRegionMoveIdentity> [-DependsOnOverride <IMoveResourceDependencyOverride[]>]
 [-ExistingTargetId <String>] [-MoveStatusCode <String>] [-MoveStatusDetail <ICloudErrorBody[]>]
 [-MoveStatusJobName <String>] [-MoveStatusJobProgress <String>] [-MoveStatusMessage <String>]
 [-MoveStatusMoveState <String>] [-MoveStatusTarget <String>] [-MoveStatusTargetId <String>]
 [-ProvisioningState <String>] [-ResourceSettingResourceType <String>]
 [-ResourceSettingTargetResourceName <String>] [-SourceId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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
Defines the move resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DependsOnOverride
Gets or sets the move resource dependencies overrides.
To construct, see NOTES section for DEPENDSONOVERRIDE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResourceDependencyOverride[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExistingTargetId
Gets or sets the existing target ARM Id of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MoveCollectionName
.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusCode
An identifier for the error.
Codes are invariant and are intended to be consumed programmatically.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusDetail
A list of additional details about the error.
To construct, see NOTES section for MOVESTATUSDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.ICloudErrorBody[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusJobName
Defines the job names.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusJobProgress
Gets or sets the monitoring job percentage.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusMessage
A message describing the error, intended to be suitable for display in a user interface.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusMoveState
Defines the MoveResource states.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusTarget
The target of the particular error.
For example, the name of the property in error.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveStatusTargetId
Gets the Target ARM Id of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: MoveResourceName

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

### -ProvisioningState
Defines the provisioning states.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceSettingResourceType
The resource type.
For example, the value can be Microsoft.Compute/virtualMachines.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceSettingTargetResourceName
Gets or sets the target Resource name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceId
Gets or sets the Source ARM Id of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IMoveResource>: Defines the move resource.
  - `ResourceSettingResourceType <String>`: The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
  - `[DependsOnOverride <IMoveResourceDependencyOverride[]>]`: Gets or sets the move resource dependencies overrides.
    - `[Id <String>]`: Gets or sets the ARM ID of the dependent resource.
    - `[TargetId <String>]`: Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of         the dependent resource.
  - `[ExistingTargetId <String>]`: Gets or sets the existing target ARM Id of the resource.
  - `[MoveStatusCode <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  - `[MoveStatusDetail <ICloudErrorBody[]>]`: A list of additional details about the error.
    - `[Code <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
    - `[Detail <ICloudErrorBody[]>]`: A list of additional details about the error.
    - `[Message <String>]`: A message describing the error, intended to be suitable for display in a user interface.
    - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.
  - `[MoveStatusJobName <String>]`: Defines the job names.
  - `[MoveStatusJobProgress <String>]`: Gets or sets the monitoring job percentage.
  - `[MoveStatusMessage <String>]`: A message describing the error, intended to be suitable for display in a user interface.
  - `[MoveStatusMoveState <String>]`: Defines the MoveResource states.
  - `[MoveStatusTarget <String>]`: The target of the particular error. For example, the name of the property in error.
  - `[MoveStatusTargetId <String>]`: Gets the Target ARM Id of the resource.
  - `[ProvisioningState <String>]`: Defines the provisioning states.
  - `[ResourceSettingTargetResourceName <String>]`: Gets or sets the target Resource name.
  - `[SourceId <String>]`: Gets or sets the Source ARM Id of the resource.

DEPENDSONOVERRIDE <IMoveResourceDependencyOverride[]>: Gets or sets the move resource dependencies overrides.
  - `[Id <String>]`: Gets or sets the ARM ID of the dependent resource.
  - `[TargetId <String>]`: Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of         the dependent resource.

INPUTOBJECT <IRegionMoveIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MoveCollectionName <String>]`: 
  - `[MoveResourceName <String>]`: 
  - `[ResourceGroupName <String>]`: 
  - `[SubscriptionId <String>]`: The Subscription ID.

MOVESTATUSDETAIL <ICloudErrorBody[]>: A list of additional details about the error.
  - `[Code <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  - `[Detail <ICloudErrorBody[]>]`: A list of additional details about the error.
  - `[Message <String>]`: A message describing the error, intended to be suitable for display in a user interface.
  - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.

## RELATED LINKS

