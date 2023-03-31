if(($null -eq $TestName) -or ($TestName -contains 'Start-AzAksManagedClusterCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzAksManagedClusterCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzAksManagedClusterCommand' {
    It 'RunExpanded' {
        $result = Start-AzAksManagedClusterCommand -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Command "kubectl get pods --all-namespaces -o wide"
        $result.ProvisioningState | Should -Be 'Succeeded'
        $result.ExitCode | Should -Be 0
        $result.Log.contains("aks-command") | Should -Be $true
        $result.Log.contains("kube-system") | Should -Be $true
    }

    It 'RunViaIdentityExpanded' {
        $aks = @{Id = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/aks-test/providers/Microsoft.ContainerService/managedClusters/aks"}
        $result = Start-AzAksManagedClusterCommand -InputObject $aks -Command "kubectl get nodes"
        $result.ProvisioningState | Should -Be 'Succeeded'
        $result.ExitCode | Should -Be 0
        $result.Log.contains("aks-default") | Should -Be $true
        $result.Log.contains("aks-pool2") | Should -Be $true
    }
}
