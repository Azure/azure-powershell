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

        $endpointName = 'end-pstest110'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $policyName = "pol-psName040"
        Write-Host -ForegroundColor Green "Use policyName : $($policyName)"

        $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
            -WafPolicyId "/subscriptions/$subId/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter -SubscriptionId $subId
    }

    It 'PatchExpanded' -Skip {
        $endpointName2 = 'end-pstest111'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName2)"
        $endpoint2 = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName2 -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $updateAssociation = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        $updateAssociation2 = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint2.Id)})            
        $updateParameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  @($updateAssociation, $updateAssociation2) `
        -WafPolicyId "/subscriptions/$subid/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        Update-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName `
        -Parameter $updateParameter
    }

    It 'PatchViaIdentityExpanded' -Skip {
        $endpointName2 = 'end-pstest112'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName2)"
        $endpoint2 = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName2 -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $updateAssociation = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
        $updateAssociation2 = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint2.Id)})            
        $updateParameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  @($updateAssociation, $updateAssociation2) `
        -WafPolicyId "/subscriptions/$subid/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

        $securityObject = Get-AzFrontDoorCdnSecurityPolicy -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $policyName
        Update-AzFrontDoorCdnSecurityPolicy -Parameter $updateParameter -InputObject $securityObject
    }
}
