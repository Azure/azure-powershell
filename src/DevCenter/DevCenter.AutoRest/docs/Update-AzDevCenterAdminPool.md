---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradminpool
schema: 2.0.0
---

# Update-AzDevCenterAdminPool

## SYNOPSIS
Partially updates a machine pool

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDevCenterAdminPool -Name <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DevBoxDefinitionName <String>] [-LocalAdministrator <LocalAdminStatus>]
 [-Location <String>] [-NetworkConnectionName <String>] [-StopOnDisconnectGracePeriodMinute <Int32>]
 [-StopOnDisconnectStatus <StopOnDisconnectEnableStatus>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzDevCenterAdminPool -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -Body <IPoolUpdate> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzDevCenterAdminPool -InputObject <IDevCenterIdentity> -Body <IPoolUpdate> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminPool -InputObject <IDevCenterIdentity> [-DevBoxDefinitionName <String>]
 [-LocalAdministrator <LocalAdminStatus>] [-Location <String>] [-NetworkConnectionName <String>]
 [-StopOnDisconnectGracePeriodMinute <Int32>] [-StopOnDisconnectStatus <StopOnDisconnectEnableStatus>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially updates a machine pool

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
The pool properties for partial update.
Properties not provided in the update request will not be changed.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IPoolUpdate
Parameter Sets: Update, UpdateViaIdentity
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

### -DevBoxDefinitionName
Name of a Dev Box definition in parent Project of this Pool

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalAdministrator
Indicates whether owners of Dev Boxes in this pool are added as local administrators on the Dev Box.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.LocalAdminStatus
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the pool.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: PoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConnectionName
Name of a Network Connection in parent Project of this Pool

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### -ProjectName
The name of the project.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopOnDisconnectGracePeriodMinute
The specified time in minutes to wait before stopping a Dev Box once disconnect is detected.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopOnDisconnectStatus
Whether the feature to stop the Dev Box on disconnect once the grace period has lapsed is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.StopOnDisconnectEnableStatus
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IPoolUpdate

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IPool

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IPoolUpdate>`: The pool properties for partial update. Properties not provided in the update request will not be changed.
  - `[Location <String>]`: The geo-location where the resource lives
  - `[Tag <ITags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[DevBoxDefinitionName <String>]`: Name of a Dev Box definition in parent Project of this Pool
  - `[LicenseType <LicenseType?>]`: Specifies the license type indicating the caller has already acquired licenses for the Dev Boxes that will be created.
  - `[LocalAdministrator <LocalAdminStatus?>]`: Indicates whether owners of Dev Boxes in this pool are added as local administrators on the Dev Box.
  - `[NetworkConnectionName <String>]`: Name of a Network Connection in parent Project of this Pool
  - `[StopOnDisconnectGracePeriodMinute <Int32?>]`: The specified time in minutes to wait before stopping a Dev Box once disconnect is detected.
  - `[StopOnDisconnectStatus <StopOnDisconnectEnableStatus?>]`: Whether the feature to stop the Dev Box on disconnect once the grace period has lapsed is enabled.

`INPUTOBJECT <IDevCenterIdentity>`: Identity Parameter
  - `[AttachedNetworkConnectionName <String>]`: The name of the attached NetworkConnection.
  - `[CatalogName <String>]`: The name of the Catalog.
  - `[DevBoxDefinitionName <String>]`: The name of the Dev Box definition.
  - `[DevCenterName <String>]`: The name of the devcenter.
  - `[EnvironmentTypeName <String>]`: The name of the environment type.
  - `[GalleryName <String>]`: The name of the gallery.
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The name of the image.
  - `[Location <String>]`: The Azure region
  - `[NetworkConnectionName <String>]`: Name of the Network Connection that can be applied to a Pool.
  - `[OperationId <String>]`: The ID of an ongoing async operation
  - `[PoolName <String>]`: Name of the pool.
  - `[ProjectName <String>]`: The name of the project.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScheduleName <String>]`: The name of the schedule that uniquely identifies it.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VersionName <String>]`: The version of the image.

## RELATED LINKS

