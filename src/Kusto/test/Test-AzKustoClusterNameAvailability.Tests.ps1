$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoClusterNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzKustoClusterNameAvailability' {
    It 'CheckExpanded' {
        $clusterName = $env.clusterName
        $location = $env.location
        $resourceType = $env.resourceType

        $testResult = Test-AzKustoClusterNameAvailability -Name $clusterName -Location $location -Type $resourceType
        $testResult.Message | Should -Be "Name '$clusterName' with type Engine is already taken. Please specify a different name"
    }
}
