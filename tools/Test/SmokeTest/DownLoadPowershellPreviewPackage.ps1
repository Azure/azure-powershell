[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $true, Position = 0)]
  $DowanloadDir,
  [string]
  [Parameter(Mandatory = $true)]
  $AgentOS,
  [string]
  [Parameter(Mandatory = $true)]
  $AgentAarchitecture
)

$ExtractDestination = Join-Path $DowanloadDir "ps_preview"

switch ($AgentOS) {
        "Windows_NT" { $OS = "win" }
        "Linux" { $OS = "linux" }
        "Darwin" { $OS = "osx" }
        default { throw "PowerShell package for OS '$_' is not supported." }
}

switch ($AgentAarchitecture) {
        "X86" { $Architecture = "x86" }
        "X64" { $Architecture = "x64" }
        "ARM" { $Architecture = "arm64" }
        default { throw "PowerShell package for OS architecture '$_' is not supported." }
 }

# Fetch the recent PowerShell preview release version from github file.
$Metadata = Invoke-RestMethod https://raw.githubusercontent.com/PowerShell/PowerShell/master/tools/metadata.json
# Remove the beginning 'v' from PreviewReleaseTag.
# Eg. Change from 'v7.4.0-preview.1' to '7.4.0-preview.1'.
$Release = $Metadata.PreviewReleaseTag -replace '^v'

if ($OS -eq "win") {
  $PackageName = "PowerShell-${Release}-${OS}-${Architecture}.zip"
} else {
  $PackageName = "Powershell-${Release}-${OS}-${Architecture}.tar.gz"
}

$null = New-Item -ItemType Directory -Path $DowanloadDir -ErrorAction SilentlyContinue
$DownloadURL = "https://github.com/PowerShell/PowerShell/releases/download/v${Release}/${PackageName}"
Write-Verbose "About to download package from '$DownloadURL' to '$DowanloadDir'" -Verbose
$PackagePath = Join-Path -Path $DowanloadDir -ChildPath $PackageName

Invoke-WebRequest -Uri $downloadURL -OutFile $PackagePath
Write-Host "##vso[task.setvariable variable=PowerShellPath]$ExtractDestination"