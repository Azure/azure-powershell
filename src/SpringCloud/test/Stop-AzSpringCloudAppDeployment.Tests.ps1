$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzSpringCloudAppDeployment' {
    It 'Stop' {
        $deploy = Stop-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployTest 
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployTest  
        $deploy.Status | Should -Be "Stopped"
    }

    It 'StopViaIdentity' {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployProd 
        $deploy = Stop-AzSpringCloudAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appAccount -Name $env.deployProd 
        $deploy.Status | Should -Be "Stopped"
    }
}
