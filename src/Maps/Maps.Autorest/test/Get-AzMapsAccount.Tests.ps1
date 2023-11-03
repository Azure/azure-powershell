$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMapsAccount.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMapsAccount' {
    It 'List1' {
        { Get-AzMapsAccount } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMapsAccount -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName01 } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
          $maps = Get-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName01
          Get-AzMapsAccount -InputObject $maps 
        } | Should -Not -Throw
    }
}
