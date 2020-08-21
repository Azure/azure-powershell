$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzSpringCloudAppDeployment' {
    It 'UpdateExpanded' {
        $deploy = Update-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployTest -Cpu 2
        $deploy.DeploymentSettingCpu | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $deploy = Update-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployProd
        $deploy = Update-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployProd -SourceVersion '0.0.1'
        $deploy.SourceVersion | Should -Be '0.0.1'   
    }
}
