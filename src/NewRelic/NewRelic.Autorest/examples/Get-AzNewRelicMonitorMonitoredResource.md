### Example 1: List the resources currently being monitored by the NewRelic monitor resource.
```powershell
Get-AzNewRelicMonitorMonitoredResource -MonitorName test-03 -ResourceGroupName ps-test | Format-List
```

```output
Id                     : /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/SITETEST
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SERVERFARMS/PSTEST
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/SITETEST2
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.INSIGHTS/COMPONENTS/INSIGHTTEST2
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/ACCTEST9482/PROVIDERS/MICROSOFT.INSIGHTS/COMPONENTS/TEST3210
ReasonForLogsStatus    : DiagnosticSettingsLimitReached
ReasonForMetricsStatus : 
SendingLog             : Disabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/MC_KANSINGH-RG_TESTNRCLUSTER_EASTUS/PROVIDERS/MICROSOFT.NETWORK/PUBLICIPADDRESSES/00001111-aaaa-2222-bbbb-3333cccc4444
ReasonForLogsStatus    : DiagnosticSettingsLimitReached
ReasonForMetricsStatus : 
SendingLog             : Disabled
SendingMetric          : 
```

List the resources currently being monitored by the NewRelic monitor resource.

