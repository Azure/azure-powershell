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

    It 'GetViaIdentity' -Skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        $PrivateLinkList = Get-AzKustoPrivateLinkResource -ClusterName $env.kustoClusterName -ResourceGroupName $env.resourceGroupName
        $fullPrivateLinkResourceName = $env.kustoClusterName + "/cluster"
        $resourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroupName + "/providers/Microsoft.Kusto/Clusters/" + $env.kustoClusterName + "/PrivateLinkResources/cluster"
        Validate_PrivateLinkList $PrivateLinkList $resourceId $fullPrivateLinkResourceName
    }

    It 'Get' {        
        $privateLinkResourceName = "cluster"
        $PrivateLink = Get-AzKustoPrivateLinkResource -ClusterName $env.kustoClusterName -Name $privateLinkResourceName -ResourceGroupName $env.resourceGroupName
        $fullPrivateLinkResourceName = $env.kustoClusterName + "/cluster"
        $resourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $env.resourceGroupName + "/providers/Microsoft.Kusto/Clusters/" + $env.kustoClusterName + "/PrivateLinkResources/cluster"
        Validate_PrivateLink $PrivateLink $resourceId $fullPrivateLinkResourceName
    }
}
