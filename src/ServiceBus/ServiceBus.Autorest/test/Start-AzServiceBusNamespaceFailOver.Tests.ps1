if(($null -eq $TestName) -or ($TestName -contains 'Start-AzServiceBusNamespaceFailOver'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzServiceBusNamespaceFailOver.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzServiceBusNamespaceFailOver' {
    It 'SetExpanded' {
        Start-AzServiceBusNamespaceFailOver -ResourceGroupName $env.resourceGroup -Name $env.namespaceV10  -PrimaryLocation westus
        $serviceBusNamespace = Get-AzServiceBusNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV10
        $serviceBusNamespace.GeoDataReplicationLocation.Count | Should -Be 2
    }

    It 'SetViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
