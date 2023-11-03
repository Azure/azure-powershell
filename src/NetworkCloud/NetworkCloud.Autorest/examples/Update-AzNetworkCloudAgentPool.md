### Example 1: Update Kubernetes cluster's agent pool
```powershell
Update-AzNetworkCloudAgentPool -Name agentPoolName -KubernetesClusterName clusterName -ResourceGroupName resourceGroup -Count updatedCount -Tag @{tags = "newTag"} -UpgradeSettingMaxSurge updatedMaxSurge
```

```output
Location Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------      ----                -------------------               -------------------                  -----------------------                   ------------------------                  --
westus3  agentpool1 07/17/2023 18:14:59 <identity>                           Application                              07/18/2023 17:06:24           <identity>
```

This command updates a Kubernetes cluster agent pool's properties.
