<# if(($null -eq $TestName) -or ($TestName -contains 'New-AzStackHCIVMImage'))
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
        New-AzStackHCIVMImage -Name  $env.mkpImageNameURN  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -URN $env.urn -OSType $env.osTypeWindows | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'GalleryImage'  {
        New-AzStackHCIVMImage -Name  $env.imageName -ImagePath  $env.imagePath  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -OSType $env.osTypeLinux | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Marketplace'  {
        New-AzStackHCIVMImage -Name "testMkpImage2" -SubscriptionId "0709bd7a-8383-4e1d-98c8-f81d1b3443fc" -ResourceGroupName "mkclus0824-rg" -CustomLocationId "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourcegroups/mkclus0824-rg/providers/microsoft.extendedlocation/customlocations/myresourcebridge-cl" -Location "eastus" -Offer "windowsserver" -Publisher "microsoftwindowsserver" -Sku "2022-datacenter-azure-edition-core"  -Version "20348.1850.230906" -OSType "Windows" | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
}
 #>