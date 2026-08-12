### Example 1: Update the query on a discovery rule
```powershell
# Replace the Resource Graph query on the discovery rule discover-vms
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' and tags['env'] =~ 'prod' | project id"
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover production virtual machines' -Specification $specification
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms -Property $property
```

Replaces the specification with a Resource Graph query that also filters on the env tag.

### Example 2: Update the Application Insights component on a discovery rule
```powershell
# Point the discovery rule discover-appinsights at a different Application Insights component
$applicationInsightsId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/microsoft.insights/components/azpwsh-appinsights'
$specification = New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId $applicationInsightsId
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover services from Application Insights' -Specification $specification
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-appinsights -Property $property
```

Replaces the specification on an existing Application Insights discovery rule.
