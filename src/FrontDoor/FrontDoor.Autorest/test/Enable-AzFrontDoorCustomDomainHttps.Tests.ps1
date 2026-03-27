if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzFrontDoorCustomDomainHttps'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzFrontDoorCustomDomainHttps.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzFrontDoorCustomDomainHttps' {
    It 'EnableExpanded' -skip {
        # need to clean dns zone record before running this test
        $PrefixName = "pwshenable-7"
        $FrontDoorName = "pwshenable7"
        $tags = @{"tag1" = "value1"; "tag2" = "value2"}
        $hostName = "$FrontDoorName.azurefd.net"
        $customDomainHostName = "$PrefixName.afdxe2e.azfdtest.xyz"
        $customFrontendEndpointName = "frontendendpoint2"

        $keyVaultName = "/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/afdxe2etest/providers/Microsoft.KeyVault/vaults/afdportal-e2e-test-kv"  # Replace with actual Key Vault
        $secretName = "wildcard-afdxe2e-azfdtest-xyz2"  

        $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $FrontDoorName -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
        $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" 
        $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
        $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
        $frontendEndpoint2 = New-AzFrontDoorFrontendEndpointObject -Name $customFrontendEndpointName -HostName $customDomainHostName
        $frontendEndpoints = $frontendEndpoint1, $frontendEndpoint2
        $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $FrontDoorName -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"

        New-AzFrontDoor -Name $FrontDoorName -ResourceGroupName $env.ResourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoints -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
      
        Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName $env.ResourceGroupName -FrontDoorName $FrontDoorName -FrontendEndpointName $customFrontendEndpointName -MinimumTlsVersion "1.2" -VaultId $keyVaultName -SecretName $secretName
    }

    It 'EnableViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Enable' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityFrontDoorExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityFrontDoor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

Describe 'Disable-AzFrontDoorCustomDomainHttps' {
    It 'Disable' -skip {
        $FrontDoorName = "pwshv4test"
        $customFrontendEndpointName = "frontendendpoint2"

        Disable-AzFrontDoorCustomDomainHttps -ResourceGroupName $env.ResourceGroupName -FrontDoorName $FrontDoorName -FrontendEndpointName $customFrontendEndpointName
    }

    It 'DisableViaIdentityFrontDoor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
