if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminCatalog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminCatalog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminCatalog' {
    It 'Delete' {
        Remove-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogNameDelete -ResourceGroupName $env.resourceGroup
        { Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogNameDelete -ResourceGroupName $env.resourceGroup } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $catalog = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogNameDelete2 -ResourceGroupName $env.resourceGroup
        Remove-AzDevCenterAdminCatalog -InputObject $catalog
        { Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogNameDelete2 -ResourceGroupName $env.resourceGroup } | Should -Throw
    }
}
