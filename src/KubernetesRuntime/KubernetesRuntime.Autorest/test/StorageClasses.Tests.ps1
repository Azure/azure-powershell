Describe 'AzKubernetesRuntimeStorageClass' {

    $resourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Kubernetes/connectedClusters/$($env.ArcName)"

    $extensionName = "arc-k8s-storage-class"

    It 'Enables Storage class service' {
        $output = Enable-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri

        $output.Extension.Name | Should -Be $extensionName
        $output.StorageClassContributorRoleAssignment.ObjectId | Should -Be $output.Extension.IdentityPrincipalId

        { Get-AzKubernetesExtension -ResourceGroupName $env.ResourceGroup -ClusterName $env.ArcName -ClusterType ConnectedClusters -Name $extensionName } | Should -Not -Throw

    }

    It 'Gets storage classes' {
        Get-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri | Should -Not -Be $null
    }

    It 'Gets storage classes by name' {
        Get-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri -StorageClassName 'default' | Should -Not -Be $null
    }

    $newStorageClassName = "nfs-test"

    It 'Creates a NFS storage class' {

        $typeProperties = New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject `
            -Server "0.0.0.0" `
            -Share "/share" `
            -MountPermission "777" `
            -OnDelete "Delete" `
            -SubDir "subdir"

        $output = New-AzKubernetesRuntimeStorageClass `
            -ResourceUri $resourceUri `
            -Name $newStorageClassName `
            -TypeProperty $typeProperties
        
        Write-Host $output

        $output.TypePropertiesType | Should -Be "NFS"
        
        Get-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri -StorageClassName $newStorageClassName | Should -Be $output
    }

    It 'Deletes a storage class' {
        Remove-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri -StorageClassName $newStorageClassName | Should -Not -Be $null

        { Get-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri -StorageClassName $newStorageClassName } | Should -Throw
    }

    It 'Disables storage class service' {
        Disable-AzKubernetesRuntimeStorageClass -ResourceUri $resourceUri

        { Get-AzKubernetesExtension -ResourceGroupName $env.ResourceGroup -ClusterName $env.ArcName -ClusterType ConnectedClusters -Name $extensionName } | Should -Throw
    }
}