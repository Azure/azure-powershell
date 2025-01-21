### Example 1: Get specific App Service
```powershell
Get-AzNewRelicMonitoredAppService -MonitorName test-02 -ResourceGroupName ps-test -UserEmail user1@outlook.com -AzureResourceId /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/WEBSITETEST
```

Get specified app service information currently being monitored by specified NewRelic resource.