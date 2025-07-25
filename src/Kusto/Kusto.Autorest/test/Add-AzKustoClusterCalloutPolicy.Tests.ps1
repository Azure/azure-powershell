Describe 'Add-AzKustoClusterCalloutPolicy' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzKustoClusterCalloutPolicy.Recording.json'
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
        $subscriptionId = $env.subscriptionId
        $apiVersion = $env.kustoApiVersion
        $kustoCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
            calloutType = "kusto"
            outboundAccess = "Allow"
            calloutUriRegex = "*"
        }
        $sqlCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
            calloutType = "sql"
            outboundAccess = "Deny"
            calloutUriRegex = "*"
        }
        $policies = @($kustoCalloutPolicy, $sqlCalloutPolicy)
        { Add-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId -Value $policies } | Should -Not -Throw
    }
}
