if(($null -eq $TestName) -or ($TestName -contains 'Test-AzKustoSandboxCustomImageNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoSandboxCustomImageNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzKustoSandboxCustomImageNameAvailability' {
    It 'CheckExpanded' {
        $sandboxImageName = "test-name-avilability"

        $testResult = Test-AzKustosandboxCustomImageNameAvailability -ClusterName $env.kustoClusterName -ResourceGroupName $env.resourceGroupName -Name $sandboxImageName
        $testResult.NameAvailable | Should -Be $true
    }

    It 'CheckViaIdentityExpanded' {
        $sandboxImageName = "test-name-avilability"
        $cluster = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.kustoClusterName

        $testResult = Test-AzKustosandboxCustomImageNameAvailability -InputObject $cluster -Name $sandboxImageName
        $testResult.NameAvailable | Should -Be $true
    }
}
