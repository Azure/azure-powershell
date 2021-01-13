$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzADB2CTenant.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzADB2CTenant' {
    It 'CreateExpanded' {
        {
            New-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName02  -Location 'United States' -Sku Standard -CountryCode US -DisplayName $env.tenantName02 
        } | Should -Not -Throw
    }
}
