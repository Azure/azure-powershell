if (($null -eq $TestName) -or ($TestName -contains 'Start-AzSqlVMAssessment')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzSqlVMAssessment.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzSqlVMAssessment' {
    It 'Start' {
        Start-AzSqlVMAssessment -ResourceGroupName $env.ResourceGroupName -SqlVirtualMachineName $env.SqlVMName
    }

    It 'StartViaIdentity' {
        $SubscriptionId = $PSDefaultParameterValues["*:SubscriptionId"]
        $PSDefaultParameterValues.Remove("*:SubscriptionId")
        
        $sqlvm = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
        $sqlvm | Start-AzSqlVMAssessment

        $PSDefaultParameterValues["*:SubscriptionId"] = $SubscriptionId
    }
}
