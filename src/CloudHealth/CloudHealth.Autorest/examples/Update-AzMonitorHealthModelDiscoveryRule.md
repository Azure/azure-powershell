### Example 1: Narrow the query on a discovery rule
```powershell
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' and tags['env'] =~ 'prod' | project id"
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover production virtual machines' -Specification $specification
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms -Property $property
```

Restricts discovery to virtual machines tagged as production.
