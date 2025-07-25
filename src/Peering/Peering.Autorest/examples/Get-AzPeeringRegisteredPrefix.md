### Example 1: List all registered prefixes for a peering
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting1 240.0.0.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Failed                Succeeded
accessibilityTesting2 240.0.1.0/24 249aa0dd-6177-4105-94fe-dfefcbf5ab48 Failed                Succeeded
accessibilityTesting3 240.0.2.0/24 4fb59e9e-d4eb-4847-b2ad-9939edda750b Failed                Succeeded
accessibilityTesting4 240.0.4.0/24 b725f16c-759b-4144-93ed-ed4eb89cb8f7 Failed                Succeeded
accessibilityTesting5 240.0.3.0/24 bb1262ca-0b31-45f3-a301-105b0615b21c Failed                Succeeded
```

List all registered prefixes

### Example 2: Get specific registered prefix for a peering
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG -Name accessibilityTesting1
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting1 240.0.0.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Failed                Succeeded
```

Get a specific registered prefix by name

