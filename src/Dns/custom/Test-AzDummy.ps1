<#
.Synopsis
Dummy alias cmdlet
.Description
Dummy alias cmdlet
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dns/test-azdummy
#>
function Test-AzDummy {
[OutputType('Boolean')]
[CmdletBinding(PositionalBinding=$false)]
[Alias(
    'Add-AzDnsRecordConfig'
    ,'New-AzDnsRecordConfig'
    ,'Remove-AzDnsRecordConfig'
)]
[Microsoft.Azure.PowerShell.Cmdlets.Dns.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Dns.Description('Dummy alias cmdlet')]
param(
    [Parameter(Mandatory, HelpMessage='The name of the dummy.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Path')]
    [Alias(
        'RecordSet'
        ,'Ipv4Address'
        ,'Ipv6Address'
        ,'Nsdname'
        ,'Exchange'
        ,'Preference'
        ,'Ptrdname'
        ,'Value'
        ,'Priority'
        ,'Target'
        ,'Port'
        ,'Weight'
        ,'Cname'
        ,'CaaFlags'
        ,'CaaTag'
        ,'CaaValue'
    )]
    [System.String]
    ${Name},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile}
)

process {}
}
