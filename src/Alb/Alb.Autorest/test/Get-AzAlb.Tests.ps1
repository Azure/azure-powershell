if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAlb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAlb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAlb' {
    It 'List' {
        {
            (Get-AzAlb).Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $alb = Get-AzAlb -Name $env.albName -ResourceGroupName $env.resourceGroup
            $alb.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            (Get-AzAlb -ResourceGroupName $env.resourceGroup).Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
