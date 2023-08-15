### Example 1: Create a new registered prefix
```powershell
New-AzPeeringRegisteredPrefix -Name accessibilityTesting6 -PeeringName DemoPeering -ResourceGroupName DemoRG -Prefix 240.0.5.0/24
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting6 240.0.5.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Pending                Updating
```

Create a new registered prefix object

