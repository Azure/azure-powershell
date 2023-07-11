if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSpringAppDeployment'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpringAppDeployment.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSpringAppDeployment' {
    It 'Delete' {
        Remove-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway -Name $env.greenDeploymentName
        $deployList = Get-AzSpringAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway
        $deployList.Name| Should -Not -Contain $env.greenDeploymentName
    }

    It 'DeleteViaIdentity' {
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway -Name $env.buleDeploymentName
        Remove-AzSpringAppDeployment -InputObject $deploy
        $deployList = Get-AzSpringAppDeployment  -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -AppName $env.appGateway
        $deployList.Name| Should -Not -Contain $env.buleDeploymentName
    }
}
