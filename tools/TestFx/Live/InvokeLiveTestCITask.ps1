[CmdletBinding(DefaultParameterSetName = "ByScriptFile")]
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
    $process = "dotnet tool run pwsh"
    Write-Host "##[section]Using PowerShell"
    dotnet tool run pwsh -NoLogo -NoProfile -NonInteractive -Version
}

switch ($PSCmdlet.ParameterSetName) {
    "ByScriptFile" {
        Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -File $ScriptFile"
    }
    "ByScriptBlock" {
        Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -Command $ScriptBlock"
    }
}
