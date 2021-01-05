$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSpringCloudAppDeployment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzSpringCloudAppDeployment' {
    It 'CreateExpanded' {
        $deploy = New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway -Name $env.deployTest `
        -Cpu 1 -MemoryInGb 3 -RuntimeVersion "Java_8" -EnvironmentVariable @{"env" = "test"}
        $deploy.ProvisioningState | Should -Be "Succeeded"

        $deploy = New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway -Name $env.deployProd `
        -Cpu 1 -MemoryInGb 3 -RuntimeVersion "Java_8" -EnvironmentVariable @{"env" = "prod"} -JvmOption "-Xms1G -Xmx1G"
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
