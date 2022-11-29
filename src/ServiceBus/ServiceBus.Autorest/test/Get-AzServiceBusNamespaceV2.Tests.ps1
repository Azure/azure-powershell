if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusNamespaceV2' {
    It 'List'  {
        $listOfNamespaces = Get-AzServiceBusNamespaceV2
        $listOfNamespaces.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $namespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace
        $namespace.Name | Should -Be $env.namespace
    }

    It 'List1' {
        $listOfNamespaces = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup
        $listOfNamespaces.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $namespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace
        $namespace = Get-AzServiceBusNamespaceV2 -InputObject $namespace
        $namespace.Name | Should -Be $env.namespace
    }

}
