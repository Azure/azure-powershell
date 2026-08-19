if(($null -eq $TestName) -or ($TestName -contains 'New-AzMonitorHealthModel'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModel.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModel' {
    It 'CreateExpanded' {
        {
            $result = New-AzMonitorHealthModel -Name $env.HealthModelCreateName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -EnableSystemAssignedIdentity -Tag @{ scenario = 'create' }
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.HealthModelCreateName
            $result.Location | Should -Be $env.Location
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
