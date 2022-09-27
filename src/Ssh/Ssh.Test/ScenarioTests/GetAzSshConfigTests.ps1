<#
.SYNOPSIS
Test GetIpAddress Private Address
#>
function Test-GetArcConfig
{
    $MachineName = Get-RandomArcName
    $ResourceGroupName = Get-RandomResourceGroupName

    New-AzResourceGroup -Name $ResourceGroupName -Location "eastus" | Out-Null
    
    $SubscriptionId = (Get-AzContext).Subscription.Id
    $TenantId = (Get-AzContext).Tenant.Id
    
    $agent = installArcAgent

    Assert-AreEqual $agent 'C:\Program Files\AzureConnectedMachineAgent\azcmagent.exe'

    Start-Agent -MachineName $MachineName -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -TenantId $TenantId -Agent $agent 

    $configEntry = Export-AzSshConfig -ResourceGroupName $ResourceGroupName -Name $MachineName -ConfigFilePath ./config -LocalUser azureuser

    Assert-NotNull $configEntry
    Assert-AreEqual $configEntry.Host "$ResourceGroupName-$MachineName"

    $configContent = Get-Content -Path ./config

    Assert-AreEqual $configEntry.configString $configContent
    
    Stop-Agent -AgentPath $agent
    
}