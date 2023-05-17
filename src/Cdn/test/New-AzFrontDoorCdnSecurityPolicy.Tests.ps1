if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnSecurityPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnSecurityPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnSecurityPolicy'  {
    It 'CreateExpanded'  {
        $subId = $env.SubscriptionId
        Write-Host -ForegroundColor Green "Use subscriptionId : $($subId)"

        $endpointName = 'end-pstest060'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $policyName = "pol-psName020"
        Write-Host -ForegroundColor Green "Use policyName : $($policyName)"

        $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
        -WafPolicyId "/subscriptions/$subId/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        
        # Remove security policy for other tests
        Remove-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
    }
}
