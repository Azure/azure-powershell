### Example 1: List all monitors under the specified subscription
```powershell
Get-AzElasticMonitor
```

```output
Name      SkuName                         MonitoringStatus Location
----      -------                         ---------------- --------
Monitor01 ess-monthly-consumption_Monthly Enabled          eastus
Monitor02 ess-monthly-consumption_Monthly Enabled          eastus
Monitor03 ess-monthly-consumption_Monthly Enabled          eastus
Monitor04 ess-monthly-consumption_Monthly Enabled          westus
Monitor05 ess-monthly-consumption_Monthly Enabled          westus
```

List all monitors under the specified subscription.

### Example 2: List all monitors under the specified resource group
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01
```

```output
Name      SkuName                         MonitoringStatus Location
----      -------                         ---------------- --------
Monitor01 ess-monthly-consumption_Monthly Enabled          eastus
Monitor02 ess-monthly-consumption_Monthly Enabled          eastus
Monitor03 ess-monthly-consumption_Monthly Enabled          eastus
```

List all monitors under the specified resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01
```

```output
CompanyInfoBusiness                           :
CompanyInfoCountry                            :
CompanyInfoDomain                             :
CompanyInfoEmployeesNumber                    :
CompanyInfoState                              :
ElasticCloudDeploymentAzureSubscriptionId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ElasticCloudDeploymentElasticsearchRegion     : azure-eastus
ElasticCloudDeploymentElasticsearchServiceUrl : https://d77db1126b14406da269f44d9207cadc.eastus.azure.elastic-cloud
                                                .com
ElasticCloudDeploymentId                      : 4c9b72a426d0f2531f5da53b755ae829
ElasticCloudDeploymentKibanaServiceUrl        : https://25e81d6794fb4750a53df7b321ef05f7.eastus.azure.elastic-cloud
                                                .com:9243
ElasticCloudDeploymentKibanaSsoUrl            : /sso/v1/go/ec:1836023263:kibana-monitor01?acs=https://monitor01.kb.
                                                eastus.azure.elastic-cloud.com:9243/api/security/saml/callback&sp_l
                                                ogin_url=https://monitor01.kb.eastus.azure.elastic-cloud.com:9243
ElasticCloudDeploymentName                    : Monitor01
ElasticCloudUserElasticCloudSsoDefaultUrl     : https://cloud.elastic.co
ElasticCloudUserEmailAddress                  : user@contoso.com
ElasticCloudUserId                            : xxxxxxxx
GenerateApiKey                                : False
Id                                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/
                                                ElasticResourceGroup01/providers/Microsoft.Elastic/monitors/Monitor
                                                01
IdentityPrincipalId                           :
IdentityTenantId                              :
IdentityType                                  :
LiftrResourceCategory                         : MonitorLogs
LiftrResourcePreference                       : 0
Location                                      : eastus
MonitoringStatus                              : Enabled
Name                                          : Monitor01
ProvisioningState                             : Succeeded
ResourceGroupName                             : ElasticResourceGroup01
SkuName                                       : ess-monthly-consumption_Monthly
SystemDataCreatedAt                           : 07/17/2023 05:20:39
SystemDataCreatedBy                           : user@contoso.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 07/17/2023 05:20:39
SystemDataLastModifiedBy                      : user@contoso.com
SystemDataLastModifiedByType                  : User
Tag                                           : {}
Type                                          : microsoft.elastic/monitors
UserInfoCompanyName                           :
UserInfoEmailAddress                          :
UserInfoFirstName                             :
UserInfoLastName                              :
Version                                       :
```

Get the properties of a specific monitor resource.
