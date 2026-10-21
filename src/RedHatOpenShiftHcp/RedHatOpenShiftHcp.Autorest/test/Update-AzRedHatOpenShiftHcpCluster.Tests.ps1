if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRedHatOpenShiftHcpCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRedHatOpenShiftHcpCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Updates the throwaway cluster created by New-AzRedHatOpenShiftHcpCluster.Tests.ps1. MUST be byte-identical
# to the name the New-/Remove- cluster tests use (the recording match key includes the cluster name in the
# PATCH/GET URIs). Dedicated literal, NOT $env.ClusterName (the persistent live cluster nikthoma-hcp-01).
$clusterName = 'cltest-ps'

Describe 'Update-AzRedHatOpenShiftHcpCluster' {
    It 'UpdateExpanded' {
        # Exercise the C3 wrapper: when operator-identity maps are supplied, Update-Cluster GET-merges them
        # with the current cluster and recomputes the flat identity list (control-plane operators + service MI).
        # We re-assert the SAME identities (idempotent) so the merge path runs without rotating anything, and
        # also change a Tag so the PATCH is a real no-op-free update.
        $sub = if ($env:AzPSAutorestTestPlaybackMode) { $env.SubscriptionId } else { (Get-AzContext).Subscription.Id }
        $rg  = $env.ResourceGroupName
        $miBase = "/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities"

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
        $dpOperators = @{
            'disk-csi-driver' = "$miBase/nikthoma-hcp-01-dp-disk-csi-driver-wl4wdquqroamw"
            'file-csi-driver' = "$miBase/nikthoma-hcp-01-dp-file-csi-driver-wl4wdquqroamw"
            'image-registry'  = "$miBase/nikthoma-hcp-01-dp-image-registry-wl4wdquqroamw"
        }
        $smi = "$miBase/nikthoma-hcp-01-service-managed-identity-wl4wdquqroamw"

        $c = Update-AzRedHatOpenShiftHcpCluster -ResourceGroupName $rg -Name $clusterName -SubscriptionId $sub `
            -UserAssignedIdentityControlPlaneOperator $cpOperators `
            -UserAssignedIdentityDataPlaneOperator $dpOperators `
            -UserAssignedIdentityServiceManagedIdentity $smi `
            -Tag @{ env = 'dev'; updated = 'true' }

        $c.Name | Should -Be $clusterName
        $c.ProvisioningState | Should -Be 'Succeeded'
    }
}
