$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareAddonSrmPropertiesObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareAddonSrmPropertiesObject' {
    It '__AllParameterSets' {
        {
            $config = New-AzVMwareAddonSrmPropertiesObject  -AddonType SRM -LicenseKey "LicenseKeyValue"
            $config.AddonType | Should -Be "SRM"
        } | Should -Not -Throw
    }
}
