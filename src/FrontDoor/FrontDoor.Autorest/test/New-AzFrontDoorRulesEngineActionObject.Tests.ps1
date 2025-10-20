if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorRulesEngineActionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorRulesEngineActionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorRulesEngineActionObject' {
    It 'ForwardingParameterSet' -skip {
        $FDName = $env.FrontDoorName
        $resourceGroupName = $env.ResourceGroupName
        $subId = $env.SubscriptionId

        $headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
        $ruleEngineForwardAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions -ForwardingProtocol "HttpsOnly" -BackendPoolName "backendpool1" -ResourceGroupName $resourceGroupName -FrontDoorName $FDName -QueryParameterStripDirective "StripNone" -DynamicCompression "Disabled" -EnableCaching $true
        $ruleEngineForwardAction.RouteConfigurationOverride.ForwardingProtocol | Should -Be "HttpsOnly"
        $ruleEngineForwardAction.RouteConfigurationOverride.BackendPoolId | Should -Be "/subscriptions/$subId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/frontDoors/$FDName/BackendPools/backendPool1"
        $ruleEngineForwardAction.RouteConfigurationOverride.CacheConfiguration.GetType() | Should -Be "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.CacheConfiguration"
        $ruleEngineForwardAction.RouteConfigurationOverride.CacheConfiguration.DynamicCompression | Should -Be "Disabled"
        $ruleEngineForwardAction.RouteConfigurationOverride.CacheConfiguration.QueryParameterStripDirective | Should -Be "StripNone"
        $ruleEngineForwardAction.RouteConfigurationOverride.CacheConfiguration.QueryParameter | Should -Be $null
        $ruleEngineForwardAction.RouteConfigurationOverride.CacheConfiguration.CacheDuration | Should -Be $null
    }
    It 'RedirectParameterSet' -skip {
        $ruleEngineRedirectAction = New-AzFrontDoorRulesEngineActionObject -RedirectProtocol "MatchRequest" -CustomHost "www.contoso.com" -RedirectType "Moved"
        $ruleEngineRedirectAction.RouteConfigurationOverride.RedirectProtocol | Should -Be "MatchRequest"
        $ruleEngineRedirectAction.RouteConfigurationOverride.RedirectType | Should -Be "Moved"
        $ruleEngineRedirectAction.RouteConfigurationOverride.CustomHost | Should -Be "www.contoso.com"
        $ruleEngineRedirectAction.RouteConfigurationOverride.CustomPath | Should -Be ""
        $ruleEngineRedirectAction.RouteConfigurationOverride.CustomFragment | Should -Be $null
    }
}
