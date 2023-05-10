if(($null -eq $TestName) -or ($TestName -contains 'AzDeviceUpdateAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDeviceUpdateAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDeviceUpdateAccount' {
    # It 'CreateExpanded' {
    #     {
    #         $privateEndpointConnection = New-AzDeviceUpdatePrivateEndpointConnectionObject -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
    #         $config = New-AzDeviceUpdateAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -PrivateEndpointConnection $privateEndpointConnection -PublicNetworkAccess 'Enabled' -Sku 'Standard'
    #         $config.Name | Should -Be $env.accountName1
    #     } | Should -Not -Throw
    # }

    It 'List' {
        {
            $config = Get-AzDeviceUpdateAccount
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDeviceUpdateAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.accountName1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzDeviceUpdateAccount -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzDeviceUpdateAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.accountName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzDeviceUpdateAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroup
            $config = Update-AzDeviceUpdateAccount -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.accountName1
        } | Should -Not -Throw
    }

    # It 'Delete' {
    #     {
    #         Remove-AzDeviceUpdateAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroup
    #     } | Should -Not -Throw
    # }

    # It 'DeleteViaIdentity' {
    #     {
    #         $privateEndpointConnection = New-AzDeviceUpdatePrivateEndpointConnectionObject -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
    #         $config = New-AzDeviceUpdateAccount -Name $env.accountName2 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -PrivateEndpointConnection $privateEndpointConnection -PublicNetworkAccess 'Enabled' -Sku 'Standard'
    #         $config.Name | Should -Be $env.accountName2
            
    #         $config = Get-AzDeviceUpdateAccount -Name $env.accountName2 -ResourceGroupName $env.resourceGroup
    #         Remove-AzDeviceUpdateAccount -InputObject $config
    #     } | Should -Not -Throw
    # }
}
