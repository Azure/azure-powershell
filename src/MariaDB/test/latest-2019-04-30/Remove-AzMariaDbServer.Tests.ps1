$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$mariaDbParam01 = @{SkuName='B_Gen5_1'}
$mariaDbParam02 = @{SkuName='B_Gen5_1'}
$mariadbTest01 = GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup
$mariadbTest02 = GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam02 -ResourceGroup $env.resourceGroup

Describe 'Remove-AzMariaDbServer' {
    It 'Delete' {
        Remove-AzMariaDbServer -Name $mariadbTest01.Name -ResourceGroupName $env.ResourceGroup
        $mariadbs = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariadbs.Name | Should -Not -Contain $mariadbTest01.Name
    }

    It 'DeleteViaIdentity' {
        Remove-AzMariaDbServer -InputObject $mariadbTest02
        $mariadbs = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariadbs.Name | Should -Not -Contain $mariadbTest02.Name
    }
}
