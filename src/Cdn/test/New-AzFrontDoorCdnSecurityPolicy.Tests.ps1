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

Describe 'New-AzFrontDoorCdnSecurityPolicy' -Tag 'LiveOnly' {
    It 'CreateExpanded'  {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        try
        {
            Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
            New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

            $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

            $profileSku = "Standard_AzureFrontDoor";
            $frontDoorCdnProfile = New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

            $endpointName = 'end-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
            $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

            $policyName = "pol-" + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use policyName : $($policyName)"

            $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
            $parameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
            -WafPolicyId "/subscriptions/4d894474-aa7f-4611-b830-344860c3eb9c/resourcegroups/powershelltest/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/powershelltestwaf"

            New-AzFrontDoorCdnSecurityPolicy -Name $policyName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Parameter $parameter
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}
