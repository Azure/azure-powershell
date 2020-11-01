[CmdletBinding()]
Param
(
    [ValidateSet("Az.AppService", "Az.Billing", "Az.Compute", "Az.Dns", "Az.FrontDoor", "Az.KeyVault", "Az.Media",
                 "Az.Monitor", "Az.Network", "Az.RedisCache", "Az.Resources", "Az.ServiceBus", "Az.Storage")]
    [Parameter(Mandatory)]
    [string]${Module},

    [Parameter(Mandatory)]
    [ArgumentCompleter( {
            param ( $commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters )

            if ($fakeBoundParameters.ContainsKey("Module"))
            {
                $TempModule = $fakeBoundParameters.Module
                $RootFolder = (Get-Item -Path $PSScriptRoot).Parent.FullName
                $SrcFolder = Join-Path -Path $RootFolder -ChildPath "src"
                $ModuleFolder = Join-Path -Path $SrcFolder -ChildPath ($TempModule.Replace("Az.", ""))
                if (Test-Path -Path $ModuleFolder)
                {
                    $ExportsFolder = Join-Path -Path $ModuleFolder -ChildPath "exports"
                    if (Test-Path -Path $ExportsFolder)
                    {
                        (Get-ChildItem -Path $ExportsFolder -Directory).Name | Where-Object { $_ -like "*$wordToComplete*" }
                    }
                }
            }
        } )]
    [string]${ApiProfile},

    [Parameter()]
    [string]${OutputFile},

    [Parameter()]
    [switch]${IgnoreForce}
)

$Result = @()
$ToolsFolder = $PSScriptRoot
$SerializedCmdletsFolder = Join-Path -Path $ToolsFolder -ChildPath (Join-Path -Path "Tools.Common" -ChildPath "SerializedCmdlets")
$RootFolder = (Get-Item -Path $ToolsFolder).Parent.FullName
$SrcFolder = Join-Path -Path $RootFolder -ChildPath "src"
$ModuleFolder = Join-Path -Path $SrcFolder -ChildPath ($Module.Replace("Az.", ""))
$ModuleToSerializedCmdletsFile = @{
    "Az.AppService" = @( "Microsoft.Azure.PowerShell.Cmdlets.Websites.dll.json" );
    "Az.Billing"    = @( "Microsoft.Azure.PowerShell.Cmdlets.Billing.dll.json",
                         "Microsoft.Azure.PowerShell.Cmdlets.Consumption.dll.json",
                         "Microsoft.Azure.PowerShell.Cmdlets.UsageAggregates.dll.json");
    "Az.Compute"    = @( "Microsoft.Azure.PowerShell.Cmdlets.Compute.dll.json" );
    "Az.Dns"        = @( "Microsoft.Azure.PowerShell.Cmdlets.Dns.dll.json" );
    "Az.FrontDoor"  = @( "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.dll.json" );
    "Az.KeyVault"   = @( "Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll.json" );
    "Az.Media"      = @( "Microsoft.Azure.PowerShell.Cmdlets.Media.dll.json" );
    "Az.Monitor"    = @( "Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll.json" );
    "Az.Network"    = @( "Microsoft.Azure.PowerShell.Cmdlets.Network.dll.json" );
    "Az.RedisCache" = @( "Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll.json" );
    "Az.Resources"  = @( "Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll.json",
                         "Microsoft.Azure.PowerShell.Cmdlets.Resources.dll.json",
                         "Microsoft.Azure.PowerShell.Cmdlets.Tags.dll.json" );
    "Az.ServiceBus" = @( "Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.dll.json" );
    "Az.Storage"    = @( "Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll.json" );
}

$CmdletsToParameters = @{}
$CmdletToAliases = @{}
$SerializedCmdletsFiles = $ModuleToSerializedCmdletsFile[$Module]
if ($null -eq $SerializedCmdletsFiles)
{
    Write-Error  "No serialized cmdlet files found for module '$Module'"
    return
}

foreach ($File in $SerializedCmdletsFiles)
{
    $FullFile = Get-Item -Path (Join-Path -Path $SerializedCmdletsFolder -ChildPath $File)
    if (!(Test-Path -Path $FullFile))
    {
        Write-Warning "Can not find serialized cmdlet file '$FullFile' -- skipping"
    }

    Write-Debug "[DEBUG] Processing serialized cmdlet file '$FullFile'"
    $Json = ConvertFrom-Json ([System.IO.File]::ReadAllText($FullFile))
    $Hashtable = @{}
    $Json.PSObject.Properties | ForEach-Object { $Hashtable[$_.Name] = $_.Value }
    foreach ($Cmdlet in $Hashtable.Cmdlets)
    {
        $CmdletsToParameters[$Cmdlet.Name] = $Cmdlet.Parameters
        $CmdletToAliases[$Cmdlet.Name] = $Cmdlet.AliasList
    }
}

if (!(Test-Path -Path $ModuleFolder))
{
    Write-Error "No folder found for module '$Module' in $SrcFolder"
    return
}

Write-Debug "[DEBUG] Using module folder path '$ModuleFolder'"
$ExportsFolder = Get-ChildItem -Path $ModuleFolder -Filter "exports" -Recurse -Directory
if ($null -eq $ExportsFolder)
{
    Write-Error "No exports folder found in module folder '$ModuleFolder'"
    return
}

$ApiProfileFolder = Join-Path -Path $ExportsFolder -ChildPath $ApiProfile
if (!(Test-Path -Path $ApiProfileFolder))
{
    Write-Error "Can not find folder '$ApiProfileFolder' containing generated cmdlets"
    return
}

Write-Debug "[DEBUG] Using API profile folder '$ApiProfileFolder'"
$GeneratedCmdlets = @{}
$NewlyGeneratedCmdlets = @()
$NoMissingParametersCmdlets = @()
$AllCmdletAliases = @()
$GeneratedScripts = Get-ChildItem -Path $ApiProfileFolder -Filter "*.ps1"
$Result += "## Incorrect Cmdlets`n"
foreach ($Script in $GeneratedScripts)
{
    $CmdletName = $Script.BaseName
    $CmdletAliases = @()
    $Content = Get-Content -Path $Script.FullName
    for ($Index = 0; $Index -lt $Content.Length; $Index++)
    {
        $Line = $Content[$Index]
        if ($Line -like "*param(*")
        {
            $TempIndex = $Index - 1
            while ($TempIndex -ge 0 -and $Content[$TempIndex] -notlike "*function *")
            {
                $Line = $Content[$TempIndex]
                if ($Line -like '*`[Alias`(*')
                {
                    $Line = $Line.Trim("").Trim("[Alias(").Trim(")]")
                    $Aliases = $Line -split ","
                    foreach ($Alias in $Aliases)
                    {
                        $AliasName = $Alias.Trim("").Trim("'")
                        $CmdletAliases += $AliasName
                        $AllCmdletAliases += $AliasName
                    }

                    break
                }

                $TempIndex--
            }
        }
    }

    $GeneratedCmdlets[$CmdletName] = $true
    $ExistingParameters = $CmdletsToParameters[$CmdletName]
    if ($null -eq $ExistingParameters)
    {
        foreach ($Cmdlet in $CmdletToAliases.Keys)
        {
            if ($CmdletToAliases[$Cmdlet] -contains $CmdletName)
            {
                $ExistingParameters = $CmdletsToParameters[$Cmdlet]
                break
            }
        }

        if ($null -eq $ExistingParameters)
        {
            foreach ($Cmdlet in $CmdletAliases)
            {
                if ($null -ne $CmdletsToParameters[$Cmdlet])
                {
                    $ExistingParameters = $CmdletsToParameters[$Cmdlet]
                    break
                }
            }

            if ($null -eq $ExistingParameters)
            {
                Write-Debug "[DEBUG] '$CmdletName' is a new cmdlet -- skipping"
                $NewlyGeneratedCmdlets += $CmdletName
                continue
            }
        }
    }

    $Parameters = @()
    for ($Index = 0; $Index -lt $Content.Length; $Index++)
    {
        $Line = $Content[$Index]
        if ($Line -like "*`${*}*")
        {
            $Parameters += $Line.Trim("").Trim("`${").Trim("},")
            $TempIndex = $Index - 1
            while ($TempIndex -ge 0 -and ![string]::IsNullOrWhiteSpace($Content[$TempIndex]))
            {
                $Line = $Content[$TempIndex]
                if ($Line -like '*`[Alias`(*')
                {
                    $Line = $Line.Trim("").Trim("[Alias(").Trim(")]")
                    $Aliases = $Line -split ","
                    foreach ($Alias in $Aliases)
                    {
                        $Parameters += $Alias.Trim("").Trim("'")
                    }

                    break
                }

                $TempIndex--
            }
        }
    }

    $MissingParameters = @()
    foreach ($Parameter in $ExistingParameters)
    {
        if (($Parameter.Name -ne 'ResourceId') -and (-not $IgnoreForce -or $Parameter.Name -ne 'Force') -and (($Parameters | Where-Object { $_ -eq $Parameter.Name }).Count -eq 0))
        {
            $Found = $false
            foreach ($Alias in $Parameter.AliasList)
            {
                if ($Parameters -contains $Alias)
                {
                    $Found = $true
                    break
                }
            }

            if (!$Found)
            {
                $MissingParameters += $Parameter.Name
            }
        }
    }

    if ($MissingParameters.Count -eq 0)
    {
        Write-Debug "[DEBUG] No missing parameters found for '$CmdletName'"
        $NoMissingParametersCmdlets += $CmdletName
    }
    else
    {
        Write-Debug "[DEBUG] Missing parameters found for '$CmdletName'"
        $Result += "- $CmdletName"
        $MissingParameters | ForEach-Object { $Result += "    - $_" }
    }
}

$Result += "`n## Correct Cmdlets`n"
$NoMissingParametersCmdlets | ForEach-Object { $Result += "- $_" }

$Result += "`n## New Cmdlets`n"
$NewlyGeneratedCmdlets | ForEach-Object { $Result += "- $_" }

$MissingCmdlets = @()
foreach ($Cmdlet in $CmdletsToParameters.Keys)
{
    if ($null -eq $GeneratedCmdlets[$Cmdlet] -and $AllCmdletAliases -notcontains $Cmdlet)
    {
        $AliasList = $CmdletToAliases[$Cmdlet]
        $Found = $false
        foreach ($Alias in $AliasList)
        {
            if ($null -ne $GeneratedCmdlets[$Alias])
            {
                $Found = $true
                break
            }
        }

        if (!$Found)
        {
            Write-Debug "[DEBUG] No cmdlet generated for existing cmdlet '$Cmdlet'"
            $MissingCmdlets += $Cmdlet
        }
    }
}

$Result += "`n## Missing Cmdlets`n"
$MissingCmdlets | Sort-Object | ForEach-Object { $Result += "- $_" }

if ([string]::IsNullOrEmpty($OutputFile))
{
    $Result | ForEach-Object { Write-Host $_ }
}
else
{
    if (!(Test-Path -Path $OutputFile))
    {
        Write-Debug "[DEBUG] Provided output file '$OutputFile' does not exist -- creating this file"
        New-Item -Path $OutputFile -ItemType File
    }

    Set-Content -Path $OutputFile -Value $Result -Force | Out-Null
}