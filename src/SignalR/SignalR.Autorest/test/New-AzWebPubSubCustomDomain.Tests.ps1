# This test requires a lot of preparation work such as creating a KeyVault resource, creating a cert, assigning the wps resource permissions to read the cert and secert in KeyVault, which is not related to the cmdlet test. Therefore, the setups are ignored here.

# To update the test recording with new API, you should prepare resources and update the constants.
# Detail steps:
# 1. Create a Web PubSub resource.
# 2. Ask the team for a usable KeyVault and DNS zone which they use for other custom domain e2e tests so that you don't need to create these resources again. See https://learn.microsoft.com/azure/azure-web-pubsub/howto-custom-domain for detailed steps on how to use these resources.
# 3. Update the constants.
# 4. Run PowerShell command ".\test-module.ps1 -Record -TestName New-AzWebPubSubCustomDomain" to update the record.

if(($null -eq $TestName) -or ($TestName -contains 'New-AzWebPubSubCustomDomain'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebPubSubCustomDomain.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWebPubSubCustomDomain' {
    It 'CreateExpanded' {
        $wpsName = 'ps-test-wps';
        $resourceGroup = 'ps-test-rg'
        $customCertName = 'pstest-customCert'
        $keyVaultBaseUri = 'https://kvcustomcertificatetest.vault.azure.net/'
        $keyVaultSecretName = 'manual-test'
        $customDomainResourceName = 'myDomain'
        $customDomainName = 'ps-test-wps.manual-test.dev.signalr.azure.com'

        # Test New-AzWebPubSubCustomCertificate CreateExpanded
        $customCert = New-AzWebPubSubCustomCertificate -Name $customCertName -ResourceName $wpsName -ResourceGroupName $resourceGroup -KeyVaultBaseUri $keyVaultBaseUri -KeyVaultSecretName $keyVaultSecretName
        $customCert.ProvisioningState | Should -Be "Succeeded"

        # Test Get-AzWebPubSubCustomCertificate List
        $customCerts = Get-AzWebPubSubCustomCertificate -ResourceName $wpsName -ResourceGroupName $resourceGroup
        $customCerts | Should -HaveCount 1
        $customCert = $customCerts[0]
        $customCert.KeyVaultBaseUri | Should -Be $keyVaultBaseUri
        $customCert.KeyVaultSecretName | Should -Be $keyVaultSecretName
        $customCert.ProvisioningState | Should -Be "Succeeded"

        # Test Get-AzWebPubSubCustomCertificate Get
        $customCert = Get-AzWebPubSubCustomCertificate -Name $customCertName -ResourceName $wpsName -ResourceGroupName $resourceGroup
        $customCert.KeyVaultBaseUri | Should -Be $keyVaultBaseUri
        $customCert.KeyVaultSecretName | Should -Be $keyVaultSecretName
        $customCert.ProvisioningState | Should -Be "Succeeded"

        # Test Get-AzWebPubSubCustomCertificate GetViaIdentity
        $customCertViaIdentity = Get-AzWebPubSubCustomCertificate -InputObject $customCert
        $customCertViaIdentity.KeyVaultBaseUri | Should -Be $keyVaultBaseUri
        $customCertViaIdentity.KeyVaultSecretName | Should -Be $keyVaultSecretName
        $customCertViaIdentity.ProvisioningState | Should -Be "Succeeded"

        # Test New-AzWebPubSubCustomDomain
        { New-AzWebPubSubCustomDomain -Name $customDomainResourceName -ResourceGroupName $resourceGroup -ResourceName $wpsName -DomainName $customDomainName -CustomCertificateId $customCert.Id } | Should -Not -Throw

        # Test Get-AzWebPubSubCustomDomain List
        $customDomainResources = Get-AzWebPubSubCustomDomain -ResourceGroupName $resourceGroup -ResourceName $wpsName
        $customDomainResources | Should -HaveCount 1
        $customDomainResource = $customDomainResources[0]
        $customDomainResource.Name | Should -Be $customDomainResourceName
        $customDomainResource.CustomCertificateId | Should -Be $customCert.Id
        $customDomainResource.DomainName | Should -Be $customDomainName

        # Test Get-AzWebPubSubCustomDomain Get
        $customDomainResource = Get-AzWebPubSubCustomDomain -ResourceGroupName $resourceGroup -ResourceName $wpsName -Name $customDomainResourceName
        $customDomainResource.Name | Should -Be $customDomainResourceName
        $customDomainResource.CustomCertificateId | Should -Be $customCert.Id
        $customDomainResource.DomainName | Should -Be $customDomainName

        # Test Get-AzWebPubSubCustomDomain GetViaIdentity
        $customDomainResourceViaIdentity = Get-AzWebPubSubCustomDomain -InputObject $customDomainResource
        $customDomainResourceViaIdentity.Name | Should -Be $customDomainResourceName
        $customDomainResourceViaIdentity.CustomCertificateId | Should -Be $customCert.Id
        $customDomainResourceViaIdentity.DomainName | Should -Be $customDomainName

        # Remove-AzWebPubSubCustomDomain Delete (Default)
        Remove-AzWebPubSubCustomDomain -Name $customDomainResourceName -ResourceGroupName $resourceGroup -ResourceName $wpsName
        Get-AzWebPubSubCustomDomain -ResourceGroupName $resourceGroup -ResourceName $wpsName | Should -HaveCount 0

        # Remove-AzWebPubSubCustomDomain DeleteViaIdentity
        $customDomainResource = New-AzWebPubSubCustomDomain -Name $customDomainResourceName -ResourceGroupName $resourceGroup -ResourceName $wpsName -DomainName $customDomainName -CustomCertificateId $customCert.Id
        Remove-AzWebPubSubCustomDomain -InputObject $customDomainResource
        Get-AzWebPubSubCustomDomain -ResourceGroupName $resourceGroup -ResourceName $wpsName | Should -HaveCount 0

        # Remove-AzWebPubSubCustomCertificate Delete (Default)
        Remove-AzWebPubSubCustomCertificate -Name $customCertName -ResourceGroupName $resourceGroup -ResourceName $wpsName
        Get-AzWebPubSubCustomCertificate -ResourceName $wpsName -ResourceGroupName $resourceGroup | Should -HaveCount 0

        # Remove-AzWebPubSubCustomCertificate DeleteViaIdentity
        $customCert = New-AzWebPubSubCustomCertificate -Name $customCertName -ResourceName $wpsName -ResourceGroupName $resourceGroup -KeyVaultBaseUri $keyVaultBaseUri -KeyVaultSecretName $keyVaultSecretName
        Remove-AzWebPubSubCustomCertificate -InputObject $customCert
        Get-AzWebPubSubCustomCertificate -ResourceName $wpsName -ResourceGroupName $resourceGroup | Should -HaveCount 0
    }
}
