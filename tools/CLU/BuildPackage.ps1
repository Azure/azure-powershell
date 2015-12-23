param([string]$cmdletsDir, [string]$packageId, [string]$packageSource, [string]$packageVersion, [string]$outputDir)

if (!(Test-Path $cmdletsDir))
{
	throw "cmdletsDir: '$cmdletsDir' must be an existing directory containing cmdlet code"
}
if (!(Test-Path $outputDir))
{
	throw "outputDir: '$outputDir' must be an existing directory"
}

if ([string]::IsNullOrWhiteSpace($env:WORKSPACE) -or !(Test-Path $env:WORKSPACE))
{
	throw "env:WORKSPACE: '$env:WORKSPACE' must be an existing directory"
}

$packageSource = $packageSource.TrimEnd('\\')
Write-Host "using package id: $packageId, package source: $packageSource, packageVersion: $packageVersion"
dotnet publish $cmdletsDir -f dnxcore50 -r win7-x64 -o $packageSource
Copy-Item -Path $cmdletsDir\content -Destination $packageSource\content -Recurse -Force

$nuSpecTemplate = (Get-ChildItem ([System.IO.Path]::Combine($cmdletsDir, ($packageId + ".nuspec.template"))))
$nuSpecOutput = [System.IO.Path]::Combine($packageSource, ($packageId + ".nuspec"))
Write-Host "Creating dynamic nuspec package in: $nuSpecOutput"

$fileContent = Get-Content $nuSpecTemplate
$renameFileExists = Test-Path -Path ([System.IO.Path]::Combine($packageSource, "content", "rename.cfg"))
$files = (Get-ChildItem $packageSource | Where -FilterScript {!$_.Name.Contains("nuspec")} | Select-Object -Property Name)
$refFiles = $files | Where -FilterScript { $_.Name.EndsWith(".dll")}
$contentFiles = $files | Where -FilterScript { $_.Name.EndsWith("xml")}
$refFileText = ""
$refFiles | %{$refFileText +=  ("        <reference file=""" + $_.Name + """/>`r`n")}
$contentFileText = ""
$contentFiles | %{ $contentFileText += ("    <file src=""" + $_.Name + """ target=""content""/>`r`n")}
if ($packageId -ne "Microsoft.CLU.Commands") 
{
	$contentFileText += "    <file src=""content\*.lx"" target=""content""/>`r`n"
}
if ($renameFileExists)
{
	$contentFileText += "    <file src=""content\rename.cfg"" target=""content""/>`r`n"
}
$contentFileText += "    <file src=""content\package.cfg"" target=""content""/>`r`n"
$sourceFileText = ""
$refFiles | %{$sourceFileText += ("    <file src=""" + $_.Name + """ target=""lib\dnxcore50""/>`r`n")}
$outputContent = $fileContent -replace "%PackageVersion%", $packageVersion 
$outputContent = $outputContent -replace "%ReferenceFiles%", $refFileText
 $outputContent = $outputContent -replace "%SourceFiles%", $sourceFileText 
 $outputContent = $outputContent -replace "%ContentFiles%", $contentFileText
Set-Content -Value $outputContent -Path $nuspecOutput

Write-Host "Creating nuget package..."
cmd /c "$env:WORKSPACE\tools\Nuget.exe pack $nuspecOutput -OutputDirectory $outputDir"
Pop-Location
