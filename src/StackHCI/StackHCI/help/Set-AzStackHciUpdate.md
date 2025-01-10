---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/set-azstackhciupdate
schema: 2.0.0
---

# Set-AzStackHciUpdate

## SYNOPSIS
Put specified Update

## SYNTAX

### PutExpanded (Default)
```
Set-AzStackHciUpdate -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AdditionalProperty <String>] [-AvailabilityType <AvailabilityType>]
 [-ComponentVersion <IPackageVersionInfo[]>] [-Description <String>] [-DisplayName <String>]
 [-HealthCheckDate <DateTime>] [-HealthCheckResult <IPrecheckResult[]>] [-HealthState <HealthState>]
 [-InstalledDate <DateTime>] [-Location <String>] [-MinSbeVersionRequired <String>] [-PackagePath <String>]
 [-PackageSizeInMb <Single>] [-PackageType <String>] [-Prerequisite <IUpdatePrerequisite[]>]
 [-Publisher <String>] [-RebootRequired <RebootRequirement>] [-ReleaseLink <String>] [-State <State>]
 [-UpdateStatePropertyNotifyMessage <String>] [-UpdateStatePropertyProgressPercentage <Single>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Put
```
Set-AzStackHciUpdate -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -UpdateProperty <IUpdate> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Put specified Update

## EXAMPLES

### Example 1:
```powershell
Set-AzStackHciUpdate -ClusterName 'test-cluster' -ResourceGroupName 'test-rg' -Name 'test-update'
```

Sets the update

## PARAMETERS

### -AdditionalProperty
Extensible KV pairs serialized as a string.
This is currently used to report the stamp OEM family and hardware model information when an update is flagged as Invalid for the stamp based on OEM type.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityType
Indicates the way the update content can be downloaded.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.AvailabilityType
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the cluster.

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

### -ComponentVersion
An array of component versions for a Solution Bundle update, and an empty array otherwise.

To construct, see NOTES section for COMPONENTVERSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IPackageVersionInfo[]
Parameter Sets: PutExpanded
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

### -Description
Description of the update.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
Display name of the Update

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthCheckDate
Last time the package-specific checks were run.

```yaml
Type: System.DateTime
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthCheckResult
An array of PrecheckResult objects.
To construct, see NOTES section for HEALTHCHECKRESULT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IPrecheckResult[]
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthState
Overall health state for update-specific health checks.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.HealthState
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstalledDate
Date that the update was installed.

```yaml
Type: System.DateTime
Parameter Sets: PutExpanded
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
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinSbeVersionRequired
Minimum Sbe Version of the update.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Update

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: UpdateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackagePath
Path where the update package is available.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageSizeInMb
Size of the package.
This value is a combination of the size from update metadata and size of the payload that results from the live scan operation for OS update content.

```yaml
Type: System.Single
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageType
Customer-visible type of the update.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Prerequisite
If update State is HasPrerequisite, this property contains an array of objects describing prerequisite updates before installing this update.
Otherwise, it is empty.
To construct, see NOTES section for PREREQUISITE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdatePrerequisite[]
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
Publisher of the update package.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RebootRequired
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.RebootRequirement
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReleaseLink
Link to release notes for the update.

```yaml
Type: System.String
Parameter Sets: PutExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
State of the update as it relates to this stamp.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.State
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateProperty
Update details
To construct, see NOTES section for UPDATEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdate
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -UpdateStatePropertyNotifyMessage
Brief message with instructions for updates of AvailabilityType Notify.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateStatePropertyProgressPercentage
Progress percentage of ongoing operation.
Currently this property is only valid when the update is in the Downloading state, where it maps to how much of the update content has been downloaded.

```yaml
Type: System.Single
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of the update.

```yaml
Type: System.String
Parameter Sets: PutExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdate

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdate

## NOTES

## RELATED LINKS
