# To version all modules in Az (standard release), run the following command: .\RunVersionController.ps1 -Release "December 2017"
# To version a single module (one-off release), run the following command: .\RunVersionController.ps1 -ModuleName "Az.Compute"
[CmdletBinding()]
Param(
    [Parameter(ParameterSetName='ReleaseAz', Mandatory = $true)]
    [string]$Release,

    [Parameter(ParameterSetName='ReleaseSingleModule', Mandatory = $true)]
    [string]$ModuleName
)

enum PSVersion
{
    NONE = 0
    PATCH = 1
    MINOR = 2
    MAJOR = 3
}

function Get-VersionBump
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$GalleryVersion,
        [Parameter(Mandatory = $true)]
        [string]$LocalVersion
    )

    $gallerySplit = $GalleryVersion.Split('.')
    $localSplit = $LocalVersion.Split('.')

    if ($gallerySplit[0] -ne $localSplit[0])
    {
        return [PSVersion]::MAJOR
    }
    elseif ($gallerySplit[1] -ne $localSplit[1])
    {
        return [PSVersion]::MINOR
    }
    elseif ($gallerySplit[2] -ne $localSplit[2])
    {
        return [PSVersion]::PATCH
    }

    return [PSVersion]::NONE
}

function Get-BumpedVersion
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$Version,
        [Parameter(Mandatory = $true)]
        [PSVersion]$VersionBump
    )

    $versionSplit = $Version.Split('.')
    if ($VersionBump -eq [PSVersion]::MAJOR)
    {
        $versionSplit[0] = 1 + $versionSplit[0]
        $versionSplit[1] = "0"
        $versionSplit[2] = "0"
    }
    elseif ($VersionBump -eq [PSVersion]::MINOR)
    {
        $versionSplit[1] = 1 + $versionSplit[1]
        $versionSplit[2] = "0"
    }
    elseif ($VersionBump -eq [PSVersion]::PATCH)
    {
        $versionSplit[2] = 1 + $versionSplit[2]
    }

    return $versionSplit -join "."
}

function Update-AzurecmdFile
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$OldVersion,
        [Parameter(Mandatory = $true)]
        [string]$NewVersion,
        [Parameter(Mandatory = $true)]
        [string]$Release,
        [Parameter(Mandatory = $true)]
        [string]$RootPath
    )

    $AzurecmdFile = Get-Item -Path "$RootPath\setup\azurecmd.wxs"
    (Get-Content $AzurecmdFile.FullName) | % {
        $_ -replace "Microsoft Azure PowerShell - (\w*)(\s)(\w*)", "Microsoft Azure PowerShell - $Release"
    } | Set-Content -Path $AzurecmdFile.FullName -Encoding UTF8

    (Get-Content $AzurecmdFile.FullName) | % {
        $_ -replace "$OldVersion", "$NewVersion"
    } | Set-Content -Path $AzurecmdFile.FullName -Encoding UTF8
}

function Update-AzurePowerShellFile
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$OldVersion,
        [Parameter(Mandatory = $true)]
        [string]$NewVersion,
        [Parameter(Mandatory = $true)]
        [string]$RootPath
    )

    $AzurePowerShellFile = Get-Item -Path "$RootPath\src\Common\Commands.Common\AzurePowerShell.cs"
    (Get-Content $AzurePowerShellFile.FullName) | % {
        $_ -replace "$OldVersion", "$NewVersion"
    } | Set-Content -Path $AzurePowerShellFile.FullName -Encoding UTF8
}

function Get-ReleaseNotes
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$Module,
        [Parameter(Mandatory = $true)]
        [string]$RootPath
    )

    $ProjectPaths = @( "$RootPath\src" )
    $ModuleManifestFile = $ProjectPaths | % { Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | where { $_.Name.Replace(".psd1", "") -eq $Module -and `
                                                                                                          $_.FullName -notlike "*Debug*" -and `
                                                                                                          $_.FullName -notlike "*Netcore*" -and `
                                                                                                          $_.FullName -notlike "*dll-Help.psd1*" -and `
                                                                                                          $_.FullName -notlike "*Stack*" } }

    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $ModuleManifestFile.DirectoryName -FileName $ModuleManifestFile.Name
    return $ModuleMetadata.PrivateData.PSData.ReleaseNotes
}

function Update-ChangeLog
{
    Param(
        [Parameter(Mandatory = $true)]
        [string[]]$Content,
        [Parameter(Mandatory = $true)]
        [string]$RootPath
    )

    $ChangeLogFile = Get-Item -Path "$RootPath\ChangeLog.md"
    $ChangeLogContent = Get-Content -Path $ChangeLogFile.FullName
    ($Content + $ChangeLogContent) | Set-Content -Path $ChangeLogFile.FullName -Encoding UTF8
}

if (!(Test-Path "C:/Program Files/PowerShell/Modules/PowerShellGet"))
{
    try
    {
        Save-Module -Name PowerShellGet -Repository PSGallery -Path "C:/Program Files/PowerShell/Modules" -ErrorAction Stop
    }
    catch
    {
        throw "Please rerun in Administrator mode."
    }
}

switch ($PSCmdlet.ParameterSetName)
{
    "ReleaseSingleModule"
    {
        dotnet $PSScriptRoot/../artifacts/VersionController/VersionController.Netcore.dll $PSScriptRoot/../artifacts/VersionController/Exceptions $ModuleName
    }

    "ReleaseAz"
    {
        try
        {
            Install-Module Az -Repository PSGallery
        }
        catch
        {
            throw "Please rerun in Administrator mode."
        }

        dotnet $PSScriptRoot/../artifacts/VersionController/VersionController.Netcore.dll

        Write-Host "Getting local Az information..." -ForegroundColor Yellow
        $localAz = Test-ModuleManifest -Path "$PSScriptRoot\Az\Az.psd1"

        Write-Host "Getting gallery Az information..." -ForegroundColor Yellow
        $galleryAz = Find-Module -Name Az -Repository PSGallery

        $versionBump = [PSVersion]::NONE
        $updatedModules = @()
        foreach ($galleryDependency in $galleryAz.Dependencies)
        {
            $localDependency = $localAz.RequiredModules | where { $_.Name -eq $galleryDependency.Name }
            if ($localDependency -eq $null)
            {
                Write-Error "Could not find matching dependency for $($galleryDependency.Name)"
            }

            $galleryVersion = $galleryDependency.RequiredVersion
            if ([string]::IsNullOrEmpty($galleryVersion))
            {
                $galleryVersion = $galleryDependency.MinimumVersion
            }
            $localVersion = $localDependency.Version.ToString()
            if ($galleryVersion.ToString() -ne $localVersion)
            {
                $updatedModules += $galleryDependency.Name
                $currBump = Get-VersionBump -GalleryVersion $galleryVersion.ToString() -LocalVersion $localVersion
                Write-Host "Found $currBump version bump for $($localDependency.NAME)"
                if ($currBump -eq [PSVersion]::MAJOR)
                {
                    $versionBump = [PSVersion]::MAJOR
                }
                elseif ($currBump -eq [PSVersion]::MINOR -and $versionBump -ne [PSVersion]::MAJOR)
                {
                    $versionBump = [PSVersion]::MINOR
                }
                elseif ($currBump -eq [PSVersion]::PATCH -and $versionBump -eq [PSVersion]::NONE)
                {
                    $versionBump = [PSVersion]::PATCH
                }
            }
        }

        if ($versionBump -eq [PSVersion]::NONE)
        {
            Write-Host "No changes found in Az." -ForegroundColor Green
            return
        }

        $newVersion = Get-BumpedVersion -Version $localAz.Version -VersionBump $versionBump

        Write-Host "New version of Az: $newVersion" -ForegroundColor Green

        $rootPath = "$PSScriptRoot\.."
        $oldVersion = $galleryAz.Version

        Update-AzurecmdFile -OldVersion $oldVersion -NewVersion $newVersion -Release $Release -RootPath $rootPath

        # This was moved to the common repo
        # Update-AzurePowerShellFile -OldVersion $oldVersion -NewVersion $newVersion -RootPath $rootPath

        $releaseNotes = @()
        $releaseNotes += "$newVersion - $Release"

        $changeLog = @()
        $changeLog += "## $newVersion - $Release"
        foreach ($updatedModule in $updatedModules)
        {
            $releaseNotes += $updatedModule
            $releaseNotes += $(Get-ReleaseNotes -Module $updatedModule -RootPath $rootPath) + "`n"

            $changeLog += "#### $updatedModule"
            $changeLog += $(Get-ReleaseNotes -Module $updatedModule -RootPath $rootPath) + "`n"
        }

        Update-ModuleManifest -Path "$PSScriptRoot\Az\Az.psd1" -ModuleVersion $newVersion -ReleaseNotes $releaseNotes
        Update-ChangeLog -Content $changeLog -RootPath $rootPath
    }
}
