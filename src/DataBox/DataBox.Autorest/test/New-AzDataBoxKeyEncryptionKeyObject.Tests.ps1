$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataBoxKeyEncryptionKeyObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataBoxKeyEncryptionKeyObject' {
    It '__AllParameterSets' {
        $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = $env.UserAssignedResourceId} -KekUrl $env.KekUrl -KekVaultResourceId $env.KekVaultResourceId
        $keyEncryptionDetails.KekVaultResourceId | Should -Be $env.KekVaultResourceId
    }
}
