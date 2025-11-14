### Example 1: Create a new metric config object
```powershell
New-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg" -ApplicationInsightsConnectionString "InstrumentationKey=95a645a2-898c-4e40-b285-3f38bbe02e5f;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/;ApplicationId=b4834f2c-adb3-4319-9e71-0721e949f2df" -ApplicationInsightsResourceId "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/06Aug2025/providers/microsoft.insights/components/test-prakgupta3-metrics-ai"
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
PanEtag                             : c97aa9bb-b2e9-47a4-9e2e-cd905fc346ba
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

Create a new metric config object.

