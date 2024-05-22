$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareVmHostPlacementPolicyPropertieObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareVmHostPlacementPolicyPropertieObject' {
    It '__AllParameterSets' {
        {
            $config = New-AzVMwareVmHostPlacementPolicyPropertieObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"} -VMMember @{"test"="test"}
            $config.AffinityType | Should -Be "AntiAffinity"
        } | Should -Not -Throw
    }
}
