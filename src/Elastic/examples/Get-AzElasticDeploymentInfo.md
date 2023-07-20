### Example 1: Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource
```powershell
Get-AzElasticDeploymentInfo -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
DeploymentUrl                           : /sso/v1/go/ec:1836023263:kibana-monitor01?acs=https://monitor01.kb.eastus
                                          .azure.elastic-cloud.com:9243/api/security/saml/callback&sp_login_url=htt
                                          ps://monitor01.kb.eastus.azure.elastic-cloud.com:9243
DiskCapacity                            : 573440
MarketplaceSaaInfoMarketplaceName       : AzElastic_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_elastic
MarketplaceSaaInfoMarketplaceResourceId :
MarketplaceSaaInfoMarketplaceStatus     :
MarketplaceSubscriptionId               : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
MemoryCapacity                          : 16384
Status                                  : Healthy
Version                                 : 8.8.2
```

Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource.

### Example 2: Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 | Get-AzElasticDeploymentInfo
```

```output
DeploymentUrl                           : /sso/v1/go/ec:1836023263:kibana-monitor01?acs=https://monitor01.kb.eastus
                                          .azure.elastic-cloud.com:9243/api/security/saml/callback&sp_login_url=htt
                                          ps://monitor01.kb.eastus.azure.elastic-cloud.com:9243
DiskCapacity                            : 573440
MarketplaceSaaInfoMarketplaceName       : AzElastic_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_elastic
MarketplaceSaaInfoMarketplaceResourceId :
MarketplaceSaaInfoMarketplaceStatus     :
MarketplaceSubscriptionId               : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
MemoryCapacity                          : 16384
Status                                  : Healthy
Version                                 : 8.8.2
```

Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource via pipeline.
