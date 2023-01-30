Invoke-LiveTestScenario -Name "Creates a virtual machine." -Description "Test create new VM" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName

    $VMLocalAdminUser = New-LiveTestResourceName;
    $VMLocalAdminSecurePassword = ConvertTo-SecureString "Aalexwdy5#" -AsPlainText -Force;
    $LocationName = "eastus";
    $domainNameLabel = New-LiveTestResourceName;
    $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);
    $text = New-LiveTestResourceName;
    $bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
    $userData = [Convert]::ToBase64String($bytes);

    $actual =  New-AzVM -ResourceGroupName $rgName -Name $name -Credential $Credential -DomainNameLabel $domainNameLabel -UserData $userData;

    Assert-AreEqual $name $actual.Name
    # Assert-AreEqual "Succeeded" Label $actual.ProvisioningState
    # Assert-AreEqual $userData $actual.UserData
}

Invoke-LiveTestScenario -Name "Removes a virtual machine from Azure" -Description "Test removes a virtual machine from Azure."  -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName
    $VMLocalAdminUser = New-LiveTestResourceName;
    $VMLocalAdminSecurePassword = ConvertTo-SecureString "Aalexwdy5#" -AsPlainText -Force;
    $LocationName = "eastus";
    $domainNameLabel = New-LiveTestResourceName;
    $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);
    $text = New-LiveTestResourceName;
    $bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
    $userData = [Convert]::ToBase64String($bytes);

    New-AzVM -ResourceGroupName $rgName -Name $name -Credential $Credential -DomainNameLabel $domainNameLabel -UserData $userData;
    Remove-AzVM -ResourceGroupName $rgName -Name $name -Force

    $removedVM = Get-AzVM -ResourceGroupName $rgName -Name $name
    Assert-Null $removedVM
}
