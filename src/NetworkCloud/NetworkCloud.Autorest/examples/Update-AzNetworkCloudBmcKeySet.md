### Example 1: Update Cluster's baseboard management controller key set
```powershell
$tagHash = @{
    tag = "tagUpdate"
}
$userList = @{
    userPrincipalName = "userPrincipalName"
    description   = "userDescription"
    azureUserName = "userName"
    sshPublicKey  = "ssh-rsa aaaKyfsdx= fakekey@vm"
}

$tagUpdatedHash = @{
    tag1 = "tag1"
    tag2 = "tag1Update"
}

Update-AzNetworkCloudBmcKeySet -ResourceGroupName resourceGroupName -Name baseboardmgtcontrollerkeysetname -Tag $tagUpdatedHash -ClusterName clusterName -UserList $userList
```

This command updates properties of a baseboard management controller key set of a cluster.
