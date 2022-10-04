<#
.SYNOPSIS
Test Exporting SSH Config File for an Arc Server using Local User Login
#>
function Test-GetArcConfig
{

    $isPlayback = IsPlayback

    if ($IsMacOS) {
        return
    }
    $MachineName = Get-RandomArcName
    $ResourceGroupName = Get-RandomResourceGroupName
    $SubscriptionId = (Get-AzContext).Subscription.Id
    $TenantId = (Get-AzContext).Tenant.Id

    New-AzResourceGroup -Name $ResourceGroupName -Location "eastus" | Out-Null
    
    if (-not $isPlayback) { $agent = installArcAgent }   

    try 
    {
        if (-not $isPlayback) { Start-Agent -MachineName $MachineName -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -TenantId $TenantId -Agent $agent }

        $accessToken = Get-AzAccessToken
        Assert-NotNull $accessToken
    
        Remove-Item ./config -ErrorAction Ignore

        $configEntry = Export-AzSshConfig -ResourceGroupName $ResourceGroupName -Name $MachineName -ConfigFilePath ./config -LocalUser azureuser -Port 35000

        Assert-NotNull $configEntry
        Assert-AreEqual $configEntry.Host "$ResourceGroupName-$MachineName"
        Assert-AreEqual $configEntry.Hostname $MachineName

        if ([intptr]::Size -eq 4) {
            $arch = "386"
        } else {
            $arch = "amd64"
        }

        if ($IsWindows) {
            $os = 'windows'
        } elseif ($IsMacOS) {
            $os = 'darwin'
        } else {
            $os = 'linux'
        }

        $proxyName = "sshProxy_" + $os + "_" + $arch +"_1_3_017634.exe"
        $proxyPath = Join-Path $HOME ".clientsshproxy" $proxyName

        $relayPath = Join-Path (Split-Path ((Resolve-Path ./config).Path)) "az_ssh_config" "$ResourceGroupName-$MachineName" "$ResourceGroupName-$MachineName-relay_info"

        Assert-AreEqual $configEntry.ProxyCommand "`"$proxyPath`" -r `"$relayPath`" -p 35000"

    }
    finally {
        Remove-Item ./config -ErrorAction Ignore -Force
        Remove-Item ./az_ssh_config -ErrorAction Ignore -Force -Recurse
        Remove-Item (Join-Path $HOME ".clientsshproxy") -ErrorAction Ignore -Force -Recurse
        if (-not $isPlayback) { Stop-Agent -AgentPath $agent }
        Remove-AzResourceGroup -Name $ResourceGroupName -Force
    }
}

<#
.SYNOPSIS
Test Exporting SSH Config File for an Azure VM using Local User Login. Test overwriting and appending new entries to the same file.
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

    try 
    {
        $vm = New-AzVM -ResourceGroupName $ResourceGroupName -Name $VmName -Location "eastus" -Image UbuntuLTS -Credential $cred
        Remove-Item ./config -ErrorAction Ignore

        Assert-NotNull $vm
        $configEntry = Export-AzSshConfig -ResourceGroupName $ResourceGroupName -Name $VmName -ConfigFilePath ./config -LocalUser $username

        Assert-NotNull $configEntry
        Assert-AreEqual $configEntry.Host "$ResourceGroupName-$VmName"
        Assert-AreEqual $configEntry.User $username
        Assert-AreEqual $configEntry.ResourceType "Microsoft.Compute/virtualMachines"
        Assert-AreEqual $configEntry.LoginType "LocalUser"
        Assert-Null $configEntry.CertificateFile
        Assert-Null $configEntry.IdentityFile
        Assert-Null $configEntry.ProxyCommand
        Assert-Null $configEntry.Port
        Assert-NotNull $configEntry.HostName

        $configFileContent = (Get-Content -Path ./config)
        Assert-AreEqual "Host $ResourceGroupName-$VmName-$username" $configFileContent[1]
        
    }
    finally {
        Remove-Item ./config -ErrorAction Ignore -Force
        Remove-AzResourceGroup -Name $ResourceGroupName -Force
    }
}


