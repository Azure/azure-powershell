---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/export-azloganalyticrequestratebyinterval
schema: 2.0.0
---

# Export-AzLogAnalyticRequestRateByInterval

## SYNOPSIS
Export logs that show Api requests made by this subscription in the given time window to show throttling activities.

## SYNTAX

### ExportExpanded1 (Default)
```
Export-AzLogAnalyticRequestRateByInterval -Location <String> -SubscriptionId <String>
 -BlobContainerSasUri <String> -FromTime <DateTime> -IntervalLength <IntervalInMins> -ToTime <DateTime>
 [-GroupByOperationName] [-GroupByResourceName] [-GroupByThrottlePolicy] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExportViaIdentityExpanded1
```
Export-AzLogAnalyticRequestRateByInterval -InputObject <IComputeIdentity> -BlobContainerSasUri <String>
 -FromTime <DateTime> -IntervalLength <IntervalInMins> -ToTime <DateTime> [-GroupByOperationName]
 [-GroupByResourceName] [-GroupByThrottlePolicy] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ExportViaIdentity1
```
Export-AzLogAnalyticRequestRateByInterval -InputObject <IComputeIdentity>
 [-Parameter <IRequestRateByIntervalInput>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Export logs that show Api requests made by this subscription in the given time window to show throttling activities.

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BlobContainerSasUri
SAS Uri of the logging blob container to which LogAnalytics Api writes output logs to.

```yaml
Type: System.String
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -FromTime
From time of the query

```yaml
Type: System.DateTime
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GroupByOperationName
Group query result by Operation Name.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GroupByResourceName
Group query result by Resource Name.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GroupByThrottlePolicy
Group query result by Throttle Policy applied.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: ExportViaIdentityExpanded1, ExportViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IntervalLength
Interval value in minutes used to create LogAnalytics call rate logs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.IntervalInMins
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
The location upon which virtual-machine-sizes is queried.

```yaml
Type: System.String
Parameter Sets: ExportExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Api request input for LogAnalytics getRequestRateByInterval Api.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IRequestRateByIntervalInput
Parameter Sets: ExportViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: ExportExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ToTime
To time of the query

```yaml
Type: System.DateTime
Parameter Sets: ExportExpanded1, ExportViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IRequestRateByIntervalInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ILogAnalyticsOperationResult

## ALIASES

## RELATED LINKS

