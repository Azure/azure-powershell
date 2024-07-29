if(($null -eq $TestName) -or ($TestName -contains 'Start-AzSpringAppDeployment'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzSpringAppDeployment.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzSpringAppDeployment' {
    # Test case been write in other cmdlet
    It 'Start' -skip {
        $deploy = Start-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName  
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }

    It 'StartViaIdentity' -skip {
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy = Start-AzSpringAppDeployment -InputObject $deploy
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName 
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
