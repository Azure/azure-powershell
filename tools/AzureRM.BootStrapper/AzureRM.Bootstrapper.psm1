$RollUpModule = "AzureRM"
$PSProfileMapEndpoint = "https://azureprofile.azureedge.net/powershell/profilemap.json"
$script:BootStrapRepo = "PSGallery"

# Is it Powershell Core edition?
$Script:IsCoreEdition = ($PSVersionTable.PSEdition -eq 'Core')

# Check if current user is Admin to decide on cache path
$script:IsAdmin = $false
if ((-not $Script:IsCoreEdition) -or ($IsWindows))
{
  $script:ProgramFilesPSPath = $env:ProgramFiles
  If (([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
  {
    $script:IsAdmin = $true
  }
}
else {
  $script:ProgramFilesPSPath = $PSHOME
  # on Linux, tests run via sudo will generally report "root" for whoami
  if ( (whoami) -match "root" ) 
  {
    $script:IsAdmin = $true
  }
}

# Get profile cache path
function Get-ProfileCachePath
{
  if ((-not $Script:IsCoreEdition) -or ($IsWindows))
  {
    $ProfileCache = Join-Path -path $env:LOCALAPPDATA -childpath "Microsoft\AzurePowerShell\ProfileCache"
    if ($script:IsAdmin)
    {
      $ProfileCache = Join-Path -path $env:ProgramData -ChildPath "Microsoft\AzurePowerShell\ProfileCache"
    }
  }
  else {
    $ProfileCache = "$HOME/.config/Microsoft/AzurePowerShell/ProfileCache" 
  }

  # If profile cache directory does not exist, create one.
  if(-Not (Test-Path $ProfileCache))
  {
    New-Item -ItemType Directory -Force -Path $ProfileCache | Out-Null
  }

  return $ProfileCache
}

# Function to find the latest profile map from cache
function Get-LatestProfileMapPath
{
  $ProfileCache = Get-ProfileCachePath
  $ProfileMapPaths = Get-ChildItem $ProfileCache
  if ($null -eq $ProfileMapPaths)
  {
    return
  }

  $LargestNumber = Get-LargestNumber -ProfileCache $ProfileCache
  if ($null -eq $LargestNumber)
  {
    return
  }

  $LatestMapPath = $ProfileMapPaths | Where-Object { $_.Name.Startswith($LargestNumber.ToString() + '-') }
  return $LatestMapPath
}

# Function to get the largest number in profile cache profile map names: This helps to find the latest map
function Get-LargestNumber
{
  param($ProfileCache)
  
  $ProfileMapPaths = Get-ChildItem $ProfileCache
  $LargestNumber = $ProfileMapPaths | ForEach-Object { if($_.Name -match "\d+-") { $matches[0] -replace '-' } } | Measure-Object -Maximum 
  if ($null -ne $LargestNumber)
  {
    return $LargestNumber.Maximum
  }
}

# Find the latest ProfileMap 
$script:LatestProfileMapPath = Get-LatestProfileMapPath

# Make Web-Call
function Get-AzureStorageBlob
{
  $ScriptBlock = {
    Invoke-WebRequest -uri $PSProfileMapEndpoint -UseBasicParsing -TimeoutSec 120 -ErrorVariable RestError
  }

  $WebResponse = Invoke-CommandWithRetry -ScriptBlock $ScriptBlock    
  return $WebResponse
}

# Get-ProfileMap from Azure Endpoint
function Get-AzureProfileMap
{
  Write-Verbose "Updating profiles"
  $ProfileCache = Get-ProfileCachePath

  # Get online profile data using Web request
  $WebResponse = Get-AzureStorageBlob  

  # Get ETag value for OnlineProfileMap
  $OnlineProfileMapETag = $WebResponse.Headers["ETag"]

  # If profilemap json exists, compare online Etag and cached Etag; if not different, don't replace cache.
  if (($null -ne $script:LatestProfileMapPath) -and ($script:LatestProfileMapPath -match "(\d+)-(.*.json)"))
  {
    [string]$ProfileMapETag = [System.IO.Path]::GetFileNameWithoutExtension($Matches[2])
    if (($ProfileMapETag -eq $OnlineProfileMapETag) -and (Test-Path $script:LatestProfileMapPath.FullName))
    {
      $scriptBlock = {
        Get-Content -Raw -Path $script:LatestProfileMapPath.FullName -ErrorAction stop | ConvertFrom-Json 
      }
      $ProfileMap = Invoke-CommandWithRetry -ScriptBlock $scriptBlock 

      if ($null -ne $ProfileMap)
      {
        return $ProfileMap
      }
    }
  }

  # If profilemap json doesn't exist, or if online ETag and cached ETag are different, cache online profile map
  $LargestNoFromCache = Get-LargestNumber -ProfileCache $ProfileCache 
  if ($null -eq $LargestNoFromCache)
  {
    $LargestNoFromCache = 0
  }
  
  $ChildPathName = ($LargestNoFromCache+1).ToString() + '-' + ($OnlineProfileMapETag) + ".json"
  $CacheFilePath = (Join-Path $ProfileCache -ChildPath $ChildPathName)
  $OnlineProfileMap = RetrieveProfileMap -WebResponse $WebResponse
  $OnlineProfileMap | ConvertTo-Json -Compress | Out-File -FilePath $CacheFilePath
   
  # Store old profile map's path before Updating
  $oldProfileMap = $script:LatestProfileMapPath

  # Update $script:LatestProfileMapPath
  $script:LatestProfileMapPath = Get-ChildItem $ProfileCache | Where-Object { $_.FullName.equals($CacheFilePath)}
  
  # Remove old profile map if it exists
  if (($null -ne $oldProfileMap) -and (Test-Path $oldProfileMap.FullName))
  {
    $ScriptBlock = {
      Remove-Item -Path $oldProfileMap.FullName -Force -ErrorAction Stop
    }
    Invoke-CommandWithRetry -ScriptBlock $ScriptBlock
  }
  
  return $OnlineProfileMap
}

# Helper to retrieve profile map from http response
function RetrieveProfileMap
{
  param($WebResponse)
  $OnlineProfileMap = $WebResponse | ConvertFrom-Json
  return $OnlineProfileMap
}

# Get ProfileMap from Cache, online or embedded source
function Get-AzProfile
{
  [CmdletBinding()]
  param([Switch]$Update)

  $Update = $PSBoundParameters.Update
  # If Update is present, download ProfileMap from online source
  if ($Update.IsPresent)
  {
    return (Get-AzureProfileMap)
  }

  # Check the cache
  if(($null -ne $script:LatestProfileMapPath) -and (Test-Path $script:LatestProfileMapPath.FullName))
  {
    $scriptBlock = {
      Get-Content -Raw -Path $script:LatestProfileMapPath.FullName -ErrorAction stop | ConvertFrom-Json 
    }
    $ProfileMap = Invoke-CommandWithRetry -ScriptBlock $scriptBlock 
    if ($null -ne $ProfileMap)
    {
      return $ProfileMap
    }
  }
     
  # If cache doesn't exist, Check embedded source
  $defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
  $scriptBlock = {
    Get-Content -Raw -Path (Join-Path -Path $defaults -ChildPath "ProfileMap.json") -ErrorAction stop | ConvertFrom-Json 
  }
  $ProfileMap = Invoke-CommandWithRetry -ScriptBlock $scriptBlock 
  if($null -eq $ProfileMap)
  {
    # Cache & Embedded source empty; Return error and stop
    throw [System.IO.FileNotFoundException] "Profile meta data does not exist. Use 'Get-AzureRmProfile -Update' to download from online source."
  }

  return $ProfileMap
}

# Lists the profiles that are installed on the machine
function Get-ProfilesInstalled
{
  param([parameter(Mandatory = $true)] [PSCustomObject] $ProfileMap, [REF]$IncompleteProfiles)
  $result = @{} 
  $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
  foreach ($key in $AllProfiles)
  {
    Write-Verbose "Checking if profile $key is installed"
    foreach ($module in ($ProfileMap.$key | Get-Member -MemberType NoteProperty).Name)
    {
      $ModulesList = (Get-Module -Name $Module -ListAvailable)
      $versionList = $ProfileMap.$key.$module
      foreach ($version in $versionList)
      {
        if ($null -ne ($ModulesList | Where-Object { $_.Version -eq $version}))
        {
          if ($result.ContainsKey($key))
          {
            if ($result[$key].Containskey($module))
            {
              $result[$key].$module += $version
            }
            else
            {
              $result[$key] += @{$module = @($version)}
            }
          }
          else
          {
            $result.Add($key, @{$module = @($version)})
          }
        }
      }
    }

    # If not all the modules from a profile are installed, add it to $IncompleteProfiles
    if(($result.$key.Count -gt 0) -and ($result.$key.Count -ne ($ProfileMap.$key | Get-Member -MemberType NoteProperty).Count))
    {
      if ($result.$key.Contains($RollUpModule))
      {
        continue
      }
      
      $result.Remove($key)
      if ($null -ne $IncompleteProfiles) 
      {
        $IncompleteProfiles.Value += $key
      }
    }
  }
  return $result
}

# Get profiles installed associated with the module version
function Test-ProfilesInstalled
{
  param([System.Version]$version, [String]$Module, [String]$Profile, [PSObject]$PMap, [hashtable]$AllProfilesInstalled)

  # Profiles associated with the particular module version - installed?
  $profilesAssociated = @()
  foreach ($profileInAllProfiles in $AllProfilesInstalled[$Module + $version])
  {
    $profilesAssociated += $profileInAllProfiles
  }
  return $profilesAssociated
}

# Function to uninstall module
function Uninstall-ModuleHelper
{
  [CmdletBinding(SupportsShouldProcess = $true)] 
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSAvoidShouldContinueWithoutForce", "")]
  param([String]$Profile, $Module, [System.Version]$version, [Switch]$RemovePreviousVersions)

  $Remove = $PSBoundParameters.RemovePreviousVersions
  Do
  {
    $moduleInstalled = Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version} 
    if ($PSCmdlet.ShouldProcess("$module version $version", "Remove module")) 
    {
      if (($null -ne $moduleInstalled) -and ($Remove.IsPresent -or $PSCmdlet.ShouldContinue("Uninstall module $Module version $version", "Uninstall Modules for profile $Profile"))) 
      {
        Write-Verbose "Removing module from session"
        Remove-Module -Name $module -Force -ErrorAction "SilentlyContinue"
        try 
        {
          Write-Verbose "Uninstalling module $module version $version"
          Uninstall-Module -Name $module -RequiredVersion $version -Force -ErrorAction Stop
        }
        catch
        {
          if ($_.Exception.Message -match "No match was found")
          {
            # Check for msi installation (Install folder: C:\ProgramFiles(x86)\Microsoft SDKs\Azure\PowerShell) Only in windows
            if ((-not $Script:IsCoreEdition) -or ($IsWindows))
            {
              $sdkPath1 = (join-path ${env:ProgramFiles(x86)} -childpath "\Microsoft SDKs\Azure\PowerShell\")
              $sdkPath2 = (join-path $script:ProgramFilesPSPath -childpath "\Microsoft SDKs\Azure\PowerShell\")
              if (($null -ne $moduleInstalled.Path) -and (($moduleInstalled.Path.Contains($sdkPath1) -or $moduleInstalled.Path.Contains($sdkPath2))))
              {
                Write-Error "Unable to uninstall module $module because it was installed in a different scope than expected. If you installed via an MSI, please uninstall the MSI before proceeding." -Category InvalidOperation
                break 
              }
            }
            Write-Error "Unable to uninstall module $module because it was installed in a different scope than expected. If you installed the module to a custom directory in your path, please remove the module manually, by using Uninstall-Module, or removing the module directory." -Category InvalidOperation
          }
          else {
            Write-Error $_.Exception.Message
          }
          break
        }
      }
      else {
        break
      }
    }
    else {
      break
    }
  }
  While($null -ne $moduleInstalled);
}

# Help function to uninstall a profile
function Uninstall-ProfileHelper
{
  [CmdletBinding()]
  param([PSObject]$PMap, [String]$Profile, [Switch]$Force)
  $modules = ($PMap.$Profile | Get-Member -MemberType NoteProperty).Name

  # Get-Profiles installed across all hashes. This is to avoid uninstalling modules that are part of other installed profiles
  $AllProfilesInstalled = Get-AllProfilesInstalled

  foreach ($module in $modules)
  {
    $versionList = $PMap.$Profile.$module
    foreach ($version in $versionList)
    {
      if ($Force.IsPresent)
      {
        Invoke-UninstallModule -PMap $PMap -Profile $Profile -Module $module -version $version -AllProfilesInstalled $AllProfilesInstalled -RemovePreviousVersions
      }
      else {
        Invoke-UninstallModule -PMap $PMap -Profile $Profile -Module $module -version $version -AllProfilesInstalled $AllProfilesInstalled 
      }
    }
  }
}

# Checks if the module is part of other installed profiles. Calls Uninstall-ModuleHelper if not.
function Invoke-UninstallModule
{
  [CmdletBinding()]
  param([PSObject]$PMap, [String]$Profile, $Module, [System.Version]$version, [hashtable]$AllProfilesInstalled, [Switch]$RemovePreviousVersions)

  # Check if the profiles associated with the module version are installed.
  Write-Verbose "Checking module dependency to any other profile installed"
  $profilesAssociated = Test-ProfilesInstalled -version $version -Module $Module -Profile $Profile -PMap $PMap -AllProfilesInstalled $AllProfilesInstalled
      
  # If more than one profile is installed for the same version of the module, do not uninstall
  if ($profilesAssociated.Count -gt 1) 
  {
    return
  }

  $PSBoundParameters.Remove('AllProfilesInstalled') | Out-Null
  $PSBoundParameters.Remove('PMap') | Out-Null

  Uninstall-ModuleHelper @PSBoundParameters
}

# Helps to uninstall previous versions of modules in the profile
function Remove-PreviousVersion
{
  [CmdletBinding()]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseShouldProcessForStateChangingFunctions", "")]
  param([PSObject]$LatestMap, [hashtable]$AllProfilesInstalled, [String]$Profile, [Array]$Module, [Switch]$RemovePreviousVersions)

  $Remove = $PSBoundParameters.RemovePreviousVersions
  $Modules = $PSBoundParameters.Module

  Write-Verbose "Checking if previous versions of modules are installed"

  if ($null -eq $Modules)
  {
    $Modules = ($LatestMap.$Profile | Get-Member -MemberType NoteProperty).Name
  }

  foreach ($module in $Modules)
  {   
    # Skip the latest version; first element will be the latest version
    $versionList = $LatestMap.$Profile.$module
    $versionList = $versionList | Where-Object { $_ -ne $versionList[0] }
    foreach ($version in $versionList)
    {
      # Is that module version installed? If not skip; 
      if ($null -eq (Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version} ))
      {
        continue
      }

      Write-Verbose "Previous versions of modules were found. Trying to uninstall..."
      if ($Remove.IsPresent)
      {
        Invoke-UninstallModule -PMap $LatestMap -Profile $Profile -Module $module -version $version -AllProfilesInstalled $AllProfilesInstalled -RemovePreviousVersions
      }
      else {
        Invoke-UninstallModule -PMap $LatestMap -Profile $Profile -Module $module -version $version -AllProfilesInstalled $AllProfilesInstalled         
      }
    }
      
    # Uninstall removes module from session; import latest version again
    $versions = $LatestMap.$Profile.$module
    $version = Get-LatestModuleVersion -versions $versions
    Import-Module $Module -RequiredVersion $version -Global
  }
}

# Gets profiles installed as @{Module+Version = @(profile)} for checking module dependency during uninstall
function Get-AllProfilesInstalled
{
  $AllProfilesInstalled = @{}
  # If Cache is empty, use embedded source
  if ($null -eq $script:LatestProfileMapPath)
  {
    $ModulePath = [System.IO.Path]::GetDirectoryName($PSCommandPath)
    $script:LatestProfileMapPath = Get-Item -Path (Join-Path -Path $ModulePath -ChildPath "ProfileMap.json")
  }

  $scriptBlock = {
    Get-Content -Raw -Path $script:LatestProfileMapPath.FullName -ErrorAction stop | ConvertFrom-Json 
  }
  $ProfileMap = Invoke-CommandWithRetry -ScriptBlock $scriptBlock 
  $profilesInstalled = (Get-ProfilesInstalled -ProfileMap $ProfileMap)
  foreach ($Profile in $profilesInstalled.Keys)
  { 
    foreach ($module in ($profilesinstalled.$profile.Keys)) 
    {
      $versionList = $profilesinstalled.$Profile.$Module
      foreach ($version in $versionList)
      {
        if ($AllProfilesInstalled.ContainsKey(($Module + $version)))
        {
          if ($Profile -notin $AllProfilesInstalled[($Module + $version)])
          {
            $AllProfilesInstalled[($Module + $version)] += $Profile
          }
        }
        else {
          $AllProfilesInstalled.Add(($Module + $version), @($Profile))
        }
      }
    }
  }
  return $AllProfilesInstalled
}

# Helps to remove-previous versions of the update-profile and clean up cache
function Update-ProfileHelper
{
  [CmdletBinding()]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseShouldProcessForStateChangingFunctions", "")]
  param([String]$Profile, [Array]$Module, [Switch]$RemovePreviousVersions)

  Write-Verbose "Attempting to clean up previous versions"

  # Cache was updated before calling this function, so latestprofilemap will not be null. 
  $scriptBlock = {
    Get-Content -Raw -Path $script:LatestProfileMapPath.FullName -ErrorAction stop | ConvertFrom-Json 
  }
  $LatestProfileMap = Invoke-CommandWithRetry -ScriptBlock $scriptBlock 

  $AllProfilesInstalled = Get-AllProfilesInstalled
  Remove-PreviousVersion -LatestMap $LatestProfileMap -AllProfilesInstalled $AllProfilesInstalled @PSBoundParameters
}

# If cmdlets were installed at a different scope, warn users of the potential conflict
function Find-PotentialConflict
{
  [CmdletBinding(SupportsShouldProcess = $true)] 
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "")]
  param([string]$Module, [switch]$Force)
  
  Write-Verbose "Checking if there is a potential conflict for module installation"
  $availableModules = Get-Module $Module -ListAvailable
  $IsPotentialConflict = $false

  Write-Information "Modules installed: $availableModules"

  if ($null -eq $availableModules)
  {
    return $false
  }

  # If Admin, check CurrentUser Module folder path and vice versa
  if ($script:IsAdmin)
  {
    $availableModules | ForEach-Object { if (($null -ne $_.Path) -and $_.Path.Contains($HOME)) { $IsPotentialConflict = $true } }
  }
  else { 
    $availableModules | ForEach-Object { if (($null -ne $_.Path) -and $_.Path.Contains($script:ProgramFilesPSPath)) { $IsPotentialConflict = $true } }
  }

  # If potential conflict found, confirm with user for continuing with module installation if 'force' was not used
  if ($IsPotentialConflict)
  {
    if (($Force.IsPresent) -or ($PSCmdlet.ShouldContinue(`
      "The Cmdlets from module $Module are already present on this device. Proceeding with the installation might cause conflicts. Would you like to continue?", "Detected $Module cmdlets")))
    {
      return $false
    }
    else 
    {
      return $true
    }
  }

  # False if no conflict was found
  return $false 
}

# Helper function to invoke install-module
function Invoke-InstallModule
{
  param($module, $version, $scope)
  $installCmd = Get-Command Install-Module
  if($installCmd.Parameters.ContainsKey('AllowClobber'))
  {
    if (-not $scope)
    {
      Install-Module $Module -RequiredVersion $version -AllowClobber -Repository $script:BootStrapRepo
    }
    else {
      Install-Module $Module -RequiredVersion $version -Scope $scope -AllowClobber -Repository $script:BootStrapRepo
    }
  }
  else {
     if (-not $scope)
    {
      Install-Module $Module -RequiredVersion $version -Force -Repository $script:BootStrapRepo
    }
    else {
      Install-Module $Module -RequiredVersion $version -Scope $scope -Force -Repository $script:BootStrapRepo
    }
  }
}

# Invoke any script block with a retry logic
function Invoke-CommandWithRetry
{
  [CmdletBinding()]
  [OutputType([PSObject])]
  Param
  (
    [Parameter(Mandatory=$true,
      ValueFromPipelineByPropertyName=$true,
      Position=0)]
      [System.Management.Automation.ScriptBlock]
      $ScriptBlock,

    [Parameter(Position=1)]
      [ValidateNotNullOrEmpty()]
      [int]$MaxRetries=3,

    [Parameter(Position=2)]
      [ValidateNotNullOrEmpty()]
      [int]$RetryDelay=3
  )

  Begin
  {
    $currentRetry = 1
    $Success = $False
  }

  Process
  {
    do {
      try
      {
        $result = . $ScriptBlock
        $success = $true
        return $result
      }
      catch
      {
        $currentRetry = $currentRetry + 1
        if ($currentRetry -gt $MaxRetries) {
          $PSCmdlet.ThrowTerminatingError($PSitem)
        }
        else {
          Write-verbose -Message "Waiting $RetryDelay second(s) before attempting again"
          Start-Sleep -seconds $RetryDelay
        }
      }
    } while(-not $Success)
  }
}

# Select profile according to scope & create if it doesn't exist
function Select-Profile
{ 
  param([string]$scope)
  if($scope -eq "AllUsers" -and (-not $script:IsAdmin))
  {
    Write-Error "Administrator rights are required to use AllUsers scope. Log on to the computer with an account that has Administrator rights, and then try again, or retry the operation by adding `"-Scope CurrentUser`" to your command. You can also try running the Windows PowerShell session with elevated rights (Run as Administrator). " -Category InvalidArgument -ErrorAction Stop
  }

  if($scope -eq "AllUsers")
  {
    $profilePath = $profile.AllUsersAllHosts
  }
  else {
    $profilePath = $profile.CurrentUserAllHosts
  }
  if (-not (Test-Path $ProfilePath))
  {
    new-item -path $ProfilePath -itemtype file -force | Out-Null
  }
  return $profilePath
}

# Get the latest version of a module in a profile
function Get-LatestModuleVersion
{
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "")]
  param ([array]$versions)

  $versionEnum = $versions.GetEnumerator()
  $toss = $versionEnum.MoveNext()
  $version = $versionEnum.Current
  return $version
}

# Gets module version to be set in default parameter in $profile
function Get-ModuleVersion
{
  param ([string] $armProfile, [string] $invocationLine)

  if (-not $invocationLine.ToLower().Contains("azure"))
  {
    return
  }

  $ProfileMap = (Get-AzProfile)
  $Modules = ($ProfileMap.$armProfile | Get-Member -MemberType NoteProperty).Name
    
  # Check for AzureRm first 
  if ($invocationLine.ToLower().Contains($RollUpModule.ToLower()) -and (-not $invocationLine.ToLower().Contains("$($RollUpModule.ToLower())."))) 
  {
    $versions = $ProfileMap.$armProfile.$RollUpModule
    $version = Get-LatestModuleVersion -versions $versions
    return $version
  }

  foreach ($module in $Modules)
  {
    if ($module -eq $RollUpModule)
    {
      continue
    }

    if ($invocationLine.ToLower().Contains($module.ToLower())) 
    {
      $versions = $ProfileMap.$armProfile.$module
      $version = Get-LatestModuleVersion -versions $versions
      return $version
    }
  }
}

# Create a script block with function to be called to get requiredversions for use with default parameters
function Get-ScriptBlock
{
  param ($ProfilePath)
  
  $profileContent = @()

  # Write Get-ModuleVersion function to $profile path 
  $functionScript = @"
function Get-ModVersion
{
  param (`$armProfile, `$invocationLine)
  if (-not `$invocationLine.ToLower().Contains("azure"))
  {
    return
  }
  try 
  {
    `$BootstrapModule = Get-Module -Name "AzureRM.Bootstrapper" -ListAvailable
    if (`$null -ne `$BootstrapModule)
    {
      Import-Module -Name "AzureRM.Bootstrapper" -RequiredVersion `$BootstrapModule.Version[0]
      `$version = Get-ModuleVersion -armProfile `$armProfile -invocationLine `$invocationLine
      return `$version
    }
  }
  catch
  {
    return
  }
} `r`n
"@
  
  $profileContent += $functionScript

  $defaultScript = @"
`$PSDefaultParameterValues["Import-Module:RequiredVersion"]={ Get-ModVersion -armProfile `$PSDefaultParameterValues["*-AzureRmProfile:Profile"] -invocationLine `$MyInvocation.Line }
########## END AzureRM.Bootstrapper scripts
"@
  $profileContent += $defaultScript
  return $profileContent
}

function Remove-ProfileSetting
{
  [CmdletBinding(SupportsShouldProcess=$true)]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "")]
  param ([string] $profilePath)

  $RemoveSettingScriptBlock = {
    $reqLines = @()
    Get-Content -Path $profilePath -ErrorAction Stop | 
      Foreach-Object { 
        if($_.contains("BEGIN AzureRM.Bootstrapper scripts") -or $donotread)
        {
          $donotread = $true; 
        } 
        else 
        { 
          $reqLines += $_ 
        }
        if ($_.contains("END AzureRM.Bootstrapper scripts"))
        { 
          $donotread = $false 
        }
      }

      if ($PSCmdlet.ShouldProcess($reqLines, "Updating `$profile conents"))
      {
        Set-Content -path $profilePath -Value $reqLines -ErrorAction Stop 
      }
  }
  
  Invoke-CommandWithRetry -ScriptBlock $RemoveSettingScriptBlock
}

# Add Scope parameter to the cmdlet
function Add-ScopeParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $Keys = @('CurrentUser', 'AllUsers')
  $scopeValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($Keys)
  $scopeAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $scopeAttribute.ParameterSetName = 
  $scopeAttribute.Mandatory = $false
  $scopeAttribute.Position = 2
  $scopeCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $scopeCollection.Add($scopeValid)
  $scopeCollection.Add($scopeAttribute)
  $scopeParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Scope", [string], $scopeCollection)
  $params.Add("Scope", $scopeParam)
}

# Add the profile parameter to the cmdlet
function Add-ProfileParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $ProfileMap = (Get-AzProfile)
  $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
  $profileAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $profileAttribute.ParameterSetName = $set
  $profileAttribute.Mandatory = $true
  $profileAttribute.Position = 0
  $profileAttribute.ValueFromPipeline = $true
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

function Add-ModuleParam
{
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "")]
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$name, [string] $set = "__AllParameterSets")
  $ProfileMap = (Get-AzProfile)
  $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
  if ($Profiles.Count -gt 1)
  {
    $enum = $Profiles.GetEnumerator()
    $toss = $enum.MoveNext()
    $Current = $enum.Current
    $Keys = ($($ProfileMap.$Current) | Get-Member -MemberType NoteProperty).Name
  }
  else {
    $Keys = ($($ProfileMap.$Profiles[0]) | Get-Member -MemberType NoteProperty).Name
  }
  $moduleValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($Keys)
  $AllowNullAttribute = New-Object -Type System.Management.Automation.AllowNullAttribute
  $AllowEmptyStringAttribute = New-Object System.Management.Automation.AllowEmptyStringAttribute
  $moduleAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $moduleAttribute.ParameterSetName = 
  $moduleAttribute.Mandatory = $false
  $moduleAttribute.Position = 1
  $moduleCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $moduleCollection.Add($moduleValid)
  $moduleCollection.Add($moduleAttribute)
  $moduleCollection.Add($AllowNullAttribute)
  $moduleCollection.Add($AllowEmptyStringAttribute)
  $moduleParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Module", [array], $moduleCollection)
  $params.Add("Module", $moduleParam)
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Get-AzureRmModule 
{
  [CmdletBinding()]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "")]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    $ProfileMap = (Get-AzProfile)
    $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    if ($Profiles.Count -gt 1)
    {
      $enum = $Profiles.GetEnumerator()
      $toss = $enum.MoveNext()
      $Current = $enum.Current
      $Keys = ($($ProfileMap.$Current) | Get-Member -MemberType NoteProperty).Name
    }
    else {
      $Keys = ($($ProfileMap.$Profiles[0]) | Get-Member -MemberType NoteProperty).Name
    }
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
    $Profile = $PSBoundParameters.Profile
    $Module = $PSBoundParameters.Module
    $versionList = $ProfileMap.$Profile.$Module
    Write-Verbose "Getting the version of $module from $profile"
    $moduleList = Get-Module -Name $Module -ListAvailable | Where-Object {$null -ne $_.RepositorySourceLocation}
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
    $PSBoundParameters.Remove('ListAvailable') | Out-Null
    $ProfileMap = (Get-AzProfile @PSBoundParameters)
    if ($ListAvailable.IsPresent)
    {
      Write-Verbose "Getting all the profiles available for install"
      foreach ($profile in ($ProfileMap | get-member -MemberType NoteProperty).Name)
      {
        $profileObj = $ProfileMap.$profile
        $profileObj | Add-Member -MemberType NoteProperty -Name "ProfileName" -Value $profile
        $profileObj | Add-Member -TypeName ProfileMapData 
        $profileObj
      }
      return
    }
    else
    {
      # Just display profiles installed on the machine
      Write-Verbose "Getting profiles installed on the machine and available for import"
      $IncompleteProfiles = @()
      $profilesInstalled = Get-ProfilesInstalled -ProfileMap $ProfileMap ([REF]$IncompleteProfiles)
      foreach ($key in $profilesInstalled.Keys)
      {      
        $profileObj = New-Object -TypeName psobject -property $profilesinstalled.$key
        $profileObj.PSObject.TypeNames.Insert(0,'ProfileMapData')
        $profileObj | Add-Member -MemberType NoteProperty -Name "ProfileName" -Value $key
        $profileObj
      }
      if ($IncompleteProfiles.Count -gt 0)
      {
        Write-Warning "Some modules from profile(s) $(@($IncompleteProfiles) -join ', ') were not installed. Use Install-AzureRmProfile to install missing modules."
      }
      return
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Use-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess=$true)] 
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSAvoidShouldContinueWithoutForce", "")]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-ScopeParam $params
    Add-ModuleParam $params
    return $params
  }
  PROCESS 
  {
    $Force = $PSBoundParameters.Force
    $ProfileMap = (Get-AzProfile)
    $Profile = $PSBoundParameters.Profile
    $Scope = $PSBoundParameters.Scope
    $Modules = $PSBoundParameters.Module

    # If user hasn't provided modules, use the module names from profile
    if ($null -eq $Modules)
    {
      $Modules = ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name
    }

    # If AzureRM $RollUpModule is present in that profile, it will install all the dependent modules; no need to specify other modules
    if ($Modules.Contains($RollUpModule))
    {
      $Modules = @($RollUpModule)
    }
    
    $PSBoundParameters.Remove('Profile') | Out-Null
    $PSBoundParameters.Remove('Scope') | Out-Null
    $PSBoundParameters.Remove('Module') | Out-Null

    # Variable to track progress
    $ModuleCount = 0
    Write-Output "Loading Profile $Profile"
    foreach ($Module in $Modules)
    {
      $ModuleCount = $ModuleCount + 1
      $version = Get-AzureRmModule -Profile $Profile -Module $Module
      if (($null -eq $version) -and $PSCmdlet.ShouldProcess($module, "Installing module for profile $profile in the current scope"))
      {
        Write-Verbose "$module was not found on the machine. Trying to install..."
        if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Install Module $module for Profile $Profile from the gallery?", "Installing Modules for Profile $Profile")))
        {
          if (Find-PotentialConflict -Module $Module @PSBoundParameters) 
          {
            continue
          }
          $versions = $ProfileMap.$Profile.$Module
          $version = Get-LatestModuleVersion -versions $versions
          Write-Progress -Activity "Installing Module $Module version: $version" -Status "Progress:" -PercentComplete ($ModuleCount/($Modules.Length)*100)
          Write-Verbose "Installing module $module"
          Invoke-InstallModule -module $Module -version $version -scope $scope
        }
      }

      # If a different profile's Azure Module was imported, block user
      $importedModules = Get-Module "Azure*"
      foreach ($importedModule in $importedModules) 
      {
        $importedVersions = $ProfileMap.$Profile.$($importedModule.Name)
        if ($null -ne $importedVersions)
        {
          # We need the latest version in that profile to be imported. If old version was imported, block user and ask to import in a new session
          $importedVersion = Get-LatestModuleVersion -versions $importedVersions
          if ([system.version]$importedVersion -ne $importedModule.Version)
          {
            Write-Error "A different profile version of module $importedModule is imported in this session. Start a new PowerShell session and retry the operation." -Category  InvalidOperation 
            return
          }
        }
      }

      if ($PSCmdlet.ShouldProcess($module, "Importing module for profile $profile in the current scope"))
      {
        Write-Verbose "Importing module $module"
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
  [CmdletBinding(SupportsShouldProcess=$true)]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ScopeParam $params
    Add-ForceParam $params
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile)
    $Profile = $PSBoundParameters.Profile
    $Scope = $PSBoundParameters.Scope
    $Modules = ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name

    # If AzureRM $RollUpModule is present in $profile, it will install all the dependent modules; no need to specify other modules
    if ($Modules.Contains($RollUpModule))
    {
      $Modules = @($RollUpModule)
    }
      
    $PSBoundParameters.Remove('Profile') | Out-Null
    $PSBoundParameters.Remove('Scope') | Out-Null

    $ModuleCount = 0
    foreach ($Module in $Modules)
    {
      $ModuleCount = $ModuleCount + 1
      if (Find-PotentialConflict -Module $Module @PSBoundParameters) 
      {
        continue
      }

      $version = Get-AzureRmModule -Profile $Profile -Module $Module
      if ($null -eq $version) 
      {
        $versions = $ProfileMap.$Profile.$Module
        $version = Get-LatestModuleVersion -versions $versions
        if ($PSCmdlet.ShouldProcess($Module, "Installing Module $Module version: $version"))
        {
          Write-Progress -Activity "Installing Module $Module version: $version" -Status "Progress:" -PercentComplete ($ModuleCount/($Modules.Length)*100)
          Write-Verbose "Installing module $module" 
          Invoke-InstallModule -module $Module -version $version -scope $scope
        }
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
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSAvoidShouldContinueWithoutForce", "")]
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
    $Profile = $PSBoundParameters.Profile
    $Force = $PSBoundParameters.Force

    if ($PSCmdlet.ShouldProcess("$Profile", "Uninstall Profile")) 
    {
      if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Uninstall Profile $Profile", "Removing Modules for profile $Profile")))
      {
        Write-Verbose "Trying to uninstall profile $profile"
        Uninstall-ProfileHelper -PMap $ProfileMap @PSBoundParameters
      }
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Update-AzureRmProfile
{
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "")]
  [CmdletBinding(SupportsShouldProcess = $true)]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-RemoveParam $params 
    Add-ModuleParam $params
    Add-ScopeParam $params
    return $params
  }

  PROCESS {
    # Update Profile cache, if not up-to-date
    $ProfileMap = (Get-AzProfile -Update)
    $profile = $PSBoundParameters.Profile
    $Remove = $PSBoundParameters.RemovePreviousVersions

    $PSBoundParameters.Remove('RemovePreviousVersions') | Out-Null

    # Install & import the required version
    Use-AzureRmProfile @PSBoundParameters
    
    $PSBoundParameters.Remove('Force') | Out-Null
    $PSBoundParameters.Remove('Scope') | Out-Null

    # Remove previous versions of the profile?
    if ($Remove.IsPresent -and $PSCmdlet.ShouldProcess($profile, "Remove previous versions of profile")) 
    {
      # Remove-PreviousVersions and clean up cache
      Update-ProfileHelper @PSBoundParameters -RemovePreviousVersions
    }
  }
}

function Set-BootstrapRepo
{
	[CmdletBinding()]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseShouldProcessForStateChangingFunctions", "")]
	param([string]$Repo)
	$script:BootStrapRepo = $Repo
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Set-AzureRmDefaultProfile
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSAvoidShouldContinueWithoutForce", "")]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-ScopeParam $params
    return $params
  }
  PROCESS {
    $armProfile = $PSBoundParameters.Profile
    $Scope = $PSBoundParameters.Scope
    $Force = $PSBoundParameters.Force

    $defaultProfile = $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"]
    if ($defaultProfile -ne $armProfile)
    {
      if ($PSCmdlet.ShouldProcess("$armProfile", "Set Default Profile")) 
      {
        if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Are you sure you would like to set $armProfile as Default Profile?", "Setting $armProfile as Default profile")))
        {
          # Check Profile existence and choose proper profile
          $profilePath = Select-Profile -Scope $Scope

          # Set DefaultProfile for this session
          $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"]="$armProfile"
          $Global:PSDefaultParameterValues["Import-Module:RequiredVersion"]={ Get-ModuleVersion -armProfile $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"] -invocationLine $MyInvocation.Line }

          # Edit the profile content
          $profileContent = @"
########## BEGIN AzureRM.Bootstrapper scripts
`$PSDefaultParameterValues["*-AzureRmProfile:Profile"]="$armProfile" `r`n
"@

          # Get Script to be added to the $profile path
          $profileContent += Get-ScriptBlock -ProfilePath $profilePath

          Write-Verbose "Updating default profile value to $armProfile"
          Write-Debug "Removing previous setting if exists"
          Remove-ProfileSetting -profilePath $profilePath

          Write-Debug "Adding new default profile value as $armProfile"
          $AddContentScriptBlock = {
            Add-Content -Value $profileContent -Path $profilePath -ErrorAction Stop
          }  
          Invoke-CommandWithRetry -ScriptBlock $AddContentScriptBlock
        }
      }
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Remove-AzureRmDefaultProfile
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSAvoidShouldContinueWithoutForce", "")]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ForceParam $params
    return $params
  }
  PROCESS {
    $Force = $PSBoundParameters.Force

    if ($PSCmdlet.ShouldProcess("ARM Default Profile", "Remove Default Profile")) 
    {
      if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Are you sure you would like to remove Default Profile?", "Remove Default profile")))
      {
        Write-Verbose "Removing default profile value"
        $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
        $Global:PSDefaultParameterValues.Remove("Import-Module:RequiredVersion")
        
        # Remove AzureRm modules except bootstrapper module
        $importedModules = Get-Module "Azure*"
        foreach ($importedModule in $importedModules) 
        {
          if ($importedModule.Name -eq "AzureRM.Bootstrapper")
          {
            continue
          }
          Remove-Module -Name $importedModule -Force -ErrorAction "SilentlyContinue"
        }

        # Remove content from $profile
        $profiles = @()
        if ($script:IsAdmin)
        {
          $profiles += $profile.AllUsersAllHosts
        }
        
        $profiles += $profile.CurrentUserAllHosts
        
        foreach ($profilePath in $profiles)
        {
          if (-not (Test-Path -path $profilePath))
          {
            continue
          }

          Remove-ProfileSetting -profilePath $profilePath
        }
      }
    }
  }
}