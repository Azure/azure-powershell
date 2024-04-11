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
        $resourceSku3 = @{sku = "Standard_D4_v3"}
        $desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
        $desiredLocations = 'eastus','eastus2','westus'
        $desiredCount = 1
    }

    It 'PostExpanded' {
        {
            # Zonal
            $response = Invoke-AzSpotPlacementRecommender -Location eastus -DesiredCount $desiredCount -DesiredLocation $desiredLocations -DesiredSize $desiredSizes
            $response.PlacementScore | Should -Not -BeNullOrEmpty -ErrorAction Stop

            # Regional
            $response = Invoke-AzSpotPlacementRecommender -Location eastus -DesiredCount $desiredCount -DesiredLocation $desiredLocations -DesiredSize $desiredSizes -AvailabilityZone
            $response.PlacementScore | Should -Not -BeNullOrEmpty -ErrorAction Stop
        } | Should -Not -Throw
    }

    It 'Post' {
        {
            # Zonal
            $spotPlacementRecommenderInput = 
            @{
                desiredSize = $desiredSizes;
                desiredCount = $desiredCount;
                desiredLocation = $desiredLocations;
                availabilityZone = $true
            }
            $response = Invoke-AzSpotPlacementRecommender -Location eastus -SpotPlacementRecommenderInput $spotPlacementRecommenderInput
            $response.PlacementScore | Should -Not -BeNullOrEmpty -ErrorAction Stop

            # Regional
            $spotPlacementRecommenderInput = 
            @{
                desiredSize = $desiredSizes;
                desiredCount = $desiredCount;
                desiredLocation = $desiredLocations;
                availabilityZone = $false
            }
            $response = Invoke-AzSpotPlacementRecommender -Location eastus -SpotPlacementRecommenderInput $spotPlacementRecommenderInput
            $response.PlacementScore | Should -Not -BeNullOrEmpty -ErrorAction Stop
        } | Should -Not -Throw
    }
}
