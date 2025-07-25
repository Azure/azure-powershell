### Example 1: List all peering service prefixes
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
TestPrefix2 240.0.0.0/24                                         Failed                None        Succeeded
```

Lists all peering service prefixes for the peering service

### Example 2: Get specific peering service prefix
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG -Name TestPrefix
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
```

Gets a specific peering service prefix

