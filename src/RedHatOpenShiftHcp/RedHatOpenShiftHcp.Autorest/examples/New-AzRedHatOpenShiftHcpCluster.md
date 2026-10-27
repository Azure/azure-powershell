### Example 1: Create an ARO-HCP cluster
```powershell
$cpOperators = @{
    'cluster-api-azure'        = 'myCluster-cp-cluster-api-azure'
    'control-plane'            = 'myCluster-cp-control-plane'
    'cloud-controller-manager' = 'myCluster-cp-cloud-controller-manager'
    'ingress'                  = 'myCluster-cp-ingress'
    'disk-csi-driver'          = 'myCluster-cp-disk-csi-driver'
    'file-csi-driver'          = 'myCluster-cp-file-csi-driver'
    'image-registry'           = 'myCluster-cp-image-registry'
    'cloud-network-config'     = 'myCluster-cp-cloud-network-config'
    'kms'                      = 'myCluster-cp-kms'
}
$dpOperators = @{
    'disk-csi-driver' = 'myCluster-dp-disk-csi-driver'
    'file-csi-driver' = 'myCluster-dp-file-csi-driver'
    'image-registry'  = 'myCluster-dp-image-registry'
}
$smi    = 'myCluster-service-managed-identity'
$subnet = '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-subnet-1'
$nsg    = '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/networkSecurityGroups/customer-nsg'
$vnetIntSubnet = '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-vnet-integration-subnet'

New-AzRedHatOpenShiftHcpCluster -Name myCluster -ResourceGroupName myResourceGroup -Location westeurope `
  -VersionId '4.22' -VersionChannelGroup 'stable' `
  -NetworkType 'OVNKubernetes' -NetworkPodCidr '10.128.0.0/14' -NetworkServiceCidr '172.30.0.0/16' `
  -NetworkMachineCidr '10.0.0.0/16' -NetworkHostPrefix 23 `
  -ApiVisibility Public -IngressType Public -PlatformOutboundType LoadBalancer `
  -PlatformManagedResourceGroup myCluster-managed `
  -PlatformSubnetId $subnet -PlatformNetworkSecurityGroupId $nsg -PlatformVnetIntegrationSubnetId $vnetIntSubnet `
  -UserAssignedIdentityControlPlaneOperator $cpOperators `
  -UserAssignedIdentityDataPlaneOperator $dpOperators `
  -UserAssignedIdentityServiceManagedIdentity $smi `
  -KmVaultName mykeyvault -ActiveKeyName etcd-encryption-key `
  -ActiveKeyVersion 1234567890abcdef1234567890abcdef -KmVisibility Public `
  -ClusterImageRegistryState Enabled -Tag @{ env = 'dev' }
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Creates an ARO-HCP cluster with the 9 control-plane and 3 data-plane operator identities plus the service managed identity, OVNKubernetes networking, and customer-managed (KMS) etcd encryption. The wrapper auto-derives the flat identity list (control-plane operators plus the service MI) and hardcodes the etcd encryption type to KMS, so `-UserAssignedIdentity` and `-CustomerManagedEncryptionType` are not passed. Identity values may be bare names (resolved to full resource IDs via `-PlatformSubnetId`). `-VersionId` must be MAJOR.MINOR (the RP manages the patch); `-VersionChannelGroup` must be `fast` or `stable`.
