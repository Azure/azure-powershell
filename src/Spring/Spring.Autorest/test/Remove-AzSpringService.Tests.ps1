if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSpringService'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpringService.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Remove-AzSpringService' {
    It 'Delete' {
        Remove-AzSpringService -ResourceGroupName $env.resourceGroup -Name $env.springName01
        $springList = Get-AzSpringService -ResourceGroupName $env.resourceGroup
        $springList.Name| Should -Not -Contain $env.springName02
    }

    It 'DeleteViaIdentity' {
        $spring = New-AzSpringService -ResourceGroupName $env.resourceGroup -Name $env.springName02 -Location $env.location2
        Remove-AzSpringService -InputObject $spring
        $springList = Get-AzSpringService -ResourceGroupName $env.resourceGroup
        $springList.Name| Should -Not -Contain $env.springName02
    }
}