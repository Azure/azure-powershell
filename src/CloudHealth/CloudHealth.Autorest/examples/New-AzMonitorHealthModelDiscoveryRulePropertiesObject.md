### Example 1: Build discovery rule properties
```powershell
# Build a discovery rule property object for use with New- or Update-AzMonitorHealthModelDiscoveryRule
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover virtual machines' -Specification $specification
```

Creates the property object to pass to New-AzMonitorHealthModelDiscoveryRule.
