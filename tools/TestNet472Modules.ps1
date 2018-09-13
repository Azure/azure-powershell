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
$rmBasePath = (Join-Path $srcPath -ChildPath 'ResourceManager')
$storageBasePath = (Join-Path $srcPath -ChildPath 'Storage')
$testConfig = (Join-Path $libPath -ChildPath 'test.net472.config')
$testStorageConfig = (Join-Path $libPath -ChildPath 'test.net472.storage.config')
$rmItems = Get-ChildItem -Recurse -Path $rmBasePath -Include *.Test.dll `
  | Where {$_.FullName.Contains('bin\Debug\net472')}
$storageItems = Get-ChildItem -Recurse -Path $storageBasePath -Include *.Test.dll `
  | Where {$_.FullName.Contains('bin\Debug\net472')}

if ($ModuleFilter)
{
    $rmItems = $rmItems | Where {$_.FullName.Contains($ModuleFilter)}
    $storageItems = $storageItems | Where {$_.FullName.Contains($ModuleFilter)}
}

$rmItems | %{`
  Write-Host "Testing $_.FullName"
  Start-Process -FilePath $TestExecPath `
    -Wait `
    -WorkingDirectory $PSScriptRoot\..\src\Package `
    -NoNewWindow `
    -ArgumentList $_.FullName, $testConfig, '-trait "AcceptanceType=CheckIn"', '-notrait "Runtype=DesktopOnly"'`
}

$storageItems | %{`
  Write-Host "Testing $_.FullName"
  Start-Process -FilePath $TestExecPath `
    -Wait `
    -WorkingDirectory $PSScriptRoot\..\src\Package `
    -NoNewWindow `
    -ArgumentList $_.FullName, $testStorageConfig, '-trait "AcceptanceType=CheckIn"'`
}


