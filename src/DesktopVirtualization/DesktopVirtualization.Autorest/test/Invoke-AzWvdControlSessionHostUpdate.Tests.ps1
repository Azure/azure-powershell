if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWvdControlSessionHostUpdate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWvdControlSessionHostUpdate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWvdControlSessionHostUpdate' {
    It 'PostExpanded' {
        $imageList = Get-AzVMImage -Location $env.Location -PublisherName "microsoftwindowsdesktop" -Offer "office-365" -Sku "win11-23h2-avd-m365" | Select Version
            
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroupPersistent `
        -HostPoolName $env.AutomatedHostpoolPersistent `
        -MarketplaceInfoExactVersion $imageList[0].Version `
        -MarketplaceInfoOffer "office-365" -MarketplaceInfoPublisher "microsoftwindowsdesktop" `
        -MarketplaceInfoSku "win11-23h2-avd-m365" `
        -FriendlyName "dymmy"
        
        Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName $env.AutomatedHostpoolPersistent -ResourceGroupName $env.ResourceGroupPersistent `
        -SubscriptionId $env.subscriptionId -ScheduledDateTimeZone 'Pacific Standard Time' `
        -UpdateDeleteOriginalVM `
        -UpdateLogOffDelayMinute 0 `
        -UpdateLogOffMessage 'Updating Session Hosts. Will Log off' `
        -UpdateMaxVmsRemoved 1 `
        -NoWait

        Invoke-AzWvdControlSessionHostUpdate -HostPoolName $env.AutomatedHostpoolPersistent -ResourceGroupName $env.ResourceGroupPersistent `
        -SubscriptionId $env.subscriptionId `
        -Action Cancel `
        -CancelMessage "Giving up"
    }
}
