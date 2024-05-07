if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWvdSessionHostConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHostConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWvdSessionHostConfiguration' {
    It 'UpdateExpanded' {
        $imageList = Get-AzVMImage -Location $env.Location -PublisherName "microsoftwindowsdesktop" -Offer "office-365" -Sku "win11-23h2-avd-m365" | Select Version
            
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroupPersistent `
        -HostPoolName $env.AutomatedHostpoolPersistent `
        -VMNamePrefix "updateTest" `
        -MarketplaceInfoExactVersion $imageList[0].Version `
        -MarketplaceInfoOffer "office-365" -MarketplaceInfoPublisher "microsoftwindowsdesktop" `
        -MarketplaceInfoSku "win11-23h2-avd-m365" `

        $configuration.VMNamePrefix | Should -Be "updateTest"
    }
}
