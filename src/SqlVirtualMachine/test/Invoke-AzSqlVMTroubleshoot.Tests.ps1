if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSqlVMTroubleshoot')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSqlVMTroubleshoot.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSqlVMTroubleshoot' {
    It 'TroubleshootExpanded' {
        $SqlVMTroubleshootingResult = Invoke-AzSqlVMTroubleshoot -ResourceGroupName $env.ResourceGroupName -SqlVirtualMachineName $env.SqlVMName -StartTimeUtc '2023-03-15T17:10:00Z' -EndTimeUtc '2023-03-16T08:30:10Z' -TroubleshootingScenario 'UnhealthyReplica'
        $SqlVMTroubleshootingResult.TroubleshootingScenario | Should -BeNullOrEmpty
    }

    It 'TroubleshootViaIdentityExpanded' {
        $sqlvm = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
        $SqlVMTroubleshootingResult = Invoke-AzSqlVMTroubleshoot -InputObject $sqlvm -StartTimeUtc '2023-03-15T17:10:00Z' -EndTimeUtc '2023-03-16T08:30:10Z' -TroubleshootingScenario 'UnhealthyReplica'
        $SqlVMTroubleshootingResult.TroubleshootingScenario | Should -BeNullOrEmpty
    }

}
