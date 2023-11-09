Describe 'Get-AzKustoPrivateLinkResource' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoPrivateLinkResource.Recording.json'
        $currentPath = $PSScriptRoot
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'GetViaIdentity' {
        $privateLinkResourceName = "cluster"
        $fullPrivateLinkResourceName = $env.kustoClusterName + "/cluster"
        $resourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroupName + "/providers/Microsoft.Kusto/Clusters/" + $env.kustoClusterName + "/PrivateLinkResources/cluster"

        $privateLink = Get-AzKustoPrivateLinkResource -ClusterName $env.kustoClusterName -Name $privateLinkResourceName -ResourceGroupName $env.resourceGroupName
        $privateLink = Get-AzKustoPrivateLinkResource -InputObject $privateLink
        
        Validate_PrivateLink $privateLink $resourceId $fullPrivateLinkResourceName
    }

    It 'List' {
        $fullPrivateLinkResourceName = $env.kustoClusterName + "/cluster"
        $resourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroupName + "/providers/Microsoft.Kusto/Clusters/" + $env.kustoClusterName + "/PrivateLinkResources/cluster"

        $privateLinkList = Get-AzKustoPrivateLinkResource -ClusterName $env.kustoClusterName -ResourceGroupName $env.resourceGroupName
        Validate_PrivateLinkList $privateLinkList $resourceId $fullPrivateLinkResourceName
    }

    It 'Get' {        
        $privateLinkResourceName = "cluster"
        $fullPrivateLinkResourceName = $env.kustoClusterName + "/cluster"
        $resourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroupName + "/providers/Microsoft.Kusto/Clusters/" + $env.kustoClusterName + "/PrivateLinkResources/cluster"

        $privateLink = Get-AzKustoPrivateLinkResource -ClusterName $env.kustoClusterName -Name $privateLinkResourceName -ResourceGroupName $env.resourceGroupName
        Validate_PrivateLink $privateLink $resourceId $fullPrivateLinkResourceName
    }
}
