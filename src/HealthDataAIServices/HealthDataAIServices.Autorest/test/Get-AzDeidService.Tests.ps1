if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeidService' {
    It 'List' {
        {
            $config = Get-AzDeidService
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $config = Get-AzDeidService -Name $env.deidServiceName -ResourceGroupName $env.resourceGroupName
            $config.Name | Should -Be $env.deidServiceName
        } | Should -Not -Throw
    }

    It 'List1' {
        { 
            $config = Get-AzDeidService -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0
            $config[0].Name | Should -Not -BeNullOrEmpty
            $config[0].ResourceGroupName | Should -Be $env.resourceGroupName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $config = Get-AzDeidService -Name $env.deidServiceName -ResourceGroupName $env.resourceGroupName
            $config2 = Get-AzDeidService -InputObject $config
            $config2.Name | Should -Be $env.deidServiceName
        } | Should -Not -Throw
    }
}
