# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 

BeforeAll {
    Import-Module D:\code\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1 
    Import-Module D:\code\azure-powershell\artifacts\Debug\Az.Storage\Az.Storage.psd1 

    # Modify the path to your own
    Import-Module D:\code\azure-powershell\src\Storage\RegressionTests\utils.ps1

    [xml]$config = Get-Content D:\code\azure-powershell\src\Storage\RegressionTests\config.xml
    $globalNode = $config.SelectSingleNode("config/section[@id='global']")
    $testNode = $config.SelectSingleNode("config/section[@id='srp']")

    $secpasswd = ConvertTo-SecureString $globalNode.secPwd -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ($globalNode.applicationId, $secpasswd)
    Add-AzAccount -ServicePrincipal -Tenant $globalNode.tenantId -SubscriptionId $globalNode.subscriptionId -Credential $cred 

    $rgname = $globalNode.resourceGroupName
    $accountName = GetRandomAccountName
    $containerName = GetRandomContainerName
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

        $accountNameBasic = $accountName + "basic"

        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBasic -SkuName Standard_GRS -Location "eastus2euap" -Kind StorageV2  -EnableHierarchicalNamespace $true -EnableHttpsTrafficOnly $true -AllowCrossTenantReplication $false -PublicNetworkAccess Disabled # -AllowedCopyScope AAD
        $account.ResourceGroupName | should -Be $rgname
        $account.StorageAccountName | should -Be $accountNameBasic
        $account.Sku.Name | should -Be "Standard_GRS"
        $account.Location | should -Be "eastus2euap"
        $account.EnableHierarchicalNamespace | should -Be $true
        $account.EnableHttpsTrafficOnly | should -Be $true
        $account.Kind | should -Be "StorageV2"
        $account.AllowCrossTenantReplication | should -Be $false
        $account.PublicNetworkAccess | should -Be Disabled
        # $account.AllowedCopyScope | should -Be AAD
        
        $result = Get-AzStorageAccountNameAvailability -Name $accountNameBasic 
        $result.NameAvailable | should -Be $false

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBasic |  Set-AzStorageAccount   -EnableHttpsTrafficOnly $false -AccessTier cool -Force 
        $account.EnableHttpsTrafficOnly | should -Be $false
        $account.AccessTier | should -Be "Cool"
        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBasic |  Set-AzStorageAccount   -UpgradeToStorageV2 -PublicNetworkAccess Enabled
        $account.Kind | should -Be "StorageV2"
        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBasic -IncludeGeoReplicationStats
        ($account.GeoReplicationStats -eq $null) | should -Be $false
        $account.PublicNetworkAccess | should -Be Enabled

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBasic -Force -AsJob

        $Error.Count | should -be 0
    }

    It "create context for dataplane" {
        $Error.Clear()

        $accountNameDp = $accountName + "dp"

        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameDp -SkuName Premium_LRS -Location "centraluseuap" -Kind BlockBlobStorage  -AssignIdentity
        $a.StorageAccountName | Should -Be $accountNameDp
        $a.ResourceGroupName | Should -Be $rgname
        $a.Sku.Name | Should -Be Premium_LRS
        $a.Kind | Should -Be BlockBlobStorage
        $a.Location | Should -Be "centraluseuap"
        $a.Identity.Type | Should -Be "SystemAssigned"

        $a | New-AzStorageContainer -Name $containerName

        $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountNameDp
        $ctx = New-AzStorageContext -StorageAccountName $accountNameDp -StorageAccountKey $key[0].Value
        $containers = Get-AzStorageContainer -Context $ctx
        $containers.Count | should -BeGreaterOrEqual 1

        New-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $accountNameDp -KeyName key1

        sleep 30

        Set-AzCurrentStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameDp 
        $containers = Get-AzStorageContainer
        $containers.Count | should -BeGreaterOrEqual 1
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameDp -Force -AsJob      

        $Error.Count | should -be 0
    }
    

    It "Blob Container" {
        $Error.Clear()

        #Blob Service SRP
        $accountNameBlobCtn = $accountName + "bctn"
        $containerName = GetRandomContainerName #Add 1 every time
        $containerName2 = "ctrtodelete"
        New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -SkuName Standard_LRS -Location "westus" -Kind StorageV2 

        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName 
        $con.Name | Should -Be $containerName
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName2 -PublicAccess Blob -Metadata @{tag0="value0";tag1="value1"} 
        $con.Name | Should -Be $containerName2
        $con.Metadata.Count | Should -Be 2
        $con.PublicAccess | Should -Be Blob
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName2 
        $con.Name | Should -Be $containerName2
        $con.Metadata.Count | Should -Be 2
        $con.PublicAccess | Should -Be Blob
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName -Metadata @{tag0="value0"} -PublicAccess Container #-debug
        $con.Name | Should -Be $containerName
        $con.Metadata.Count | Should -Be 1
        $con.PublicAccess | Should -Be Container
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName -Metadata @{tag0="value0";tag1="value1";tag2="value2"}  -PublicAccess None
        $con.Name | Should -Be $containerName
        $con.Metadata.Count | Should -Be 3
        $con.PublicAccess | Should -Be None
        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName2 -Force

        Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName -Tag  tag1,tag2 
        Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName -Tag tag1 
        $tags = (Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName).LegalHold.Tags
        $tags.Count | Should -Be 1

        $imp = Get-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -ContainerName $containerName 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 0
        $imp.State | Should -Be Deleted

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -ContainerName $containerName -ImmutabilityPeriod 2 -AllowProtectedAppendWrite $false 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $imp.State | Should -Be Unlocked
        $imp.AllowProtectedAppendWrites | Should -be $false
        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -ContainerName $containerName -AllowProtectedAppendWrite $true 
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $imp.State | Should -Be Unlocked
        $imp.AllowProtectedAppendWrites | Should -be $true

        $imp = remove-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -ContainerName $containerName -Etag $imp.Etag
        $imp.ImmutabilityPeriodSinceCreationInDays | Should -Be 0
        $imp.State | Should -Be Deleted
        $imp.AllowProtectedAppendWrites | Should -be $null

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -ContainerName $containerName -ImmutabilityPeriod 1
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

        $c = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName
        $c.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $c.ImmutabilityPolicy.State | Should -Be Locked
        $c.ImmutabilityPolicy.AllowProtectedAppendWrites | Should -be $null
        $c.LegalHold.HasLegalHold | should -be $true
        $c.LegalHold.Tags.Count | should -be 1

        Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName -Tag tag2     
        $c = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName
        $c.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | Should -Be 2
        $c.ImmutabilityPolicy.State | Should -Be Locked
        $c.ImmutabilityPolicy.AllowProtectedAppendWrites | Should -be $null
        $c.LegalHold.HasLegalHold | should -be $false
        $c.LegalHold.Tags.Count | should -be 0

        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Name $containerName -Force
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameBlobCtn -Force

        $Error.Count | should -be 0
    }
    

    It "Blob Service properties" {
        $Error.Clear()

        # Blob Service properties  
        $accountNamebsp = $accountName + "bsp"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNamebsp -SkuName Standard_LRS -Location eastus 
        $bp = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamebsp |Update-AzStorageBlobServiceProperty -DefaultServiceVersion 2018-03-28 
        $bp.DefaultServiceVersion | Should -Be 2018-03-28

        Enable-AzStorageBlobDeleteRetentionPolicy -ResourceId $bp.Id -PassThru -RetentionDays 3 -AllowPermanentDelete 
        $bp = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamebsp 
        $bp.DeleteRetentionPolicy.Enabled | Should -Be $true
        $bp.DeleteRetentionPolicy.Days | Should -Be 3
        $bp.DeleteRetentionPolicy.AllowPermanentDelete | Should -Be $true

        Disable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $accountNamebsp -PassThru
        $bp = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamebsp
        $bp.DeleteRetentionPolicy.Enabled | Should -Be $false

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamebsp -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "NetworkRule" {
        $Error.Clear()

        $vnet1 = $testNode.SelectSingleNode("vnet[@id='1']").'#text'
        $vnet2 = $testNode.SelectSingleNode("vnet[@id='2']").'#text'

        ######### Prepare ############
        # New-AzureRmResourceGroup -Name $rgname -Location "eastus2euap"
        # New-AzureRmVirtualNetwork -ResourceGroupName $rgname -Location "eastus2euap" -AddressPrefix 10.0.0.0/24 -Name "vnettry1" 
        # Get-AzureRmVirtualNetwork -ResourceGroupName $rgname -Name "vnettry1" | Add-AzureRmVirtualNetworkSubnetConfig -Name "subnet1" -AddressPrefix "10.0.0.0/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzureRmVirtualNetwork 
        # Get-AzureRmVirtualNetwork -ResourceGroupName $rgname -Name "vnettry1" | Add-AzureRmVirtualNetworkSubnetConfig -Name "subnet2" -AddressPrefix "10.0.0.16/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzureRmVirtualNetwork 

        #Create Account, if the accounts already exist, skip this step
        #New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName -SkuName Standard_LRS -Location "eastus2euap"
        #New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName2 -SkuName Standard_LRS -Location "eastus2euap"
        #New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName2 -SkuName Standard_LRS -Location "eastus2(stage)"

        $accountNameNetRule1 = $accountName + "nr1"
        $accountNameNetRule2 = $accountName + "nr2"

        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNetRule1 -SkuName Standard_LRS -Location eastus
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNetRule2 -SkuName Standard_LRS -Location eastus

        #Update the Account NetworkACL with JSON
        echo "Update the Account NetworkACL with JSON"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1 -Bypass AzureServices -DefaultAction Allow -IpRule (@{IPAddressOrRange="20.11.0.0/16";Action="allow"},
            @{IPAddressOrRange="28.0.2.0/19";Action="allow"},
            @{IPAddressOrRange="129.0.2.34/25";Action="allow"})`
            -VirtualNetworkRule (@{VirtualNetworkResourceId=$vnet1;Action="allow"},
                @{VirtualNetworkResourceId=$vnet2;Action="allow"}) `
            -ResourceAccessRule (@{ResourceId=$vnet1;TenantId=$globalNode.tenantId},
                @{ResourceId=$vnet2;TenantId=$globalNode.tenantId})
        $rule.ResourceAccessRules.Count | should -be 2
        $rule.Bypass | should -be AzureServices
        $rule.DefaultAction | should -be Allow
        $rule.IpRules.Count | should -be 3
        $rule.VirtualNetworkRules.Count | should -be 2

        #Get Account NetworkACL, and show IpRules, VirtualNetworkRules
        echo "Get Account NetworkACL, and show IpRules, VirtualNetworkRules"
        #Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName | Set-AzureRmCurrentStorageAccount
        $rule = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1
        $rule.Bypass | should -be AzureServices
        $rule.DefaultAction | should -be Allow
        $rule.IpRules.Count | should -be 3
        $rule.VirtualNetworkRules.Count | should -be 2
        $rule.ResourceAccessRules.Count | should -be 2

        #Clean the IpRules, and add 6 Rules with string Array
        echo "Clean the IpRules, and add 6 Rules with string Array"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1 -IPRule @()
        $rule.IpRules.Count | should -be 0
        $iprules = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -IPAddressOrRange "20.11.0.0/16","232.0.18.177/7","89.1.206.243/3","191.2.139.113/22","252.3.217.172/11","146.4.106.152/26","229.5.65.223/16"
        $iprules.Count | Should -Be 7
        $iprules = Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -IPAddressOrRange "20.11.0.0/16","232.0.18.177/7"
        $iprules.Count | Should -Be 5

        #Clean the VirtualNetworkRules, and add 6 Rules with string Array
        echo "Clean the VirtualNetworkRules, and add 2 Rules with string Array"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1 -VirtualNetworkRule @()
        $rule.VirtualNetworkRules.Count | should -be 0
        $networkrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -VirtualNetworkResourceId $vnet1,$vnet2 
        $networkrule.Count | should -be 2
        $networkrule = Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -VirtualNetworkResourceId $vnet1 
        $networkrule.Count | should -be 1
        $networkrule = Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -VirtualNetworkResourceId $vnet2 
        $networkrule.Count | should -be 0
        $networkrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -VirtualNetworkResourceId $vnet1,$vnet2 
        $networkrule.Count | should -be 2

        #Clean the ResourceAccessRules, and add 2 Rules
        echo "Clean the ResourceAccessRules, and add 2 Rules"         
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1 -ResourceAccessRule @() 
        $rule.ResourceAccessRules.Count | should -be 0
        $resrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -TenantId $globalNode.tenantId -ResourceId $vnet1
        $resrule.Count | should -be 1
        $resrule = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -TenantId $globalNode.tenantId -ResourceId $vnet2
        $resrule.Count | should -be 2
        $resrule = Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $accountNameNetRule1 -TenantId $globalNode.tenantId -ResourceId $vnet1
        $resrule.Count | should -be 1
       
        #Clean the IpRules on Account2, Pipeline to add IpRules from Account1 to Account2
        echo "Clean the IpRules on Account2, Pipeline to add IpRules from Account1 to Account2"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule2 -IPRule @()
        $rule.IpRules.Count | should -be 0
        # Add Unary Operators ",", see more detail in http://stackoverflow.com/questions/29973212/pipe-complete-array-objects-instead-of-array-items-one-at-a-time
        $iprules = (Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1).IpRules | Add-AzStorageAccountNetworkRule  -ResourceGroupName $rgname -Name $accountNameNetRule2 
        $iprules.Count | Should -Be 5

        #Clean the ResourceAccessRule on Account2, Pipeline to add ResourceAccessRule from Account1 to Account2
        Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule2 -ResourceAccessRule @() 
        # Add Unary Operators "," to make the add-* cmdlet only run once to add all rules together, see more detail in http://stackoverflow.com/questions/29973212/pipe-complete-array-objects-instead-of-array-items-one-at-a-time
        ,((Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1).ResourceAccessRules) | Add-AzStorageAccountNetworkRule  -ResourceGroupName $rgname -Name $accountNameNetRule2 
        $rule = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1
        $rule.ResourceAccessRules.Count | should -be 1

        #Set Bypass and DefaultAction for Account2
        echo "Set Bypass and DefaultAction for Account2"
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule2 -DefaultAction Deny
        $rule.DefaultAction | should -be Deny
        $rule = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule2 -Bypass Logging,Metrics -DefaultAction Allow
        $rule.Bypass | should -be "Logging, Metrics"
        $rule.DefaultAction | should -be Allow

        #Get Account2 NetworkACL, and show IpRules, VirtualNetworkRules
        echo "Get Account2 NetworkACL, and show IpRules, VirtualNetworkRules"
        $rule = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountNameNetRule1
        $rule.Bypass | should -be AzureServices
        $rule.DefaultAction | should -be Allow
        $rule.IpRules.Count | should -be 5
        $rule.VirtualNetworkRules.Count | should -be 2
        $rule.ResourceAccessRules.Count | should -be 1
    
        Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNetRule1| Remove-AzStorageAccount -Force
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNetRule2 -Force

        $Error.Count | should -be 0
    }
    

    It "LifeCycle" {
        $Error.Clear()

        $accountNameLc1 = $accountName + "lc1"
        $accountNameLc2 = $accountName + "lc2"

        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLc1 -SkuName Standard_LRS -Location eastus
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLc2 -SkuName Standard_LRS -Location eastus

        # Resource id for storage account 2 
        $id = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLc2).Id

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
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLc1 -Rule $rule1,$rule2 
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
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLc1 -Policy (@{
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

        $policy2 = Get-AzStorageAccountManagementPolicy -StorageAccountResourceId $id | Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLc2
        $policy2.Rules.Count | should -Be 2

        $policy2 = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLc2
        $policy2.Rules.Count | should -Be 2

        Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLc1 -PassThru

        get-Azstorageaccount -ResourceGroupName $rgname -Name $accountNameLc1 | Remove-AzStorageAccountManagementPolicy   
        
        Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLc1| Remove-AzStorageAccount -Force
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLc2 -Force   

        $Error.Count | should -be 0
    }
    

    It "new sku Kind： FileStorage (Premium_ZRS)" {
        $Error.Clear()

        $accountNameFS = $accountName + "fs"

        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameFS -SkuName Premium_LRS -Location "westus" -Kind FileStorage  -AccessTier hot -EnableHttpsTrafficOnly $false         
        $account.ResourceGroupName | should -Be $rgname
        $account.StorageAccountName | should -Be $accountNameFS
        $account.Sku.Name | should -Be "Premium_LRS"
        $account.Location | should -Be "westus"
        $account.Kind | should -Be "FileStorage"

        $share2 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFS -Name testsharefs2 -AccessTier Premium
        $share2.AccessTier | Should -Be "Premium"
        $share2 = Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFS -Name testsharefs2 -QuotaGiB 102 -Metadata @{"tag1" = "value1"; "tag2" = "value2"; "tag3" = "value3" } -AccessTier Premium
        $share2.QuotaGiB | Should -Be 102 
        $share2.Metadata.Count | Should -Be 3 
        $share2.AccessTier | Should -Be "Premium"
        $share2.ShareUsageBytes | Should -Be $null

        $share2 | Remove-AzRmStorageShare -Force

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameFS -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "Managed File Share - Large File Share" {
        $Error.Clear()

        $accountNameLFS = $accountName + "lfs"
        # Large File Share 
        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -SkuName Standard_LRS -Location "westus2" -Kind StorageV2 -EnableLargeFileShare #-debug
        $account.LargeFileSharesState | should -BeIn "Enabled",$null
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -EnableLargeFileShare #-SkuName Standard_LRS -UpgradeToStorageV2
        $account.LargeFileSharesState | should -BeIn "Enabled",$null

        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Name bigtest -QuotaGiB 100001
        $share.QuotaGiB | should -be 100001

        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Name sharetest1 -QuotaGiB 101 -Metadata @{"tag1" = "value1"; "tag2" = "value2" } -AccessTier Cool
        $share.QuotaGiB | Should -Be 101 
        $share.Metadata.Count | Should -Be 2 
        $share.AccessTier | Should -Be "Cool"
        $share.ShareUsageBytes | Should -BeNullOrEmpty 

        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS 
        $share.Count | Should -BeGreaterOrEqual 1 

        $shares = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameLFS | Get-AzRmStorageShare
        $shares.Count | Should -BeGreaterOrEqual 1 

        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Name sharetest1
        $share.QuotaGiB | Should -Be 101 
        $share.Metadata.Count | Should -Be 2 
        $share.ShareUsageBytes | Should -BeNullOrEmpty
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Name sharetest1 -GetShareUsage
        $share.ShareUsageBytes | Should -Be 0
        $share = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameLFS | Get-AzRmStorageShare -Name sharetest1 -GetShareUsage
        $share.ShareUsageBytes | Should -Be 0
        $share = Get-AzRmStorageShare -ResourceId $share.Id -GetShareUsage
        $share.ShareUsageBytes | Should -Be 0
        $share = Get-AzRmStorageShare -ResourceId $share.Id  
        $share.ShareUsageBytes | Should -BeNullOrEmpty
        
        $account | New-AzRmStorageShare -Name testshare -AccessTier Hot
        $share = $account | Get-AzRmStorageShare -Name testshare
        $share.AccessTier | Should -Be "Hot"
        $share = Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Name bigtest -AccessTier Cool
        $share.AccessTier | Should -Be "Cool"
        #$share = $share | Update-AzRmStorageShare  -AccessTier TransactionOptimized 
        #Assert-AreEqual "TransactionOptimized" $share.AccessTier
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Name testsshare -Force      
     

        $share | Remove-AzRmStorageShare -Force
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameLFS -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "Identity SAS" {
        $Error.Clear()

        $accNameIdSas1 = $testNode.SelectSingleNode("accountName[@id='1']").'#text'
        $accNameIdSas2 = $testNode.SelectSingleNode("accountName[@id='2']").'#text'
        $ctrNameIdSas = $testNode.SelectSingleNode("containerName[@id='1']").'#text'
    
        $ctx = New-AzStorageContext -StorageAccountName $accNameIdSas1 -UseConnectedAccount
        #$ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -AccountName $accountName).Context

        #Container SASPS 
        $StartTime = Get-Date
        $EndTime = $startTime.AddDays(6)
        $sas = New-AzStorageContainerSASToken -Name $ctrNameIdSas -Permission rwld  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime
        $ctxsas = New-AzStorageContext -StorageAccountName $accNameIdSas1 -SasToken $sas
        Get-AzStorageBlob -Container $ctrNameIdSas -MaxCount 10 -Context $ctxsas

        # Blob SAS
        $StartTime = Get-Date
        $EndTime = $startTime.AddDays(6)
        $blobsas = New-AzStorageBlobSASToken -Container $ctrNameIdSas -Blob test -Permission rwld -StartTime $StartTime -ExpiryTime $EndTime -context $ctx
        $ctxblobsas = New-AzStorageContext -StorageAccountName $accNameIdSas1 -SasToken $blobsas
        Get-AzStorageBlob -Container $ctrNameIdSas -Blob test -Context $ctxblobsas 

        # Copy blob cross tenant with 
        $destctx = New-AzStorageContext -StorageAccountName $accNameIdSas2
        Start-AzStorageBlobCopy -SrcContainer $ctrNameIdSas -SrcBlob test -Context $ctx -DestContainer $ctrNameIdSas -DestBlob test1 -DestContext $destctx -Force

        # Revoke will cause existing SAS not work
        Revoke-AzStorageAccountUserDelegationKeys -ResourceGroupName $rgname -AccountName $accNameIdSas1
        sleep 30
        #should fail
        $Error.Count | should -be 0
        $error.Clear()
        Get-AzStorageBlob -Container $ctrNameIdSas -Blob test -Context $ctxblobsas  -ErrorAction SilentlyContinue
        $Error[0].Exception.Message.Contains("Server failed to authenticate the request. Make sure the value of Authorization header is formed correctly including the signature.") | should -Be $true
        
        $Error.Count | should -be 1
        $error.Clear()

        #create SAS again will work
        $sas = New-AzStorageContainerSASToken -Name $ctrNameIdSas -Permission rwld  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime
        $ctxsas = New-AzStorageContext -StorageAccountName $accNameIdSas1 -SasToken $sas
        Get-AzStorageBlob -Container $ctrNameIdSas -MaxCount 10 -Context $ctxsas | Out-Null
        $blobsas = New-AzStorageBlobSASToken -Container $ctrNameIdSas -Blob test -Permission rwld -StartTime $StartTime -ExpiryTime $EndTime -context $ctx
        $ctxblobsas = New-AzStorageContext -StorageAccountName $accNameIdSas1 -SasToken $blobsas
        Get-AzStorageBlob -Container $ctrNameIdSas -Blob test -Context $ctxblobsas | Out-Null
        
        $Error.Count | should -be 0
        $error.Clear()

        ### Error message
        $StartTime = Get-Date
        $EndTime = $startTime.AddDays(6)
        New-AzStorageContainerSASToken -Name $ctrNameIdSas  -context $ctx -StartTime $StartTime -ExpiryTime $EndTime -Policy 123 -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "When input Storage Context is OAuth based, Saved Policy is not supported.*"
        New-AzStorageContainerSASToken -Name $ctrNameIdSas -Permission rwld  -context $ctx -StartTime $EndTime -ExpiryTime $StartTime.AddMinutes(1) -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "Start time * is later than expiry time *."
        New-AzStorageContainerSASToken -Name $ctrNameIdSas -Permission rwld  -context $ctx -StartTime $startTime.AddHours(-2) -ExpiryTime $startTime.AddHours(-1) -ErrorAction SilentlyContinue
        $Error[0].Exception.Message  | should -BeLike "Expiry time * is earlier than now.*"
        New-AzStorageContainerSASToken -Name $ctrNameIdSas -Permission rwld  -context $ctx -StartTime $startTime -ExpiryTime $EndTime.AddDays(2) -ErrorAction SilentlyContinue
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

        $accountNameEncryp = $accountName + "ska"

        $account = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncryp -SkuName Standard_LRS -Location 'East US 2 EUAP' -Kind StorageV2  -EncryptionKeyTypeForTable Account -EncryptionKeyTypeForQueue Account -AllowSharedKeyAccess $false
        $account.Encryption.Services.Queue.Keytype | should -be "account"
        $account.Encryption.Services.Table.Keytype | should -be "account"
        $account.AllowSharedKeyAccess | Should -be $false

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncryp  -AllowSharedKeyAccess $true  -AssignIdentity
        $account.AllowSharedKeyAccess | Should -be $true        
        $account.Encryption.Services.Queue.Keytype | should -be "account"
        $account.Encryption.Services.Table.Keytype | should -be "account"
        $account.Identity.Type | Should -Be "SystemAssigned"

        Remove-AzStorageAccount  -ResourceGroupName $rgname -StorageAccountName $accountNameEncryp -Force -AsJob

        $Error.Count | should -be 0
    }
    

    It "key version" {
        $Error.Clear()

        #keyversion
        $keyVaultNode = $testNode.SelectSingleNode("keyVault[@id='1']")
        $vaultName = $keyVaultNode.vaultName
        $KeyvaultUri = $keyVaultNode.keyVaultUri
        $keyname = $keyVaultNode.keyName
        $keyversion = $keyVaultNode.keyVersion

        $accountNameKeyV = $accountName + "kv"
        # Set up a new account 
        $a = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV -AssignIdentity -SkuName Standard_LRS -Location eastus
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $rgname -ObjectId $a.Identity.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation

        $a = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV -StorageEncryption
        $a.Encryption.KeySource | Should -Be “Microsoft.Storage”

        # set keyvault without keyversion, to enable key rotation
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV -KeyvaultEncryption -KeyVaultUri $KeyvaultUri -KeyName $keyname 
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV
        $a.Encryption.KeySource | Should -Be “Microsoft.Keyvault”
        (New-Object -TypeName System.Uri -ArgumentList $KeyvaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host
        $a.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname
        $a.Encryption.KeyVaultProperties.KeyVersion | Should -BeNullOrEmpty

        # set keyvault with keyversion
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV -KeyvaultEncryption -KeyVaultUri $KeyvaultUri -KeyName $keyname -KeyVersion $keyversion
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV
        $a.Encryption.KeySource | Should -Be “Microsoft.Keyvault”
        (New-Object -TypeName System.Uri -ArgumentList $KeyvaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host
        $a.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname
        $a.Encryption.KeyVaultProperties.KeyVersion | Should -Be $keyversion

        # clean up keyversion to enable key rotation
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV -KeyvaultEncryption -KeyVaultUri $KeyvaultUri -KeyName $keyname -KeyVersion ""
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV
        $a.Encryption.KeySource | Should -Be “Microsoft.Keyvault”
        (New-Object -TypeName System.Uri -ArgumentList $KeyvaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host
        $a.Encryption.KeyVaultProperties.KeyName | Should -Be $keyname
        $a.Encryption.KeyVaultProperties.KeyVersion | Should -BeNullOrEmpty

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeyV -Force

        $Error.Count | should -be 0
    }
    

    It "doulbe Encryption" {
        $Error.Clear()

        $accountNameDE = $accountName + "de"
        #doulbe Encryption
        New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameDE -SkuName Standard_LRS -Location eastus -Kind StorageV2 -RequireInfrastructureEncryption
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameDE
        $a.Encryption.RequireInfrastructureEncryption | Should -BeTrue

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameDE -Force -Asjob

        $Error.Count | should -be 0
    }
    

    It "GZRS" {
        $Error.Clear()

        $accountNameGZRS = $accountName + "gzrs"
        $accountNameRAGZRS = $accountName + "rzgzrs"
          
        New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameGZRS -SkuName Standard_GZRS -Location eastus -Kind StorageV2 #-RequireInfrastructureEncryption
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameGZRS
        $a.Sku.Name | should -Be "Standard_GZRS"
        set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameGZRS -SkuName Standard_RAGZRS
        (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameGZRS).Sku.Name | should -Be "Standard_RAGZRS"

        New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRAGZRS -SkuName Standard_RAGZRS -Location eastus -Kind StorageV2
        (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRAGZRS).Sku.Name | should -Be "Standard_RAGZRS"
        set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRAGZRS -SkuName Standard_GZRS
        (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRAGZRS).Sku.Name | should -Be  "Standard_GZRS"

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameGZRS -Force 
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRAGZRS -Force

        $Error.Count | should -be 0
    }
    
    It "Failover "  -Skip {
        $Error.Clear()
        
        $accountNameFailover = $accountName + "fl"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFailover -SkuName Standard_RAGRS -Location eastus -Kind StorageV2 
    
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFailover -SkuName Standard_RAGRS

        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFailover -IncludeGeoReplicationStats
        $a
        $a.GeoReplicationStats
    
        $taskfailover = Invoke-AzStorageAccountFailover -ResourceGroupName $rgname -Name $accountNameFailover -Force -AsJob
        $taskfailover|Wait-Job

        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFailover
        $a.Sku.Name | Should -Be "Standard_LRS"

        Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFailover -SkuName Standard_RAGRS
        $a | Remove-AzStorageAccount -Force

        $Error.Count | should -be 0
    }
    
    It "MinimumTlsVersion , AllowBlobPublicAccess" {
        $Error.Clear()

        $accountNameTls = $accountName + "tls"
        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameTls -SkuName Standard_GRS -Location "westus" -Kind StorageV2  -MinimumTlsVersion TLS1_1 -AllowBlobPublicAccess $false
        $a.MinimumTlsVersion | Should -Be "TLS1_1"
        $a.AllowBlobPublicAccess | Should -BeFalse

        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameTls -MinimumTlsVersion TLS1_2 -AllowBlobPublicAccess $true -EnableHttpsTrafficOnly $true
        $a.MinimumTlsVersion | Should -Be "TLS1_2"
        $a.AllowBlobPublicAccess | Should -BeTrue

        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameTls -AsJob -Force
        $Error.Count | should -be 0
    }
    
    It "versioning , changefeed" {
        $Error.Clear()

        $accountNamevc = $accountName + "vc"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNamevc -SkuName Standard_LRS -Location eastus 

        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamevc -EnableChangeFeed $true -IsVersioningEnabled $true -ChangeFeedRetentionInDays 3
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamevc
        $p.ChangeFeed.Enabled | should -be $true
        $p.ChangeFeed.RetentionInDays | should -be 3
        $p.IsVersioningEnabled | should -be $true
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamevc -EnableChangeFeed $false -IsVersioningEnabled $false 
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamevc 
        $p.ChangeFeed.Enabled | should -be $false
        $p.IsVersioningEnabled | should -be $false

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNamevc -Force -AsJob

        $Error.Count | should -be 0
    }
    
    It "ORS" -Tag "2021-5-25" {
        $Error.Clear()

        $destAccountName = $testNode.SelectSingleNode("accountName[@id='4']").'#text'
        $srcAccountName = $testNode.SelectSingleNode("accountName[@id='5']").'#text'

        if ($Needprepare)
        {
            New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName -SkuName Standard_LRS -Location EastUs2
            New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName -SkuName Standard_LRS -Location EastUs2

            Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $destAccountName 
            Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $srcAccountName

            Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $destAccountName -IsVersioningEnabled $false -EnableChangeFeed $true
            Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $destAccountName -IsVersioningEnabled $true -EnableChangeFeed $true
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
        $destPolicy.SourceAccount | Should -Be $srcAccountName
        $destPolicy.DestinationAccount | Should -Be $destAccountName
        $destPolicy.PolicyId | should -Not -be $null 
        $destPolicy.Rules.Count | Should -Be 2 
        $destPolicy.Rules[0].SourceContainer | Should -Be "src1"
        $destPolicy.Rules[0].DestinationContainer | Should -Be "dest1"
        $destPolicy.Rules[0].RuleId  | Should -Not -be $null 
        $destPolicy.Rules[0].Filters | Should -BeNullOrEmpty
        $destPolicy.Rules[1].SourceContainer | Should -Be "src"
        $destPolicy.Rules[1].DestinationContainer | Should -Be "dest"
        $destPolicy.Rules[1].RuleId  | should -Not -be $null 
        $destPolicy.Rules[1].Filters.PrefixMatch.Count | Should -Be 3 
        ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z") | Should -Be "2019-01-02T00:00:00Z"

        $policyId = $destPolicy[0].PolicyId

        $srcPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $srcAccountName -PolicyId $policyId
        $srcPolicy.SourceAccount | Should -Be $srcAccountName
        $srcPolicy.DestinationAccount | Should -Be $destAccountName
        $srcPolicy.PolicyId | Should -Be $policyId
        $srcPolicy.Rules.Count | Should -Be 2 
        $srcPolicy.Rules[0].SourceContainer | Should -Be "src1"
        $srcPolicy.Rules[0].DestinationContainer | Should -Be "dest1"
        $srcPolicy.Rules[0].RuleId  | should -Not -be $null 
        $srcPolicy.Rules[0].Filters | Should -BeNullOrEmpty
        $srcPolicy.Rules[1].SourceContainer | Should -Be "src"
        $srcPolicy.Rules[1].DestinationContainer | Should -Be "dest"
        $srcPolicy.Rules[1].RuleId  | should -Not -be $null 
        $srcPolicy.Rules[1].Filters.PrefixMatch.Count | Should -Be 3
        ($srcPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z") | Should -Be "2019-01-02T00:00:00Z"
    
        # Validate dataplane
        $ctxsrc = (Get-AzStorageAccount  -ResourceGroupName $rgname -StorageAccountName $srcAccountName ).Context
        $ctxdest = (Get-AzStorageAccount  -ResourceGroupName $rgname -StorageAccountName $destAccountName ).Context
        $blobdest = Get-AzStorageBlob -Container dest1 -Blob testors -Context $ctxdest
        $blobdest.BlobProperties.ObjectReplicationDestinationPolicyId  | should -Not -be $null 
        $blobdest.BlobProperties.ObjectReplicationSourceProperties | Should -BeNullOrEmpty
        $blobsrc = Get-AzStorageBlob -Container src1 -Blob testors -Context $ctxsrc
        $blobsrc.BlobProperties.ObjectReplicationDestinationPolicyId | Should -BeNullOrEmpty
        $blobsrc.BlobProperties.ObjectReplicationSourceProperties[0].PolicyId | should -Not -be $null 
        $blobsrc.BlobProperties.ObjectReplicationSourceProperties[0].Rules[0].RuleId | should -Not -be $null 
        $blobsrc.BlobProperties.ObjectReplicationSourceProperties[0].Rules[0].ReplicationStatus | Should -Be "Complete"

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
        $destPolicy.SourceAccount | Should -Be $srcaccount.Id
        $destPolicy.DestinationAccount | Should -Be $destaccount.Id
        $destPolicy.PolicyId | should -Not -be $null 
        $destPolicy.Rules.Count | Should -Be 2 
        $destPolicy.Rules[0].SourceContainer | Should -Be "src1"
        $destPolicy.Rules[0].DestinationContainer | Should -Be "dest1"
        $destPolicy.Rules[0].RuleId  | Should -Not -be $null 
        $destPolicy.Rules[0].Filters | Should -BeNullOrEmpty
        $destPolicy.Rules[1].SourceContainer | Should -Be "src"
        $destPolicy.Rules[1].DestinationContainer | Should -Be "dest"
        $destPolicy.Rules[1].RuleId  | should -Not -be $null 
        $destPolicy.Rules[1].Filters.PrefixMatch.Count | Should -Be 3 
        ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z") | Should -Be "2019-01-02T00:00:00Z"

        $policyId = $destPolicy[0].PolicyId

        $srcPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $srcAccountName -PolicyId $policyId
        $srcPolicy.SourceAccount | Should -Be $srcaccount.Id
        $srcPolicy.DestinationAccount | Should -Be $destaccount.Id
        $srcPolicy.PolicyId | Should -Be $policyId
        $srcPolicy.Rules.Count | Should -Be 2 
        $srcPolicy.Rules[0].SourceContainer | Should -Be "src1"
        $srcPolicy.Rules[0].DestinationContainer | Should -Be "dest1"
        $srcPolicy.Rules[0].RuleId  | Should -Not -be $null 
        $srcPolicy.Rules[0].Filters | Should -BeNullOrEmpty
        $srcPolicy.Rules[1].SourceContainer | Should -Be "src"
        $srcPolicy.Rules[1].DestinationContainer | Should -Be "dest"
        $srcPolicy.Rules[1].RuleId  | should -Not -be $null 
        $srcPolicy.Rules[1].Filters.PrefixMatch.Count | Should -Be 3 
        ($srcPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z") | Should -Be "2019-01-02T00:00:00Z"

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

        $rgname = $testNode.fileAD.resourceGroupName
        $accountName = $testNode.fileAD.SelectSingleNode("accountName[@id='1']").'#text'
        $accountName2 = $testNode.fileAD.SelectSingleNode("accountName[@id='2']").'#text'
        $accountName3 = $testNode.fileAD.SelectSingleNode("accountName[@id='3']").'#text'
        $accountName4 = $testNode.fileAD.SelectSingleNode("accountName[@id='4']").'#text'
        $accountName5 = $testNode.fileAD.SelectSingleNode("accountName[@id='5']").'#text'

    
        $DomainName = $testNode.fileAD.domainName
        $NetBiosDomainName = $testNode.fileAD.netBiosDomainName
        $ForestName = $testNode.fileAD.forestName
        $DomainGuid = $testNode.fileAD.domainGuid
        $DomainSid = $testNode.fileAD.domainSid
        $AzureStorageSid = $testNode.fileAD.azureStorageSid
   
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

        $rgname = $globalNode.resourceGroupName
        $accountNamePITR = $accountName + "pitr"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNamePITR -SkuName Standard_LRS -Location eastus2euap
        Enable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $accountNamePITR -RetentionDays 5
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamePITR -EnableChangeFeed $true -IsVersioningEnabled $true
        Enable-AzStorageBlobRestorePolicy -ResourceGroupName $rgname -StorageAccountName $accountNamePITR -RestoreDays 4 -PassThru
        $properties = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamePITR 
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
        $job = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $accountNamePITR -TimeToRestore $timeToRestore -BlobRestoreRange $range1,$range2 -WaitForComplete -asjob 
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
            $job = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $accountNamePITR `
                -TimeToRestore (Get-Date).AddSeconds(-1) `
                -BlobRestoreRange (@{StartRange="aaa/abc";EndRange="bbb/abc"},@{StartRange="bbb/acc";EndRange=""}) -asjob 
            $job | wait-job
            $job.State | should -be "Completed" 
        }
        
        $timeToRestore = (Get-Date).AddMinutes(-1)
        $status = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $accountNamePITR `
            -TimeToRestore $timeToRestore `
            -BlobRestoreRange (@{StartRange="";EndRange=""}) 
        $status.RestoreId.Length | should -Be 36 # should be GUID format
        $status.FailureReason | should -be $null
        $status.Parameters.TimeToRestore | should -be (new-object System.DateTimeOffset -ArgumentList $timeToRestore)
        $status.Parameters.BlobRanges.Count | should -be 1
        $status.Parameters.BlobRanges[0].StartRange | should -be ""
        $status.Parameters.BlobRanges[0].EndRange | should -be ""
        sleep 10
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamePITR  -IncludeBlobRestoreStatus 
        $a.BlobRestoreStatus.Status | should -be "InProgress" 
        $a.BlobRestoreStatus.RestoreId | should -Be $status.RestoreId
        #$a.BlobRestoreStatus.Parameters.TimeToRestore | should -be (new-object System.DateTimeOffset -ArgumentList $timeToRestore)
        while ($a.BlobRestoreStatus.Status -eq "InProgress")
        {        
            sleep 10
            $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNamePITR  -IncludeBlobRestoreStatus 
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

        Disable-AzStorageBlobRestorePolicy -ResourceGroupName $rgname -StorageAccountName $accountNamePITR -ErrorAction SilentlyContinue  
        $properties = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNamePITR 
        $properties.RestorePolicy.Enabled | should -Be $false
        
        Remove-AzStorageAccount -ResourceGroupName $globalNode.resourceGroupName -Name $accountNamePITR

        $Error.Clear()
        $Error.Count | should -be 0
    }
    
    It "Share Soft delete" {
        $Error.Clear()

        $shareName1 = "test01"
        $shareName2 = "test02"
        $accountNameSSD = $accountName + "sharesoftdel"

        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSSD -SkuName Standard_LRS -Location eastus 

        #Enable softdlete
        Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 1 #-debug
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSSD 
        {$p.ShareDeleteRetentionPolicy.Enabled} | should -be $true
        Assert-AreEqual 1 $p.ShareDeleteRetentionPolicy.Days

        $Originshares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -IncludeDeleted 
        $OriginNotdeleteshares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD 

        # create 2 shares and revmove 1
        New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName1
        New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName2

        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName1 -Force

        # list all shares include the deleted ones
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD 
        Assert-AreEqual ($OriginNotdeleteshares.count+1) $shares.count
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -IncludeDeleted 
        Assert-AreEqual ($Originshares.count+2) $shares.count

        # get single share
        $share2 = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName2 -GetShareUsage
        $share2.ShareUsageBytes | should -be 0

        # find one deleted share
        $deletedshare = (Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -IncludeDeleted | ? {($_.Deleted) -and ($_.Name -eq $shareName1)})[0]
        Assert-AreEqual $true $deletedshare.Deleted

        #restore the share
        sleep 30
        Restore-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName1 -DeletedShareVersion $deletedshare.Version


        #list shares
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD 
        Assert-AreEqual ($OriginNotdeleteshares.count+2) $shares.count

        #Disable softdlete
        Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -EnableShareDeleteRetentionPolicy $false
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSSD 
        {!$p.ShareDeleteRetentionPolicy.Enabled} | should -be $true

        #remove shares
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName1 -Force
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameSSD -Name $shareName2 -Force

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSSD -Force -AsJob

        $Error.Count | should -be 0
    }
  
    It "EnryptionScope" {
        $Error.Clear()

        $accountNameEncypScope = $accountName + "encryp"
        $scopename = "testscope"
        $msscopename = "mstestscope1"
        $KeyUri = $testNode.keyVault.SelectSingleNode("keyUri[@id='1']").'#text'
        $KeyUri2 = $testNode.keyVault.SelectSingleNode("keyUri[@id='2']").'#text'
        $KeyUri3 = $testNode.keyVault.SelectSingleNode("keyUri[@id='3']").'#text'

        # Prepare storage account 
        $acc = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameEncypScope -SkuName Standard_LRS -Location eastus -AssignIdentity
        Set-AzKeyVaultAccessPolicy -VaultName $testNode.keyVault.vaultName -ResourceGroupName $rgname -ObjectId $acc.Identity.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation

        $scope = New-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -EncryptionScopeName $msscopename -StorageEncryption -RequireInfrastructureEncryption 
        $scope.Name | should -be $msscopename
        $scope.Source  | should -be "Microsoft.Storage" 
        $scope.RequireInfrastructureEncryption | should -be $true
        $scope2 = New-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri
        $scope2.Name | Should -Be $scopename
        $scope2.Source | Should -Be "Microsoft.Keyvault"
        $scope2.KeyVaultProperties.keyUri | should -BeLike $KeyUri.Replace(":443","*") 
        $scope2 = New-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri2
        $scope2.Name | Should -Be $scopename
        $scope2.Source | Should -Be "Microsoft.Keyvault"
        (New-Object -TypeName System.Uri -ArgumentList $scope2.KeyVaultProperties.keyUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $KeyUri2).Host

        # Update Storage account
        Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -StorageEncryption
        Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -KeyvaultEncryption -KeyName wrappingKey2 -KeyVaultUri $testNode.keyVault.keyVaultUri
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope
        (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $testNode.keyVault.argumentList).Host
        $a.Encryption.KeyVaultProperties.KeyName | Should -Be "wrappingKey2"
        $a.Encryption.KeySource | Should -Be "Microsoft.Keyvault"

        Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -KeyvaultEncryption -KeyName wrappingKey -KeyVaultUri $testNode.keyVault.keyVaultUri -KeyVersion $testNode.keyVault.keyVersion
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope
        (New-Object -TypeName System.Uri -ArgumentList $a.Encryption.KeyVaultProperties.KeyVaultUri).Host | should -Be (New-Object -TypeName System.Uri -ArgumentList $testNode.keyVault.argumentList).Host
        $a.Encryption.KeyVaultProperties.KeyName | Should -Be "wrappingKey"
        $a.Encryption.KeyVaultProperties.KeyVersion | Should -Be $testNode.keyVault.keyVersion
        $a.Encryption.KeySource | Should -Be "Microsoft.Keyvault"

        Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameEncypScope | New-AzStorageEncryptionScope  -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri

        #get single scope
        Get-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -EncryptionScopeName $scopename

        Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameEncypScope | Get-AzStorageEncryptionScope -EncryptionScopeName $scopename

        #list scope, will list all scopes
        Get-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope 
        Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameEncypScope | Get-AzStorageEncryptionScope 

        # Set to Disabled.
        ### Move the encryption scope to CMK by passing { 'properties': { 'state':'Disabled' } }
        $scope = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameEncypScope | Update-AzStorageEncryptionScope -EncryptionScopeName $scopename -State Disabled 
        $scope.State | Should -Be "Disabled"

        # Set to Enabled.
        ### Move the encryption scope to CMK by passing { 'properties': { 'state':'Enabled' } }
        $scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -EncryptionScopeName $scopename -State Enabled 
        $scope.State | Should -Be "Enabled"

        # Set to CMK.
        ### Move the encryption scope to CMK by passing { 'properties': { 'source':'Microsoft.KeyVault', 'keyVaultProperties':{ 'keyUri': '$key.Key.Kid' } } }
        $scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -EncryptionScopeName $scopename -KeyvaultEncryption -KeyUri $KeyUri
        $scope.Source | Should -Be "Microsoft.Keyvault"

        # Back to MMK, might fail for server issue with 400
        ### Move the encryption scope back to Microsoft Managed Keys by passing { 'properties': { 'source':'Microsoft.Storage' } }
        $scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -Name $scopename -StorageEncryption 
        $scope.Source | Should -Be "Microsoft.Storage"

        # create container
        $c = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -Name testcontainer -DefaultEncryptionScope $scopename -PreventEncryptionScopeOverride $true 
        $c.DefaultEncryptionScope | Should -Be $scopename
        $c.DenyEncryptionScopeOverride | Should -BeTrue

        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameEncypScope -Name testcontainer -Force
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameEncypScope -Force -AsJob
        $Error.Count | should -be 0
    } 

    It "Routing preference" {
        $Error.Clear()
        
        $accountNameRp = $accountName + "testrp"

        #create account 
        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp -SkuName Standard_LRS -Location eastus -Kind StorageV2 -PublishMicrosoftEndpoint $true -PublishInternetEndpoint $true -RoutingChoice MicrosoftRouting
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob  | Should -Not -Be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob  | Should -Not -Be $null
        $a.RoutingPreference.RoutingChoice | Should -Be "MicrosoftRouting"
        {$a.RoutingPreference.PublishInternetEndpoints} | Should -BeTrue
        {$a.RoutingPreference.PublishMicrosoftEndpoints} | Should -BeTrue

        #get Account property
        $a = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob  | Should -Not -be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob  | Should -Not -be $null
        $a.RoutingPreference.RoutingChoice | Should -Be "MicrosoftRouting"
        {$a.RoutingPreference.PublishInternetEndpoints} | Should -BeTrue
        {$a.RoutingPreference.PublishMicrosoftEndpoints} | Should -BeTrue

        # update account
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp -RoutingChoice InternetRouting -PublishMicrosoftEndpoint $false -PublishInternetEndpoint $false 
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | should -Be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -Be $null
        $a.RoutingPreference.RoutingChoice | Should -Be "InternetRouting"
        {!$a.RoutingPreference.PublishInternetEndpoints} | should -BeTrue
        {!$a.RoutingPreference.PublishMicrosoftEndpoints} | should -BeTrue
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp -RoutingChoice MicrosoftRouting 
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | Should -Be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | Should -Be $null
        $a.RoutingPreference.RoutingChoice | Should -Be "MicrosoftRouting"
        {!$a.RoutingPreference.PublishInternetEndpoints} | Should -BeTrue
        {!$a.RoutingPreference.PublishMicrosoftEndpoints} | Should -BeTrue
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp -PublishInternetEndpoint  $true
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | Should -Be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -Not -be $null
        $a.RoutingPreference.RoutingChoice | Should -Be "MicrosoftRouting"
        {$a.RoutingPreference.PublishInternetEndpoints} | should -BeTrue
        {!$a.RoutingPreference.PublishMicrosoftEndpoints}  | should -BeTrue
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp -PublishMicrosoftEndpoint $true 
        $a.PrimaryEndpoints.MicrosoftEndpoints.Blob | should -Not -be $null
        $a.PrimaryEndpoints.InternetEndpoints.Blob | should -Not -be $null
        $a.RoutingPreference.RoutingChoice | Should -Be "MicrosoftRouting"
        {$a.RoutingPreference.PublishInternetEndpoints} | should -BeTrue
        {$a.RoutingPreference.PublishMicrosoftEndpoints}  | should -BeTrue

        # clean up
        Remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameRp -AsJob -Force

        $Error.Count | should -be 0
    }    
    
    It "Key SAS Policy" {
        $Error.Clear()

        $accountNameKeySAS = $accountName + "keysasp"

        $a = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeySAS -Kind StorageV2 -SkuName Standard_LRS -Location eastus -KeyExpirationPeriodInDay 5 -SasExpirationPeriod "1.12:05:06" 
        $a.KeyCreationTime.Key1 | should -Not -Be $null
        $a.SasPolicy.SasExpirationPeriod | should -Be "1.12:05:06"
        $a.KeyPolicy.KeyExpirationPeriodInDays | should -Be 5
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeySAS  -KeyExpirationPeriodInDay 60 -SasExpirationPeriod "11.11:12:36"  -EnableHttpsTrafficOnly $true 
        $a.SasPolicy.SasExpirationPeriod | should -Be "11.11:12:36"
        $a.KeyPolicy.KeyExpirationPeriodInDays | should -Be 60
        $a = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeySAS  -KeyExpirationPeriodInDay 0 -SasExpirationPeriod "0.00:00:00"  -EnableHttpsTrafficOnly $true 
        $a.SasPolicy | should -Be $null
        $a.KeyPolicy | should -Be $null

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameKeySAS -Force -AsJob

        $Error.Count | should -be 0
    }   
    
    It "Extend Location" {
        $Error.Clear()

        $accountNameExtendLoc = $accountName + "extloc"

        $a = New-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $accountNameExtendLoc  -SkuName Premium_LRS -Location westus -EdgeZone "microsoftlosangeles1"
        $a.ExtendedLocation.Type | should -Be "EdgeZone"
        $a.ExtendedLocation.Name | should -Be "microsoftlosangeles1"

        remove-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $accountNameExtendLoc -Force -asjob

        $Error.Count | should -be 0
    } 
    
    It "User identity" -tag "longrunning" {
        $Error.Clear()

        $t = Get-AzResourceGroup |  ? {$_.ResourceGroupName -like "testUid*"} | Remove-AzResourceGroup -Force -asjob

        $rgName = 'testUid';
        $keyvaultName = $testNode.userIdentity.SelectSingleNode("keyVaultName[@id='1']").'#text'
        $keyvaultUri = "https://$($keyvaultName).vault.azure.net:443"
        $keyname = "wrappingKey"
        $keyversion = $testNode.userIdentity.SelectSingleNode("keyVersion[@id='1']").'#text'
        $keyvaultName2 = $testNode.userIdentity.SelectSingleNode("keyVaultName[@id='2']").'#text'
        $keyvaultUri2 = "https://$($keyvaultName2).vault.azure.net:443"
        $keyname2 = "wrappingKey"
        $keyversion2 = $testNode.userIdentity.SelectSingleNode("keyVersion[@id='2']").'#text'

        $useridentity= $testNode.UserIdentity.SelectSingleNode("userIdentity[@id='1']").'#text'
        $useridentity2= $testNode.UserIdentity.SelectSingleNode("userIdentity[@id='2']").'#text'

        $accountNamePrefix = $accountName + "uid"

        try
        {
        New-AzResourceGroup -Name $rgName -Location eastus2 -Force

        if ($false)
        {
             # login
                 $secpasswd = ConvertTo-SecureString $globalNode.secPwd -AsPlainText -Force
                 $cred = New-Object System.Management.Automation.PSCredential ($globalNode.applicationId, $secpasswd)
                 Add-AzAccount -ServicePrincipal -Tenant $globalNode.tenantId -SubscriptionId $globalNode.subscriptionId -Credential $cred 

            # prepare keyvault  
                $location =  'eastus2'; 

                $keyVault = New-AzKeyVault -VaultName $keyvaultName -ResourceGroupName $rgName -Location $location -EnablePurgeProtection
  
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $testNode.userIdentity.SelectSingleNode("adGroupObjectId[@id='1']").'#text' -PermissionsToKeys backup,create,delete,get,import,get,list,update,restore 
                $key = Add-AzKeyVaultKey -VaultName $keyvaultName -Name $keyname2 -Destination 'Software'    
                $keyversion2 = $key.Version

                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $testNode.userIdentity.SelectSingleNode("adGroupObjectId[@id='2']").'#text' -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $testNode.userIdentity.SelectSingleNode("adGroupObjectId[@id='3']").'#text' -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 
    
                $keyVault = New-AzKeyVault -VaultName $keyvaultName2 -ResourceGroupName $rgName -Location $location -EnablePurgeProtection

                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName2 -ResourceGroupName $rgName -ObjectId $testNode.userIdentity.SelectSingleNode("adGroupObjectId[@id='1']").'#text'-PermissionsToKeys backup,create,delete,get,import,get,list,update,restore 
                $key = Add-AzKeyVaultKey -VaultName $keyvaultName2 -Name $keyname2 -Destination 'Software'    
                $keyversion2 = $key.Version

                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName2 -ResourceGroupName $rgName -ObjectId $testNode.userIdentity.SelectSingleNode("adGroupObjectId[@id='2']").'#text' -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName2 -ResourceGroupName $rgName -ObjectId $testNode.userIdentity.SelectSingleNode("adGroupObjectId[@id='3']").'#text' -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation 

                # remove-AzKeyVault -VaultName $keyvaultName -ResourceGroupName $rgName

            # create 2 User identity, and give them access to keyvault
                $userId3 = New-AzUserAssignedIdentity -ResourceGroupName $rgName -Name regressiontestid3
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $userId3.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
                $useridentity= $userId3.Id
                $userId4 = New-AzUserAssignedIdentity -ResourceGroupName $rgName -Name regressiontestid4
                Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $userId4.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
                $useridentity2= $userId4.Id
                # Remove-AzUserAssignedIdentity -ResourceGroupName $rgName -Name regressiontestid3
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
            Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgname -ObjectId $account.Identity.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation

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
        $containerName = "blobinvcontainer"
        $accountNameBlobInv = $accountName + "blobinv"
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameBlobInv -SkuName Standard_LRS -Location eastus -EnableHierarchicalNamespace $true

        $con = New-AzRmStorageContainer -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv  -Name $containerName

        # set rules
        $rule1 = New-AzStorageBlobInventoryPolicyRule -Name Test1 -Destination $containerName -Disabled -Format Csv -Schedule Daily -ContainerSchemaField Name,Metadata,PublicAccess,Last-mOdified,LeaseStatus,LeaseState,LeaseDuration,HasImmutabilityPolicy,HasLegalHold -PrefixMatch con1,con2
        $rule2 = New-AzStorageBlobInventoryPolicyRule -Name Test2 -Destination $containerName -Format Parquet -Schedule Weekly  -BlobType blockBlob -PrefixMatch aaa,bbb -BlobSchemaField name,Last-Modified,Metadata,LastAccessTime,AccessTierInferred #,Tags
        $rule3 = New-AzStorageBlobInventoryPolicyRule -Name Test3 -Destination $containerName -Format Parquet -Schedule Daily  -IncludeSnapshot -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                -BlobSchemaField name,Creation-Time,Last-Modified,Content-Length,Content-MD5,BlobType,AccessTier,AccessTierChangeTime,Expiry-Time,hdi_isfolder,Owner,Group,Permissions,Acl,Metadata,LastAccessTime 
        # $rule4 = New-AzStorageBlobInventoryPolicyRule -Name Test4 -Destination $containerName -Disabled -Format Csv -Schedule Weekly -BlobSchemaField Name,BlobType,Content-Length,Creation-Time -BlobType blockBlob -IncludeBlobVersion

        $policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv  -Disabled -Rule $rule1,$rule2,$rule3
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

        $policy = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv 
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

        $removeSuccess = Remove-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv  -PassThru
        $removeSuccess | should -Be $true

        # Account pipeline
        $policy = Get-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv | Set-AzStorageBlobInventoryPolicy -Rule $rule1        
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
        $policy = Get-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv | Get-AzStorageBlobInventoryPolicy
        $policy.Enabled | should -Be $true
        $policy.Rules.Count | should -be 1
        $policy.Rules[0].Name | should -be "Test1"
        $policy = $null
        Get-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv | Remove-AzStorageBlobInventoryPolicy
    
        # set BlobInventoryPolicy with json
        $policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv -Policy (@{
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
        $policy = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv | Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv 
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
        $policy = ,((Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv).Rules) | Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv -Disabled
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
        Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $accountNameBlobInv | Remove-AzStorageBlobInventoryPolicy       
        
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameBlobInv -Force -AsJob     

        $Error.Count | should -be 0
    }
    
    It "File Share Snapshot" -Tag "2021-5-25"  {
        $Error.Clear()

        $accountNameFSSnap = $accountName + "fssnap"
        $shareName = "testshare"+(Get-date).Ticks
        $shareName2 = $shareName+"2"
        $shareName3 = $shareName+"3"

        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFSSnap -SkuName Standard_LRS -Location eastus 

        Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap  -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 1
    
        $share1 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName
        $share2 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName2    
        $share3 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName3
        $share1Snapshot1 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -Snapshot
        $share1Snapshot2 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -Snapshot  
        $share3Snapshot1 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName3 -Snapshot
        $share1.SnapshotTime | should -Be $null
        $share2.SnapshotTime | should -Be $null
        $share3.SnapshotTime | should -Be $null
        $share1Snapshot1.SnapshotTime | should -Not -Be $null
        $share1Snapshot2.SnapshotTime | should -Not -Be $null
        $share3Snapshot1.SnapshotTime | should -Not -Be $null

        $share2 | Remove-AzRmStorageShare -Force

        # list share
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -IncludeSnapshot -IncludeDeleted | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 6
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 5
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap  -IncludeDeleted | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 3
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 2

        # get single snapshot
        $share1Snapshot1_1 = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -SnapshotTime $share1Snapshot1.SnapshotTime
        $share1Snapshot1_1.SnapshotTime | should -Be $share1Snapshot1.SnapshotTime

        # remove single snapshot 
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -SnapshotTime $share1Snapshot1.SnapshotTime -Force
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 4

        #remove base share default (none)
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -Force -ErrorAction SilentlyContinue
        $Error[0].Exception.Message.Contains("The share has snapshots and the operation requires no snapshots.") | should -Be $true        
        $Error.Count | should -be 1
        $error.Clear()

        #remove base share include none
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -Force -Include None -ErrorAction SilentlyContinue
        $Error[0].Exception.Message.Contains("The share has snapshots and the operation requires no snapshots.") | should -Be $true        
        $Error.Count | should -be 1
        $error.Clear()

        #remove base share include snapshot
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName -Force -Include Snapshots
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 2

        #remove base share include Leased-Snapshots  
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -Name $shareName3 -Force -Include Leased-Snapshots
        $shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameFSSnap -IncludeSnapshot  | ?{ $_.Name -like "$($shareName)*"}
        $shares.Count | should -Be 0

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFSSnap -Force -AsJob

        $Error.Count | should -be 0
    }

    It "NFS" {
        $Error.Clear()

        $accountNameNFS = $accountName + "nfs"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNFS -SkuName Premium_LRS -Location eastus -Kind FileStorage 

        ### create share
        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1 -EnabledProtocol NFS -RootSquash RootSquash 
        $share.EnabledProtocols | Should -Be "NFS"
        $share.RootSquash | Should -Be "RootSquash"
        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare2 -EnabledProtocol NFS -RootSquash NoRootSquash 
        $share.EnabledProtocols | Should -Be "NFS"
        $share.RootSquash | Should -Be "NoRootSquash"
        $share = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare3 -EnabledProtocol SMB
        $share.EnabledProtocols | Should -Be "SMB"
        $share.RootSquash | Should -Be $null
        $share2 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare4 -EnabledProtocol NFS -RootSquash AllSquash -QuotaGiB 200 -Metadata @{"m1" = "v1"} 
        $share2.EnabledProtocols | Should -Be "NFS"
        $share2.RootSquash | Should -Be "AllSquash"
        $share2.QuotaGiB | Should -Be 200
        $share2.Metadata.Count | Should -Be 1 

        ### update share
        $share = Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1 -RootSquash NoRootSquash 
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1
        $share.EnabledProtocols | Should -Be "NFS"
        $share.RootSquash | Should -Be "NoRootSquash"
        Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1 -QuotaGiB 201 -RootSquash AllSquash 
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1
        $share.EnabledProtocols | Should -Be "NFS"
        $share.RootSquash | Should -Be "AllSquash"
        $share.QuotaGiB | Should -Be 201
        Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1 -Metadata @{"m1" = "v1"; "m2" = "v2"}  -RootSquash RootSquash 
        $share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1
        $share.EnabledProtocols | Should -Be "NFS"
        $share.RootSquash | Should -Be "RootSquash"
        $share.QuotaGiB | Should -Be 201
        $share.Metadata.Count | Should -Be 2 

        Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS

        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare1 -Force
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare2 -Force
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare3 -Force
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $accountNameNFS -Name testshare4 -Force

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNFS -Force -AsJob

        $Error.Count | should -be 0
    }  

    It "Smb Multichannel" {
        $Error.Clear()
        
        $accountNameSmb = $accountName + "smb"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSmb -SkuName Premium_LRS -Location eastus -Kind FileStorage

        #Enable Smb Multichannel
        $p = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSmb -EnableSmbMultichannel $true
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true 
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSmb
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true 
        $p = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSmb -EnableSmbMultichannel $false 
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $false 
        $p = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSmb
        $p.ProtocolSettings.Smb.Multichannel.Enabled | should -be $false 

        $Error.Count | should -be 0
    }
  
    It "Container Soft Delete" -Tag "2021-7-6" {
        $Error.Clear()

        $conName1 = "cont1"
        $conName2 = "cont2"
        $accountNameCtSoftDel = $accountName + "ctsd"
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameCtSoftDel -SkuName Standard_LRS -Location eastus 
        $ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel).Context

        #Enable container soft delete
        $deletePolicy = Enable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel -RetentionDays 2 -PassThru
        $deletePolicy.Enabled | should -be $true
        $deletePolicy.Days | should -Be 2
        $policy = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel 
        $policy.ContainerDeleteRetentionPolicy.Enabled | should -be $true
        $policy.ContainerDeleteRetentionPolicy.Days | should -Be 2

        #create/delete/list container/list - managemetn plane        
        $con1 = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel -Name $conName1
        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel -Name $conName1 -Force
        $contains = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel -IncludeDeleted
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
        Disable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel -PassThru
        $policy = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameCtSoftDel
        $policy.ContainerDeleteRetentionPolicy.Enabled -eq $true| should -be $false

        #remove containers
        Remove-AzStorageContainer -Name $conName1 -Context $ctx
        Remove-AzStorageContainer -Name $conName2 -Context $ctx

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameCtSoftDel -Force -AsJob

        $Error.Count | should -be 0
    }

    It "EnableNfsV3" -tag "2021-06-01" {
        $Error.Clear()
         
        $vnet1 = $testNode.nfsv3.vnet
        # Commands to create a vnet 
        # New-AzVirtualNetwork -ResourceGroupName $rgname -Location "eastus2euap" -AddressPrefix 10.0.0.0/24 -Name "vnet1" 
        # $n = Get-AzVirtualNetwork -ResourceGroupName $rgname -Name "vnet1" | Add-AzVirtualNetworkSubnetConfig -Name "subnet1" -AddressPrefix "10.0.0.0/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzVirtualNetwork 

        $accountNameNfsv3 = $accountName + "nfsv3"
        $a = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNfsv3 -SkuName Standard_LRS  -Location centraluseuap -Kind StorageV2 -EnableNfsV3 $true -EnableHierarchicalNamespace $true -EnableHttpsTrafficOnly $false `
                -NetworkRuleSet (@{bypass="Logging,Metrics";virtualNetworkRules=(@{VirtualNetworkResourceId="$vnet1";Action="allow"});defaultAction="deny"})   
        $a.EnableNfsV3 | should -BeTrue

        # create container
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name rootsquash -RootSquash RootSquash
        $con.EnableNfsV3AllSquash | should -BeFalse
        $con.EnableNfsV3RootSquash | should -BeTrue
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name norootsquash -RootSquash NoRootSquash
        $con.EnableNfsV3AllSquash | should -BeFalse
        $con.EnableNfsV3RootSquash | should -BeFalse
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name allsquash -RootSquash AllSquash
        $con.EnableNfsV3AllSquash | should -BeTrue
        $con.EnableNfsV3RootSquash | should -BeFalse
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name normal
        $con.EnableNfsV3AllSquash | should -be $null
        $con.EnableNfsV3RootSquash | should -be $null  
  
        # update container
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name rootsquash -RootSquash NoRootSquash
        $con.EnableNfsV3AllSquash | should -BeFalse
        $con.EnableNfsV3RootSquash | should -BeFalse
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name norootsquash -RootSquash AllSquash
        $con.EnableNfsV3AllSquash | should -BeTrue
        $con.EnableNfsV3RootSquash | should -BeFalse
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameNfsv3 -Name allsquash -RootSquash RootSquash
        $con.EnableNfsV3AllSquash | should -BeFalse
        $con.EnableNfsV3RootSquash | should -BeTrue

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameNfsv3 -Force -AsJob

        $Error.Count | should -be 0
    }

    It "Secure SMB" -Tag "2021-7-6" {
        $Error.Clear()

        $accountNameSecSMB = $accountName + "secsmb"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSecSMB -SkuName Premium_LRS -Location eastus -Kind FileStorage

        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB -SMBProtocolVersion SMB2.1,SMB3.0,SMB3.1.1 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 3
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB -SMBAuthenticationMethod Kerberos,NTLMv2
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 2
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB -SMBKerberosTicketEncryption RC4-HMAC,AES-256
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 2
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB -SMBChannelEncryption AES-128-CCM,AES-128-GCM,AES-256-GCM
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 3
        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB -SMBProtocolVersion SMB2.1,SMB3.0  -SMBAuthenticationMethod Kerberos -SMBKerberosTicketEncryption RC4-HMAC -SMBChannelEncryption AES-128-CCM,AES-256-GCM -EnableSmbMultichannel $true 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 2
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 1
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 1
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 2
        $fs.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true
        $fs = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 2
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 1
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 1
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 2
        $fs.ProtocolSettings.Smb.Multichannel.Enabled | should -be $true

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB 
        $fs = $account | Update-AzStorageFileServiceProperty  `
			-SMBProtocolVersion @() `
			-SMBAuthenticationMethod @() `
			-SMBKerberosTicketEncryption @() `
			-SMBChannelEncryption @() 
        $fs.ProtocolSettings.Smb.Smb.Versions.Count | should -be 0
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 0
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 0
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 0

        $fs = Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameSecSMB `
			        -SMBProtocolVersion SMB2.1,SMB3.0,SMB3.1.1  `
			        -SMBAuthenticationMethod Kerberos,NTLMv2 `
			        -SMBKerberosTicketEncryption RC4-HMAC,AES-256 `
			        -SMBChannelEncryption AES-128-CCM,AES-128-GCM,AES-256-GCM 
        $fs.ProtocolSettings.Smb.Versions.Count | should -be 3
        $fs.ProtocolSettings.Smb.AuthenticationMethods.Count | should -be 2
        $fs.ProtocolSettings.Smb.KerberosTicketEncryption.Count | should -be 2
        $fs.ProtocolSettings.Smb.ChannelEncryption.Count | should -be 3

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSecSMB -Force -AsJob

        $Error.Count | should -be 0
    }  
        
    It "Blob LastAccessTime Tracking" {
        $Error.Clear()

        $accountNameLAT = $accountName + "lat"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLAT -SkuName Standard_LRS -Location eastus 

        #enable LAT
        $p = Enable-AzStorageBlobLastAccessTimeTracking  -ResourceGroupName $rgname -StorageAccountName $accountNameLAT -PassThru
        $p.Enable | should -Be $true
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameLAT
        $p.LastAccessTimeTrackingPolicy.Enable | should -Be $true

        # Add management policy with rule object
        $action1 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -DaysAfterLastAccessTimeGreaterThan 100 -EnableAutoTierToHotFromCool
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToCool -DaysAfterLastAccessTimeGreaterThan 30 -EnableAutoTierToHotFromCool
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToArchive -DaysAfterModificationGreaterThan 80 -DaysAfterLastTierChangeGreaterThan 30
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction Delete -daysAfterCreationGreaterThan 100
        $filter1 = New-AzStorageAccountManagementPolicyFilter -PrefixMatch con/prefix1,con/prefix2 #-SuffixMatch .jpg,.exe -SizeInByteLessThan 10000 -SizeInByteGreaterThan 100
        $rule1 = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action1 -Filter $filter1
        
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLAT -Rule $rule1 # -debug
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
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLAT -Policy (@{
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
        Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $accountNameLAT
        Disable-AzStorageBlobLastAccessTimeTracking  -ResourceGroupName $rgname -StorageAccountName $accountNameLAT
        $p = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $accountNameLAT
        $p.LastAccessTimeTrackingPolicy | should -Be $null

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameLAT -Force -AsJob

        $Error.Count | should -be 0
    }

    It "HnsOn Migration" -tag "fail","longrunning" {
        $Error.Clear()

        $accountNameHns = $accountName + "hnson" ## e.g. “testaccount”-tag "fail"

        #clean up
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameHns -Force  -ErrorAction SilentlyContinue
        $Error.Clear()
        
        # Create account
        $a = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameHns -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 # -EnableHierarchicalNamespace $true 
        $a.EnableHierarchicalNamespace | should -be $null

        # Validation
        Invoke-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $accountNameHns -RequestType Validation | should -be $true

        # upgrade
        $task = Invoke-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $accountNameHns -RequestType Upgrade -Force -AsJob

        # stop upgrade (will fail)
        Stop-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $accountNameHns -Force -PassThru -ErrorAction SilentlyContinue        
        $error[0].Exception.Message | should -Be "Hns migration for the account: $($accountName) is not found."
        $error.Count | should -be 1
        $error.Clear()

        # wait for upgrade complete
        $task | Wait-Job
        $task.State | should -be "Completed"

        $a = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameHns
        $a.EnableHierarchicalNamespace | should -be $true

        # clean up
        $t = Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameHns -Force -AsJob 
        $t | Wait-Job
        $t.State | should -be "Completed"

        $Error.Count | should -be 0
    }

    It "AllowProtectedAppendWriteAll" -tag "2021-06-01" {
        $Error.Clear()

        $accountNamePawa = $accountName + "pawa"
        $containerNamePawa = $containerName + "pawa"

        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNamePawa -SkuName Standard_LRS -Location eastus -EnableHierarchicalNamespace $true 

        # ImmutabilityPolicy 
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -Name $containerNamePawa 
        $con.ImmutabilityPolicy.AllowProtectedAppendWritesAll | should -be $null
        $con.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $null

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -ContainerName $containerNamePawa -ImmutabilityPeriod 2 -AllowProtectedAppendWrite $false -AllowProtectedAppendWriteAll $true
        $imp.AllowProtectedAppendWrites | should -BeIn @($null, $false)
        $imp.AllowProtectedAppendWritesAll | should -be $true
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -Name $containerNamePawa 
        $con.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $false
        $con.ImmutabilityPolicy.AllowProtectedAppendWritesAll | should -be $true

        $imp = Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -ContainerName $containerNamePawa -ImmutabilityPeriod 2  -AllowProtectedAppendWriteAll $false
        $imp.AllowProtectedAppendWrites | should -be $false
        $imp.AllowProtectedAppendWritesAll | should -be $false

        # LegalHold
        $legal = Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -ContainerName $containerNamePawa -Tag  tag1,tag2  -AllowProtectedAppendWriteAll $true
        $legal.AllowProtectedAppendWritesAll | should -be $true
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -Name $containerNamePawa 
        $con.LegalHold.ProtectedAppendWritesHistory.AllowProtectedAppendWritesAll | should -be $true

        # clean up
        $legal = Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -ContainerName $containerNamePawa -Tag  tag1,tag2 
        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNamePawa -Name $containerNamePawa -Force

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNamePawa -Force -AsJob

        $Error.Count | should -be 0
    }

    
    It "VLW" -Tag "VLW","longrunning" {
        $Error.Clear()
        $accountNameVLW = $testNode.SelectSingleNode("accountName[@id='1']").'#text' ## e.g. “testaccount”

        $ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName).Context
        $containerNameVLW = "vlwtest"
        $containerNameVLW2 = "vlwtestmigration2"
        $localSrcFile = "C:\temp\testfile_10240K_0" 
        $blobname = "testvlw1"

        ##### mgmt plane: 
        # Create container with VLW, then Get it
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameVLW -Name $containerNameVLW -EnableImmutableStorageWithVersioning # -debug
        $con.ImmutableStorageWithVersioning.Enabled | should -be $true
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameVLW -Name $containerNameVLW # -debug
        $con.ImmutableStorageWithVersioning.Enabled | should -be $true

    
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameVLW -Name $containerNameVLW2
        $con.ImmutableStorageWithVersioning.Enabled | should -be $null
        Set-AzRmStorageContainerImmutabilityPolicy  -ResourceGroupName $rgname -StorageAccountName $accountNameVLW -ContainerName $containerNameVLW2 -ImmutabilityPeriod 1
        $t = Invoke-AzRmStorageContainerImmutableStorageWithVersioningMigration -ResourceGroupName $rgname -StorageAccountName $accountNameVLW -Name $containerNameVLW2 -asjob
        $t | Wait-Job
        $con = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountNameVLW -Name $containerNameVLW2 # -debug
        $con.ImmutableStorageWithVersioning.Enabled | should -be $true

        $con | Remove-AzRmStorageContainer -Force

        #### Dataplane - cmdlet:
        # create a blob
        $b = Set-AzStorageBlobContent -Container $containerNameVLW -Blob $blobname -File $localSrcFile -Context $ctx -Force
        $b.BlobBaseClient.CreateSnapshot()        
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null

        # set and remove ImmutabilityPolicy on an exiting blob
        $b = Set-AzStorageBlobImmutabilityPolicy -Container $containerNameVLW -Blob $blobname  -Context $ctx -ExpiresOn (Get-Date).AddDays(100) -PolicyMode Unlocked       
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -Not -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be Unlocked
    
        $b = Remove-AzStorageBlobImmutabilityPolicy -Container $containerNameVLW -Blob $blobname  -Context $ctx 
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null
    
        # set and remove LegalHold on an exiting blob
        $blob = Set-AzStorageBlobLegalHold -Container $containerNameVLW -Blob $blobname  -Context $ctx -EnableLegalHold
        $blob.BlobProperties.HasLegalHold | should -be $true

        $blob = Set-AzStorageBlobLegalHold -Container $containerNameVLW -Blob $blobname  -Context $ctx -DisableLegalHold
        $blob.BlobProperties.HasLegalHold | should -be $false

        # pipeline 
        # pipeline a snapshot
        $blobs = Get-AzStorageBlob -Container $containerNameVLW  -Context $ctx -IncludeVersion
        $Snapshot = ($blobs | ?{ $_.SnapshotTime -ne $null})[0]
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Set-AzStorageBlobImmutabilityPolicy -ExpiresOn (Get-Date).AddDays(1) -PolicyMode Unlocked
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Set-AzStorageBlobLegalHold -EnableLegalHold
        $b = Get-AzStorageBlob -Container $containerNameVLW -Blob $Snapshot.Name -SnapshotTime $Snapshot.SnapshotTime -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -Not -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be Unlocked
        $b.BlobProperties.HasLegalHold | should -be $true
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Remove-AzStorageBlobImmutabilityPolicy 
        ($blobs | ?{ $_.SnapshotTime -ne $null})[0] | Set-AzStorageBlobLegalHold -DisableLegalHold
        $b = Get-AzStorageBlob -Container $containerNameVLW -Blob $Snapshot.Name -SnapshotTime $Snapshot.SnapshotTime -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null
        $b.BlobProperties.HasLegalHold | should -be $false

        # pipeline a blob version
        $blobVersion = ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0]
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Set-AzStorageBlobImmutabilityPolicy -ExpiresOn (Get-Date).AddDays(1) -PolicyMode Unlocked
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Set-AzStorageBlobLegalHold -EnableLegalHold
        $b = Get-AzStorageBlob -Container $containerNameVLW -Blob $blobVersion.Name -VersionId $blobVersion.VersionId -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -Not -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be Unlocked
        $b.BlobProperties.HasLegalHold | should -be $true
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Set-AzStorageBlobLegalHold -DisableLegalHold
        ($blobs | ?{ $_.VersionId -ne $null -and $_.IsLatestVersion -ne $true})[0] | Remove-AzStorageBlobImmutabilityPolicy 
        $b = Get-AzStorageBlob -Container $containerNameVLW -Blob $blobVersion.Name -VersionId $blobVersion.VersionId -Context $ctx
        $b.BlobProperties.ImmutabilityPolicy.ExpiresOn | should -be $null
        $b.BlobProperties.ImmutabilityPolicy.PolicyMode | should -be $null
        $b.BlobProperties.HasLegalHold | should -be $false   

        # mgmt: cleanup by remove container
        # Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $accountName -Name $containerName -Force 

        $Error.Count | should -be 0
    }    

    It "account worm" {
        $Error.Clear()

        $accountNameavlw1 = $accountName + "avlw1"
        $accountNameavlw2 = $accountName + "avlw2"
        $accountNameavlw3 = $accountName + "avlw3"

        # create account
        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw1 -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 -EnableAccountLevelImmutability -ImmutabilityPeriod 1 -ImmutabilityPolicyState Unlocked # -AllowProtectedAppendWrite $true #-debug
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
        # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $true

        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw2 -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 -EnableAccountLevelImmutability  
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy| should -be $null

        $a = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw3 -SkuName Standard_LRS -Location centraluseuap -Kind StorageV2 -EnableAccountLevelImmutability -ImmutabilityPeriod 1 -ImmutabilityPolicyState Disabled
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Disabled
        # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $null

        # update account
        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw1  -ImmutabilityPeriod 2 -ImmutabilityPolicyState Unlocked # -AllowProtectedAppendWrite $false #-debug        
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 2
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
       # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $false

        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw1  -ImmutabilityPeriod 1       
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
      #  $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $false

        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw1 # -AllowProtectedAppendWrite $true   
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Unlocked
       # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $true

        $a= Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw1  -ImmutabilityPolicyState Locked      
        $a.ImmutableStorageWithVersioning.Enabled | should -be $true
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays | should -be 1
        $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.State | should -be Locked
       # $a.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites | should -be $true

        # clean up
        $t1 = remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw1 -Force -AsJob
        $t2 = remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw2 -Force -AsJob
        $t3 = remove-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $accountNameavlw3 -Force -AsJob
        @($t1, $t2, $t3) | Wait-Job
   
        $Error.Count | should -be 0
    }
    
    It "SFTP & Local User" {
        $Error.Clear()

        $accountNameSFTP = $accountName + "sftp"

        $UserName = “testuser" ## e.g. "testuser"


        # Create account 
        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP -Location centralus -SkuName Standard_LRS -Kind StorageV2 -EnableSftp $true -EnableHierarchicalNamespace $true -EnableNfsV3 $false -EnableLocalUser $true
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $true

        # update account 
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP -EnableSftp $false 
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $false
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP -EnableLocalUser $false 
        $account.EnableLocalUser | should -be $false
        $account.EnableSftp | should -be $false
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP -EnableLocalUser $true 
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $false
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP -EnableSftp $true -EnableLocalUser $true 
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $true
        ## show account properties
        $account = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP
        $account.EnableLocalUser | should -be $true
        $account.EnableSftp | should -be $true

        # create/update local user
        $sshkey1 = New-AzStorageLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykey=" -Description "sshpulickey name1"
        $sshkey2 = New-AzStorageLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykey=" -Description "sshpulickey name2"
        $permissionScope1 = New-AzStorageLocalUserPermissionScope -Permission rw -Service blob -ResourceName container1 
        $permissionScope2 = New-AzStorageLocalUserPermissionScope -Permission rw -Service file -ResourceName share2
        $localuser = Set-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName $UserName -HomeDirectory "/" -SshAuthorizedKey $sshkey1,$sshkey2 -PermissionScope $permissionScope1,$permissionScope2 -HasSharedKey $true -HasSshKey $true -HasSshPassword $true #-Debug
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

        $localuser = Set-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName $UserName -HomeDirectory "/" -HasSharedKey $true -HasSshKey $true -HasSshPassword $true `
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


        $localuser = Set-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName "$($UserName)2" -HomeDirectory "/" -SshAuthorizedKey $sshkey1
        $localuser.Name | should -Be "$($UserName)2"
        $localuser.HomeDirectory | should -Be "/"
        $localuser.HasSharedKey | should -Be $null
        $localuser.HasSshKey | should -Be $null
        $localuser.HasSshPassword | should -Be $null
        $localuser.SshAuthorizedKeys.Count | should -be 1
        $localuser.SshAuthorizedKeys[0].Description | should -be "sshpulickey name1"
        $localuser.SshAuthorizedKeys[0].Key | should -be "ssh-rsa keykeykeykeykey="
        $localuser.PermissionScopes.Count | should -be 0
        $localuser = Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP | Set-AzStorageLocalUser -UserName "$($UserName)3" -HomeDirectory "/dir1"
        $localuser.Name | should -Be "$($UserName)3"
        $localuser.HomeDirectory | should -Be "/dir1"
        $localuser.HasSharedKey | should -Be $null
        $localuser.HasSshKey | should -Be $null
        $localuser.HasSshPassword | should -Be $null
        $localuser.SshAuthorizedKeys.Count | should -be 0
        $localuser.PermissionScopes.Count | should -be 0

        #get single local user
        $localuser = Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName $UserName
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
        $localusers = Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP
        $localusers.count | should -be 3
        $localusers[0].Name | should -Be $UserName
        $localusers[1].Name | should -Be "$($UserName)2"
        $localusers[2].Name | should -Be "$($UserName)3"

        # get key
        $keys = Get-AzStorageLocalUserKey -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName $UserName
        $keys.SharedKey.Length | should -BeGreaterThan 1
        $keys.SshAuthorizedKeys.Count | should -be 2
        $keys.SshAuthorizedKeys[0].Description | should -be "sshpulickey name1"
        $keys.SshAuthorizedKeys[0].Key | should -be "ssh-rsa keykeykeykeykew="
        $keys.SshAuthorizedKeys[1].Description | should -be "sshpulickey name2"
        $keys.SshAuthorizedKeys[1].Key | should -be "ssh-rsa keykeykeykeykew="

        # regenerate key
        $key = New-AzStorageLocalUserSshPassword -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName $UserName 
        $key.SshPassword.Length  | should -BeGreaterThan 1

        # delete a local user
        Remove-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP -UserName $UserName -PassThru
        (Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP).count | should -be 2
        Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP | Remove-AzStorageLocalUser
        (Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $accountNameSFTP).count | should -be 0

        # remove account 
        remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameSFTP -AsJob -Force

        $Error.Count | should -be 0
    }

    It "AADKerb" {
        $Error.Clear()

        $accountNameAADKerb = $accountName + "aadkerb"
    
        $DomainName = "onpremaadstg.com"
        $DomainGuid = "aebfc118-9fa9-4732-a21f-d98e41a77ae1"
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb -SkuName Standard_LRS -Location "centraluseuap" -EnableAzureActiveDirectoryKerberosForFile $true -ActiveDirectoryDomainName $DomainName -ActiveDirectoryDomainGuid $DomainGuid 
        $a = get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "AADKERB"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainName | should -Be $DomainName
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainGuid | should -Be $DomainGuid

        $a = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb -EnableAzureActiveDirectoryKerberosForFile $false 
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "None"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties | should -Be $null

        $a = set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb -EnableAzureActiveDirectoryKerberosForFile $true 
        $a = get-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "AADKERB"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties | should -Be $null

        $a = set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb -EnableAzureActiveDirectoryKerberosForFile $true -ActiveDirectoryDomainName $DomainName -ActiveDirectoryDomainGuid $DomainGuid 
        $a.AzureFilesIdentityBasedAuth.DirectoryServiceOptions | should -Be "AADKERB"
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainName | should -Be $DomainName
        $a.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.DomainGuid | should -Be $DomainGuid

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameAADKerb -Force -AsJob

        $Error.Count | should -be 0
    }

    
    It "FederatedClientId" -Skip {
        $Error.Clear()

        Add-AzAccount -Subscription $testNode.federatedClientId.subscription -Tenant $testNode.federatedClientId.tenant

        $keyvaultName = $testNode.federatedClientId.keyvaultName
        $keyvaultUri = "https://$($keyvaultName).vault.azure.net:443"
        $keyname = "wrappingKey"
       
        $accountNameFedClt = $accountName + "fedclt"
        
        $useridentity= $testNode.federatedClientId.userIdentity

        if ($false)
        {

            # prepare keyvault  
            $location =  'eastus'; 
    
            $keyVault = New-AzKeyVault -VaultName $keyvaultName -ResourceGroupName $rgname -Location $location -EnablePurgeProtection
            # give service principle "weiwei's AAD app" (d6f7e858-345d-45f6-849c-8175519656b7) access to the keyvault 
            Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgname -ObjectId $testNode.federatedClientId.objectId -PermissionsToKeys backup,create,delete,get,import,get,list,update,restore 

            $key = Add-AzKeyVaultKey -VaultName $keyvaultName -Name $keyname -Destination 'Software'    
            $keyversion = $key.Version

            # create 1 User identity, and give them access to keyvault
            $userId3 = New-AzUserAssignedIdentity -ResourceGroupName $rgname -Name regresstestidfed
            Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgName -ObjectId $userId3.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
            $useridentity= $userId3.Id
        }


        # Create Account with UAI (SystemAssignedUserAssigned)
        # KeyVaultFederatedClientId is application IS for service principle 
        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFedClt -Kind StorageV2 -SkuName Standard_LRS -Location eastus2 `
                    -UserAssignedIdentityId $useridentity  -IdentityType SystemAssignedUserAssigned  `
                    -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity -KeyVaultFederatedClientId $testNode.federatedClientId.SelectSingleNode("federatedClientId[@id='1']").'#text'  #-debug
        $account.Encryption.EncryptionIdentity.EncryptionFederatedIdentityClientId | should -be $testNode.federatedClientId.SelectSingleNode("federatedClientId[@id='1']").'#text' 

        # update account
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFedClt `
                    -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity -KeyVaultFederatedClientId $testNode.federatedClientId.SelectSingleNode("federatedClientId[@id='2']").'#text'  #-debug
        $account.Encryption.EncryptionIdentity.EncryptionFederatedIdentityClientId | should -be $testNode.federatedClientId.SelectSingleNode("federatedClientId[@id='2']").'#text' 
    
        $account = Set-AzStorageAccount -ResourceGroupName $rgName -Name $accountNameFedClt -KeyVaultFederatedClientId $testNode.federatedClientId.SelectSingleNode("federatedClientId[@id='2']").'#text'  #-debug
        $account.Encryption.EncryptionIdentity.EncryptionFederatedIdentityClientId | should -be $testNode.federatedClientId.SelectSingleNode("federatedClientId[@id='2']").'#text' 

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameFedClt -As

        $Error.Count | should -be 0
    }

    It "TODO" {
        $Error.Clear()

        $Error.Count | should -be 0
    }
    
    
    AfterAll { 
        #Cleanup  
        Get-AzStorageAccount | ? { $_.StorageAccountname -like $accountName + "*"} | Remove-AzStorageAccount -Force -AsJob


    }
}