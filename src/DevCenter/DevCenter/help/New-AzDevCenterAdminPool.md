---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteradminpool
schema: 2.0.0
---

# New-AzDevCenterAdminPool

## SYNOPSIS
Creates or updates a machine pool

## SYNTAX

### CreateExpanded (Default)
```
New-AzDevCenterAdminPool -Name <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> -DevBoxDefinitionName <String>
 -LocalAdministrator <LocalAdminStatus> -NetworkConnectionName <String> [-DisplayName <String>]
 [-ManagedVirtualNetworkRegion <String[]>] [-Tag <Hashtable>] [-SingleSignOnStatus <SingleSignOnStatus>]
 [-VirtualNetworkType <VirtualNetworkType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDevCenterAdminPool -InputObject <IDevCenterIdentity> -Location <String> -DevBoxDefinitionName <String>
 -LocalAdministrator <LocalAdminStatus> -NetworkConnectionName <String> [-DisplayName <String>]
 [-ManagedVirtualNetworkRegion <String[]>] [-Tag <Hashtable>] [-SingleSignOnStatus <SingleSignOnStatus>]
 [-VirtualNetworkType <VirtualNetworkType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a machine pool

## EXAMPLES

### Example 1: Create a pool
```powershell
New-AzDevCenterAdminPool -Name DevPool -ProjectName DevProject -ResourceGroupName testRg -Location westus2 -DevBoxDefinitionName WebDevBox -LocalAdministrator "Enabled" -NetworkConnectionName Network1westus2
```

This command creates a pool named "DevPool" in the project "DevProject".

### Example 2: Create a pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminPool -InputObject $pool -Location westus2 -DevBoxDefinitionName WebDevBox -LocalAdministrator "Enabled" -NetworkConnectionName Network1westus2
```

This command creates a pool named "DevPool" in the project "DevProject".

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

Required: True
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
Parameter Sets: CreateViaIdentityExpanded
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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
Parameter Sets: CreateExpanded
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
The name of the project.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20231001Preview.IPool

## NOTES

## RELATED LINKS
