if(($null -eq $TestName) -or ($TestName -contains 'New-AzPeeringDirectConnectionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPeeringDirectConnectionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPeeringDirectConnectionObject' {
    It '__AllParameterSets' {
        {
            $connection = New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 12.90.152.62 -BgpSessionPeerSessionIPv4Address 12.90.152.61 -BgpSessionPrefixV4 12.90.152.60/30 -PeeringDbFacilityId 86 -SessionAddressProvider Peer -ConnectionIdentifier d1111111111111111111111111111111
            $connection.ConnectionIdentifier | Should -Be "d1111111111111111111111111111111"
        } | Should -Not -Throw
    }
}
