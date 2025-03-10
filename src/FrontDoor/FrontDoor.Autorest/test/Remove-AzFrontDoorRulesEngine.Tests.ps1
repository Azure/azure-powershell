if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorRulesEngine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorRulesEngine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorRulesEngine' {
    It 'Delete' {
        { 
            $conditions = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable "RequestHeader" -Operator "Equal" -MatchValue "forward" -Transform "Lowercase" -Selector "Rules-Engine-Route-Forward" -NegateCondition $false
            $headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
            $ruleEngineResponseHeaderAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions	
            $ruleEngineResponseHeaderRule = New-AzFrontDoorRulesEngineRuleObject -Name "rule101" -Priority 1 -Action $ruleEngineResponseHeaderAction -MatchCondition $conditions
        
            $ruleEngineForwardAction = New-AzFrontDoorRulesEngineActionObject -ForwardingProtocol "HttpsOnly" -BackendPoolName "backendpool1" -ResourceGroupName $env.ResourceGroupName -FrontDoorName $env.FrontDoorName -QueryParameterStripDirective "StripNone" -DynamicCompression "Disabled" -EnableCaching $true
            $ruleEngineForwardRule = New-AzFrontDoorRulesEngineRuleObject -Name "rule102" -Priority 2 -Action $ruleEngineForwardAction -MatchCondition $conditions
        
            $redirectConditions = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable "RequestHeader" -Operator Equal -MatchValue "redirect" -Transform "Lowercase" -Selector "Rules-Engine-Route-Forward" -NegateCondition $false
            $ruleEngineRedirectAction = New-AzFrontDoorRulesEngineActionObject -RedirectProtocol "MatchRequest" -CustomHost "www.contoso.com" -RedirectType "Moved"
            $ruleEngineRedirectRule = New-AzFrontDoorRulesEngineRuleObject -Name "rule103" -Priority 3 -Action $ruleEngineRedirectAction -MatchCondition $redirectConditions
        
            New-AzFrontDoorRulesEngine -ResourceGroupName $env.ResourceGroupName -Rule $ruleEngineResponseHeaderRule,$ruleEngineForwardRule,$ruleEngineRedirectRule -FrontDoorName $env.FrontDoorName -Name "engine102"
            
            Remove-AzFrontDoorRulesEngine -ResourceGroupName $env.ResourceGroupName -FrontDoorName $env.FrontDoorName -Name "engine102" -PassThru
         } | Should -Not -Throw
    }

    It 'DeleteViaIdentityFrontDoor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
