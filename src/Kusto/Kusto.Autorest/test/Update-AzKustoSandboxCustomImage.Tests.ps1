Describe 'Update-AzKustoSandboxCustomImage' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoSandboxCustomImage.Recording.json'
        $currentPath = $PSScriptRoot
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'UpdateExpanded' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        Update-AzKustoSandboxCustomImage -ClusterName $clusterName  -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent
        
        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }

    It 'Update' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $sandboxCustomImageName = "testimage"
        $sandboxCustomImageParameter = @{
            LanguageVersion = "3.9.7"
            RequirementsFileContent = "Pillow"
        }

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -Parameter $sandboxCustomImageParameter

        Update-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -Parameter $sandboxCustomImageParameter

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }

    It 'UpdateViaIdentityExpanded' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent
       
        $sandboxImage = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
        
        Update-AzKustoSandboxCustomImage -InputObject $sandboxImage -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }

    It 'UpdateViaIdentity' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $sandboxCustomImageName = "testimage"
        $sandboxCustomImageParameter = @{
            LanguageVersion = "3.9.7"
            RequirementsFileContent = "Pillow"
        }

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -Parameter $sandboxCustomImageParameter

        $sandboxImage = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName

        Update-AzKustoSandboxCustomImage -InputObject $sandboxImage -Parameter $sandboxCustomImageParameter

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }
}
