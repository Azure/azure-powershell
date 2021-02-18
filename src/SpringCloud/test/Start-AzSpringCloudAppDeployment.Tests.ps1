$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzSpringCloudAppDeployment' {
    It 'Start' {
        $deploy = Start-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployTest
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployTest  
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }

    It 'StartViaIdentity' {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployProd 
        $deploy = Start-AzSpringCloudAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployProd 
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
