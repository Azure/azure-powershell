### Example 1: list all billing containers from a specified subscription
```powershell
Get-AzDeviceRegistryBillingContainer -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

```output
Name                   SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
--------------------   -------------------   ------------------- ----------------------- ------------------------ ------------------------             ----------------------------
my-billingContainer1   12/18/2024 7:36:44 PM user@outlook.com    User                    12/18/2024 7:43:58 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
my-billingContainer2   12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
```

This command lists all the Device Registry billing containers from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`

### Example 2: get a billing container by name
```powershell
Get-AzDeviceRegistryBillingContainer -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Name my-billingContainer1
```

```output
Etag                         : "1f00ec86-0000-0500-0000-66e9d6ab0000"
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.DeviceRegistry/billingContainers/adr-billing
Name                         : adr-billing
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 9/6/2024 12:31:24 AM
SystemDataCreatedBy          : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/17/2024 7:21:14 PM
SystemDataLastModifiedBy     : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataLastModifiedByType : Application
Type                         : microsoft.deviceregistry/billingcontainers
```

This command gets the Device Registry billing container `my-billingContainer1` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`

### Example 3: GetViaIdentity for billing container
```powershell
$billingContainer = @{
  SubscriptionId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
  BillingContainerName = "my-billingContainer1"
}
Get-AzDeviceRegistryBillingContainer -InputObject $billingContainer
```

```output
Etag                         : "1f00ec86-0000-0500-0000-66e9d6ab0000"
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.DeviceRegistry/billingContainers/adr-billing
Name                         : adr-billing
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 9/6/2024 12:31:24 AM
SystemDataCreatedBy          : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/17/2024 7:21:14 PM
SystemDataLastModifiedBy     : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataLastModifiedByType : Application
Type                         : microsoft.deviceregistry/billingcontainers
```

This command gets the Device Registry billing container `my-billingContainer1` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx` via the Identity input object.