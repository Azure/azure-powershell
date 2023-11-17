### Example 1: Test registered prefix
```powershell
Test-AzPeeringRegisteredPrefix -Name accessibilityTesting2 -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting2 240.0.1.0/24 249aa0dd-6177-4105-94fe-dfefcbf5ab48 Pending               Succeeded
```

Tests the validity of the given registered prefix (shown in prefix validation state)

