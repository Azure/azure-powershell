if (($null -eq $TestName) -or ($TestName -contains 'AzChaosTarget')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzChaosTarget.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzChaosTarget' {
    It 'NewAzChaosTarget-CreateExpanded' {
        {
            $propertyTarget = @{"type" = "CertificateSubjectIssuer"; "subject" = "CN=example.subject" }
            $propertyTargetArr = @($propertyTarget)
            $identitiesTarget = @{"identities" = $propertyTargetArr }
            $config = New-AzChaosTarget -Name $env.targetName2 -ParentResourceName $env.virtualMachine2 -ResourceGroupName $env.resourceGroup -Location $env.location -Property $identitiesTarget -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Name | Should -Be $env.targetName2
        } | Should -Not -Throw
    }

    It 'GetAzChaosTarget-List' {
        {
            $config = Get-AzChaosTarget -ParentResourceName $env.virtualMachine2 -ResourceGroupName $env.resourceGroup -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosTarget-Get' {
        {
            $config = Get-AzChaosTarget -Name $env.targetName2 -ParentResourceName $env.virtualMachine2 -ResourceGroupName $env.resourceGroup -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Name | Should -Be $env.targetName2
        } | Should -Not -Throw
    }

    It 'GetAzChaosTargetType-List' {
        {
            $config = Get-AzChaosTargetType -LocationName $env.location
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosTargetType-Get' {
        {
            $config = Get-AzChaosTargetType -LocationName $env.location -Name Microsoft-KeyVault
            $config.Name | Should -Be "Microsoft-KeyVault"
        } | Should -Not -Throw
    }

    It 'UpdateAzChaosTarget-UpdateExpanded' {
        {
            $propertyTarget = @{"type" = "CertificateSubjectIssuer"; "subject" = "CN=example.subject" }
            $propertyTargetArr = @($propertyTarget)
            $identitiesTarget = @{"identities" = $propertyTargetArr }
            $config = Update-AzChaosTarget -Name $env.targetName2 -ParentResourceName $env.virtualMachine2 -ResourceGroupName $env.resourceGroup -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines -Location $env.location -Property $identitiesTarget
            $config.Name | Should -Be $env.targetName2
        } | Should -Not -Throw
    }

    It 'RemoveAzChaosTarget-Delete' {
        {
            Remove-AzChaosTarget -Name $env.targetName2 -ParentResourceName $env.virtualMachine2 -ResourceGroupName $env.resourceGroup -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
        } | Should -Not -Throw
    }
}
