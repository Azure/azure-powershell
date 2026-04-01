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

Describe 'New-AzFrontDoorCdnSecurityPolicy' {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $endpointName = 'e-clipstest060'
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $policyName = "pol-psName020"
        Write-Host -ForegroundColor Green "New SecurityPolicy: $($policyName)"

        $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject -Association $association `
            -WafPolicyId "/subscriptions/$subId/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        # New
        $policy = New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        $policy.Name | Should -Be $policyName

        # Get - List / by name / ViaIdentity
        $policies = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $policies.Count | Should -BeGreaterOrEqual 1
        $getPolicy = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
        $getPolicy.Name | Should -Be $policyName
        $getPolicy2 = Get-AzFrontDoorCdnSecurityPolicy -InputObject $getPolicy
        $getPolicy2.Name | Should -Be $policyName

        # Remove
        Write-Host -ForegroundColor Green "Remove SecurityPolicy: $($policyName)"
        Remove-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
    }
}
