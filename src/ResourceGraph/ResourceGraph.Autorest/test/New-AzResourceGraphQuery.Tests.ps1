$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzResourceGraphQuery.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzResourceGraphQuery' {
    It 'CreateExpandedByQuery' {
        $query =  New-AzResourceGraphQuery -Name $env.query03 -ResourceGroupName $env.resourceGroup -Location $env.location -Description "requesting a subset of resource fields." -Query "project id, name, type, location, tags"
        $query.Name | Should -Be $env.query03
    }
    It 'CreateExpandedByFile' {
        $query =  New-AzResourceGraphQuery -Name $env.query04 -ResourceGroupName $env.resourceGroup -Location $env.location -Description "requesting a subset of resource fields." -File "$PSScriptRoot\$($env.kqlFilePath)"
        $query.Name | Should -Be $env.query04
    }
}
