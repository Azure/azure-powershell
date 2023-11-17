Describe 'Remove-AzKustoDatabasePrincipal' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoDatabasePrincipal.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'RemoveExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName

        [array]$databasePrincipals = Get-AzKustoDatabasePrincipal -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName
        $databasePrincipal = $databasePrincipals[0]

        { Remove-AzKustoDatabasePrincipal -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Value (@{Name = $databasePrincipal.Name; Role = $databasePrincipal.Role; Type = $databasePrincipal.Type; Email = $databasePrincipal.Email; AppId = $databasePrincipal.AppId }) } | Should -Not -Throw
        { Add-AzKustoDatabasePrincipal -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Value (@{Name = $databasePrincipal.Name; Role = $databasePrincipal.Role; Type = $databasePrincipal.Type; Email = $databasePrincipal.Email; AppId = $databasePrincipal.AppId }) } | Should -Not -Throw
    }
}
