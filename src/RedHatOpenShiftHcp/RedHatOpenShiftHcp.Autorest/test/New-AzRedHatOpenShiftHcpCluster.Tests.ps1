if(($null -eq $TestName) -or ($TestName -contains 'New-AzRedHatOpenShiftHcpCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRedHatOpenShiftHcpCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Throwaway cluster exercised by the C2 create wrapper. Fixed (not random) so the recorded request URIs
# match on playback. Its managed RG is likewise a fixed literal and must NOT pre-exist at record time.
$clusterName = 'cltest-ps'
$managedRg   = 'cltest-ps-managed'

Describe 'New-AzRedHatOpenShiftHcpCluster' {
    It 'CreateExpanded' {
        # Real subscription at record time, masked env.json sub on playback. Everything below the cluster
        # name lives in the request BODY (not the match key), so sub-bearing values only need to be real
        # when actually calling Azure; on playback they are rebuilt from the masked env.json sub.
        $sub = if ($env:AzPSAutorestTestPlaybackMode) { $env.SubscriptionId } else { (Get-AzContext).Subscription.Id }
        $rg  = $env.ResourceGroupName

        $subnetId        = "/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-subnet-1"
        $vnetIntSubnetId = "/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-vnet-integration-subnet"
        $nsgId           = "/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.Network/networkSecurityGroups/customer-nsg"
        $miBase          = "/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities"

        # 9 control-plane operator identities. The C2 wrapper unions these values with the service MI to
        # auto-derive the flat identity.userAssignedIdentities list -- the caller never supplies it.
        $cpOperators = @{
            'cluster-api-azure'        = "$miBase/nikthoma-hcp-01-cp-cluster-api-azure-wl4wdquqroamw"
            'control-plane'            = "$miBase/nikthoma-hcp-01-cp-control-plane-wl4wdquqroamw"
            'cloud-controller-manager' = "$miBase/nikthoma-hcp-01-cp-cloud-controller-manager-wl4wdquqroamw"
            'ingress'                  = "$miBase/nikthoma-hcp-01-cp-ingress-wl4wdquqroamw"
            'disk-csi-driver'          = "$miBase/nikthoma-hcp-01-cp-disk-csi-driver-wl4wdquqroamw"
            'file-csi-driver'          = "$miBase/nikthoma-hcp-01-cp-file-csi-driver-wl4wdquqroamw"
            'image-registry'           = "$miBase/nikthoma-hcp-01-cp-image-registry-wl4wdquqroamw"
            'cloud-network-config'     = "$miBase/nikthoma-hcp-01-cp-cloud-network-config-wl4wdquqroamw"
            'kms'                      = "$miBase/nikthoma-hcp-01-cp-kms-wl4wdquqroamw"
        }
        # 3 data-plane operator identities (NOT folded into the flat identity list by the wrapper).
        $dpOperators = @{
            'disk-csi-driver' = "$miBase/nikthoma-hcp-01-dp-disk-csi-driver-wl4wdquqroamw"
            'file-csi-driver' = "$miBase/nikthoma-hcp-01-dp-file-csi-driver-wl4wdquqroamw"
            'image-registry'  = "$miBase/nikthoma-hcp-01-dp-image-registry-wl4wdquqroamw"
        }
        $smi = "$miBase/nikthoma-hcp-01-service-managed-identity-wl4wdquqroamw"

        # KMS key version: live lookup at record time, masked env.json value on playback (body-only, so az
        # need not run during playback).
        $keyVer = if ($env:AzPSAutorestTestPlaybackMode) {
            $env.KmsKeyVersion
        } else {
            (az keyvault key show --vault-name $env.KmVaultName --name $env.KmsKeyName --query key.kid -o tsv).Split('/')[-1]
        }

        # C2 wrapper invocation. Note the ABSENCE of -UserAssignedIdentity (auto-derived = CP operators
        # union service MI) and -CustomerManagedEncryptionType (hardcoded to KMS) -- the two things this
        # wrapper hides from the caller.
        $c = New-AzRedHatOpenShiftHcpCluster -Name $clusterName -ResourceGroupName $rg -Location $env.Location -SubscriptionId $sub `
            -VersionId '4.22' -VersionChannelGroup 'stable' `
            -NetworkType 'OVNKubernetes' -NetworkPodCidr '10.128.0.0/14' -NetworkServiceCidr '172.30.0.0/16' -NetworkMachineCidr '10.0.0.0/16' -NetworkHostPrefix 23 `
            -ApiVisibility Public -IngressType Public -PlatformOutboundType LoadBalancer `
            -PlatformManagedResourceGroup $managedRg `
            -PlatformSubnetId $subnetId -PlatformNetworkSecurityGroupId $nsgId -PlatformVnetIntegrationSubnetId $vnetIntSubnetId `
            -UserAssignedIdentityControlPlaneOperator $cpOperators -UserAssignedIdentityDataPlaneOperator $dpOperators -UserAssignedIdentityServiceManagedIdentity $smi `
            -KmVaultName $env.KmVaultName -ActiveKeyName $env.KmsKeyName -ActiveKeyVersion $keyVer -KmVisibility Public `
            -ClusterImageRegistryState Enabled -Tag @{ env = 'dev' }

        $c.Name | Should -Be $clusterName
        $c.ProvisioningState | Should -Be 'Succeeded'
        $c.Location | Should -Be $env.Location
        $c.VersionId | Should -Be '4.22'

        # Round-trip: the created cluster is retrievable and terminal.
        $got = Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName $rg -Name $clusterName -SubscriptionId $sub
        $got.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'C2 wrapper hides the flat identity list and the encryption type' {
        # Static guard: the two params the C2 wrapper derives/hardcodes must NOT be on the public surface.
        $params = (Get-Command New-AzRedHatOpenShiftHcpCluster).Parameters.Keys
        $params | Should -Not -Contain 'UserAssignedIdentity'            # auto-derived (CP operators union service MI)
        $params | Should -Not -Contain 'CustomerManagedEncryptionType'  # hardcoded to KMS
    }
}
