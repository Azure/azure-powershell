[CmdletBinding()]
param(
    
    [Parameter(Mandatory=$true)]
    [string]$TestExecPath,
    [Parameter(Mandatory=$false)]
    [string]$ModuleFilter
)

$dirPath = (Join-Path $PSScriptRoot -ChildPath '..')
$artPath = (Join-Path $dirPath 'artifacts')
$srcPath = (Join-Path $dirPath -ChildPath 'src')
$libPath = (Join-Path $srcPath -ChildPath 'lib')
$testConfig = (Join-Path $libPath -ChildPath 'test.net472.config')
$rmItems = Get-ChildItem -Recurse -Path $srcPath -Include *.Test.dll `
  | Where {$_.FullName.Contains('bin\Debug\netstandard2.0')}

if ($ModuleFilter)
{
    $rmItems = $rmItems | Where {$_.FullName.Contains($ModuleFilter)}
}

<<<<<<< HEAD
=======
$success = $true

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
$rmItems | %{`
  Write-Host ("Testing " + $_.FullName)
  $testDir = $_.Directory.FullName
  $testExec = Get-Item $TestExecPath
  $testExecDir = $testExec.Directory.FullName
  $testExecFile = $testExec.Name
  $newExecPath = Join-Path $testDir -ChildPath $testExecFile
  $logFile = $_.Name -replace '.dll', '.log.xml'
  $logPath = (Join-Path $artPath $logFile)
  $copiedItems = (Get-ChildItem $testExecDir | Where-Object {$_.Name.StartsWith("xunit")})
  $copiedItems | Copy-Item -Destination $testDir
  try {
<<<<<<< HEAD
  Start-Process -FilePath $newExecPath `
    -Wait `
    -WorkingDirectory $testDir `
    -NoNewWindow `
    -ArgumentList $_.FullName, $testConfig, '-trait "AcceptanceType=CheckIn"', '-notrait "RunType=DesktopOnly"', '-notrait "RunType=CoreOnly"', "-xml $logPath" `
=======
	  # xunit.console will not throw an exception when the tests failed. So we should handle the exitcode by adding option PassThru
	  $process = Start-Process -FilePath $newExecPath `
		-Wait `
		-WorkingDirectory $testDir `
		-NoNewWindow `
		-ArgumentList $_.FullName, $testConfig, '-trait "AcceptanceType=CheckIn"', '-notrait "RunType=DesktopOnly"', '-notrait "RunType=CoreOnly"', "-xml $logPath"  -PassThru 
	  if ($process.ExitCode -ne 0) {
		$success = $false
	  }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
  }
  finally {
    $copiedItems | %{Remove-Item -Force (Join-Path $testDir $_.Name)}
  }
}

<<<<<<< HEAD
=======
if(-not $success) {
    Write-Warning 'Failure: One or more test case failed.'
    exit 1
}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
