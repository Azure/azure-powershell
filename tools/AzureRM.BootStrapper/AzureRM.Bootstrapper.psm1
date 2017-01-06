$RollUpModule = "AzureRM"
$PSProfileMapEndpoint = "https://profile.azureedge.net/powershell/ProfileMap.json"
$PSModule = $ExecutionContext.SessionState.Module
# $Global:dependencyIndex 
$script:BootStrapRepo = "BootStrap"
$RepoLocation = "https://www.powershellgallery.com/api/v2/"
$existingRepos = Get-PSRepository | Where-Object {$_.SourceLocation -eq $RepoLocation}
if ($existingRepos -eq $null)
{
  Register-PSRepository -Name $BootStrapRepo -SourceLocation $RepoLocation -PublishLocation $RepoLocation -ScriptSourceLocation $RepoLocation -ScriptPublishLocation $RepoLocation -InstallationPolicy Trusted -PackageManagementProvider NuGet
}
else
{
  $script:BootStrapRepo = $existingRepos[0].Name
}

# Get profile cache path
function Get-ProfileCachePath
{
  $ProfileCache = Join-Path -path $env:LOCALAPPDATA -childpath "Microsoft\AzurePowerShell\ProfileCache"
  return $ProfileCache
}

# Make Rest-Call
function Get-RestResponse
{
  try {
    $ProfileMap = Invoke-RestMethod -ea SilentlyContinue -Uri $PSProfileMapEndpoint -ErrorVariable RestError -ContentType application/json 
    return $ProfileMap
  }
  catch {
    $HttpStatusCode = $RestError.ErrorRecord.Exception.Response.StatusCode.value__
    $HttpStatusDescription = $RestError.ErrorRecord.Exception.Response.StatusDescription
    
  	Throw "Http Status Code: $($HttpStatusCode) `nHttp Status Description: $($HttpStatusDescription)"
  }
}

# Save old ProfileMap
function Rename-PreviousProfileMap
{
  [string]$ProfileCache = Get-ProfileCachePath
  [string]$filePath = "$ProfileCache\ProfileMap.json";

  [string]$directory = [System.IO.Path]::GetDirectoryName($filePath);
  [string]$strippedFileName = [System.IO.Path]::GetFileNameWithoutExtension($filePath);
  [string]$extension = [System.IO.Path]::GetExtension($filePath);
  [string]$newFileName = $strippedFileName + [DateTime]::Now.ToString("yyyyMMdd-HHmmss") + $extension;
  [string]$newFilePath = [System.IO.Path]::Combine($directory, $newFileName);

  Copy-Item -LiteralPath $filePath -Destination $newFilePath;
}

# Get-ProfileMap from Azure Endpoint
function Get-AzureProfileMap
{
  $ProfileCache = Get-ProfileCachePath

  # If profile cache directory does not exist, create one.
  if(-Not (Test-Path $ProfileCache))
  {
    New-Item -ItemType Directory -Force -Path $ProfileCache | Out-Null
  }

  # Get online profile data using Rest method
  $OnlineProfileMap = Get-RestResponse  

  # If cache ProfileMap does not exist, create one using online data.
  if(-not (Test-Path "$ProfileCache\ProfileMap.json"))
  {
    $ChildPathName = ((Get-FileHashProfileMap $OnlineProfileMap).Hash) + ".json"
    $CacheFilePath = (Join-Path $ProfileCache -ChildPath $ChildPathName)
    $OnlineProfileMap | ConvertTo-Json -Compress | Out-File -FilePath $CacheFilePath
   
    # create symlink
    Invoke-Expression -Command "cmd /c mklink $ProfileCache\ProfileMap.json $CacheFilePath"
    return $OnlineProfileMap
  }

  # Compare hash values for Online profile map and cached profile map; replace cached if different.
  $ProfileMap = Get-Content -Raw -Path "$ProfileCache\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json
  if ((Get-FileHashProfileMap $ProfileMap).Hash -ne (Get-FileHashProfileMap $OnlineProfileMap).Hash)
  {
    # Rename & Save old ProfileMap if exists
    Rename-PreviousProfileMap
    $ChildPathName = ((Get-FileHashProfileMap $OnlineProfileMap).Hash) + ".json"
    $OnlineProfileMap | ConvertTo-Json -Compress | Out-File -FilePath (Join-Path $ProfileCache -ChildPath $ChildPathName)
    # Set-Content "$ProfileCache\ProfileMap.json" -Value $OnlineProfileMap -Force
    # Update symlink
    # No edit symlink cmd available. So delete it and create a new one with the same name.
  }
  
  # Return cached data if not different
  $ProfileMap = Get-Content -Raw -Path "$ProfileCache\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json 
  return $ProfileMap
}

# Get ProfileMap from Cache, online or embedded source
function Get-AzProfile
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-SwitchParam $params "Update"
    Add-SwitchParam $params "ListAvailable" "ListAvailableParameterSet"
    return $params
  }

  PROCESS
  {
    $Update = $PSBoundParameters.Update
    # If Update is present, download ProfileMap from Storage blob endpoint
    if ($Update.IsPresent)
    {
      return (Get-AzureProfileMap)
    }

    # Check the cache
    $ProfileCache = Get-ProfileCachePath
    if(Test-Path $ProfileCache)
    {
        $ProfileMap = Get-Content -Raw -Path "$ProfileCache\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json 
       
        if ($ProfileMap -ne $null)
        {
           return $ProfileMap
        }
    }
     
    # If cache doesn't exist, Check embedded source
    $defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
    $ProfileMap = Get-Content -Raw -Path "$defaults\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json
    if($ProfileMap -eq $null)
    {
        # Cache & Embedded source empty; Return error and stop
        throw [System.IO.FileNotFoundException] "Profile meta data does not exist. Use 'Get-AzureRmProfile -Update' to download from online source."
    }

    return $ProfileMap
  }
}

# Lists the profiles available for install from gallery
function Get-ProfilesAvailable
{
  param([PSCustomObject] $ProfileMap)
  $ProfileList = ""
  foreach ($Profile in $ProfileMap) 
  {
    foreach ($Module in ($Profile | get-member -MemberType NoteProperty).Name)
    {
      $ProfileList += "Profile: $Module`n"
      $ProfileList += "----------------`n"
      $ProfileList += ($Profile.$Module | Format-List | Out-String)
    } 
  }
  return $ProfileList
}

# Lists the profiles that are installed on the machine
function Get-ProfilesInstalled
{
  param([PSCustomObject] $ProfileMap)
  $result = @{}
  $IncompleteProfiles = @()
  $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name

  foreach ($key in $AllProfiles)
  {
    foreach ($module in ($ProfileMap.$key | Get-Member -MemberType NoteProperty).Name)
    {
      if ((Get-AzureRmModule -Profile $key -Module $module) -ne $null)
      {
        if ($result.ContainsKey($key))
        {
          $result[$key] += @{$module = $ProfileMap.$Key.$module}
        }
        else
        {
           $result.Add($key, @{$module = $ProfileMap.$Key.$module})
        }
      }
    }

    if(($result.$key.Count -gt 0) -and ($result.$key.Count -ne ($ProfileMap.$key | Get-Member -MemberType NoteProperty).Count))
    {
        $IncompleteProfiles += $key
        $result.Remove($key)
    }
  }

  foreach ($key in $result.Keys)
  {
     Write-Host "Profile : $key"
     Write-Host "-----------------"
     $result.$key | Format-Table -HideTableHeaders 
  }
  if ($IncompleteProfiles -ne $null)
  {
    Write-Host "Some modules from profile(s) $IncompleteProfiles were not installed. Use Install-AzureRmProfile to install missing modules."
  }
}

# Install module from the gallery
function Install-ModuleHelper
{
  param([string] $Module, [string] $Profile, [PSCustomObject] $ProfileMap)
        $versions = $ProfileMap.$Profile.$Module
        $versionEnum = $versions.GetEnumerator()
        $toss = $versionEnum.MoveNext()
        $version = $versionEnum.Current
        Install-Module $Module -RequiredVersion $version -Repository $BootStrapRepo
}

# Check if the module version is part of any other profile
function Test-Dependencies
{
  # param([string] $Module, [version] $version)
  $ProfileCache = Get-ProfileCachePath
  $ProfileMapFiles = Get-ChildItem $ProfileCache
  $dependencyIndex = @{} 
  foreach($ProfileMapPath in $ProfileMapFiles)
  {
    $ProfileMap = Get-Content -Raw -Path (Join-Path $ProfileCache $ProfileMapPath) |  ConvertFrom-json
    $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    foreach ($profile in $Profiles)
    {
      foreach ($Module in ($ProfileMap.$profile | Get-Member -MemberType NoteProperty).Name)
      {
        if ($dependencyIndex.ContainsKey(($Module + $ProfileMap.$Profile.$Module)))
        {
          if ($profile -ne $dependencyIndex[($Module + $ProfileMap.$Profile.$Module)])
          {
            $dependencyIndex[($Module + $ProfileMap.$Profile.$Module)] += $Profile
          }
        }
        else {
          $dependencyIndex.Add(($Module + $ProfileMap.$Profile.$Module), @($Profile))
        }
      }
    }
  }
  $dependencyIndex
}

# Gets hash value for profilemap
function Get-FileHashProfileMap
{
  <#
  https://msdn.microsoft.com/powershell/reference/5.1/microsoft.powershell.utility/Get-FileHash
  http://stackoverflow.com/questions/8047064/convert-string-to-system-io-stream
  #>
  $mapstr = Get-ProfilesAvailable $profilemap
  $bytearr = [System.Text.Encoding]::UTF8.GetBytes($mapstr)
  $stream = [System.Io.MemoryStream]::New($bytearr)
  Get-FileHash -InputStream $stream -Algorithm MD5
}

function Add-ProfileParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $ProfileMap = (Get-AzProfile)
  $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
  $profileAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $profileAttribute.ParameterSetName = $set
  $profileAttribute.Mandatory = $true
  $profileAttribute.Position = 0
  $validateProfileAttribute = New-Object -Type System.Management.Automation.ValidateSetAttribute($AllProfiles)
  $profileCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $profileCollection.Add($profileAttribute)
  $profileCollection.Add($validateProfileAttribute)
  $profileParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Profile", [string], $profileCollection)
  $params.Add("Profile", $profileParam)
}

function Add-ForceParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  Add-SwitchParam $params "Force" $set
}

function Add-RemoveParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $name = "RemovePreviousVersions" 
  $newAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $newAttribute.ParameterSetName = $set
  $newAttribute.Mandatory = $false
  $newCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $newCollection.Add($newAttribute)
  $newParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter($name, [switch], $newCollection)
  $params.Add($name, [Alias("r")]$newParam)
}

function Add-SwitchParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$name, [string] $set = "__AllParameterSets")
  $newAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $newAttribute.ParameterSetName = $set
  $newAttribute.Mandatory = $false
  $newCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $newCollection.Add($newAttribute)
  $newParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter($name, [switch], $newCollection)
  $params.Add($name, $newParam)
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Get-AzureRmModule 
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    $ProfileMap = (Get-AzProfile)
    $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $enum = $Profiles.GetEnumerator()
    $toss = $enum.MoveNext()
    $Current = $enum.Current
    $Keys = ($($ProfileMap.$Current) | Get-Member -MemberType NoteProperty).Name
    $moduleValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($Keys)
    $moduleAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
    $moduleAttribute.ParameterSetName = 
    $moduleAttribute.Mandatory = $true
    $moduleAttribute.Position = 1
    $moduleCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
    $moduleCollection.Add($moduleValid)
    $moduleCollection.Add($moduleAttribute)
    $moduleParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Module", [string], $moduleCollection)
    $params.Add("Module", $moduleParam)
    return $params
  }
  
  PROCESS
  {
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $Module = $PSBoundParameters.Module
    $versionList = $ProfileMap.$Profile.$Module
    $moduleList = Get-Module -Name $Module -ListAvailable | where {$_.RepositorySourceLocation -ne $null}
    foreach ($version in $versionList)
    {
      foreach ($module in $moduleList)
      {
        if ($version -eq $module.Version)
        {
          return $version
        }
      }
    }

    return $null
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Get-AzureRmProfile
{
  [CmdletBinding(DefaultParameterSetName="ListAvailableParameterSet")]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-SwitchParam $params "ListAvailable" "ListAvailableParameterSet"
    Add-SwitchParam $params "Update"
    return $params
  }
  PROCESS
  {
    # ListAvailable helps to display all profiles available from the gallery
    [switch]$ListAvailable = $PSBoundParameters.ListAvailable
    $ProfileMap = (Get-AzProfile @PSBoundParameters)
    if ($ListAvailable.IsPresent)
    {
      Get-ProfilesAvailable $ProfileMap
    }
    else
    {
      # Just display profiles installed on the machine
      Get-ProfilesInstalled -ProfileMap $ProfileMap 
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Use-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess=$true)] 
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-RemoveParam $params
    return $params
  }
  PROCESS 
  {
    $Force = $PSBoundParameters.Force
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    if ($PSCmdlet.ShouldProcess($Profile, "Loading modules for profile in the current scope"))
    {
      foreach ($Module in ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name)
      {
        $version = Get-AzureRmModule -Profile $Profile -Module $Module
        if (($version -eq $null) -and ($IsConfirmed -or $Force.IsPresent -or $PSCmdlet.ShouldContinue("Install Modules for Profile $Profile from the gallery?", "Installing Modules for Profile $Profile")))
        {
          # Flag to track if the prompt for install module was previously accepted.
          $IsConfirmed = $true
          Install-ModuleHelper -Module $Module -Profile $Profile -ProfileMap $ProfileMap
        }
        Write-Host "Loading Profile $Profile, $Module Module version $version"
        Import-Module -Name $Module -RequiredVersion $version -Global
      }
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Install-AzureRmProfile
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    foreach ($Module in ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name)
    {
      $version = Get-AzureRmModule -Profile $Profile -Module $Module
      if ($version -eq $null) 
      {
        Install-ModuleHelper -Module $Module -Profile $Profile -ProfileMap $ProfileMap
      }
      else 
      {
        Write-Host "Module $Module Version $version is already installed."
      }
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Uninstall-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile)
    Uninstall-ProfileHelper -PMap $ProfileMap @PSBoundParameters
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Update-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-RemoveParam $params 
    return $params
  }

  PROCESS {
    # Update Profile cache, if not up-to-date
    $ProfileMap = (Get-AzProfile -Update)
    $profile = $PSBoundParameters.Profile

    $ProfileCache = Get-ProfileCachePath
    $ProfileMapHashes = Get-ChildItem $ProfileCache 
    
    foreach ($ProfileMapHash in $ProfileMapHashes)
    {
      $previousProfileMap = Get-Content -Raw -Path (Join-Path $profilecache $ProfileMapHash) |  ConvertFrom-json
      $PreviousProfiles = ($previousProfileMap | Get-Member -MemberType NoteProperty).Name
      foreach($PreviousProfile in $PreviousProfiles)
      {
        # Do not remove the current installed profile
        if ($PreviousProfile -eq $profile)
        {
          continue
        }
        
        # Uninstall the previous profile
        $removeHash = (Uninstall-ProfileHelper -PMap $previousProfileMap @PSBoundParameters )

        # Delete hash file if profile uninstall was not denied
        if ($removeHash -ne $false) 
        {
          Remove-ProfileMapFile -ProfileMapPath (Join-Path $profilecache $ProfileMapHash)
        }
      }
    }

    # Install & import the required version
    Use-AzureRmProfile @PSBoundParameters
  }
}

    <#foreach($ProfileMapPath in $ProfileMapFiles)
    {
      $previousProfileMap = Get-Content -Raw -Path (Join-Path $profilecache $ProfileMapPath) |  ConvertFrom-json
      # Flag to track if profile is installed: If no profile from the previous json file was installed, remove the json file.
      $profileInstalled = $false
      $PreviousProfiles = ($previousProfileMap | Get-Member -MemberType NoteProperty).Name
      foreach($previousProfile in $PreviousProfiles)
      {
        $versionList = $previousProfileMap.$previousProfile.$RollUpModule
        foreach($version in $versionList)
        {
          # Remove profile versions that are less than the given profile version
          foreach ($CurrentVersion in $CurrentVersionList) 
          {
            if ($version -ge $CurrentVersion) 
            {
              continue
            }
            
            #if ($version -lt $CurrentVersion)
            #  {
                $moduleInstalled =  Get-Module -Name $RollUpModule -ListAvailable | Where-Object { $_.Version -eq $version}
                # Ask to remove only if the profile was previously installed
                if (($previousProfile -ne $profile) -and ($moduleInstalled -ne $null))
                {
                  # Set flag to track profile installed
                  $profileInstalled = $true
                  Uninstall-ProfileHelper -PMap $previousProfileMap -Profile $profile 
                  <#if ($PSCmdlet.ShouldProcess("Profile $previousProfile", "Remove Profile"))
                  {
                    if (($Remove.IsPresent -or $PSCmdlet.ShouldContinue("Remove Profile $previousProfile?", "Removing profile $previousProfile")))
                    {
                      $modules = ($previousProfileMap.$previousProfile | Get-Member -MemberType NoteProperty).Name
                      foreach ($module in $modules) 
                      {
                        Remove-Module -Name $module -Force -ErrorAction "SilentlyContinue"
                        try 
                        {
                          Uninstall-Module -Name $module -RequiredVersion $version -Force -ErrorAction Stop
                        }
                        catch
                        {
                          break
                        }
                      }
                      # Remove the previous profile map json file 
                      if($ProfileMapPath.Name -ne 'ProfileMap.json')
                      {
                        Remove-ProfileMapFile -ProfileMapPath (Join-Path $profilecache $ProfileMapPath)
                      }
                    }
                  }
                }
             # }
            }
          }
        }
    
      # Remove the json file if no profile from it was found installed
      if ((-not $profileInstalled) -and ($ProfileMapPath.Name -ne 'ProfileMap.json'))
      {
        Remove-ProfileMapFile -ProfileMapPath (Join-Path $profilecache $ProfileMapPath)
      }
    }
    #>

function Uninstall-ProfileHelper
{
  [CmdletBinding(SupportsShouldProcess = $true)]
	param([PSObject]$PMap)
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-RemoveParam $params
    return $params
  }

  PROCESS {
    $Force = $PSBoundParameters.Force
    $Remove = $PSBoundParameters.RemovePreviousVersions
    $AllProfiles = ($PMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $modules = ($PMap.$Profile | Get-Member -MemberType NoteProperty).Name
    $profilesInstalled = Get-ProfilesInstalled
    foreach ($module in $modules)
    {
     $canceled = $false
     $dependencyIndex = Test-Dependencies
     if($dependencyIndex[$module + ($PMap.$Profile.$module)].Count -ge 2)
     {
       # To Do
     }
     foreach ($profileInDepIndex in $dependencyIndex[$module + ($PMap.$Profile.$module)])
     {
       if ($profileInDepIndex -in $profilesInstalled)
       {
         # Ask to uninstall. If denied, do not delete the hash
         Do
         {
           $version = (Get-AzureRmModule -Profile $Profile -Module $module)
           if ($PSCmdlet.ShouldProcess("$module version $version", "Remove module"))
           {
             if (($version -ne $null) -and ($Force -or $Remove -or $PSCmdlet.ShouldContinue("Remove module $module version $version", "Removing Modules for profile $Profile")))
             {
               Remove-Module -Name $module -Force -ErrorAction "SilentlyContinue"
               try 
               {
                 Uninstall-Module -Name $module -RequiredVersion $version -Force -ErrorAction Stop
               }
               catch
               {
                 break
               }
             }
             else
             {
               if ($version -ne $null)
               {
                 $removeHash = $false
               }
               break
             }
           }
           else
           {
             break
           }
         }
         While($version -ne $null);
       }
       if ($removeHash -eq $false)
       {
         continue
       }
     }
   } 
   return $removeHash
  }
}
<#if($dependencyIndex[$module + ($PMap.$Profile.$module)].Count -ge 2)
          {
          }#>



function Remove-ProfileMapFile
{
  [CmdletBinding()]
	param([string]$ProfileMapPath)

  if (Test-Path -Path $ProfileMapPath)
  {
    Remove-Item -Path $ProfileMapPath -Force
  }
}

function Set-BootstrapRepo
{
	[CmdletBinding()]
	param([string]$Repo)
	$script:BootStrapRepo = $Repo
}
