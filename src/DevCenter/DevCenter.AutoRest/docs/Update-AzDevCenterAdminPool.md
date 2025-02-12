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
 [-SubscriptionId <String>] [-DevBoxDefinitionName <String>] [-DisplayName <String>]
 [-LocalAdministrator <LocalAdminStatus>] [-ManagedVirtualNetworkRegion <String[]>]
 [-NetworkConnectionName <String>] [-SingleSignOnStatus <SingleSignOnStatus>]
 [-StopOnDisconnectGracePeriodMinute <Int32>] [-StopOnDisconnectStatus <StopOnDisconnectEnableStatus>]
 [-Tag <Hashtable>] [-VirtualNetworkType <VirtualNetworkType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminPool -InputObject <IDevCenterIdentity> [-DevBoxDefinitionName <String>]
 [-DisplayName <String>] [-LocalAdministrator <LocalAdminStatus>] [-ManagedVirtualNetworkRegion <String[]>]
 [-NetworkConnectionName <String>] [-SingleSignOnStatus <SingleSignOnStatus>]
 [-StopOnDisconnectGracePeriodMinute <Int32>] [-StopOnDisconnectStatus <StopOnDisconnectEnableStatus>]
 [-Tag <Hashtable>] [-VirtualNetworkType <VirtualNetworkType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially updates a machine pool

## EXAMPLES

### Example 1: Update a pool
```powershell
Update-AzDevCenterAdminPool -Name DevPool -ProjectName DevProject -ResourceGroupName testRg -DevBoxDefinitionName WebDevBox -LocalAdministrator "Disabled" -NetworkConnectionName Network1westus2
```

This command updates a pool named "DevPool" in the project "DevProject".

### Example 2: Update a pool using InputObject
```powershell
Get-AzDevCenterAdminPool -ResourceGroupName testRg -Name DevPool -ProjectName DevProject
Update-AzDevCenterAdminPool -InputObject $poolInput -DevBoxDefinitionName WebDevBox -LocalAdministrator "Disabled" -NetworkConnectionName Network1westus2

```

This command updates a pool named "DevPool" in the project "DevProject".

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name of the pool.

```yaml
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedVirtualNetworkRegion
The regions of the managed virtual network (required when managedNetworkType is Managed).

```yaml
Type: System.String[]
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnStatus
Indicates whether Dev Boxes in this pool are created with single sign on enabled.
The also requires that single sign on be enabled on the tenant.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.SingleSignOnStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopOnDisconnectGracePeriodMinute
The specified time in minutes to wait before stopping a Dev Box once disconnect is detected.

```yaml
Type: System.Int32
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkType
Indicates whether the pool uses a Virtual Network managed by Microsoft or a customer provided network.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.VirtualNetworkType
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IPool

## NOTES

## RELATED LINKS

