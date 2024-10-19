if(($null -eq $TestName) -or ($TestName -contains 'New-AzHealthDeidentificationDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHealthDeidentificationDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHealthDeidentificationDeidService' {
    It 'CreateExpanded' {
        { 
            $config = New-AzHealthDeidentificationDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceToCreateInTests -Location $env.location
            $config.Name | Should -Be $env.deidServiceToCreateInTests
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        { 
            $config = New-AzHealthDeidentificationDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceToCreateInTests -Location $env.location -JsonFilePath (Join-Path $PSScriptRoot '.\jsonConfigs\deidServiceJson.json')
            $config.Name | Should -Be $env.deidServiceToCreateInTests
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        { 
            $config = New-AzHealthDeidentificationDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceToCreateInTests -Location $env.location -JsonString (Get-Content (Join-Path $PSScriptRoot '.\jsonConfigs\deidServiceJson.json'))
            $config.Name | Should -Be $env.deidServiceToCreateInTests
        } | Should -Not -Throw
    }
}
