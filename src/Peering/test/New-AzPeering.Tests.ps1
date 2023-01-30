if(($null -eq $TestName) -or ($TestName -contains 'New-AzPeering'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPeering.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPeering' {
    It 'CreateExpanded' {
        {
            $peerAsnId = "/subscriptions/e815e305-b43a-49c4-8b1a-4e61f1aec1e8/providers/Microsoft.Peering/peerAsns/ContosoEdgeTest"
            $connection = New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 12.90.152.62 -BgpSessionPeerSessionIPv4Address 12.90.152.61 -BgpSessionPrefixV4 12.90.152.60/30 -PeeringDbFacilityId 86 -SessionAddressProvider Peer -ConnectionIdentifier d1111111111111111111111111111111
            $directConnections = ,$connection
            $peering = New-AzPeering -Name TestPeeringPs -ResourceGroupName DemoRG -Kind Direct -Location "West US 2" -DirectConnection $directConnections -DirectPeeringType Cdn -DirectPeerAsnId $peerAsnId -PeeringLocation Seattle -Sku Premium_Direct_Unlimited
            $peering.Name | Should -Be "TestPeeringPs"
            } | Should -Not -Throw
    }
}
