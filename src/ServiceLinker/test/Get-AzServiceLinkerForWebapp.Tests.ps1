if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerForWebapp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerForWebapp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerForWebapp' {
    It 'List' {
        $linkers = Get-AzServiceLinkerForWebapp -ResourceGroupName $env.resourceGroup -Webapp $env.preparedWebapp
        $linkers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $linker = Get-AzServiceLinkerForWebapp -ResourceGroupName $env.resourceGroup -Webapp $env.preparedWebapp -LinkerName $env.preparedLinker
        $linker.Name | Should -Be $env.preparedLinker
    }

}
