if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSpringApp'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpringApp.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSpringApp' {
    It 'Delete' {
        Remove-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appGateway
        $appList = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01
        $appList.Name| Should -Not -Contain $env.appGateway
    }

    It 'DeleteViaIdentity' {
        $app = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appAccount
        Remove-AzSpringApp -InputObject $app
        $appList = Get-AzSpringApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01
        $appList.Name| Should -Not -Contain $env.appAccount        
    }
}
