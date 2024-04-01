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
    #Command has some issues
    It 'ClaimDevice23' -Skip {
        {
            Invoke-AzSphereClaimDeviceGroupDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.TestDeviceGroup -DeviceIdentifier $env.deviceID3,$env.deviceID2
        } | Should -Not -Throw
    }

    # Please uncommit this case for first record running
    It 'CreateOtherDevices' -Skip {
        {
            New-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.TestDeviceGroup -Name $env.deviceID2 -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup

            New-AzSphereDeviceGroup -Name $env.DevDeviceGroup -ProductName $env.secondProduct -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup

            New-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.DevDeviceGroup -Name $env.deviceID3 -ProductName $env.secondProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
    # Please commit this case for first record running
    It 'AssignOtherDevices' {
        {
            $TestDevice2Group = '/subscriptions/'+$env.subscriptionId+'/resourceGroups/'+$env.resourceGroup+'/providers/Microsoft.AzureSphere/catalogs/'+$env.firstCatalog+'/products/'+$env.firstProduct+'/deviceGroups/'+$env.TestDeviceGroup
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.defaultLocation -Name $env.deviceID2 -ProductName $env.defaultLocation -ResourceGroupName $env.resourceGroup -DeviceGroupId $TestDevice2Group

            $TestDevice3Group = '/subscriptions/'+$env.subscriptionId+'/resourceGroups/'+$env.resourceGroup+'/providers/Microsoft.AzureSphere/catalogs/'+$env.firstCatalog+'/products/'+$env.secondProduct+'/deviceGroups/'+$env.DevDeviceGroup
            Update-AzSphereDevice -CatalogName $env.firstCatalog -GroupName $env.defaultLocation -Name $env.deviceID3 -ProductName $env.defaultLocation -ResourceGroupName $env.resourceGroup -DeviceGroupId $TestDevice3Group
        } | Should -Not -Throw
    }

    It 'ListDeviceInsight' {
        {
            Get-AzSphereCatalogDeviceInsight -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
        } | Should -Not -Throw
    }

    It 'ListDeviceInCatalog' {
        {
            # first product DevGroup 1,first product TestGroup 1, second product DevGroup 1
            $listDevice = Get-AzSphereCatalogDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
            $listDevice.Count | Should -BeGreaterOrEqual 3
        } | Should -Not -Throw
    }

    It 'ListDeviceByGroup' {
        {
            # first product DevGroup 1
            $listDevice = Get-AzSphereDevice -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -GroupName $env.DevDeviceGroup
            $listDevice.Count | Should -Be 1
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
