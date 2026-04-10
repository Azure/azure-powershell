if(($null -eq $TestName) -or ($TestName -contains 'CredentialsAndPoliciesFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'CredentialsAndPoliciesFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

<#
.SYNOPSIS
    End-to-end flow test for DeviceRegistry Credentials, Policies, Namespace Devices,
    and BYOR (Bring Your Own Root) operations.

.DESCRIPTION
    Adapted from the JavaScript SDK test:
    azure-sdk-for-js/sdk/deviceregistry/arm-deviceregistry/test/public/deviceregistry_credentials_and_policies_flow_test.spec.ts

    PREREQUISITES (must exist before running in Live mode):
    - Resource Group, UAMI, ADR Namespace, IoT Hub, and DPS with ADR Integration.
    - Use the helper scripts:
        Setup:    .\tests\Scripts\Setup-CmsTestPrerequisites.ps1 -Suffix both -Iteration 1 -NoPrompt
        Teardown: .\tests\Scripts\Teardown-CmsTestPrerequisites.ps1 -Suffix both -Iteration 1 -Force
#>

Describe 'CredentialsAndPoliciesFlow' {

    BeforeAll {
        # Resource names — must match what the prerequisite scripts create.
        $iteration = "1"
        $suffix = "async$iteration"
        $script:namespaceName    = "cms-test-namespace-$suffix"
        $script:policyName       = "cms-test-policy-$suffix"
        $script:byorPolicyName   = "cms-test-byor-policy-$suffix"
        $script:deviceName       = "cms-test-device-$suffix"

        # CMS test-specific overrides (these differ from the standard test env)
        $script:resourceGroup    = "adr-sdk-test-cms-async1"
        $script:subscriptionId   = (Get-AzContext).Subscription.Id
        $script:location         = "eastus2euap"
    }

    # ============================================================
    # Standard Credential and Policy Flow
    # ============================================================

    It 'Step01 - Verify pre-created namespace exists' {
        $ns = Get-AzDeviceRegistryNamespace -ResourceGroupName $script:resourceGroup -Name $script:namespaceName -SubscriptionId $script:subscriptionId
        $ns | Should -Not -BeNullOrEmpty
        $ns.Name | Should -Be $script:namespaceName
    }

    It 'Step02 - Create credential' {
        # Check if credential already exists
        $existing = $null
        try {
            $existing = Get-AzDeviceRegistryCredentials -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -SubscriptionId $script:subscriptionId
        } catch {
            # Expected if not found
        }

        if ($null -eq $existing) {
            $cred = New-AzDeviceRegistryCredentials -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Location $script:location -SubscriptionId $script:subscriptionId
            $cred | Should -Not -BeNullOrEmpty
        } else {
            $existing | Should -Not -BeNullOrEmpty
        }
    }

    It 'Step03 - Clean up existing policies and create new policy' {
        # List and delete any existing policies (1 policy/credential limit)
        $existingPolicies = @(Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -SubscriptionId $script:subscriptionId)
        foreach ($p in $existingPolicies) {
            Remove-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $p.Name -SubscriptionId $script:subscriptionId
        }

        # Create policy with ECC certificate and 90-day validity (must use JsonString as KeyType is not exposed as a parameter)
        $policyJson = '{"properties":{"certificate":{"certificateAuthorityConfiguration":{"keyType":"ECC"},"leafCertificateConfiguration":{"validityPeriodInDays":90}}}}'
        $policy = New-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -Name $script:policyName `
            -JsonString $policyJson `
            -SubscriptionId $script:subscriptionId
        $policy | Should -Not -BeNullOrEmpty
        $policy.Name | Should -Be $script:policyName

        # Verify certificate configuration
        $policy.CertificateAuthorityConfigurationKeyType | Should -Be 'ECC'
        $policy.LeafCertificateConfigurationValidityPeriodInDay | Should -Be 90
        $policy.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'Step03b - List policies and verify policy exists' {
        $allPolicies = @(Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -SubscriptionId $script:subscriptionId)
        $allPolicies.Name | Should -Contain $script:policyName
    }

    It 'Step04 - Synchronize credentials with IoT Hub' {
        Sync-AzDeviceRegistryCredentials -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -SubscriptionId $script:subscriptionId
    }

    It 'Step05 - Get fresh policy after sync' {
        $policy = Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $script:policyName -SubscriptionId $script:subscriptionId
        $policy | Should -Not -BeNullOrEmpty
        $policy.LeafCertificateConfigurationValidityPeriodInDay | Should -Be 90
    }

    It 'Step06 - Update policy validity period from 90 to 60 days' {
        Update-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -Name $script:policyName `
            -LeafCertificateConfigurationValidityPeriodInDay 60 `
            -SubscriptionId $script:subscriptionId

        # Verify update
        $policy = Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $script:policyName -SubscriptionId $script:subscriptionId
        $policy.LeafCertificateConfigurationValidityPeriodInDay | Should -Be 60
    }

    # ============================================================
    # Namespace Device Operations
    # ============================================================

    It 'Step07 - Create device in CMS namespace' {
        $device = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -DeviceName $script:deviceName `
            -Location $script:location `
            -Manufacturer "Contoso" `
            -Model "CMS-TestModel-5000" `
            -OperatingSystem "Linux" `
            -OperatingSystemVersion "22.04" `
            -SubscriptionId $script:subscriptionId
        $device | Should -Not -BeNullOrEmpty
        $device.Name | Should -Be $script:deviceName
        $device.Manufacturer | Should -Be "Contoso"
        $device.Model | Should -Be "CMS-TestModel-5000"
    }

    It 'Step08 - Get device and verify properties' {
        $device = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -DeviceName $script:deviceName `
            -SubscriptionId $script:subscriptionId
        $device | Should -Not -BeNullOrEmpty
        $device.Manufacturer | Should -Be "Contoso"
        $device.Model | Should -Be "CMS-TestModel-5000"
        $device.OperatingSystem | Should -Be "Linux"
        $device.OperatingSystemVersion | Should -Be "22.04"

        # List devices in namespace
        $allDevices = @(Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -SubscriptionId $script:subscriptionId)
        $allDevices.Name | Should -Contain $script:deviceName
    }

    It 'Step09 - Revoke device credentials (ARM-created device, no policy - expect failure)' {
        # ARM-created devices have no policy attached, so revoke should fail.
        { Revoke-AzDeviceRegistryNamespaceDevice -ResourceGroupName $script:resourceGroup `
              -NamespaceName $script:namespaceName `
              -DeviceName $script:deviceName `
              -Disable:$false `
              -SubscriptionId $script:subscriptionId } | Should -Throw
    }

    It 'Step10 - Verify device state unchanged after failed revoke' {
        $device = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -DeviceName $script:deviceName `
            -SubscriptionId $script:subscriptionId
        $device | Should -Not -BeNullOrEmpty
        $device.Name | Should -Be $script:deviceName
    }

    It 'Step11 - Delete device' {
        Remove-AzDeviceRegistryNamespaceDevice -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -DeviceName $script:deviceName `
            -SubscriptionId $script:subscriptionId
    }

    It 'Step12 - Revoke issuer on standard policy' {
        # RevokeIssuer may fail if active device certificates still exist after sync.
        # This is expected RP behavior — treat both success and this specific error as valid.
        try {
            Revoke-AzDeviceRegistryPolicyIssuer -ResourceGroupName $script:resourceGroup `
                -NamespaceName $script:namespaceName `
                -PolicyName $script:policyName `
                -SubscriptionId $script:subscriptionId

            # Verify policy state after RevokeIssuer
            $policy = Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $script:policyName -SubscriptionId $script:subscriptionId
            $policy | Should -Not -BeNullOrEmpty
            $policy.ProvisioningState | Should -Be 'Succeeded'
        } catch {
            $_.Exception.Message | Should -BeLike '*active device certificates*'
        }
    }

    It 'Step13 - Delete standard policy' {
        Remove-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -Name $script:policyName `
            -SubscriptionId $script:subscriptionId
    }

    # ============================================================
    # BYOR (Bring Your Own Root) Policy Flow
    # ============================================================

    It 'Step14 - Create BYOR-enabled policy' {
        $byorPolicy = New-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -Name $script:byorPolicyName `
            -LeafCertificateConfigurationValidityPeriodInDay 90 `
            -BringYourOwnRootEnabled `
            -SubscriptionId $script:subscriptionId
        $byorPolicy | Should -Not -BeNullOrEmpty
        $byorPolicy.Name | Should -Be $script:byorPolicyName
        $byorPolicy.BringYourOwnRootEnabled | Should -Be $true
    }

    It 'Step15 - Verify BYOR PendingActivation status and CSR' {
        $byorPolicy = Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $script:byorPolicyName -SubscriptionId $script:subscriptionId
        $byorPolicy.BringYourOwnRootStatus | Should -Be 'PendingActivation'
        $byorPolicy.BringYourOwnRootCertificateSigningRequest | Should -Not -BeNullOrEmpty
        $byorPolicy.BringYourOwnRootCertificateSigningRequest | Should -BeLike '*-----BEGIN CERTIFICATE REQUEST-----*'
    }

    It 'Step16 - ActivateBYOR with invalid certificate (negative test)' {
        $fakeCertificateChain = @"
-----BEGIN CERTIFICATE-----
MIIBkTCB+wIJALRiMLAhFake0DQYJKoZIhvcNAQELBQAwDzENMAsGA1UEAwwEdGVz
dDAeFw0yNDAzMjAxMjAwMDBaFw0yNTAzMjAxMjAwMDBaMA8xDTALBgNVBAMMBHRl
c3QwXDANBgkqhkiG9w0BAQEFAANLADBIAkEA0Z3VS5JJcds3xf0GQGZ/fake+key
data+that+is+intentionally+invalid+for+testing+purposes+only+AAAAAAAAAA==
-----END CERTIFICATE-----
"@

        { Initialize-AzDeviceRegistryPolicyBringYourOwnRoot -ResourceGroupName $script:resourceGroup `
              -NamespaceName $script:namespaceName `
              -PolicyName $script:byorPolicyName `
              -CertificateChain $fakeCertificateChain `
              -SubscriptionId $script:subscriptionId } | Should -Throw
    }

    It 'Step17 - Verify BYOR state unchanged after failed activation' {
        $byorPolicy = Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $script:byorPolicyName -SubscriptionId $script:subscriptionId
        $byorPolicy.BringYourOwnRootEnabled | Should -Be $true
        $byorPolicy.BringYourOwnRootStatus | Should -Be 'PendingActivation'
        $byorPolicy.BringYourOwnRootCertificateSigningRequest | Should -Not -BeNullOrEmpty
    }

    It 'Step18 - Update BYOR policy validity period to 45 days' {
        Update-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -Name $script:byorPolicyName `
            -LeafCertificateConfigurationValidityPeriodInDay 45 `
            -SubscriptionId $script:subscriptionId

        # Verify update
        $byorPolicy = Get-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup -NamespaceName $script:namespaceName -Name $script:byorPolicyName -SubscriptionId $script:subscriptionId
        $byorPolicy.LeafCertificateConfigurationValidityPeriodInDay | Should -Be 45
        $byorPolicy.BringYourOwnRootEnabled | Should -Be $true
    }

    It 'Step19 - Delete BYOR policy' {
        Remove-AzDeviceRegistryPolicy -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -Name $script:byorPolicyName `
            -SubscriptionId $script:subscriptionId
    }

    It 'Step20 - Delete credential' {
        Remove-AzDeviceRegistryCredentials -ResourceGroupName $script:resourceGroup `
            -NamespaceName $script:namespaceName `
            -SubscriptionId $script:subscriptionId
    }
}
