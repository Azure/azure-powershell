 Describe 'Remove-AzKustoClusterLanguageExtension' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoClusterLanguageExtension.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'RemoveExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName

        { Remove-AzKustoClusterLanguageExtension -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Value (@{ Name = "R" }) } | Should -Not -Throw
    }

    It 'RemoveViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

        { Remove-AzKustoClusterLanguageExtension -InputObject $clusterGetItem -Value (@{ Name = "PYTHON" }) } | Should -Not -Throw
    }
}
