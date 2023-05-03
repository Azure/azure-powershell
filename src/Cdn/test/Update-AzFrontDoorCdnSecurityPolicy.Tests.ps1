if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnSecurityPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnSecurityPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnSecurityPolicy'  {
    BeforeAll {
        $subId = $env.SubscriptionId

        # $endpointName = 'end-' + (RandomString -allChars $false -len 6);
        # Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        # $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        # $policyName = "pol-" + (RandomString -allChars $false -len 6);
        # Write-Host -ForegroundColor Green "Use policyName : $($policyName)"

        # $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        # $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
        # -WafPolicyId "/subscriptions/$subId/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        # New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
    
        # $updateAssociation = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        # $updateParameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  @($updateAssociation, $updateAssociation2) `
        #     -WafPolicyId "/subscriptions/$subId/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"
    }

    It 'PatchExpanded' -skip {
        $PSDefaultParameterValues['Disabled'] = $true
        Update-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName `
            -Parameter $updateParameter

        # Remove security policy for other tests
        Remove-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
    }

    It 'PatchViaIdentityExpanded' -skip {
        $PSDefaultParameterValues['Disabled'] = $true

        New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName `
            | Update-AzFrontDoorCdnSecurityPolicy -Parameter $updateParameter
    }
}
