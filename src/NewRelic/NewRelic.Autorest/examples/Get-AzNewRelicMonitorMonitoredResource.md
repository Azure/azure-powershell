### Example 1: List the resources currently being monitored by the NewRelic monitor resource.
```powershell
Get-AzNewRelicMonitorMonitoredResource -MonitorName test-03 -ResourceGroupName ps-test | Format-List
```

```output
Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/JOYERTEST
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SERVERFARMS/PSTEST
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/JOYERTEST2
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.INSIGHTS/COMPONENTS/JOYERTEST2
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/ACCTEST9482/PROVIDERS/MICROSOFT.INSIGHTS/COMPONENTS/TEST3210
ReasonForLogsStatus    : DiagnosticSettingsLimitReached
ReasonForMetricsStatus : 
SendingLog             : Disabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/MC_KANSINGH-RG_TESTNRCLUSTER_EASTUS/PROVIDERS/MICROSOFT.NETWORK/PUBLICIPADDRESSES/99894EC0-4C67-4D40-BF63-B640D5 
                         9E1596
ReasonForLogsStatus    : DiagnosticSettingsLimitReached
ReasonForMetricsStatus : 
SendingLog             : Disabled
SendingMetric          : 
```

List the resources currently being monitored by the NewRelic monitor resource.

