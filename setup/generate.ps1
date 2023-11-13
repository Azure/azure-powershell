<#
.SYNOPSIS
    Generate the Azure Cmdlets MSI files.
.DESCRIPTION
    This script installs the azure cmdlets from the powershell gallery, tweaks them and generates MSI files for x86 and x64.
    When the MSI installs it will install the cmdlets to the same location the gallery would, and PowerShellGet treats them 
    as if they were installed from the gallery
.PARAMETER Version
    The version number for the generated MSI.
.PARAMETER Force
    Forces a fresh installation of the Az cmdlets from the gallery
.PARAMETER noBuildNumber
    Prevent a build number from being tacked on the end of the version number.
.PARAMETER repository
    Set the repository to pull packages from.
#>

param(
    [Parameter(HelpMessage="The version number for the generated MSI.  This will be obtained from the Az module if not specified.")]
    [string]$version="0",
    
    [Parameter(HelpMessage="Prevent a build number from being tacked on the end of the version number.")]
    [Switch]$noBuildNumber,

    [Parameter(HelpMessage="Set the repository to pull packages from.")]
    [string]$repository="PSGallery"
    )

if( (-not (get-command -ea 0 light)) -or (-not (get-command -ea 0 heat)) -or (-not(get-command -ea 0  candle)) ) {
    write-host -fore Red  "This script requires WiX Toolset in the path. [exiting]"
    return ;
}

# variables 

# output filename (plus '-$version-$arch.msi' )
$outputName ="Az-Cmdlets"

# generate the product name from the current month/year.
$productName = "Microsoft Azure PowerShell - November 2023"

# where to put temp files
$tmp = Join-Path $env:temp azure-cmdlets-tmp

# where we're going to install the modules to 
$modulesDir = "$tmp\modules"

# archetectures supported
$archs = @('x86','x64')

$scriptLocation = (Get-Item $PSCommandPath).Directory

# cleanup first
Write-Host -fore yellow "Forcing clean install"
$shhh = (cmd.exe /c rmdir /s /q $tmp)

$shhh = mkdir -ea 0 "$tmp"
erase -ea 0 "$tmp/*.wixobj"
erase -ea 0 "$tmp/*.wxi"

erase -ea 0 "$scriptLocation/*.wixpdb"
erase -ea 0 "$scriptLocation/*.msi"

# install modules locally.
if ( -not (test-path $modulesDir))  {
    Write-Host -fore green "Installing Modules..."
    # create a folder for everything
    $shh= mkdir -ea 0 $modulesDir 

    # First install the modules locally
    save-module az -path $modulesDir -Repository $repository

    if ($version -eq "0")
    {
        $version = (Get-ChildItem -Path $modulesDir\Az).Name
    }

    Write-Host -fore green "Tweaking Modules"
    cmd /c dir /a/s/b "$modulesDir\psgetmoduleinfo.xml" |% {
        Write-Host -fore Gray " - Patching $_"
        (gc $_ -raw ) -replace ".*<S N=.InstalledLocation.*S>",""  | Set-Content $_
        (gc $_ -raw ) -replace ".*<S N=.RepositorySourceLocation`".*S>",'<S N="RepositorySourceLocation">https://www.powershellgallery.com/api/v2/</S>'  | Set-Content $_
        (gc $_ -raw ) -replace ".*<S N=.Repository`".*S>",'<S N="Repository">PSGallery</S>'  | Set-Content $_
    }
}

# the build number is the number of commits in this branch. 
if( -not $noBuildNumber ) {
    # useful for an ever-increasing number that can be tracked to a commit.
    $buildNumber = git rev-list --parents HEAD --count --full-history

    # tack the build number onto the version
    if ($buildNumber -ne $null)
    {
        $version = "$version.$buildNumber"
    }
}

# prepare include files 
$archs |% {
    $arch = $_
    $includeFile = "$tmp\azurecmdfiles-$arch.wxi"
    erase -ea 0 $includeFile
    Write-Host -fore green "Generating '$includeFile' include file"
    heat dir $modulesDir -out $includeFile -srd -sfrag -sreg -ag -g1 -cg "azurecmdfiles$arch" -dr "Modules$arch" -var var.modulesDir -indent 2 -nologo 
    if( $LASTEXITCODE) {
        write-host -fore red "Failed to generate include file."
        break;
    }

    Write-Host -fore gray " - Fixing include file."
    (gc $includeFile).replace('<Wix', '<Include') | Set-Content $includeFile
    (gc $includeFile).replace('</Wix' ,'</Include') | Set-Content $includeFile
    (gc $includeFile).replace('PSGetModuleInfo.xml" />' ,'PSGetModuleInfo.xml" Hidden="yes" />') | Set-Content $includeFile
}
if( $LASTEXITCODE) {
    # did it fail in the loop?
    return;
}
# make msi files
$archs |% {
    $arch = $_
    Write-Host -fore green "Compiling Wix Script for $arch"  
    $out = candle -arch $arch -ext WixUIExtension "-dversion=$version" -sw1118 -nologo "-I$tmp" "-dtmp=$tmp" "-dmodulesDir=$modulesDir" "-dproductName=$productName" $scriptLocation\azurecmd.wxs -out "$tmp\$outputName-$version-$arch.wixobj"
    if( $LASTEXITCODE) {
        write-host -fore red "Failed to compile WiX Script for $arch"
        write-host -fore red $out        
        break;
    }

    Write-Host -fore green "Creating installer for $arch"
    $out = light "$tmp\$outputName-$version-$arch.wixobj" -ext WixUIExtension -out "$scriptLocation\$outputName-$version-$arch.msi" -sw1076 -sice:ICE80  -nologo -b $scriptLocation
    if( $LASTEXITCODE) {
        write-host -fore red "ERROR: Failed to link MSI for $arch" 
        write-host -fore red $out
        break;
    }

    write-host -fore cyan "Installer Created: $scriptLocation\$outputName-$version-$arch.msi"
}
if( $LASTEXITCODE) {
    # did it fail in the loop?
    return;
}
# clean-up tmp folder
erase -ea 0 "$tmp/*.wixpdb"
erase -ea 0 "$tmp/*.wixobj"
