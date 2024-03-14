<#
    Check (and recurse) current directory                   .\CheckSignature.ps1
    Find and check directory of Azure PowerShell modules    .\CheckSignature.ps1 -AzurePowerShell
    Check directory of MSI-installed modules                .\CheckSignature.ps1 -MsiInstall
    Check directory of gallery-installed modules            .\CheckSignature.ps1 -GalleryInstall
    Check files in provided path                            .\CheckSignature.ps1 -CustomPath $Path
#>
[CmdletBinding(DefaultParameterSetName="CurrentDirectory")]
Param
(
    [Parameter(ParameterSetName="AzurePowerShell", Mandatory=$true)]
    [switch]$AzurePowerShell,
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

    if (!(Get-Command "sn.exe" -ErrorAction SilentlyContinue))
    {
        Write-Error "Unable to find sn.exe; please ensure that the Windows SDK is installed and found in the PATH environment variable."
        return
    }

    $invalidList = @()

    $files = Get-ChildItem $path\* -Include *.dll -Recurse | Where-Object { $_.FullName -like "*Azure*" }
    $files = $files | Where-Object { ($_.FullName -notlike "*System.Management.Automation*") }
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

    $files = Get-ChildItem $path\* -Include *.dll, *.ps1, *.psm1 -Recurse | Where-Object { $_.FullName -like "*Azure*" }
    $files = $files | Where-Object { ($_.FullName -notlike "*Newtonsoft.Json*") -and `
                                     ($_.FullName -notlike "*AutoMapper*") -and `
                                     ($_.FullName -notlike "*Security.Cryptography*") -and `
                                     ($_.FullName -notlike "*NLog*") -and `
                                     ($_.FullName -notlike "*YamlDotNet*") -and `
                                     ($_.FullName -notlike "*BouncyCastle.Crypto*") -and `
                                     ($_.FullName -notlike "*System.Management.Automation*")}
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
        Write-Host "All files (.dll, .ps1, .psm1) have a valid authenticode signature." -ForegroundColor Green
    }

    if ($invalidList.Length -gt 0) {
        Write-Output($invalidList)
        throw "Strong name signature check and/or authenticode signature check failed. Please see the above errors."
    }
}

$path = ".\"

if ($PSCmdlet.ParameterSetName -eq "AzurePowerShell")
{
    $ProfileModule = Get-Module -Name AzureRM.Profile -ListAvailable
    if (!($ProfileModule))
    {
        Write-Error "Unable to find the AzureRM.Profile module. Please ensure that Azure PowerShell has been installed and the appropriate path is found in the PSModulePath environment variable."
        return
    }

    if ($ProfileModule.Count -gt 1)
    {
        Write-Error "Mulitple versions of Azure PowerShell were found. Please use the -MsiInstall and -GalleryInstall switches to select the installed version you want to check."
        return
    }

    $ModulePath = $ProfileModule.Path
    if ($ModulePath -like "*Microsoft SDKs\Azure\PowerShell*")
    {
        $EndIdx = $ModulePath.IndexOf("PowerShell\ResourceManager", [System.StringComparison]::OrdinalIgnoreCase) + "PowerShell".Length
    }
    elseif ($ModulePath -like "*Modules\AzureRM.Profile*")
    {
        $EndIdx = $ModulePath.IndexOf("Modules\AzureRM.Profile", [System.StringComparison]::OrdinalIgnoreCase) + "Modules".Length
    }

    $path = $ModulePath.Substring(0, $EndIdx)
    Write-Host "Found AzureRM module - checking all (Azure) files in $path" -ForegroundColor Yellow
}
elseif ($PSCmdlet.ParameterSetName -eq "MsiInstall")
{
    $ProfileModule = Get-Module -Name AzureRM.Profile -ListAvailable
    if (!($ProfileModule))
    {
        Write-Error "Unable to find the AzureRM.Profile module. Please ensure that Azure PowerShell has been installed and the appropriate path is found in the PSModulePath environment variable."
        return
    }

    $SearchString = "Microsoft SDKs\Azure\PowerShell"

    $ModulePath = $ProfileModule.Path

    if ($ProfileModule.Count -gt 1)
    {
        $ModulePath = $ProfileModule | Where-Object { $_.Path -like "*$($SearchString)*" }
        if (!($ModulePath))
        {
            Write-Error "Unable to find path of MSI-installed modules from multiple locations found in PSModulePath."
            return
        }
    }
    else
    {
        if ($ModulePath -notlike "*$($SearchString)*")
        {
            Write-Error "Modules installed on the current machine were not from MSI. Consider using the -GalleryInstall switch."
            return
        }
    }

    $EndIdx = $ModulePath.IndexOf("PowerShell\ResourceManager", [System.StringComparison]::OrdinalIgnoreCase) + "PowerShell".Length
    $path = $ModulePath.Substring(0, $EndIdx)
    Write-Host "Installed Azure PowerShell from MSI - checking all (Azure) files in $path" -ForegroundColor Yellow
}
elseif ($PSCmdlet.ParameterSetName -eq "GalleryInstall")
{
    $ProfileModule = Get-Module -Name AzureRM.Profile -ListAvailable
    if (!($ProfileModule))
    {
        Write-Error "Unable to find the AzureRM.Profile module. Please ensure that Azure PowerShell has been installed and the appropriate path is found in the PSModulePath environment variable."
        return
    }

    $SearchString = "WindowsPowerShell\Modules"

    $ModulePath = $ProfileModule.Path

    if ($ProfileModule.Count -gt 1)
    {
        $ModulePath = $ProfileModule | Where-Object { $_.Path -like "*$($SearchString)*" }
        if (!($ModulePath))
        {
            Write-Error "Unable to find path of gallery-installed modules from multiple locations found in PSModulePath."
            return
        }
    }
    else
    {
        if ($ModulePath -notlike "*$($SearchString)*")
        {
            Write-Error "Modules installed on the current machine were not from the gallery. Consider using the -MsiInstall switch."
            return
        }
    }

    $EndIdx = $ModulePath.IndexOf("Modules\AzureRM.Profile", [System.StringComparison]::OrdinalIgnoreCase) + "Modules".Length
    $path = $ModulePath.Substring(0, $EndIdx)
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
