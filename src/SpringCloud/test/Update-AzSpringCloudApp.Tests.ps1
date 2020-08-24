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

Describe 'Update-AzSpringCloudApp' {
    It 'UpdateExpanded' {
        Update-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -Name $env.appAuth -ActiveDeploymentName $env.deployProd
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAuth -Name $env.deployProd
        $deploy.Active | Should -Be $true
    }

    It 'UpdateViaIdentityExpanded' {
        $app = Get-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -Name $env.appAccount
        Update-AzSpringCloudApp -InputObject $app -ActiveDeploymentName $env.deployTest
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployTest
        $deploy.Active | Should -Be $true
    }
}
