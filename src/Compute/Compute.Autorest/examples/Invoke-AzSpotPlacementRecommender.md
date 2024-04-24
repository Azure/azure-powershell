### Example 1: Regionally scoped Spot Placement Recommender scores
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'

$response = Invoke-AzSpotPlacementRecommender -Location eastus -DesiredCount 1 -DesiredLocation $desiredLocations -DesiredSize $desiredSizes
$response.PlacementScore
```

```output
AvailabilityZone IsQuotaAvailable Region         Score                     Sku
---------------- ---------------- ------         -----                     ---
                 True             japaneast      RestrictedSkuNotAvailable Standard_D2_v3
                 True             japaneast      RestrictedSkuNotAvailable Standard_D2_v2
                 True             japaneast      RestrictedSkuNotAvailable Standard_D4_v3
                 True             southcentralus High                      Standard_D2_v3
                 True             southcentralus High                      Standard_D2_v2
                 True             southcentralus High                      Standard_D4_v3
                 True             centralus      RestrictedSkuNotAvailable Standard_D2_v3
                 True             centralus      RestrictedSkuNotAvailable Standard_D2_v2
                 True             centralus      RestrictedSkuNotAvailable Standard_D4_v3
```

Returns regionally scoped spot placement recommender scores for the input.

### Example 2: Zonally scoped Spot Placement Recommender scores
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'

$response = Invoke-AzSpotPlacementRecommender -Location eastus -DesiredCount 1 -DesiredLocation $desiredLocations -DesiredSize $desiredSizes -AvailabilityZone
$response.PlacementScore
```

```output
AvailabilityZone IsQuotaAvailable Region         Score               Sku
---------------- ---------------- ------         -----               ---
1                True             japaneast      High                Standard_D2_v3
2                True             japaneast      High                Standard_D2_v3
3                True             japaneast      High                Standard_D2_v3
1                True             japaneast      High                Standard_D2_v2
2                True             japaneast      High                Standard_D2_v2
3                True             japaneast      High                Standard_D2_v2
1                True             japaneast      High                Standard_D4_v3
2                True             japaneast      High                Standard_D4_v3
3                True             japaneast      High                Standard_D4_v3
1                True             southcentralus High                Standard_D2_v3
2                True             southcentralus High                Standard_D2_v3
3                True             southcentralus High                Standard_D2_v3
1                True             southcentralus High                Standard_D2_v2
2                True             southcentralus High                Standard_D2_v2
3                True             southcentralus High                Standard_D2_v2
1                True             southcentralus High                Standard_D4_v3
2                True             southcentralus High                Standard_D4_v3
3                True             southcentralus High                Standard_D4_v3
1                True             centralus      DataNotFoundOrStale Standard_D2_v3
2                True             centralus      High                Standard_D2_v3
3                True             centralus      High                Standard_D2_v3
1                True             centralus      DataNotFoundOrStale Standard_D2_v2
2                True             centralus      High                Standard_D2_v2
3                True             centralus      High                Standard_D2_v2
1                True             centralus      DataNotFoundOrStale Standard_D4_v3
2                True             centralus      High                Standard_D4_v3
3                True             centralus      High                Standard_D4_v3
```

Returns zonally scoped spot placement recommender scores for the input.

### Example 3: Regionally scoped Spot Placement Recommender scores using SpotPlacementRecommenderInput parameter as argument
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'
$desiredCount = 1

$spotPlacementRecommenderInput = @{desiredLocation = $desiredLocations; desiredSize = $desiredSizes; desiredCount = $desiredCount; availabilityZone = $false}

$response = Invoke-AzSpotPlacementRecommender -Location eastus -SpotPlacementRecommenderInput $spotPlacementRecommenderInput
$response.PlacementScore
```

```output
AvailabilityZone IsQuotaAvailable Region         Score                     Sku
---------------- ---------------- ------         -----                     ---
                 True             japaneast      RestrictedSkuNotAvailable Standard_D2_v3
                 True             japaneast      RestrictedSkuNotAvailable Standard_D2_v2
                 True             japaneast      RestrictedSkuNotAvailable Standard_D4_v3
                 True             southcentralus High                      Standard_D2_v3
                 True             southcentralus High                      Standard_D2_v2
                 True             southcentralus High                      Standard_D4_v3
                 True             centralus      RestrictedSkuNotAvailable Standard_D2_v3
                 True             centralus      RestrictedSkuNotAvailable Standard_D2_v2
                 True             centralus      RestrictedSkuNotAvailable Standard_D4_v3
```

Returns regionally scoped spot placement recommender scores for the input.

### Example 2: Zonally scoped Spot Placement Recommender scores using SpotPlacementRecommenderInput parameter as argument
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'
$desiredCount = 1

$spotPlacementRecommenderInput = @{desiredLocation = $desiredLocations; desiredSize = $desiredSizes; desiredCount = $desiredCount; availabilityZone = $true}

$response = Invoke-AzSpotPlacementRecommender -Location eastus -SpotPlacementRecommenderInput $spotPlacementRecommenderInput
$response.PlacementScore
```

```output
AvailabilityZone IsQuotaAvailable Region         Score Sku
---------------- ---------------- ------         ----- ---
1                True             japaneast      High  Standard_D2_v3
2                True             japaneast      High  Standard_D2_v3
3                True             japaneast      High  Standard_D2_v3
1                True             japaneast      High  Standard_D2_v2
2                True             japaneast      High  Standard_D2_v2
3                True             japaneast      High  Standard_D2_v2
1                True             japaneast      High  Standard_D4_v3
2                True             japaneast      High  Standard_D4_v3
3                True             japaneast      High  Standard_D4_v3
1                True             southcentralus High  Standard_D2_v3
2                True             southcentralus High  Standard_D2_v3
3                True             southcentralus High  Standard_D2_v3
1                True             southcentralus High  Standard_D2_v2
2                True             southcentralus High  Standard_D2_v2
3                True             southcentralus High  Standard_D2_v2
1                True             southcentralus High  Standard_D4_v3
2                True             southcentralus High  Standard_D4_v3
3                True             southcentralus High  Standard_D4_v3
1                True             centralus      High  Standard_D2_v3
2                True             centralus      High  Standard_D2_v3
3                True             centralus      High  Standard_D2_v3
1                True             centralus      High  Standard_D2_v2
2                True             centralus      High  Standard_D2_v2
3                True             centralus      High  Standard_D2_v2
1                True             centralus      High  Standard_D4_v3
2                True             centralus      High  Standard_D4_v3
3                True             centralus      High  Standard_D4_v3
```

Returns zonally scoped spot placement recommender scores for the input.