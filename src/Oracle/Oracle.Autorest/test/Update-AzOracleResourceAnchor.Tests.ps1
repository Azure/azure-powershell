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

    It 'Update tags' {
        {
            # Prefer native -Tag if the cmdlet supports it; otherwise use -JsonString
            $tags = @{ updatedBy = 'Pester'; purpose = 'sdk-test' }

            $cmd = Get-Command -Name Update-AzOracleResourceAnchor -ErrorAction SilentlyContinue
            if ($cmd -and ($cmd.Parameters.Keys -contains 'Tag')) {
                Update-AzOracleResourceAnchor -Name $env.resourceAnchorName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.SubscriptionId -Tag $tags | Out-Null
            } else {
                $patchBody = @{ tags = $tags } | ConvertTo-Json -Depth 4
                Update-AzOracleResourceAnchor -Name $env.resourceAnchorName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.SubscriptionId -JsonString $patchBody | Out-Null
            }

            $ra = Get-AzOracleResourceAnchor -Name $env.resourceAnchorName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.SubscriptionId
            $ra.Tag.Get_Item('updatedBy') | Should -Be 'Pester'
            $ra.Tag.Get_Item('purpose')   | Should -Be 'sdk-test'
        } | Should -Not -Throw
    }
}
