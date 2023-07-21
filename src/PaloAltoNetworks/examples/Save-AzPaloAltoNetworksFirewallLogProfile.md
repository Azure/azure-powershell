### Example 1: Log Profile for Firewall.
```powershell
Save-AzPaloAltoNetworksFirewallLogProfile -FirewallName azps-firewall -ResourceGroupName azps_test_group_pan -LogType TRAFFIC -LogOption SAME_DESTINATION -CommonDestinationMonitorConfigurationsId /subscriptions/{subId}/resourceGroups/sudh_fire_test/providers/Microsoft.OperationalInsights/workspaces/testAnalyticsX -CommonDestinationMonitorConfigurationsPrimaryKey 7******Q== -CommonDestinationMonitorConfigurationsSecondaryKey 7******w== -CommonDestinationMonitorConfigurationsSubscriptionId /subscriptions/{subId} -CommonDestinationMonitorConfigurationsWorkspace {guid} -PassThru
```

```output
True
```

Log Profile for Firewall.