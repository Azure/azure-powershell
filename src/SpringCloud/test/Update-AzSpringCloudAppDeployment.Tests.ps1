if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSpringCloudAppDeployment'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSpringCloudAppDeployment.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSpringCloudAppDeployment' {
    It 'UpdateExpanded' {
        $deploy = Update-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName
    }

    It 'UpdateViaIdentityExpanded' {
        $deploy = Get-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName
        Update-AzSpringCloudAppDeployment -InputObject $deploy    
    }
}
