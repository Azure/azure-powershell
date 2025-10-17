# Minimal playback test for Update-AzOracleNetworkAnchor (tags-only)

if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleNetworkAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleNetworkAnchor.Recording.json'

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

Describe 'Update-AzOracleNetworkAnchor' {
    # Match the CREATE/GET defaults
    $naName  = if ($env:NETWORK_ANCHOR_NAME) { $env:NETWORK_ANCHOR_NAME } else { 'PowershellTest1s' }
    $rgName  = if ($env:resourceGroup)      { $env:resourceGroup }      else { 'basedb-iad53-rg' }
    $subId   = if ($env:SubscriptionId)     { $env:SubscriptionId }     else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    It 'Update tags only' {
        {
            $tags = @{ updatedBy = 'Pester'; purpose = 'sdk-test' }

            $cmd = Get-Command -Name Update-AzOracleNetworkAnchor -ErrorAction SilentlyContinue
            if ($cmd -and ($cmd.Parameters.Keys -contains 'Tag')) {
                Update-AzOracleNetworkAnchor -Name $naName -ResourceGroupName $rgName -SubscriptionId $subId -Tag $tags | Out-Null
            } else {
                $patchBody = @{ tags = $tags } | ConvertTo-Json -Depth 4
                Update-AzOracleNetworkAnchor -Name $naName -ResourceGroupName $rgName -SubscriptionId $subId -JsonString $patchBody -NoWait| Out-Null
            }

            $na = Get-AzOracleNetworkAnchor -Name $naName -ResourceGroupName $rgName -SubscriptionId $subId
            $na | Should -Not -BeNullOrEmpty
            $na.Tag.Get_Item('updatedBy') | Should -Be 'Pester'
            $na.Tag.Get_Item('purpose')   | Should -Be 'sdk-test'
        } | Should -Not -Throw
    }
}
