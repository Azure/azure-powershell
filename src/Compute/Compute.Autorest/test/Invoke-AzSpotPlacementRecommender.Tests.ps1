if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSpotPlacementRecommender'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSpotPlacementRecommender.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSpotPlacementRecommender' {
    BeforeAll { 
        $resourceSku1 = @{sku = "Standard_D2_v3"}
        $resourceSku2 = @{sku = "Standard_D2_v2"}
        $resourceSku3 = @{sku = "Standard_D32_v2"}
        $desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
        $desiredLocations = 'eastus','eastus2','westus'
    }

    It 'PostExpanded' {
        {
            $spotPlacementRecommenderInput = 
            @{
                desiredLocations = $desiredLocations;
                desiredSizes = $desiredSizes;
                desiredCount = 100;
                availabilityZones = $true
            }
            Invoke-AzSpotPlacementRecommender -Location eastus -SpotPlacementRecommenderInput $spotPlacementRecommenderInput -verbose
        }
    }

    It 'Post' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
