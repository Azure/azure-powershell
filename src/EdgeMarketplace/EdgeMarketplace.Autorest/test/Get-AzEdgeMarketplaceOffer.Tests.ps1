if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeMarketplaceOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeMarketplaceOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeMarketplaceOffer' {
    It 'List' {
        $result = Get-AzEdgeMarketplaceOffer -ResourceUri $env.ResourceUri
    }

    It 'Get' {
        $result = Get-AzEdgeMarketplaceOffer -OfferId $env.OfferId -ResourceUri $env.ResourceUri
    }

    It 'GetViaIdentity' {
        $offerInputObject = @{
            "OfferId" = $env.OfferId;
            "ResourceUri" = $env.ResourceUri;
        }

        $result = Get-AzEdgeMarketplaceOffer -InputObject $offerInputObject
    }
}
