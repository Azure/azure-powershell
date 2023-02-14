### Example 1: Stop-AzConnectedNetworkVendorFunctionRoleInstance via location, serviceKey, vendor name and role instance name
```powershell
<<<<<<< HEAD
Stop-AzConnectedNetworkVendorFunctionRoleInstance -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor -Name role1
=======
PS C:\> Stop-AzConnectedNetworkVendorFunctionRoleInstance -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor -Name role1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Stoping a role instance of a vendor network function with the specified serviceKey, location centraluseuap, vendor name myVendor and role instance name role1.

### Example 2: Stop-AzConnectedNetworkVendorFunctionRoleInstance via Identity
```powershell
<<<<<<< HEAD
$role = @{ RoleInstanceName = "role1"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"; VendorName = "myVendor"; serviceKey = "1234-abcd-4321-dcba"}
Stop-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role
=======
PS C:\> $role = @{ RoleInstanceName = "role1"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"; VendorName = "myVendor"; serviceKey = "1234-abcd-4321-dcba"}
PS C:\> Stop-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Creating an identity with role instance name role1, location centraluseuap, vendor name myVendor specified subscription, serviceKey. Stopping a role instance with the given identity.