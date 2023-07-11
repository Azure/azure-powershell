if(($null -eq $TestName) -or ($TestName -contains 'New-AzSpringAppDeployment'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSpringAppDeployment.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'New-AzSpringAppDeployment' {
    It 'CreateExpanded' {
        $jarSource = New-AzSpringAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"
        $deploy = New-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway -Name $env.greenDeploymentName `
        -Source $jarSource -EnvironmentVariable @{"env" = "test"}
        $deploy.ProvisioningState | Should -Be "Succeeded"

        $deploy = New-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway -Name $env.buleDeploymentName `
        -Source $jarSource -EnvironmentVariable @{"env" = "prod"}
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
