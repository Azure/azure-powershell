
$RepoRoot = Get-Location
$buildProjPath = Join-Path $RepoRoot 'build.proj'

$filesChangedOutputPath = Join-Path $RepoRoot 'artifacts' 'FilesChanged.txt'
$subTasksFilePath = Join-Path $RepoRoot 'artifacts' 'SubTasksFile.txt'
$IsSecurityCheck = $null

dotnet msbuild $buildProjPath /t:FilterBuild "/p:FilesChangedOutputPath=$FilesChangedOutputPath;SubTasksFilePath=$SubTasksFilePath;IsSecurityCheck=$IsSecurityCheck"
