[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $true)]
  $requiredPsVersion,
  [string]
  [Parameter(Mandatory = $true)]
  $script,
  [string]
  [AllowEmptyString()]
  [Parameter(Mandatory = $false)]
  $PowerShellPath,
  [string]
  [Parameter(Mandatory = $false)]
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
      # Change the mode of 'pwsh' to 'rwxr-xr-x' to allow execution
      if ( $AgentOS -ne $IsWinEnv) { chmod 755 "$PowerShellPath/pwsh" }
      . "$PowerShellPath/pwsh" -Command $command
    } else {
      dotnet tool run pwsh -c $command
    }
}