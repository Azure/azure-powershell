#Requires -Modules Pester

param(
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory=$true)]
    [System.String]$RootTestLocation
)

Set-Location $RootTestLocation

Invoke-Pester -EnableExit