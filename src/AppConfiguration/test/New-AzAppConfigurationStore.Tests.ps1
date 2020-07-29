$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppConfigurationStore.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzAppConfigurationStore' {
    It 'CreateExpanded' {
        New-AzAppConfigurationStore -Name $env.appconfName02 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "standard"
        $appConf = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup -Name $env.appconfName02
        
        $appConf.ProvisioningState | Should -Be "Succeeded"

        Remove-AzAppConfigurationStore -InputObject $appConf
    }
    It 'CreateWithIdentityTypeUserAssigned' {
        $appConf = New-AzAppConfigurationStore -Name $env.appconfName03 -ResourceGroupName $env.resourceGroup `
        -Location $env.location -Sku "standard" `
        -IdentityType "UserAssigned" -UserAssignedIdentity $env.assignedIdentityId

        $appConf.IdentityType | Should -Be "UserAssigned"
        $appConf.IdentityUserAssignedIdentity.Count | Should -BeGreaterThan 0
        $appConf.ProvisioningState | Should -Be "Succeeded"

        Remove-AzAppConfigurationStore -InputObject $appConf
    }
    It 'CreateWithIdentityTypeSystemAssigned' {
        $appConf = New-AzAppConfigurationStore -Name $env.appconfName04 -ResourceGroupName $env.resourceGroup `
        -Location $env.location -Sku "standard" `
        -IdentityType "SystemAssigned"

        $appConf.IdentityType | Should -Be "SystemAssigned"
        $appConf.IdentityPrincipalId | Should -BeTrue
        $appConf.IdentityTenantId | Should -BeTrue
        $appConf.IdentityUserAssignedIdentity.Count | Should -Be 0
        $appConf.ProvisioningState | Should -Be "Succeeded"

        Remove-AzAppConfigurationStore -InputObject $appConf
    }
    It 'CreateWithIdentityTypeSystemAssigned' {
        $appConf = New-AzAppConfigurationStore -Name $env.appconfName05 -ResourceGroupName $env.resourceGroup `
        -Location $env.location -Sku "standard" `
        -IdentityType "SystemAssignedAndUserAssigned" -UserAssignedIdentity $env.assignedIdentityId

        $appConf.IdentityType | Should -Be "SystemAssigned, UserAssigned"
        $appConf.IdentityPrincipalId | Should -BeTrue
        $appConf.IdentityTenantId | Should -BeTrue
        $appConf.IdentityUserAssignedIdentity.Count | Should -BeGreaterThan 0
        $appConf.ProvisioningState | Should -Be "Succeeded"

        Remove-AzAppConfigurationStore -InputObject $appConf
    }
}
