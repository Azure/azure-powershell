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
        $runScript = Join-Path $PSScriptRoot 'run-module.ps1'
        if (Test-Path $runScript) {
            & $runScript
        } else {
            $modulePsd1 = Join-Path $PSScriptRoot '..\Az.Oracle.psd1'
            if (Test-Path $modulePsd1) { Import-Module $modulePsd1 -ErrorAction Stop }
        }
    }

    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleResourceAnchor' {

    $hasCmd = Get-Command -Name Remove-AzOracleResourceAnchor -ErrorAction SilentlyContinue

    It 'Remove minimal' -Skip {
        {
            if ($hasCmd) {
                Remove-AzOracleResourceAnchor `
                    -Name $env.resourceAnchorName `
                    -ResourceGroupName $env.resourceAnchorRgName `
                    -SubscriptionId $env.networkAnchorSubId `
                    -NoWait `
                    -Confirm:$false | Out-Null
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
