---
external help file: Az.Compute-help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/invoke-azspotplacementscore
schema: 2.0.0
---

# Invoke-AzSpotPlacementScore

## SYNOPSIS
Generates placement scores for Spot VM skus.

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzSpotPlacementScore -Location <String> [-SubscriptionId <String>] [-AvailabilityZone]
 [-DesiredCount <Int32>] [-DesiredLocation <String[]>] [-DesiredSize <IResourceSize[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Post
```
Invoke-AzSpotPlacementScore -Location <String> [-SubscriptionId <String>]
 -SpotPlacementScoresInput <ISpotPlacementScoresInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PostViaIdentityExpanded
```
Invoke-AzSpotPlacementScore -InputObject <IComputeIdentity> [-AvailabilityZone] [-DesiredCount <Int32>]
 [-DesiredLocation <String[]>] [-DesiredSize <IResourceSize[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PostViaIdentity
```
Invoke-AzSpotPlacementScore -InputObject <IComputeIdentity>
 -SpotPlacementScoresInput <ISpotPlacementScoresInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Generates placement scores for Spot VM skus.

## EXAMPLES

### Example 1: Regionally scoped Spot Placement scores
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'

$response = Invoke-AzSpotPlacementScore -Location eastus -DesiredCount 1 -DesiredLocation $desiredLocations -DesiredSize $desiredSizes
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

Returns regionally scoped spot placement scores for the input.

### Example 2: Zonally scoped Spot Placement Scores
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'

$response = Invoke-AzSpotPlacementScore -Location eastus -DesiredCount 1 -DesiredLocation $desiredLocations -DesiredSize $desiredSizes -AvailabilityZone
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

Returns zonally scoped spot placement scores for the input.

### Example 3: Regionally scoped Spot Placement Scores using SpotPlacementScoresInput parameter as argument
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'
$desiredCount = 1

$spotPlacementScoresInput = @{desiredLocation = $desiredLocations; desiredSize = $desiredSizes; desiredCount = $desiredCount; availabilityZone = $false}

$response = Invoke-AzSpotPlacementScore -Location eastus -SpotPlacementScoresInput $spotPlacementScoresInput
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

Returns regionally scoped spot placement scores for the input.

### Example 4: Zonally scoped Spot Placement scores using SpotPlacementScoresInput parameter as argument
```powershell
$resourceSku1 = @{sku = "Standard_D2_v3"}
$resourceSku2 = @{sku = "Standard_D2_v2"}
$resourceSku3 = @{sku = "Standard_D4_v3"}
$desiredSizes = $resourceSku1,$resourceSku2,$resourceSku3
$desiredLocations = 'japaneast','southcentralus','centralus'
$desiredCount = 1
$spotPlacementScoresInput = @{desiredLocation = $desiredLocations; desiredSize = $desiredSizes; desiredCount = $desiredCount; availabilityZone = $true}
$response = Invoke-AzSpotPlacementScore -Location eastus -SpotPlacementScoresInput $spotPlacementScoresInput
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

Returns zonally scoped spot placement scores for the input.

## PARAMETERS

### -AvailabilityZone
Defines if the scope is zonal or regional.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DesiredCount
Desired instance count per region/zone based on the scope.

```yaml
Type: System.Int32
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DesiredLocation
The desired regions

```yaml
Type: System.String[]
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DesiredSize
The desired resource SKUs.
To construct, see NOTES section for DESIREDSIZE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20240601Preview.IResourceSize[]
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: PostViaIdentityExpanded, PostViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: PostExpanded, Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpotPlacementScoresInput
SpotPlacementScores API Input.
To construct, see NOTES section for SPOTPLACEMENTSCORESINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20240601Preview.ISpotPlacementScoresInput
Parameter Sets: Post, PostViaIdentity
Aliases: SpotPlacementRecommenderInput

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: PostExpanded, Post
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20240601Preview.ISpotPlacementScoresInput

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20240601Preview.ISpotPlacementScoresResponse

## NOTES

ALIASES

Invoke-AzSpotPlacementRecommender

## RELATED LINKS
