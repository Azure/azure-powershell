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

function Get-Configuration
{
    Get-Content -Raw -Path .\config.json | ConvertFrom-Json
}

function Build-CharacterTable
{
    param ($Configuration)

    $blacklistOfCodePoints = $Configuration.BlacklistOfCodePoints
    $blacklistOfCodePointRanges = $Configuration.BlacklistOfCodePointRanges

    $numberOfInvalidCharacters = 0
    $arraySize = 65536
    $charTable = new-object bool[] $arraySize
    for ($i = 0; $i -lt $arraySize; $i += 1)
    {
        $isBlocked = $false
        $aChar = [char]$i;
        $charTable[$i] = ([char]::IsHighSurrogate($aChar)) -or 
                    $blacklistOfCodePoints.Contains($aChar) -or
                    ($blacklistOfCodePointRanges.Where({ ($_.Start -le $i) -and ($_.End -ge $i) }).Count -gt 0);
    }
    return $charTable
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
	$skippedCharacters = 0
	$succeededCharacters = 0
    for ($i = 0; $i -lt $blockedCharactersTable.Count; $i += 1)
    {
        $isBlocked = $blockedCharactersTable[$i];
        if ($isBlocked)
        {
            try
			{
				CreateItem -path $path -name ("{1}WithInvalidCharacter{0}InName" -f [char]$i, $itemType) -itemType $itemType
				$succeededCharacters += 1
			}
			catch
			{
				Write-Warning ("Skipping blocked character #{0} '{1}' : blocked '{2}'. Error: {3}" -f $i, [char]$i, $isBlocked, $_)
				$skippedCharacters += 1
			}
        }
    }
	
	Write-Verbose "Created $succeededCharacters items, skipped $skippedCharacters"
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