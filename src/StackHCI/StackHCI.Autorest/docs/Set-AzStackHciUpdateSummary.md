---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/set-azstackhciupdatesummary
schema: 2.0.0
---

# Set-AzStackHciUpdateSummary

## SYNOPSIS
Put Update summaries under the HCI cluster

## SYNTAX

### PutExpanded (Default)
```
Set-AzStackHciUpdateSummary -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-CurrentSbeVersion <String>] [-CurrentVersion <String>] [-HardwareModel <String>]
 [-HealthCheckDate <DateTime>] [-HealthCheckResult <IPrecheckResult[]>] [-HealthState <HealthState>]
 [-LastChecked <DateTime>] [-LastUpdated <DateTime>] [-Location <String>] [-OemFamily <String>]
 [-PackageVersion <IPackageVersionInfo[]>] [-State <UpdateSummariesPropertiesState>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Put
```
Set-AzStackHciUpdateSummary -ClusterName <String> -ResourceGroupName <String>
 -UpdateLocationProperty <IUpdateSummaries> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Put Update summaries under the HCI cluster

## EXAMPLES

### Example 1:
```powershell
Set-AzStackHciUpdateSummary -ClusterName 'test-cluster' -ResourceGroupName 'test-rg'
```

Sets the update summary for the cluster

## PARAMETERS

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

### -CurrentSbeVersion
Current Sbe version of the stamp.

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

### -CurrentVersion
Current Solution Bundle version of the stamp.

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

### -HardwareModel
Name of the hardware model.

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
An array of pre-check result objects.
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

### -LastChecked
Last time the update service successfully checked for updates

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

### -LastUpdated
Last time an update installation completed successfully.

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

### -OemFamily
OEM family name.

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

### -PackageVersion
Current version of each updatable component.
To construct, see NOTES section for PACKAGEVERSION properties and create a hash table.

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
Overall update state of the stamp.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.UpdateSummariesPropertiesState
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

### -UpdateLocationProperty
Get the update summaries for the cluster
To construct, see NOTES section for UPDATELOCATIONPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateSummaries
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateSummaries

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateSummaries

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`HEALTHCHECKRESULT <IPrecheckResult[]>`: An array of pre-check result objects.
  - `[AdditionalData <String>]`: Property bag of key value pairs for additional information.
  - `[Description <String>]`: Detailed overview of the issue and what impact the issue has on the stamp.
  - `[DisplayName <String>]`: The health check DisplayName localized of the individual test executed.
  - `[HealthCheckSource <String>]`: The name of the services called for the HealthCheck (I.E. Test-AzureStack, Test-Cluster).
  - `[Name <String>]`: Name of the individual test/rule/alert that was executed. Unique, not exposed to the customer.
  - `[Remediation <String>]`: Set of steps that can be taken to resolve the issue found.
  - `[Severity <Severity?>]`: Severity of the result (Critical, Warning, Informational, Hidden). This answers how important the result is. Critical is the only update-blocking severity.
  - `[Status <Status?>]`: The status of the check running (i.e. Failed, Succeeded, In Progress). This answers whether the check ran, and passed or failed.
  - `[TagKey <String>]`: Key that allow grouping/filtering individual tests.
  - `[TagValue <String>]`: Value of the key that allow grouping/filtering individual tests.
  - `[TargetResourceId <String>]`: The unique identifier for the affected resource (such as a node or drive).
  - `[TargetResourceName <String>]`: The name of the affected resource.
  - `[Timestamp <DateTime?>]`: The time in which the HealthCheck was called.
  - `[Title <String>]`: User-facing name; one or more sentences indicating the direct issue.

`PACKAGEVERSION <IPackageVersionInfo[]>`: Current version of each updatable component.
  - `[LastUpdated <DateTime?>]`: Last time this component was updated.
  - `[PackageType <String>]`: Package type
  - `[Version <String>]`: Package version

`UPDATELOCATIONPROPERTY <IUpdateSummaries>`: Get the update summaries for the cluster
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[CurrentSbeVersion <String>]`: Current Sbe version of the stamp.
  - `[CurrentVersion <String>]`: Current Solution Bundle version of the stamp.
  - `[HardwareModel <String>]`: Name of the hardware model.
  - `[HealthCheckDate <DateTime?>]`: Last time the package-specific checks were run.
  - `[HealthCheckResult <IPrecheckResult[]>]`: An array of pre-check result objects.
    - `[AdditionalData <String>]`: Property bag of key value pairs for additional information.
    - `[Description <String>]`: Detailed overview of the issue and what impact the issue has on the stamp.
    - `[DisplayName <String>]`: The health check DisplayName localized of the individual test executed.
    - `[HealthCheckSource <String>]`: The name of the services called for the HealthCheck (I.E. Test-AzureStack, Test-Cluster).
    - `[Name <String>]`: Name of the individual test/rule/alert that was executed. Unique, not exposed to the customer.
    - `[Remediation <String>]`: Set of steps that can be taken to resolve the issue found.
    - `[Severity <Severity?>]`: Severity of the result (Critical, Warning, Informational, Hidden). This answers how important the result is. Critical is the only update-blocking severity.
    - `[Status <Status?>]`: The status of the check running (i.e. Failed, Succeeded, In Progress). This answers whether the check ran, and passed or failed.
    - `[TagKey <String>]`: Key that allow grouping/filtering individual tests.
    - `[TagValue <String>]`: Value of the key that allow grouping/filtering individual tests.
    - `[TargetResourceId <String>]`: The unique identifier for the affected resource (such as a node or drive).
    - `[TargetResourceName <String>]`: The name of the affected resource.
    - `[Timestamp <DateTime?>]`: The time in which the HealthCheck was called.
    - `[Title <String>]`: User-facing name; one or more sentences indicating the direct issue.
  - `[HealthState <HealthState?>]`: Overall health state for update-specific health checks.
  - `[LastChecked <DateTime?>]`: Last time the update service successfully checked for updates
  - `[LastUpdated <DateTime?>]`: Last time an update installation completed successfully.
  - `[Location <String>]`: The geo-location where the resource lives
  - `[OemFamily <String>]`: OEM family name.
  - `[PackageVersion <IPackageVersionInfo[]>]`: Current version of each updatable component.
    - `[LastUpdated <DateTime?>]`: Last time this component was updated.
    - `[PackageType <String>]`: Package type
    - `[Version <String>]`: Package version
  - `[State <UpdateSummariesPropertiesState?>]`: Overall update state of the stamp.

## RELATED LINKS

