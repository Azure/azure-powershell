if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSpringCloudApp'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSpringCloudApp.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Update-AzSpringCloudApp' {
    It 'UpdateExpanded' {
        Update-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway
    }

    It 'UpdateViaIdentityExpanded' {
        $app = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway
        Update-AzSpringCloudApp -InputObject $app
    }
}
