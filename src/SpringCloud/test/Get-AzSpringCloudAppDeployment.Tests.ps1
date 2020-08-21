$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzSpringCloudAppDeployment' {
    It 'List' {
        $deployList = Get-AzSpringCloudAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway
        $deployList.Count | Should -Be 2
    }

    It 'Get' {
        $deploy = Get-AzSpringCloudAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployTest
        $deploy.Name | Should -Be $env.deployTest  
    }

    It 'GetViaIdentity' {
        $deploy = Get-AzSpringCloudAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -AppName $env.appGateway -Name $env.deployTest
        $deployNew = Get-AzSpringCloudAppDeployment -InputObject $deploy
        $deployNew.Name | Should -Be $env.deployTest    
    }
}
