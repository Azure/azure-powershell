if(($null -eq $TestName) -or ($TestName -contains 'New-AzHealthDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHealthDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHealthDeidService' {
    It 'CreateExpanded' {
        { 
            $config = New-AzHealthDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceToCreateInTests -Location $env.location
            $config.Name | Should -Be $env.deidServiceToCreateInTests
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        { 
            $config = New-AzHealthDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceToCreateInTests -JsonFilePath (Join-Path $PSScriptRoot '.\jsonConfigs\deidServiceJson.json')
            $config.Name | Should -Be $env.deidServiceToCreateInTests
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        { 
            $jsonString = Get-Content -Path (Join-Path $PSScriptRoot '.\jsonConfigs\deidServiceJson.json') -Raw
            $config = New-AzHealthDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceToCreateInTests -JsonString $jsonString
            $config.Name | Should -Be $env.deidServiceToCreateInTests
        } | Should -Not -Throw
    }
}
