### Example 1: Create Cluster's bare metal machine key set
```powershell
$tagHash = @{
    tag = "tag"
}
$userList = @{
    description   = "userDescription"
    azureUserName = "userName"
    sshPublicKey  = @{
        keyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
    }
}

New-AzNetworkCloudBareMetalMachineKeySet -ResourceGroupName resourceGroupName -Name baremetalmachinekeysetname -ClusterName clusterName -AzureGroupId azuregroupid -Expiration "2023-12-31T23:59:59.008Z" -OSGroupName osgroupName -ExtendedLocationName /subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/customLocationName -PrivilegeLevel Superuser -JumpHostsAllowed "192.0.0.1" -ExtendedLocationType CustomLocation -Location EastUs -Tag $tagHash  -UserList $userList -SubscriptionId subscriptionId
```
```output
Location Name                          SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                     AzureAsyncOperation
-------- ----                         ------------------- -------------------     ----------------------- ------------------------  ------------------------             ---------------------------- ----                                                     -------------------
EastUs   baremetalmachinekeysetname    05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
```

This command creates a cluster's bare metal machine key set.
