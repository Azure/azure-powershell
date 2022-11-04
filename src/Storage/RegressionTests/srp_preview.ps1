# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 

BeforeAll {
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

Describe "Management plan test - preview" { 
    It "Copy Scope" {
        $Error.Clear()
        
        $accountNameCopyScope = $accountName + "cpys"
        # Create account 
        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameCopyScope -Location centraluseuap -SkuName Standard_LRS -Kind StorageV2 -AllowedCopyScope AAD 
        $account.AllowedCopyScope | should -be AAD

        # update account 
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameCopyScope -AllowedCopyScope PrivateLink
        $account.AllowedCopyScope | should -be PrivateLink

        # clean up
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountNameCopyScope -Force -AsJob

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