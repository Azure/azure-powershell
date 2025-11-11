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
    Write-Host "##[section]Using Windows PowerShell"
    $executable = "powershell"
    $baseArguments = @("-NoLogo", "-NoProfile", "-NonInteractive")
}
else {
    Write-Host "##[section]Using PowerShell"
    dotnet tool run pwsh -NoLogo -NoProfile -NonInteractive -Version
    $executable = "dotnet"
    $baseArguments = @("tool", "run", "pwsh", "-NoLogo", "-NoProfile", "-NonInteractive")
}

switch ($PSCmdlet.ParameterSetName) {
    "ByScriptFile" {
        $arguments = $baseArguments + @("-Command", "& $ScriptFile")
        & $executable @arguments
    }
    "ByScriptBlock" {
        $arguments = $baseArguments + @("-Command", $ScriptBlock)
        & $executable @arguments
    }
}
