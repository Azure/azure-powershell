### Example 1: Create Kubernetes cluster's agent pool
```powershell
    $networkAttachment = @{
        AttachedNetworkId = "l3NetworkId"
    }
    $labels = @{
        Key = "key"
        Value = "value"
    }
    $taints = @{
        Key = "key"
        Value = "value"
    }
    $sshPublicKey = @{
        KeyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
    }

    New-AzNetworkCloudAgentPool -KubernetesClusterName clusterName -Name agentPoolName -ResourceGroupName resourceGroup -Count count -Location location -Mode agentPoolMode -VMSkuName vmSkuName -SubscriptionId subscriptionId -AdministratorConfigurationAdminUsername adminUsername -AdministratorConfigurationSshPublicKey $sshPublicKey -AgentOptionHugepagesCount hugepagesCount -AgentOptionHugepagesSize hugepagesSize -AttachedNetworkConfigurationL3Network $networkAttachment -AvailabilityZone availabilityZones -ExtendedLocationName clusterExtendedLocation -ExtendedLocationType "CustomLocation " -Tag @{tags = "tag"} -Label $labels -Taint $taints -UpgradeSettingMaxSurge maxSurge
```

```output
Location  Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                -------------------              -------------------                   -----------------------                    ------------------------                ------------
westus3  agentpool1 07/18/2023 17:44:02 <identity>                            User                                            07/18/2023 17:46:45         <identity>
```

This command creates an agent pool for the given Kubernetes cluster.
