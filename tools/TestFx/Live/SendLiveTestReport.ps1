param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailServiceConnectionString,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailFrom
)

$ltResults = Get-ChildItem -Path ${env:DATALOCATION} -Filter "LiveTestAnalysis" -Directory -Recurse -ErrorAction SilentlyContinue | Get-ChildItem -Filter "Raw" -Directory | Get-ChildItem -Filter "*.csv" -File | Select-Object -ExpandProperty FullName
if ($null -ne $ltResults) {
    $errorsArr = $ltResults | ForEach-Object {
        $ltCsv = $_
        (Import-Csv -Path $ltCsv) | Where-Object IsSuccess -eq $false | Select-Object OSVersion, PSVersion, Module, Name, Errors | ForEach-Object {
            $errors = $_.Errors | ConvertFrom-Json
            [PSCustomObject]@{
                OSVersion      = $_.OSVersion
                PSVersion      = $_.PSVersion
                Module         = $_.Module
                Name           = $_.Name
                Exception      = $errors.Exception
                RetryException = $errors.Retry3Exception
            }
        }
    } | Sort-Object OSVersion, PSVersion, Module, Name
}

$emailSvcUtil = Join-Path -Path ($PSScriptRoot | Split-Path) -ChildPath "Utilities" | Join-Path -ChildPath "EmailServiceUtility.psd1"
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

    table#summary {
        width: 50%;
    }

    table#summary td {
        width: 50%;
    }
    </style>
"@

$emailSubject = "Azure PowerShell Live Test Status Report"

$summarySection = @"
    <h1>Live Test Summary</h1>
    <table id='summary'>
        <tr>
            <td><b>Requested For:</b></td>
            <td>${env:BUILD_REQUESTEDFOR}</td>
        </tr>
        <tr>
            <td><b>Build Number:</b></td>
            <td><a href="${env:LIVETESTPIPELINEURL}/_build/results?buildId=${env:BUILD_BUILDID}">${env:BUILD_BUILDID}</a></td>
        </tr>
        <tr>
            <td><b>Build Reason:</b></td>
            <td>${env:BUILD_REASON}</td>
        </tr>
        <tr>
            <td><b>Source Branch Name:</b></td>
            <td>${env:BUILD_SOURCEBRANCH}</td>
        </tr>
    </table>
    <br />
"@

if ($errorsArr.Count -gt 0) {
    Write-Host "##[error]Found $($errorsArr.Count) live test error(s)."
    $errorsArr

    $emailContent = $errorsArr | ConvertTo-Html -Property OSVersion, PSVersion, Module, Name, Exception, RetryException -Head $css -Title "Azure PowerShell Live Test Report" -PreContent "$summarySection<h1>Live Test Error Details</h1>"

    Send-EmailServiceMail -To "${env:EMAILTO}" -Subject $emailSubject -Content $emailContent -IsHtml

    Write-Host "##[section]Live test error report email sent successfully."
}
else {
    Write-Host "##[section]All live tests passed. No errors found."
}
