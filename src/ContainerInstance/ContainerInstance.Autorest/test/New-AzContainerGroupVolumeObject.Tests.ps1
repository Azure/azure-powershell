$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerGroupVolumeObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzContainerGroupVolumeObject' {
    It '__AllParameterSets' {
        {
            New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force)
        } | Should -Not -Throw
    }
}
