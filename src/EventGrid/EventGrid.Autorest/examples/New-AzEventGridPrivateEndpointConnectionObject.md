### Example 1: Create an in-memory object for PrivateEndpointConnection.
```powershell
New-AzEventGridPrivateEndpointConnectionObject -GroupId "TestId" -PrivateEndpointId "TestPrivateEndpointId" -PrivateLinkServiceConnectionStateActionsRequired "TestActionsRequired" -PrivateLinkServiceConnectionStateDescription "TestDescription" -PrivateLinkServiceConnectionStateStatus Approved -ProvisioningState Succeeded | Format-List
```

```output
GroupId                                          : {TestId}
Id                                               :
Name                                             :
PrivateEndpointId                                : TestPrivateEndpointId
PrivateLinkServiceConnectionStateActionsRequired : TestActionsRequired
PrivateLinkServiceConnectionStateDescription     : TestDescription
PrivateLinkServiceConnectionStateStatus          : Approved
ProvisioningState                                : Succeeded
ResourceGroupName                                :
Type                                             :
```

Create an in-memory object for PrivateEndpointConnection.