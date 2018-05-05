$ErrorActionPreference = "Stop"
$scriptpath = $MyInvocation.MyCommand.Path
$scriptDirectory = Split-Path $scriptpath
$scriptFileName = Split-Path $scriptpath -Leaf

function prompt { return "PS> " }

ipmo "$($scriptDirectory)\devops.psm1" -DisableNameChecking