if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminPool' {
    It 'CreateExpanded' -skip {
        $pool = New-AzDevCenterAdminPool -Name $env.poolNew -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Location $env.location -DevBoxDefinitionName $env.devBoxDefinitionName -LocalAdministrator "Enabled" -NetworkConnectionName $env.networkConnectionName -StopOnDisconnectGracePeriodMinute 60 -StopOnDisconnectStatus "Enabled"
        $pool.Name | Should -Be $env.poolNew
        #check this and update Get pool
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionName
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.NetworkConnectionName | Should -Be $env.NetworkConnectionName
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.Name | Should -Be $env.poolNewStopOnDisconnectStatus
    }

    It 'Create' -skip {
        $body = @{"Location" = $env.location; "DevBoxDefinitionName" = $env.devBoxDefinitionName; "LocalAdministrator" = "Enabled" ; "NetworkConnectionName" = $env.networkConnectionName; "StopOnDisconnectGracePeriodMinute" = 60; "StopOnDisconnectStatus" = "Enabled" }
        $pool = New-AzDevCenterAdminPool -Name $env.poolNew2 -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Body $body  
        $pool.Name | Should -Be $env.poolNew2
    }

}
