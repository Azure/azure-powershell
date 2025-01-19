if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringAppDeployment'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringAppDeployment.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzSpringAppDeployment' {
    It 'List' {
        $deployList = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway
        $deployList.Count | Should -Be 2
    }

    It 'Get' {
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName
        $deploy.Name | Should -Be $env.greenDeploymentName  
    }

    It 'GetViaIdentity' {
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName
        $deployNew = Get-AzSpringAppDeployment -InputObject $deploy
        $deployNew.Name | Should -Be $env.greenDeploymentName    
    }
}
