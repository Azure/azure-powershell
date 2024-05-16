if(($null -eq $TestName) -or ($TestName -contains 'AzSphereImageandDeploymentScenario'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzSphereImageandDeploymentScenario.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
### This test is running with image and deployment.
### Please record this scenario wih first product and prod device group.
Describe 'AzSphereImageandDepoymentScenario' {
    It 'CreateImages' {
        {
            Write-Host 'Create first image' $env.imageID1
            $base64str1 = [system.convert]::ToBase64String($env.imagecontext1)
            New-AzSphereImage -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup -Name $env.imageID1 -Image $base64str1

            Write-Host 'Create second image' $env.imageID2
            $base64str2 = [system.convert]::ToBase64String($env.imagecontext2)
            New-AzSphereImage -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup -Name $env.imageID2 -Image $base64str2
            
            Write-Host 'Create third image' $env.imageID3
            $base64str3 = [system.convert]::ToBase64String($env.imagecontext3)
            New-AzSphereImage -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup -Name $env.imageID3 -Image $base64str3
            
            Write-Host 'Create forth image' $env.imageID4
            $base64str4 = [system.convert]::ToBase64String($env.imagecontext4)
            New-AzSphereImage -CatalogName $env.firstCatalog -ResourceGroupName $env.resourceGroup -Name $env.imageID4 -Image $base64str4
        } | Should -Not -Throw
    }

    It 'CreateGetDeployment' {
        {
            $image1 = Get-AzSphereImage -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -Name $env.imageID1

            $deployment1 = New-AzSphereDeployment -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.ProdDeviceGroup -DeployedImage $image1 -Name .default
            $deploymentNameFirst = $deployment1.Name

            $resultDefault = Get-AzSphereDeployment -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.ProdDeviceGroup -Name .default
            $resultDefault.Name | Should -Be $deploymentNameFirst

            Get-AzSphereDeployment -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.ProdDeviceGroup -Name $deploymentNameFirst

            $image2 = Get-AzSphereImage -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -Name $env.imageID2
            $image3 = Get-AzSphereImage -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -Name $env.imageID3
            $deployment2 = New-AzSphereDeployment -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.ProdDeviceGroup -DeployedImage $image2,$image3 -Name .default
            
            $result = Get-AzSphereDeployment -InputObject $deployment2
            $result.Name | Should -Be $deployment2.Name
        } | Should -Not -Throw
    }
    
    It 'ListImage' {
        {
            $listImage = Get-AzSphereImage -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog
            $listImage.Count | Should -Be 4
        } | Should -Not -Throw
    }

    It 'GetImage' {
        {
            $image = Get-AzSphereImage -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -Name $env.imageID1
            $image.Name | Should -Be $env.imageID1
        } | Should -Not -Throw
    }

    It 'ListDeployment' {
        {
            $deploymentList = Get-AzSphereDeployment -ResourceGroupName $env.resourceGroup -CatalogName $env.firstCatalog -ProductName $env.firstProduct -DeviceGroupName $env.ProdDeviceGroup
            $deploymentList.Count | Should -Be 2
        } | Should -Not -Throw
    }
}
