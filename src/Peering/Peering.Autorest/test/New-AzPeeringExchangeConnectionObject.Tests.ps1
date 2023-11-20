if(($null -eq $TestName) -or ($TestName -contains 'New-AzPeeringExchangeConnectionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPeeringExchangeConnectionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPeeringExchangeConnectionObject' {
    It '__AllParameterSets' {
        {
            $exchangeConnection = New-AzPeeringExchangeConnectionObject -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 1.1.1.1 -BgpSessionPeerSessionIPv4Address 1.1.1.0 -BgpSessionPrefixV4 1.1.1.1/31 -PeeringDbFacilityId 82 -ConnectionIdentifier c111111111111
            $exchangeConnection.ConnectionIdentifier | Should -Be "c111111111111"
        } | Should -Not -Throw
    }
}
