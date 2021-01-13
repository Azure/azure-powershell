$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADB2CTenant.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzADB2CTenant' {
    It 'Delete' {
        Remove-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName01
        $tenantList = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup
        $tenantList.Name | Should -Not -Contain $env.tenantName01
    }

    It 'DeleteViaIdentity' {
        $tenant = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName02
        Remove-AzADB2CTenant -InputObject $tenant
        $tenantList = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup
        $tenantList.Name | Should -Not -Contain $env.tenantName02
    }
}
