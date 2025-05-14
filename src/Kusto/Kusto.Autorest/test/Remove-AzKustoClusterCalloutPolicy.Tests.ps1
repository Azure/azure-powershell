Describe 'Remove-AzKustoClusterCalloutPolicy' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoClusterCalloutPolicy.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Remove' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $subscriptionId = $env.subscriptionId
        $apiVersion = $env.kustoApiVersion
        $sandboxCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
            calloutType = "sandbox_artifacts"
            outboundAccess = "Allow"
            calloutUriRegex = "*"
        }
        $genevametricsCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
            calloutType = "genevametrics"
            outboundAccess = "Deny"
            calloutUriRegex = "*"
        }
        $policies = @($sandboxCalloutPolicy, $genevametricsCalloutPolicy)
        Add-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId -Value $policies

        $returnedPolicies = Get-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId
        $returnedPolicies.Count | Should -BeGreaterOrEqual 2
        $numberOfPoliciesBeforeRemoval = $returnedPolicies.Count
        
        Remove-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId -CalloutPolicy $returnedPolicies[0]
        $returnedPoliciesAfterRemoval = Get-AzKustoClusterCalloutPolicy -ResourceGroupName $resourceGroupName -ClusterName $clusterName -SubscriptionId $subscriptionId
        $returnedPoliciesAfterRemoval.Count | Should -Be ($numberOfPoliciesBeforeRemoval - 1)
                
    }
}
