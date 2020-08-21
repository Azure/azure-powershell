$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpringCloudApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzSpringCloudApp' {
    It 'Delete' {
        Remove-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appGateway
        $appList = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01
        $appList.Name| Should -Not -Contain $env.appGateway
    }

    It 'DeleteViaIdentity' {
        $app = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appAccount
        Remove-AzSpringCloudApp -InputObject $app
        $appList = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01
        $appList.Name| Should -Not -Contain $env.appAccount        
    }
}
