### Example 1: Get metrics configurations object of a firewall
```powershell
Get-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg"
```

```output
ApplicationInsightsConnectionString : InstrumentationKey=95a645a2-898c-4e40-b285-3f38bbe02e5f;IngestionEndpoint=https:/
                                      /eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagn
                                      ostics.monitor.azure.com/;ApplicationId=b4834f2c-adb3-4319-9e71-0721e949f2df
ApplicationInsightsResourceId       : /subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/06Aug2025/prov
                                      iders/microsoft.insights/components/test-prakgupta3-metrics-ai
Id                                  : /subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/eastus-rg/prov
                                      iders/PaloAltoNetworks.Cloudngfw/firewalls/italynorth-test-fw/metrics/default
Name                                : default
PanEtag                             : cb064af4-f5b9-48f1-ba5f-0dff41f00fc9
ProvisioningState                   : Succeeded
ResourceGroupName                   : eastus-rg
SystemDataCreatedAt                 :
SystemDataCreatedBy                 :
SystemDataCreatedByType             :
SystemDataLastModifiedAt            :
SystemDataLastModifiedBy            :
SystemDataLastModifiedByType        :
Type                                : firewalls/metrics
```

Get metrics configurations object of a firewall.

