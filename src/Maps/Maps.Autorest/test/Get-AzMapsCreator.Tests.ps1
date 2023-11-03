$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMapsCreator.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMapsCreator' {
    #NOTE: Only one creator is allowed for a Maps account.
    It 'List' {
        { Get-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName01 } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName01 -Name $env.creatorName01 } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
          $creator = Get-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName01 -Name $env.creatorName01
          Get-AzMapsCreator -InputObject $creator
        } | Should -Not -Throw
    }
}
