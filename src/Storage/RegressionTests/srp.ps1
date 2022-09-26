# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 

BeforeAll {
    Import-Module D:\code\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1 
    Import-Module D:\code\azure-powershell\artifacts\Debug\Az.Storage\Az.Storage.psd1 
    Import-Module D:\psh_scripts\Assert\Assert.ps1

    $config = (Get-Content D:\code\azure-powershell\src\Storage\RegressionTests\config.json -Raw | ConvertFrom-Json).srp

    $secpasswd = ConvertTo-SecureString $config.credentials.secpwd -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ($config.credentials.username, $secpasswd)
    Add-AzAccount -ServicePrincipal -Tenant $config.credentials.tenantId -SubscriptionId $config.credentials.subscriptionId -Credential $cred 

    $rgname = "weitry";
    $accountName = "weisanity5"
    $accountName2 = "weisanity6"
    
    $containerName = "weitest"

    
}

Describe "Management plan test" {

    It "Basic Account" -tag "2021-06-01" {
        $Error.Clear()

        Get-AzStorageUsage -Location 'East Us 2'

        $job = Get-AzStorageAccount -asjob
        $job | Wait-Job
        $job.Output.Count | should -BeGreaterThan 10

        $accounts = Get-AzStorageAccount -ResourceGroupName $rgname 
        $accounts.Count | should -BeGreaterThan 1

        $result = Get-AzStorageAccountNameAvailability -Name $accountName 
        $result.NameAvailable | should -Be $true

        #create Account, update account
        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_GRS -Location "eastus2euap" -Kind StorageV2  -EnableHierarchicalNamespace $true -EnableHttpsTrafficOnly $true -AllowCrossTenantReplication $false -PublicNetworkAccess Disabled # -AllowedCopyScope AAD
        $account.ResourceGroupName | should -Be $rgname
        $account.StorageAccountName | should -Be $accountName
        $account.Sku.Name | should -Be "Standard_GRS"
        $account.Location | should -Be "eastus2euap"
        $account.EnableHierarchicalNamespace | should -Be $true
        $account.EnableHttpsTrafficOnly | should -Be $true
        $account.Kind | should -Be "StorageV2"
        $account.AllowCrossTenantReplication | should -Be $false
        $account.PublicNetworkAccess | should -Be Disabled
        # $account.AllowedCopyScope | should -Be AAD
        
        $result = Get-AzStorageAccountNameAvailability -Name $accountName 
        $result.NameAvailable | should -Be $false

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName |  Set-AzStorageAccount   -EnableHttpsTrafficOnly $false -AccessTier cool -Force 
        $account.EnableHttpsTrafficOnly | should -Be $false
        $account.AccessTier | should -Be "Cool"
        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName |  Set-AzStorageAccount   -UpgradeToStorageV2 -PublicNetworkAccess Enabled
        $account.Kind | should -Be "StorageV2"
        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -IncludeGeoReplicationStats
        ($account.GeoReplicationStats -eq $null) | should -Be $false
        $account.PublicNetworkAccess | should -Be Enabled

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -Force -AsJob

        $Error.Count | should -be 0
    }

    It "create context for dataplane" {
        $Error.Clear()

        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -SkuName Premium_LRS -Location "centraluseuap" -Kind BlockBlobStorage  -AssignIdentity
        $a.StorageAccountName | Should -Be $accountName2
        $a.ResourceGroupName | Should -Be $rgname
        $a.Sku.Name | Should -Be Premium_LRS
        $a.Kind | Should -Be BlockBlobStorage
        $a.Location | Should -Be "centraluseuap"
        $a.Identity.Type | Should -Be "SystemAssigned"

        $a | New-AzStorageContainer -Name $containerName

        $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName2
        $ctx = New-AzStorageContext -StorageAccountName $accountName2 -StorageAccountKey $key[0].Value
        $containers = Get-AzStorageContainer -Context $ctx
        $containers.Count | should -BeGreaterOrEqual 1

        New-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName2 -KeyName key1

        sleep 30

        Set-AzCurrentStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 
        $containers = Get-AzStorageContainer
        $containers.Count | should -BeGreaterOrEqual 1
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -Force -AsJob      

        $Error.Count | should -be 0
    }
    

    It "Blob Container" {
        $Error.Clear()

        #Blob Service SRP
        $accountName = "weisanity3"
        $containerName = "weitest4" #Add 1 every time
        $containerName2 = "weitesttodelete"
        #New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_LRS -Location "westus" -Kind StorageV2 

        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName 
        $con.Name | Should -Be $containerName
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName2 -PublicAccess Blob -Metadata @{tag0="value0";tag1="value1"} 
        $con.Name | Should -Be $containerName2
        $con.Metadata.Count | Should -Be 2
        $con.PublicAccess | Should -Be Blob
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName2 
        $con.Name | Should -Be $containerName2
        $con.Metadata.Count | Should -Be 2
        $con.PublicAccess | Should -Be Blob
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Metadata @{tag0="value0"} -PublicAccess Container #-debug
        $con.Name | Should -Be $containerName
        $con.Metadata.Count | Should -Be 1
        $con.PublicAccess | Should -Be Container
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Metadata @{tag0="value0";tag1="value1";tag2="value2"}  -PublicAccess None
        $con.Name | Should -Be $containerName
        $con.Metadata.Count | Should -Be 3
        $con.PublicAccess | Should -Be None
        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName2 -Force

        Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Tag  tag1,tag2 
        Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Tag tag1 
        $tags = (Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName).LegalHold.Tags
        $tags.Count | Should -Be 1

        $imp = Get-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 0
        $imp.State | Should -Be Deleted

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -ImmutabilityPeriod 2 -AllowProtectedAppendWrite $false 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $imp.State | Should -Be Unlocked
        $imp.AllowProtectedAppendWrites | Should -be $false
        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -AllowProtectedAppendWrite $true 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $imp.State | Should -Be Unlocked
        $imp.AllowProtectedAppendWrites | Should -be $true

        $imp = remove-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -Etag $imp.Etag
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 0
        $imp.State | Should -Be Deleted
        $imp.AllowProtectedAppendWrites | Should -be $null

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -ImmutabilityPeriod 1
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 1
        $imp.State | Should -Be Unlocked
        $imp.AllowProtectedAppendWrites | Should -be $null

        $imp = Lock-AzRmStorageContainerImmutabilityPolicy -ImmutabilityPolicy $imp -Force
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 1
        $imp.State | Should -Be Locked
        $imp.AllowProtectedAppendWrites | Should -be $null
     

        $imp = Set-AzRmStorageContainerImmutabilityPolicy -ImmutabilityPolicy $imp -ImmutabilityPeriod 2 -ExtendPolicy 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $imp.State | Should -Be Locked
        $imp.AllowProtectedAppendWrites | Should -be $null

        $c = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName
        $c.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $c.ImmutabilityPolicy.State | Should -Be Locked
        $c.ImmutabilityPolicy.AllowProtectedAppendWrites | Should -be $null
        $c.LegalHold.HasLegalHold | should -be $true
        $c.LegalHold.Tags.Count | should -be 1

        Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Tag tag2     
        $c = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName
        $c.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $c.ImmutabilityPolicy.State | Should -Be Locked
        $c.ImmutabilityPolicy.AllowProtectedAppendWrites | Should -be $null
        $c.LegalHold.HasLegalHold | should -be $false
        $c.LegalHold.Tags.Count | should -be 0

        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Force
        #Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -Force

        $Error.Count | should -be 0
    }
    

    It "Blob Service properties" {
        $Error.Clear()

        # Blob Service properties  
        $accountName = "weisanity3"
        $bp = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName |Update-AzStorageBlobServiceProperty -DefaultServiceVersion 2018-03-28 
        $bp.DefaultServiceVersion | Should -Be 2018-03-28

        Enable-AzStorageBlobDeleteRetentionPolicy -ResourceId $bp.Id -PassThru -RetentionDays 3 -AllowPermanentDelete 
        $bp = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        $bp.DeleteRetentionPolicy.Enabled | Should -Be $true
        $bp.DeleteRetentionPolicy.Days | Should -Be 3
        $bp.DeleteRetentionPolicy.AllowPermanentDelete | Should -Be $true

        Disable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -PassThru
        $bp = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName
        $bp.DeleteRetentionPolicy.Enabled | Should -Be $false

        $Error.Count | should -be 0
    }
    

    It "NetworkRule" {
        $Error.Clear()

        #stage
        $resourceGroupName = "weitest"
        $accountName = "weiacl20"
        $accountName2 = "weiacl0"

        $vnet1 = $config.networkRule.vnet1
        $vnet2 = $config.networkRule.vnet2

        ######### Prepare ############
        # New-AzureRmResourceGroup -Name $resourceGroupName -Location "eastus2euap"
        # New-AzureRmVirtualNetwork -ResourceGroupName $resourceGroupName -Location "eastus2euap" -AddressPrefix 10.0.0.0/24 -Name "vnettry1" 
        # Get-AzureRmVirtualNetwork -ResourceGroupName $resourceGroupName -Name "vnettry1" | Add-AzureRmVirtualNetworkSubnetConfig -Name "subnet1" -AddressPrefix "10.0.0.0/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzureRmVirtualNetwork 
        # Get-AzureRmVirtualNetwork -ResourceGroupName $resourceGroupName -Name "vnettry1" | Add-AzureRmVirtualNetworkSubnetConfig -Name "subnet2" -AddressPrefix "10.0.0.16/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzureRmVirtualNetwork 

        #Create Account, if the accounts already exist, skip this step
        #New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName -SkuName Standard_LRS -Location "eastus2euap"
        #New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName2 -SkuName Standard_LRS -Location "eastus2euap"
        #New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName2 -SkuName Standard_LRS -Location "eastus2(stage)"
        $a = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName

        #Update the Account NetworkACL with JSON
        echo "Update the Account NetworkACL with JSON"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName -Bypass AzureServices -DefaultAction Allow -IpRule (@{IPAddressOrRange="20.11.0.0/16";Action="allow"},
            @{IPAddressOrRange="28.0.2.0/19";Action="allow"},
            @{IPAddressOrRange="129.0.2.34/25";Action="allow"})`
            -VirtualNetworkRule (@{VirtualNetworkResourceId=$vnet1;Action="allow"},
                @{VirtualNetworkResourceId=$vnet2;Action="allow"}) `
            -ResourceAccessRule (@{ResourceId=$vnet1;TenantId=$config.credentials.tenantId},
                @{ResourceId=$vnet2;TenantId=$config.credentials.tenantId})
        $rule.ResourceAccessRules.Count | should -be 2
        $rule.Bypass | should -be AzureServices
        $rule.DefaultAction | should -be Allow
        $rule.IpRules.Count | should -be 3
        $rule.VirtualNetworkRules.Count | should -be 2

        #Get Account NetworkACL, and show IpRules, VirtualNetworkRules
        echo "Get Account NetworkACL, and show IpRules, VirtualNetworkRules"
        #Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName | Set-AzureRmCurrentStorageAccount
        $rule = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName
        $rule.Bypass | should -be AzureServices
        $rule.DefaultAction | should -be Allow
        $rule.IpRules.Count | should -be 3
        $rule.VirtualNetworkRules.Count | should -be 2
        $rule.ResourceAccessRules.Count | should -be 2

        #Clean the IpRules, and add 6 Rules with string Array
        echo "Clean the IpRules, and add 6 Rules with string Array"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName -IPRule @()
        $rule.IpRules.Count | should -be 0
        $iprules = Add-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -IPAddressOrRange "20.11.0.0/16","232.0.18.177/7","89.1.206.243/3","191.2.139.113/22","252.3.217.172/11","146.4.106.152/26","229.5.65.223/16"
        $iprules.Count | Should -Be 7
        $iprules = Remove-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -IPAddressOrRange "20.11.0.0/16","232.0.18.177/7"
        $iprules.Count | Should -Be 5

        #Clean the VirtualNetworkRules, and add 6 Rules with string Array
        echo "Clean the VirtualNetworkRules, and add 2 Rules with string Array"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName -VirtualNetworkRule @()
        $rule.VirtualNetworkRules.Count | should -be 0
        $networkrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -VirtualNetworkResourceId $vnet1,$vnet2 
        $networkrule.Count | should -be 2
        $networkrule = Remove-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -VirtualNetworkResourceId $vnet1 
        $networkrule.Count | should -be 1
        $networkrule = Remove-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -VirtualNetworkResourceId $vnet2 
        $networkrule.Count | should -be 0
        $networkrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -VirtualNetworkResourceId $vnet1,$vnet2 
        $networkrule.Count | should -be 2

        #Clean the ResourceAccessRules, and add 2 Rules
        echo "Clean the ResourceAccessRules, and add 2 Rules"         
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName -ResourceAccessRule @() 
        $rule.ResourceAccessRules.Count | should -be 0
        $resrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -TenantId $config.credentials.tenantId -ResourceId $vnet1
        $resrule.Count | should -be 1
        $resrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -TenantId $config.credentials.tenantId -ResourceId $vnet2
        $resrule.Count | should -be 2
        $resrule = Remove-AzStorageAccountNetworkRule -ResourceGroupName $resourceGroupName -Name $accountName -TenantId $config.credentials.tenantId -ResourceId $vnet1
        $resrule.Count | should -be 1
       

        #Clean the IpRules on Account2, Pipeline to add IpRules from Account1 to Account2
        echo "Clean the IpRules on Account2, Pipeline to add IpRules from Account1 to Account2"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName2 -IPRule @()
        $rule.IpRules.Count | should -be 0
        # Add Unary Operators ",", see more detail in http://stackoverflow.com/questions/29973212/pipe-complete-array-objects-instead-of-array-items-one-at-a-time
        $iprules = (Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName).IpRules | Add-AzStorageAccountNetworkRule  -ResourceGroupName $resourceGroupName -Name $accountName2 
        $iprules.Count | Should -Be 5

        #Clean the ResourceAccessRule on Account2, Pipeline to add ResourceAccessRule from Account1 to Account2
        Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName2 -ResourceAccessRule @() 
        # Add Unary Operators "," to make the add-* cmdlet only run once to add all rules together, see more detail in http://stackoverflow.com/questions/29973212/pipe-complete-array-objects-instead-of-array-items-one-at-a-time
        ,((Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName).ResourceAccessRules) | Add-AzStorageAccountNetworkRule  -ResourceGroupName $resourceGroupName -Name $accountName2 
        $rule = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName
        $rule.ResourceAccessRules.Count | should -be 1

        #Set Bypass and DefaultAction for Account2
        echo "Set Bypass and DefaultAction for Account2"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName2 -DefaultAction Deny
        $rule.DefaultAction | should -be Deny
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName2 -Bypass Logging,Metrics -DefaultAction Allow
        $rule.Bypass | should -be "Logging, Metrics"
        $rule.DefaultAction | should -be Allow

        #Get Account2 NetworkACL, and show IpRules, VirtualNetworkRules
        echo "Get Account2 NetworkACL, and show IpRules, VirtualNetworkRules"
        $rule = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $resourceGroupName -Name $accountName
        $rule.Bypass | should -be AzureServices
        $rule.DefaultAction | should -be Allow
        $rule.IpRules.Count | should -be 5
        $rule.VirtualNetworkRules.Count | should -be 2
        $rule.ResourceAccessRules.Count | should -be 1
    
        #Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName| Remove-AzStorageAccount  -Force
        #Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName2 -Force

        $Error.Count | should -be 0
    }
    

    It "LifeCycle" {
        $Error.Clear()

        $rgname = "weitest";
        $accountName = "weiacl20"
        $accountname2 = "weiacl0"

        $id = $config.lifecycle.storageAccountResourceId

        # create Rule1
        $action1 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToArchive -daysAfterModificationGreaterThan 50 -DaysAfterLastTierChangeGreaterThan 40
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToCool -daysAfterCreationGreaterThan 30
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction Delete -daysAfterCreationGreaterThan 100
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction TierToArchive -daysAfterCreationGreaterThan 90 -DaysAfterLastTierChangeGreaterThan 30
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction TierToCool -daysAfterCreationGreaterThan 80
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BlobVersionAction Delete -daysAfterCreationGreaterThan 70
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BlobVersionAction TierToArchive -daysAfterCreationGreaterThan 60 -DaysAfterLastTierChangeGreaterThan 20
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BlobVersionAction TierToCool -daysAfterCreationGreaterThan 50
        $filter1 = New-AzStorageAccountManagementPolicyFilter -PrefixMatch prefix1,prefix2 #-SuffixMatch .jpg,.exe -SizeInByteLessThan 10000 -SizeInByteGreaterThan 100
        $rule1 = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action1 -Filter $filter1
        $rule1.Enabled | should -Be $true
        $rule1.Name | should -be Test
        $rule1.Definition.Actions.BaseBlob.TierToCool.daysAfterCreationGreaterThan | should -be 30
        $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan | should -be 50
        $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan | should -be 100
        $rule1.Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan | should -be 90
        $rule1.Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan | should -be 80
        $rule1.Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan | should -be 70
        $rule1.Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan | should -be 60
        $rule1.Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan | should -be 50
        $rule1.Definition.Filters.PrefixMatch.Count | should -be 2
        $rule1.Definition.Filters.BlobTypes.Count | should -be 1

        # create Rule2
        $action2 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
        # $action2 = Add-AzStorageAccountManagementPolicyAction -SnapshotAction Delete -daysAfterCreationGreaterThan 100
        # $action2 = Add-AzStorageAccountManagementPolicyAction -BlobVersionAction Delete -daysAfterCreationGreaterThan 100
        $filter2 = New-AzStorageAccountManagementPolicyFilter -BlobType appendBlob,blockBlob
        $rule2 = New-AzStorageAccountManagementPolicyRule -Name Test2 -Action $action2 -Filter $filter2 -Disabled
        $rule2.Enabled | should -Be $false
        $rule2.Name | should -be Test2
        $rule2.Definition.Actions.BaseBlob.TierToCool | should -be $null
        $rule2.Definition.Actions.BaseBlob.TierToArchive | should -be $null
        $rule2.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $rule2.Definition.Actions.Snapshot | should -be $null
        $rule2.Definition.Actions.Version | should -be $null
        $rule2.Definition.Filters.PrefixMatch | should -be $null
        $rule2.Definition.Filters.BlobTypes.Count | should -be 2

        # (Option 1) Set the 2 rules together
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -Rule $rule1,$rule2 
        $policy = Set-AzStorageAccountManagementPolicy -StorageAccountResourceId $id -Rule $rule1,$rule2 
        $policy.Rules.Count | should -Be 2
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Name | should -be Test
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.daysAfterCreationGreaterThan | should -be 30
        $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan | should -be 50
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 40
        $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan | should -be 100
        $policy.Rules[0].Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan | should -be 90
        $policy.Rules[0].Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 30
        $policy.Rules[0].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan | should -be 80
        $policy.Rules[0].Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan | should -be 70
        $policy.Rules[0].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan | should -be 60
        $policy.Rules[0].Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 20
        $policy.Rules[0].Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan | should -be 50
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 1
        $policy.Rules[1].Enabled | should -Be $false
        $policy.Rules[1].Name | should -be Test2
        $policy.Rules[1].Definition.Actions.BaseBlob.TierToCool | should -be $null
        $policy.Rules[1].Definition.Actions.BaseBlob.TierToArchive | should -be $null
        $policy.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $policy.Rules[1].Definition.Actions.Snapshot | should -be $null
        $policy.Rules[1].Definition.Actions.Version | should -be $null
        $policy.Rules[1].Definition.Filters.PrefixMatch | should -be $null
        $policy.Rules[1].Definition.Filters.BlobTypes.Count | should -be 2

        # (Option 2) Set Policy with 1 command
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -Policy (@{
            Rules=(@{
                Enabled=$true;
                Name="Test";
                Definition=(@{
                    Actions=(@{
                        BaseBlob=(@{
                            TierToCool=@{DaysAfterCreationGreaterThan=30};
                            TierToArchive=@{DaysAfterModificationGreaterThan=50;DaysAfterLastTierChangeGreaterThan=40};
                            Delete=@{DaysAfterModificationGreaterThan=100};
                        });
                        Snapshot=(@{
                            Delete=@{DaysAfterCreationGreaterThan=100}
                            TierToArchive=@{DaysAfterCreationGreaterThan=90;DaysAfterLastTierChangeGreaterThan=30};
                            TierToCool=@{DaysAfterCreationGreaterThan=80};
                        });
                        Version=(@{
                            Delete=@{DaysAfterCreationGreaterThan=70}
                            TierToArchive=@{DaysAfterCreationGreaterThan=60;DaysAfterLastTierChangeGreaterThan=20};
                            TierToCool=@{DaysAfterCreationGreaterThan=50};
                        });
                    });
                    Filters=(@{
                        BlobTypes=@("blockBlob");
                        PrefixMatch=@("con/prefix1","con/prefix2");
                    })
                })
            },
            @{
                Enabled=$false;
                Name="Test2";
                Definition=(@{
                    Actions=(@{
                        BaseBlob=(@{
                            Delete=@{DaysAfterModificationGreaterThan=100};
                        });
                    });
                    Filters=(@{
                        BlobTypes=@("blockBlob","appendblob");
                    })
                })
            })
        })
        $policy.Rules.Count | should -Be 2
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Name | should -be Test
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterCreationGreaterThan | should -be 30
        $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan | should -be 50
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 40
        $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan | should -be 100
        $policy.Rules[0].Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan | should -be 90
        $policy.Rules[0].Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 30
        $policy.Rules[0].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan | should -be 80
        $policy.Rules[0].Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan | should -be 70
        $policy.Rules[0].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan | should -be 60
        $policy.Rules[0].Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 20
        $policy.Rules[0].Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan | should -be 50
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 1
        $policy.Rules[1].Enabled | should -Be $false
        $policy.Rules[1].Name | should -be Test2
        $policy.Rules[1].Definition.Actions.BaseBlob.TierToCool | should -be $null
        $policy.Rules[1].Definition.Actions.BaseBlob.TierToArchive | should -be $null
        $policy.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $policy.Rules[1].Definition.Actions.Snapshot | should -be $null
        $policy.Rules[1].Definition.Actions.Version | should -be $null
        $policy.Rules[1].Definition.Filters.PrefixMatch | should -be $null
        $policy.Rules[1].Definition.Filters.BlobTypes.Count | should -be 2

        $policy2 = Get-AzStorageAccountManagementPolicy -StorageAccountResourceId $id | Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountname2
        $policy2.Rules.Count | should -Be 2

        $policy2 = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName2
        $policy2.Rules.Count | should -Be 2

        Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -PassThru

        get-Azstorageaccount -ResourceGroupName $rgname -Name $accountName | Remove-AzStorageAccountManagementPolicy      

        $Error.Count | should -be 0
    }
    

    It "new sku Kind： FileStorage (Premium_ZRS)" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName1 = "weinewsrp9"
        $accountName2 = "weinewsrp7"

        $account = new-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName1 -SkuName Premium_LRS -Location "westus" -Kind FileStorage  -AccessTier hot -EnableHttpsTrafficOnly $false         
        $account.ResourceGroupName | should -Be $rgname
        $account.StorageAccountName | should -Be $accountName1
        $account.Sku.Name | should -Be "Premium_LRS"
        $account.Location | should -Be "westus"
        $account.Kind | should -Be "FileStorage"

        $share2 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName1 -Name weitest2 -AccessTier Premium
        Assert-AreEqual $share2.AccessTier "Premium"
        $share2 = Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName1 -Name weitest2 -QuotaGiB 102 -Metadata @{"tag1" = "value1"; "tag2" = "value2"; "tag3" = "value3" } -AccessTier Premium
        Assert-AreEqual $share2.QuotaGiB 102
        Assert-AreEqual $share2.Metadata.Count 3
        Assert-AreEqual $share2.AccessTier "Premium"
        Assert-Null $share.ShareUsageBytes
        $share2 | Remove-AzRmStorageShare -Force


        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName1 -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "Managed File Share - Large File Share" {
        $Error.Clear()

      # Large File Share 
        $rgname = "weitry";
        $accountName = "weifileshare"
        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_LRS -Location "westus2" -Kind StorageV2 -EnableLargeFileShare #-debug
        $account.LargeFileSharesState | should -BeIn "Enabled",$null
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -EnableLargeFileShare #-SkuName Standard_LRS -UpgradeToStorageV2
        $account.LargeFileSharesState | should -BeIn "Enabled",$null

        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name bigtest -QuotaGiB 100001
        $share.QuotaGiB | should -be 100001

        #Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -Force

        # Managed File Share
        #$rgname = "weitry";
       # $accountName = "weifilestorage1"
        #New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Premium_LRS -Location 'Central US EUAP'  -Kind FileStorage -debug


        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest -QuotaGiB 101 -Metadata @{"tag1" = "value1"; "tag2" = "value2" } -AccessTier Cool
        Assert-AreEqual $share.QuotaGiB 101
        Assert-AreEqual $share.Metadata.Count 2
        Assert-AreEqual $share.AccessTier "Cool"
        Assert-Null $share.ShareUsageBytes
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName 
        Assert-AreEqual $true ($shares.Count -ge 1)
        $shares = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName | Get-AzRmStorageShare
        Assert-AreEqual $true ($shares.Count -ge 1)
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest
        Assert-AreEqual $share.QuotaGiB 101
        Assert-AreEqual $share.Metadata.Count 2
        Assert-Null $share.ShareUsageBytes
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest -GetShareUsage
        Assert-AreEqual $share.ShareUsageBytes 0
        $share = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName | Get-AzRmStorageShare -Name weitest -GetShareUsage
        Assert-AreEqual $share.ShareUsageBytes 0
        $share = Get-AzRmStorageShare -ResourceId $share.Id -GetShareUsage
        Assert-AreEqual $share.ShareUsageBytes 0
        $share = Get-AzRmStorageShare -ResourceId $share.Id  # -Name weitest 
        Assert-Null $share.ShareUsageBytes
        
        $account | New-AzRmStorageShare -Name testshare -AccessTier Hot
        $share = $account | Get-AzRmStorageShare -Name testshare
        Assert-AreEqual "Hot" $share.AccessTier
        $share = Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name bigtest -AccessTier Cool
        Assert-AreEqual "Cool" $share.AccessTier
        #$share = $share | Update-AzRmStorageShare  -AccessTier TransactionOptimized 
        #Assert-AreEqual "TransactionOptimized" $share.AccessTier
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name testsshare -Force      
     

        $share | Remove-AzRmStorageShare -Force
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "Identity SAS" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weirp1"
        $accountName2 = "weirp3"
        $containerName = "testcon"
    
        $ctx = New-AzStorageContext -StorageAccountName $accountName -UseConnectedAccount
        #$ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -AccountName $accountName).Context

        #Container SASPS 
        $StartTime = Get-Date
        $EndTime = $startTime.AddDays(6)
        $sas = New-AzStorageContainerSASToken -Name $containerName -Permission rwld  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime
        $ctxsas = New-AzStorageContext -StorageAccountName $accountName -SasToken $sas
        Get-AzStorageBlob -Container $containerName -MaxCount 10 -Context $ctxsas

        # Blob SAS
        $StartTime = Get-Date
        $EndTime = $startTime.AddDays(6)
        $blobsas = New-AzStorageBlobSASToken -Container $containerName -Blob test -Permission rwld -StartTime $StartTime -ExpiryTime $EndTime -context $ctx
        $ctxblobsas = New-AzStorageContext -StorageAccountName $accountName -SasToken $blobsas
        Get-AzStorageBlob -Container $containerName -Blob test -Context $ctxblobsas 

        # Copy blob cross tenant with 
        $destctx = New-AzStorageContext -StorageAccountName $accountName2
        Start-AzStorageBlobCopy -SrcContainer $containerName -SrcBlob test -Context $ctx -DestContainer $containerName -DestBlob test1 -DestContext $destctx -Force

        # Revoke will cause existing SAS not work
        Revoke-AzStorageAccountUserDelegationKeys -ResourceGroupName $rgname -AccountName $accountName
        sleep 30
        #should fail
        $Error.Count | should -be 0
        $error.Clear()
        Get-AzStorageBlob -Container $containerName -Blob test -Context $ctxblobsas  -ErrorAction SilentlyContinue
        $Error[0].Exception.Message.Contains("Server failed to authenticate the request. Make sure the value of Authorization header is formed correctly including the signature.") | should -Be $true
        
        $Error.Count | should -be 1
        $error.Clear()

        #create SAS again will work
        $sas = New-AzStorageContainerSASToken -Name $containerName -Permission rwld  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime
        $ctxsas = New-AzStorageContext -StorageAccountName $accountName -SasToken $sas
        Get-AzStorageBlob -Container $containerName -MaxCount 10 -Context $ctxsas | Out-Null
        $blobsas = New-AzStorageBlobSASToken -Container $containerName -Blob test -Permission rwld -StartTime $StartTime -ExpiryTime $EndTime -context $ctx
        $ctxblobsas = New-AzStorageContext -StorageAccountName $accountName -SasToken $blobsas
        Get-AzStorageBlob -Container $containerName -Blob test -Context $ctxblobsas | Out-Null
        
        $Error.Count | should -be 0
        $error.Clear()

        ### Error message
        $StartTime = Get-Date
        $EndTime = $startTime.AddDays(6)
        New-AzStorageContainerSASToken -Name $containerName  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime -Policy 123 -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "When input Storage Context is OAuth based, Saved Policy is not supported.*"
        New-AzStorageContainerSASToken -Name $containerName -Permission rwld  -context $ctx -StartTime $EndTime -ExpiryTime $StartTime.AddMinutes(1) -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "Start time * is later than expiry time *."
        New-AzStorageContainerSASToken -Name $containerName -Permission rwld  -context $ctx -StartTime $startTime.AddHours(-2) -ExpiryTime $startTime.AddHours(-1) -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "Expiry time * is earlier than now.*"
        New-AzStorageContainerSASToken -Name $containerName -Permission rwld  -context $ctx -StartTime $startTime -ExpiryTime $EndTime.AddDays(2) -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "Generate User Delegation SAS with OAuth bases Storage context. User Delegate Key expiry time * must be in 7 days from now.*"
        $Error.Count | should -be 4
        $error.Clear()

        
        ### Account SAS not work with Oauth
        New-AzStorageAccountSASToken -Service Blob -ResourceType Container,Object,Service -Permission rwld  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "Storage account SAS token must be secured with the storage account key.*"
        $Error.Count | should -be 1
        $error.Clear()

        $Error.Count | should -be 0
    }
    

    It "Queue/Table Encyrption Keytype, AllowSharedKeyAccess" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weiqtencryregression1"
        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_LRS -Location 'East US 2 EUAP' -Kind StorageV2  -EncryptionKeyTypeForTable Account -EncryptionKeyTypeForQueue Account -AllowSharedKeyAccess $false
        $account.Encryption.Services.Queue.Keytype | should -be "account"
        $account.Encryption.Services.Table.Keytype | should -be "account"
        $account.AllowSharedKeyAccess | Should -be $false

        $account = set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName  -AllowSharedKeyAccess $true  -AssignIdentity
        $account.AllowSharedKeyAccess | Should -be $true        
        $account.Encryption.Services.Queue.Keytype | should -be "account"
        $account.Encryption.Services.Table.Keytype | should -be "account"
        $account.Identity.Type | Should -Be "SystemAssigned"

        Remove-AzStorageAccount  -ResourceGroupName $rgname -StorageAccountName $accountName -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "key version" {
        $Error.Clear()

        #keyversion
        $storageAccountName = 'weiestest'
        $rgName = 'weitry';
        $KeyvaultUri = $config.keyVersion.keyVaultUri
        $keyname = "wrappingKey"
        $keyversion = $config.keyVersion.keyVersion

        $a = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -StorageEncryption
        Assert-AreEqual “Microsoft.Storage” $a.Encryption.KeySource

        # set keyvault without keyversion, to enable key rotation
        Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -KeyvaultEncryption -KeyVaultUri $KeyvaultUri -KeyName $keyname 
        $a = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName
        Assert-AreEqual “Microsoft.Keyvault” $a.Encryption.KeySource
        (New-Object -TypeName System.Uri -ArgumentList $KeyvaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host
        Assert-AreEqual $keyname  $a.Encryption.KeyVaultProperties.KeyName
        Assert-Null  $a.Encryption.KeyVaultProperties.KeyVersion

        # set keyvault with keyversion
        Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -KeyvaultEncryption -KeyVaultUri $KeyvaultUri -KeyName $keyname -KeyVersion $keyversion
        $a = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName
        Assert-AreEqual “Microsoft.Keyvault” $a.Encryption.KeySource
        (New-Object -TypeName System.Uri -ArgumentList $KeyvaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host
        Assert-AreEqual $keyname  $a.Encryption.KeyVaultProperties.KeyName
        Assert-AreEqual $keyversion  $a.Encryption.KeyVaultProperties.KeyVersion

        # clean up keyversion to enable key rotation
        Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -KeyvaultEncryption -KeyVaultUri $KeyvaultUri -KeyName $keyname -KeyVersion ""
        $a = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName
        Assert-AreEqual “Microsoft.Keyvault” $a.Encryption.KeySource
        (New-Object -TypeName System.Uri -ArgumentList $KeyvaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host
        Assert-AreEqual $keyname  $a.Encryption.KeyVaultProperties.KeyName
        Assert-AreEqual ""  $a.Encryption.KeyVaultProperties.KeyVersion    

        $Error.Count | should -be 0
    }
    

    It "doulbe Encryption" {
        $Error.Clear()

      #doulbe Encryption
      $accountNamegdoubleencry = "weidoubleencry" 
      New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegdoubleencry -SkuName Standard_LRS -Location "eastus2euap" -Kind StorageV2 -RequireInfrastructureEncryption
      $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegdoubleencry
      Assert-AreEqual $true $a.Encryption.RequireInfrastructureEncryption
      Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegdoubleencry -Force -Asjob

        $Error.Count | should -be 0
    }
    

    It "GZRS" {
        $Error.Clear()

        # GZRS
      $accountNamegzrs = "weigzrs1" 
      $accountNameragzrs = "weiragzrs1"    
        New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegzrs -SkuName Standard_GZRS -Location "eastus2euap" -Kind StorageV2 #-RequireInfrastructureEncryption
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegzrs
        $a.Sku.Name | should -Be "Standard_GZRS"
        set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegzrs -SkuName Standard_RAGZRS
        (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegzrs).Sku.Name | should -Be "Standard_RAGZRS"
        New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameragzrs -SkuName Standard_RAGZRS -Location "eastus2euap" -Kind StorageV2
        (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameragzrs).Sku.Name | should -Be "Standard_RAGZRS"
        set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameragzrs -SkuName Standard_GZRS
        (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameragzrs).Sku.Name | should -Be  "Standard_GZRS"
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamegzrs -Force -Asjob
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameragzrs -Force -Asjob

        $Error.Count | should -be 0
    }
    
    It "Failover "  -Skip {
        $Error.Clear()

        $RGName = "weitest"
        $AccountName = "weifailover"

        #New-AzStorageAccount -ResourceGroupName $RGName -Name $AccountName -SkuName Standard_RAGRS -Location "eastus2euap" -Kind StorageV2 
    
        set-AzStorageAccount -ResourceGroupName $RGName -Name $AccountName -SkuName Standard_RAGRS

        $a = get-AzStorageAccount -ResourceGroupName $RGName -Name $AccountName -IncludeGeoReplicationStats
        $a
        $a.GeoReplicationStats
    
        $taskfailover = Invoke-AzStorageAccountFailover -ResourceGroupName $RGName -Name $AccountName -Force -AsJob
        $taskfailover|Wait-Job

        $a = get-AzStorageAccount -ResourceGroupName $RGName -Name $AccountName
        Assert-AreEqual "Standard_LRS" $a.Sku.Name

        Set-AzStorageAccount -ResourceGroupName $RGName -Name $AccountName -SkuName Standard_RAGRS
        #$a | Remove-AzStorageAccount -Force -Asjob

        $Error.Count | should -be 0
    }
    
    It "MinimumTlsVersion , AllowBlobPublicAccess" {
        $Error.Clear()
         
        $rgname = "weitry";
        $AccountName = "weimintls"
        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_GRS -Location "westus" -Kind StorageV2  -MinimumTlsVersion TLS1_1 -AllowBlobPublicAccess $false
        Assert-AreEqual "TLS1_1" $a.MinimumTlsVersion
        Assert-AreEqual $false $a.AllowBlobPublicAccess
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -MinimumTlsVersion TLS1_2 -AllowBlobPublicAccess $true -EnableHttpsTrafficOnly $true
        Assert-AreEqual "TLS1_2" $a.MinimumTlsVersion
        Assert-AreEqual $true $a.AllowBlobPublicAccess
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -AsJob -Force


        $Error.Count | should -be 0
    }
    
    It "versioning , changefeed" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weibstest"
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableChangeFeed $true -IsVersioningEnabled $true -ChangeFeedRetentionInDays 3
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName
        $p.ChangeFeed.Enabled | should -be $true
        $p.ChangeFeed.RetentionInDays | should -be 3
        $p.IsVersioningEnabled | should -be $true
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableChangeFeed $false -IsVersioningEnabled $false 
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        $p.ChangeFeed.Enabled | should -be $false
        $p.IsVersioningEnabled | should -be $false

        $Error.Count | should -be 0
    }
    
    It "ORS" -Tag "2021-5-25" {
        $Error.Clear()

        $rgname = "weitry";
        $destAccountName = "weiors4"
        $srcAccountName = "weiors3"

        if ($Needprepare)
        {
            New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName -SkuName Standard_LRS -Location EastUs2
            New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName -SkuName Standard_LRS -Location EastUs2

             Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName 
             Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName

            Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $destAccountName -IsVersioningEnabled $false -EnableChangeFeed $true
            Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $srcAccountName -IsVersioningEnabled $true -EnableChangeFeed $true
             Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $destAccountName
             Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $srcAccountName

            # prepare
            update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $srcAccountName -EnableChangeFeed $true
            Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName | New-AzStorageContainer src
            Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName | New-AzStorageContainer dest
            Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName | New-AzStorageContainer src1
            Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName | New-AzStorageContainer dest1


            $ctxsrc = (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName).Context
            $ctxdest = (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName).Context

            Set-AzStorageBlobContent -Container src1 -File D:\TestBlob1 -Blob testors -Context $ctxsrc

            Set-AzStorageBlobContent -Container dest1 -File D:\TestBlob1 -Blob testors -Context $ctxdest
        }
        
        # enable AllowCrossTenantReplication
        $destaccount = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName -AllowCrossTenantReplication $true -EnableHttpsTrafficOnly $True
        $srcaccount = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName -AllowCrossTenantReplication $true -EnableHttpsTrafficOnly $True
        $destaccount.AllowCrossTenantReplication | should -be $true
        $srcaccount.AllowCrossTenantReplication | should -be $true

        $rule1 = New-AzStorageObjectReplicationPolicyRule -SourceContainer src1 -DestinationContainer dest1 
        $rule2 = New-AzStorageObjectReplicationPolicyRule -SourceContainer src -DestinationContainer dest -MinCreationTime "2019-01-02T00:00:00Z" -PrefixMatch a,abc,dd 

        #Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName -PolicyId default -SourceAccount $srcAccountName -DestinationAccount $destAccountName -Rule $rule1,$rule2 -debug
        $destPolicy = Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName -PolicyId default -SourceAccount $srcAccountName  -Rule $rule1,$rule2 
        $destPolicy.Rules
        Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $srcAccountName -InputObject $destPolicy

        # check policy
        $destPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName  # -debug
        Assert-AreEqual $srcAccountName $destPolicy.SourceAccount
        Assert-AreEqual $destAccountName $destPolicy.DestinationAccount
        $destPolicy.PolicyId | should -Not -be $null 
        Assert-AreEqual 2 $destPolicy.Rules.Count
        Assert-AreEqual "src1" $destPolicy.Rules[0].SourceContainer
        Assert-AreEqual "dest1" $destPolicy.Rules[0].DestinationContainer
        $destPolicy.Rules[0].RuleId  | should -Not -be $null 
        Assert-AreEqual $null $destPolicy.Rules[0].Filters 
        Assert-AreEqual "src" $destPolicy.Rules[1].SourceContainer
        Assert-AreEqual "dest" $destPolicy.Rules[1].DestinationContainer 
        $destPolicy.Rules[1].RuleId  | should -Not -be $null 
        Assert-AreEqual 3 $destPolicy.Rules[1].Filters.PrefixMatch.Count
        Assert-AreEqual "2019-01-02T00:00:00Z" ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")
        $policyId = $destPolicy[0].PolicyId

        $srcPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $srcAccountName -PolicyId $policyId
        Assert-AreEqual $srcAccountName $srcPolicy.SourceAccount
        Assert-AreEqual $destAccountName $srcPolicy.DestinationAccount
        Assert-AreEqual $policyId $srcPolicy.PolicyId
        Assert-AreEqual 2 $srcPolicy.Rules.Count
        Assert-AreEqual "src1" $srcPolicy.Rules[0].SourceContainer
        Assert-AreEqual "dest1" $srcPolicy.Rules[0].DestinationContainer
        $srcPolicy.Rules[0].RuleId  | should -Not -be $null 
        Assert-AreEqual $null $srcPolicy.Rules[0].Filters 
        Assert-AreEqual "src" $srcPolicy.Rules[1].SourceContainer
        Assert-AreEqual "dest" $srcPolicy.Rules[1].DestinationContainer 
        $srcPolicy.Rules[1].RuleId  | should -Not -be $null 
        Assert-AreEqual 3 $srcPolicy.Rules[1].Filters.PrefixMatch.Count
        Assert-AreEqual "2019-01-02T00:00:00Z" ($srcPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")
    
        # Validate dataplane
        $ctxsrc = (Get-AzStorageAccount  -ResourceGroupName $rgname -StorageAccountName $srcAccountName ).Context
        $ctxdest = (Get-AzStorageAccount  -ResourceGroupName $rgname -StorageAccountName $destAccountName ).Context
        $blobdest = Get-AzStorageBlob -Container dest1 -Blob testors -Context $ctxdest
        $blobdest.BlobProperties.ObjectReplicationDestinationPolicyId  | should -Not -be $null 
        Assert-Null $blobdest.BlobProperties.ObjectReplicationSourceProperties
        $blobsrc = Get-AzStorageBlob -Container src1 -Blob testors -Context $ctxsrc
        Assert-Null $blobsrc.BlobProperties.ObjectReplicationDestinationPolicyId
        $blobsrc.BlobProperties.ObjectReplicationSourceProperties[0].PolicyId | should -Not -be $null 
        $blobsrc.BlobProperties.ObjectReplicationSourceProperties[0].Rules[0].RuleId | should -Not -be $null 
        Assert-AreEqual "Complete" $blobsrc.BlobProperties.ObjectReplicationSourceProperties[0].Rules[0].ReplicationStatus

        #remove ors policy
        Remove-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName -PolicyId $policyId
        Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName | Remove-AzStorageObjectReplicationPolicy -PolicyId $policyId
        
        # Disable AllowCrossTenantReplication
        $destaccount = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName -AllowCrossTenantReplication $false -EnableHttpsTrafficOnly $True
        $srcaccount = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName -AllowCrossTenantReplication $false -EnableHttpsTrafficOnly $True
        $destaccount.AllowCrossTenantReplication | should -be $false
        $srcaccount.AllowCrossTenantReplication | should -be $false

         #Set policy
        $destPolicy = Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName -PolicyId default -SourceAccount $srcaccount.Id  -Rule $rule1,$rule2 
        $destPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName
        Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $srcAccountName -InputObject $destPolicy

        # check policy
        $destPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName  # -debug
        Assert-AreEqual $srcaccount.Id $destPolicy.SourceAccount
        Assert-AreEqual $destaccount.Id $destPolicy.DestinationAccount
        $destPolicy.PolicyId | should -Not -be $null 
        Assert-AreEqual 2 $destPolicy.Rules.Count
        Assert-AreEqual "src1" $destPolicy.Rules[0].SourceContainer
        Assert-AreEqual "dest1" $destPolicy.Rules[0].DestinationContainer
        $destPolicy.Rules[0].RuleId  | should -Not -be $null 
        Assert-AreEqual $null $destPolicy.Rules[0].Filters 
        Assert-AreEqual "src" $destPolicy.Rules[1].SourceContainer
        Assert-AreEqual "dest" $destPolicy.Rules[1].DestinationContainer 
        $destPolicy.Rules[1].RuleId  | should -Not -be $null 
        Assert-AreEqual 3 $destPolicy.Rules[1].Filters.PrefixMatch.Count
        Assert-AreEqual "2019-01-02T00:00:00Z" ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")
        $policyId = $destPolicy[0].PolicyId

        $srcPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $srcAccountName -PolicyId $policyId
        Assert-AreEqual $srcaccount.Id $srcPolicy.SourceAccount
        Assert-AreEqual $destaccount.Id $srcPolicy.DestinationAccount
        Assert-AreEqual $policyId $srcPolicy.PolicyId
        Assert-AreEqual 2 $srcPolicy.Rules.Count
        Assert-AreEqual "src1" $srcPolicy.Rules[0].SourceContainer
        Assert-AreEqual "dest1" $srcPolicy.Rules[0].DestinationContainer
        $srcPolicy.Rules[0].RuleId  | should -Not -be $null 
        Assert-AreEqual $null $srcPolicy.Rules[0].Filters 
        Assert-AreEqual "src" $srcPolicy.Rules[1].SourceContainer
        Assert-AreEqual "dest" $srcPolicy.Rules[1].DestinationContainer 
        $srcPolicy.Rules[1].RuleId  | should -Not -be $null 
        Assert-AreEqual 3 $srcPolicy.Rules[1].Filters.PrefixMatch.Count
        Assert-AreEqual "2019-01-02T00:00:00Z" ($srcPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")

        #remove ors policy
        Remove-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $destAccountName -PolicyId $policyId
        Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName | Remove-AzStorageObjectReplicationPolicy -PolicyId $policyId

        $Error.Count | should -be 0
    }
    
    It "File AD - need user interaction" -Skip {
        $Error.Clear()

        # File AD
        Add-AzAccount -Tenant a1250d0e-e3a7-4f9e-8f99-013873b0d6ab
         #User Name: weiwei@microsoft.com
        Get-AzStorageAccount | ?{$_.StorageAccountName -like "wei*"}

        $rgname = "aadrg"
        $accountName = "weifilead12"
        $accountName2 = "weifileadd2"
        $accountName3 = "weifilead3"
        $accountName4 = "weifilead4"
        $accountName5 = "weifileaad5"

    
        $DomainName = $config.fileAD.domainName
        $NetBiosDomainName = $config.fileAD.netBiosDomainName
        $ForestName = $config.fileAD.forestName
        $DomainGuid = $config.fileAD.domainGuid
        $DomainSid = $config.fileAD.domainSid
        $AzureStorageSid = $config.fileAD.azureStorageSid
   
       #Disable AD on new account
       New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -SkuName Standard_GRS -Location "centralus" -Kind StorageV2 
       $a2 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 
       Assert-Null $a2.AzureFilesIdentityBasedAuth
       Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -EnableActiveDirectoryDomainServicesForFile $false
       $a2 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 
       Assert-AreEqual "None" $a2.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
       Assert-Null $a2.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties 

       #Disable AADDS on new account
       new-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName3 -SkuName Standard_GRS -Location "centraluse" -Kind StorageV2 
       $a3 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName3 
       Assert-Null $a3.AzureFilesIdentityBasedAuth
       Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName3 -EnableAzureActiveDirectoryDomainServicesForFile $false 
       $a3 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName3 
       Assert-AreEqual "None" $a3.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
       Assert-Null $a3.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties 

       # Enable AD on new account
        $job = new-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName4 -SkuName Standard_GRS -Location "centraluseuap" -Kind StorageV2 -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State 
       $a4 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName4 
       Assert-Null $a4.AzureFilesIdentityBasedAuth
        $job = $a4 | Set-AzStorageAccount -EnableActiveDirectoryDomainServicesForFile $true `
            -ActiveDirectoryDomainName $DomainName `
            -ActiveDirectoryNetBiosDomainName $NetBiosDomainName `
            -ActiveDirectoryForestName $ForestName `
            -ActiveDirectoryDomainGuid $DomainGuid `
            -ActiveDirectoryDomainSid $DomainSid `
            -ActiveDirectoryAzureStorageSid $AzureStorageSid `
            -ActiveDirectorySamAccountName "weisamaccount" `
            -ActiveDirectoryAccountType User  `
            -DefaultSharePermission StorageFileDataSmbShareElevatedContributor -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a4 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName4 
        $a4.AzureFilesIdentityBasedAuth | should -Not -be $null 
        Assert-AreEqual "AD" $a4.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        $a4.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties  | should -Not -be $null 
        $a4.AzureFilesIdentityBasedAuth.DefaultSharePermission | should -be StorageFileDataSmbShareElevatedContributor
        $a4.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.SamAccountName | should -Be "weisamaccount"
        $a4.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.AccountType | should -Be "User"
    
       # Enable AADDS on new account
       $job = new-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName5 -SkuName Standard_GRS -Location "centraluseuap" -Kind StorageV2 -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
       $a5 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName5 
       Assert-Null $a5.AzureFilesIdentityBasedAuth
       $job = $a5 | Set-AzStorageAccount -EnableAzureActiveDirectoryDomainServicesForFile $true -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a5 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName5 
        $a5.AzureFilesIdentityBasedAuth | should -Not -be $null 
        Assert-AreEqual "AADDS" $a5.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        $a5.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties  | should -Not -be $null 
   
       # Create Account with AD, and update 
       $job = new-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_GRS -Location "centraluseuap" -Kind Storage -EnableActiveDirectoryDomainServicesForFile $true `
            -ActiveDirectoryDomainName $DomainName `
            -ActiveDirectoryNetBiosDomainName $NetBiosDomainName `
            -ActiveDirectoryForestName $ForestName `
            -ActiveDirectoryDomainGuid $DomainGuid `
            -ActiveDirectoryDomainSid $DomainSid `
            -ActiveDirectoryAzureStorageSid $AzureStorageSid `
            -ActiveDirectorySamAccountName "samaccountname" `
            -ActiveDirectoryAccountType Computer `
            -DefaultSharePermission StorageFileDataSmbShareContributor -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName 
        $a
        Assert-AreEqual "AD"  $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties  | should -Not -be $null 
        $a.AzureFilesIdentityBasedAuth.DefaultSharePermission | should -be StorageFileDataSmbShareContributor
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.SamAccountName | should -Be "samaccountname"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.AccountType | should -Be "Computer"
    
        Get-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName -ListKerbKey
        New-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName -KeyName kerb1
        Get-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName -ListKerbKey
        New-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName -KeyName kerb2
        Get-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountName -ListKerbKey

        $job = $a | Set-AzStorageAccount -EnableActiveDirectoryDomainServicesForFile $false -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName 
        Assert-AreEqual "None" $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        Assert-Null $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties 

                sleep 60    

        $job = $a | Set-AzStorageAccount -EnableAzureActiveDirectoryDomainServicesForFile $true -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a = get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName    
        Assert-AreEqual "AADDS" $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        Assert-Null $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties 
        

        $job = $a5 | Set-AzStorageAccount -EnableAzureActiveDirectoryDomainServicesForFile $false  -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a5 = get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName5  
        Assert-AreEqual "None" $a5.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        Assert-Null $a5.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties 

                sleep 60

        $job = $a5 | Set-AzStorageAccount -EnableActiveDirectoryDomainServicesForFile $true `
            -ActiveDirectoryDomainName $DomainName `
            -ActiveDirectoryNetBiosDomainName $NetBiosDomainName `
            -ActiveDirectoryForestName $ForestName `
            -ActiveDirectoryDomainGuid $DomainGuid `
            -ActiveDirectoryDomainSid $DomainSid `
            -ActiveDirectoryAzureStorageSid $AzureStorageSid -asjob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $a5 = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName5 
        Assert-AreEqual "AD" $a5.AzureFilesIdentityBasedAuth.DirectoryServiceOptions
        $a5.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties  | should -Not -be $null 
    
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -Force -asjob
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -Force -asjob
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName3 -Force -asjob
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName4 -Force -asjob
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName5 -Force -asjob

        $Error.Count | should -be 0
    }    

    It "PITR" -Tag "PITR","longrunning" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "wei"+(Get-Date).Ticks
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -SkuName Standard_LRS -Location eastus2euap
        Enable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -RetentionDays 5
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableChangeFeed $true -IsVersioningEnabled $true
        Enable-AzStorageBlobRestorePolicy -ResourceGroupName $rgname -StorageAccountName $accountName -RestoreDays 4 -PassThru
        $properties = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        $properties.DeleteRetentionPolicy.Enabled | should -Be $true
        $properties.DeleteRetentionPolicy.Days | should -Be 5
        $properties.RestorePolicy.Enabled | should -Be $true
        $properties.RestorePolicy.Days | should -Be 4
        $properties.ChangeFeed.Enabled | should -Be $true


        # [start, end）
        $range1 = New-AzStorageBlobRangeToRestore -StartRange container1/blob1 -EndRange container2/blob2
        $range2 = New-AzStorageBlobRangeToRestore -StartRange container3/blob3 -EndRange container4/blob4
        #$range2 = New-AzStorageBlobRangeToRestore -StartRange "" -EndRange ""
        #$range = New-AzStorageBlobRangeToRestore -EndRange container1/blob1
        
        sleep 70  
        $timeToRestore = (Get-Date).AddSeconds(-1)
        $job = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $accountName -TimeToRestore $timeToRestore -BlobRestoreRange $range1,$range2 -WaitForComplete -asjob 
        $job | wait-job
        $job.State | should -be "Completed" 
        $job.Output[0].RestoreId.Length | should -Be 36 # should be GUID format
        $job.Output[0].FailureReason | should -be $null
       # $job.Output[0].Parameters.TimeToRestore | should -be (new-object System.DateTimeOffset -ArgumentList $timeToRestore)
        $job.Output[0].Parameters.BlobRanges.Count | should -be 2
        $job.Output[0].Parameters.BlobRanges[0].StartRange | should -be $range1.StartRange
        $job.Output[0].Parameters.BlobRanges[0].EndRange | should -be $range1.EndRange
        $job.Output[0].Parameters.BlobRanges[1].StartRange | should -be $range2.StartRange
        $job.Output[0].Parameters.BlobRanges[1].EndRange | should -be $range2.EndRange

        if ($false){
            $job = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $accountName `
                -TimeToRestore (Get-Date).AddSeconds(-1) `
                -BlobRestoreRange (@{StartRange="aaa/abc";EndRange="bbb/abc"},@{StartRange="bbb/acc";EndRange=""}) -asjob 
            $job | wait-job
            $job.State | should -be "Completed" 
        }
        
        $timeToRestore = (Get-Date).AddMinutes(-1)
        $status = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $accountName `
            -TimeToRestore $timeToRestore `
            -BlobRestoreRange (@{StartRange="";EndRange=""}) 
        $status.RestoreId.Length | should -Be 36 # should be GUID format
        $status.FailureReason | should -be $null
        $status.Parameters.TimeToRestore | should -be (new-object System.DateTimeOffset -ArgumentList $timeToRestore)
        $status.Parameters.BlobRanges.Count | should -be 1
        $status.Parameters.BlobRanges[0].StartRange | should -be ""
        $status.Parameters.BlobRanges[0].EndRange | should -be ""
        sleep 10
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName  -IncludeBlobRestoreStatus 
        $a.BlobRestoreStatus.Status | should -be "InProgress" 
        $a.BlobRestoreStatus.RestoreId | should -Be $status.RestoreId
        #$a.BlobRestoreStatus.Parameters.TimeToRestore | should -be (new-object System.DateTimeOffset -ArgumentList $timeToRestore)
        while ($a.BlobRestoreStatus.Status -eq "InProgress")
        {        
            sleep 10
            $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName  -IncludeBlobRestoreStatus 
            $a.BlobRestoreStatus.RestoreId | should -Be $status.RestoreId
            $a.BlobRestoreStatus.FailureReason | should -be $null
            #$a.BlobRestoreStatus.Parameters.TimeToRestore | should -be (new-object System.DateTimeOffset -ArgumentList $timeToRestore)
            $a.BlobRestoreStatus.Parameters.BlobRanges.Count | should -be 1
            $a.BlobRestoreStatus.Parameters.BlobRanges[0].StartRange | should -be ""
            $a.BlobRestoreStatus.Parameters.BlobRanges[0].EndRange | should -be ""
        }
        $a.BlobRestoreStatus.Status | should -be "Complete" 

        sleep 20
        
        $Error.Count | should -be 0

        Disable-AzStorageBlobRestorePolicy -ResourceGroupName $rgname -StorageAccountName $accountName -ErrorAction SilentlyContinue  
        $properties = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        $properties.RestorePolicy.Enabled | should -Be $false
        
        $Error.Clear()
        $Error.Count | should -be 0
    }
    
    It "Share Soft delete" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weifilestorage1"
        $shareName1 = "test01"
        $shareName2 = "test02"

        #Enable softdlete
        Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 1 #-debug
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        {$p.ShareDeleteRetentionPolicy.Enabled} | should -be $true
        Assert-AreEqual 1 $p.ShareDeleteRetentionPolicy.Days

        $Originshares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -IncludeDeleted 
        $OriginNotdeleteshares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName 

        # create 2 shares and revmove 1
        New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName1
        New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName2

        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName1 -Force

        # list all shares include the deleted ones
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName 
        Assert-AreEqual ($OriginNotdeleteshares.count+1) $shares.count
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -IncludeDeleted 
        Assert-AreEqual ($Originshares.count+2) $shares.count

        # get single share
        $share2 = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName2 -GetShareUsage
        $share2.ShareUsageBytes | should -be 0

        # find one deleted share
        $deletedshare = (Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -IncludeDeleted | ? {($_.Deleted) -and ($_.Name -eq $shareName1)})[0]
        Assert-AreEqual $true $deletedshare.Deleted

        #restore the share
        sleep 30
        Restore-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName1 -DeletedShareVersion $deletedshare.Version


        #list shares
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName 
        Assert-AreEqual ($OriginNotdeleteshares.count+2) $shares.count

        #Disable softdlete
        Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableShareDeleteRetentionPolicy $false
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        {!$p.ShareDeleteRetentionPolicy.Enabled} | should -be $true

        #remove shares
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName1 -Force
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name $shareName2 -Force

        $Error.Count | should -be 0
    }
  
    It "EnryptionScope" {
        $Error.Clear()

        $storageAccountName = 'weiestest'
        $rgName = 'weitry';
        $scopename = "testscope"
        $msscopename = "mstestscope1"
        $KeyUri = $config.encryptionScope.keyUri.keyUri1
        $KeyUri2 = $config.encryptionScope.keyUri.keyUri2
        $KeyUri3 = $config.encryptionScope.keyUri.keyUri3
        $scope = New-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -EncryptionScopeName $msscopename -StorageEncryption -RequireInfrastructureEncryption 
        $scope.Name | should -be $msscopename
        $scope.Source  | should -be "Microsoft.Storage" 
        $scope.RequireInfrastructureEncryption | should -be $true
        $scope2 = New-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri
        Assert-AreEqual $scopename $scope2.Name
        Assert-AreEqual "Microsoft.Keyvault"  $scope2.Source
        $scope2.KeyVaultProperties.keyUri | should -BeLike $KeyUri.Replace(":443","*") 
        $scope2 = New-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri2
        Assert-AreEqual $scopename $scope2.Name
        Assert-AreEqual "Microsoft.Keyvault"  $scope2.Source
        (New-Object -TypeName System.Uri -ArgumentList $scope2.KeyVaultProperties.keyUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $KeyUri2).Host

        # Update Storage account
        Set-AzStorageAccount -ResourceGroupName $rgName -StorageAccountName $storageAccountName -StorageEncryption
        Set-AzStorageAccount -ResourceGroupName $rgName -StorageAccountName $storageAccountName -KeyvaultEncryption -KeyName wrappingKey2 -KeyVaultUri $config.encryptionScope.keyVaultUri
        $a = Get-AzStorageAccount -ResourceGroupName $rgName -StorageAccountName $storageAccountName
        (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $config.encryptionScope.argumentList).Host
        Assert-AreEqual "wrappingKey2" $a.Encryption.KeyVaultProperties.KeyName
        Assert-AreEqual "Microsoft.Keyvault" $a.Encryption.KeySource

        Set-AzStorageAccount -ResourceGroupName $rgName -StorageAccountName $storageAccountName -KeyvaultEncryption -KeyName wrappingKey -KeyVaultUri $config.encryptionScope.keyVaultUri -KeyVersion $config.encryptionScope.keyVersion
        $a = Get-AzStorageAccount -ResourceGroupName $rgName -StorageAccountName $storageAccountName
        (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $config.encryptionScope.argumentList).Host
        Assert-AreEqual "wrappingKey" $a.Encryption.KeyVaultProperties.KeyName
        Assert-AreEqual  $config.encryptionScope.keyVersion $a.Encryption.KeyVaultProperties.KeyVersion
        Assert-AreEqual "Microsoft.Keyvault" $a.Encryption.KeySource

        Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName | New-AzStorageEncryptionScope  -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri

        #get single scope
        Get-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename

        Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName | Get-AzStorageEncryptionScope -EncryptionScopeName $scopename

        #list scope, will list all scopes
        Get-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName 
        Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName | Get-AzStorageEncryptionScope 

        # Set to Disabled.
        ### Move the encryption scope to CMK by passing { 'properties': { 'state':'Disabled' } }
        $scope = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName | Update-AzStorageEncryptionScope -EncryptionScopeName $scopename -State Disabled 
        Assert-AreEqual "Disabled" $scope.State

        # Set to Enabled.
        ### Move the encryption scope to CMK by passing { 'properties': { 'state':'Enabled' } }
        $scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename -State Enabled 
        Assert-AreEqual "Enabled" $scope.State

        # Set to CMK.
        ### Move the encryption scope to CMK by passing { 'properties': { 'source':'Microsoft.KeyVault', 'keyVaultProperties':{ 'keyUri': '$key.Key.Kid' } } }
        $scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri
        Assert-AreEqual "Microsoft.Keyvault"  $scope.Source

        # Back to MMK, might fail for server issue with 400
        ### Move the encryption scope back to Microsoft Managed Keys by passing { 'properties': { 'source':'Microsoft.Storage' } }
        $scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgName -StorageAccountName $storageAccountName -Name $scopename -StorageEncryption 
        Assert-AreEqual "Microsoft.Storage"  $scope.Source

        # create container
        $c = New-AzRmStorageContainer -ResourceGroupName $rgName -StorageAccountName $storageAccountName -Name testcontainer -DefaultEncryptionScope $scopename -PreventEncryptionScopeOverride $true 
            Assert-AreEqual $scopeName $c.DefaultEncryptionScope
            Assert-AreEqual $true $c.DenyEncryptionScopeOverride
        remove-AzRmStorageContainer -ResourceGroupName $rgName -StorageAccountName $storageAccountName -Name testcontainer -Force
        $Error.Count | should -be 0
    } 

    It "Routing preference" {
        $Error.Clear()
        
        $rgname = "weitry";
        $accountName = "weirp4"


        #create account 
        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_LRS -Location "centraluseuap" -Kind StorageV2 -PublishMicrosoftEndpoint $true -PublishInternetEndpoint $true -RoutingChoice MicrosoftRouting
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob  | should -Not -be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob  | should -Not -be $null
        Assert-AreEqual "MicrosoftRouting"  $a.RoutingPreference.RoutingChoice
        {$a.RoutingPreference.PublishInternetEndpoints} | should -be $true
        {$a.RoutingPreference.PublishMicrosoftEndpoints} | should -be $true

        #get Account property
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | should -Not -be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -Not -be $null
        Assert-AreEqual "MicrosoftRouting"  $a.RoutingPreference.RoutingChoice
        {$a.RoutingPreference.PublishInternetEndpoints} | should -be $true
        {$a.RoutingPreference.PublishMicrosoftEndpoints} | should -be $true

        # update account
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -RoutingChoice InternetRouting -PublishMicrosoftEndpoint $false -PublishInternetEndpoint $false 
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | should -be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -be $null
        Assert-AreEqual "InternetRouting"  $a.RoutingPreference.RoutingChoice
        {!$a.RoutingPreference.PublishInternetEndpoints} | should -be $true
        {!$a.RoutingPreference.PublishMicrosoftEndpoints} | should -be $true
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -RoutingChoice MicrosoftRouting 
        Assert-Null $a.PrimaryEndpoints.MicrosoftEndpoints.Blob
        Assert-Null $a.PrimaryEndpoints.InternetEndpoints.Blob
        Assert-AreEqual "MicrosoftRouting"  $a.RoutingPreference.RoutingChoice
        {!$a.RoutingPreference.PublishInternetEndpoints} | should -be $true
        {!$a.RoutingPreference.PublishMicrosoftEndpoints} | should -be $true
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -PublishInternetEndpoint  $true
        Assert-Null $a.PrimaryEndpoints.MicrosoftEndpoints.Blob
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -Not -be $null
        Assert-AreEqual "MicrosoftRouting"  $a.RoutingPreference.RoutingChoice
        {$a.RoutingPreference.PublishInternetEndpoints} | should -be $true
        {!$a.RoutingPreference.PublishMicrosoftEndpoints}  | should -be $true
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -PublishMicrosoftEndpoint $true 
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | should -Not -be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -Not -be $null
        Assert-AreEqual "MicrosoftRouting"  $a.RoutingPreference.RoutingChoice
        {$a.RoutingPreference.PublishInternetEndpoints} | should -be $true
        {$a.RoutingPreference.PublishMicrosoftEndpoints}  | should -be $true

        # clean up
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -AsJob -Force

        $Error.Count | should -be 0
    }    
    
    It "Key SAS Policy" {
        $Error.Clear()

        $storageAccountName = 'weikeysaspolicy2'
        $rgName = 'weitry';

        $a = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Kind StorageV2 -SkuName Standard_LRS -Location eastus -KeyExpirationPeriodInDay 5 -SasExpirationPeriod "1.12:05:06" 
        $a.KeyCreationTime.Key1 | should -Not -Be $null
        $a.SasPolicy.SasExpirationPeriod | should -Be "1.12:05:06"
        $a.KeyPolicy.KeyExpirationPeriodInDays | should -Be 5
        $a = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName  -KeyExpirationPeriodInDay 60 -SasExpirationPeriod "11.11:12:36"  -EnableHttpsTrafficOnly $true 
        $a.SasPolicy.SasExpirationPeriod | should -Be "11.11:12:36"
        $a.KeyPolicy.KeyExpirationPeriodInDays | should -Be 60
        $a = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName  -KeyExpirationPeriodInDay 0 -SasExpirationPeriod "0.00:00:00"  -EnableHttpsTrafficOnly $true 
        $a.SasPolicy | should -Be $null
        $a.KeyPolicy | should -Be $null

        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Force -AsJob

        $Error.Count | should -be 0
    }   
    
    It "Extend Location" {
        $Error.Clear()

        $resourceGroupName = "weitest"
        $accountName = "weiextendlocation3"

        $a = New-AzStorageAccount -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName  -SkuName Premium_LRS -Location westus -EdgeZone "microsoftlosangeles1"
        $a.ExtendedLocation.Type | should -Be "EdgeZone"
        $a.ExtendedLocation.Name | should -Be "microsoftlosangeles1"

        remove-AzStorageAccount -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName -Force -asjob

        $Error.Count | should -be 0
    } 
    
    It "User identity" -tag "longrunning" {
        $Error.Clear()

        $t = Get-AzResourceGroup |  ? {$_.ResourceGroupName -like "weiuid*"} | Remove-AzResourceGroup -Force -asjob

        $rgName = 'weiuid1';
        $keyvaultName = "weiestestkeyvault10"
        $keyvaultUri = "https://$($keyvaultName).vault.azure.net:443"
        $keyname = "wrappingKey"
        $keyversion = $config.userIdentity.keyVersion.keyVersion1
        $keyvaultName2 = "weikeyvault11"
        $keyvaultUri2 = "https://$($keyvaultName2).vault.azure.net:443"
        $keyname2 = "wrappingKey"
        $keyversion2 = $config.userIdentity.keyVersion.keyVersion2

        $useridentity= $config.userIdentity.userIdentity.userIdentity1
        $useridentity2= $config.userIdentity.userIdentity.userIdentity2

        $accountNamePrefix = "weiuserid10"

        try
        {
        New-AzResourceGroup -Name $rgName -Location eastus2 -Force

        if ($false)
        {
             # login
                 $secpasswd = ConvertTo-SecureString $config.credentials.secpwd -AsPlainText -Force
                 $cred = New-Object System.Management.Automation.PSCredential ($config.credentials.username, $secpasswd)
                 Add-AzAccount -ServicePrincipal -Tenant $config.credentials.tenantId -SubscriptionId $config.credentials.subscriptionId -Credential $cred 

            # prepare keyvault  
                $location =  'eastus2'; 

                $keyVault = New-AzKeyVault -VaultName $keyvaultName -ResourceGroupName $rgName -Location $location -EnablePurgeProtection
                # give service principle "weiwei's AAD app" (d6f7e858-345d-45f6-849c-8175519656b7) access to the keyvault 
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $config.userIdentity.adGroupObjectId.objectId1 -PermissionsToKeys backup,create,delete,get,import,get,list,update,restore 
                $key = Add-AzKeyVaultKey -VaultName $keyvaultName -Name $keyname2 -Destination 'Software'    
                $keyversion2 = $key.Version
                # ID of /subscriptions/{SubscriptionId}/resourceGroups/weitry/providers/Microsoft.ManagedIdentity/userAssignedIdentities/weitestid1
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $config.userIdentity.adGroupObjectId.objectId2 -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 
                # ID of /subscriptions/{SubscriptionId}/resourceGroups/weitry/providers/Microsoft.ManagedIdentity/userAssignedIdentities/weitestid2
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $config.userIdentity.adGroupObjectId.objectId3 -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 
    
                $keyVault = New-AzKeyVault -VaultName $keyvaultName2 -ResourceGroupName $rgName -Location $location -EnablePurgeProtection
                # give service principle "weiwei's AAD app" (d6f7e858-345d-45f6-849c-8175519656b7) access to the keyvault 
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName2 -ResourceGroupName $rgName -ObjectId $config.userIdentity.adGroupObjectId.objectId1 -PermissionsToKeys backup,create,delete,get,import,get,list,update,restore 
                $key = Add-AzKeyVaultKey -VaultName $keyvaultName2 -Name $keyname2 -Destination 'Software'    
                $keyversion2 = $key.Version
                # ID of /subscriptions/{SubscriptionId}/resourceGroups/weitry/providers/Microsoft.ManagedIdentity/userAssignedIdentities/weitestid1
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName2 -ResourceGroupName $rgName -ObjectId $config.userIdentity.adGroupObjectId.objectId2 -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 
                # ID of /subscriptions/{SubscriptionId}/resourceGroups/weitry/providers/Microsoft.ManagedIdentity/userAssignedIdentities/weitestid2
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName2 -ResourceGroupName $rgName -ObjectId $config.userIdentity.adGroupObjectId.objectId3 -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 

                # remove-AzKeyVault -VaultName $keyvaultName -ResourceGroupName $rgName

            # create 2 User identity, and give them access to keyvault
                $userId3 = New-AzUserAssignedIdentity -ResourceGroupName $rgName -Name weitestid3
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $userId3.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
                $useridentity= $userId3.Id
                $userId4 = New-AzUserAssignedIdentity -ResourceGroupName $rgName -Name weitestid4
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $userId4.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
                $useridentity2= $userId4.Id
                # Remove-AzUserAssignedIdentity -ResourceGroupName $rgName -Name weitestid3
        }

        # Create Account with UAI (SystemAssignedUserAssigned)
            $storageAccountName = $accountNamePrefix+"1"
            $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Kind StorageV2 -SkuName Standard_LRS -Location eastus2 `
                        -UserAssignedIdentityId $useridentity  -IdentityType SystemAssignedUserAssigned  `
                        -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity #-debug

            $account.Identity.Type | should -be "SystemAssigned,UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -BeGreaterOrEqual 1
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity
            $account.Encryption.KeyVaultProperties.KeyVaultUri | Should -Be $keyvaultUri
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname

        # 10 CMK1+UAI1 -> CMK2+UAI2
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType SystemAssignedUserAssigned -UserAssignedIdentityId $useridentity2 -KeyVaultUserAssignedIdentityId $useridentity2  
            $account.Identity.Type | should -be "SystemAssigned,UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity2] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity2
            $account.Encryption.KeyVaultProperties.KeyVaultUri | Should -Be $keyvaultUri
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname
            
            if($false)
            {
            Sleep 600
    
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -KeyVaultUri $keyvaultUri2 -KeyName $keyname2 -KeyVersion $keyversion2 
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity2] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity2
            $account.Encryption.KeyVaultProperties.KeyVaultUri | Should -Be $keyvaultUri2
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname2
            $account.Encryption.KeyVaultProperties.KeyVersion | Should -Be $keyversion2
            }

            remove-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Force -AsJob

        #1 MMK -> CMK with SAI:  
            # create MMK account
            $storageAccountName = $accountNamePrefix+"2"
            $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Kind StorageV2 -SkuName Standard_LRS -Location eastus2 -AssignIdentity
            $account.Identity.Type | should -be "SystemAssigned"
            $account.Encryption.KeySource | Should -Be Microsoft.Storage

            # update to CMK with SAI
            Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $account.Identity.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType SystemAssigned -KeyName $keyname -KeyVaultUri $keyvaultUri   
            $account.Identity.Type | should -be "SystemAssigned"
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity | Should -Be $null
            (New-Object -TypeName System.Uri -ArgumentList $account.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $keyvaultUri).Host
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname

        #3. CMK with SAI -> UAI:  
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType SystemAssignedUserAssigned -UserAssignedIdentityId $useridentity  -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity 
            $account.Identity.Type | should -be "SystemAssigned,UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity
            (New-Object -TypeName System.Uri -ArgumentList $account.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $keyvaultUri).Host
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname
                
            if($false)
            {
        #9. CMK1 with UAI -> CMK2 with UAI
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -KeyName $keyname2 -KeyVaultUri $keyvaultUri2 
            $account.Identity.Type | should -be "SystemAssigned,UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity
            $account.Encryption.KeyVaultProperties.KeyVaultUri | Should -Be $keyvaultUri2
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname2
            }

            remove-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Force -AsJob

        #2 MMK-> CMK with UAI:  
            # create MMK account
            $storageAccountName = $accountNamePrefix+"33"
            $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Kind StorageV2 -SkuName Standard_LRS -Location eastus2euap -AssignIdentity

            Sleep 60

            # update to CMK with UAI
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType UserAssigned -UserAssignedIdentityId $useridentity -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity 
            $account.Identity.Type | should -be "UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity
            $account.Encryption.KeyVaultProperties.KeyVaultUri | Should -Be $keyvaultUri
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname

        # 4. CMK with UAI -> CMK with SAI
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName  -IdentityType SystemAssignedUserAssigned
            $account.Identity.Type | should -be "SystemAssigned,UserAssigned" 
            Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName weitry -ObjectId $account.Identity.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation

            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType SystemAssignedUserAssigned -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId "" 
            $account.Identity.Type | should -be "SystemAssigned,UserAssigned"
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be ""
            $account.Encryption.KeyVaultProperties.KeyVaultUri | Should -Be $keyvaultUri
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname

        #7 CMK with SAI -> MMK
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName  -StorageEncryption 
            $account.Encryption.KeySource | Should -Be Microsoft.Storage

            remove-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Force -AsJob

        # 5 CMK with UAI1 -> CMK with UAI2: 
            # create account CMK with UAI (UserAssigned)
            $storageAccountName = $accountNamePrefix+"44"
            $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Kind StorageV2 -SkuName Standard_LRS -Location eastus2euap -AssignIdentity  -UserAssignedIdentityId $useridentity -IdentityType UserAssigned  `
                    -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity  
            $account.Identity.Type | should -be "UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity
            (New-Object -TypeName System.Uri -ArgumentList $account.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $keyvaultUri).Host
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname


            # update to UAI2
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType UserAssigned -UserAssignedIdentityId $useridentity2 -KeyVaultUserAssignedIdentityId $useridentity2  # -KeyName $keyname -KeyVaultUri $keyvaultUri 
            $account.Identity.Type | should -be "UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity2] | should -Not -be $null
            $account.Encryption.KeySource | Should -Be Microsoft.Keyvault
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity2
            (New-Object -TypeName System.Uri -ArgumentList $account.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $keyvaultUri).Host
            $account.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname

        # 6.CMK with UAI -> MMK
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -StorageEncryption  -Force
            $account.Encryption.KeySource | Should -Be Microsoft.Storage

        # 8. Remove Identity - Server behavior will take care of it.  
            # Clean up Identity
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType None -KeyVaultUserAssignedIdentityId "" 
            $account.Identity.Type | should -be "None"
            $account.Identity.UserAssignedIdentities | should -Be $null

            #Recover 
            $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -IdentityType UserAssigned -UserAssignedIdentityId $useridentity -KeyVaultUserAssignedIdentityId $useridentity
            $account.Identity.Type | should -be "UserAssigned"
            $account.Identity.UserAssignedIdentities.Count | should -Be 1
            $account.Identity.UserAssignedIdentities[$useridentity] | should -Not -be $null
            $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity | Should -Be $useridentity


            remove-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Force -AsJob

            } 
            catch
            {
                throw;
            }
            finally
            {
                Remove-AzResourceGroup -Name $rgName -Force -AsJob
            }

            $Error.Count | should -be 0
    }
        
    It "Blob Inventory" -Tag "2021-5-25" {
        $Error.Clear()

        $resourceGroupName = "weitry"
        $accountName = "weisanity1" # HNS enabled, can't enabled versiongin
        $containerName = "weitestnew"
        
        # Update-AzStorageBlobServiceProperty  -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName -IsVersioningEnabled $true
        $con = New-AzRmStorageContainer -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName  -Name $containerName

        # set rules
        $rule1 = New-AzStorageBlobInventoryPolicyRule -Name Test1 -Destination $containerName -Disabled -Format Csv -Schedule Daily -ContainerSchemaField Name,Metadata,PublicAccess,Last-mOdified,LeaseStatus,LeaseState,LeaseDuration,HasImmutabilityPolicy,HasLegalHold -PrefixMatch con1,con2
        $rule2 = New-AzStorageBlobInventoryPolicyRule -Name Test2 -Destination $containerName -Format Parquet -Schedule Weekly  -BlobType blockBlob -PrefixMatch aaa,bbb -BlobSchemaField name,Last-Modified,Metadata,LastAccessTime,AccessTierInferred #,Tags
        $rule3 = New-AzStorageBlobInventoryPolicyRule -Name Test3 -Destination $containerName -Format Parquet -Schedule Daily  -IncludeSnapshot -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                -BlobSchemaField name,Creation-Time,Last-Modified,Content-Length,Content-MD5,BlobType,AccessTier,AccessTierChangeTime,Expiry-Time,hdi_isfolder,Owner,Group,Permissions,Acl,Metadata,LastAccessTime 
        # $rule4 = New-AzStorageBlobInventoryPolicyRule -Name Test4 -Destination $containerName -Disabled -Format Csv -Schedule Weekly -BlobSchemaField Name,BlobType,Content-Length,Creation-Time -BlobType blockBlob -IncludeBlobVersion

        $policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName  -Disabled -Rule $rule1,$rule2,$rule3
        $policy.Enabled | should -Be $false
        $policy.Rules.Count | should -be 3
        $policy.Rules[0].Name | should -be "Test1"
        $policy.Rules[0].Enabled | should -Be $false
        $policy.Rules[0].Destination | should -Be $containerName
        $policy.Rules[0].Definition.ObjectType | should -Be Container
        $policy.Rules[0].Definition.Format | should -Be Csv
        $policy.Rules[0].Definition.Schedule | should -Be Daily
        $policy.Rules[0].Definition.SchemaFields.Count | should -Be 9
        $policy.Rules[0].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[0].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[0].Definition.Filters.BlobTypes| should -be $null
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[1].Name | should -be "Test2"
        $policy.Rules[1].Enabled | should -Be $true
        $policy.Rules[1].Destination | should -Be $containerName
        $policy.Rules[1].Definition.ObjectType | should -Be Blob
        $policy.Rules[1].Definition.Format | should -Be Parquet
        $policy.Rules[1].Definition.Schedule | should -Be Weekly
        $policy.Rules[1].Definition.SchemaFields.Count | should -Be 5
        $policy.Rules[1].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[1].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[1].Definition.Filters.BlobTypes.Count | should -be 1
        $policy.Rules[1].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[2].Name | should -be "Test3"
        $policy.Rules[2].Enabled | should -Be $true
        $policy.Rules[2].Destination | should -Be $containerName
        $policy.Rules[2].Definition.ObjectType | should -Be Blob
        $policy.Rules[2].Definition.Format | should -Be Parquet
        $policy.Rules[2].Definition.Schedule | should -Be Daily
        $policy.Rules[2].Definition.SchemaFields.Count | should -Be 17
        $policy.Rules[2].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[2].Definition.Filters.IncludeSnapshots | should -Be $true
        $policy.Rules[2].Definition.Filters.BlobTypes.Count | should -be 2
        $policy.Rules[2].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy = $null

        $policy = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName 
        $policy.Enabled | should -Be $false
        $policy.Rules.Count | should -be 3
        $policy.Rules[0].Name | should -be "Test1"
        $policy.Rules[0].Enabled | should -Be $false
        $policy.Rules[0].Destination | should -Be $containerName
        $policy.Rules[0].Definition.ObjectType | should -Be Container
        $policy.Rules[0].Definition.Format | should -Be Csv
        $policy.Rules[0].Definition.Schedule | should -Be Daily
        $policy.Rules[0].Definition.SchemaFields.Count | should -Be 9
        $policy.Rules[0].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[0].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[0].Definition.Filters.BlobTypes| should -be $null
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[1].Name | should -be "Test2"
        $policy.Rules[1].Enabled | should -Be $true
        $policy.Rules[1].Destination | should -Be $containerName
        $policy.Rules[1].Definition.ObjectType | should -Be Blob
        $policy.Rules[1].Definition.Format | should -Be Parquet
        $policy.Rules[1].Definition.Schedule | should -Be Weekly
        $policy.Rules[1].Definition.SchemaFields.Count | should -Be 5
        $policy.Rules[1].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[1].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[1].Definition.Filters.BlobTypes.Count | should -be 1
        $policy.Rules[1].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[2].Name | should -be "Test3"
        $policy.Rules[2].Enabled | should -Be $true
        $policy.Rules[2].Destination | should -Be $containerName
        $policy.Rules[2].Definition.ObjectType | should -Be Blob
        $policy.Rules[2].Definition.Format | should -Be Parquet
        $policy.Rules[2].Definition.Schedule | should -Be Daily
        $policy.Rules[2].Definition.SchemaFields.Count | should -Be 17
        $policy.Rules[2].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[2].Definition.Filters.IncludeSnapshots | should -Be $true
        $policy.Rules[2].Definition.Filters.BlobTypes.Count | should -be 2
        $policy.Rules[2].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy = $null

        $removeSuccess = Remove-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName  -PassThru
        $removeSuccess | should -Be $true

        # Account pipeline
        $policy = Get-AzStorageAccount -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName | Set-AzStorageBlobInventoryPolicy -Rule $rule1        
        $policy.Enabled | should -Be $true
        $policy.Rules.Count | should -be 1
        $policy.Rules[0].Name | should -be "Test1"
        $policy.Rules[0].Enabled | should -Be $false
        $policy.Rules[0].Destination | should -Be $containerName
        $policy.Rules[0].Definition.ObjectType | should -Be Container
        $policy.Rules[0].Definition.Format | should -Be Csv
        $policy.Rules[0].Definition.Schedule | should -Be Daily
        $policy.Rules[0].Definition.SchemaFields.Count | should -Be 9
        $policy.Rules[0].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[0].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[0].Definition.Filters.BlobTypes| should -be $null
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy = $null
        $policy = Get-AzStorageAccount -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName | Get-AzStorageBlobInventoryPolicy
        $policy.Enabled | should -Be $true
        $policy.Rules.Count | should -be 1
        $policy.Rules[0].Name | should -be "Test1"
        $policy = $null
        Get-AzStorageAccount -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName | Remove-AzStorageBlobInventoryPolicy
    
        # set BlobInventoryPolicy with json
        $policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName -Policy (@{
                Enabled=$true;
                Rules=(@{
                    Enabled=$true;
                    Name="Test1";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Blob";
                        Format="Csv";
                        Schedule="Weekly";
                        SchemaFields=@("name","Content-Length","BlobType","Snapshot");
                        Filters=(@{
                            BlobTypes=@("blockBlob","appendBlob");
                            PrefixMatch=@("prefix1","prefix2");
                            IncludeSnapshots=$true;
                            IncludeBlobVersions=$false;
                        })
                    })
                },
                @{
                    Enabled=$false;
                    Name="Test2";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Container";
                        Format="Parquet";
                        Schedule="Daily";
                        SchemaFields=@("name","Metadata","PublicAccess");
                        Filters=(@{
                            PrefixMatch=@("conpre1","conpre2");
                        })
                    })
                })
            })
        $policy.Enabled | should -Be $true
        $policy.Rules.Count | should -be 2
        $policy.Rules[0].Name | should -be "Test1"
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Destination | should -Be $containerName
        $policy.Rules[0].Definition.ObjectType | should -Be Blob
        $policy.Rules[0].Definition.Format | should -Be Csv
        $policy.Rules[0].Definition.Schedule | should -Be Weekly
        $policy.Rules[0].Definition.SchemaFields.Count | should -Be 4
        $policy.Rules[0].Definition.Filters.IncludeBlobVersions | should -Be $false
        $policy.Rules[0].Definition.Filters.IncludeSnapshots | should -Be $true
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 2
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[1].Name | should -be "Test2"
        $policy.Rules[1].Enabled | should -Be $false
        $policy.Rules[1].Destination | should -Be $containerName
        $policy.Rules[1].Definition.ObjectType | should -Be Container
        $policy.Rules[1].Definition.Format | should -Be Parquet
        $policy.Rules[1].Definition.Schedule | should -Be Daily
        $policy.Rules[1].Definition.SchemaFields.Count | should -Be 3
        $policy.Rules[1].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[1].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[1].Definition.Filters.BlobTypes| should -be $null
        $policy.Rules[1].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy = $null

        #policy pipeline
        $policy = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName | Set-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName 
        $policy.Enabled | should -Be $true
        $policy.Rules.Count | should -be 2
        $policy.Rules[0].Name | should -be "Test1"
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Destination | should -Be $containerName
        $policy.Rules[0].Definition.ObjectType | should -Be Blob
        $policy.Rules[0].Definition.Format | should -Be Csv
        $policy.Rules[0].Definition.Schedule | should -Be Weekly
        $policy.Rules[0].Definition.SchemaFields.Count | should -Be 4
        $policy.Rules[0].Definition.Filters.IncludeBlobVersions | should -Be $false
        $policy.Rules[0].Definition.Filters.IncludeSnapshots | should -Be $true
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 2
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[1].Name | should -be "Test2"
        $policy.Rules[1].Enabled | should -Be $false
        $policy.Rules[1].Destination | should -Be $containerName
        $policy.Rules[1].Definition.ObjectType | should -Be Container
        $policy.Rules[1].Definition.Format | should -Be Parquet
        $policy.Rules[1].Definition.Schedule | should -Be Daily
        $policy.Rules[1].Definition.SchemaFields.Count | should -Be 3
        $policy.Rules[1].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[1].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[1].Definition.Filters.BlobTypes| should -be $null
        $policy.Rules[1].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy = $null
        $policy = ,((Get-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName).Rules) | Set-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName -Disabled
        $policy.Enabled | should -Be $false
        $policy.Rules.Count | should -be 2
        $policy.Rules[0].Name | should -be "Test1"
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Destination | should -Be $containerName
        $policy.Rules[0].Definition.ObjectType | should -Be Blob
        $policy.Rules[0].Definition.Format | should -Be Csv
        $policy.Rules[0].Definition.Schedule | should -Be Weekly
        $policy.Rules[0].Definition.SchemaFields.Count | should -Be 4
        $policy.Rules[0].Definition.Filters.IncludeBlobVersions | should -Be $false
        $policy.Rules[0].Definition.Filters.IncludeSnapshots | should -Be $true
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 2
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[1].Name | should -be "Test2"
        $policy.Rules[1].Enabled | should -Be $false
        $policy.Rules[1].Destination | should -Be $containerName
        $policy.Rules[1].Definition.ObjectType | should -Be Container
        $policy.Rules[1].Definition.Format | should -Be Parquet
        $policy.Rules[1].Definition.Schedule | should -Be Daily
        $policy.Rules[1].Definition.SchemaFields.Count | should -Be 3
        $policy.Rules[1].Definition.Filters.IncludeBlobVersions | should -Be $null
        $policy.Rules[1].Definition.Filters.IncludeSnapshots | should -Be $null
        $policy.Rules[1].Definition.Filters.BlobTypes| should -be $null
        $policy.Rules[1].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy = $null
        Get-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName | Remove-AzStorageBlobInventoryPolicy            

        $Error.Count | should -be 0
    }
    
    It "File Share Snapshot" -Tag "2021-5-25"  {
        $Error.Clear()

        $resourceGroupName = "weitest"
        $accountName = "weiacl0"
        $shareName = "testshare"+(Get-date).Ticks
        $shareName2 = $shareName+"2"
        $shareName3 = $shareName+"3"

        Update-AzStorageFileServiceProperty -ResourceGroupName $resourceGroupName -StorageAccountName $accountName  -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 1
    
        $share1 = New-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName
        $share2 = New-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName2    
        $share3 = New-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName3
        $share1Snapshot1 = New-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -Snapshot
        $share1Snapshot2 = New-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -Snapshot  
        $share3Snapshot1 = New-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName3 -Snapshot
        $share1.SnapshotTime | should -Be $null
        $share2.SnapshotTime | should -Be $null
        $share3.SnapshotTime | should -Be $null
        $share1Snapshot1.SnapshotTime | should -Not -Be $null
        $share1Snapshot2.SnapshotTime | should -Not -Be $null
        $share3Snapshot1.SnapshotTime | should -Not -Be $null

        $share2 | Remove-AzRmStorageShare -Force

        # list share
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -IncludeSnapshot -IncludeDeleted | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 6
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 5
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName  -IncludeDeleted | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 3
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 2

        # get single snapshot
        $share1Snapshot1_1 = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -SnapshotTime $share1Snapshot1.SnapshotTime
        $share1Snapshot1_1.SnapshotTime | should -Be $share1Snapshot1.SnapshotTime

        # remove single snapshot 
        Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -SnapshotTime $share1Snapshot1.SnapshotTime -Force
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 4

        #remove base share default (none)
        Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -Force -ErrorAction SilentlyContinue
        $Error[0].Exception.Message.Contains("The share has snapshots and the operation requires no snapshots.") | should -Be $true        
        $Error.Count | should -be 1
        $error.Clear()

        #remove base share include none
        Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -Force -Include None -ErrorAction SilentlyContinue
        $Error[0].Exception.Message.Contains("The share has snapshots and the operation requires no snapshots.") | should -Be $true        
        $Error.Count | should -be 1
        $error.Clear()

        #remove base share include snapshot
        Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -Force -Include Snapshots
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 2

        #remove base share include Leased-Snapshots  
        Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName3 -Force -Include Leased-Snapshots
        $shares = Get-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 0

        $Error.Count | should -be 0
    }

    It "NFS" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weifilestorage1"

        ### create share
        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1 -EnabledProtocol NFS -RootSquash RootSquash 
        Assert-AreEqual "NFS" $share.EnabledProtocols
        Assert-AreEqual "RootSquash" $share.RootSquash
        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest2 -EnabledProtocol NFS -RootSquash NoRootSquash 
        Assert-AreEqual "NFS" $share.EnabledProtocols
        Assert-AreEqual "NoRootSquash" $share.RootSquash
        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest3 -EnabledProtocol SMB
        Assert-AreEqual "SMB" $share.EnabledProtocols
        Assert-Null $share.RootSquash
        $share2 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest4 -EnabledProtocol NFS -RootSquash AllSquash -QuotaGiB 200 -Metadata @{"m1" = "v1"} 
        Assert-AreEqual "NFS" $share2.EnabledProtocols
        Assert-AreEqual "AllSquash" $share2.RootSquash
        Assert-AreEqual 200 $share2.QuotaGiB
        Assert-AreEqual 1 $share2.Metadata.Count

        ### update share
        $share = Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1 -RootSquash NoRootSquash 
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1
        Assert-AreEqual "NFS" $share.EnabledProtocols
        Assert-AreEqual "NoRootSquash" $share.RootSquash
        Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1 -QuotaGiB 201 -RootSquash AllSquash 
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1
        Assert-AreEqual "NFS" $share.EnabledProtocols
        Assert-AreEqual "AllSquash" $share.RootSquash
        Assert-AreEqual 201 $share.QuotaGiB
        Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1 -Metadata @{"m1" = "v1"; "m2" = "v2"}  -RootSquash RootSquash 
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1
        Assert-AreEqual "NFS" $share.EnabledProtocols
        Assert-AreEqual "RootSquash" $share.RootSquash
        Assert-AreEqual 201 $share.QuotaGiB
        Assert-AreEqual 2 $share.Metadata.Count

        Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName

        remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest1 -Force
        remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest2 -Force
        remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest3 -Force
        remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountName -Name weitest4 -Force

        $Error.Count | should -be 0
    }  

    It "Smb Multichannel" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weifilestorage1"

        #Enable Smb Multichannel
        $p = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableSmbMultichannel $true
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true 
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true 
        $p = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -EnableSmbMultichannel $false 
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $false 
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $false 

        $Error.Count | should -be 0
    }
  
    It "Container Soft Delete" -Tag "2021-7-6" {
        $Error.Clear()

        $resourceGroupName = "weitry"
        $storageAccountName = "weiors3"
        $conName1 = "cont1"
        $conName2 = "cont2"

        $ctx = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName).Context

        #Enable container soft delete
        $deletePolicy = Enable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -RetentionDays 2 -PassThru
        $deletePolicy.Enabled | should -be $true
        $deletePolicy.Days | should -Be 2
        $policy = Get-AzStorageBlobServiceProperty -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName 
        $policy.ContainerDeleteRetentionPolicy.Enabled | should -be $true
        $policy.ContainerDeleteRetentionPolicy.Days | should -Be 2

        #create/delete/list container/list - managemetn plane        
        $con1 = New-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -Name $conName1
        Remove-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -Name $conName1 -Force
        $contains = Get-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -IncludeDeleted
        $deletedCon1 = $contains | ?{ $_.Name -eq $conName1  -and $_.Deleted}
        $deletedCon1.Count | should -BeGreaterOrEqual 1  
        $deletedCon1.Version  | should -Not -Be $null  
        
        #create/delete/list container - dataplane plane
        $con2 = New-AzStorageContainer -Name $conName2 -Context $ctx
        Remove-AzStorageContainer -Name $conName2 -Context $ctx -Force
        $contains = Get-AzStorageContainer -IncludeDeleted -Context $ctx
        $deletedCon1 = $contains | ?{ $_.Name -eq $conName1  -and $_.IsDeleted}
        $deletedCon1[0].VersionId | should -Not -Be $null
        $deletedCon1.Count | should -BeGreaterOrEqual 1   
        $deletedCon2 = $contains | ?{ $_.Name -eq $conName2  -and $_.IsDeleted}
        $deletedCon2[0].VersionId | should -Not -Be $null  
        
        #restore container
        sleep 60
        $con1 = $deletedCon1[0] | ?{ $_.Name -eq $conName1 } | Restore-AzStorageContainer 
        $con1.Name | should -be $deletedCon1[0].Name
        $con1.BlobContainerClient.Exists() | should -be $true
        $con2 = Restore-AzStorageContainer -Name $deletedCon2[0].Name -VersionId $deletedCon2[0].VersionId -Context $ctx
        $con2.Name | should -be $deletedCon2[0].Name
        $con2.BlobContainerClient.Exists() | should -be $true
        $contains = Get-AzStorageContainer -IncludeDeleted -Context $ctx
        ($contains | ?{ $_.Name -eq $conName1  -and $_.IsDeleted -eq $null}).Count |should -BeGreaterOrEqual 1
        ($contains | ?{ $_.Name -eq $conName2 -and $_.IsDeleted -eq $null}).Count |should -BeGreaterOrEqual 1
        
        #Disable container soft delete
        Disable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -PassThru
        $policy = Get-AzStorageBlobServiceProperty -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        $policy.ContainerDeleteRetentionPolicy.Enabled -eq $true| should -be $false

        #remove containers
        Remove-AzStorageContainer -Name $conName1 -Context $ctx
        # Remove-AzStorageContainer -Name $conName2 -Context $ctx
        Remove-AzStorageContainer -Name $conName2 -Context $ctx

        $Error.Count | should -be 0
    }

    It "EnableNfsV3" -tag "2021-06-01" {
        $Error.Clear()
         
        $vnet1 = $config.enableNfsV3.vnet
        # New-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Location "eastus2euap" -AddressPrefix 10.0.0.0/24 -Name "vnet1" 
        # $n = Get-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Name "vnet1" | Add-AzVirtualNetworkSubnetConfig -Name "subnet1" -AddressPrefix "10.0.0.0/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzVirtualNetwork 

        $resourceGroupName = "weitest"
        $accountName3 = "weinfsv3"
        $a = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName3 -SkuName Standard_LRS  -Location centraluseuap -Kind StorageV2 -EnableNfsV3 $true -EnableHierarchicalNamespace $true -EnableHttpsTrafficOnly $false `
                -NetworkRuleSet (@{bypass="Logging,Metrics";virtualNetworkRules=(@{VirtualNetworkResourceId="$vnet1";Action="allow"});defaultAction="deny"})   
        $a.EnableNfsV3 | should -Be $true

        # create container
        $con = New-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name rootsquash -RootSquash RootSquash
        $con.EnableNfsV3AllSquash | should -be $false
        $con.EnableNfsV3RootSquash | should -be $true
        $con = New-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name norootsquash -RootSquash NoRootSquash
        $con.EnableNfsV3AllSquash | should -be $false
        $con.EnableNfsV3RootSquash | should -be $false
        $con = New-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name allsquash -RootSquash AllSquash
        $con.EnableNfsV3AllSquash | should -be $true
        $con.EnableNfsV3RootSquash | should -be $false
        $con = New-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name normal
        $con.EnableNfsV3AllSquash | should -be $null
        $con.EnableNfsV3RootSquash | should -be $null  
  
        # update container
        $con = Update-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name rootsquash -RootSquash NoRootSquash
        $con.EnableNfsV3AllSquash | should -be $false
        $con.EnableNfsV3RootSquash | should -be $false
        $con = Update-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name norootsquash -RootSquash AllSquash
        $con.EnableNfsV3AllSquash | should -be $true
        $con.EnableNfsV3RootSquash | should -be $false
        $con = Update-AzRmStorageContainer -ResourceGroupName $resourceGroupName -StorageAccountName $accountName3 -Name allsquash -RootSquash RootSquash
        $con.EnableNfsV3AllSquash | should -be $false
        $con.EnableNfsV3RootSquash | should -be $true

        Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName3 -Force -AsJob

        $Error.Count | should -be 0
    }

    It "Secure SMB" -Tag "2021-7-6" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weifilestorage1"
        
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -SMBProtocolVersion SMB2.1,SMB3.0,SMB3.1.1 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 3
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -SMBAuthenticationMethod Kerberos,NTLMv2
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 2
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -SMBKerberosTicketEncryption RC4-HMAC,AES-256
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 2
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -SMBChannelEncryption AES-128-CCM,AES-128-GCM,AES-256-GCM
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 3
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName -SMBProtocolVersion SMB2.1,SMB3.0  -SMBAuthenticationMethod Kerberos -SMBKerberosTicketEncryption RC4-HMAC -SMBChannelEncryption AES-128-CCM,AES-256-GCM -EnableSmbMultichannel $true 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 2
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 1
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 1
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 2
        $fs.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true
        $fs = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 2
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 1
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 1
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 2
        $fs.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName 
        $fs = $account | Update-AzStorageFileServiceProperty  `
			-SMBProtocolVersion @() `
			-SMBAuthenticationMethod @() `
			-SMBKerberosTicketEncryption @() `
			-SMBChannelEncryption @() 
        $fs.ProtocolSettings.Smb.Smb.Versions.Count | should -be 0
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 0
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 0
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 0

        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName `
			        -SMBProtocolVersion SMB2.1,SMB3.0,SMB3.1.1  `
			        -SMBAuthenticationMethod Kerberos,NTLMv2 `
			        -SMBKerberosTicketEncryption RC4-HMAC,AES-256 `
			        -SMBChannelEncryption AES-128-CCM,AES-128-GCM,AES-256-GCM 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 3
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 2
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 2
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 3

        $Error.Count | should -be 0
    }  
        
    It "Blob LastAccessTime Tracking" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weiors3"

        #enable LAT
        $p = Enable-AzStorageBlobLastAccessTimeTracking  -ResourceGroupName $rgname -StorageAccountName $accountName -PassThru
        $p.Enable | should -Be $true
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName
        $p.LastAccessTimeTrackingPolicy.Enable | should -Be $true

        # Add management policy with rule object
        $action1 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -DaysAfterLastAccessTimeGreaterThan 100 -EnableAutoTierToHotFromCool
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToCool -DaysAfterLastAccessTimeGreaterThan 30 -EnableAutoTierToHotFromCool
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToArchive -DaysAfterModificationGreaterThan 80 -DaysAfterLastTierChangeGreaterThan 30
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction Delete -daysAfterCreationGreaterThan 100
        $filter1 = New-AzStorageAccountManagementPolicyFilter -PrefixMatch con/prefix1,con/prefix2 #-SuffixMatch .jpg,.exe -SizeInByteLessThan 10000 -SizeInByteGreaterThan 100
        $rule1 = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action1 -Filter $filter1
        
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -Rule $rule1 # -debug
        $policy.Rules.Count | should -Be 1
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Name | should -be Test
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterLastAccessTimeGreaterThan | should -be 30
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan | should -be $null
        $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be $null
        $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterLastAccessTimeGreaterThan | should -be 100
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan | should -be 80
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan | should -be 30
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastAccessTimeGreaterThan | should -be $null
        $policy.Rules[0].Definition.Actions.BaseBlob.EnableAutoTierToHotFromCool | should -be $true
        $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan | should -be 100
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 1

        # Add management policy with Json        
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName -Policy (@{
            Rules=(@{
                Enabled="true";
                Name="Test2";
                Definition=(@{
                    Actions=(@{
                        BaseBlob=(@{
                            TierToCool=@{DaysAfterLastAccessTimeGreaterThan=40};
                            TierToArchive=@{DaysAfterLastAccessTimeGreaterThan=50};
                            Delete=100;
                        });
                        Snapshot=(@{
                            Delete=@{DaysAfterCreationGreaterThan=200}
                        });
                    });
                    Filters=(@{
                        BlobTypes=@("blockBlob");
                        PrefixMatch=@("con/prefix1","con/prefix2");
                    })
                })
            })
        })

        $policy.Rules.Count | should -Be 1
        $policy.Rules[0].Enabled | should -Be $true
        $policy.Rules[0].Name | should -be Test2
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterLastAccessTimeGreaterThan | should -be 40
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan | should -be $null
        $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan | should -be 100
        $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterLastAccessTimeGreaterThan | should -be $null
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan | should -be $null
        $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastAccessTimeGreaterThan | should -be 50
        $policy.Rules[0].Definition.Actions.BaseBlob.EnableAutoTierToHotFromCool | should -be $null
        $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan | should -be 200
        $policy.Rules[0].Definition.Filters.PrefixMatch.Count | should -be 2
        $policy.Rules[0].Definition.Filters.BlobTypes.Count | should -be 1

        # remove management policy and disable LAT 
        Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountName
        Disable-AzStorageBlobLastAccessTimeTracking  -ResourceGroupName $rgname -StorageAccountName $accountName
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountName
        $p.LastAccessTimeTrackingPolicy | should -Be $null

        $Error.Count | should -be 0
    }

    It "HnsOn Migration" -tag "fail","longrunning" {
        $Error.Clear()

        $rgname = “weitry” ## e.g. testrg”
        $accountName = "weihnsonregression"+ (Get-Date).Ticks%10000 ## e.g. “testaccount”-tag "fail"

        #clean up
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -Force  -ErrorAction SilentlyContinue
        $Error.Clear()
        
        # Create account
        $a = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 # -EnableHierarchicalNamespace $true 
        $a.EnableHierarchicalNamespace | should -be $null

        # Validation
        Invoke-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $accountName -RequestType Validation | should -be $true

        # upgrade
        $task = Invoke-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $accountName -RequestType Upgrade -Force -AsJob

        # stop upgrade (will fail)
        Stop-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $accountName -Force -PassThru -ErrorAction SilentlyContinue        
        $error[0].Exception.Message | should -Be "Hns migration for the account: $($accountName) is not found."
        $error.Count | should -be 1
        $error.Clear()

        # wait for upgrade complete
        $task | Wait-Job
        $task.State | should -be "Completed"

        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName
        $a.EnableHierarchicalNamespace | should -be $true

        # clean up
        $t = Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -Force -AsJob 
        $t | Wait-Job
        $t.State | should -be "Completed"

        $Error.Count | should -be 0
    }

    It "AllowProtectedAppendWriteAll" -tag "2021-06-01" {
        $Error.Clear()
            
        $rgname = "weitry";
        $accountName = "weiadlscanary1" # must be an account which enabled HNFS
        $containerName = "weitestallappend1" 

        # ImmutabilityPolicy 
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName 
        $con.ImmutabilityPolicy.AllowProtectedAppendWritesAll | should -be $null
        $con.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $null

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -ImmutabilityPeriod 2 -AllowProtectedAppendWrite $false -AllowProtectedAppendWriteAll $true
        $imp.AllowProtectedAppendWrites | should -BeIn @($null, $false)
        $imp.AllowProtectedAppendWritesAll | should -be $true
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName 
        $con.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $false
        $con.ImmutabilityPolicy.AllowProtectedAppendWritesAll | should -be $true

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -ImmutabilityPeriod 2  -AllowProtectedAppendWriteAll $false
        $imp.AllowProtectedAppendWrites | should -be $false
        $imp.AllowProtectedAppendWritesAll | should -be $false

        # LegalHold
        $legal = Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -Tag  tag1,tag2  -AllowProtectedAppendWriteAll $true
        $legal.AllowProtectedAppendWritesAll | should -be $true
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName 
        $con.LegalHold.ProtectedAppendWritesHistory.AllowProtectedAppendWritesAll | should -be $true

        # clean up
        $legal = Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName -Tag  tag1,tag2 
        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Force

        $Error.Count | should -be 0
    }

    
    It "VLW" -Tag "VLW","longrunning" {
        $Error.Clear()
        $rgname = “weitry” ## e.g. testrg”
        $accountName = “weirp1” ## e.g. “testaccount”

        $ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName).Context
        $containerName = "vlwtest"
        $containerName2 = "vlwtestmigration2"
        $localSrcFile = "C:\temp\testfile_10240K_0" 
        $blobname = "testvlw1"

        ##### mgmt plane: 
        # Create container with VLW, then Get it
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -EnableImmutableStorageWithVersioning # -debug
        $con.ImmutableStorageWithVersioning.Enabled | should -be $true
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName # -debug
        $con.ImmutableStorageWithVersioning.Enabled | should -be $true

    
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName2
        $con.ImmutableStorageWithVersioning.Enabled | should -be $null
        Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountName -ContainerName $containerName2 -ImmutabilityPeriod 1
        $t = Invoke-AzRmStorageContainerImmutableStorageWithVersioningMigration -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName2 -asjob
        $t | Wait-Job
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName2 # -debug
        $con.ImmutableStorageWithVersioning.Enabled | should -be $true

        $con | Remove-AzRmStorageContainer -Force

        #### Dataplane - cmdlet:
        # create a blob
        $b = Set-AzStorageBlobContent -Container $containerName -Blob $blobname -File $localSrcFile -Context $ctx -Force
        $b.BlobBaseClient.CreateSnapshot()        
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null

        # set and remove ImmutabilityPolicy on an exiting blob
        $b = Set-AzStorageBlobImmutabilityPolicy -Container $containerName -Blob $blobname  -Context $ctx -ExpiresOn (Get-Date).AddDays(100) -PolicyMode Unlocked       
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -Not -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be Unlocked
    
        $b = Remove-AzStorageBlobImmutabilityPolicy -Container $containerName -Blob $blobname  -Context $ctx 
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null
    
        # set and remove LegalHold on an exiting blob
        $blob = Set-AzStorageBlobLegalHold -Container $containerName -Blob $blobname  -Context $ctx -EnableLegalHold
        $blob.BlobProperties.HasLegalHold | should -be $true

        $blob = Set-AzStorageBlobLegalHold -Container $containerName -Blob $blobname  -Context $ctx -DisableLegalHold
        $blob.BlobProperties.HasLegalHold | should -be $false

        # pipeline 
        # pipeline a snapshot
        $blobs = Get-AzStorageBlob -Container $containerName  -Context $ctx -IncludeVersion
        $Snapshot = ($blobs | ?{ $_.SnapshotTime -ne $null})[0]
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Set-AzStorageBlobImmutabilityPolicy -ExpiresOn (Get-Date).AddDays(1) -PolicyMode Unlocked
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Set-AzStorageBlobLegalHold -EnableLegalHold
        $b = Get-AzStorageBlob -Container $containerName -Blob $Snapshot.Name -SnapshotTime $Snapshot.SnapshotTime -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -Not -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be Unlocked
        $b.BlobProperties.HasLegalHold | should -be $true
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Remove-AzStorageBlobImmutabilityPolicy 
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Set-AzStorageBlobLegalHold -DisableLegalHold
        $b = Get-AzStorageBlob -Container $containerName -Blob $Snapshot.Name -SnapshotTime $Snapshot.SnapshotTime -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null
        $b.BlobProperties.HasLegalHold | should -be $false

        # pipeline a blob version
        $blobVersion = ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0]
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Set-AzStorageBlobImmutabilityPolicy -ExpiresOn (Get-Date).AddDays(1) -PolicyMode Unlocked
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Set-AzStorageBlobLegalHold -EnableLegalHold
        $b = Get-AzStorageBlob -Container $containerName -Blob $blobVersion.Name -VersionId $blobVersion.VersionId -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -Not -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be Unlocked
        $b.BlobProperties.HasLegalHold | should -be $true
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Set-AzStorageBlobLegalHold -DisableLegalHold
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Remove-AzStorageBlobImmutabilityPolicy 
        $b = Get-AzStorageBlob -Container $containerName -Blob $blobVersion.Name -VersionId $blobVersion.VersionId -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null
        $b.BlobProperties.HasLegalHold | should -be $false   

        # mgmt: cleanup by remove container
        # Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Force 

        $Error.Count | should -be 0
    }    

    It "account worm" {
        $Error.Clear()

        $rgname = “weitry”
        $accountName = “weiavlw1” 
        $accountName1 = “weiavlw11” 
        $accountName2 = “weiavlw12” 

        # create account
        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 -EnableAccountLevelImmutability -ImmutabilityPeriod 1 -ImmutabilityPolicyState Unlocked # -AllowProtectedAppendWrite $true #-debug
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
        # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $true

        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName1 -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 -EnableAccountLevelImmutability  
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy| should -be $null

        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 -EnableAccountLevelImmutability -ImmutabilityPeriod 1 -ImmutabilityPolicyState Disabled
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Disabled
        # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $null

        # update account
        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName  -ImmutabilityPeriod 2 -ImmutabilityPolicyState Unlocked # -AllowProtectedAppendWrite $false #-debug        
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 2
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
       # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $false

        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName  -ImmutabilityPeriod 1       
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
      #  $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $false

        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName # -AllowProtectedAppendWrite $true   
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
       # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $true

        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName  -ImmutabilityPolicyState Locked      
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Locked
       # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $true

        # clean up
        $t1 = remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName -Force -AsJob
        $t2 = remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName1 -Force -AsJob
        $t3 = remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountName2 -Force -AsJob
        @($t1, $t2, $t3) | Wait-Job
   
        $Error.Count | should -be 0
    }
    
    It "SFTP & Local User" {
        $Error.Clear()

        $resourceGroupName = “weitry” ## e.g. testrg”
        $storageAccountName = “weisftpregression" ## e.g. “testaccount”
        $UserName = “testuser" ## e.g. "testuser"


        # Create account 
        $account = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -Location centralus -SkuName Standard_LRS -Kind StorageV2 -EnableSftp $true -EnableHierarchicalNamespace $true -EnableNfsV3 $false -EnableLocalUser $true
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $true

        # update account 
        $account = Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -EnableSftp $false 
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $false
        $account = Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -EnableLocalUser $false 
        $account.EnableLocalUser | should -be $false
        $account.EnableSftp | should -be $false
        $account = Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -EnableLocalUser $true 
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $false
        $account = Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -EnableSftp $true -EnableLocalUser $true 
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $true
        ## show account properties
        $account = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $true

        # create/update local user
        $sshkey1 = New-AzStorageLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykey=" -Description "sshpulickey name1"
        $sshkey2 = New-AzStorageLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykey=" -Description "sshpulickey name2"
        $permissionScope1 = New-AzStorageLocalUserPermissionScope -Permission rw -Service blob -ResourceName container1 
        $permissionScope2 = New-AzStorageLocalUserPermissionScope -Permission rw -Service file -ResourceName share2
        $localuser = Set-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName $UserName -HomeDirectory "/" -SshAuthorizedKey $sshkey1,$sshkey2 -PermissionScope $permissionScope1,$permissionScope2 -HasSharedKey $true -HasSshKey $true -HasSshPassword $true #-Debug
        ## show the created/updated local user propertes
        $localuser.Name | should -Be $UserName
        $localuser.HomeDirectory | should -Be "/"
        $localuser.HasSharedKey | should -Be $true
        $localuser.HasSshKey | should -Be $true
        $localuser.HasSshPassword | should -Be $true
        $localuser.SshAuthorizedKeys.Count | should -be 2
        $localuser.SshAuthorizedKeys[0].Description | should -be "sshpulickey name1"
        $localuser.SshAuthorizedKeys[0].Key | should -be "ssh-rsa keykeykeykeykey="
        $localuser.SshAuthorizedKeys[1].Description | should -be "sshpulickey name2"
        $localuser.SshAuthorizedKeys[1].Key | should -be "ssh-rsa keykeykeykeykey="
        $localuser.PermissionScopes.Count | should -be 2
        $localuser.PermissionScopes[0].Permissions | should -be "rw"
        $localuser.PermissionScopes[0].Service | should -be "blob"
        $localuser.PermissionScopes[0].ResourceName | should -be "container1"
        $localuser.PermissionScopes[1].Permissions | should -be "rw"
        $localuser.PermissionScopes[1].Service | should -be "file"
        $localuser.PermissionScopes[1].ResourceName | should -be "share2"

        $localuser = Set-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName $UserName -HomeDirectory "/" -HasSharedKey $true -HasSshKey $true -HasSshPassword $true `
                    -SshAuthorizedKey (@{
                        Description="sshpulickey name1";
                        Key="ssh-rsa keykeykeykeykey=";                
                    },
                    @{
                        Description="sshpulickey name2";
                        Key="ssh-rsa keykeykeykeykey="; 
                    }) `
                    -PermissionScope (@{
                        Permissions="rw";
                        Service="blob"; 
                        ResourceName="container1";                
                    },
                    @{
                        Permissions="rwd";
                        Service="file"; 
                        ResourceName="share1";
                    }) 
        $localuser.Name | should -Be $UserName
        $localuser.HomeDirectory | should -Be "/"
        $localuser.HasSharedKey | should -Be $true
        $localuser.HasSshKey | should -Be $true
        $localuser.HasSshPassword | should -Be $true
        $localuser.SshAuthorizedKeys.Count | should -be 2
        $localuser.SshAuthorizedKeys[0].Description | should -be "sshpulickey name1"
        $localuser.SshAuthorizedKeys[0].Key | should -be "ssh-rsa keykeykeykeykey="
        $localuser.SshAuthorizedKeys[1].Description | should -be "sshpulickey name2"
        $localuser.SshAuthorizedKeys[1].Key | should -be "ssh-rsa keykeykeykeykey="
        $localuser.PermissionScopes.Count | should -be 2
        $localuser.PermissionScopes[0].Permissions | should -be "rw"
        $localuser.PermissionScopes[0].Service | should -be "blob"
        $localuser.PermissionScopes[0].ResourceName | should -be "container1"
        $localuser.PermissionScopes[1].Permissions | should -be "rwd"
        $localuser.PermissionScopes[1].Service | should -be "file"
        $localuser.PermissionScopes[1].ResourceName | should -be "share1"


        $localuser = Set-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName "$($UserName)2" -HomeDirectory "/" -SshAuthorizedKey $sshkey1
        $localuser.Name | should -Be "$($UserName)2"
        $localuser.HomeDirectory | should -Be "/"
        $localuser.HasSharedKey | should -Be $null
        $localuser.HasSshKey | should -Be $null
        $localuser.HasSshPassword | should -Be $null
        $localuser.SshAuthorizedKeys.Count | should -be 1
        $localuser.SshAuthorizedKeys[0].Description | should -be "sshpulickey name1"
        $localuser.SshAuthorizedKeys[0].Key | should -be "ssh-rsa keykeykeykeykey="
        $localuser.PermissionScopes.Count | should -be 0
        $localuser = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName | Set-AzStorageLocalUser -UserName "$($UserName)3" -HomeDirectory "/dir1"
        $localuser.Name | should -Be "$($UserName)3"
        $localuser.HomeDirectory | should -Be "/dir1"
        $localuser.HasSharedKey | should -Be $null
        $localuser.HasSshKey | should -Be $null
        $localuser.HasSshPassword | should -Be $null
        $localuser.SshAuthorizedKeys.Count | should -be 0
        $localuser.PermissionScopes.Count | should -be 0

        #get single local user
        $localuser = Get-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName $UserName
        $localuser.Name | should -Be $UserName
        $localuser.HomeDirectory | should -Be "/"
        $localuser.HasSharedKey | should -Be $true
        $localuser.HasSshKey | should -Be $true
        #$localuser.HasSshPassword | should -Be $true
        $localuser.SshAuthorizedKeys.Count | should -be 0
        $localuser.PermissionScopes.Count | should -be 2
        $localuser.PermissionScopes[0].Permissions | should -be "rw"
        $localuser.PermissionScopes[0].Service | should -be "blob"
        $localuser.PermissionScopes[0].ResourceName | should -be "container1"
        $localuser.PermissionScopes[1].Permissions | should -be "rwd"
        $localuser.PermissionScopes[1].Service | should -be "file"
        $localuser.PermissionScopes[1].ResourceName | should -be "share1"

        #list local user from a storage account
        $localusers = Get-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        $localusers.count | should -be 3
        $localusers[0].Name | should -Be $UserName
        $localusers[1].Name | should -Be "$($UserName)2"
        $localusers[2].Name | should -Be "$($UserName)3"

        # get key
        $keys = Get-AzStorageLocalUserKey -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName $UserName
        $keys.SharedKey.Length | should -BeGreaterThan 1
        $keys.SshAuthorizedKeys.Count | should -be 2
        $keys.SshAuthorizedKeys[0].Description | should -be "sshpulickey name1"
        $keys.SshAuthorizedKeys[0].Key | should -be "ssh-rsa keykeykeykeykew="
        $keys.SshAuthorizedKeys[1].Description | should -be "sshpulickey name2"
        $keys.SshAuthorizedKeys[1].Key | should -be "ssh-rsa keykeykeykeykew="

        # regenerate key
        $key = New-AzStorageLocalUserSshPassword -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName $UserName 
        $key.SshPassword.Length  | should -BeGreaterThan 1

        # delete a local user
        Remove-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -UserName $UserName -PassThru
        (Get-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName).count | should -be 2
        Get-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName | Remove-AzStorageLocalUser
        (Get-AzStorageLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName).count | should -be 0

        # remove account 
        remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -AsJob -Force

        $Error.Count | should -be 0
    }

    It "AADKerb" {
        $Error.Clear()

        $rgname = "weitry";
        $accountName = "weiaadkerb"
    
        $DomainName = "onpremaadstg.com"
        $DomainGuid = $config.asadKerb.domainGuid
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -SkuName Standard_LRS -Location "centraluseuap" -EnableAzureActiveDirectoryKerberosForFile $true -ActiveDirectoryDomainName $DomainName -ActiveDirectoryDomainGuid $DomainGuid 
        $a = get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "AADKERB"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainName | should -Be $DomainName
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainGuid | should -Be $DomainGuid

        $a = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -EnableAzureActiveDirectoryKerberosForFile $false 
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "None"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties | should -Be $null

        $a = set-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -EnableAzureActiveDirectoryKerberosForFile $true 
        $a = get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "AADKERB"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties | should -Be $null

        $a = set-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -EnableAzureActiveDirectoryKerberosForFile $true -ActiveDirectoryDomainName $DomainName -ActiveDirectoryDomainGuid $DomainGuid 
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "AADKERB"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainName | should -Be $DomainName
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainGuid | should -Be $DomainGuid

        remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -Force -AsJob

        $Error.Count | should -be 0
    }

    It "TODO" {
        $Error.Clear()

        $Error.Count | should -be 0
    }
    
    
    AfterAll { 
        #Cleanup  

    }
}