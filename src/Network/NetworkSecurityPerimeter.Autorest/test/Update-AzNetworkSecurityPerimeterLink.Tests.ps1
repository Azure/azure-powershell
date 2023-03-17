if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkSecurityPerimeterLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkSecurityPerimeterLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkSecurityPerimeterLink' {
    It 'UpdateExpanded' {
        {

        # write test cases for all fields
        # $remoteNsp = '/subscriptions/' +  $env.SubscriptionId + '/resourceGroups/' + $env.rgname  + '/providers/Microsoft.Network/networkSecurityPerimeters/' + $env.tmpNsp7

        $updateLinkObj = Update-AzNetworkSecurityPerimeterLink -Name $env.tmpLink2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp4  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')

        # $updateLinkObj.autoApprovedRemotePerimeterResourceId | Should -Be $remoteNsp

        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {

           $GETObj = Get-AzNetworkSecurityPerimeterLink -Name $env.tmpLink2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp4

           $UpdateLinkObj = Update-AzNetworkSecurityPerimeterLink -InputObject $GETObj -LocalInboundProfile @('*')

        } | Should -Not -Throw
    }
}
