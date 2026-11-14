---
external help file:
Module Name: Az.AIInfraOptimization
online version: https://learn.microsoft.com/powershell/module/az.aiinfraoptimization/get-azaiinfraoptimizationvmskurecommendation
schema: 2.0.0
---

# Get-AzAIInfraOptimizationVMSkuRecommendation

## SYNOPSIS
Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.

## SYNTAX

### RecommendExpanded (Default)
```
Get-AzAIInfraOptimizationVMSkuRecommendation -Location <String> [-SubscriptionId <String[]>]
 [-HuggingFaceModelId <String>] [-IncludePlacement] [-IncludePricing] [-IncludeQuota]
 [-MaxConcurrentRequestsPerReplica <Int32>] [-MaxDeploymentCostPerHourAmount <Double>]
 [-MaxDeploymentCostPerHourCurrencyCode <String>] [-MaxOutputTokenCount <Int32>] [-ModelHeadDimension <Int32>]
 [-ModelKeyValueHeadCount <Int32>] [-ModelLayerCount <Int32>] [-ModelMaxContextLength <Int32>]
 [-ModelParameterCount <Int64>] [-ModelWeightPrecision <String>] [-ProcurementOption <String>]
 [-PromptTokenCount <Int32>] [-RankingPreference <String>] [-ReplicaCount <Int32>] [-TargetVMSize <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### RecommendViaJsonFilePath
```
Get-AzAIInfraOptimizationVMSkuRecommendation -Location <String> -JsonFilePath <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### RecommendViaJsonString
```
Get-AzAIInfraOptimizationVMSkuRecommendation -Location <String> -JsonString <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.

## EXAMPLES

### Example 1: Get virtual machine size recommendations for a Hugging Face model
```powershell
Get-AzAIInfraOptimizationVMSkuRecommendation -Location eastus2 -HuggingFaceModelId "Qwen/Qwen2.5-7B-Instruct"
```

```output
BasisContextLengthSource                : Default
BasisModelWeightsCalculation            : ArtifactSize
BasisParameterCountSource               : HuggingFace
MemoryKvCacheGiBPerRequest              : 0.22
MemoryKvCacheGiBTotal                   : 0.22
MemoryModelAndKvCacheGiB                : 14.4
MemoryModelWeightsGiB                   : 14.19
ModelHuggingFaceModelId                 : Qwen/Qwen2.5-7B-Instruct
ModelParameterCount                     : 7615616512
ModelWeightPrecision                    : FP16
Option                                  : {Standard_NC4as_T4_v3, Standard_NC8as_T4_v3, Standard_NC16as_T4_v3, Standard_NV36ads_A10_v5…}
WorkloadContextLength                   : 4096
WorkloadMaxConcurrentRequestsPerReplica : 1
```

Gets Azure virtual machine size recommendations for serving the Qwen/Qwen2.5-7B-Instruct model in the East US 2 region of the current subscription.
The service resolves the model metadata from Hugging Face, sizes the model weights and key-value cache, and returns the ranked virtual machine sizes in the Option property.

### Example 2: List the ranked virtual machine size options
```powershell
$recommendation = Get-AzAIInfraOptimizationVMSkuRecommendation -Location eastus2 -HuggingFaceModelId "Qwen/Qwen2.5-7B-Instruct"
$recommendation.Option | Format-Table RecommendationRank, VMSize, ReadinessStatus, AcceleratorModel, AcceleratorCountPerVM, CostDeploymentHourly
```

```output
RecommendationRank VMSize                                ReadinessStatus      AcceleratorModel AcceleratorCountPerVM CostDeploymentHourly
------------------ ------                                ---------------      ---------------- --------------------- --------------------
                 1 Standard_NC4as_T4_v3                  VerificationRequired T4                                   1                 1.05
                 2 Standard_NC8as_T4_v3                  VerificationRequired T4                                   1                 1.50
                 3 Standard_NC16as_T4_v3                 VerificationRequired T4                                   1                 2.41
                 4 Standard_NV36ads_A10_v5               VerificationRequired A10                                  1                 3.20
                 5 Standard_NC24ads_A100_v4              VerificationRequired A100                                 1                 3.67
                 6 Standard_NC64as_T4_v3                 VerificationRequired T4                                   4                 4.35
                 7 Standard_NV36adms_A10_v5              VerificationRequired A10                                  1                 4.52
                 8 Standard_NC144lds_xl_RTXPRO6000BSE_v6 VerificationRequired RTX PRO 6000                         1                 5.50
                 9 Standard_NC144ds_xl_RTXPRO6000BSE_v6  VerificationRequired RTX PRO 6000                         1                 6.38
                10 Standard_NV72ads_A10_v5               VerificationRequired A10                                  2                 6.52
```

Lists the recommended virtual machine sizes from best to worst match.
Each option includes its readiness, accelerator hardware, node topology, and the hourly cost of the whole deployment in the currency shown by CostCurrencyCode.

### Example 3: Size a model from its parameter count and architecture
```powershell
$params = @{
    Location                             = "eastus2"
    ModelParameterCount                  = 70000000000
    ModelWeightPrecision                 = "FP16"
    ModelLayerCount                      = 80
    ModelKeyValueHeadCount               = 8
    ModelHeadDimension                   = 128
    PromptTokenCount                     = 8000
    MaxOutputTokenCount                  = 1024
    MaxConcurrentRequestsPerReplica      = 4
    ReplicaCount                         = 2
    RankingPreference                    = "Cost"
    MaxDeploymentCostPerHourAmount       = 50
    MaxDeploymentCostPerHourCurrencyCode = "USD"
}
$recommendation = Get-AzAIInfraOptimizationVMSkuRecommendation @params
$recommendation.Option | Format-Table RecommendationRank, VMSize, AcceleratorModel, AcceleratorCountPerVM, TopologyEstimatedTotalNodeCount, CostDeploymentHourly
```

```output
RecommendationRank VMSize                                AcceleratorModel AcceleratorCountPerVM TopologyEstimatedTotalNodeCount CostDeploymentHourly
------------------ ------                                ---------------- --------------------- ------------------------------- --------------------
                 1 Standard_NC288ds_xl_RTXPRO6000BSE_v6  RTX PRO 6000                         2                               2                22.00
                 2 Standard_NC288lds_xl_RTXPRO6000BSE_v6 RTX PRO 6000                         2                               2                22.00
                 3 Standard_NC144lds_xl_RTXPRO6000BSE_v6 RTX PRO 6000                         1                               4                22.00
                 4 Standard_NC24ads_A100_v4              A100                                 1                               6                22.04
                 5 Standard_NC144ds_xl_RTXPRO6000BSE_v6  RTX PRO 6000                         1                               4                25.52
                 6 Standard_NC80adis_H100_v5             H100 NVL                             2                               2                27.92
                 7 Standard_NC40ads_H100_v5              H100 NVL                             1                               4                27.92
                 8 Standard_NCC40ads_H100_v5             H100 NVL                             1                               4                27.92
                 9 Standard_NC96ads_A100_v4              A100                                 4                               2                29.38
                10 Standard_NC48ads_A100_v4              A100                                 2                               4                29.38
```

Sizes a 70-billion-parameter model that is not published on Hugging Face from its parameter count and architecture.
Each of the 2 replicas serves up to 4 concurrent requests with 8000 prompt tokens and 1024 output tokens.
The options are ranked by cost, and only deployments that cost at most 50 USD per hour are returned.

### Example 4: Check subscription quota, capacity placement, and pricing
```powershell
$recommendation = Get-AzAIInfraOptimizationVMSkuRecommendation -Location eastus2 -HuggingFaceModelId "Qwen/Qwen2.5-7B-Instruct" -IncludeQuota -IncludePlacement -IncludePricing
$recommendation.Option | Select-Object -First 2 | Format-List VMSize, ReadinessStatus, QuotaStatus, QuotaReason, PlacementStatus, CostSource, CostDeploymentHourly
```

```output
VMSize               : Standard_NC24ads_A100_v4
ReadinessStatus      : QuotaIncreaseRequired
QuotaStatus          : Unavailable
QuotaReason          : Insufficient quota for deployment (regular). Required vCPUs: 24, regional vCPU quota available: 100, SKU family 'StandardNCADSA100v4Family' vCPU quota available: 0.
PlacementStatus      : NotEvaluated
CostSource           : AzureSubscription
CostDeploymentHourly : 3.673

VMSize               : Standard_NC40ads_H100_v5
ReadinessStatus      : QuotaIncreaseRequired
QuotaStatus          : Unavailable
QuotaReason          : Insufficient quota for deployment (regular). Required vCPUs: 40, regional vCPU quota available: 100, SKU family 'StandardNCadsH100v5Family' vCPU quota available: 0.
PlacementStatus      : NotEvaluated
CostSource           : AzureSubscription
CostDeploymentHourly : 6.98
```

Evaluates the subscription quota, capacity placement, and subscription pricing for each recommended virtual machine size.
ReadinessStatus shows whether a size can be deployed, and the Quota and Placement properties explain why it cannot.
Placement is evaluated only for sizes that have available quota.

### Example 5: Rank selected virtual machine sizes by latency
```powershell
$recommendation = Get-AzAIInfraOptimizationVMSkuRecommendation -Location eastus2 -HuggingFaceModelId "Qwen/Qwen2.5-72B-Instruct" -TargetVMSize "Standard_NC48ads_A100_v4", "Standard_NC96ads_A100_v4", "Standard_ND96isr_H100_v5" -RankingPreference Latency
$recommendation.Option | Format-Table RecommendationRank, VMSize, TopologyEstimatedTotalNodeCount, PerformanceEstimateTtftMS, CostDeploymentHourly
```

```output
RecommendationRank VMSize                   TopologyEstimatedTotalNodeCount PerformanceEstimateTtftMS CostDeploymentHourly
------------------ ------                   ------------------------------- ------------------------- --------------------
                 1 Standard_ND96isr_H100_v5                               1                    141.50                98.32
                 2 Standard_NC96ads_A100_v4                               1                    775.70                14.69
                 3 Standard_NC48ads_A100_v4                               2                    775.70                14.69
```

Ranks only the listed virtual machine sizes, from the lowest to the highest estimated latency.
PerformanceEstimateTtftMS is the estimated time to first token of a single request, in milliseconds.

### Example 6: Pass the request body as a JSON string
```powershell
$request = @{
    model        = @{ huggingFaceModelId = "Qwen/Qwen2.5-7B-Instruct"; weightPrecision = "BF16" }
    deployment   = @{ replicaCount = 2; procurementOption = "Spot" }
    optimization = @{ rankingPreference = "Cost" }
} | ConvertTo-Json -Depth 5
$recommendation = Get-AzAIInfraOptimizationVMSkuRecommendation -Location westus3 -JsonString $request
$recommendation.Option | Select-Object -First 3 | Format-Table RecommendationRank, VMSize, ReadinessStatus, CostDeploymentHourly, CostCurrencyCode
```

```output
RecommendationRank VMSize                   ReadinessStatus      CostDeploymentHourly CostCurrencyCode
------------------ ------                   ---------------      -------------------- ----------------
                 1 Standard_NV36ads_A10_v5  VerificationRequired                 1.18 USD
                 2 Standard_NC24ads_A100_v4 VerificationRequired                 1.49 USD
                 3 Standard_NV36adms_A10_v5 VerificationRequired                 1.67 USD
```

Sends a request body that uses the REST API property names as a JSON string.
This request prices 2 Spot replicas of the model served in BF16 precision in the West US 3 region.

### Example 7: Pass the request body from a JSON file
```powershell
@'
{
  "model": { "huggingFaceModelId": "Qwen/Qwen2.5-7B-Instruct" },
  "workload": {
    "maxConcurrentRequestsPerReplica": 16,
    "tokenBudget": { "promptTokens": 2048, "maxOutputTokens": 512 }
  },
  "targetVmSizes": [ "Standard_NC24ads_A100_v4", "Standard_NC40ads_H100_v5" ]
}
'@ | Set-Content -Path ./vmsku-request.json
$recommendation = Get-AzAIInfraOptimizationVMSkuRecommendation -Location eastus2 -JsonFilePath ./vmsku-request.json
$recommendation.Option | Format-Table RecommendationRank, VMSize, AcceleratorModel, TopologyEstimatedTotalNodeCount, CostDeploymentHourly
```

```output
RecommendationRank VMSize                   AcceleratorModel TopologyEstimatedTotalNodeCount CostDeploymentHourly
------------------ ------                   ---------------- ------------------------------- --------------------
                 1 Standard_NC24ads_A100_v4 A100                                           1                 3.67
                 2 Standard_NC40ads_H100_v5 H100 NVL                                       1                 6.98
```

Reads the request body from a JSON file that uses the REST API property names.
The request ranks two virtual machine sizes for 16 concurrent requests per replica, each with 2048 prompt tokens and 512 output tokens.

## PARAMETERS

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

### -HuggingFaceModelId
The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.

```yaml
Type: System.String
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludePlacement
Whether to query placement scores for candidate virtual machine sizes with available quota.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludePricing
Whether to fetch subscription-scoped virtual machine pricing.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeQuota
Whether to evaluate subscription quota for candidate virtual machine sizes.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Recommend operation

```yaml
Type: System.String
Parameter Sets: RecommendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Recommend operation

```yaml
Type: System.String
Parameter Sets: RecommendViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxConcurrentRequestsPerReplica
The maximum number of simultaneous inference requests handled by each deployment replica.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxDeploymentCostPerHourAmount
The maximum cost per hour for the whole deployment.
Must be greater than zero when supplied.

```yaml
Type: System.Double
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxDeploymentCostPerHourCurrencyCode
The ISO 4217 currency code the amount is expressed in.
The recommendation service currently supports `USD`.

```yaml
Type: System.String
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxOutputTokenCount
The maximum number of generated output tokens per inference request.
Must be supplied together with PromptTokenCount, and the two must total from 1 through 2147483647 without exceeding the model's maximum context length.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelHeadDimension
The attention head dimension, used for architecture-aware key-value cache sizing.
Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelKeyValueHeadCount
The model key-value head count, used for architecture-aware key-value cache sizing.
Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelLayerCount
The model layer count, used for architecture-aware key-value cache sizing.
Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelMaxContextLength
The maximum context length the model supports, in tokens.
Used only as an upper bound for the sizing context length when Hugging Face metadata provides no usable maximum.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelParameterCount
The logical total model parameter count, including all mixture-of-experts experts.
May be supplied with or without a model identifier.

```yaml
Type: System.Int64
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelWeightPrecision
The precision the model weights are served at.
Matched case-insensitively.

```yaml
Type: System.String
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProcurementOption
The Azure virtual machine procurement option.

```yaml
Type: System.String
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PromptTokenCount
The number of prompt, or input, tokens per inference request.
Must be supplied together with MaxOutputTokenCount, and the two must total from 1 through 2147483647 without exceeding the model's maximum context length.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RankingPreference
The preference used to rank the recommended options.

```yaml
Type: System.String
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicaCount
The number of deployment replicas used for cost, quota, and placement calculations.

```yaml
Type: System.Int32
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMSize
The Azure virtual machine candidate set.
When supplied, only these virtual machine sizes are ranked.
Entries must be non-blank and unique, compared case-insensitively.

```yaml
Type: System.String[]
Parameter Sets: RecommendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse

## NOTES

## RELATED LINKS

