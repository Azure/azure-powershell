if(($null -eq $TestName) -or ($TestName -contains 'Get-AzHealthDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHealthDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzHealthDeidService' {
    It 'List' {
        {
            $config = Get-AzHealthDeidService
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $config = Get-AzHealthDeidService -Name $env.deidServiceName -ResourceGroupName $env.resourceGroupName
            $config.Name | Should -Be $env.deidServiceName
        } | Should -Not -Throw
    }

    It 'List1' {
        { 
            $config = Get-AzHealthDeidService -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { 
            $config = Get-AzHealthDeidService -Name $env.deidServiceName -ResourceGroupName $env.resourceGroupName
            $config2 = Get-AzHealthDeidService -InputObject $config
            $config2.Name | Should -Be $env.deidServiceName
        } | Should -Not -Throw
    }
}
