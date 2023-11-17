param(
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [string] $DesiredVersion
)

& (Join-Path -Path ($PSScriptRoot | Split-Path) -ChildPath "Utilities" | Join-Path -ChildPath "CommonUtility.ps1")

$winPSVersion = "5.1"
$isWinPSDesired = $DesiredVersion -eq $winPSVersion

Write-Host "Validating desired PowerShell version."

if ($isWinPSDesired) {
    powershell -NoLogo -NoProfile -NonInteractive -Command "(Get-Variable -Name PSVersionTable).Value"
    Write-Host "##[section]Desired Windows Powershell version $DesiredVersion has been installed."
}
else {
    Write-Host "##[section]Installing PowerShell version $DesiredVersion."

    dotnet --version
    dotnet new tool-manifest --force
    if ($DesiredVersion -eq "latest") {
        dotnet tool install powershell
    }
    else {
        dotnet tool install powershell --version $DesiredVersion
    }
    dotnet tool list

    dotnet tool run pwsh -Version

    Write-Host "##[section]Desired PowerShell version $DesiredVersion has been installed."
}

if ($DesiredVersion -eq "latest") {
    $curMajorVer = dotnet tool run pwsh -NoLogo -NoProfile -NonInteractive -Command "(Get-Variable -Name PSVersionTable -ValueOnly).PSVersion.Major"
    $curMinorVer = dotnet tool run pwsh -NoLogo -NoProfile -NonInteractive -Command "(Get-Variable -Name PSVersionTable -ValueOnly).PSVersion.Minor"
    $curSimpleVer = "$curMajorVer.$curMinorVer"

    if ($curSimpleVer -eq ${env:POWERSHELLLATEST}) {
        Write-Host "##[section]Skipping live test for PowerShell $curSimpleVer as it has already been explicitly specified in the pipeline." -ForegroundColor Green
        Write-Host "##vso[task.setvariable variable=skipLatest;isreadonly=true]true"
    }
}
