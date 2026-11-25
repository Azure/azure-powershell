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
    $executable = $env:LIVETESTPWSHPATH
    if ([string]::IsNullOrWhiteSpace($executable) -or -not (Test-Path -LiteralPath $executable)) {
        throw "PowerShell executable not found. Ensure InitializeLiveTestEnvironment.ps1 has set the LiveTestPwshPath variable."
    }
    Write-Host "##[section]Using PowerShell at $executable"
    & $executable -NoLogo -NoProfile -NonInteractive -Version
    $baseArguments = @("-NoLogo", "-NoProfile", "-NonInteractive")
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
