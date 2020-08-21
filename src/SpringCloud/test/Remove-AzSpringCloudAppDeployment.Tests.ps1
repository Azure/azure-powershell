$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzSpringCloudAppDeployment' {
    It 'Delete' {
        Remove-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appAuth -Name $env.deployTest
        $deployList = Get-AzSpringCloudAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appAuth
        $deployList.Name| Should -Not -Contain $env.deployTest
    }

    It 'DeleteViaIdentity' {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appAuth -Name $env.deployProd
        Remove-AzSpringCloudAppDeployment -InputObject $deploy
        $deployList = Get-AzSpringCloudAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appAuth
        $deployList.Name| Should -Not -Contain $env.deployProd
    }
}
