if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserCatalog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserCatalog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserCatalog' {
    It 'List' {
        $listOfCatalogs = Get-AzDevCenterUserCatalog -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfCatalogs.Count | Should -Be 1

        if ($Record -or $Live) {
            $listOfCatalogs = Get-AzDevCenterUserCatalog -DevCenterName $env.devCenterName -ProjectName $env.projectName
            $listOfCatalogs.Count | Should -Be 1
        }

    }

    It 'Get' {
        $catalog = Get-AzDevCenterUserCatalog -Endpoint $env.endpoint -ProjectName $env.projectName -CatalogName $env.catalogName 
        $catalog.Name | Should -Be $env.catalogName

        if ($Record -or $Live) {
            $catalog = Get-AzDevCenterUserCatalog -DevCenterName $env.devCenterName -ProjectName $env.projectName -CatalogName $env.catalogName 
            $catalog.Name | Should -Be $env.catalogName
        }
    }

    It 'GetViaIdentity' {
        $catalogInput = @{"CatalogName" = $env.catalogName; "ProjectName" = $env.projectName }
        $catalog = Get-AzDevCenterUserCatalog -Endpoint $env.endpoint -InputObject $catalogInput 
        $catalog.Name | Should -Be $env.catalogName

        if ($Record -or $Live) {
            $catalog = Get-AzDevCenterUserCatalog -DevCenterName $env.devCenterName -InputObject $catalogInput 
            $catalog.Name | Should -Be $env.catalogName
        }

    }
}
