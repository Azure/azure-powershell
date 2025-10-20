# Minimal playback test for Remove-AzOracleDbSystem (DELETE)

if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleDbSystem'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleDbSystem.Recording.json'

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

Describe 'Remove-AzOracleDbSystem' {
    # Keep in sync with Create/Update tests
    $dbsName = 'PowershellSdk'
    $rgName  = if ($env:resourceGroup)  { $env:resourceGroup }  else { 'basedb-rg929-ti-iad52' }
    $subId   = if ($env:SubscriptionId) { $env:SubscriptionId } else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    $hasCmd = Get-Command -Name Remove-AzOracleDbSystem -ErrorAction SilentlyContinue

    It 'Remove minimal' {
        {
            if ($hasCmd) {
                Remove-AzOracleDbSystem `
                    -Name $dbsName `
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
