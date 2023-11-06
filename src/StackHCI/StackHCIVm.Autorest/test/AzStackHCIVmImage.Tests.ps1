if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVmImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVmImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVmImage' {
    It 'Create Image '  {
        New-AzStackHCIVMImage -Name  $env.imageName -ImagePath  $env.imagePath  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -OSType $env.osTypeLinux | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Create Marketplace Image '  {
        New-AzStackHCIVMImage -Name $env.mkpImageName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -Offer $env.offer -Publisher $env.publisher -Sku $env.sku  -Version $env.version -OSType $env.osTypeWindows | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Create Marketplace Image with URN'  {
        New-AzStackHCIVMImage -Name  $env.mkpImageNameURN  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -URN $env.urn -OSType $env.osTypeWindows | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
    

    It 'List'  {
        {
            $config = Get-AzStackHCIVMImage -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMImage -Name  $env.imageName -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be $env.imageName
        } | Should -Not -Throw
    }


    It 'Delete'{
        {
            Remove-AzStackHCIVMImage -Name  $env.imageName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMImage -Name  $env.mkpImageName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMImage -Name  $env.mkpImageNameURN -ResourceGroupName $env.resourceGroupName -Force
            $config =  Get-AzStackHCIVMImage -Name  $env.imageName -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null

        } | Should -Throw
    }

}
