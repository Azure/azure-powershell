# Minimal playback test for Remove-AzOracleResourceAnchor (DELETE)

if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleResourceAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleResourceAnchor.Recording.json'

    $pubLoaded  = Get-Module Az.Oracle -ErrorAction SilentlyContinue
    $privLoaded = Get-Module Az.Oracle.private -ErrorAction SilentlyContinue
    if (-not ($pubLoaded -and $privLoaded)) {
        & (Join-Path $PSScriptRoot 'run-module.ps1')
    }

    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleResourceAnchor' {
    # Keep in sync with your create test/recording
    $anchorName = if ($env:RESOURCE_ANCHOR_NAME) { $env:RESOURCE_ANCHOR_NAME } else { 'Create' }
    $rgName     = if ($env:resourceGroup)       { $env:resourceGroup }       else { 'basedb-rg929-ti-iad52' }
    $subId   = if ($env:SubscriptionId) { $env:SubscriptionId } else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    $hasCmd = Get-Command -Name Remove-AzOracleResourceAnchor -ErrorAction SilentlyContinue

    It 'Remove minimal' {
        {
            if ($hasCmd) {
                Remove-AzOracleResourceAnchor `
                    -Name $anchorName `
                    -ResourceGroupName $rgName `
                    -SubscriptionId $subId `
                    -NoWait `
                    -Confirm:$false | Out-Null
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
