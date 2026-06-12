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
 [-HealthCheckDate <DateTime>] [-HealthCheckResult <IPrecheckResult[]>] [-HealthState <String>]
 [-LastChecked <DateTime>] [-LastUpdated <DateTime>] [-Location <String>] [-OemFamily <String>]
 [-PackageVersion <IPackageVersionInfo[]>] [-State <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Put
```
Set-AzStackHciUpdateSummary -ClusterName <String> -ResourceGroupName <String>
 -UpdateLocationProperty <IUpdateSummaries> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### PutViaJsonFilePath
```
Set-AzStackHciUpdateSummary -ClusterName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PutViaJsonString
```
Set-AzStackHciUpdateSummary -ClusterName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IPrecheckResult[]
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
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Put operation

```yaml
Type: System.String
Parameter Sets: PutViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Put operation

```yaml
Type: System.String
Parameter Sets: PutViaJsonString
Aliases:

Required: True
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IPackageVersionInfo[]
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
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IUpdateSummaries
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IUpdateSummaries

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IUpdateSummaries

## NOTES

## RELATED LINKS

