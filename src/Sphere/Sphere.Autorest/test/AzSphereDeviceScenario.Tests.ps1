if(($null -eq $TestName) -or ($TestName -contains 'AzSphereDeviceScenario'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzSphereDeviceScenario.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
### This test is running with new device.
### Please record this scenario wih new ids.
### It should have one device in first catalog.
Describe 'AzSphereDeviceScenario' {
    It 'CreateProduct' {
        {
            $prodObject = New-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.firstProduct -ResourceGroupName $env.resourceGroup
            $prod1 = Get-AzSphereProduct -InputObject $prodObject
            $prod1.Name | Should -Be $env.firstProduct

            New-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.secondProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'ListProduct' {
        {
            $listProd = Get-AzSphereProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $listProd.Count | Should -BeGreaterOrEqual 2
        } | Should -Not -Throw
    }

    It 'GetProduct' {
        {
            $prod1 = Get-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.firstProduct -ResourceGroupName $env.resourceGroup
            $prod1.Name | Should -Be $env.firstProduct
        } | Should -Not -Throw
    }

    It 'GenerateDefaultAndListDeviceGroup' {
        {
            New-AzSphereProductDefaultDeviceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
            
            Write-Host 'List test device group to verify'
            $listDeviceGroup = Get-AzSphereDeviceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
            $listDeviceGroup.Count | Should -BeGreaterOrEqual 5
        } | Should -Not -Throw
    }

    It 'ListGroupInCatalog' {
        {
            $listDeviceGroup = Get-AzSphereCatalogDeviceGroup -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
            $listDeviceGroup.Count | Should -BeGreaterOrEqual 5
        } | Should -Not -Throw
    }

    It 'GetDevDeviceGroup' {
        {
            $group = Get-AzSphereDeviceGroup -Name $env.DevDeviceGroup -ProductName $env.firstProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $group.Name | Should -Be $env.DevDeviceGroup
        } | Should -Not -Throw
    }

    It 'GetCreateDevice-GenerateDeviceImage' {
        {
            New-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.DevDeviceGroup -Name $env.deviceID -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup

            $device = Get-AzSphereDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -GroupName $env.DevDeviceGroup -Name $env.deviceID
            $device.Name | Should -Be $env.deviceID

            New-AzSphereDeviceCapabilityImage -CatalogName $env.firstCatalog -DeviceGroupName $env.DevDeviceGroup -DeviceName $env.deviceID -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup -Capability 'ApplicationDevelopment'
        } | Should -Not -Throw
    }

    It 'ListDeviceInsight' {
        {
            Get-AzSphereCatalogDeviceInsight -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
        } | Should -Not -Throw
    }

    It 'ListDeviceByGroup' {
        {
            # first product DevGroup 1
            $listDevice = Get-AzSphereDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -GroupName $env.DevDeviceGroup
            $listDevice.Count | Should -Be 1
        } | Should -Not -Throw
    }
}
