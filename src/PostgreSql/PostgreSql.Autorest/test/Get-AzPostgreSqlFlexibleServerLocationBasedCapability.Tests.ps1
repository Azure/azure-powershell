$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerLocationBasedCapability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlFlexibleServerLocationBasedCapability' {
    It 'Get' {
        {
            $Result = Get-AzPostgreSqlFlexibleServerLocationBasedCapability -Location eastus2euap
            $Result.Length | Should -BeGreaterThan 0 
        } | Should -Not -Throw
    }
}
