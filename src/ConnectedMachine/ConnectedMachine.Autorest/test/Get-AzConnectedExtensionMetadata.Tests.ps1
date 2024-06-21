$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedExtensionMetadata.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConnectedExtensionMetadata' {
    It 'List' {
        $all = @(Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Publisher 'Microsoft.Compute' -Location 'centraluseuap')
        $all | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $all = @(Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Publisher 'Microsoft.Compute' -Location $env.Location -Version '1.10.10')
        $all | Should -Not -BeNullOrEmpty
    }
}
