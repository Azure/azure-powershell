if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorRoutingRuleObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorRoutingRuleObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorRoutingRuleObject' {
    It 'ForwardingParameterSet' -skip {
        $FDName = $env.FrontDoorName
        $resourceGroupName = $env.ResourceGroupName
        $subId = $env.SubscriptionId
        $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $FDName -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
        $routingrule1.Name | Should -Be "routingrule1"
        $routingrule1.FrontendEndpoint[0].id | Should -Be "/subscriptions/$subId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/frontDoors/$FDName/FrontendEndpoints/frontendEndpoint1"
        $routingrule1.AcceptedProtocol | Should -Be @("Http", "Https")
        $routingrule1.PatternsToMatch | Should -Be @("/*")
        $routingrule1.RouteConfiguration.GetType() | Should -Be "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ForwardingConfiguration"
        $routingrule1.RouteConfiguration.BackendPoolId | Should -Be "/subscriptions/$subId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/frontDoors/$FDName/BackendPools/backendPool1"
        $routingrule1.RouteConfiguration.CustomForwardingPath | Should -Be $null
        $routingrule1.RouteConfiguration.ForwardingProtocol | Should -Be "MatchRequest"
    }

    It 'RedirectParameterSet' -skip {
        $FDName = $env.FrontDoorName
        $resourceGroupName = $env.ResourceGroupName
        $subId = $env.SubscriptionId
        $routingrule2 = New-AzFrontDoorRoutingRuleObject -Name "routingrule2" -FrontDoorName $FDName -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -CustomFragment "#fragment"
        $routingrule2.Name | Should -Be "routingrule2"
        $routingrule2.FrontendEndpoint[0].id | Should -Be "/subscriptions/$subId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/frontDoors/$FDName/FrontendEndpoints/frontendEndpoint1"
        $routingrule2.AcceptedProtocol | Should -Be @("Http", "Https")
        $routingrule2.PatternsToMatch | Should -Be @("/*")
        $routingrule2.RouteConfiguration.GetType() | Should -Be "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RedirectConfiguration"
        $routingrule2.RouteConfiguration.RedirectProtocol | Should -Be "MatchRequest"
        $routingrule2.RouteConfiguration.RedirectType | Should -Be "Moved"
        $routingrule2.RouteConfiguration.CustomFragment | Should -Be "#fragment"
        $routingrule2.RouteConfiguration.CustomHost | Should -Be ""
        $routingrule2.RouteConfiguration.CustomPath | Should -Be ""
    }
}
