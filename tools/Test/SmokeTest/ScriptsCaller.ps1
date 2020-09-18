[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $true, Position = 0)]
  $requiredPsVersion,
  [string]
  [Parameter(Mandatory = $true, Position = 1)]
  $script
)

$preinstalledPsVersion = $PSVersionTable.PSVersion.ToString()

if($requiredPsVersion -eq $preinstalledPsVersion){
    $pwsh = "powershell"
    if($PSVersionTable.PSEdition -eq "Core"){
        $pwsh = "pwsh"
    }
    Invoke-Command -ScriptBlock { param ($pwsh, $command) & $pwsh -Command $command } -ArgumentList $pwsh, $script 
}else{
    $command = "`$PSVersionTable `
                $script `
                Exit"
    dotnet tool run pwsh -c $command
}