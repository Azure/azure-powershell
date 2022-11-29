### Example 1: Update the status of a private endpoint connection with the given name.
```powershell
New-AzDigitalTwinsPrivateEndpointConnection -Name "11c903a5-7b8a-4b86-812d-03f007dca6df" -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -PrivateLinkServiceConnectionStateStatus 'Approved' -PrivateLinkServiceConnectionStateDescription "Approved by johndoe@company.com."
```

```output
Name                                 GroupId PrivateLinkServiceConnectionStateStatus ResourceGroupName
----                                 ------- --------------------------------------- -----------------
11c903a5-7b8a-4b86-812d-03f007dca6df {API}   Approved                                azps_test_group
```

Update the status of a private endpoint connection with the given name.
Please Create a Private Endpoint in `Azure Digital Twins` -> `Networking` -> `Private endpoint connections`.