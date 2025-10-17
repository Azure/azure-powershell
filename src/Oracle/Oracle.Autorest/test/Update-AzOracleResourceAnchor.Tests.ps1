# Minimal playback test for Update-AzOracleResourceAnchor (tags-only)

if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleResourceAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
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
    # Keep in sync with your Create/Remove tests
    $anchorName = if ($env:RESOURCE_ANCHOR_NAME) { $env:RESOURCE_ANCHOR_NAME } else { 'Create' }
    $rgName     = if ($env:resourceGroup)       { $env:resourceGroup }       else { 'basedb-rg929-ti-iad52' }
    $subId   = if ($env:SubscriptionId) { $env:SubscriptionId } else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    It 'Update tags' {
        {
            # Prefer native -Tag if the cmdlet supports it; otherwise use -JsonString
            $tags = @{ updatedBy = 'Pester'; purpose = 'sdk-test' }

            $cmd = Get-Command -Name Update-AzOracleResourceAnchor -ErrorAction SilentlyContinue
            if ($cmd -and ($cmd.Parameters.Keys -contains 'Tag')) {
                Update-AzOracleResourceAnchor -Name $anchorName -ResourceGroupName $rgName -SubscriptionId $subId -Tag $tags | Out-Null
            } else {
                $patchBody = @{ tags = $tags } | ConvertTo-Json -Depth 4
                Update-AzOracleResourceAnchor -Name $anchorName -ResourceGroupName $rgName -SubscriptionId $subId -JsonString $patchBody | Out-Null
            }

            $ra = Get-AzOracleResourceAnchor -Name $anchorName -ResourceGroupName $rgName -SubscriptionId $subId
            $ra.Tag.Get_Item('updatedBy') | Should -Be 'Pester'
            $ra.Tag.Get_Item('purpose')   | Should -Be 'sdk-test'
        } | Should -Not -Throw
    }
}
