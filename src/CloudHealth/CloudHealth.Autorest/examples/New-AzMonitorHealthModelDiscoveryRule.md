### Example 1: Discover virtual machines with a Resource Graph query
```powershell
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover virtual machines' -Specification $specification
New-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms -Property $property
```

Adds every virtual machine returned by the query as an entity. The authentication setting's identity needs Reader on the queried scope.
