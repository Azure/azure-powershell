Describe 'Get-AzKustoClusterCalloutPolicy' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterCalloutPolicy.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $subscriptionId = $env.subscriptionId
        $apiVersion = $env.kustoApiVersion
        $cosmosdbCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
            calloutType = "cosmosdb"
            outboundAccess = "Allow"
            calloutUriRegex = "*"
        }
        $postgresqlCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
            calloutType = "postgresql"
            outboundAccess = "Deny"
            calloutUriRegex = "*"
        }
        $policies = @($cosmosdbCalloutPolicy, $postgresqlCalloutPolicy)
        Add-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId -Value $policies
        
        $returnedPolicies = Get-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId
        $returnedPolicies.Count | Should -BeGreaterOrEqual 2
    }
}
    

