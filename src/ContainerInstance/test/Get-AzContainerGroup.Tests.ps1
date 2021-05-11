$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzContainerGroup' {
    It 'List' {
        {
            Get-AzContainerGroup
        } | Should -Not -Throw
    }

    It 'Get' {
        Get-AzContainerGroup -Name $env.containerGroupName -ResourceGroupName $env.resourceGroupName
    }

    It 'List1' {
        Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName
    }

    It 'GetViaIdentity' {
        Update-AzContainerGroup -Name $env.containerGroupName -ResourceGroupName $env.resourceGroupName -Tag @{"key"="value"} | Get-AzContainerGroup
    }
}
