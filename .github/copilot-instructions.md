# Azure PowerShell Repository

Azure PowerShell is a collection of 200+ PowerShell modules for managing Azure resources. The repository contains both SDK-based modules and AutoRest-generated modules, all built using .NET and MSBuild.

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Working Effectively

### Prerequisites and Setup
First-time setup requires these exact steps:
- **CRITICAL**: Ensure you have network connectivity to Azure DevOps package feeds. Build failures with "Name or service not known" errors indicate firewall/connectivity issues that must be resolved before building.
- Install .NET SDK 8.0+ and .NET Framework Dev Pack 4.7.2+: `dotnet --version` should show 8.0+
- Install PowerShell 7+: `pwsh --version` should show 7.0+
- Install platyPS module: `pwsh -c "Install-Module -Name platyPS -Force -Scope CurrentUser"`
- Install PSScriptAnalyzer: `pwsh -c "Install-Module -Name PSScriptAnalyzer -Force -Scope CurrentUser"`
- Set PowerShell execution policy: `pwsh -c "Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope CurrentUser"`

### Building the Repository
**NEVER CANCEL** any build commands - they may take 45-60 minutes to complete.

Core build commands (run from repository root):
- Clean: `dotnet msbuild build.proj /t:Clean` -- takes ~15 seconds
- Full build: `dotnet msbuild build.proj` -- takes 45-60 minutes. NEVER CANCEL. Set timeout to 90+ minutes.
- Build specific module: `dotnet msbuild build.proj /p:Scope=Accounts` -- takes 15-30 minutes
- Generate help: `dotnet msbuild build.proj /t:GenerateHelp` -- takes 10-15 minutes. NEVER CANCEL. Set timeout to 30+ minutes.
- Static analysis: `dotnet msbuild build.proj /t:StaticAnalysis` -- takes 10-15 minutes. NEVER CANCEL. Set timeout to 30+ minutes.
- Run tests: `dotnet msbuild build.proj /t:Test` -- takes 15+ minutes. NEVER CANCEL. Set timeout to 45+ minutes.

Alternative PowerShell build commands:
- Build single module: `pwsh -c "./tools/BuildScripts/BuildModules.ps1 -RepoRoot $(pwd) -Configuration Debug -TargetModule Accounts"` -- takes 5-15 minutes depending on module size

### Testing
**NEVER CANCEL** test commands - they can take 15+ minutes.

Test execution patterns:
- All tests: `dotnet msbuild build.proj /t:Test` -- takes 15+ minutes. NEVER CANCEL.
- Core tests only: `dotnet msbuild build.proj /t:Test /p:TestsToRun=Core` -- tests Compute, Network, Resources, Sql, Websites modules
- Individual module tests: Navigate to module test directory and run `dotnet test` or use Pester

Test framework uses .NET 6 target framework and Azure Test Framework for recording/playback of HTTP requests.

### Validation Steps
Always run these validation steps before committing changes:
- Build succeeds: `dotnet msbuild build.proj /p:Scope=YourModule` 
- Static analysis passes: `dotnet msbuild build.proj /t:StaticAnalysis`
- Help generation succeeds: `dotnet msbuild build.proj /t:GenerateHelp`
- Tests pass: Navigate to test directory and run tests for your module
- **SCENARIO VALIDATION**: Import your module and test actual PowerShell cmdlets work correctly:
  ```powershell
  Import-Module ./artifacts/Debug/Az.YourModule/Az.YourModule.psd1
  Get-Command -Module Az.YourModule
  # Test actual cmdlet functionality
  ```

## Common Build Issues and Workarounds

### Network Connectivity Issues
**CRITICAL**: If you see "Failed to download package" or "Name or service not known" errors:
- This indicates firewall/proxy issues blocking access to Azure DevOps package feeds
- Workaround 1: Configure corporate proxy/firewall to allow `*.vsblob.vsassets.io` and `pkgs.dev.azure.com`
- Workaround 2: Use VPN or different network environment
- **DO NOT** attempt to modify NuGet.Config - this will break the build

### Incomplete Builds
If build appears to hang or shows no progress:
- **DO NOT CANCEL** - builds can take 45+ minutes with periods of no visible progress
- Monitor system resources - builds are CPU and network intensive
- Check network connectivity if stuck on package restore

### Module-Specific Issues
- Help generation requires platyPS module to be installed and functioning
- Static analysis requires PSScriptAnalyzer module
- Some modules depend on specific Azure SDK versions from Azure DevOps feeds

## Repository Structure and Navigation

### Key Directories
- `/src/` - SDK-based PowerShell modules (200+ modules)
- `/generated/` - AutoRest-generated modules  
- `/tools/` - Build scripts, static analysis, testing utilities
- `/documentation/` - Developer guides, design guidelines, testing docs
- `/artifacts/` - Build outputs (created during build process)

### Module Types
Two types of modules with different development approaches:

**SDK-based modules** (in `/src/`):
- Hand-written C# cmdlets using Azure .NET SDKs
- Example: `/src/Accounts/`, `/src/Compute/`
- Build using main repository build system
- Follow patterns in `/documentation/development-docs/azure-powershell-developer-guide.md`

**AutoRest-generated modules** (in `/generated/` and some `/src/`):
- Generated from REST API specifications
- Example: `/generated/Cdn/Cdn.Autorest/`
- Have individual build scripts: `build-module.ps1`, `test-module.ps1`, `pack-module.ps1`
- Follow patterns in individual module `how-to.md` files

### Important Files
- `build.proj` - Main MSBuild file for entire repository
- `NuGet.Config` - Package source configuration (DO NOT MODIFY)
- `CONTRIBUTING.md` - Contribution guidelines and PR requirements
- `ChangeLog.md` - Release notes (must be updated for changes)

### Development Workflow Files
- `/tools/BuildScripts/BuildModules.ps1` - Core module build automation
- `/tools/GenerateHelp.ps1` - Help documentation generation
- `/tools/StaticAnalysis/` - Code analysis and validation tools
- `/tools/Test/` - Testing infrastructure and utilities

## Typical Development Tasks

### Adding a New Cmdlet
1. Navigate to appropriate module directory in `/src/`
2. Add cmdlet class following existing patterns
3. Update module manifest (`.psd1`) if needed
4. Build module: `dotnet msbuild build.proj /p:Scope=YourModule`
5. Generate help: `dotnet msbuild build.proj /t:GenerateHelp`
6. Add tests following patterns in `ModuleName.Test` directory
7. Update `ChangeLog.md` with your changes

### Working with AutoRest Modules
1. Navigate to module directory (usually in `/generated/`)
2. Modify files in `/custom/` directory for customizations
3. Build using individual module scripts if they exist
4. Test using `test-module.ps1` if available
5. Refer to module-specific `how-to.md` for detailed instructions

### Running Specific Module Tests
1. Navigate to module test directory: `cd src/YourModule/YourModule.Test`
2. Set up test environment (see `/documentation/testing-docs/using-azure-test-framework.md`)
3. Run tests: `dotnet test` or use PowerShell/Pester patterns
4. Record new tests in "Record" mode, run existing tests in "Playback" mode

### Pre-commit Validation
Always run before submitting PR:
1. `dotnet msbuild build.proj /t:Clean`
2. `dotnet msbuild build.proj /p:Scope=YourModule` -- wait for completion, 15-30 minutes
3. `dotnet msbuild build.proj /t:StaticAnalysis` -- wait for completion, 10-15 minutes  
4. Test your specific changes manually by importing and using the cmdlets
5. Update ChangeLog.md with your changes

## Timing Expectations
**CRITICAL**: All timing estimates include buffers. NEVER CANCEL commands before these timeouts:

| Command | Expected Time | Timeout Setting |
|---------|---------------|-----------------|
| Clean build | 15 seconds | 60 seconds |
| Full repository build | 45-60 minutes | 90 minutes |
| Single module build | 15-30 minutes | 45 minutes |
| Help generation | 10-15 minutes | 30 minutes |
| Static analysis | 10-15 minutes | 30 minutes |  
| Test execution | 15+ minutes | 45 minutes |

**NEVER CANCEL** any build or test command before the timeout period. Builds may show no progress for extended periods while downloading packages or compiling.

## Files to Always Update
- **ChangeLog.md** - Add entry under "## Upcoming Release" section
- **Module-specific ChangeLog.md** - Located at `src/YourModule/YourModule/ChangeLog.md`
- **Help documentation** - Regenerate using help generation commands
- **Tests** - Add or update tests for new functionality

## Common Command Reference
```bash
# Repository setup
dotnet --version                    # Check .NET version (need 8.0+)
pwsh --version                     # Check PowerShell version (need 7.0+)

# Build commands  
dotnet msbuild build.proj /t:Clean                    # Clean build
dotnet msbuild build.proj                             # Full build (45-60 min)
dotnet msbuild build.proj /p:Scope=ModuleName         # Build specific module
dotnet msbuild build.proj /t:GenerateHelp             # Generate help (10-15 min)  
dotnet msbuild build.proj /t:StaticAnalysis           # Run static analysis (10-15 min)
dotnet msbuild build.proj /t:Test                     # Run tests (15+ min)

# Module development
pwsh -c "Import-Module ./artifacts/Debug/Az.ModuleName/Az.ModuleName.psd1"
pwsh -c "Get-Command -Module Az.ModuleName"

# Individual module builds (for AutoRest modules)
cd generated/ModuleName/ModuleName.Autorest
./build-module.ps1                 # If available
./test-module.ps1                  # If available
```

Remember: This is a large, complex repository with extensive build times. Plan accordingly and never cancel long-running operations.