if (($null -eq $TestName) -or ($TestName -contains 'New-AzSqlVMGroup')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSqlVMGroup.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSqlVMGroup' {

    It 'CreateExpanded-Simple' {
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "simpleGroup"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $env.SqlImageOffer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $env.SqlImageOffer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileClusterOperatorAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileClusterSubnetType | Should -Be $ClusterSubnetType
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileSqlServiceAccount | Should -BeNullOrEmpty 
        $group.WsfcDomainProfileStorageAccountUrl | Should -BeNullOrEmpty 

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName
    }

    It 'CreateExpanded-Normal' {
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $userAccount = 'azureadmin@azpstestsqlvm.com'
        $SqlServiceAccount = 'sqladmin@azpstestsqlvm.com'
        $storageAccountPrimaryKey = ConvertTo-SecureString -String "REDACTED " -AsPlainText
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "normalGroup"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $env.SqlImageOffer -Sku $Sku -DomainFqdn $DomainFqdn -ClusterOperatorAccount $userAccount -ClusterBootstrapAccount $userAccount -StorageAccountUrl $env.StorageAccountUrl -SqlServiceAccount $SqlServiceAccount -StorageAccountPrimaryKey $storageAccountPrimaryKey -ClusterSubnetType $ClusterSubnetType
        
        $group.Name | Should -Be $SqlVMGroupName
        $group.SqlImageOffer | Should -Be $env.SqlImageOffer
        $group.SqlImageSku | Should -Be $Sku
        $group.WsfcDomainProfileClusterBootstrapAccount | Should -Be $userAccount
        $group.WsfcDomainProfileClusterSubnetType | Should -Be $ClusterSubnetType
        $group.WsfcDomainProfileDomainFqdn | Should -Be $DomainFqdn
        $group.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName
    }
}
