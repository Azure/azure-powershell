$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareAddonHcxPropertiesObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareAddonHcxPropertiesObject' {
    It '__AllParameterSets' {
        {
            $config = New-AzVMwareAddonHcxPropertiesObject -AddonType HCX -Offer "OfferValue"
            $config.AddonType | Should -Be "HCX"
        } | Should -Not -Throw
    }
}
