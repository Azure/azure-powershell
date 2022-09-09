### Example 1: Create a PrivateEndpointConnection object for Account.
```powershell
New-AzDeviceUpdatePrivateEndpointConnectionObject -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
```

```output
Name ProvisioningState ResourceGroupName PrivateLinkServiceConnectionStateStatus
---- ----------------- ----------------- ---------------------------------------
                                         Approved
```

Create a PrivateEndpointConnection object for Account.