### Example 1: Create or update the metadata of a DigitalTwinsInstance.
```powershell
New-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Location eastus -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled'
```

```output
Name                       Location ResourceGroupName
----                       -------- -----------------
azps-digitaltwins-instance eastus   azps_test_group
```

Create or update the metadata of a DigitalTwinsInstance.
The usual pattern to modify a property is to retrieve the DigitalTwinsInstance and security metadata, and then combine them with the modified values in a new body to update the DigitalTwinsInstance.