Import-Module ".\Modules\Build-Tasks.psd1"
Import-Module ".\Modules\TestFx-Tasks.psd1"

$taskScriptDir = [System.IO.Path]::GetDirectoryName($PSCommandPath)
$env:repoRoot = [System.IO.Path]::GetDirectoryName($taskScriptDir)
$userPsFileDir = [string]::Empty

[string]$envVariableName="TEST_CSM_ORGID_AUTHENTICATION"

Function Init()
{
    #Initialize Code
}


<#
We allow users to include any helper powershell scripts they would like to include in the current session
Currently we support two ways to include helper powershell scripts
1) psuserspreferences environment variable
2) $env:USERPROFILE\psFiles directory
We will include all *.ps1 files from any of the above mentioned locations
#>
if([System.IO.Directory]::Exists($env:psuserpreferences))
{
	$userPsFileDir = $env:psuserpreferences
}
elseif([System.IO.Directory]::Exists("$env:USERPROFILE\psFiles"))
{
	$userPsFileDir = "$env:USERPROFILE\psFiles"
}

if([string]::IsNullOrEmpty($userPsFileDir) -eq $false)
{
	Get-ChildItem $userPsFileDir | WHERE {$_.Name -like "*.ps1"} | ForEach {
	Write-Host "Including $_" -ForegroundColor Green
	. $userPsFileDir\$_
	}
}
else
{
	Write-Host "Loading skipped. 'psuserpreferences' environment variable was not set to load user preferences." -ForegroundColor DarkYellow
}

Write-Host "For more information on the Repo-Tasks module, please see the following: https://github.com/Azure/azure-powershell/blob/preview/documentation/testing-docs/repo-tasks-module.md" -ForegroundColor Yellow

#Execute Init
#Init
