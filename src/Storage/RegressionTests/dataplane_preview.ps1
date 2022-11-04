BeforeAll {
    # Modify the path to your own
    Import-Module D:\code\azure-powershell\src\Storage\RegressionTests\utils.ps1
    
    [xml]$config = Get-Content D:\code\azure-powershell\src\Storage\RegressionTests\config.xml
    $globalNode = $config.SelectSingleNode("config/section[@id='global']")
    $testNode = $config.SelectSingleNode("config/section[@id='dataplanePreview']")

    cd C:\temp # This directory should exist before tests 

    $resourceGroupName = $globalNode.resourceGroupName
    $storageAccountName = $testNode.accountName

    $key = (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName)[0].Value
    $ctx = New-AzStorageContext -StorageAccountName weirp1 -StorageAccountKey $key
    $localSrcFile = "C:\temp\testfile_10240K_0" #The file need exist before test, and should be 512 bytes aligned
    $localDestFile = "C:\temp\testpreview.txt" # test will create the file
    $containerName = GetRandomContainerName
    # $containerName = "weitestpreview"

    New-AzStorageContainer $containerName -Context $ctx
    New-AzStorageShare $containerName -Context $ctx
}

Describe "dataplane test for preview" { 

    It "container access policy -preview"  -Tag "accesspolicy"  {
        $Error.Clear()
        
        $con = get-AzStorageContainer $containerName -Context $ctx

        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test1 -Permission xcdlrwt -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2 -Permission ctr -ExpiryTime (Get-Date).AddDays(6)
        $policy = get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 
        $policy 
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2
        Set-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2 -Permission xacdlrwt -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 
        Remove-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2
        Remove-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 

        $Error.Count | should -be 0

    }
    
    AfterAll {    
        Remove-AzStorageShare -Name $containerName -Force -Context $ctx -PassThru
        Remove-AzStorageContainer -Name $containerName -Force -Context $ctx -PassThru
    }
}