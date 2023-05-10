if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzSpringCloudAppDeployment'))
{
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
}

Describe 'Stop-AzSpringCloudAppDeployment' {
    # Test case been write in other cmdlet
    It 'Stop' -skip {
        $deploy = Stop-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName  
        $deploy.Status | Should -Be "Stopped"
    }

    It 'StopViaIdentity' -skip {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy = Stop-AzSpringCloudAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy.Status | Should -Be "Stopped"
    }
}
