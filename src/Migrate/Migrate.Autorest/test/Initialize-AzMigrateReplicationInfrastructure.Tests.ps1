$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Initialize-AzMigrateReplicationInfrastructure.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Initialize-AzMigrateReplicationInfrastructure' -Tag 'LiveOnly' {
    It 'Default' {
        $response = Initialize-AzMigrateReplicationInfrastructure -ProjectName $env.srsinitinfraProjectName -ResourceGroupName $env.srsinitinfraResourceGroupName -Scenario $env.srsinitinfraScenario -TargetRegion $env.srsinitinfraTargetRegion
        $response[$response.length -1] | Should -Be $true
    }
}