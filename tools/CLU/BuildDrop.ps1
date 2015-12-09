param([string]$dropLocation, [string]$packageVersion="0.0.1", [switch] $excludeCommandPackages, [switch] $excludeCluRun)

$thisScriptDirectory = Split-Path $MyInvocation.MyCommand.Path -Parent

$workspaceDirectory = $env:WORKSPACE
if (!($workspaceDirectory))
{
    $workspaceDirectory = (Resolve-Path "$thisScriptDirectory\..\..").Path
    $env:WORKSPACE = $workspaceDirectory
}

$buildProfileScriptPath = "`"$thisScriptDirectory\BuildProfile.ps1`"" # Guard against spaces in the path
$sourcesRoot = "$workspaceDirectory\src\clu"

if (!($dropLocation))
{
    $dropLocation = "$workspaceDirectory\drop"
}

if (!(Test-Path -Path $dropLocation -PathType Container))
{
    mkdir "$dropLocation"
    mkdir "$dropLocation\CommandRepo"
    mkdir "$dropLocation\clurun"
}



if (!($excludeCommandPackages.IsPresent))
{
    # Grap all command packages to build.
    # We'll assume that all directories that contain a *.nuspec.template file is a command package and that the name of the package is everything leading up to .nuspec.template
    $commandPackages = Get-ChildItem -path $sourcesRoot -Filter '*.nuspec.template' -Recurse -File | ForEach-Object { New-Object PSObject -Property @{Directory=$_.DirectoryName; Package=$_.Name.Substring(0, $_.Name.Length - ".nuspec.template".Length)} }

    foreach($commandPackage in $commandPackages)
    {
        $commandPackageName = $commandPackage.Package
        $commandPackageDir  = $commandPackage.Directory
        $buildOutputDirectory = Join-Path -path $commandPackageDir -ChildPath "bin\Debug\publish"


        Invoke-Expression "& $buildProfileScriptPath $commandPackageDir $commandPackageName $buildOutputDirectory $packageVersion $dropLocation\CommandRepo"
    }
}

if (!($excludeCluRun))
{
    foreach ($runtime in @("win7-x64", "osx.10.10-x64", "ubuntu.14.04-x64"))
    {
        $cluRunOutput = "$dropLocation\clurun\$runtime"
        dotnet publish "$sourcesRoot\clurun" --framework dnxcore50 --runtime $runtime --output $cluRunOutput

        if (!($runtime.StartsWith("win")))
        {
            # Fix current x-plat dotnet publish by correctly renaming ConsoleHost to clurun
            Move-Item -Path "$cluRunOutput\coreconsole" -Destination "$cluRunOutput\clurun" -Force

            # Remove all extra exes that end up in the output directory...
            Get-ChildItem -Path "$cluRunOutput" -Filter "*.exe" | Remove-Item
        }
        else 
        {
            # Remove all extra exes that end up in the output directory...
            Get-Childitem -path "$cluRunOutput" -Filter *.exe | Where-Object -Property "Name" -Value "clurun.exe" -NotMatch | Remove-Item
        }
    }
}