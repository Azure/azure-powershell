### Example 1: Create Peering service prefix
```powershell
New-AzPeeringServicePrefix -Name TestPrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG -PeeringServicePrefixKey 6a7f0d42-e49c-4eea-a930-280610671c3f -Prefix 91.194.255.0/24
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
```

Create a peering service prefix

