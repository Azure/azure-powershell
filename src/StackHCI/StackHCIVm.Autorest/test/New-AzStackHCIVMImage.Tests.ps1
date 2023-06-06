if(($null -eq $TestName) -or ($TestName -contains 'New-AzStackHCIVMImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStackHCIVMImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStackHCIVMImage' { 
    It 'MarketplaceURN'  {
        New-AzStackHCIVMImage -Name $env.mkpImageName -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -URN $env.urn | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'GalleryImage'  {
         New-AzStackHCIVMImage -Name $env.imageName -ImagePath $env.imagePath  -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Marketplace'  {
        New-AzStackHCIVMImage -Name $env.mkpImageName2 -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -Offer $env.offer -Publisher $env.publisher -Sku $env.sku -Version $env.version | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
}
