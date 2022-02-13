$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMapsAccount.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMapsAccount' {
    It 'Delete' {
        { 
          New-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName03 -SkuName S1 -Location $env.location
          Remove-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName03 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
          $maps = New-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName03 -SkuName S1 -Location $env.location
          Remove-AzMapsAccount -InputObject $maps
        } | Should -Not -Throw
    }
}
