# Minimal playback test for Get-AzOracleResourceAnchor

if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleResourceAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleResourceAnchor.Recording.json'

    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleResourceAnchor' {

    It 'Get by name and resource group' {
        {
            $ra = Get-AzOracleResourceAnchor -Name $env.resourceAnchorName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.SubscriptionId
            $ra | Should -Not -BeNullOrEmpty
            $ra.Name | Should -Be $env.resourceAnchorName
        } | Should -Not -Throw
    }

    It 'List in subscription' {
        {
            $list = Get-AzOracleResourceAnchor -SubscriptionId $env.SubscriptionId
            $list.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
