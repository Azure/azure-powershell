### Example 1: Create Cluster's baseboard management controller key set
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

New-AzNetworkCloudBmcKeySet -ResourceGroupName resourceGroupName -Name baseboardmgtcontrollerkeysetname -ClusterName clusterName -AzureGroupId azuregroupid -Expiration "2023-12-31T23:59:59.008Z" -ExtendedLocationName /subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/customLocationName -PrivilegeLevel ReadOnly -ExtendedLocationType CustomLocation -Location EastUs -Tag $tagHash -UserList $userList
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                                      e
-------- ----        ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- ----------------
eastus   baseboardmgtcontrollerkeysetname 07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                 RG-name
```

This command creates a cluster's baseboard management controller key set.
