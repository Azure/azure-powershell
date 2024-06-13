if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityPerimeterAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkSecurityPerimeterAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkSecurityPerimeterAssociation' {
    It 'CreateExpanded' {
        { 
        
            $profileId = '/subscriptions/' +  $env.SubscriptionId + '/resourceGroups/' + $env.rgname  + '/providers/Microsoft.Network/networkSecurityPerimeters/' + $env.tmpNsp1 + '/profiles/' + $env.tmpProfile2
            $privateLinkResourceId = '/subscriptions/' + $env.SubscriptionId +  '/resourceGroups/' + $env.rgname + '/providers/Microsoft.KeyVault/vaults/' + $env.tmpPaas4Rp

            New-AzNetworkSecurityPerimeterAssociation -Name $env.association1 -SecurityPerimeterName $env.tmpNsp1 -ResourceGroupName $env.rgname -Location $env.location -AccessMode $env.accessMode1 -ProfileId $profileId -PrivateLinkResourceId $privateLinkResourceId

        } | Should -Not -Throw
    }
}
