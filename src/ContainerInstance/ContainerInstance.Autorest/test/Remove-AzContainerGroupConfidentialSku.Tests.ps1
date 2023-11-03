$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzContainerGroupConfidentialSku.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzContainerGroupConfidentialSku' {
    It 'Delete' {
        Remove-AzContainerGroup -Name "$($env.confidentialContainerGroupName)-remove1" -ResourceGroupName $env.resourceGroupName
    }

    It 'DeleteViaIdentity' {
        $remove = Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.confidentialContainerGroupName)-remove2"
        Remove-AzContainerGroup -InputObject $remove
    }
}
