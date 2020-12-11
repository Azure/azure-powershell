$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzResourceGraphQuery.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzResourceGraphQuery' {
    It 'Delete' {
        Remove-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup -Name $env.query03
        $queryList =  Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup
        $queryList.Name | Should -Not -Contain $env.query03
    }

    It 'DeleteViaIdentity' {
        $query = Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup -Name $env.query04
        Remove-AzResourceGraphQuery -InputObject $query
        $queryList = Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup
        $queryList.Name | Should -Not -Contain $env.query04
    }
}
