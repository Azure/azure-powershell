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
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "updateGroup1"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $env.SqlImageOffer -Sku $Sku -DomainFqdn $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $env.SqlImageOffer
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
        $storageAccountPrimaryKey = ConvertTo-SecureString -String "REDACTED " -AsPlainText
        $Tag = @{'IT' = '8888' }

        Update-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -ClusterBootstrapAccount $ClusterBootstrapAccount -ClusterOperatorAccount $ClusterOperatorAccount -ClusterSubnetType $ClusterSubnetType -DomainFqdn $DomainFqdn -OuPath $OuPath -SqlServiceAccount $SqlServiceAccount -StorageAccountUrl $env.StorageAccountUrl -storageAccountPrimaryKey $storageAccountPrimaryKey -Tag $Tag

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $env.SqlImageOffer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -Be $ClusterBootstrapAccount 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -Be $ClusterOperatorAccount
        $group.WsfcDomainProfileClusterSubnetType | Should -Be 'SingleSubnet' # not changed
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -Be $SqlServiceAccount
        $group.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName
    }

    It 'UpdateViaIdentityExpanded' {
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "updateGroup2"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $env.SqlImageOffer -Sku $Sku -DomainFqdn $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $env.SqlImageOffer
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
        $storageAccountPrimaryKey = ConvertTo-SecureString -String "REDACTED" -AsPlainText -Force
        $Tag = @{'IT' = '8888' }

        Update-AzSqlVMGroup -InputObject $group -ClusterBootstrapAccount $ClusterBootstrapAccount -ClusterOperatorAccount $ClusterOperatorAccount -ClusterSubnetType $ClusterSubnetType -DomainFqdn $DomainFqdn -OuPath $OuPath -SqlServiceAccount $SqlServiceAccount -StorageAccountUrl $env.StorageAccountUrl -storageAccountPrimaryKey $storageAccountPrimaryKey -Tag $Tag

        $group = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $env.SqlImageOffer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -Be $ClusterBootstrapAccount 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -Be $ClusterOperatorAccount
        $group.WsfcDomainProfileClusterSubnetType | Should -Be 'SingleSubnet' # not changed
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -Be $SqlServiceAccount
        $group.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName
    }
}
