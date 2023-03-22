if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzSqlVM')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSqlVM.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSqlVM' {
    It 'Delete' {
        New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location
        Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

    It 'DeleteViaIdentity' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location
        Remove-AzSqlVM -InputObject $sqlVM
    }
    
}
