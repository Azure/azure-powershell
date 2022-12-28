[cmdletbinding(DefaultParameterSetName = 'PowerShell')]
param(
  [string]
  [Parameter(Mandatory = $true, ParameterSetName = 'PowerShell', Position = 0)]
  [Parameter(Mandatory = $false, ParameterSetName = 'PowerShellPreview', Position = 0)]
  $requiredPsVersion,
  [string]
  [Parameter(Mandatory = $true, ParameterSetName = 'PowerShell', Position = 1)]
  [Parameter(Mandatory = $true, ParameterSetName = 'PowerShellPreview', Position = 1)]
  $script,
  [string]
  [Parameter(Mandatory = $true, ParameterSetName = 'PowerShellPreview')]
  $PowerShellPath,
  [string]
  [Parameter(Mandatory = $true, ParameterSetName = 'PowerShellPreview')]
  $AgentOS
)

Write-Host "Required Version:", $requiredPsVersion, ", script:", $script
$windowsPowershellVersion = "5.1.14"

$script += " -ErrorAction Stop"
if($requiredPsVersion -eq $windowsPowershellVersion){
    Invoke-Command -ScriptBlock { param ($command) &"powershell.exe" -Command $command } -ArgumentList $script 
}else{
    $command = "`$PSVersionTable `
                  $script `
                  Exit"
    if ($requiredPsVersion -eq "preview") {
      if ( $AgentOS -ne $IsWinEnv) { chmod 755 "$PowerShellPath/pwsh" }
      . "$PowerShellPath/pwsh" -Command $command
    } else {
      dotnet tool run pwsh -c $command
    }
}