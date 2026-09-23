if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeMarketplaceOfferAccessToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeMarketplaceOfferAccessToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeMarketplaceOfferAccessToken' {
    It 'GetExpanded' {
        $result = Get-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -RequestId $env.RequestId
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }

    It 'GetViaJsonString' {
        $result = Get-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -JsonString '{"requestId": "24373:dummy"}'
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }

    It 'GetViaJsonFilePath' {
        $result = Get-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/GetOfferAccessToken.json')
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $requestBody = @{
            "requestId" = $env.RequestId
        }
        $result = Get-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -Body $requestBody
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentityExpanded' {
        $offerIdentity = @{
            "OfferId" = $env.OfferId;
            "ResourceUri" = $env.ResourceUri;
        }

        $result = Get-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -RequestId $env.RequestId
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $requestBody = @{
            "requestId" = $env.RequestId
        }

        $offerIdentity = @{
            "OfferId" = $env.OfferId;
            "ResourceUri" = $env.ResourceUri;
        }

        $result = Get-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -Body $requestBody
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }
}
