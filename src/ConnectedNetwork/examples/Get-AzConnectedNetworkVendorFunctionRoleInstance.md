### Example 1: Get-AzConnectedNetworkVendorFunctionRoleInstance via Location, Service key, vendor name and role name
```powershell
PS C:\>  Get-AzConnectedNetworkVendorFunctionRoleInstance -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor -Name hpehss

Id                           :
Name                         : hpehss
OperationalState             : Running
ProvisioningState            :
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

```

Getting the role instance information of role hpehss with Location centraluseuap, Service key 1234-abcd-4321-dcba and vendor name myVendor.

### Example 2: Get-AzConnectedNetworkVendorFunctionRoleInstance via Identity
```powershell
PS C:\> $role = @{ RoleInstanceName = "hpehss"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"; VendorName = "myVendor"; serviceKey = "1234-abcd-4321-dcba"}
PS C:\> Get-AzConnectedNetworkVendorFunctionRoleInstance -InputObject $role

Id                           :
Name                         : hpehss
OperationalState             : Stopped
ProvisioningState            :
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

```

Getting the role instance information of role hpehss with Location centraluseuap, Service key 1234-abcd-4321-dcba, vendor name myVendor and the given subscription.