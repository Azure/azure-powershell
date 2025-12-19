if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksManagedClusterCommandResult'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksManagedClusterCommandResult.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksManagedClusterCommandResult' {
    It 'Get' {
        $result = Start-AzAksManagedClusterCommand -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Command "kubectl get pods --all-namespaces -o wide"
        $CommandId =  $result.Id
        $result = Get-AzAksManagedClusterCommandResult -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -CommandId $CommandId
        
        $result.ProvisioningState | Should -Be 'Succeeded'
        $result.ExitCode | Should -Be 0
        $result.Log.contains("aks-command") | Should -Be $true
        $result.Log.contains("kube-system") | Should -Be $true
    }

    It 'GetViaIdentity' {
        $result = Start-AzAksManagedClusterCommand -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Command "kubectl get pods --all-namespaces -o wide"
        $CommandId =  $result.Id
        $command = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/commandResults/$CommandId"}
        $result = Get-AzAksManagedClusterCommandResult -InputObject $command
        
        $result.ProvisioningState | Should -Be 'Succeeded'
        $result.ExitCode | Should -Be 0
        $result.Log.contains("aks-command") | Should -Be $true
        $result.Log.contains("kube-system") | Should -Be $true
    }
}
