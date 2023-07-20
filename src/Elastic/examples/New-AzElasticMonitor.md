### Example 1: Create a monitor resource
```powershell
New-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Location eastus -Name Monitor01 -Sku ess-monthly-consumption_Monthly -UserInfoEmailAddress user@contoso.com
```

```output
CompanyInfoBusiness                           :
CompanyInfoCountry                            :
CompanyInfoDomain                             :
CompanyInfoEmployeesNumber                    :
CompanyInfoState                              :
ElasticCloudDeploymentAzureSubscriptionId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ElasticCloudDeploymentElasticsearchRegion     : azure-eastus
ElasticCloudDeploymentElasticsearchServiceUrl : https://283b270586b74450a4b05150d74e2e90.eastus.azure.elastic-cloud
                                                .com
ElasticCloudDeploymentId                      : 34eb2e206a8a7049c8d14729fb4d82cc
ElasticCloudDeploymentKibanaServiceUrl        : https://38edd7f06aba44ff874418f5df521ed0.eastus.azure.elastic-cloud
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
SystemDataCreatedAt                           : 07/20/2023 08:16:19
SystemDataCreatedBy                           : user@contoso.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 07/20/2023 08:16:19
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

Create a monitor resource.

### Example 2: Create a monitor resource via JSON string
```powershell
$monitorProps = @{
	location = "eastus"
	sku = @{
		name = "ess-monthly-consumption_Monthly"
	}
	properties = @{
		userInfo = @{
			emailAddress = "user@contoso.com"
		}
	}
}
$monitorPropsJson = ConvertTo-Json -InputObject $monitorProps -Depth 5
New-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 -JsonString $monitorPropsJson
```

```output
CompanyInfoBusiness                           :
CompanyInfoCountry                            :
CompanyInfoDomain                             :
CompanyInfoEmployeesNumber                    :
CompanyInfoState                              :
ElasticCloudDeploymentAzureSubscriptionId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ElasticCloudDeploymentElasticsearchRegion     : azure-eastus
ElasticCloudDeploymentElasticsearchServiceUrl : https://0708d96e6a6e465e9bc08beae8545d46.eastus.azure.elastic-cloud
                                                .com
ElasticCloudDeploymentId                      : 0a75470005346b8dc57e0cb1d596764c
ElasticCloudDeploymentKibanaServiceUrl        : https://2be9491ce2104fdaa251c84a587455da.eastus.azure.elastic-cloud
                                                .com:9243
ElasticCloudDeploymentKibanaSsoUrl            : /sso/v1/go/ec:1836023263:kibana-monitor02?acs=https://monitor02.kb.
                                                eastus.azure.elastic-cloud.com:9243/api/security/saml/callback&sp_l
                                                ogin_url=https://monitor02.kb.eastus.azure.elastic-cloud.com:9243
ElasticCloudDeploymentName                    : Monitor02
ElasticCloudUserElasticCloudSsoDefaultUrl     : https://cloud.elastic.co
ElasticCloudUserEmailAddress                  : user@contoso.com
ElasticCloudUserId                            : xxxxxxxx
GenerateApiKey                                : False
Id                                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/
                                                ElasticResourceGroup01/providers/Microsoft.Elastic/monitors/Monitor
                                                02
IdentityPrincipalId                           :
IdentityTenantId                              :
IdentityType                                  :
LiftrResourceCategory                         : MonitorLogs
LiftrResourcePreference                       : 0
Location                                      : eastus
MonitoringStatus                              : Enabled
Name                                          : Monitor02
ProvisioningState                             : Succeeded
ResourceGroupName                             : ElasticResourceGroup01
SkuName                                       : ess-monthly-consumption_Monthly
SystemDataCreatedAt                           : 07/20/2023 08:24:13
SystemDataCreatedBy                           : user@contoso.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 07/20/2023 08:24:13
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

Create a monitor resource via JSON string.
