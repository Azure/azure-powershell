if(($null -eq $TestName) -or ($TestName -contains 'AzDeviceUpdatePrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDeviceUpdatePrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDeviceUpdatePrivateEndpointConnection' {
    # Need to create some private endpoint in this resource group
    It 'CreateExpanded' {
        {
            $config = New-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -Name azpstest-privateendpoint-1 -ResourceGroupName $env.resourceGroup -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
            $config.Name | Should -Be "azpstest-privateendpoint-1"

            $config = New-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -Name azpstest-privateendpoint-2 -ResourceGroupName $env.resourceGroup -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
            $config.Name | Should -Be "azpstest-privateendpoint-2"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName $env.resourceGroup -Name azpstest-privateendpoint-1
            $config.Name | Should -Be "azpstest-privateendpoint-1"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName $env.resourceGroup -Name azpstest-privateendpoint-2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName $env.resourceGroup -Name azpstest-privateendpoint-1
            Remove-AzDeviceUpdatePrivateEndpointConnection -InputObject $config
        } | Should -Not -Throw
    }
}
