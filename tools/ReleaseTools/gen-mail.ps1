param (
    [Parameter(Mandatory = $true)]
    [ValidateSet('RC1','RC2','RC3','Publish')]
    [System.String]$Phase,

    [Parameter(Mandatory = $true)]
    [System.String]$ReleaseBranch,

    [Parameter()]
    [System.String]$OutFilePath = "mail.md",

    [Parameter(Mandatory = $true)]
    [System.String]$StorageResourceGroup,

    [Parameter(Mandatory = $true)]
    [System.String]$StorageAccountName,

    [Parameter(Mandatory = $true)]
    [System.String]$StorageContianerName,
)

function GetCommitNumber
{
    param(
        [Parameter(Mandatory = $true)]
        [AllowEmptyString()]
        [System.String]$pkgName
    )
    if(-not $pkgName){
        return 0
    }
    $elements = $pkgName -split {$_ -eq "." -or $_ -eq "-"}
    [int]$commitNum = [int]$elements[-3]

    return $commitNum
}

if ($Phase -ne 'Pulish')
{
    Write-Host "Generating $Phase email"

    # Changelog
    $changelog = Invoke-WebRequest -Uri https://raw.githubusercontent.com/Azure/azure-powershell/internal/release/ChangeLog.md 
    $changelog = [regex]::split($changelog, "##\s\d+\.\d+\.\d+\s-\s\w+\s\d{4}")[1] -replace '^\s*\n|\n\s*$', ''

    ## TODO: add thanks list

    # Get bumped version and previous version
    # Calculate 1st GA modules and preview modules
    $BumpedAzPreviewOutFile = "AzPreview_bumped.psd1"
    $PreviousAzPreviewOutFile = "AzPreview_previous.psd1"
    Invoke-WebRequest -Uri https://raw.githubusercontent.com/Azure/azure-powershell/internal/release/tools/AzPreview/AzPreview.psd1 -OutFile AzPreview_bumped.psd1 
    $BumpedModuleInfos = Import-PowerShellDataFile -Path $BumpedAzPreviewOutFile
    Invoke-WebRequest -Uri https://raw.githubusercontent.com/Azure/azure-powershell/$ReleaseBranch/tools/AzPreview/AzPreview.psd1 -OutFile AzPreview_previous.psd1 
    $PreviousModuleInfos = Import-PowerShellDataFile -Path $PreviousAzPreviewOutFile
    
    $AzVersion = $BumpedModuleInfos.ModuleVersion

    # Get link from storage account
    $storageContext = (Get-AzStorageAccount -Name $StorageAccountName -ResourceGroupName $StorageResourceGroup).Context
    # $null = Set-AzCurrentStorageAccount -context $storageContext.Context
    $PkgList = Get-AzStorageBlob -Container $StorageContianerName -blob Az-Cmdlets-$AzVersion* -Context $storageContext.Context
    $x64Msi = ""
    $x86Msi = ""
    $previewZip = ""
    $tarGz = ""
    foreach($pkg in $PkgList){
        $commitNum = GetCommitNumber $pkg.Name
        if ($pkg.Name.EndsWith("x64.msi")){
            if ($commitNum -gt (GetCommitNumber $x64Msi)){
                $x64Msi = $pkg.Name
            }
        }
        elseif ($pkg.Name.EndsWith("x86.msi")){
            if ($commitNum -gt (GetCommitNumber $x86Msi)){
                $x86Msi = $pkg.Name
            }
        }
        elseif ($pkg.Name.EndsWith("preview.zip")){
            if ($commitNum -gt (GetCommitNumber $previewZip)){
                $previewZip = $pkg.Name
            }
        }
        elseif ($pkg.Name.EndsWith("tar.gz")){
            if ($commitNum -gt (GetCommitNumber $tarGz)){
                $tarGz = $pkg.Name
            }
        }
    }

    # Changelog
    $changelog = Invoke-WebRequest -Uri https://raw.githubusercontent.com/Azure/azure-powershell/internal/release/ChangeLog.md 
    $changelog = [regex]::split($changelog, "##\s\d+\.\d+\.\d+\s-\s\w+\s\d{4}")[1] -replace '^\s*\n|\n\s*$', ''

    ## TODO: add thanks list

    # Get bumped version and previous version
    # Calculate 1st GA modules and preview modules
    $BumpedAzPreviewOutFile = "AzPreview_bumped.psd1"
    $PreviousAzPreviewOutFile = "AzPreview_previous.psd1"
    Invoke-WebRequest -Uri https://raw.githubusercontent.com/Azure/azure-powershell/internal/release/tools/AzPreview/AzPreview.psd1 -OutFile AzPreview_bumped.psd1 
    $BumpedModuleInfos = Import-PowerShellDataFile -Path $BumpedAzPreviewOutFile
    Invoke-WebRequest -Uri https://raw.githubusercontent.com/Azure/azure-powershell/main/tools/AzPreview/AzPreview.psd1 -OutFile AzPreview_previous.psd1 
    $PreviousModuleInfos = Import-PowerShellDataFile -Path $PreviousAzPreviewOutFile
    
    $BumpedModuleInfos = $BumpedModuleInfos.RequiredModules
    $PreviousModuleInfos = $PreviousModuleInfos.RequiredModules
    $1stGAModules = @()
    $previewModules = @()

    foreach($m in $BumpedModuleInfos){
        # Write-Host $m.moduleName
        
        if (($m.moduleName -in $PreviousModuleInfos.ModuleName)){
            $previousModule = $PreviousModuleInfos | Where-Object {$_.ModuleName -eq $m.ModuleName}
            $previousVersion = $previousModule.RequiredVersion
            # GA modules
            if (($previousVersion -ne $m.RequiredVersion) -and ($m.RequiredVersion -eq "1.0.0")){
                if(-not $1stGAModules.count -gt 0){
                    $1stGAModules += "Modules out of preview and now generally available as part of Az: ` "
                }
                $1stGAModules += "* $($m.moduleName)"
            }

            if (($previousVersion -ne $m.RequiredVersion) -and ($m.RequiredVersion.StartsWith("0."))){
                if(-not $previewModules.count -gt 0){
                    $previewModules += "Modules under preview (the following modules must be installed separately): ` “
                }
                $previewModules += "* $($m.moduleName) $($m.RequiredVersion) ` "
            } 
            
        }
        else{
            Write-Host $m.moduleName preview2
            if(-not $previewModules.count -gt 0){
                $previewModules += "Modules under preview (the following modules must be installed separately): ` “
            }
            $previewModules += "* $($m.moduleName) $($m.RequiredVersion) ` "
        }
        
    }

    if($Phase.StartsWith("RC")){
        $RCNum = $Phase -replace "RC", ""
    }
    
    $template = "Az $AzVersion - Release Candidate $RCNum Now Available ` ` 
Hi everyone, `
`
**The release candidate $RCNum for Az $AzVersion** is now available for testing: `
`
* [$x64Msi](https://azpspackage.blob.core.windows.net/release/$x64Msi) `
* [$x86Msi](https://azpspackage.blob.core.windows.net/release/$x86Msi) `
* [$tarGz](https://azpspackage.blob.core.windows.net/release/$tarGz) `
`
If you want to install module by compressed package, please run ``./InstallModule.ps1 -ModuleName Az.{ModuleName}`` after decompressing the package. If you have any questions or find any issues, please little ‘r’ the azdevxps alias. Thanks! `
`
If no issue is reported, this release will be considered as final release candidate and published to PSGallery. `
`
### Release Notes
$changelog
$($1stGAModules | Out-String)
$($previewModules | Out-String)
The preview modules (whose versions are lower than 1.0.0) are available as below: `
* [$previewZip](https://azpspackage.blob.core.windows.net/release/$previewZip)  `
`
Known issues: `
* {any} `
`
Thanks,`
<Name>"

    if(-not $1stGAModules.count -gt 0){
        Write-Host No 1st GA
        $null = $template -replace "Modules out of preview and now generally available as part of Az:", ""
    }
    if(-not $previewModules.count -gt 0){
        Write-Host No preview updates
        $null = $template.replace("Modules under preview (the following modules mut be installed separately):", "")
    }

    $template | Out-File -FilePath $OutFilePath
    Write-Host "Email generated under $OutFilePath, please do not forget to replace your <name> and pay attention to Known issues session."
    # Cleanup
    Remove-Item $BumpedAzPreviewOutFile
    Remove-Item $PreviousAzPreviewOutFile
}
else{
    Write-Host "#TODO: Publish email"
}
