if(($null -eq $TestName) -or ($TestName -contains 'New-AzSpringCloudTestKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSpringCloudTestKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSpringCloudTestKey' {
    It 'RegenerateExpanded' {
        { 
            New-AzSpringCloudTestKey -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01 -KeyType Primary
        } | Should -Not -Throw
    }
}
