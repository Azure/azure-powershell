---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdscalingplan
schema: 2.0.0
---

# Get-AzWvdScalingPlan

## SYNOPSIS
Get a scaling plan.

## SYNTAX

### List1 (Default)
```
Get-AzWvdScalingPlan [-SubscriptionId <String[]>] [-InitialSkip <Int32>] [-IsDescending] [-PageSize <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWvdScalingPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWvdScalingPlan -InputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzWvdScalingPlan -ResourceGroupName <String> [-SubscriptionId <String[]>] [-InitialSkip <Int32>]
 [-IsDescending] [-PageSize <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzWvdScalingPlan -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-InitialSkip <Int32>] [-IsDescending] [-PageSize <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a scaling plan.

## EXAMPLES

### Example 1: Get a Windows Virtual Desktop Scaling Plan by name
```powershell
Get-AzWvdScalingPlan -ResourceGroupName ResourceGroupName -Name scalingPlan1
```

```output
Location      Name             Type
--------      ----             ----
westcentralus scalingPlan1     Microsoft.DesktopVirtualization/scalingplans
```

This command gets a Windows Virtual Desktop Scaling Plan in a Resource Group.

### Example 2: List Windows Virtual Desktop Scaling Plans
```powershell
Get-AzWvdScalingPlan -ResourceGroupName ResourceGroupName
```

```output
Location      Name             Type
--------      ----             ----
westcentralus scalingPlan1     Microsoft.DesktopVirtualization/scalingplans
westcentralus scalingPlan2     Microsoft.DesktopVirtualization/scalingplans
```

This command lists all the Windows Virtual Desktop Scaling Plans in a Resource Group.

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

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitialSkip
Initial number of items to skip.

```yaml
Type: System.Int32
Parameter Sets: List, List1, List2
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsDescending
Indicates whether the collection is descending.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List, List1, List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the scaling plan.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ScalingPlanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageSize
Number of items per page.

```yaml
Type: System.Int32
Parameter Sets: List, List1, List2
Aliases:

Required: False
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
Parameter Sets: Get, List, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1, List2
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IScalingPlan

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDesktopVirtualizationIdentity>`: Identity Parameter
  - `[ApplicationGroupName <String>]`: The name of the application group
  - `[ApplicationName <String>]`: The name of the application within the specified application group
  - `[DesktopName <String>]`: The name of the desktop within the specified desktop group
  - `[HostPoolName <String>]`: The name of the host pool within the specified resource group
  - `[Id <String>]`: Resource identity path
  - `[MsixPackageFullName <String>]`: The version specific package full name of the MSIX package within specified hostpool
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScalingPlanName <String>]`: The name of the scaling plan.
  - `[ScalingPlanScheduleName <String>]`: The name of the ScalingPlanSchedule
  - `[SessionHostName <String>]`: The name of the session host within the specified host pool
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UserSessionId <String>]`: The name of the user session within the specified session host
  - `[WorkspaceName <String>]`: The name of the workspace

## RELATED LINKS

