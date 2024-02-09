if(($null -eq $TestName) -or ($TestName -contains 'New-AzSphereDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSphereDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSphereDevice' {
    It 'CreateExpanded' {
        {
            New-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.firstDeviceGroup -Name $env.deviceID4 -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
