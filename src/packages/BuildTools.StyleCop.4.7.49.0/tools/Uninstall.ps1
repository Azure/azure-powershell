param($installPath, $toolsPath, $package, $project)

# if there is no project, then there is nothing to do
if (!$project) { return }

Import-Module (Join-Path $toolsPath "StyleCop.psm1") -Force

# turn it off
Uninstall-StyleCop $project
$project.Save()