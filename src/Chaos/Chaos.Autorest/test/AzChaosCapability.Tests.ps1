if (($null -eq $TestName) -or ($TestName -contains 'AzChaosCapability')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzChaosCapability.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzChaosCapability' {
    It 'NewAzChaosCapability-CreateExpanded' {
        {
            $config = New-AzChaosCapability -Name Shutdown-1.0 -ResourceGroupName $env.resourceGroup -TargetName $env.targetName2 -ParentResourceName $env.virtualMachine2 -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Name | Should -Be "Shutdown-1.0"
        } | Should -Not -Throw
    }

    It 'GetAzChaosCapability-List' {
        {
            $config = Get-AzChaosCapability -ResourceGroupName $env.resourceGroup -TargetName $env.targetName2 -ParentResourceName $env.virtualMachine2 -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosCapability-Get' {
        {
            $config = Get-AzChaosCapability -Name Shutdown-1.0 -ResourceGroupName $env.resourceGroup -TargetName $env.targetName2 -ParentResourceName $env.virtualMachine2 -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Name | Should -Be "Shutdown-1.0"
        } | Should -Not -Throw
    }

    It 'GetAzChaosCapabilityType-List' {
        {
            $config = Get-AzChaosCapabilityType -LocationName $env.location -TargetTypeName $env.targetName2
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosCapabilityType-Get' {
        {
            $config = Get-AzChaosCapabilityType -LocationName $env.location -TargetTypeName $env.targetName2 -Name Shutdown-1.0
            $config.Name | Should -Be "Shutdown-1.0"
        } | Should -Not -Throw
    }

    It 'UpdateAzChaosCapability-UpdateExpanded' {
        {
            $config = Update-AzChaosCapability -Name Shutdown-1.0 -ResourceGroupName $env.resourceGroup -TargetName $env.targetName2 -ParentResourceName $env.virtualMachine2 -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
            $config.Name | Should -Be "Shutdown-1.0"
        } | Should -Not -Throw
    }

    It 'RemoveAzChaosCapability-Delete' {
        {
            Remove-AzChaosCapability -Name Shutdown-1.0 -ResourceGroupName $env.resourceGroup -TargetName $env.targetName2 -ParentResourceName $env.virtualMachine2 -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines
        } | Should -Not -Throw
    }
}
