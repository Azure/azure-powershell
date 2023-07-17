if(($null -eq $TestName) -or ($TestName -contains 'Restart-AzSpringCloudAppDeployment'))
{
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
}

Describe 'Restart-AzSpringCloudAppDeployment' {
    It 'Restart' {
        Stop-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName
        Start-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        Restart-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }

    It 'RestartViaIdentity' {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        Stop-AzSpringCloudAppDeployment -InputObject $deploy
        Start-AzSpringCloudAppDeployment -InputObject $deploy
        Restart-AzSpringCloudAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
