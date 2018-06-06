param(
    [Parameter(Mandatory=$true)]
    $Configuraton)

$ErrorActionPreference = "Stop"
$scriptpath = $MyInvocation.MyCommand.Path
$scriptDirectory = Split-Path $scriptpath
$scriptFileName = Split-Path $scriptpath -Leaf

Import-Module "..\..\..\..\..\..\src\Package\$Configuraton\ResourceManager\AzureResourceManager\AzureRM.StorageSync\AzureRM.StorageSync.psd1" -Verbose

$VerbosePreference='Continue'

function prompt { return "PS> " }

Write-Verbose 'Your debugger is attached to current PowerShell instance'
Write-Verbose 'To recreate a test data set and perform an evaluation run'
Write-Verbose '    Perform-Test -Full'
Write-Verbose 'To perform an evaluation for an already created dataset run'
Write-Verbose '    Perform-Test'

function Get-Configuration
{
    Get-Content -Raw -Path .\config.json | ConvertFrom-Json
}

function Build-CharacterTable
{
    param ($Configuration)

    $blacklistOfCodePoints = $Configuration.BlacklistOfCodePoints
    $whitelistOfCodePointRanges = $Configuration.WhitelistOfCodePointRanges

    $arraySize = 0x10FFFF + 1
    $blacklistedCodePointsTable = new-object bool[] $arraySize
    for ($i = 0; $i -lt $arraySize; $i += 1)
    {
        $blacklistedCodePointsTable[$i] = $blacklistOfCodePoints.Contains($i) -or
                    ($whitelistOfCodePointRanges.Where({ ($_.Start -le $i) -and ($_.End -ge $i) }).Count -eq 0);
    }
    return $blacklistedCodePointsTable
}

function CreateItem
{
    param ($path, $name, $itemType)
    
    $fullpath = Join-Path $path $name

    try
    {
        if (Test-Path $fullpath)
        {
            return
        }

        if (!(Test-Path $path))
        {
            New-Item -Path $path -ItemType Directory | Out-Null
        }
    
        New-Item -Path $path -Name $name -ItemType $itemType | Out-Null
    }
    catch
    {
        throw "Couldn't handle path:$path, name:$name, itemType:$itemType"
    }
}

function CreateItemsWithInvalidCharacters
{
    param ($path, $configuration, $blockedCharactersTable, $itemType)
    
    Write-Verbose "Creating items of type $itemType with invalid characters"
    $skippedCodePoints = 0
    $succeededCodePoints = 0
    for ($i = 0; $i -lt $blockedCharactersTable.Count; $i += 1)
    {
        $isBlocked = $blockedCharactersTable[$i];
        if ($isBlocked)
        {
            $invalid_character_or_surrogate_pair = "<unavailable>"
            try
            {
                $invalid_character_or_surrogate_pair = [char]::ConvertFromUtf32($i)
                if ($invalid_character_or_surrogate_pair.Length -gt 1)
                {
                    CreateItem -path $path -name ("{1}invalidSurrogatePair_occurence1_{0}_occurence2_{0}" -f $invalid_character_or_surrogate_pair, $itemType) -itemType $itemType
                }
                else
                {
                    CreateItem -path $path -name ("{1}invalidChar_occurence1_{0}_occurence2_{0}" -f $invalid_character_or_surrogate_pair, $itemType) -itemType $itemType
                }
                $succeededCodePoints += 1
            }
            catch
            {
                Write-Warning ("Skipping blocked codepoint #{0} as hex 0x{0:X} '{1}' : blocked '{2}'. Error: {3}" -f $i, $invalid_character_or_surrogate_pair, $isBlocked, $_)
                $skippedCodePoints += 1
            }
        }
    }
    
    Write-Verbose "Created $succeededCodePoints items, skipped $skippedCodePoints"
}

function Perform-Test
{
    param ([switch]$Full)
    
    $dataSetLocation = Join-Path $env:TEMP "EvalToolDataSet"

    if ($Full)
    {
        Write-Verbose "Getting configuration"
        $configuration = Get-Configuration

        Write-Verbose "Creating blocked character table"
        $table = Build-CharacterTable -Configuration $configuration

        Write-Verbose "Creating invalid files"
        $pathForInvalidFileNameCharacters = Join-Path $dataSetLocation "InvalidFileNameCharacters"
        CreateItemsWithInvalidCharacters -path $pathForInvalidFileNameCharacters -configuration $configuration -blockedCharactersTable $table -itemType File

        Write-Verbose "Creating invalid dirs"
        $pathForInvalidDirNameCharacters = Join-Path $dataSetLocation "InvalidDirNameCharacters"
        CreateItemsWithInvalidCharacters -path $pathForInvalidDirNameCharacters -configuration $configuration -blockedCharactersTable $table -itemType Directory
    }
    else
    {
        if (!(Test-Path $dataSetLocation))
        {
            throw "Cannot access: $dataSetLocation"
        }
    }

    Write-Verbose "Invoking evaluation tool with path $dataSetLocation"
    $errors = Invoke-AzureRmStorageSyncCompatibilityCheck -Path $dataSetLocation -SkipSystemChecks
    Write-Verbose "Number of errors: $($errors.Count)"

    $reportLocation = Join-Path $env:TEMP "EvalReport.csv"
    Write-Verbose "Exporting as CSV at $reportLocation"
    $errors | Select-Object -Property Type, Path, Level, Description, Result | Export-Csv -Path $reportLocation -NoTypeInformation
    
    Write-Verbose "Done"
}