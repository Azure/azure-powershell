if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSpringApp'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSpringApp.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Update-AzSpringApp' {
    It 'UpdateExpanded' {
        Update-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway
    }

    It 'UpdateViaIdentityExpanded' {
        $app = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway
        Update-AzSpringApp -InputObject $app
    }
}
