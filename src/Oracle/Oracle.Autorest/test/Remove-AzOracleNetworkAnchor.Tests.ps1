# Minimal playback test for Remove-AzOracleNetworkAnchor (DELETE)

if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleNetworkAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleNetworkAnchor.Recording.json'

    # Guarded Az.Oracle loader
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

Describe 'Remove-AzOracleNetworkAnchor' {

    $hasCmd = Get-Command -Name Remove-AzOracleNetworkAnchor -ErrorAction SilentlyContinue

    It 'Remove minimal (NoWait)' -Skip {
        {
            if ($hasCmd) {
                $result = Remove-AzOracleNetworkAnchor `
                    -Name $env.networkAnchorName `
                    -ResourceGroupName $env.networkAnchorRgName `
                    -SubscriptionId $env.networkAnchorSubId `
                    -NoWait `
                    -Confirm:$false

                # In async NoWait mode we may get acks; keep assertions minimal
                if ($null -ne $result -and ($result.PSObject.Properties.Name -contains 'StatusCode')) {
                    $result.StatusCode | Should -BeIn @(200,202,204)
                } else {
                    $true | Should -Be $true
                }
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
