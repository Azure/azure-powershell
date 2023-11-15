$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMapsCreator.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMapsCreator' {
    It 'UpdateExpanded' {
        { Update-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName01 -Name $env.creatorName01 -Tag @{'key1'='value1'; 'key2'='value2'} } | Should -Not -Throw
    }


    It 'UpdateViaIdentityExpanded' {
        {
          $creator = Get-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName01 -Name $env.creatorName01 
          Update-AzMapsCreator -InputObject $creator -Tag @{'key1'='value1'; 'key2'='value2'} 
        } | Should -Not -Throw
    }

}
