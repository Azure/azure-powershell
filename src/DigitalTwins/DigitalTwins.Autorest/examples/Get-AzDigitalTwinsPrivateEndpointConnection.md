### Example 1: List private endpoint connection properties for the digital twins instance.
```powershell
Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name                                 GroupId PrivateLinkServiceConnectionStateStatus ResourceGroupName
----                                 ------- --------------------------------------- -----------------
11c903a5-7b8a-4b86-812d-03f007dca6df {API}   Approved                                azps_test_group
```

List private endpoint connection properties for the digital twins instance.

### Example 2: Get private endpoint connection properties for the given private endpoint.
```powershell
Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Name "11c903a5-7b8a-4b86-812d-03f007dca6df"
```

```output
Name                                 GroupId PrivateLinkServiceConnectionStateStatus ResourceGroupName
----                                 ------- --------------------------------------- -----------------
11c903a5-7b8a-4b86-812d-03f007dca6df {API}   Approved                                azps_test_group
```

Get private endpoint connection properties for the given private endpoint.