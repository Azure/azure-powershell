if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWorkloadsSapDatabaseInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWorkloadsSapDatabaseInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWorkloadsSapDatabaseInstance' {
    It 'Start' {
        $startResponse = Start-AzWorkloadsSapDatabaseInstance -Name $env.SapDatabseInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $startResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StartViaIdentity' {
        $startResponseId = Start-AzWorkloadsSapDatabaseInstance -InputObject $env.DbServerIdSub2
        $startResponseId.Status | Should -Be $env.ProvisioningState
    }
}
