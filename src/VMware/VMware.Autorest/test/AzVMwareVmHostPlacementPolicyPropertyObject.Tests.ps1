$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareVmHostPlacementPolicyPropertyObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareVmHostPlacementPolicyPropertyObject' {
    It '__AllParameterSets' {
        {
            $config = New-AzVMwareVmHostPlacementPolicyPropertyObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"} -VMMember @{"test"="test"}
            $config.AffinityType | Should -Be "AntiAffinity"
        } | Should -Not -Throw
    }
}
