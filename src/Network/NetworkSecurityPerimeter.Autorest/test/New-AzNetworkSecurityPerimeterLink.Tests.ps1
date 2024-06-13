if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityPerimeterLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkSecurityPerimeterLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkSecurityPerimeterLink' {
    It 'CreateExpanded' {
        {

        $remoteNsp = '/subscriptions/' +  $env.SubscriptionId + '/resourceGroups/' + $env.rgname  + '/providers/Microsoft.Network/networkSecurityPerimeters/' + $env.tmpNsp7

        New-AzNetworkSecurityPerimeterLink -Name $env.link1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')

        } | Should -Not -Throw
    }
}
