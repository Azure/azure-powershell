### Example 1: Create a discovery rule from a Resource Graph query
```powershell
# Create the discovery rule discover-vms from an Azure Resource Graph query
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover virtual machines' -Specification $specification
New-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms -Property $property
```

Creates a discovery rule that runs the given Azure Resource Graph query.
The authentication setting's identity needs Reader on the queried scope.

### Example 2: Create a discovery rule from an Application Insights application map
```powershell
# Create the discovery rule discover-appinsights from an Application Insights component
$applicationInsightsId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/microsoft.insights/components/azpwsh-appinsights'
$specification = New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId $applicationInsightsId
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover services from Application Insights' -Specification $specification
New-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-appinsights -Property $property
```

Creates a discovery rule that reads the given Application Insights components.
