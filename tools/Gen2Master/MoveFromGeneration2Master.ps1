Function Move-Generation2Master {
    Param(
        [string]
        ${SourcePath},
        [string]
        ${DestPath}
    )

    process {
        $ModuleName = ($SourcePath.Trim("\").Split("\"))[-1]
        If (-not ($DestPath -Match $ModuleName)) {
            $DestPath = Join-Path -Path $DestPath -ChildPath $ModuleName
        }
        If (-not (Test-Path $DestPath)) {
            New-Item -ItemType Directory -Path $DestPath
        }
        $Dir2Copy = @('custom', 'examples', 'exports', 'generated', 'internal', 'test')
        Foreach($Dir in $Dir2Copy) {
            $SourceItem = Join-Path -Path $SourcePath -ChildPath $Dir
            $DestItem = Join-Path -Path $DestPath -ChildPath $Dir
            If (Test-Path $DestItem) {
                Remove-Item -Path $DestItem -Recurse
            }
            Write-Host "Copying folder: $SourceItem." -ForegroundColor Yellow
            Copy-Item -Recurse -Path $SourceItem -Destination $DestItem
        }
        #Region Clean Local Modules
        $LocalModulesPath = Join-Path -Path (Join-Path -Path $DestPath -ChildPath 'generated') -ChildPath 'modules'
        If (Test-Path $LocalModulesPath) {
            Write-Host "Removing local modules: $LocalModulesPath." -ForegroundColor Yellow
            Remove-Item -Path $LocalModulesPath -Recurse
        }
        #EndRegion
        #Region copy docs
        $SourceItem = Join-Path -Path $SourcePath -ChildPath 'docs'
        $DestItem = Join-Path -Path $DestPath -ChildPath 'help'
        If (Test-Path $DestItem) {
            Remove-Item -Path $DestItem -Recurse
        }
        Write-Host "Copying docs: $SourceItem." -ForegroundColor Yellow
        Copy-Item -Recurse -Path $SourceItem -Destination $DestItem
        #EndRegion
        $File2Copy = @('*.ps1', 'how-to.md', 'readme.md', '*.psm1', '*.ps1xml', 'MSSharedLibKey.snk')
        Foreach($File in $File2Copy) {
            $SourceItem = Join-Path -Path $SourcePath -ChildPath $File
            $DestItem = Join-Path -Path $DestPath -ChildPath $File
            If (Test-Path $DestItem) {
                Remove-Item -Path $DestItem
            }
            Write-Host "Copying file: $SourceItem" -ForegroundColor Yellow
            Copy-Item -Path $SourceItem -Destination $DestPath
        }

        #Region verify psd1 file
        Write-Host "Copying Az.$ModuleName.psd1." -ForegroundColor Yellow
        $ModuleGuid = $Null
        $RequiredModule = $Null
        $DestPsd1Path = Join-Path -Path $DestPath -ChildPath "Az.$ModuleName.psd1"
        $SourcePsd1Path = Join-Path -Path $SourcePath -ChildPath "Az.$ModuleName.psd1"
        If (Test-Path $DestPsd1Path) {
            $Psd1Metadata = Import-LocalizedData -BaseDirectory $DestPath -FileName "Az.$ModuleName.psd1"
            $ModuleGuid = $Psd1Metadata.GUID
            $RequiredModule = $Psd1Metadata.RequiredModules
        }
        $Psd1Metadata = Import-LocalizedData -BaseDirectory $SourcePath -FileName "Az.$ModuleName.psd1"
        If ($Null -ne $ModuleGuid) {
            $Psd1Metadata.GUID = $ModuleGuid
        }
        If ($Null -ne $RequiredModule) {
            $Psd1Metadata.RequiredModules = $RequiredModule
        }
        If ($Psd1Metadata.FunctionsToExport -Contains "*") {
            $Psd1Metadata.FunctionsToExport = ($Psd1Metadata.FunctionsToExport | Where-Object {$_ -ne "*"})
        }
        Update-ModuleManifest -Path (Join-Path -Path $SourcePath -ChildPath "Az.$ModuleName.psd1") @Psd1Metadata
        Copy-Item -Path $SourcePsd1Path -Destination $DestPsd1Path
        #EndRegion

        #Region Remove unnecessary readme.md
        $ReadmeInHelp = Join-Path -Path (Join-Path -Path $DestPath -ChildPath 'help') -ChildPath 'readme.md'
        $ModuleReadmeInHelp = Join-Path -Path (Join-Path -Path $DestPath -ChildPath 'help') -ChildPath "Az.$ModuleName.md"
        If (Test-Path $ReadmeInHelp) {
            Write-Host "Deleting file $ReadmeInHelp." -ForegroundColor Yellow
            Remove-Item -Path $ReadmeInHelp
        }
        If ($Null -ne $ModuleGuid) {
            $ReadmeContent = Get-Content -Path $ModuleReadmeInHelp
            $ReadmeContent -replace "Module Guid: [0-9a-z\-]+","Module Guid: $ModuleGuid" | Set-Content -Path $ModuleReadmeInHelp
        }
        $ReadmeInExample = Join-Path -Path (Join-Path -Path $DestPath -ChildPath 'examples') -ChildPath 'readme.md'
        If (Test-Path $ReadmeInExample) {
            Remove-Item -Path $ReadmeInExample
        }
        #EndRegion

        #Region update azure-powershell-modules.md
        
        #EndRegion

        Copy-Template -SourceName Az.ModuleName.csproj -DestPath $DestPath -DestName "Az.$ModuleName.csproj"
        Copy-Template -SourceName Changelog.md -DestPath $DestPath -DestName Changelog.md
        Copy-Template -SourceName ModuleName.sln -DestPath $DestPath -DestName "$ModuleName.sln"

        $PropertiesPath = Join-Path -Path $DestPath -ChildPath "Properties"
        If (-not (Test-Path $PropertiesPath)) {
            New-Item -ItemType Directory -Path $PropertiesPath
        }
        Copy-Template -SourceName AssemblyInfo.cs -DestPath $PropertiesPath -DestName AssemblyInfo.cs
        Update-MappingJson -ModuleName $ModuleName
    }
}

Function Update-MappingJson {
    Param(
        [string]
        ${ModuleName}
    )
    process {
        Write-Host "Updating MappingJson: CreateMappings_rules.json." -ForegroundColor Yellow
        $MappingPath = Join-Path -Path (Join-Path -Path $PSScriptRoot -ChildPath '..') -ChildPath "CreateMappings_rules.json"
        $MappingObject = Get-Content -Path $MappingPath | ConvertFrom-Json
        Foreach ($Item in $MappingObject) {
            If ($ModuleName -eq $Item.regex) {
                return
            }
        }
        $MappingObject = $MappingObject + @{regex=$ModuleName; alias=$ModuleName}
        ConvertTo-Json $MappingObject -Depth 1 | Set-Content -Path $MappingPath
    }
}

Function Copy-Template {
    Param(
        [string]
        $SourceName,
        [string]
        $DestPath,
        [string]
        $DestName
    )
    process {
        $DestPath = Join-Path -Path $DestPath -ChildPath $DestName
        If (-not (Test-Path -Path $DestPath)) {
            Write-Host "Copying template: $SourceName." -ForegroundColor Yellow
            New-Item -Path $DestPath
            $TemplatePath = Join-Path -Path (Join-Path -Path $PSScriptRoot -ChildPath "Templates") -ChildPath $SourceName
            $TemplateContent = Get-Content -Path $TemplatePath
            If ($TemplateContent -Match "{GUID}") {
                $TemplateContent = $TemplateContent -replace '{GUID}',(New-Guid).Guid
            }
            $TemplateContent -replace '{ModuleNamePlaceHolder}',$ModuleName | Set-Content -Path $DestPath
        }
    }
}
