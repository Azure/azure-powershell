### Example 1: Log Profile for Firewall.
```powershell
Save-AzPaloAltoNetworksFirewallLogProfile -FirewallName azps-firewall -ResourceGroupName azps_test_group_pan -LogType TRAFFIC -LogOption SAME_DESTINATION -CommonDestinationMonitorConfigurationsId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/sudh_fire_test/providers/Microsoft.OperationalInsights/workspaces/testAnalyticsX -CommonDestinationMonitorConfigurationsPrimaryKey 7******Q== -CommonDestinationMonitorConfigurationsSecondaryKey 7******w== -CommonDestinationMonitorConfigurationsSubscriptionId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX -CommonDestinationMonitorConfigurationsWorkspace XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX -PassThru
```

```output
True
```

Log Profile for Firewall.