<#
.SYNOPSIS
Test Exporting SSH Config File for an Arc Server using Local User Login
#>
function Test-GetArcConfig
{
    $MachineName = Get-RandomArcName
    $ResourceGroupName = Get-RandomResourceGroupName
    $SubscriptionId = (Get-AzContext).Subscription.Id
    $TenantId = (Get-AzContext).Tenant.Id

    New-AzResourceGroup -Name $ResourceGroupName -Location "eastus" | Out-Null
       
    $agent = installArcAgent
    Start-Agent -MachineName $MachineName -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -TenantId $TenantId -Agent $agent 

    #azcmagent connect --resource-group $ResourceGroupName --tenant-id $TenantId --location eastus --subscription-id $SubscriptionId --access-token (Get-AzAccessToken) --resource-name $MachineName
    
    Remove-Item ./config -ErrorAction Ignore

    $configEntry = Export-AzSshConfig -ResourceGroupName $ResourceGroupName -Name $MachineName -ConfigFilePath ./config -LocalUser azureuser

    Assert-NotNull $configEntry
    Assert-AreEqual $configEntry.Host "$ResourceGroupName-$MachineName"
    Assert-AreEqual $configEntry.configString (Get-Content -Path ./config)
    
    Stop-Agent -AgentPath $agent
    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Test Exporting SSH Config File for an Azure VM using Local User Login
#>
function Test-GetVmConfig
{
    $VmName = Get-RandomVmName
    $ResourceGroupName = Get-RandomResourceGroupName
    $SubscriptionId = (Get-AzContext).Subscription.Id
    $TenantId = (Get-AzContext).Tenant.Id
    
    $username = "azuretestuser"
    $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password

    New-AzResourceGroup -Name $ResourceGroupName -Location "eastus" | Out-Null

    New-AzVM -ResourceGroupName $ResourceGroupName -Name $VmName -Location "eastus" -Image UbuntuLTS -Credential $cred

    Remove-Item ./config -ErrorAction Ignore

    $configEntry = Export-AzSshConfig -ResourceGroupName $ResourceGroupName -Name $VmName -ConfigFilePath ./config

    Assert-NotNull $configEntry
    Assert-AreEqual $configEntry.Host "$ResourceGroupName-$VmName"
    Assert-AreEqual $configEntry.configString (Get-Content -Path ./config -Raw)

    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

