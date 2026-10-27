if(($null -eq $TestName) -or ($TestName -contains 'New-AzRedHatOpenShiftHcpNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRedHatOpenShiftHcpNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Throwaway node pool exercised by the New/Update/Remove lifecycle tests. Fixed (not random) so the
# recorded request URIs match on playback.
$poolName = 'nptest-ps'

Describe 'New-AzRedHatOpenShiftHcpNodePool' {
    It 'CreateExpanded' {
        # Real subscription at record time, masked env.json sub on playback. The subnet id is in the request
        # BODY (not the match key), so the value only needs to be real when actually calling Azure.
        $sub = if ($env:AzPSAutorestTestPlaybackMode) { $env.SubscriptionId } else { (Get-AzContext).Subscription.Id }
        $subnetId = "/subscriptions/$sub/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-subnet-1"

        $np = New-AzRedHatOpenShiftHcpNodePool -ResourceGroupName $env.ResourceGroupName -HcpOpenShiftClusterName $env.ClusterName `
            -Name $poolName -Location $env.Location `
            -VersionId '4.22.18' -VersionChannelGroup 'stable' `
            -PlatformVMSize 'Standard_D8s_v3' -Replica 1 `
            -PlatformSubnetId $subnetId `
            -OSDiskSizeGiB 64 -OSDiskStorageAccountType StandardSSD_LRS -OSDiskType Managed -AutoRepair

        $np.Name | Should -Be $poolName
        $np.ProvisioningState | Should -Be 'Succeeded'
        $np.Replica | Should -Be 1
        $np.OSDiskSizeGiB | Should -Be 64
    }
}
