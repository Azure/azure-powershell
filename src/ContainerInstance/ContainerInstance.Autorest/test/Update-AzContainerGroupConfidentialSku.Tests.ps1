$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzContainerGroupConfidentialSku.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzContainerGroupConfidentialSku' {
    It 'UpdateExpanded' {
        Update-AzContainerGroup -Name $env.confidentialContainerGroupName -ResourceGroupName $env.resourceGroupName -Tag @{"test"="value"}
    }

    It 'UpdateViaIdentityExpanded' {
        $update = Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.confidentialContainerGroupName
        Update-AzContainerGroup -InputObject $update -Tag @{"test"="value"}
    }
}
