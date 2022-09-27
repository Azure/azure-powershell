<#
.SYNOPSIS
Test GetIpAddress Private Address
#>
function Test-GetPrivateIp
{
    $vm = "private-ip-w22"
    $rg = "azssh_powershell_iputils_test"
    $expected_ip = "10.3.0.4"
    $_message = ""
    $_context = Get-AzContext
    $ipUtils = [Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common.IpUtils]::new($_context)
    $ip = $ipUtils.GetIpAddress($vm, $rg, $true, [ref] $_message)
    Assert-AreEqual $ip $expected_ip
}

<#
.SYNOPSIS
Test GetIpAddress Public Address
#>
function Test-GetPublicIp
{
    $vm = "public-ip-rhel8"
    $rg = "azssh_powershell_iputils_test"
    $expected_ip = "40.124.136.94"
    $_message = ""
    $_context = Get-AzContext
    $ipUtils = [Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common.IpUtils]::new($_context)
    $ip = $ipUtils.GetIpAddress($vm, $rg, $false, [ref] $_message)
    Assert-AreEqual $ip $expected_ip
}

<#
.SYNOPSIS
Test GetIpAddress: Attempt to get a public IP from a VM with no public IP.
Get a private ip instead.
#>
function Test-GetPublicIpNotFound
{
    $vm = "no-public-ip-u20"
    $rg = "azssh_powershell_iputils_test"
    $expected_ip = "10.1.0.4"
    $_message = ""
    $_context = Get-AzContext
    $ipUtils = [Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common.IpUtils]::new($_context)
    $ip = $ipUtils.GetIpAddress($vm, $rg, $false, [ref] $_message)
    Assert-AreEqual $ip $expected_ip
    Assert-AreEqual $_message "Unable to find public IP. Attempting to connect to private ip 10.1.0.4"
}