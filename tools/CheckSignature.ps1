<#
    Check (and recurse) current directory     .\CheckSignature.ps1
    Check directory after MSI install         .\CheckSignature.ps1 -MsiInstall
    Check directory after gallery install     .\CheckSignature.ps1 -GalleryInstall
#>
[CmdletBinding(DefaultParameterSetName="CurrentDirectory")]
Param
(
    [Parameter(ParameterSetName="MsiInstall", Mandatory=$true)]
    [switch]$MsiInstall,
    [Parameter(ParameterSetName="GalleryInstall", Mandatory=$true)]
    [switch]$GalleryInstall,
    [Parameter(ParameterSetName="CustomPath", Mandatory=$true)]
    [string]$CustomPath
)

function Check-StrongName {
    [CmdletBinding()]
    param([Parameter(ValueFromPipeline=$true)][string]$path)
    $output = & "sn.exe" -vf $path
    $length = $output.Length - 1
    if (-not $output[$length].Contains("is valid")) {
        Write-Output "$path has an invalid strong name."
    }
}

function Check-AuthenticodeSignature {
    [CmdletBinding()]
    param([Parameter(ValueFromPipeline=$true)][string]$path)
    $output = Get-AuthenticodeSignature $path
    if (-not ($output.Status -like "Valid")) {
        Write-Output "$path has an invalid authenticode signature. Status is $($output.Status)"
    }
}

function Check-All {
    [CmdletBinding()]
    param([Parameter()][string]$path)

    $invalidList = @()

    $files = Get-ChildItem $path\* -Include *.dll -Recurse | where { $_.FullName -like "*Azure*" }
    Write-Host "Checking the strong name signature of $($files.Count) files (.dll)" -ForegroundColor Yellow

    $invalidStrongNameList = @()

    for ($idx = 0; $idx -lt $files.Length; $idx++) {
        $percent = (100 * $idx) / $files.Length
        Write-Progress -Activity "Validating strong name signature of $($files[$idx])" -Status "$percent% Complete" -PercentComplete $percent
        $invalidStrongNameList += Check-StrongName -path $files[$idx]
    }

    if ($invalidStrongNameList.Length -gt 0) {
        $invalidList += $invalidStrongNameList
        Write-Host "Found $($invalidStrongNameList.Count) files with an invalid strong name signature." -ForegroundColor Red
    }
    else {
        Write-Host "All files (.dll) have a strong name signature." -ForegroundColor Green
    }    

    # -------------------------------------

    $files = Get-ChildItem $path\* -Include *.dll, *.ps1, *.psm1 -Recurse | where { $_.FullName -like "*Azure*" }
    $files = $files | where { ($_.FullName -notlike "*Newtonsoft.Json*") -and `
                              ($_.FullName -notlike "*AutoMapper*") -and `
                              ($_.FullName -notlike "*Security.Cryptography*") -and `
                              ($_.FullName -notlike "*BouncyCastle.Crypto*")}
    Write-Host "Checking the authenticode signature of $($files.Count) files (.dll, .ps1, .psm1)" -ForegroundColor Yellow

    $invalidAuthenticodeList = @()

    for ($idx = 0; $idx -lt $files.Length; $idx++) {
        $percent = (100 * $idx) / $files.Length
        Write-Progress -Activity "Validating authenticode signature of $($files[$idx])" -Status "$percent% Complete" -PercentComplete $percent
        $invalidAuthenticodeList += Check-AuthenticodeSignature -path $files[$idx]
    }

    if ($invalidAuthenticodeList.Length -gt 0) {
        $invalidList += $invalidAuthenticodeList
        Write-Host "Found $($invalidAuthenticodeList.Count) files with an invalid authenticode signature." -ForegroundColor Red
    }
    else {
        Write-Host "All files (.dll, .ps1, .psd1) have a valid authenticode signature." -ForegroundColor Green
    }

    if ($invalidList.Length -gt 0) {
        Write-Output($invalidList)
        throw "Strong name signature check and/or authenticode signature check failed. Please see the above errors."
    }
}

$path = ".\"

if ($PSCmdlet.ParameterSetName -eq "MsiInstall")
{
    $path = "${env:ProgramFiles(x86)}\Microsoft SDKs\Azure\PowerShell"
    Write-Host "Installed Azure PowerShell from MSI - checking all (Azure) files in $path" -ForegroundColor Yellow
}
elseif ($PSCmdlet.ParameterSetName -eq "GalleryInstall")
{
    $path = "$($env:ProgramFiles)\WindowsPowerShell\Modules"
    Write-Host "Installed Azure PowerShell from the gallery - checking all (Azure) files in $path" -ForegroundColor Yellow
}
elseif ($PSCmdlet.ParameterSetName -eq "CustomPath")
{
    $path = $CustomPath
    Write-Host "Custom path provided - checking all (Azure) files in $path" -ForegroundColor Yellow
}
else
{
    Write-Host "No switch parameter set - checking all files in current directory" -ForegroundColor Yellow
}

Check-All $path