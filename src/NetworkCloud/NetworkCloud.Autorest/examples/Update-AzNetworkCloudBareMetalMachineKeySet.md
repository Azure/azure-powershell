### Example 1: Update Cluster's bare metal machine key set
```powershell
$tagHash = @{
    tag = "tagUpdate"
}
$userList = @{
    description   = "userDescription"
    azureUserName = "userName"
    sshPublicKey  = @{
        keyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
    }
}
$tagUpdatedHash = @{
    tag1 = "tag1"
    tag2 = "tag1Update"
}

Update-AzNetworkCloudBareMetalMachineKeySet -ResourceGroupName resourceGroupName -Name baremetalmachinekeysetname -Tag $tagUpdatedHash -ClusterName clusterName -UserList $userList -SubscriptionId subscriptionId
```

This command updates the bare metal machine key set of a cluster.
