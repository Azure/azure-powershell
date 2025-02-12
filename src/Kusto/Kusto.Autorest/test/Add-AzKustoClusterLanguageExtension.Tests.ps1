

Describe 'Add-AzKustoClusterLanguageExtension' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzKustoClusterLanguageExtension.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'AddExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        
        { Add-AzKustoClusterLanguageExtension -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Value (@{ Name = "R" }) } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

        { Add-AzKustoClusterLanguageExtension -InputObject $clusterGetItem -Value (@{ Name = "PYTHON" }) } | Should -Not -Throw
    }
}
