if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAIInfraOptimizationVMSkuRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAIInfraOptimizationVMSkuRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAIInfraOptimizationVMSkuRecommendation' {
    It 'RecommendExpanded' {
        $params = @{
            SubscriptionId                  = $env.SubscriptionId
            Location                        = $env.Location
            ModelParameterCount             = 7615616512
            ModelWeightPrecision            = 'BF16'
            ModelLayerCount                 = 28
            ModelKeyValueHeadCount          = 4
            ModelHeadDimension              = 128
            PromptTokenCount                = 2048
            MaxOutputTokenCount             = 512
            MaxConcurrentRequestsPerReplica = 8
            ReplicaCount                    = 2
            RankingPreference               = 'Cost'
            TargetVMSize                    = $env.TargetVMSize
        }
        $result = Get-AzAIInfraOptimizationVMSkuRecommendation @params -IncludeQuota

        $result.ModelParameterCount | Should -Be 7615616512
        $result.ModelWeightPrecision | Should -Be 'BF16'
        $result.BasisParameterCountSource | Should -Be 'Request'
        $result.WorkloadContextLength | Should -Be 2560
        $result.WorkloadMaxConcurrentRequestsPerReplica | Should -Be 8
        $result.Option.Count | Should -BeGreaterThan 0
        $result.Option[0].RecommendationRank | Should -Be 1
        $result.Option | ForEach-Object {
            $_.VMSize | Should -BeIn $env.TargetVMSize
            $_.QuotaStatus | Should -Not -BeNullOrEmpty
        }
    }

    It 'RecommendViaJsonFilePath' {
        $requestPath = Join-Path $TestDrive 'recommendVmSku.json'
        @{
            model    = @{ huggingFaceModelId = $env.HuggingFaceModelId }
            workload = @{ maxConcurrentRequestsPerReplica = 4 }
        } | ConvertTo-Json -Depth 5 | Set-Content -Path $requestPath

        $result = Get-AzAIInfraOptimizationVMSkuRecommendation -SubscriptionId $env.SubscriptionId -Location $env.Location -JsonFilePath $requestPath

        $result.ModelHuggingFaceModelId | Should -Be $env.HuggingFaceModelId
        $result.BasisParameterCountSource | Should -Be 'HuggingFace'
        $result.WorkloadMaxConcurrentRequestsPerReplica | Should -Be 4
        $result.Option.Count | Should -BeGreaterThan 0
    }

    It 'RecommendViaJsonString' {
        $request = @{
            model         = @{ huggingFaceModelId = $env.HuggingFaceModelId }
            targetVmSizes = $env.TargetVMSize
        } | ConvertTo-Json -Depth 5

        $result = Get-AzAIInfraOptimizationVMSkuRecommendation -SubscriptionId $env.SubscriptionId -Location $env.Location -JsonString $request

        $result.ModelHuggingFaceModelId | Should -Be $env.HuggingFaceModelId
        $result.Option.Count | Should -BeGreaterThan 0
        $result.Option | ForEach-Object { $_.VMSize | Should -BeIn $env.TargetVMSize }
        $result.Option[0].ToString() | Should -Be $result.Option[0].VMSize
    }
}
