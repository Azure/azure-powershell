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

Describe 'Get-AzFrontDoorCdnSecurityPolicy' {
    BeforeAll {
        $script:endpointName = 'e-clipstest-sp-get'
        $script:policyName = 'pol-psName-get'
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $script:endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @('/*') -Domain @(@{'Id'=$endpoint.Id})
        $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject -Association $association -WafPolicyId "/subscriptions/$($env.SubscriptionId)/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"
        New-AzFrontDoorCdnSecurityPolicy -Name $script:policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnEndpoint -EndpointName $script:endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $ps = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $ps.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $p = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:policyName
        $p.Name | Should -Be $script:policyName
    }

    It 'GetViaIdentity' {
        $p = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:policyName
        $p2 = Get-AzFrontDoorCdnSecurityPolicy -InputObject $p
        $p2.Name | Should -Be $script:policyName
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
