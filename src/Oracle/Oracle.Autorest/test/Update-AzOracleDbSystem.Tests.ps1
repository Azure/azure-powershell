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
    # Use a var name that won't collide with Pester's $Name
    $dbsName = 'PowershellSdk'
    $rgName  = if ($env:resourceGroup)  { $env:resourceGroup }  else { 'basedb-rg929-ti-iad52' }
    $subId   = if ($env:SubscriptionId) { $env:SubscriptionId } else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    It 'Update tags' {
        {
            $tags = @{ updatedBy = 'Pester'; purpose = 'sdk-test' }
            Update-AzOracleDbSystem -Name $dbsName -ResourceGroupName $rgName -SubscriptionId $subId -Tag $tags | Out-Null

            $db = Get-AzOracleDbSystem -Name $dbsName -ResourceGroupName $rgName -SubscriptionId $subId
            $db.Tag.Get_Item('updatedBy') | Should -Be 'Pester'
            $db.Tag.Get_Item('purpose')   | Should -Be 'sdk-test'
        } | Should -Not -Throw
    }
}
