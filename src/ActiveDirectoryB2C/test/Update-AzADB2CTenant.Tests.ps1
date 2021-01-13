$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzADB2CTenant.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzADB2CTenant' {
    It 'UpdateExpanded' {
        $tenant = Update-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName00 -Tag @{"key1" = 1; "key2" = 2; "key3" = 3}
        $tenant.Tag.Count | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded' {
      $tenant = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName00 
      $tenant = Update-AzADB2CTenant -InputObject $tenant -Tag @{"key1" = 1}
      $tenant.Tag.Count | Should -Be 1 
    }
}
