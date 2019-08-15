---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/set-azdiagnosticsetting
schema: 2.0.0
---

# Set-AzDiagnosticSetting

## SYNOPSIS
Creates or updates diagnostic settings for the specified resource.

## SYNTAX

```
Set-AzDiagnosticSetting -Name <String> -ResourceId <String> [-EventHubAuthorizationRuleId <String>]
 [-EventHubName <String>] [-Log <ILogSettings[]>] [-LogAnalyticsDestinationType <String>]
 [-Metric <IMetricSettings[]>] [-ServiceBusRuleId <String>] [-StorageAccountId <String>]
 [-WorkspaceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates diagnostic settings for the specified resource.

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

### -EventHubAuthorizationRuleId
The resource Id for the event hub authorization rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EventHubName
The name of the event hub.
If none is specified, the default event hub will be selected.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Log
The list of logs settings.
To construct, see NOTES section for LOG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20170501Preview.ILogSettings[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LogAnalyticsDestinationType
A string indicating whether the export to Log Analytics should use the default destination type, i.e.
AzureDiagnostics, or use a destination type constructed as follows: \<normalized service identity\>_\<normalized category name\>.
Possible values are: Dedicated and null (null is default.)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metric
The list of metric settings.
To construct, see NOTES section for METRIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20170501Preview.IMetricSettings[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the diagnostic setting.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceId
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServiceBusRuleId
The service bus rule Id of the diagnostic setting.
This is here to maintain backwards compatibility.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountId
The resource ID of the storage account to which you would like to send Diagnostic Logs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WorkspaceId
The full ARM resource ID of the Log Analytics workspace to which you would like to send Diagnostic Logs.
Example: /subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20170501Preview.IDiagnosticSettingsResource

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### LOG <ILogSettings[]>: The list of logs settings.
  - `Enabled <Boolean>`: a value indicating whether this log is enabled.
  - `RetentionPolicyDay <Int32>`: the number of days for the retention in days. A value of 0 will retain the events indefinitely.
  - `RetentionPolicyEnabled <Boolean>`: a value indicating whether the retention policy is enabled.
  - `[Category <String>]`: Name of a Diagnostic Log category for a resource type this setting is applied to. To obtain the list of Diagnostic Log categories for a resource, first perform a GET diagnostic settings operation.

#### METRIC <IMetricSettings[]>: The list of metric settings.
  - `Enabled <Boolean>`: a value indicating whether this category is enabled.
  - `RetentionPolicyDay <Int32>`: the number of days for the retention in days. A value of 0 will retain the events indefinitely.
  - `RetentionPolicyEnabled <Boolean>`: a value indicating whether the retention policy is enabled.
  - `[Category <String>]`: Name of a Diagnostic Metric category for a resource type this setting is applied to. To obtain the list of Diagnostic metric categories for a resource, first perform a GET diagnostic settings operation.
  - `[TimeGrain <TimeSpan?>]`: the timegrain of the metric in ISO8601 format.

## RELATED LINKS

