### Example 1: Restart-AzConnectedNetworkVendorFunctionRoleInstance via location, serviceKey, vendor name and role instance name
```powershell
Restart-AzConnectedNetworkVendorFunctionRoleInstance -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor -Name role1
```

Restarting a role instance of a vendor network function with the specified serviceKey, location centraluseuap, vendor name myVendor and role instance name role1.

### Example 2: Restart-AzConnectedNetworkVendorFunctionRoleInstance via Identity
```powershell
$role = @{ RoleInstanceName = "role1"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"; VendorName = "myVendor"; serviceKey = "1234-abcd-4321-dcba"}
Restart-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
```

Creating an identity with role instance name role1, location centraluseuap, vendor name myVendor specified subscription, serviceKey. Restarting a role instance with the given identity.