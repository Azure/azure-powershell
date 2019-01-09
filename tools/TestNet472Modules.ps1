[CmdletBinding()]
param(
    
    [Parameter(Mandatory=$true)]
    [string]$TestExecPath,
    [Parameter(Mandatory=$false)]
    [string]$ModuleFilter
)

$dirPath = (Join-Path $PSScriptRoot -ChildPath '..')
$srcPath = (Join-Path $dirPath -ChildPath 'src')
$libPath = (Join-Path $srcPath -ChildPath 'lib')
$testConfig = (Join-Path $libPath -ChildPath 'test.net472.config')
$rmItems = Get-ChildItem -Recurse -Path $srcPath -Include *.Test.dll `
  | Where {$_.FullName.Contains('bin\Debug\net472')}

if ($ModuleFilter)
{
    $rmItems = $rmItems | Where {$_.FullName.Contains($ModuleFilter)}
}

$rmItems | %{`
  Write-Host "Testing $_.FullName"
  Start-Process -FilePath $TestExecPath `
    -Wait `
    -WorkingDirectory $PSScriptRoot\..\artifacts `
    -NoNewWindow `
    -ArgumentList $_.FullName, $testConfig, '-trait "AcceptanceType=CheckIn"', '-notrait "Runtype=DesktopOnly"'`
}
