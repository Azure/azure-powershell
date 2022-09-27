<#
.SYNOPSIS
Test GetIpAddress Private Address
#>
function Test-GetRelayInformation
{
    $machine_name = "relay-info-tests-u20"
    $resource_group_name = "azssh_powershell_relayinformationutils_test"
    $message = ""
    $_context = Get-AzContext
    $expected_relay_info_commonpart = "eyJyZWxheSI6IHsibmFtZXNwYWNlTmFtZSI6ICJhemduLWVhc3Rhc2lhLXB1YmxpYy0xcC1zZWFzZzMtMDA3IiwgIm5hbWVzcGFjZU5hbWVTdWZmaXgiOiAic2VydmljZWJ1cy53aW5kb3dzLm5ldCIsICJoeWJyaWRDb25uZWN0aW9uTmFtZSI6"

    $relay_info_utils = [Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common.RelayInformationUtils]::new($_context)
    $relay_info_string = $relay_info_utils.GetRelayInformation($resource_group_name, $machine_name, [ref] $message)

    Assert-StartsWith $expected_relay_info_commonpart $relay_info_string 

}

function Test-GetRelayInformationNoEndpointNoPermissionToCreate{

}
