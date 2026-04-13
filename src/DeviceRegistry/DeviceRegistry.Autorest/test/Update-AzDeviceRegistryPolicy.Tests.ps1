if (($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryPolicy')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryPolicy.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryPolicy' {

    It 'UpdateExpanded' {
        $policyTestParams = $env.policyTests.updateTests.UpdateExpanded
        
        Update-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -LeafCertificateConfigurationValidityPeriodInDay 60
            
        $policy = Get-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }

    It 'UpdateViaJsonString' -skip {
        $policyTestParams = $env.policyTests.updateTests.UpdateViaJsonString
        $jsonFilePath = (Join-Path $PSScriptRoot $policyTestParams.updateJsonFilePath)
        $jsonString = Get-Content -Path $jsonFilePath -Raw
        
        $policy = Update-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -JsonString $jsonString
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }

    It 'UpdateViaJsonFilePath' -skip {
        $policyTestParams = $env.policyTests.updateTests.UpdateViaJsonFilePath
        $jsonFilePath = (Join-Path $PSScriptRoot $policyTestParams.updateJsonFilePath)
        
        $policy = Update-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -JsonFilePath $jsonFilePath
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }

    It 'UpdateViaIdentity' -skip {
        $policyTestParams = $env.policyTests.updateTests.UpdateViaIdentity
        $policyUpdateJson = @"
{
    "properties": {
        "certificate": {
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 60
            }
        }
    }
}
"@
        
        $policy = Get-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        $updatedPolicy = Update-AzDeviceRegistryPolicy `
            -InputObject $policy `
            -JsonString $policyUpdateJson
        
        $updatedPolicy.Name | Should -Be $policyTestParams.policyName
        $updatedPolicy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }
}
