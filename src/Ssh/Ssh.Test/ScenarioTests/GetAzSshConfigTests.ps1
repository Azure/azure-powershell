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
    $MachineName = Get-ArcServerName
    $ResourceGroupName = Get-ResourceGroupName
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

        Install-Module Az.Ssh.ArcProxy -Scope CurrentUser -Repository PsGallery -Force -AllowClobber

        $configEntry = Export-AzSshConfig -ResourceGroupName $ResourceGroupName -Name $MachineName -ConfigFilePath ./config -LocalUser azureuser -Port 35000 -Force

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


        $proxyNamePattern = "sshProxy_" + $os + "_" + $arch +"_*"
        if ($IsWindows) {
            $proxyName = $proxyName + ".exe"
        }
        $proxyDir = (Get-Item (Get-module -ListAvailable -Name Az.Ssh.ArcProxy).Path).Directory.FullName
        $proxyPath = (Get-ChildItem $proxyDir -Filter $proxyNamePattern | Select-Object -First 1).FullName

        $relayPath = Join-Path (Split-Path ((Resolve-Path ./config).Path)) "az_ssh_config" "$ResourceGroupName-$MachineName" "$ResourceGroupName-$MachineName-relay_info"

        Assert-AreEqual $configEntry.ProxyCommand "`"$proxyPath`" -r `"$relayPath`" -p 35000"

    }
    finally {
        Uninstall-Module Az.Ssh.ArcProxy -ErrorAction Ignore
        Remove-Item ./config -ErrorAction Ignore -Force
        Remove-Item ./az_ssh_config -ErrorAction Ignore -Force -Recurse
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
    $VmName = Get-AzureVmName
    $ResourceGroupName = Get-ResourceGroupName
    $SubscriptionId = (Get-AzContext).Subscription.Id
    $TenantId = (Get-AzContext).Tenant.Id
    
    $username = "azuretestuser"
    $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password

    New-AzResourceGroup -Name $ResourceGroupName -Location "eastus" | Out-Null

    $domainlabel = "d1" + $ResourceGroupName
    try 
    {
        $vm = New-AzVM -ResourceGroupName $ResourceGroupName -Name $VmName -Location "eastus" -Credential $cred -DomainNameLabel $domainlabel
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


