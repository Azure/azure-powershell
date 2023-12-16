### Example 1: Update storage appliance
```powershell
Update-AzNetworkCloudStorageAppliance -Name storageApplianceName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId -SerialNumber serialNumber -Tag @{ tag1 = "tag1"; tag2 = "tag2" }
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------   ----------------------- ------------------------ ------------------------  ---------------------------- ------------------
eastus   storagApplianceName 07/12/2023 01:16:50 user1                  Application             07/12/2023 23:43:33      user2                      Application                ResourceGroupName
```

This command updates the properties of the existing storage appliance.
