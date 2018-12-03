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
  | Where {$_.FullName.Contains('bin\Debug\netstandard2.0')}
$storageItems = Get-ChildItem -Recurse -Path $storageBasePath -Include *.Test.dll `
  | Where {$_.FullName.Contains('bin\Debug\netstandard2.0')}

if ($ModuleFilter)
{
    $rmItems = $rmItems | Where {$_.FullName.Contains($ModuleFilter)}
    $storageItems = $storageItems | Where {$_.FullName.Contains($ModuleFilter)}
}

$rmItems | %{`
  Write-Host ("Testing " + $_.FullName)
  $testDir = $_.Directory.FullName
  $testExec = Get-Item $TestExecPath
  $testExecDir = $testExec.Directory.FullName
  $testExecFile = $testExec.Name
  $newExecPath = Join-Path $testDir -ChildPath $testExecFile
  $copiedItems = (Get-ChildItem $testExecDir | Where-Object {$_.Name.StartsWith("xunit")})
  $copiedItems | Copy-Item -Destination $testDir
  try {
  Start-Process -FilePath $newExecPath `
    -Wait `
    -WorkingDirectory $testDir `
    -NoNewWindow `
    -ArgumentList $_.FullName, $testConfig, '-trait "AcceptanceType=CheckIn"', '-notrait "Runtype=DesktopOnly"'`
  }
  finally {
    $copiedItems | %{Remove-Item -Force (Join-Path $testDir $_.Name)}
  }
}

$storageItems | %{`
  Write-Host ("Testing " + $_.FullName)
  Start-Process -FilePath $TestExecPath `
    -Wait `
    -WorkingDirectory $_.Directory.FullName `
    -NoNewWindow `
    -ArgumentList $_.FullName, $testStorageConfig, '-trait "AcceptanceType=CheckIn"'`
}


