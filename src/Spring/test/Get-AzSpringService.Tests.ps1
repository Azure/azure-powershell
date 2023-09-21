if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringService'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringService.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzSpringService' {
    It 'List' {
        $springList = Get-AzSpringService
        $springList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $springList = Get-AzSpringService -ResourceGroupName $env.resourceGroup
        $springList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' { 
        $spring = Get-AzSpringService -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        $spring.Name | Should -Be $env.standardSpringName01
    }

    It 'GetViaIdentity' {
        $spring = Get-AzSpringService -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        $springNew = Get-AzSpringService -InputObject $spring
        $springNew.Name | Should -Be $env.standardSpringName01
    }
}
