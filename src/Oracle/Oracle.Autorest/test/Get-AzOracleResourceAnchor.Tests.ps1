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
    # Vars (ENV overrides first; keep defaults in sync with your Create test)
    $raName = if ($env:RESOURCE_ANCHOR_NAME) { $env:RESOURCE_ANCHOR_NAME } else { 'Create' }
    $rgName = if ($env:resourceGroup)       { $env:resourceGroup }       else { 'basedb-rg929-ti-iad52' }
    $subId  = if ($env:SubscriptionId)      { $env:SubscriptionId }      else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    It 'Get by name and resource group' {
        {
            $ra = Get-AzOracleResourceAnchor -Name $raName -ResourceGroupName $rgName -SubscriptionId $subId
            $ra | Should -Not -BeNullOrEmpty
            $ra.Name | Should -Be $raName
        } | Should -Not -Throw
    }

    It 'List in subscription' {
        {
            $list = Get-AzOracleResourceAnchor -SubscriptionId $subId
            $list.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
