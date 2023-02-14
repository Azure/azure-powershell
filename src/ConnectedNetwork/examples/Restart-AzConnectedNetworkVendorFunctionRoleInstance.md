### Example 1: Restart-AzConnectedNetworkVendorFunctionRoleInstance via location, serviceKey, vendor name and role instance name
```powershell
<<<<<<< HEAD
Restart-AzConnectedNetworkVendorFunctionRoleInstance -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor -Name role1
=======
PS C:\> Restart-AzConnectedNetworkVendorFunctionRoleInstance -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor -Name role1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Restarting a role instance of a vendor network function with the specified serviceKey, location centraluseuap, vendor name myVendor and role instance name role1.

### Example 2: Restart-AzConnectedNetworkVendorFunctionRoleInstance via Identity
```powershell
<<<<<<< HEAD
$role = @{ RoleInstanceName = "role1"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"; VendorName = "myVendor"; serviceKey = "1234-abcd-4321-dcba"}
Restart-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
=======
PS C:\> $role = @{ RoleInstanceName = "role1"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"; VendorName = "myVendor"; serviceKey = "1234-abcd-4321-dcba"}
PS C:\> Restart-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Creating an identity with role instance name role1, location centraluseuap, vendor name myVendor specified subscription, serviceKey. Restarting a role instance with the given identity.