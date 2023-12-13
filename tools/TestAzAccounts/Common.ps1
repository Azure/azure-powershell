function ConvertTo-PlainString
{
    param (
        [Parameter(Mandatory=$true, Position=0)]
        [object]
        $Secret
    )

    $ssPtr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($Secret)
    try {
        $secretValueText = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR($ssPtr)
    } finally {
        [System.Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ssPtr)
    }
    return $secretValueText
}

function Invoke-PowerShellCommand
{
    param (
        [Parameter(Mandatory)]
        [bool] $UseWindowsPowerShell,

        [Parameter(Mandatory, ParameterSetName = "ByScriptFile")]
        [ValidateNotNullOrEmpty()]
        [string] $ScriptFile,

        [Parameter(Mandatory, ParameterSetName = "ByScriptBlock")]
        [ValidateNotNullOrEmpty()]
        [string] $ScriptBlock
    )

    if ($UseWindowsPowerShell) {
        $process = "powershell"
        Write-Host "##[section]Using Windows PowerShell"
    }
    else {
        $process = "pwsh"
        Write-Host "##[section]Using PowerShell"
        pwsh -NoLogo -NoProfile -NonInteractive -Version
    }

    switch ($PSCmdlet.ParameterSetName) {
        "ByScriptFile" {
            Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -File $ScriptFile"
        }
        "ByScriptBlock" {
            #Write-Host "The commnd to execute:"
            #Write-Host "$ScriptBlock"
            Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -Command $ScriptBlock"
        }
    }
}

function Set-TestEnvironment
{
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $AzVersion,

        [Parameter(Mandatory = $true)]
        [string]
        $NugetPath
    )

    $module = Find-Module -name Az -RequiredVersion $AzVersion
    if ($null -ne $module)
    {
        $null = Install-AzModule -RequiredAzVersion $AzVersion -UseExactAccountVersion -Repository PSGallery
    }
    else
    {
        throw "The specified version $AzVersion is not found in PSGallery."
    }
    $accountsVersion = ($module.Dependencies | Where-Object {$_.Name -eq "Az.Accounts"}).MinimumVersion
    $null = Install-AzModule -Path $NugetPath

    $accountsVersion
}
