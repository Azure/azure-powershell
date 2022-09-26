# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 
C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1


BeforeAll {
    Import-Module C:\Users\weiwei\Desktop\PSH_Script\Assert.ps1
    $config = (Get-Content D:\code\azure-powershell\src\Storage\RegressionTests\config.json -Raw | ConvertFrom-Json).srpPreview

    $secpasswd = ConvertTo-SecureString $config.credentials.secpwd -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ($config.credentials.username, $secpasswd)
    Add-AzAccount -ServicePrincipal -Tenant $config.credentials.tenantId -SubscriptionId $config.credentials.subscriptionId -Credential $cred 

    $rgname = "weitry";
    $accountName = "weisanity5"
    $accountName2 = "weisanity6"

    $containerName = "weitest"
}

Describe "Management plan test - preview" { 
    It "Copy Scope" {
        $Error.Clear()

        $resourceGroupName = “weitry” ## e.g. testrg”
        $storageAccountName = “weicopyscoperegression1" ## e.g. “testaccount”


        # Create account 
        $account = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -Location centraluseuap -SkuName Standard_LRS -Kind StorageV2 -AllowedCopyScope AAD 
        $account.AllowedCopyScope | should -be AAD

        # update account 
        $account = Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -AllowedCopyScope PrivateLink
        $account.AllowedCopyScope | should -be PrivateLink

        # clean up
        Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -Force -AsJob

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