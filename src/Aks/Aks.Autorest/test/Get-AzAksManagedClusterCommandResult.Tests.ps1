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
        $CommandId = '706de66629b14267b4962cf015122c12'
        $result = Get-AzAksManagedClusterCommandResult -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -CommandId $CommandId
        
        $result.ProvisioningState | Should -Be 'Succeeded'
        $result.ExitCode | Should -Be 0
        $result.Log.Contains("aks-default") | Should -Be $true
        $result.Log.Contains("aks-pool2")| Should -Be $true
    }

    It 'GetViaIdentity' {
        $command = @{Id = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/aks-test/providers/Microsoft.ContainerService/managedClusters/aks/commandResults/706de66629b14267b4962cf015122c12"}
        $result = Get-AzAksManagedClusterCommandResult -InputObject $command
        
        $result.ProvisioningState | Should -Be 'Succeeded'
        $result.ExitCode | Should -Be 0
        $result.Log.Contains("aks-default") | Should -Be $true
        $result.Log.Contains("aks-pool2")| Should -Be $true

    }
}
