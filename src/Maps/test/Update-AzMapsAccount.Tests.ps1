$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMapsAccount.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMapsAccount' {
    It 'UpdateExpanded' {
        { 
          Update-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName01 -Tag @{'key1'='value1'; 'key2'='value2'}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {  
          $maps = Get-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName01 
          Update-AzMapsAccount -InputObject $maps -Tag @{'key1'='value1'; 'key2'='value2'}
        } | Should -Not -Throw
    }

}
