$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzSpringCloudApp' {
    It 'List'  {
        $appList = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00
        $appList.Count | Should -Be 3
    }

    It 'Get' {
        $app = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -Name $env.appGateway
        $app.Name | Should -Be $env.appGateway
    }

    It 'GetViaIdentity' {
        $app = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -Name $env.appGateway
        $appNew = Get-AzSpringCloudApp -InputObject $app
        $appNew.Name | Should -Be $env.appGateway
    }
}
