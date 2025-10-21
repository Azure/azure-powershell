# Minimal playback test for Update-AzOracleDbSystem (tags-only)

if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleDbSystem'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleDbSystem.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOracleDbSystem' {

    It 'Update tags' -Skip {
        {
            $tags = @{ updatedBy = 'Pester'; purpose = 'sdk-test' }
            Update-AzOracleDbSystem -Name $env.baseDbName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.networkAnchorSubId -Tag $tags | Out-Null

            $db = Get-AzOracleDbSystem -Name $env.baseDbName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.networkAnchorSubId
            $db.Tag.Get_Item('updatedBy') | Should -Be 'Pester'
            $db.Tag.Get_Item('purpose')   | Should -Be 'sdk-test'
        } | Should -Not -Throw
    }
}
