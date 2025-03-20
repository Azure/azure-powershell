if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringConfigServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringConfigServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringConfigServer' {
    It 'Get' {
        { 
            Get-AzSpringConfigServer -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Test-AzSpringConfigServer -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Update-AzSpringConfigServer -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        } | Should -Not -Throw
    }
}
