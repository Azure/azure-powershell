if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnSecurityPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnSecurityPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnSecurityPolicy'  {
    BeforeAll {
        $subId = $env.SubscriptionId

        $endpointName = 'end-pstest010'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $policyName = "pol-psName010"
        Write-Host -ForegroundColor Green "Use policyName : $($policyName)"

        $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
        -WafPolicyId "/subscriptions/$subId/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter -SubscriptionId $subId
    }

    It 'List' {
        $policies = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $subId
        $policies.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $policy = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
        $policy.Name | Should -Be $policyName
    }

    It 'GetViaIdentity' {
        $policyObject = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
        $policy = Get-AzFrontDoorCdnSecurityPolicy -InputObject $policyObject

        $policy.Name | Should -Be $policyName
        Remove-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
    }
}
