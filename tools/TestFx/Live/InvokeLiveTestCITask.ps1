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
}
else {
    $process = "dotnet tool run pwsh"
}

switch ($PSCmdlet.ParameterSetName) {
    "ByScriptFile" {
        Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -File $ScriptFile"
    }
    "ByScriptBlock" {
        Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -Command $ScriptBlock"
    }
}
