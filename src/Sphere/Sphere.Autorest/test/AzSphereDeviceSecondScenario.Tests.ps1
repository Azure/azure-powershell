if(($null -eq $TestName) -or ($TestName -contains 'AzSphereDeviceSecondScenario'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzSphereDeviceSecondScenario.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
### This test is running with old devices. 
### Please clean the environment if necessary.
### Please commit below create cases with new catalog. It need three devices in first catalog.
Describe 'AzSphereDeviceSecondScenario' {
    It 'CreateSecondEnvironment' {
        {
            New-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.secondProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    #Command has some issues
    It 'ClaimDevice23' -Skip {
        {
            Invoke-AzSphereClaimDeviceGroupDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.TestDeviceGroup -DeviceIdentifier $env.deviceID3,$env.deviceID2
        } | Should -Not -Throw
    }

    # Please uncommit this case for new device id
    It 'CreateOtherDevices' -Skip {
        {
            New-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.TestDeviceGroup -Name $env.deviceID2 -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup

            New-AzSphereDeviceGroup -Name $env.DevDeviceGroup -ProductName $env.secondProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup

            New-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.DevDeviceGroup -Name $env.deviceID3 -ProductName $env.secondProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
    # Please uncommit this case for old devices record running
    It 'AssignOtherDevices' {
        {
            # New-AzSphereDeviceGroup -Name $env.DevDeviceGroup -ProductName $env.firstProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $FirstGroupId = '/subscriptions/'+$env.subscriptionId+'/resourceGroups/'+$env.resourceGroup+'/providers/Microsoft.AzureSphere/catalogs/'+$env.firstCatalog+'/products/'+$env.firstProduct+'/deviceGroups/'+$env.DevDeviceGroup
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.defaultLocation -Name $env.deviceID -ProductName $env.defaultLocation -ResourceGroupName $env.resourceGroup -DeviceGroupId $FirstGroupId

            # New-AzSphereDeviceGroup -Name $env.TestDeviceGroup -ProductName $env.firstProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $TestDevice2Group = '/subscriptions/'+$env.subscriptionId+'/resourceGroups/'+$env.resourceGroup+'/providers/Microsoft.AzureSphere/catalogs/'+$env.firstCatalog+'/products/'+$env.firstProduct+'/deviceGroups/'+$env.TestDeviceGroup
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.defaultLocation -Name $env.deviceID2 -ProductName $env.defaultLocation -ResourceGroupName $env.resourceGroup -DeviceGroupId $TestDevice2Group

            New-AzSphereDeviceGroup -Name $env.DevDeviceGroup -ProductName $env.secondProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup
            $TestDevice3Group = '/subscriptions/'+$env.subscriptionId+'/resourceGroups/'+$env.resourceGroup+'/providers/Microsoft.AzureSphere/catalogs/'+$env.firstCatalog+'/products/'+$env.secondProduct+'/deviceGroups/'+$env.DevDeviceGroup
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.defaultLocation -Name $env.deviceID3 -ProductName $env.defaultLocation -ResourceGroupName $env.resourceGroup -DeviceGroupId $TestDevice3Group
        } | Should -Not -Throw
    }

    It 'ListDeviceInCatalog' {
        {
            # first product DevGroup 1,first product TestGroup 1, second product DevGroup 1
            $listDevice = Get-AzSphereCatalogDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
            $listDevice.Count | Should -BeGreaterOrEqual 3
        } | Should -Not -Throw
    }

    It 'CountDeviceInCatalog' {
        {
            # first product DevGroup 1,first product TestGroup 1, second product DevGroup 1
            $result = Invoke-AzSphereCountCatalogDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
            $result.Value | Should -BeGreaterOrEqual 3
        } | Should -Not -Throw
    }

    It 'CountDeviceInProdcut' {
        {
            # first product DevGroup 1,first product TestGroup 1
            $result = Invoke-AzSphereCountProductDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct
            $result.Value | Should -Be 2
        } | Should -Not -Throw
    }

    It 'CountDeviceInGroup' {
        {
            #second product DevGroup 1
            $result = Invoke-AzSphereCountDeviceGroupDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.secondProduct -DeviceGroupName $env.DevDeviceGroup
            $result.Value | Should -Be 1
        } | Should -Not -Throw
    }

    It 'UpdateDevice2AssignSecondProduct' {
        {
            # first product TestGroup 1->0, second product DevGroup 1->2
            $devGroup = Get-AzSphereDeviceGroup -Name $env.DevDeviceGroup -ProductName $env.secondProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup

            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.TestDeviceGroup -Name $env.deviceID2 -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup -DeviceGroupId $devGroup.Id
        } | Should -Not -Throw
    }

    It 'UpdateDeviceUnassign' {
        {
            # first product DevGroup 1, second product DevGroup 2
            $defaultGroupId = '/subscriptions/'+$env.subscriptionId+'/resourceGroups/'+$env.resourceGroup+'/providers/Microsoft.AzureSphere/catalogs/'+$env.firstCatalog+'/products/'+$env.defaultLocation+'/deviceGroups/'+$env.defaultLocation
            
            Write-Host 'Unassign device 3 from second product dev device group into' $env.firstCatalog
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.DevDeviceGroup -Name $env.deviceID3 -ProductName $env.secondProduct -ResourceGroupName $env.resourceGroup -DeviceGroupId $defaultGroupId

            Write-Host 'Unassign device 2 from second product test device group into' $env.firstCatalog
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.DevDeviceGroup -Name $env.deviceID2 -ProductName $env.secondProduct -ResourceGroupName $env.resourceGroup -DeviceGroupId $defaultGroupId

            Write-Host 'Unassign device 1 from first product dev device group into' $env.firstCatalog
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.DevDeviceGroup -Name $env.deviceID -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup -DeviceGroupId $defaultGroupId
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityDeviceGroup' {
        {
            $devicegroup = Get-AzSphereDeviceGroup -CatalogName $env.firstCatalog -Name $env.TestDeviceGroup -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
            Remove-AzSphereDeviceGroup -InputObject $devicegroup
        } | Should -Not -Throw
    }

    It 'DeleteDeviceGroup' {
        {
            Remove-AzSphereDeviceGroup -CatalogName $env.firstCatalog -Name $env.DevDeviceGroup -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityProduct' {
        {
            $product = Get-AzSphereProduct -CatalogName $env.firstCatalog -Name $env.secondProduct -ResourceGroupName $env.resourceGroup
            Remove-AzSphereProduct -InputObject $product
        } | Should -Not -Throw
    }
}
