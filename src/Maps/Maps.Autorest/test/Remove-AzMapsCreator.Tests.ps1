$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMapsCreator.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMapsCreator' {
    It 'Delete' {
        { 
          Remove-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName02 -Name $env.creatorName02 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {           
          New-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName03 -SkuName S1 -Location $env.location
          $creator = New-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName03 -Name $env.creatorName03 -Location $env.creatorLocation -StorageUnit 3
          Remove-AzMapsCreator -InputObject $creator
        } | Should -Not -Throw
    }
}
