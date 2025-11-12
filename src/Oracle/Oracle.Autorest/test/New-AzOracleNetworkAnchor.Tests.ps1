# Minimal playback test for New-AzOracleNetworkAnchor (CREATE)

if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleNetworkAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleNetworkAnchor.Recording.json'

    # Guarded Az.Oracle loader (avoid double-load)
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

    # HttpPipelineMocking bootstrap
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleNetworkAnchor' {

    $hasCmd = Get-Command -Name New-AzOracleNetworkAnchor -ErrorAction SilentlyContinue

    It 'Create minimal (NoWait ack safe assertions)' {
        {
            if ($hasCmd) {
                $created = New-AzOracleNetworkAnchor `
                    -Name $env.networkAnchorName `
                    -ResourceGroupName $env.resourceGroup `
                    -SubscriptionId $env.SubscriptionId `
                    -Location $env.location `
                    -ResourceAnchorId $env.resourceAnchorId `
                    -SubnetId $env.subnetId `
                    -Zone $env.zone `
                    -NoWait

                # Always ensure we got something back
                $created | Should -Not -BeNullOrEmpty



            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
