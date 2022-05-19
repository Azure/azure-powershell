if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnDeliveryRuleObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnDeliveryRuleObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnDeliveryRuleObject' -Tag 'LiveOnly' {
    It '__AllParameterSets' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
                $cond1 = New-AzCdnDeliveryRuleIsDeviceConditionObject -Name "IsDevice" -ParameterMatchValue "Desktop"
                $action1 = New-AzCdnUrlRewriteActionObject -Name "UrlRewrite" -ParameterDestination "/def" -ParameterSourcePattern "/abc" -ParameterPreserveUnmatchedPath $true
                $action2 = New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject -Name "CacheKeyQueryString" -ParameterQueryStringBehavior "ExcludeAll" -ParameterQueryParameter "abc,def"
                $action3 = New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject -Name "CacheKeyQueryString" -ParameterQueryStringBehavior "IncludeAll"
                $redirect = New-AzCdnUrlRedirectActionObject -Name "UrlRedirect" -ParameterRedirectType "Found" -ParameterDestinationProtocol "MatchRequest"
                $rule0 = New-AzCdnDeliveryRuleObject -Name "EmptyCondition" -Action $redirect,$action3 -Order 0
                $rule1 = New-AzCdnDeliveryRuleObject -Name "Rule1" -Action $action1,$action2 -Condition $cond1 -Order 1
                $deliverypolicy = @($rule0,$rule1)

                $endpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin -DeliveryPolicyRule $deliverypolicy
                
                $endpoint.DeliveryPolicyRule.Count | Should -Be 2

                $endpointName2 = 'e-' + (RandomString -allChars $false -len 6);
                $action = New-AzCdnDeliveryRuleResponseHeaderActionObject -Name "ModifyResponseHeader" -ParameterHeaderAction "Append" -ParameterHeaderName "Access-Control-Allow-Origin" -ParameterValue "*"
                $condition = New-AzCdnDeliveryRuleUrlPathConditionObject -Name "UrlPath" -ParameterOperator "Contains" -ParameterMatchValue "abc"
                $newRule = New-AzCdnDeliveryRuleObject -Name "Rule1" -Condition $condition -Action $action -Order 1
                $deliverypolicy = @($newRule)

                $endpoint = New-AzCdnEndpoint -Name $endpointName2 -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin -DeliveryPolicyRule $deliverypolicy
                
                $endpoint.DeliveryPolicyRule.Count | Should -Be 1
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
