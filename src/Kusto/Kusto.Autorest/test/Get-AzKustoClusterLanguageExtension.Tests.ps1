Describe 'Get-AzKustoClusterLanguageExtension' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterLanguageExtension.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName

        [array]$clusterLanguageExtensionGet = Get-AzKustoClusterLanguageExtension -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $clusterLanguageExtension = $clusterLanguageExtensionGet[0]
        $clusterLanguageExtensionGet.Count | Should -Be 2
        $clusterLanguageExtension.Name | Should -Be "PYTHON"
    }
}
