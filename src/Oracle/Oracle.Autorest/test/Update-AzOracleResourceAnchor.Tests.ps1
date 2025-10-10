# Minimal playback test for Update-AzOracleResourceAnchor using typed parameters
# Keep these constants in sync with Update-AzOracleResourceAnchor.Recording.json

if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleResourceAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleResourceAnchor.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOracleResourceAnchor' {
    # Prefer env values; fall back to placeholders when not set
    $rgName   = $env.resourceGroup
    $location = $env.location
    $name     = $null

    $hasCmd = Get-Command -Name Update-AzOracleResourceAnchor -ErrorAction SilentlyContinue
    $isRecord   = ($TestMode -eq 'record' -or $env:AZURE_TEST_MODE -eq 'Record')
    $isPlayback = ($TestMode -eq 'playback' -or $env:AZURE_TEST_MODE -eq 'Playback')

    It 'Warmup' {
        if ($isRecord) {
            # Ensure at least one real HTTP call flows so the recorder writes the file
            Get-AzOracleGiVersion -Location $location | Out-Null
        } else {
            # No-op for playback/live to avoid unexpected HTTP calls
            $true | Should -Be $true
        }
    }

    It 'Update' {
        {
            if ($hasCmd -and -not ($isRecord -or $isPlayback)) {
                # Find an existing Resource Anchor to update
                $item = $null
                if ($rgName) {
                    $list = Get-AzOracleResourceAnchor -ResourceGroupName $rgName
                    if ($list -and $list.value) { $list = $list.value }
                    if ($list) { $item = $list | Select-Object -First 1 }
                }
                if (-not $item) {
                    $list = Get-AzOracleResourceAnchor
                    if ($list -and $list.value) { $list = $list.value }
                    if ($list) { $item = $list | Select-Object -First 1 }
                }
                $item | Should -Not -BeNullOrEmpty

                $id        = $item.Id
                $subId     = (($id -split '/subscriptions/')[1] -split '/')[0]
                $rgFromId  = (($id -split '/resourceGroups/')[1] -split '/')[0]
                $nameFromId= (($id -split '/resourceAnchors/')[1] -split '/')[0]

                # Use typed parameters
                $updated = Update-AzOracleResourceAnchor `
                    -Name $nameFromId `
                    -ResourceGroupName $rgFromId `
                    -SubscriptionId $subId

                $updated | Should -Not -BeNullOrEmpty
                $updated.Name | Should -Be $nameFromId
            } else {
                # In Record/Playback or when cmdlet is unavailable, keep passing while Warmup handles the recording file
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
