param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [guid] $ServicePrincipalTenantId,

    [Parameter(Mandatory, Position = 1)]
    [ValidateNotNullOrEmpty()]
    [guid] $ServicePrincipalId,

    [Parameter(Mandatory, Position = 2)]
    [ValidateNotNullOrEmpty()]
    [string] $ServicePrincipalSecret,

    [Parameter(Mandatory, Position = 3)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterName,

    [Parameter(Mandatory, Position = 4)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterRegion,

    [Parameter(Mandatory, Position = 5)]
    [ValidateNotNullOrEmpty()]
    [string] $DatabaseName,

    [Parameter(Mandatory, Position = 6)]
    [ValidateNotNullOrEmpty()]
    [string] $TableName,

    [Parameter(Mandatory, Position = 7)]
    [ValidateNotNullOrEmpty()]
    [string] $BuildId,

    [Parameter(Mandatory, Position = 8)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailServiceConnectionString,

    [Parameter(Mandatory, Position = 9)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailFrom,

    [Parameter(Mandatory, Position = 10)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailTo
)

$utilDir = Join-Path -Path ($PSScriptRoot | Split-Path) -ChildPath "Utilities"

$kustoUtil = $utilDir | Join-Path -ChildPath "KustoUtility.psd1"
Import-Module $kustoUtil -ArgumentList $ServicePrincipalTenantId, $ServicePrincipalId, $ServicePrincipalSecret, $ClusterName, $ClusterRegion -Force

$query = @"
    $TableName
    | where BuildId == $BuildId and IsSuccess == false
    | project BuildId, OSVersion, PSVersion, Module, Name, Exception = tostring(Errors["Exception"]), RetryException = tostring(Errors["Retry3Exception"])
"@
$errors = Get-KustoQueryData -DatabaseName $DatabaseName -Query $query
$errors

$emailSvcUtil = $utilDir | Join-Path -ChildPath "EmailServiceUtility.psd1"
Import-Module $emailSvcUtil -ArgumentList $EmailServiceConnectionString, $EmailFrom -Force

$css = @"
    <style>
    table, th, td {
        border: 1px solid;
    }

    table {
        border-collapse: collapse;
    }

    th, td {
        padding: 5px;
    }

    th {
        color: white;
        background-color: #05a6f0;
    }

    h1 {
        text-align: center;
    }
    </style>
"@

$emailSubject = "Live Test Status Report"

if ($errors.Count -gt 0) {
    $emailBody = $errors | ConvertTo-Html -Property BuildId, OSVersion, PSVersion, Module, Name, Exception, RetryException -Head $css -Title "Live Test Report" -PreContent "<h1>Live Test Error Details</h1>"
}
else {
    $emailBody = "<html><body>No live test errors reported. Please check the overall status from Azure pipeline.</body></html>"
}

Send-EmailServiceMail -To $EmailTo -Subject $emailSubject -Body $emailBody
