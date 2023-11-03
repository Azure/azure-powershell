### Example 1: Create Kubernetes cluster
```powershell
$tagHash = @{tags = "tag1" }
$agentPoolConfiguration = @{
    count = 1
    mode = "System"
    name = "agentPoolName"
    vmSkuName = "vmSkuName"
    administratorConfiguration = "administratorConfiguration"
}
$sshPublicKey = @{
    KeyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
}
New-AzNetworkCloudKubernetesCluster -ResourceGroupName resourceGroupName `
                -KubernetesClusterName default -Location location `
                -ExtendedLocationName extendedLocationName `
                -ExtendedLocationType "CustomLocation" `
                -KubernetesVersion kubernetesVersion `
                -AadConfigurationAdminGroupObjectId adminGroupObjectIds `
                -AdminUsername "azureuser" `
                -SshPublicKey $sshPublicKey `
                -InitialAgentPoolConfiguration $agentPoolConfiguration `
                -NetworkConfigurationCloudServicesNetworkId cloudServicesNetworkId `
                -NetworkConfigurationCniNetworkId cniNetworkId `
                -SubscriptionId subscriptionId `
                -Tag $tagHash
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   default 08/09/2023 20:23:17 <identity>             User                    08/09/2023 20:44:27      <identity>                            Application                 resourceGroupName

```

This command creates a Kubernetes cluster.
