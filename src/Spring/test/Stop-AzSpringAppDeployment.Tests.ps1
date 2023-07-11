if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzSpringAppDeployment'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzSpringAppDeployment.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzSpringAppDeployment' {
    # Test case been write in other cmdlet
    It 'Stop' -skip {
        $deploy = Stop-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName  
        $deploy.Status | Should -Be "Stopped"
    }

    It 'StopViaIdentity' -skip {
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy = Stop-AzSpringAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy.Status | Should -Be "Stopped"
    }
}
