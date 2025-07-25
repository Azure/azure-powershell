if (($null -eq $TestName) -or ($TestName -contains 'Update-AzSqlVMGroup')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSqlVMGroup.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSqlVMGroup' {
    It 'UpdateExpanded' {
        $Offer = "SQL2022-WS2022"
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "updateGroup1"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $Offer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $Offer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileClusterSubnetType | Should -Be $ClusterSubnetType
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileStorageAccountUrl | Should -BeNullOrEmpty 

        $ClusterBootstrapAccount = 'boostrapuser@azpstestsqlvm2.com'
        $ClusterOperatorAccount = 'operatoruser@azpstestsqlvm2.com'
        $ClusterSubnetType = 'MultiSubnet'
        $DomainFqdn = 'azpstestsqlvm2.com'
        $OuPath = "OU=path1,DC=azpstestsqlvm2,DC=com"
        $SqlServiceAccount = "sqluser@azpstestsqlvm2.com"
        $StorageAccountUrl = "https://azpstestsqlvmstorage.blob.core.windows.net/"
        $storageAccountPrimaryKey = ConvertTo-SecureString -String "akeyvalue" -AsPlainText -Force
        $Tag = @{'IT' = '8888' }

        Update-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -ClusterBootstrapAccount $ClusterBootstrapAccount -ClusterOperatorAccount $ClusterOperatorAccount -ClusterSubnetType $ClusterSubnetType -DomainFqdn $DomainFqdn -OuPath $OuPath -SqlServiceAccount $SqlServiceAccount -StorageAccountUrl $StorageAccountUrl -storageAccountPrimaryKey $storageAccountPrimaryKey -Tag $Tag

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $Offer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -Be $ClusterBootstrapAccount 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -Be $ClusterOperatorAccount
        $group.WsfcDomainProfileClusterSubnetType | Should -Be 'SingleSubnet' # not changed
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -Be $SqlServiceAccount
        $group.WsfcDomainProfileStorageAccountUrl | Should -Be $StorageAccountUrl

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName
    }

    It 'UpdateViaIdentityExpanded' {
        

        $Offer = "SQL2022-WS2022"
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "updateGroup2"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $Offer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $Offer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileClusterSubnetType | Should -Be $ClusterSubnetType
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileStorageAccountUrl | Should -BeNullOrEmpty

        $ClusterBootstrapAccount = 'boostrapuser@azpstestsqlvm2.com'
        $ClusterOperatorAccount = 'operatoruser@azpstestsqlvm2.com'
        $ClusterSubnetType = 'MultiSubnet'
        $DomainFqdn = 'azpstestsqlvm2.com'
        $OuPath = "OU=path1,DC=azpstestsqlvm2,DC=com"
        $SqlServiceAccount = "sqluser@azpstestsqlvm2.com"
        $StorageAccountUrl = "https://azpstestsqlvmstorage.blob.core.windows.net/"
        $storageAccountPrimaryKey = ConvertTo-SecureString -String "akeyvalue" -AsPlainText -Force
        $Tag = @{'IT' = '8888' }

        Update-AzSqlVMGroup -InputObject $group -ClusterBootstrapAccount $ClusterBootstrapAccount -ClusterOperatorAccount $ClusterOperatorAccount -ClusterSubnetType $ClusterSubnetType -DomainFqdn $DomainFqdn -OuPath $OuPath -SqlServiceAccount $SqlServiceAccount -StorageAccountUrl $StorageAccountUrl -storageAccountPrimaryKey $storageAccountPrimaryKey -Tag $Tag

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $Offer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -Be $ClusterBootstrapAccount 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -Be $ClusterOperatorAccount
        $group.WsfcDomainProfileClusterSubnetType | Should -Be 'SingleSubnet' # not changed
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -Be $SqlServiceAccount
        $group.WsfcDomainProfileStorageAccountUrl | Should -Be $StorageAccountUrl

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName
        
        
    }
}
