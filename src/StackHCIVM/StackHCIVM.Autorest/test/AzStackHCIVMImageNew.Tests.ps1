if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVMImageNew'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVMImageNew.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVMImageNew' {
    It 'Create Image '  {
        New-AzStackHCIVMImage -Name  $env.imageName -ImagePath  $env.imagePath  -SubscriptionId $env.newSubscriptionId -ResourceGroupName $env.newResourceGroupName -CustomLocationId $env.newCustomLocationId -Location $env.location -OSType $env.osTypeLinux | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Create MarketplaceImage  '  {
        New-AzStackHCIVMImage -Name  $env.mkpImageName -Offer $env.offer -Publisher $env.publisher -Sku $env.sku -Version $env.version  -SubscriptionId $env.newSubscriptionId -ResourceGroupName $env.newResourceGroupName -CustomLocationId $env.newCustomLocationId -Location $env.location -OSType $env.osTypeWindows
        $image = Get-AzStackHCIVMImage -ResourceId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/mkclus104-rg/providers/Microsoft.AzureStackHCI/marketplaceGalleryImages/testMkpImage02262"
        $image.ProvisioningState |  Should -BeExactly "Succeeded"
    }


    It 'List'  {
        {
            $config = Get-AzStackHCIVMImage -ResourceGroupName $env.newResourceGroupName -SubscriptionId $env.newSubscriptionId
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMImage -Name  $env.imageName -ResourceGroupName $env.newResourceGroupName -SubscriptionId $env.newSubscriptionId
            $config.Name | Should -Be $env.imageName
        } | Should -Not -Throw
    }


    It 'Delete'{
        {
            Remove-AzStackHCIVMImage -Name  $env.imageName -ResourceGroupName $env.newResourceGroupName -SubscriptionId $env.newSubscriptionId -Force
            $config =  Get-AzStackHCIVMImage -Name  $env.imageName -ResourceGroupName $env.newResourceGroupName 
            $config | Should -Be $null

            Remove-AzStackHCIVMImage -Name  $env.mkpImageName -ResourceGroupName $env.newResourceGroupName -SubscriptionId $env.newSubscriptionId -Force
            $config =  Get-AzStackHCIVMImage -Name  $env.mkpImageName -ResourceGroupName $env.newResourceGroupName 
            $config | Should -Be $null

        } | Should -Throw
    }

}
