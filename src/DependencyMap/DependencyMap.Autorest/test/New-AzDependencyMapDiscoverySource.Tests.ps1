if(($null -eq $TestName) -or ($TestName -contains 'New-AzDependencyMapDiscoverySource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDependencyMapDiscoverySource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDependencyMapDiscoverySource' {
    It 'CreateExpanded' {
        {
            $property = New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject -SourceId testSourceId
            $dmSource = New-AzDependencyMapDiscoverySource -SourceName $env.sourceNameForCreation -MapName $env.mapName -ResourceGroupName $env.resourceGroup -Location $env.location -Property $property
            $dmSource.Name | Should -Be $env.sourceNameForCreation
        } | Should -Not -Throw
    }
}
