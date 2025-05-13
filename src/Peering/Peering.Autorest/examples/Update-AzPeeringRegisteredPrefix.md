### Example 1: Update a new registered prefix
```powershell
Update-AzPeeringRegisteredPrefix -Name accessibilityTesting6 -PeeringName DemoPeering -ResourceGroupName DemoRG -Prefix 240.0.5.0/24
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting6 240.0.5.0/24 11111111-2222-3333-4444-123456789101 Pending                Updating
```

Update a new registered prefix object

