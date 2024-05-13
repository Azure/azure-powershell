### Example 1: List of all active deployments linked to the given monitor
```powershell
Get-AzNewRelicConnectedPartnerResource -MonitorName test-01 -ResourceGroupName group-test
```

```output
AccountId AccountName     AzureResourceId                                                                                                                 Location
--------- -----------     ---------------                                                                                                                 --------
4404219   Account 4404219 /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/GROUP-TEST/PROVIDERS/NEWRELIC.OBSERVABILITY/MONITORS/TEST-01 eastus
```

This command list of all active deployments that are associated with the marketplace subscription linked to the given monitor.

