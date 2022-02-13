$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMapsAccountKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMapsAccountKey' {
    It 'RegenerateExpanded' {
        { New-AzMapsAccountKey -ResourceGroupName $env.resourceGroup -Name $env.mapsName01 -KeyType primary } | Should -Not -Throw
    }


    It 'RegenerateViaIdentityExpanded' {
        { 
          $maps = Get-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName01
          New-AzMapsAccountKey -InputObject $maps -KeyType primary
        } | Should -Not -Throw
    }

}
