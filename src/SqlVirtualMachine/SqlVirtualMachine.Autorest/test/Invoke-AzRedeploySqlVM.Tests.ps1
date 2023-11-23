if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRedeploySqlVM')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRedeploySqlVM.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRedeploySqlVM' {
    It 'Redeploy' {
        Invoke-AzRedeploySqlVM -ResourceGroupName $env.ResourceGroupName -SqlVirtualMachineName $env.SqlVMName
    }

    It 'RedeployViaIdentity' {
        $sqlvm = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
        Invoke-AzRedeploySqlVM -InputObject $sqlvm 
    }
}
