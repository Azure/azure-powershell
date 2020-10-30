$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResourceGraphQuery.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzResourceGraphQuery' {
    It 'UpdateExpanded'  {
        $kql = "project id, name, type, location"
        $query = Update-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup -Name $env.query01 -Query $kql -Tag @{'key1' = 1; 'key2' = 2; 'key3' = 3}
        $query.Query | Should -Be $kql
        $query.Tag.Count | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded' {
        $query = Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup -Name $env.query02
        $query = Update-AzResourceGraphQuery -InputObject $query -File "$PSScriptRoot\$($env.kqlFilePath)"
        $kql = Get-Content -Path "$PSScriptRoot\$($env.kqlFilePath)"
        $query.Query | Should -Be $kql
    }
}
