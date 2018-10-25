#########################################################################################
#
# Copyright (c) Microsoft Corporation. All rights reserved.
#
# Licensed under the MIT license.
#
# PSSwaggerUtility Module
#
#########################################################################################
Microsoft.PowerShell.Core\Set-StrictMode -Version Latest
Microsoft.PowerShell.Utility\Import-LocalizedData  LocalizedData -filename PSSwaggerUtility.Resources.psd1

<#
.DESCRIPTION
  Gets the content of a file. Removes the signature block, if it exists.

.PARAMETER Path
  Path to the file whose contents should be read.
#>
function Remove-AuthenticodeSignatureBlock {
    param(
        [Parameter(Mandatory=$true)]
        [string]$Path
    )

    $content = Get-Content -Path $Path
    $skip = $false
    foreach ($line in $content) {
        if ($line -eq "# SIG # Begin signature block") {
            $skip = $true
        } elseif ($line -eq "# SIG # End signature block") {
            $skip = $false
        } elseif (-not $skip) {
            $line
        }
    }
}

<#
.DESCRIPTION
  Gets the list of required modules to be imported for the scriptblock.

.PARAMETER  ModuleInfo
  PSModuleInfo object of the Swagger command.
#>
function Get-RequiredModulesPath
{
    param(
        [Parameter(Mandatory=$true)]
        [System.Management.Automation.PSModuleInfo]
        $ModuleInfo
    )

    $ModulePaths = @()
    $ModulePaths += $ModuleInfo.RequiredModules | ForEach-Object { Get-RequiredModulesPath -ModuleInfo $_}

    $ManifestPath = Join-Path -Path (Split-Path -Path $ModuleInfo.Path -Parent) -ChildPath "$($ModuleInfo.Name).psd1"
    if(Test-Path -Path $ManifestPath)
    {
        $ModulePaths += $ManifestPath
    }
    else
    {
        $ModulePaths += $ModuleInfo.Path
    }

    return $ModulePaths | Select-Object -Unique
}

<#
.DESCRIPTION
  Invokes the specified script block as PSSwaggerJob.

.PARAMETER  ScriptBlock
  ScriptBlock to be executed in the PSSwaggerJob

.PARAMETER  CallerPSCmdlet
  Called $PSCmldet object to set the failure status.

.PARAMETER  CallerPSBoundParameters
  Parameters to be passed into the specified script block.

.PARAMETER  CallerModule
  PSModuleInfo object of the Swagger command.
#>
function Start-PSSwaggerJobHelper
{
    param(
        [Parameter(Mandatory=$true)]
        [System.Management.Automation.ScriptBlock]
        $ScriptBlock,

        [Parameter(Mandatory=$false)]
        [System.Management.Automation.PSCmdlet]
        $CallerPSCmdlet,

        [Parameter(Mandatory=$true)]
        $CallerPSBoundParameters,

        [Parameter(Mandatory=$false)]
        [System.Management.Automation.PSModuleInfo]
        $CallerModule
    )

    $AsJob = $false
    if($CallerPSBoundParameters.ContainsKey('AsJob'))
    {
        $AsJob = $true
    }

    $null = $CallerPSBoundParameters.Remove('WarningVariable')
    $null = $CallerPSBoundParameters.Remove('ErrorVariable')
    $null = $CallerPSBoundParameters.Remove('OutVariable')
    $null = $CallerPSBoundParameters.Remove('OutBuffer')
    $null = $CallerPSBoundParameters.Remove('PipelineVariable')
    $null = $CallerPSBoundParameters.Remove('InformationVariable')
    $null = $CallerPSBoundParameters.Remove('InformationAction')
    $null = $CallerPSBoundParameters.Remove('AsJob')

    $PSSwaggerJobParameters = @{}
    $PSSwaggerJobParameters['ScriptBlock'] = $ScriptBlock

    # Required modules list
    if ($CallerModule)
    {
        $PSSwaggerJobParameters['RequiredModules'] = Get-RequiredModulesPath -ModuleInfo $CallerModule
    }

    $VerbosePresent = $false
    if (-not $CallerPSBoundParameters.ContainsKey('Verbose'))
    {
        if($VerbosePreference -in 'Continue','Inquire')
        {
            $CallerPSBoundParameters['Verbose'] = [System.Management.Automation.SwitchParameter]::Present
            $VerbosePresent = $true
        }
    }
    else
    {
        $VerbosePresent = $true
    }

    $DebugPresent = $false
    if (-not $CallerPSBoundParameters.ContainsKey('Debug'))
    {
        if($debugPreference -in 'Continue','Inquire')
        {
            $CallerPSBoundParameters['Debug'] = [System.Management.Automation.SwitchParameter]::Present
            $DebugPresent = $true
        }
    }
    else
    {
        $DebugPresent = $true
    }

    if (-not $CallerPSBoundParameters.ContainsKey('ErrorAction'))
    {
        $CallerPSBoundParameters['ErrorAction'] = $errorActionPreference
    }

    if(Test-Path variable:\errorActionPreference)
    {
        $errorAction = $errorActionPreference
    }
    else
    {
        $errorAction = 'Continue'
    }

    if ($CallerPSBoundParameters['ErrorAction'] -eq 'SilentlyContinue')
    {
        $errorAction = 'SilentlyContinue'
    }

    if($CallerPSBoundParameters['ErrorAction'] -eq 'Ignore')
    {
        $CallerPSBoundParameters['ErrorAction'] = 'SilentlyContinue'
        $errorAction = 'SilentlyContinue'
    }

    if ($CallerPSBoundParameters['ErrorAction'] -eq 'Inquire')
    {
        $CallerPSBoundParameters['ErrorAction'] = 'Continue'
        $errorAction = 'Continue'
    }

    if (-not $CallerPSBoundParameters.ContainsKey('WarningAction'))
    {
        $CallerPSBoundParameters['WarningAction'] = $warningPreference
    }

    if(Test-Path variable:\warningPreference)
    {
        $warningAction = $warningPreference
    }
    else
    {
        $warningAction = 'Continue'
    }

    if ($CallerPSBoundParameters['WarningAction'] -in 'SilentlyContinue','Ignore')
    {
        $warningAction = 'SilentlyContinue'
    }

    if ($CallerPSBoundParameters['WarningAction'] -eq 'Inquire')
    {
        $CallerPSBoundParameters['WarningAction'] = 'Continue'
        $warningAction = 'Continue'
    }

    if($CallerPSBoundParameters)
    {
        $PSSwaggerJobParameters['Parameters'] = $CallerPSBoundParameters
    }

    $job = Start-PSSwaggerJob @PSSwaggerJobParameters

    if($job)
    {
        if($AsJob)
        {
            $job
        }
        else
        {
            try
            {
                Receive-Job -Job $job -Wait -Verbose:$VerbosePresent -Debug:$DebugPresent -ErrorAction $errorAction -WarningAction $warningAction

                if($CallerPSCmdlet)
                {
                    $CallerPSCmdlet.InvokeCommand.HasErrors = $job.State -eq 'Failed'
                }
            }
            finally
            {
                if($job.State -ne "Suspended" -and $job.State -ne "Stopped")
                {
                    Get-Job -Id $job.Id -ErrorAction Ignore | Remove-Job -Force -ErrorAction Ignore
                }
                else
                {
                    $job
                }
            }
        }
    }
}

<#
.DESCRIPTION
  Gets operating system information. Returns an object with the following boolean properties: IsCore, IsLinux, IsWindows, IsMacOS, IsNanoServer, IsIoT
#>
function Get-OperatingSystemInfo {
    $info = @{
        IsCore = $false
        IsLinux = $false
        IsMacOS = $false
        IsWindows = $false
        IsNanoServer = $false
        IsIoT = $false
    }

    if ('System.Management.Automation.Platform' -as [Type]) {
        $info.IsCore = [System.Management.Automation.Platform]::IsCoreCLR
        $info.IsLinux = [System.Management.Automation.Platform]::IsLinux
        $info.IsMacOS = [System.Management.Automation.Platform]::IsMacOS
        $info.IsWindows = [System.Management.Automation.Platform]::IsWindows
        $info.IsNanoServer = [System.Management.Automation.Platform]::IsNanoServer
        $info.IsIoT = [System.Management.Automation.Platform]::IsIoT
    } else {
        # If this type doesn't exist, this should be full CLR Windows
        $info.IsWindows = $true
    }

    return $info
}

<#
.DESCRIPTION
  Gets the platform-specific directory for the given DirectoryType. Shared is a non-XDG concept for all-users access. Caller is expected to handle creation, deletion, and permissions.
  Note that this does NOT mean that PSSwagger follows the XDG specification on non-Windows systems exactly.

.PARAMETER  DirectoryType
  Type of directory to resolve.
#>
function Get-XDGDirectory {
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('Config', 'Data', 'Cache', 'Shared')]
        [string]
        $DirectoryType
    )

    if ((Get-OperatingSystemInfo).IsWindows) {
        # Windows filesystem is not included in the XDG specification
        if ('Shared' -eq $DirectoryType) {
            return Microsoft.PowerShell.Management\Join-Path -Path $env:ProgramData -ChildPath 'Microsoft' | Join-Path -ChildPath 'Windows' | Join-Path -ChildPath 'PowerShell'
        } elseif ('Cache' -eq $DirectoryType) {
            return ([System.IO.Path]::GetTempPath())
        } else {
            return Microsoft.PowerShell.Management\Join-Path -Path $env:LOCALAPPDATA -ChildPath 'Microsoft' | Join-Path -ChildPath 'Windows' | Join-Path -ChildPath 'PowerShell'
        }
    } else {
        # The rest should follow: https://specifications.freedesktop.org/basedir-spec/basedir-spec-latest.html
        $dirHome = $null
        $dirDefault = $null
        $homeVar = Get-EnvironmentVariable -Name "HOME"
        if ('Config' -eq $DirectoryType) {
            $dirHome = Get-EnvironmentVariable -Name "XDG_CONFIG_HOME"
            $dirDefault = Join-Path -Path "$homeVar" -ChildPath ".config"
        } elseif ('Data' -eq $DirectoryType) {
            $dirHome = Get-EnvironmentVariable -Name "XDG_DATA_HOME"
            $dirDefault = Join-Path -Path "$homeVar" -ChildPath ".local" | Join-Path -ChildPath "share"
        } elseif ('Cache' -eq $DirectoryType) {
            $dirHome = Get-EnvironmentVariable -Name "XDG_CACHE_HOME"
            $dirDefault = Join-Path -Path "$homeVar" -ChildPath ".cache"
        } else {
             # As global access isn't part of the XDG Base Directory Specification, we use PowerShell Core's definition: /usr/local/share
            return '/usr/local/share'
        }

        if (-not $dirHome) {
            return $dirDefault
        }

        return $dirHome
    }
}

<# .DESCRIPTION
  Helper method to get an environment variable.
#>
function Get-EnvironmentVariable {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]
        $Name
    )

    $value = [System.Environment]::GetEnvironmentVariable($Name)
    if (-not $value) {
        # If the variable doesn't exist as an environment variable, check if it exists locally
        $variable = Get-Variable -Name $Name -ErrorAction Ignore
        if ($variable) {
            return $variable.Value
        } else {
            return $value
        }
    }

    return $value
}

#region Compilation utils for PSSwagger

# go fwlink for latest nuget.exe for win10 x86
$script:NuGetClientSourceURL = 'https://go.microsoft.com/fwlink/?linkid=843467'
$script:ProgramDataPath = $null
$script:AppLocalPath = $null

<#
.DESCRIPTION
  Compiles AutoRest generated C# code using the framework of the current PowerShell process.

.PARAMETER  CSharpFiles
  All C# files to compile. Only AutoRest generated code is fully supported.

.PARAMETER  OutputAssembly
  Full Path to the output assembly.

.PARAMETER  NewtonsoftJsonRequiredVersion
  Optional string specifying required version of Newtonsoft.Json package.

.PARAMETER  MicrosoftRestClientRuntimeRequiredVersion
  Optional string specifying required version of Microsoft.Rest.ClientRuntime package.

.PARAMETER  MicrosoftRestClientRuntimeAzureRequiredVersion
  Optional string specifying required version of Microsoft.Rest.ClientRuntime.Azure package. Only used if -CodeCreatedByAzureGenerator is also used.

.PARAMETER  AllUsers
  User wants to install local tools for all users.

.PARAMETER  BootstrapConsent
  User has consented to bootstrap dependencies.

.PARAMETER  TestBuild
  Build binaries for testing (disable compiler optimizations, enable full debug information).

.PARAMETER  CodeCreatedByAzureGenerator
  C# code generated by Azure.CSharp AutoRest code generator.

.PARAMETER  SymbolPath
  Path to store PDB file and matching source file.
#>
function Add-PSSwaggerClientType {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [System.IO.FileInfo[]]
        $CSharpFiles,

        [Parameter(Mandatory=$true)]
        [AllowEmptyString()]
        [string]
        $ClrPath,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $OutputAssemblyName,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $NewtonsoftJsonRequiredVersion,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $MicrosoftRestClientRuntimeRequiredVersion,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $MicrosoftRestClientRuntimeAzureRequiredVersion,

        [Parameter(Mandatory=$false)]
        [switch]
        $AllUsers,

        [Parameter(Mandatory=$false)]
        [switch]
        $BootstrapConsent,

        [Parameter(Mandatory=$false)]
        [switch]
        $TestBuild,

        [Parameter(Mandatory=$false)]
        [switch]
        $CodeCreatedByAzureGenerator,

        [Parameter(Mandatory=$false)]
        [string]
        $SymbolPath
    )

    # Remake the required version map
    $requiredVersionMap = @{}
    if ($NewtonsoftJsonRequiredVersion) {
        $requiredVersionMap['Newtonsoft.Json'] = $NewtonsoftJsonRequiredVersion
    }
    if ($MicrosoftRestClientRuntimeRequiredVersion) {
        $requiredVersionMap['Microsoft.Rest.ClientRuntime'] = $MicrosoftRestClientRuntimeRequiredVersion
    }
    if ($MicrosoftRestClientRuntimeAzureRequiredVersion) {
        $requiredVersionMap['Microsoft.Rest.ClientRuntime.Azure'] = $MicrosoftRestClientRuntimeAzureRequiredVersion
    }

    # Find the reference assemblies to use
    # System refs are expected to exist on the system
    # Extra refs are shipped by PSSwagger
    $systemRefs = @()
    $preprocessorDirectives = @()
    if ((Get-OperatingSystemInfo).IsCore) {
        # Base framework references
        $preprocessorDirectives = @('#define DNXCORE50','#define PORTABLE')
        $systemRefs = @('System.dll',
                        'System.Core.dll',
                        'System.Net.Http.dll',
                        'Microsoft.CSharp.dll',
                        'System.Private.Uri.dll',
                        'System.Runtime.dll',
                        'System.Threading.Tasks.dll',
                        'System.Text.RegularExpressions.dll',
                        'System.Collections.dll',
                        'System.Net.Primitives.dll',
                        'System.Text.Encoding.dll',
                        'System.Linq.dll',
                        'System.Runtime.Serialization.Primitives.dll')
        $externalReferencesFramework = 'netstandard1'
    } else {
        # Base framework references
        $systemRefs = @('System.dll',
                        'System.Core.dll',
                        'System.Net.Http.dll',
                        'System.Net.Http.WebRequest.dll',
                        'System.Runtime.Serialization.dll',
                        'System.Xml.dll')
        $externalReferencesFramework = 'net4'
    }

    # Get dependencies for AutoRest SDK
    $externalReferences = Get-PSSwaggerExternalDependencies -Framework $externalReferencesFramework -Azure:$CodeCreatedByAzureGenerator -RequiredVersionMap $requiredVersionMap

    $AddClientTypeHelperParams = @{
        Path                   = $CSharpFiles | ForEach-Object { $_.FullName }
        AllUsers               = $AllUsers
        BootstrapConsent       = $BootstrapConsent
        PackageDependencies    = $externalReferences
        PreprocessorDirectives = $PreprocessorDirectives
    }
    if ($OutputAssemblyName) {
        $AddClientTypeHelperParams['OutputDirectory']    = $clrPath
        $AddClientTypeHelperParams['OutputAssemblyName'] = $OutputAssemblyName
        $AddClientTypeHelperParams['TestBuild']          = $TestBuild
        $AddClientTypeHelperParams['SymbolPath']         = $SymbolPath
    }
    $HelperResult = Add-PSSwaggerClientTypeHelper @AddClientTypeHelperParams

    $CompilerHelperParams = @{
        ReferencedAssemblies = $systemRefs + $HelperResult['ResolvedPackageReferences']
        SourceCodeFilePath   = $HelperResult['SourceCodeFilePath']
        OutputAssembly       = $HelperResult['OutputAssembly']
        TestBuild            = $TestBuild
    }

    if ((Get-OperatingSystemInfo).IsCore) {
        $addTypeParams = Get-AddTypeParameters @CompilerHelperParams
        Add-Type @addTypeParams
    }
    else {
        $CscArgumentList = Get-CscParameters @CompilerHelperParams
        $output = & 'Csc.exe' $CscArgumentList
        if ($output) {
            Write-Error -ErrorId 'SOURCE_CODE_ERROR' -Message ($output | Out-String)
            return $false
        }
    }

    # Copy the PDB to the symbol path if specified
    if ($HelperResult['OutputAssembly']) {
        # Verify result of assembly compilation
        $outputAssemblyItem = Get-Item -Path $HelperResult['OutputAssembly']
        if ((-not (Test-Path -Path $HelperResult['OutputAssembly'])) -or ($outputAssemblyItem.Length -eq 0kb)) {
            return $false
        }

        if(-not $OutputAssemblyName) {
            Add-Type -Path $outputAssemblyItem
        }
        else {
            $OutputPdbName = "$($outputAssemblyItem.BaseName).pdb"
            if ($SymbolPath -and (Test-Path -Path (Join-Path -Path $ClrPath -ChildPath $OutputPdbName))) {
                $null = Copy-Item -Path (Join-Path -Path $ClrPath -ChildPath $OutputPdbName) -Destination (Join-Path -Path $SymbolPath -ChildPath $OutputPdbName)
            }
        }
    }

    return $true
}

<#
.DESCRIPTION
  Helper function to validate and install the required package dependencies. Also prepares the source code for compilation.

.PARAMETER  Path
  All *.Code.ps1 C# files to compile.

.PARAMETER  OutputDirectory
  Full Path to output directory.

.PARAMETER  OutputAssemblyName
  Optional assembly file name.

.PARAMETER  AllUsers
  User has specified to install package dependencies to global location.

.PARAMETER  BootstrapConsent
  User has consented to bootstrap dependencies.

.PARAMETER  TestBuild
  Build binaries for testing (disable compiler optimizations, enable full debug information).

.PARAMETER  SymbolPath
  Path to store PDB file and matching source file.

.PARAMETER  PackageDependencies
  Map of package dependencies to add as referenced assemblies but don't exist on disk.

.PARAMETER  PreprocessorDirectives
  Preprocessor directives to add to the top of the combined source code file.
#>
function Add-PSSwaggerClientTypeHelper {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false)]
        [string[]]
        $Path,

        [Parameter(Mandatory = $false)]
        [AllowEmptyString()]
        [string]
        $OutputDirectory,

        [Parameter(Mandatory = $false)]
        [AllowEmptyString()]
        [string]
        $OutputAssemblyName,

        [Parameter(Mandatory = $false)]
        [switch]
        $AllUsers,

        [Parameter(Mandatory = $false)]
        [switch]
        $BootstrapConsent,

        [Parameter(Mandatory = $false)]
        [switch]
        $TestBuild,

        [Parameter(Mandatory = $false)]
        [string]
        $SymbolPath,

        [Parameter(Mandatory = $false)]
        [hashtable]
        $PackageDependencies,

        [Parameter(Mandatory = $false)]
        [string[]]
        $PreprocessorDirectives
    )

    $resultObj = @{
        # Full path to resolved package reference assemblies
        ResolvedPackageReferences = @()

        # The expected output assembly full path
        OutputAssembly            = $null

        # The actual source to be emitted
        SourceCode                = $null

        # The file name the returned params expect to exist, if required
        SourceCodeFilePath        = $null
    }

    if (-not $OutputDirectory -or -not $SymbolPath) {
        $TempOutputPath = Join-Path -Path (Get-XDGDirectory -DirectoryType Cache) -ChildPath ([Guid]::NewGuid().Guid)
        $null = New-Item -Path $TempOutputPath -ItemType Directory -Force
    }

    if (-not $SymbolPath) {
        $SymbolPath = $TempOutputPath
    }

    if (-not $OutputDirectory) {
        $OutputDirectory = $TempOutputPath
    }
    elseif (-not (Test-Path -Path $OutputDirectory -PathType Container)) {
        $null = New-Item -Path $OutputDirectory -ItemType Directory -Force
    }

    if (-not $OutputAssemblyName) {
        $OutputAssemblyName = [Guid]::NewGuid().Guid + '.dll'
    }

    # Resolve package dependencies
    if ($PackageDependencies) {
        foreach ($entry in ($PackageDependencies.GetEnumerator() | Sort-Object { $_.Value.LoadOrder })) {
            $reference = $entry.Value
            $resolvedRef = Get-PSSwaggerDependency -PackageName $reference.PackageName `
                -RequiredVersion $reference.RequiredVersion `
                -References $reference.References `
                -Framework $reference.Framework `
                -AllUsers:$AllUsers `
                -Install `
                -BootstrapConsent:$BootstrapConsent
            $resultObj['ResolvedPackageReferences'] += $resolvedRef

            # Copy package references to OutputDirectory
            $null = Copy-Item -Path $resolvedRef -Destination (Join-Path -Path $OutputDirectory -ChildPath (Split-Path -Path $resolvedRef -Leaf)) -Force
            Add-Type -Path $resolvedRef -ErrorAction Ignore
        }
    }

    # Combine the possibly authenticode-signed *.Code.ps1 files into a single file, adding preprocessor directives to the beginning if specified
    $srcContent = @()
    $srcContent += $Path | ForEach-Object { "// File $_"; Remove-AuthenticodeSignatureBlock -Path $_ }
    if ($PreprocessorDirectives) {
        foreach ($preprocessorDirective in $PreprocessorDirectives) {
            $srcContent = , $preprocessorDirective + $srcContent
        }
    }

    $oneSrc = $srcContent -join "`n"
    $resultObj['SourceCode'] = $oneSrc

    $OutputAssemblyBaseName = [System.IO.Path]::GetFileNameWithoutExtension("$OutputAssemblyName")
    $SourceCodeFilePath = Join-Path -Path $SymbolPath -ChildPath "Generated.$OutputAssemblyBaseName.cs"
    $resultObj['SourceCodeFilePath'] = $SourceCodeFilePath
    Out-File -InputObject $oneSrc -FilePath $SourceCodeFilePath

    $resultObj['OutputAssembly'] = Join-Path -Path $OutputDirectory -ChildPath $OutputAssemblyName

    return $resultObj
}

function Get-AddTypeParameters {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]
        $SourceCodeFilePath,

        [Parameter(Mandatory = $false)]
        [string[]]
        $ReferencedAssemblies,

        [Parameter(Mandatory = $false)]
        [ValidateSet("ConsoleApplication", "Library")]
        [string]
        $OutputType = 'Library',

        [Parameter(Mandatory = $false)]
        [switch]
        $TestBuild,

        [Parameter(Mandatory = $false)]
        [string]
        $OutputAssembly
    )

    $AddTypeParams = @{
        WarningAction = 'Ignore'
    }

    if (-not (Get-OperatingSystemInfo).IsCore) {
        $AddTypeParams['Path'] = $SourceCodeFilePath
        $compilerParameters = New-Object -TypeName System.CodeDom.Compiler.CompilerParameters
        $compilerParameters.WarningLevel = 1
        $compilerParameters.CompilerOptions = '/debug:full'
        if ($TestBuild) {
            $compilerParameters.IncludeDebugInformation = $true
        }
        else {
            $compilerParameters.CompilerOptions += ' /optimize+'
        }

        if ($OutputType -eq 'ConsoleApplication') {
            $compilerParameters.GenerateExecutable = $true
        }

        $ReferencedAssemblies | ForEach-Object {
            $null = $compilerParameters.ReferencedAssemblies.Add($_)
        }
        $AddTypeParams['CompilerParameters'] = $compilerParameters
    }
    else {
        $AddTypeParams['TypeDefinition'] = Get-Content -Path $SourceCodeFilePath -Raw
        $AddTypeParams['ReferencedAssemblies'] = $ReferencedAssemblies
        $AddTypeParams['OutputType'] = $OutputType
        $AddTypeParams['Language'] = 'CSharp'
    }

    if ($OutputAssembly) {
        if ($AddTypeParams.ContainsKey('CompilerParameters')) {
            $AddTypeParams['CompilerParameters'].OutputAssembly = $OutputAssembly
        }
        else {
            $AddTypeParams['OutputAssembly'] = $OutputAssembly
        }
    }
    else {
        if ($AddTypeParams.ContainsKey('CompilerParameters')) {
            $AddTypeParams['CompilerParameters'].GenerateInMemory = $true
        }
    }

    return $AddTypeParams
}
function Get-CscParameters {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]
        $SourceCodeFilePath,

        [Parameter(Mandatory = $false)]
        [ValidateSet('Exe', 'Library')]
        [string]
        $TargetType = 'Library',

        [Parameter(Mandatory = $false)]
        [string[]]
        $ReferencedAssemblies,

        [Parameter(Mandatory = $false)]
        [string[]]
        $ConditionalCompilationSymbol,

        [Parameter(Mandatory = $false)]
        [switch]
        $TestBuild,

        [Parameter(Mandatory = $false)]
        [string]
        $OutputAssembly
    )

    $CscParameter = @(
        $SourceCodeFilePath
        '/nologo',
        '/checked',
        '/warn:1',
        '/debug:full',
        '/platform:anycpu',
        "/target:$TargetType"
    )

    $ReferencedAssemblies | ForEach-Object { $CscParameter += "/reference:$_" }
    if (-not $TestBuild) { $CscParameter += '/optimize+' }
    if ($OutputAssembly) { $CscParameter += "/out:$OutputAssembly" }
    if ($ConditionalCompilationSymbol) {
        $ConditionalCompilationSymbol | ForEach-Object { $CscParameter += "/define:$_" }
    }

    return $CscParameter
}

<#
.DESCRIPTION
  Manually initialize PSSwagger's external dependencies. By default, initializes dependencies only for the current CLR. Use this function with -AcceptBootstrap for silent execution scenarios.

.PARAMETER  AllUsers
  Install dependencies in PSSwagger's global package cache.

.PARAMETER  Azure
  Additionally install dependencies for Microsoft Azure modules.

.PARAMETER  AcceptBootstrap
  Automatically consent to downloading missing packages. If not specified, an interactive prompt will be appear.

.PARAMETER  AllFrameworks
  Initialize dependencies for all frameworks.
#>
function Initialize-PSSwaggerDependencies {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [switch]
        $AllUsers,

        [Parameter(Mandatory=$false)]
        [switch]
        $Azure,

        [Parameter(Mandatory=$false)]
        [switch]
        $AcceptBootstrap,

        [Parameter(Mandatory=$false)]
        [switch]
        $AllFrameworks
    )

    if ($AllFrameworks) {
        $framework = @('netstandard1', 'net4')
        $clr = 'fullclr'
    } else {
        $framework = if ((Get-OperatingSystemInfo).IsCore) { 'netstandard1' } else { 'net4' }
        $clr = 'coreclr'
    }

    $null = Initialize-PSSwaggerUtilities
}

<#
.DESCRIPTION
  Gets PSSwagger external dependencies.

.PARAMETER Framework
  Framework of package dependencies.

.PARAMETER Azure
  Additionally get PSSwagger dependencies for Azure module generation.

.PARAMETER RequiredVersionMap
  Optionally specifies custom required versions of packages.
#>
function Get-PSSwaggerExternalDependencies {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [AllowEmptyString()]
        [string]
        $Framework,

        [Parameter(Mandatory=$false)]
        [switch]
        $Azure,

        [Parameter(Mandatory=$false)]
        [hashtable]
        $RequiredVersionMap
    )

    $dependencies = @{}
    $dependencies['Newtonsoft.Json'] = @{
                                            PackageName = 'Newtonsoft.Json'
                                            References = @('Newtonsoft.Json.dll')
                                            Framework = $Framework
                                            RequiredVersion = if ($Framework.Contains('standard')) { '9.0.1' } else { '6.0.8' }
                                            LoadOrder = 0
                                        }
    $dependencies['Microsoft.Rest.ClientRuntime'] = @{
                                                         PackageName = 'Microsoft.Rest.ClientRuntime'
                                                         References = @('Microsoft.Rest.ClientRuntime.dll')
                                                         Framework = $Framework
                                                         RequiredVersion = '2.3.4'
                                                         LoadOrder = 1
                                                     }

    if ($Azure) {
        $dependencies['Microsoft.Rest.ClientRuntime.Azure'] = @{
                                                                   PackageName = 'Microsoft.Rest.ClientRuntime.Azure'
                                                                   References = @('Microsoft.Rest.ClientRuntime.Azure.dll')
                                                                   Framework = $Framework
                                                                   RequiredVersion = '3.3.4'
                                                                   LoadOrder = 2
                                                               }
    }

    if ($RequiredVersionMap) {
        foreach ($requiredVersionEntry in $RequiredVersionMap.GetEnumerator()) {
            if ($requiredVersionEntry.Value -and $dependencies.ContainsKey($requiredVersionEntry.Name)) {
                $dependencies[$requiredVersionEntry.Name].RequiredVersion = $requiredVersionEntry.Value
            }
        }
    }

    return $dependencies
}

<#
.DESCRIPTION
  Find PSSwagger external reference assemblies, optionally installing missing packages.

.PARAMETER PackageName
  Name of NuGet package where external reference assemblies reside.

.PARAMETER RequiredVersion
  Optionally specifies required version of NuGet package.

.PARAMETER References
  Array of reference assembly names.

.PARAMETER Framework
  Framework of reference assemblies to find.

.PARAMETER AllUsers
  Install missing packages for all users.

.PARAMETER Install
  Install missing packages.

.PARAMETER BootstrapConsent
  User has consented to downloading missing packages.
#>
function Get-PSSwaggerDependency {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $PackageName,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $RequiredVersion,

        [Parameter(Mandatory=$true)]
        [string[]]
        $References,

        [Parameter(Mandatory=$true)]
        [string]
        $Framework,

        [Parameter(Mandatory=$false)]
        [switch]
        $AllUsers,

        [Parameter(Mandatory=$false)]
        [switch]
        $Install,

        [Parameter(Mandatory=$false)]
        [switch]
        $BootstrapConsent
    )

    $package = Get-PSSwaggerDependencyPackage -PackageName $PackageName -RequiredVersion $RequiredVersion -AllUsers:$AllUsers -Install:$Install -BootstrapConsent:$BootstrapConsent
    if ($package) {
        $allPaths = @()
        foreach ($ref in $References) {
            # The following is the expected path for NuGet packages
            $paths = Get-ChildItem -Path (Join-Path -Path $package.Location -ChildPath 'lib' | Join-Path -ChildPath "$Framework*") -Directory | Sort-Object -Property Name -Descending
            if ($paths) {
                foreach ($p in $paths) {
                    $path = Join-Path -Path $p -ChildPath $ref
                    if (Test-Path -Path $path) {
                        break;
                    }
                }
            } else {
                # In case the specified framework isn't found, the backup case is to use the net45 version
                $path = Join-Path -Path $package.Location -ChildPath 'lib' `
                            | Join-Path -ChildPath 'net45' `
                                | Join-Path -ChildPath $ref
            }

            $allPaths += $path
        }

        return $allPaths
    } else {
        if ($Install) {
            throw ($LocalizedData.FailedToInstallNuGetPackage -f ($PackageName))
        }

        return $null
    }
}

<#
.DESCRIPTION
  Finds the package in which a PSSwagger external reference assembly resides, optionally installing.

.PARAMETER PackageName
  Name of NuGet package where external reference assemblies reside.

.PARAMETER RequiredVersion
  Optionally specifies required version of NuGet package.

.PARAMETER AllUsers
  Install missing packages for all users.

.PARAMETER Install
  Install missing packages.

.PARAMETER BootstrapConsent
  User has consented to downloading missing packages.
#>
function Get-PSSwaggerDependencyPackage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $PackageName,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $RequiredVersion,

        [Parameter(Mandatory=$false)]
        [switch]
        $AllUsers,

        [Parameter(Mandatory=$false)]
        [switch]
        $Install,

        [Parameter(Mandatory=$false)]
        [switch]
        $BootstrapConsent
    )

    # Although PackageManagement has been removed, we should leave this level of indirection here for future support.
    Get-PSSwaggerDependencyPackageWithNuGetCli -PackageName $PackageName -RequiredVersion $RequiredVersion -Install:$Install -BootstrapConsent:$BootstrapConsent -AllUsers:$AllUsers
}

<#
.DESCRIPTION
  Finds the package in which a PSSwagger external reference assembly resides, optionally installing, using NuGet.exe.

.PARAMETER PackageName
  Name of NuGet package where external reference assemblies reside.

.PARAMETER RequiredVersion
  Optionally specifies required version of NuGet package.

.PARAMETER AllUsers
  Install missing packages for all users.

.PARAMETER Install
  Install missing packages.

.PARAMETER BootstrapConsent
  User has consented to downloading missing packages.
#>
function Get-PSSwaggerDependencyPackageWithNuGetCli {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $PackageName,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $RequiredVersion,

        [Parameter(Mandatory=$false)]
        [switch]
        $Install,

        [Parameter(Mandatory=$false)]
        [switch]
        $BootstrapConsent,

        [Parameter(Mandatory=$false)]
        [switch]
        $AllUsers
    )

    # Attempt to get the package from the local cache first, then the global cache
    $path = Get-LocalNugetPackagePath -PackageName $PackageName -RequiredVersion $RequiredVersion
    if (-not $path) {
        $path = Get-LocalNugetPackagePath -PackageName $PackageName -RequiredVersion $RequiredVersion -GlobalCache
    }

    if ($path) {
        $versionMatch = [Regex]::Match($path, "(.+?)($($PackageName.Replace('.','[.]'))[.])([0-9.]*).*")
        $packageProps = @{
            Name = $PackageName;
            Version = $versionMatch.Groups[3].Value;
            Location = $path
        }

        return New-Object -TypeName PSObject -Property $packageProps
    } else {
        return $null
    }
}

<#
.DESCRIPTION
  Get the expected path to the given NuGet package.

.PARAMETER PackageName
  Name of NuGet package to find.

.PARAMETER RequiredVersion
  Optionally specifies required version of NuGet package.

.PARAMETER GlobalCache
  Use the global package cache. When not specified, uses the local user package cache.
#>
function Get-LocalNugetPackagePath {
    param(
        [Parameter(Mandatory=$true)]
        [AllowEmptyString()]
        [string]
        $PackageName,

        [Parameter(Mandatory=$false)]
        [switch]
        $GlobalCache,

        [Parameter(Mandatory=$false)]
        [AllowEmptyString()]
        [string]
        $RequiredVersion
    )

    $outputSubPath = $PackageName
    if ($RequiredVersion) {
        $outputSubPath += ".$RequiredVersion"
    }

    if (Test-Path -Path (Join-Path -Path (Get-PackageCache -GlobalCache:$GlobalCache) -ChildPath "$outputSubPath*")) {
        $path = (Get-ChildItem -Path (Join-Path -Path (Get-PackageCache -GlobalCache:$GlobalCache) -ChildPath "$outputSubPath*") | Select-Object -First 1 | ForEach-Object FullName)
        return $path
    }

    return ''
}

<#
.DESCRIPTION
  Gets the expected path to NuGet.exe. If NuGet.exe is in the path, just returns nuget.exe. Checks both the local and global path.

.PARAMETER SpecificPath
  Return only the specific (local or global, based on the value of -GlobalCache) path.

.PARAMETER GlobalCache
  Use the global package cache. When not specified, uses the local user package cache.
#>
function Get-NugetExePath {
    param(
        [Parameter(Mandatory=$false)]
        [switch]
        $SpecificPath,

        [Parameter(Mandatory=$false)]
        [switch]
        $GlobalCache
    )

    if ((Get-Command nuget.exe -ErrorAction Ignore)) {
        return "nuget.exe"
    }

    if ($SpecificPath) {
        return (Join-Path -Path (Get-PackageCache -GlobalCache:$GlobalCache) -ChildPath "nuget.exe")
    }

    $localCachePath = (Join-Path -Path (Get-PackageCache) -ChildPath "nuget.exe")
    if (-not (Test-Path -Path $localCachePath)) {
        $localCachePath = (Join-Path -Path (Get-PackageCache -GlobalCache) -ChildPath "nuget.exe")
    }

    return $localCachePath
}

<#
.DESCRIPTION
  Gets the location of the package cache. Creates the package cache folder if it doesn't already exist.

.PARAMETER GlobalCache
  Use the global package cache. When not specified, uses the local user package cache.
#>
function Get-PackageCache {
    param(
        [Parameter(Mandatory=$false)]
        [switch]
        $GlobalCache
    )

    $newPathCandidate = $false
    if ($null -eq $script:AppLocalPath) {
        $newPathCandidate = $true
        $script:ProgramDataPath = Microsoft.PowerShell.Management\Join-Path -Path (Get-XDGDirectory -DirectoryType Shared) -ChildPath 'PSSwagger'
        $script:AppLocalPath = Microsoft.PowerShell.Management\Join-Path -Path (Get-XDGDirectory -DirectoryType Data) -ChildPath 'PSSwagger'
    }

    if ($GlobalCache) {
        $cache = $script:ProgramDataPath
    } else {
        $cache = $script:AppLocalPath
    }

    if ($newPathCandidate -and (-not (Test-Path -Path $cache))) {
        $null = New-Item -Path $cache `
                         -ItemType Directory -Force `
                         -ErrorAction SilentlyContinue `
                         -WarningAction SilentlyContinue `
                         -Confirm:$false `
                         -WhatIf:$false
    }

    return $cache
}

<#
.DESCRIPTION
  Get a NuGet package source with location nuget.org/api/v2.
#>
function Get-NugetPackageSource
{
    Get-PackageSource -Provider NuGet `
                      -ForceBootstrap `
                      -Verbose:$false `
                      -Debug:$false |
        Where-Object { $_.Location -match 'nuget.org/api/v2' } |
            Select-Object -First 1 -ErrorAction Ignore |
                Foreach-Object {$_.Name}
}

<#
.DESCRIPTION
  Creates a temporary NuGet package source with given location.

.PARAMETER  Location
  Location of NuGet package source. Defaults to 'https://nuget.org/api/v2'.
#>
function Register-NugetPackageSource
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [string]
        $Location = 'https://nuget.org/api/v2'
    )

    $SourceName = "PSSwaggerNuGetSource_$([System.Guid]::NewGuid())"

    $params = @{
        Name = $SourceName
        Location = $Location
        ProviderName = 'NuGet'
        ForceBootstrap = $true
        Verbose = $false
        Debug = $false
        Confirm = $false
        WhatIf = $false
    }

    if(Register-PackageSource @params)
    {
        return $SourceName
    }
}

<#
.DESCRIPTION
  Get PowerShell Common parameter/preference values.

.PARAMETER  CallerPSBoundParameters
  PSBoundParameters of the caller.
#>
function Get-PSCommonParameter
{
    param(
        [Parameter(Mandatory=$true)]
        $CallerPSBoundParameters
    )

    $VerbosePresent = $false
    if (-not $CallerPSBoundParameters.ContainsKey('Verbose'))
    {
        if($VerbosePreference -in 'Continue','Inquire')
        {
            $VerbosePresent = $true
        }
    }
    else
    {
        $VerbosePresent = $true
    }

    $DebugPresent = $false
    if (-not $CallerPSBoundParameters.ContainsKey('Debug'))
    {
        if($debugPreference -in 'Continue','Inquire')
        {
            $DebugPresent = $true
        }
    }
    else
    {
        $DebugPresent = $true
    }

    if(Test-Path variable:\errorActionPreference)
    {
        $errorAction = $errorActionPreference
    }
    else
    {
        $errorAction = 'Continue'
    }

    if ($CallerPSBoundParameters['ErrorAction'] -eq 'SilentlyContinue')
    {
        $errorAction = 'SilentlyContinue'
    }

    if($CallerPSBoundParameters['ErrorAction'] -eq 'Ignore')
    {
        $errorAction = 'SilentlyContinue'
    }

    if ($CallerPSBoundParameters['ErrorAction'] -eq 'Inquire')
    {
        $errorAction = 'Continue'
    }

    if(Test-Path variable:\warningPreference)
    {
        $warningAction = $warningPreference
    }
    else
    {
        $warningAction = 'Continue'
    }

    if ($CallerPSBoundParameters['WarningAction'] -in 'SilentlyContinue','Ignore')
    {
        $warningAction = 'SilentlyContinue'
    }

    if ($CallerPSBoundParameters['WarningAction'] -eq 'Inquire')
    {
        $warningAction = 'Continue'
    }

    return @{
        Verbose = $VerbosePresent
        Debug = $DebugPresent
        WarningAction = $warningAction
        ErrorAction = $errorAction
    }
}

<#
.DESCRIPTION
  Tests if current PowerShell session is considered downlevel.
#>
function Test-Downlevel {
    return ($PSVersionTable.PSVersion -lt '5.0.0')
}

<#
.DESCRIPTION
  Finds local MSI installations.

.PARAMETER  Name
  Name of MSIs to find. Supports * wildcard.

.PARAMETER  MaximumVersion
  Maximum version of MSIs to find.
#>
function Get-PSSwaggerMsi {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $Name,

        [Parameter(Mandatory=$false)]
        [string]
        $MaximumVersion
    )

    if (Test-Downlevel) {
        return Get-MsiWithCim -Name $Name -MaximumVersion $MaximumVersion
    } else {
        return Get-MsiWithPackageManagement -Name $Name -MaximumVersion $MaximumVersion
    }
}

<#
.DESCRIPTION
  Finds local MSI installations using WMI.

.PARAMETER  Name
  Name of MSIs to find. Supports * wildcard.

.PARAMETER  MaximumVersion
  Maximum version of MSIs to find.
#>
function Get-MsiWithCim {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $Name,

        [Parameter(Mandatory=$false)]
        [string]
        $MaximumVersion
    )

    $wqlNameFilter = $Name.Replace('*', '%')
    $filter = "Name like '$wqlNameFilter'"
    if ($MaximumVersion) {
        $filter += " AND Version <= '$MaximumVersion'"
    }

    $products = Get-CimInstance -ClassName Win32_Product -Filter $filter
    $returnObjects = @()
    $products | ForEach-Object {
        $objectProps = @{
            'Name'=$_.Name;
            'Version'=$_.Version
        }

        $returnObjects += (New-Object -TypeName PSObject -Prop $objectProps)
    }

    return $returnObjects
}

<#
.DESCRIPTION
  Finds local MSI installations using PackageManagement.

.PARAMETER  Name
  Name of MSIs to find. Supports * wildcard.

.PARAMETER  MaximumVersion
  Maximum version of MSIs to find.
#>
function Get-MsiWithPackageManagement {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $Name,

        [Parameter(Mandatory=$false)]
        [string]
        $MaximumVersion
    )

    $products = Get-Package -Name $Name `
                            -MaximumVersion $MaximumVersion `
                            -ProviderName msi `
                            -Verbose:$false `
                            -Debug:$false
    $returnObjects = @()
    $products | ForEach-Object {
        $objectProps = @{
            'Name'=$_.Name;
            'Version'=$_.Version
        }

        $returnObjects += (New-Object -TypeName PSObject -Prop $objectProps)
    }

    return $returnObjects
}
#endregion

<#
.DESCRIPTION
  Initialize the PSSwagger utilities assembly, compiling if it isn't already found.
#>
function Initialize-PSSwaggerUtilities {
    if (Get-Command Start-PSSwaggerJob -ErrorAction Ignore) {
        return;
    }

    $PSSwaggerJobAssemblyPath = $null
    $PSSwaggerJobAssemblyUnsafePath = $null
    $useExternalDependencies = $true
    if ((Get-OperatingSystemInfo).IsCore) {
        $externalReferencesFramework = 'netstandard1.'
        $clr = 'coreclr'
    } else {
        $externalReferencesFramework = 'net4'
        $clr = 'fullclr'
    }

    if(("$($LocalizedData.CSharpNamespace).PSSwaggerJob" -as [Type]) -and
    (Test-Path -Path ("$($LocalizedData.CSharpNamespace).PSSwaggerJob" -as [Type]).Assembly.Location -PathType Leaf))
    {
        # This is for re-import scenario.
        $PSSwaggerJobAssemblyPath = ("$($LocalizedData.CSharpNamespace).PSSwaggerJob" -as [Type]).Assembly.Location
        if(("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type]) -and
        (Test-Path -Path ("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type]).Assembly.Location -PathType Leaf))
        {
            $PSSwaggerJobAssemblyUnsafePath = ("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type]).Assembly.Location
        }
    }
    else
    {
        # Compile the regular utilities
        $coreCodeFileName = 'PSSwaggerNetUtilities.Core.Code.ps1'
        $codeFileName = 'PSSwaggerNetUtilities.Code.ps1'
        $PSSwaggerJobFilePath = Join-Path -Path $PSScriptRoot -ChildPath $codeFileName
        $PSSwaggerCoreJobFilePath = Join-Path -Path $PSScriptRoot -ChildPath $coreCodeFileName
        if(Test-Path -Path $PSSwaggerCoreJobFilePath -PathType Leaf)
        {
            $useExternalDependencies = $false
            if ((Get-OperatingSystemInfo).IsWindows) {
                $sig = Get-AuthenticodeSignature -FilePath $PSSwaggerCoreJobFilePath
                if (('Valid' -ne $sig.Status) -and ('NotSigned' -ne $sig.Status)) {
                    throw ($LocalizedData.CodeFileSignatureValidationFailed -f ($coreCodeFileName))
                }
            }

            $PSSwaggerJobSourceString = Remove-AuthenticodeSignatureBlock -Path $PSSwaggerCoreJobFilePath
            if (Test-Path -Path $PSSwaggerJobFilePath -PathType Leaf) {
                $useExternalDependencies = $true
                if ((Get-OperatingSystemInfo).IsWindows) {
                    $sig = Get-AuthenticodeSignature -FilePath $PSSwaggerJobFilePath
                    if (('Valid' -ne $sig.Status) -and ('NotSigned' -ne $sig.Status)) {
                        throw ($LocalizedData.CodeFileSignatureValidationFailed -f ($codeFileName))
                    }
                }

                $PSSwaggerJobSourceString = $PSSwaggerJobSourceString + (Remove-AuthenticodeSignatureBlock -Path $PSSwaggerJobFilePath)
            }

            $PSSwaggerJobSourceString = $PSSwaggerJobSourceString | Out-String
            $PSSwaggerJobSourceString = $ExecutionContext.InvokeCommand.ExpandString($PSSwaggerJobSourceString)
            Add-Type -AssemblyName System.Net.Http
            $RequiredAssemblies = @(
                [System.Management.Automation.PSCmdlet].Assembly.FullName,
                [System.ComponentModel.AsyncCompletedEventArgs].Assembly.FullName,
                [System.Linq.Enumerable].Assembly.FullName,
                [System.Collections.StructuralComparisons].Assembly.FullName,
                [System.Net.Http.HttpRequestMessage].Assembly.FullName
            )

            if ((Get-OperatingSystemInfo).IsCore) {
                # On core CLR, these "additional" assemblies are required due to type redirection
                $RequiredAssemblies += 'System.Threading.Tasks'
                $RequiredAssemblies += 'System.Threading'
            }

            $TempPath = Join-Path -Path (Get-XDGDirectory -DirectoryType Data) -ChildPath ([System.IO.Path]::GetRandomFileName())
            $null = New-Item -Path $TempPath -ItemType Directory -Force

			# Compile the main utility assembly
            $PSSwaggerJobAssemblyPath = Join-Path -Path $TempPath -ChildPath "$($LocalizedData.CSharpNamespace).Utility.dll"

            Add-Type -ReferencedAssemblies $RequiredAssemblies `
                    -TypeDefinition $PSSwaggerJobSourceString `
                    -OutputAssembly $PSSwaggerJobAssemblyPath `
                    -Language CSharp `
                    -WarningAction Ignore `
                    -IgnoreWarnings
        }
    }

    if(("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type]) -and
    (Test-Path -Path ("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type]).Assembly.Location -PathType Leaf))
    {
        # This is for re-import scenario.
        $PSSwaggerJobAssemblyUnsafePath = ("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type]).Assembly.Location
    }
    elseif (-not (Get-OperatingSystemInfo).IsCore)
    {
        # Compile the utilities requiring the /unsafe flag (only for Full CLR because of no Core CLR CompilerParameters support)
        # If we move to dotnet CLI, we can remove this restriction
        $codeFileName = 'PSSwaggerNetUtilities.Unsafe.Code.ps1'
        $PSSwaggerJobFilePath = Join-Path -Path $PSScriptRoot -ChildPath $codeFileName
        if(Test-Path -Path $PSSwaggerJobFilePath -PathType Leaf) {
            if ((Get-OperatingSystemInfo).IsWindows) {
                $sig = Get-AuthenticodeSignature -FilePath $PSSwaggerJobFilePath
                if (('Valid' -ne $sig.Status) -and ('NotSigned' -ne $sig.Status)) {
                    throw ($LocalizedData.CodeFileSignatureValidationFailed -f ($codeFileName))
                }
            }

            $PSSwaggerJobSourceString = Remove-AuthenticodeSignatureBlock -Path $PSSwaggerJobFilePath | Out-String
            $PSSwaggerJobSourceString = $ExecutionContext.InvokeCommand.ExpandString($PSSwaggerJobSourceString)
            Add-Type -AssemblyName System.Net.Http
            $compilerParameters = New-Object -TypeName System.CodeDom.Compiler.CompilerParameters
            $compilerParameters.CompilerOptions = '/debug:full /optimize+ /unsafe'

            $compilerParameters.ReferencedAssemblies.Add([System.ComponentModel.AsyncCompletedEventArgs].Assembly.Location)
            $compilerParameters.ReferencedAssemblies.Add([System.Linq.Enumerable].Assembly.Location)
            $compilerParameters.ReferencedAssemblies.Add([System.Collections.StructuralComparisons].Assembly.Location)
            $compilerParameters.ReferencedAssemblies.Add([System.Net.Http.HttpRequestMessage].Assembly.Location)

            $externalReferencesFramework = 'net4'
            $clr = 'fullclr'


            $TempPath = Join-Path -Path (Get-XDGDirectory -DirectoryType Data) -ChildPath ([System.IO.Path]::GetRandomFileName())
            $null = New-Item -Path $TempPath -ItemType Directory -Force

            # Compile the main utility assembly
            $PSSwaggerJobAssemblyUnsafePath = Join-Path -Path $TempPath -ChildPath 'Microsoft.PowerShell.PSSwagger.Utility.Unsafe.dll'
            $compilerParameters.OutputAssembly = $PSSwaggerJobAssemblyUnsafePath

            Add-Type -TypeDefinition $PSSwaggerJobSourceString `
                     -WarningAction Ignore `
                     -CompilerParameters $compilerParameters
        }
    }

    if(Test-Path -LiteralPath $PSSwaggerJobAssemblyPath -PathType Leaf)
    {
        if ($useExternalDependencies) {
            $externalReferences = Get-PSSwaggerExternalDependencies -Framework $externalReferencesFramework
            foreach ($entry in ($externalReferences.GetEnumerator() | Sort-Object { $_.Value.LoadOrder })) {
                $reference = $entry.Value
                $extraRefs = Get-PSSwaggerDependency -PackageName $reference.PackageName `
                                                            -References $reference.References `
                                                            -Framework $reference.Framework `
                                                            -RequiredVersion $reference.RequiredVersion
                if ($extraRefs) {
                    foreach ($extraRef in $extraRefs) {
                        Add-Type -Path $extraRef
                    }
                }
            }
        }

        # It is required to import the generated assembly into the module scope
        # to register the PSSwaggerJobSourceAdapter with the PowerShell Job infrastructure.
        Import-Module -Name $PSSwaggerJobAssemblyPath -Verbose:$false
    }

    if ((-not (Get-OperatingSystemInfo).IsCore) -and $PSSwaggerJobAssemblyUnsafePath) {
        $externalReferences = Get-PSSwaggerExternalDependencies -Framework $externalReferencesFramework
        foreach ($entry in ($externalReferences.GetEnumerator() | Sort-Object { $_.Value.LoadOrder })) {
            $reference = $entry.Value
            $extraRefs = Get-PSSwaggerDependency -PackageName $reference.PackageName `
                                                        -References $reference.References `
                                                        -Framework $reference.Framework `
                                                        -RequiredVersion $reference.RequiredVersion
            if ($extraRefs) {
                foreach ($extraRef in $extraRefs) {
                    Add-Type -Path $extraRef
                }
            }
        }

        if(Test-Path -LiteralPath $PSSwaggerJobAssemblyUnsafePath -PathType Leaf)
        {
            Add-Type -Path $PSSwaggerJobAssemblyUnsafePath
        }
    }

    if(-not ("$($LocalizedData.CSharpNamespace).PSSwaggerJob" -as [Type]))
    {
        Write-Error -Message ($LocalizedData.FailedToAddType -f ('PSSwaggerJob'))
    }

    if((-not (Get-OperatingSystemInfo).IsCore) -and $PSSwaggerJobAssemblyUnsafePath -and (-not ("$($LocalizedData.CSharpNamespace).PSBasicAuthenticationEx" -as [Type])))
    {
        Write-Error -Message ($LocalizedData.FailedToAddType -f ('PSBasicAuthenticationEx'))
    }

    Import-Module -Name (Join-Path -Path "$PSScriptRoot" -ChildPath 'PSSwaggerClientTracing.psm1') -Verbose:$false
    Import-Module -Name (Join-Path -Path "$PSScriptRoot" -ChildPath 'PSSwaggerServiceCredentialsHelpers.psm1') -Verbose:$false
}

function New-PSSwaggerClientTracing {
	[CmdletBinding()]
	param()

    Initialize-PSSwaggerDependencies
	return New-PSSwaggerClientTracingInternal
}

function Register-PSSwaggerClientTracing {
	[CmdletBinding()]
	param(
		[object]$TracerObject
	)

    Initialize-PSSwaggerDependencies
	Register-PSSwaggerClientTracingInternal -TracerObject $TracerObject
}

function Unregister-PSSwaggerClientTracing {
	[CmdletBinding()]
	param(
		[object]$TracerObject
	)

	Initialize-PSSwaggerDependencies
    Unregister-PSSwaggerClientTracingInternal -TracerObject $TracerObject
}

function Get-AutoRestCredential {
    [CmdletBinding(DefaultParameterSetName='NoAuth')]
    param(
        [Parameter(Mandatory=$true, ParameterSetName='BasicAuth')]
        [PSCredential]
        $Credential,

        [Parameter(Mandatory=$true, ParameterSetName='ApiKeyAuth')]
        [string]
        $APIKey,

        [Parameter(Mandatory=$false, ParameterSetName='ApiKeyAuth')]
        [string]
        $Location,

        [Parameter(Mandatory=$false, ParameterSetName='ApiKeyAuth')]
        [string]
        $Name
    )

    if ('BasicAuth' -eq $PsCmdlet.ParameterSetName) {
        Get-BasicAuthCredentialInternal -Credential $Credential
    } elseif ('ApiKeyAuth' -eq $PsCmdlet.ParameterSetName) {
        Get-ApiKeyCredentialInternal -APIKey $APIKey -Location $Location -Name $Name
    } else {
        Get-EmptyAuthCredentialInternal
    }
}
