if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringApp'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringApp.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzSpringApp' {
    It 'List'  {
        $appList = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01
        $appList.Count | Should -Be 2
    }

    It 'Get' {
        $app = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway
        $app.Name | Should -Be $env.appGateway
    }

    It 'GetViaIdentity' {
        $app = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway
        $appNew = Get-AzSpringApp -InputObject $app
        $appNew.Name | Should -Be $env.appGateway
    }
}
