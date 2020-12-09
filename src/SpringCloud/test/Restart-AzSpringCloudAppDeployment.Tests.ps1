$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzSpringCloudAppDeployment' {
    It 'Restart' {
        $deploy = Restart-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployTest 
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployTest 
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }

    It 'RestartViaIdentity' {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployProd 
        $deploy = Restart-AzSpringCloudAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployTest 
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
