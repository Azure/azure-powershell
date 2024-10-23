
if (($null -eq $TestName) -or ($TestName -contains 'AzKubernetesRuntimeStorageClass')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzKubernetesRuntimeStorageClass.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzKubernetesRuntimeStorageClass' {

    $resourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Kubernetes/connectedClusters/$($env.ArcName)"
    $extensionName = "arc-k8s-storage-class"

    It 'Enables Storage class service' {
        if ($TestMode -eq 'playback') {
            return
        }

        $output = Enable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId $resourceUri

        $output.Extension.Name | Should -Be $extensionName
        $output.StorageClassContributorRoleAssignment.ObjectId | Should -Be $output.Extension.IdentityPrincipalId

        { Get-AzKubernetesExtension -ResourceGroupName $env.ResourceGroup -ClusterName $env.ArcName -ClusterType ConnectedClusters -Name $extensionName } | Should -Not -Throw

    }


    It 'Gets storage classes' {
        Get-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId $resourceUri | Should -Not -Be $null
    }

    $typeProperties = @(
        New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject `
            -Server "0.0.0.0" `
            -Share "/share" `
            -MountPermission "777" `
            -OnDelete "Delete" `
            -SubDir "subdir"
        New-AzKubernetesRuntimeSmbStorageClassTypePropertiesObject `
            -Source "//ip:port" `
            -Domain "domain" `
            -Username "username" `
            -Password $(ConvertTo-SecureString 'password' -AsPlainText) `
            -SubDir "subdir"
        New-AzKubernetesRuntimeRwxStorageClassTypePropertiesObject `
            -BackingStorageClassName "default"
        New-AzKubernetesRuntimeBlobStorageClassTypePropertiesObject `
            -AzureStorageAccountName accountName `
            -AzureStorageAccountKey $(ConvertTo-SecureString 'accountKey' -AsPlainText)
    )

    foreach ($typeProperty in $typeProperties) {
        It "Creates, Gets and Deletes a $($typeProperty.Type) storage class" {

            $newStorageClassName = "$($typeProperty.Type.ToLower())-test"

            Write-Host "Creating SC $newStorageClassName"

            $output = New-AzKubernetesRuntimeStorageClass `
                -ArcConnectedClusterId $resourceUri `
                -Name $newStorageClassName `
                -TypeProperty $typeProperty -Verbose
    
            $output.TypeProperty.Type | Should -Be $typeProperty.Type
    
            Get-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId $resourceUri -Name $newStorageClassName | ConvertTo-Json | Should -Be ($output | ConvertTo-Json)

            Remove-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId $resourceUri -Name $newStorageClassName

            { Get-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId $resourceUri -Name $newStorageClassName } | Should -Throw

        }
    }

    It 'Disables storage class service ' {

        if ($TestMode -eq 'playback') {
            return
        }

        Disable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId $resourceUri

        { Get-AzKubernetesExtension -ResourceGroupName $env.ResourceGroup -ClusterName $env.ArcName -ClusterType ConnectedClusters -Name $extensionName } | Should -Throw
    }
}