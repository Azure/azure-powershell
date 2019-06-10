---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/invoke-azcalculatemetricbaseline
schema: 2.0.0
---

# Invoke-AzCalculateMetricBaseline

## SYNOPSIS
**Lists the baseline values for a resource**.

## SYNTAX

### Calculate (Default)
```
Invoke-AzCalculateMetricBaseline -ResourceUri <String> [-TimeSeriesInformation <ITimeSeriesInformation>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CalculateExpanded
```
Invoke-AzCalculateMetricBaseline -ResourceUri <String> -Sensitivity <String[]> -Value <Double[]>
 [-Timestamp <DateTime[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CalculateViaIdentityExpanded
```
Invoke-AzCalculateMetricBaseline -InputObject <IMonitorIdentity> -Sensitivity <String[]> -Value <Double[]>
 [-Timestamp <DateTime[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CalculateViaIdentity
```
Invoke-AzCalculateMetricBaseline -InputObject <IMonitorIdentity>
 [-TimeSeriesInformation <ITimeSeriesInformation>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
**Lists the baseline values for a resource**.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.IMonitorIdentity
Parameter Sets: CalculateViaIdentityExpanded, CalculateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceUri
The identifier of the resource.
It has the following structure: subscriptions/{subscriptionName}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceName}.
For example: subscriptions/b368ca2f-e298-46b7-b0ab-012281956afa/resourceGroups/vms/providers/Microsoft.Compute/virtualMachines/vm1

```yaml
Type: System.String
Parameter Sets: Calculate, CalculateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Sensitivity
the list of sensitivities for calculating the baseline.

```yaml
Type: System.String[]
Parameter Sets: CalculateExpanded, CalculateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimeSeriesInformation
The time series info needed for calculating the baseline.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20171101Preview.ITimeSeriesInformation
Parameter Sets: Calculate, CalculateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Timestamp
the array of timestamps of the baselines.

```yaml
Type: System.DateTime[]
Parameter Sets: CalculateExpanded, CalculateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Value
The metric values to calculate the baseline.

```yaml
Type: System.Double[]
Parameter Sets: CalculateExpanded, CalculateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20171101Preview.ITimeSeriesInformation

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.IMonitorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20171101Preview.ICalculateBaselineResponse

## ALIASES

## RELATED LINKS

