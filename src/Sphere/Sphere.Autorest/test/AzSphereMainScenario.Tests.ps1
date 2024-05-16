if(($null -eq $TestName) -or ($TestName -contains 'AzSphereMainScenario'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzSphereMainScenario.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzSphereMainScenario' {
    It 'CreateUpdateCatalog' {
        {
            Write-Host 'Start to create test catalog' $env.secondCatalog
            $catalogB = New-AzSphereCatalog -Name $env.secondCatalog -ResourceGroupName $env.resourceGroup -Location $env.globalLocation
            $catalogB.Name | Should -Be $env.secondCatalog

            $key = "abc"
            $value = "123"
            $tag = @{$key=$value}
            Write-Host 'Update test catalog identity' $env.secondCatalog
            $catalog = Update-AzSphereCatalog -InputObject $catalogB -Tag $tag
            $catalog.Tag["$key"] | Should -Be $value
        } | Should -Not -Throw
    }

    It 'UpdateCatalog' {
        {
            $key = "123"
            $value = "abc"
            $tag = @{$key=$value}
            $catalog = Update-AzSphereCatalog -Name $env.secondCatalog -ResourceGroupName $env.resourceGroup -Tag $tag
            $catalog.Tag["$key"] | Should -Be $value
        } | Should -Not -Throw
    }
    
    It 'ListCatalogBySub' {
        {
            $listSub = Get-AzSphereCatalog
            $listSub.Count | Should -BeGreaterOrEqual 2
        } | Should -Not -Throw
    }

    It 'GetCatalog' {
        {
            $catalog = Get-AzSphereCatalog -Name $env.secondCatalog -ResourceGroupName $env.resourceGroup
            $catalog.Name | Should -Be $env.secondCatalog
        } | Should -Not -Throw
    }

    It 'ListCatalogByGroup' {
        {
            $listGroup = Get-AzSphereCatalog -ResourceGroupName $env.resourceGroup
            $listGroup.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'GetCertificate' {
        {
            Write-Host 'List certificate for first catalog' $env.secondCatalog
            $certSerial = Get-AzSphereCertificate -ResourceGroupName $env.resourceGroup -CatalogName $env.secondCatalog
            $certSerial.ResourceGroupName | Should -Be $env.resourceGroup

            $serialNumberFirst = $certSerial.Name
            Write-Host 'Get certificate for first catalog' $env.secondCatalog
            $cert = Get-AzSphereCertificate -ResourceGroupName $env.resourceGroup -CatalogName $env.secondCatalog -SerialNumber $serialNumberFirst
            $cert | Should -Not -BeNullOrEmpty

            Write-Host 'Get certificate cert chain for first catalog' $env.secondCatalog
            $chain = Get-AzSphereCertificateCertChain -ResourceGroupName $env.resourceGroup -CatalogName $env.secondCatalog -SerialNumber $serialNumberFirst
            $chain | Should -Not -BeNullOrEmpty
            
            Write-Host 'Get certificate proof for first catalog' $env.secondCatalog
            $proof = Get-AzSphereCertificateProof -ResourceGroupName $env.resourceGroup -CatalogName $env.secondCatalog -SerialNumber $serialNumberFirst -ProofOfPossessionNonce proofOfPossessionNonce
            $proof | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'CreateProduct' {
        {
            New-AzSphereProduct -CatalogName $env.secondCatalog -Name $env.anotherProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'GetProduct' {
        {
            $prod1 = Get-AzSphereProduct -CatalogName $env.secondCatalog -Name $env.anotherProduct -ResourceGroupName $env.resourceGroup
            $prod1.Name | Should -Be $env.anotherProduct
        } | Should -Not -Throw
    }

    It 'UpdateProduct' {
        {
            $description = 'Test product'
            $prod1 = Update-AzSphereProduct -CatalogName $env.secondCatalog -Name $env.anotherProduct -ResourceGroupName $env.resourceGroup -Description $description
            $prod1.Description | Should -Be $description
        } | Should -Not -Throw
    }
    
    It 'CreateGetUpdateDeviceGroup' {
        {
            $deviceGroup = New-AzSphereDeviceGroup -Name $env.anotherDeviceGroup -ProductName $env.anotherProduct -CatalogName $env.secondCatalog -ResourceGroupName $env.resourceGroup
            
            $description = 'Test device group'
            $update = Update-AzSphereDeviceGroup -CatalogName $env.secondCatalog -Name $env.anotherDeviceGroup -ProductName $env.anotherProduct -ResourceGroupName $env.resourceGroup -Description $description
            $update.Description | Should -Be $description

            $result = Get-AzSphereDeviceGroup -InputObject $deviceGroup
            $result.Description | Should -Be $description
            $result.Name | Should -Be $env.anotherDeviceGroup
        } | Should -Not -Throw
    }

    It 'ListGroupInCatalog' {
        {
            $listDeviceGroup = Get-AzSphereCatalogDeviceGroup -ResourceGroupName $env.resourceGroup -CatalogName $env.secondCatalog
            $listDeviceGroup.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'DeleteDeviceGroup' {
        {
            Remove-AzSphereDeviceGroup -CatalogName $env.secondCatalog -Name $env.anotherDeviceGroup -ProductName $env.anotherProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteProduct' {
        {
            Remove-AzSphereProduct -CatalogName $env.secondCatalog -Name $env.anotherProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityCatalog' {
        {
            $catalog = Get-AzSphereCatalog -Name $env.secondCatalog -ResourceGroupName $env.resourceGroup
            Remove-AzSphereCatalog -InputObject $catalog
        } | Should -Not -Throw
    }
}
