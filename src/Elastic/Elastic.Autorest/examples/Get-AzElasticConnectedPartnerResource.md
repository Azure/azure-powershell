### Example 1: List of all active deployments linked to the given monitor
```powershell
Get-AzElasticConnectedPartnerResource -ResourceGroupName elastic-rg-3eytki -MonitorName elastic-rhqz1v
```

```output
AccountId AccountName     AzureResourceId                                                                                                                 Location
--------- -----------     ---------------                                                                                                                 --------
4404219   Account 4404219 /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/elastic-rg-3eytki/PROVIDERS/MICROSOFT.ELASTIC/MONITORS/elastic-rhqz1v eastus
```

This command list of all active deployments that are associated with the marketplace subscription linked to the given monitor.

