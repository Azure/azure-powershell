# To version all modules in Az (standard release), run the following command: .\RunVersionController.ps1 -Release "December 2017"
# To version a single module (one-off release), run the following command: .\RunVersionController.ps1 -ModuleName "Az.Compute"

#Requires -Modules @{ModuleName="PowerShellGet"; ModuleVersion="2.2.1"}

[CmdletBinding(DefaultParameterSetName="ReleaseAz")]
Param(
    [Parameter(ParameterSetName='ReleaseAz', Mandatory = $true)]
    [string]$Release,

    [Parameter(ParameterSetName='ReleaseAzByMonthAndYear', Mandatory = $true)]
    [string]$MonthName,

    [Parameter(ParameterSetName='ReleaseAzByMonthAndYear', Mandatory = $true)]
    [string]$Year,

    [Parameter(ParameterSetName='ReleaseSingleModule', Mandatory = $true)]
    [string]$ModuleName,

    [Parameter()]
    [string]$GalleryName = "PSGallery",

    [Parameter()]
    [string]$ArtifactsOutputPath = "$PSScriptRoot/../artifacts/Release/"
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

    $AzurecmdFile = Get-Item -Path "$RootPath\setup\generate.ps1"
    (Get-Content $AzurecmdFile.FullName) | % {
        $_ -replace "Microsoft Azure PowerShell - (\w*)(\s)(\d*)", "Microsoft Azure PowerShell - $Release"
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

function Get-ModuleMetadata
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$Module,
        [Parameter(Mandatory = $true)]
        [string]$RootPath
    )

    $ProjectPaths = @( "$RootPath\src" )

    .($PSScriptRoot + "\PreloadToolDll.ps1")
    $ModuleManifestFile = $ProjectPaths | % { Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | where { $_.Name.Replace(".psd1", "") -eq $Module -and `
    # Skip psd1 of generated modules in HYBRID modules because they are not really used
    # This is based on an assumption that the path of the REAL psd1 of a HYBRID module should always not contain "Autorest"
                                                                                                          $_.FullName -inotlike "*autorest*" -and `
                                                                                                          $_.FullName -notlike "*Debug*" -and `
                                                                                                          $_.FullName -notlike "*Netcore*" -and `
                                                                                                          $_.FullName -notlike "*dll-Help.psd1*" -and `
                                                                                                          (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) } }

    if($ModuleManifestFile.Count -gt 1)
    {
        $ModuleManifestFile = $ModuleManifestFile[0]
    }
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $ModuleManifestFile.DirectoryName -FileName $ModuleManifestFile.Name
    return $ModuleMetadata
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

function Update-Image-Releases
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$ReleaseProps,
        [Parameter(Mandatory = $true)]
        [string]$AzVersion
    )

    $content = Get-Content $ReleaseProps
    $content -Replace "az.version=\d+\.\d+\.\d+", "az.version=$AzVersion" | Set-Content $ReleaseProps
}

function Get-ExistSerializedCmdletJsonFile
{
    return $(ls "$PSScriptRoot\Tools.Common\SerializedCmdlets").Name
}

function Bump-AzVersion
{
    Write-Host "Getting local Az information..." -ForegroundColor Yellow
    $localAz = Import-PowerShellDataFile -Path "$PSScriptRoot\Az\Az.psd1"

    Write-Host "Getting gallery Az information..." -ForegroundColor Yellow
    $galleryAz = Find-Module -Name Az -Repository $GalleryName

    $versionBump = [PSVersion]::NONE
    $updatedModules = @()
    foreach ($localDependency in $localAz.RequiredModules)
    {
        $galleryDependency = $galleryAz.Dependencies | where { $_.Name -eq $localDependency.ModuleName }
        if ($null -eq $galleryDependency)
        {
            $updatedModules += $localDependency.ModuleName
            if ($versionBump -ne [PSVersion]::MAJOR)
            {
                $versionBump = [PSVersion]::MINOR
            }
            Write-Host "Found new added module $($localDependency.ModuleName)"
            continue
        }

        $galleryVersion = $galleryDependency.RequiredVersion
        if ([string]::IsNullOrEmpty($galleryVersion))
        {
            $galleryVersion = $galleryDependency.MinimumVersion
        }

        $localVersion = $localDependency.RequiredVersion
        # Az.Accounts uses ModuleVersion to annote Version
        if ([string]::IsNullOrEmpty($localVersion))
        {
            $localVersion = $localDependency.ModuleVersion
        }

        if ($galleryVersion.ToString() -ne $localVersion)
        {
            $updatedModules += $localDependency.ModuleName
            $currBump = Get-VersionBump -GalleryVersion $galleryVersion.ToString() -LocalVersion $localVersion
            Write-Host "Found $currBump version bump for $($localDependency.ModuleName)"
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

    $newVersion = Get-BumpedVersion -Version $localAz.ModuleVersion -VersionBump $versionBump

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
        $moduleMetadata = $(Get-ModuleMetadata -Module $updatedModule -RootPath $rootPath)
        $moduleReleaseNotes = $moduleMetadata.PrivateData.PSData.ReleaseNotes
        $releaseNotes += $updatedModule
        $releaseNotes += $moduleReleaseNotes + "`n"

        $changeLog += "#### $updatedModule $($moduleMetadata.ModuleVersion)"
        $changeLog += $moduleReleaseNotes + "`n"
    }

    $resolvedArtifactsOutputPath = (Resolve-Path $ArtifactsOutputPath).Path
    if(!(Test-Path $resolvedArtifactsOutputPath))
    {
        throw "Please check artifacts output path: $resolvedArtifactsOutputPath whether exists."
    }

    # Update-ModuleManifest requires all required modules in Az.psd1 installed in local
    # Add artifacts as PSModulePath to skip installation
    if(!($env:PSModulePath.Split(";").Contains($resolvedArtifactsOutputPath)))
    {
        $env:PSModulePath += ";$resolvedArtifactsOutputPath"
    }

    Update-ModuleManifest -Path "$PSScriptRoot\Az\Az.psd1" -ModuleVersion $newVersion -ReleaseNotes $releaseNotes
    Update-ChangeLog -Content $changeLog -RootPath $rootPath

    New-CommandMappingFile

    return $versionBump
}

function Update-AzPreview
{
    # The version of AzPrview aligns with Az
    $AzPrviewVersion = (Import-PowerShellDataFile "$PSScriptRoot\Az\Az.psd1").ModuleVersion

    $requiredModulesString = "RequiredModules = @("
    $rawRequiredModulesString = "RequiredModules = @\("
    foreach ($Psd1FilePath in (Get-Psd1Path)) {
        $Psd1Object = Import-PowerShellDataFile $Psd1FilePath
        $moduleName = [System.IO.Path]::GetFileName($Psd1FilePath) -replace ".psd1"
        $moduleVersion = $Psd1Object.ModuleVersion.ToString()
        if('Az.Accounts' -eq $moduleName)
        {
            $requiredModulesString += "@{ModuleName = '$moduleName'; ModuleVersion = '$moduleVersion'; }, `n            "
        }
        else
        {
            $requiredModulesString += "@{ModuleName = '$moduleName'; RequiredVersion = '$moduleVersion'; }, `n            "
        }
    }
    $requiredModulesString = $requiredModulesString.Trim()
    $requiredModulesString = $requiredModulesString.TrimEnd(",")

    $AzPrviewTemplate = Get-Item -Path "$PSScriptRoot\AzPreview.psd1.template"
    $AzPrviewTemplateContent = Get-Content -Path $AzPrviewTemplate.FullName
    $AzPreviewPsd1Content = $AzPrviewTemplateContent | % {
        $_ -replace "ModuleVersion = 'x.x.x'", "ModuleVersion = '$AzPrviewVersion'"
    } | % {
        $_ -replace "$rawRequiredModulesString", "$requiredModulesString"
    }

    $AzPrviewPsd1 = New-Item -Path "$PSScriptRoot\AzPreview\" -Name "AzPreview.psd1" -ItemType "file" -Force
    Set-Content -Path $AzPrviewPsd1.FullName -Value $AzPreviewPsd1Content -Encoding UTF8

    $localAz = Import-PowerShellDataFile -Path "$PSScriptRoot\AzPreview\AzPreview.psd1"

    Write-Host "Getting gallery AzPreview information..." -ForegroundColor Yellow
    $galleryAz = Find-Module -Name AzPreview -Repository $GalleryName
    $updatedModules = @()
    foreach ($localDependency in $localAz.RequiredModules)
    {
        $galleryDependency = $galleryAz.Dependencies | where { $_.Name -eq $localDependency.ModuleName }
        if ($null -eq $galleryDependency)
        {
            $updatedModules += $localDependency.ModuleName
            Write-Host "Found new added module $($localDependency.ModuleName)"
            continue
        }

        $galleryVersion = $galleryDependency.RequiredVersion
        if ([string]::IsNullOrEmpty($galleryVersion))
        {
            $galleryVersion = $galleryDependency.MinimumVersion
        }

        $localVersion = $localDependency.RequiredVersion
        # Az.Accounts uses ModuleVersion to annote Version
        if ([string]::IsNullOrEmpty($localVersion))
        {
            $localVersion = $localDependency.ModuleVersion
        }

        if ($galleryVersion.ToString() -ne $localVersion)
        {
            $updatedModules += $localDependency.ModuleName
        }
    }

    $releaseNotes = @()
    $releaseNotes += "$AzPrviewVersion - $Release"
    $changeLog = @()
    $changeLog += "## $AzPrviewVersion - $Release"
    $rootPath = "$PSScriptRoot\.."
    foreach ($updatedModule in $updatedModules)
    {
        $moduleMetadata = $(Get-ModuleMetadata -Module $updatedModule -RootPath $rootPath)
        if ($moduleMetadata.ModuleVersion -eq '0.1.0') {
            $moduleReleaseNotes = "* First preview release for module $updatedModule"
        } else {
            $moduleReleaseNotes = $moduleMetadata.PrivateData.PSData.ReleaseNotes
        }
        $releaseNotes += $updatedModule
        $releaseNotes += $moduleReleaseNotes + "`n"

        $changeLog += "#### $updatedModule $($moduleMetadata.ModuleVersion)"
        $changeLog += $moduleReleaseNotes + "`n"
    }
    Update-ChangeLog -Content $changeLog -RootPath $rootPath/tools/AzPreview

}

function New-CommandMappingFile
{
    # Regenerate the cmdlet-to-module mappings for the recommendation feature of uninstalled modules
    $MappingsFilePath = "$PSScriptRoot\..\src\Accounts\Accounts\Utilities\CommandMappings.json"
    Write-Host "Generating command mapping file at $MappingsFilePath"
    $content = Get-Content $MappingsFilePath | ConvertFrom-Json -Depth 10
    $content.modules = [ordered]@{}

    foreach ($Psd1FilePath in (Get-Psd1Path))
    {
        $Psd1Object = Import-PowerShellDataFile $Psd1FilePath
        $moduleName = [System.IO.Path]::GetFileName($Psd1FilePath) -replace ".psd1"
        $moduleObject = [ordered]@{}
        $Psd1Object.CmdletsToExport | Where-Object {$null -ne $_ -and "*" -ne $_} | ForEach-Object {
            $moduleObject[$_] = @{}
        }
        $Psd1Object.FunctionsToExport | Where-Object {$null -ne $_ -and "*" -ne $_} | ForEach-Object {
            $moduleObject[$_] = @{}
        }
        $Psd1Object.AliasesToExport | Where-Object {$null -ne $_ -and "*" -ne $_}| ForEach-Object {
            $moduleObject[$_] = @{}
        }
        if ($moduleObject.Count -gt 0) {
            $content.modules[$moduleName] = $moduleObject
        }
    }

    Set-Content -Path $MappingsFilePath -Value ($content | ConvertTo-Json -Depth 10) -Encoding UTF8
    Write-Host "Done generating command mapping file"
}

function Get-Psd1Path {
    $paths = @()
    $SrcPath = Join-Path -Path $PSScriptRoot -ChildPath "..\src"
    foreach ($DirName in $(Get-ChildItem $SrcPath -Directory).Name)
    {
        $ModulePath = $(Join-Path -Path $SrcPath -ChildPath $DirName)
        $Psd1FileName = "Az.{0}.psd1" -f $DirName
        $Psd1FilePath = Get-ChildItem $ModulePath -Depth 2 -Recurse -Filter $Psd1FileName | Where-Object {
            # Skip psd1 of generated modules in HYBRID modules because they are not really used
            # This is based on an assumption that the path of the REAL psd1 of a HYBRID module should always not contain "Autorest"
            $_.FullName -inotlike "*autorest*"
        }
        if ($null -ne $Psd1FilePath)
        {
            if($Psd1FilePath.Count -gt 1)
            {
                $Psd1FilePath = $Psd1FilePath[0]
            }
            $paths += $Psd1FilePath
        }
    }
    return $paths
}

switch ($PSCmdlet.ParameterSetName)
{
    "ReleaseSingleModule"
    {
        Write-Host executing dotnet $PSScriptRoot/../artifacts/VersionController/VersionController.Netcore.dll $PSScriptRoot/../artifacts/VersionController/Exceptions $ModuleName
        dotnet $PSScriptRoot/../artifacts/VersionController/VersionController.Netcore.dll $PSScriptRoot/../artifacts/VersionController/Exceptions $ModuleName
    }

    "ReleaseAzByMonthAndYear"
    {
        $Release = "$MonthName $Year"
    }

    {$PSItem.StartsWith("ReleaseAz")}
    {
        # clean the unnecessary SerializedCmdlets json file
        $ExistSerializedCmdletJsonFile = Get-ExistSerializedCmdletJsonFile
        $ExpectJsonHashSet = @{}
        $SrcPath = Join-Path -Path $PSScriptRoot -ChildPath "..\src"
        foreach ($ModuleName in $(Get-ChildItem $SrcPath -Directory).Name)
        {
            $ModulePath = $(Join-Path -Path $SrcPath -ChildPath $ModuleName)
            $Psd1FileName = "Az.{0}.psd1" -f $ModuleName
            $Psd1FilePath = $(Get-ChildItem $ModulePath -Depth 2 -Recurse -Filter $Psd1FileName)
            if ($null -ne $Psd1FilePath)
            {
                $Psd1Object = Import-PowerShellDataFile $Psd1FilePath
                if ($Psd1Object.ModuleVersion -ge "1.0.0")
                {
                    $ExpectJsonHashSet.Add("Az.${ModuleName}.json", $true)
                }
            }
        }
        foreach ($JsonFile in $ExistSerializedCmdletJsonFile)
        {
            $ModuleName = $JsonFile.Replace('.json', '')
            if (!$ExpectJsonHashSet.Contains($JsonFile))
            {
                Write-Host "Module ${ModuleName} is not GA yet. The json file: ${JsonFile} is for reference"
            }
        }

        Write-Host executing dotnet $PSScriptRoot/../artifacts/VersionController/VersionController.Netcore.dll
        dotnet $PSScriptRoot/../artifacts/VersionController/VersionController.Netcore.dll

        $versionBump = Bump-AzVersion
        # Each release needs to update AzPreview.psd1 and dotnet csv
        # Refresh AzPreview.psd1
        Update-AzPreview
        # We need to generate the upcoming-breaking-changes.md after the process of bump version in minor release
        if ([PSVersion]::MINOR -Eq $versionBump)
        {
            Import-Module $PSScriptRoot/BreakingChanges/GetUpcomingBreakingChange.ps1
            Export-AllBreakingChangeMessageUnderArtifacts -ArtifactsPath $PSScriptRoot/../artifacts/Release/ -MarkdownPath $PSScriptRoot/../documentation/breaking-changes/upcoming-breaking-changes.md
        }
    }
}

# Generate dotnet csv
&$PSScriptRoot/Docs/GenerateDotNetCsv.ps1 -FeedPsd1FullPath "$PSScriptRoot\AzPreview\AzPreview.psd1"
