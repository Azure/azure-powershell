$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzSpringCloudApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Deploy-AzSpringCloudApp' {
    It 'CreateExpanded' -Skip {
        # Skip: Deploy need using API of data plan. Not support record model.
        # Setting active development before deploy spring app.
        Update-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -Name $env.appGateway -ActiveDeploymentName $env.deployTest
        $deploy = Deploy-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName00 -Name $env.appGateway -JarPath ./test/deployment-templates/source-code/gateway/target/gateway.jar
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
