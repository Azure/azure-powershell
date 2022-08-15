# Common Assemblies
It is common scenario that 2 different modules take dependency on different versions of one assembly. It won't be big issue for Windows PowerShell as .NET Framework allows to load different versions of one assembly into one process. However, .NET Core and .NET 5+ do not allow to load 2 different versions of one assembly into the same [AssemblyLoadContext](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext).

As a platform, PowerShell allows user to import modules on demand. Modules may probably share the same dependency but with different versions. Assembly conflict is common problem in PowerShell. Although Azure PowerShell cannot resolve it completely, we introduce techniques across modules of Azure PowerShell to mitigate this problem. The idea come from [Resolving PowerShell Module Assembly Dependency Conflicts](https://devblogs.microsoft.com/powershell/resolving-powershell-module-assembly-dependency-conflicts/)

To minimize conflicts among modules, shared assemblies are loaded by Az.Accounts during being imported. All assemblies should be referenced by `Common.Netcore.Dependencies.targets` and stored under `src/lib/NetFxPreloadAssemblies` or `src/lib/NetCorePreloadAssemblies` according to target framework.

## PowerShell 7+ with .Net 5/.Net 6
Since .NET Core and above cannot load 2 different versions of one assembly into the same load context. `Az.Accounts` creates separate assembly load context during initialization and loads all shared assemblies into it. We selected shared assemblies according to their popularity, such as Microsoft Authentication Library(MSAL), `Azure.Core`, and `Azure.Identity`.

Service module of Azure PowerShell also can create its assembly load context when it must depend on a assembly with different version from other modules. The page [How to define AssemblyLoadContext for module](/src/Accounts/AuthenticationAssemblyLoadContext) provides a comprehensive sample used by `Az.Compute`. 

## Windows PowerShell with .NET Framework
The major problem on Windows PowerShell is required assembly may not be offered by Windows PowerShell or .NET Framework. `Az.Accounts` registers a handler in `CustomAssemblyResolver` to handle event that required assembly could not be resolved. It means target assembly cannot be found from the probing path of .NET Framework or Windows PowerShell. Then, resolver compares expected version and loads target from directory `/PreloadAssemblies`  (`src/lib/NetCorePreloadAssemblies`) in `Az.Accounts` if major version is the same. Here, we assume there is no breaking change across minor or patch versions, but it cannot be guaranteed.

For further reading, please visit https://docs.microsoft.com/en-us/dotnet/standard/assembly/resolve-loads#how-the-assemblyresolve-event-works


## Example: How to upgrade `Azure.Core`
`Azure.Core` is common library used by management plane and data plane SDKs. Below are steps to upgrade its version.
1. Navigate to [Common.Netcore.Dependencies.targets](/tools/Common.Netcore.Dependencies.targets) to check current version of `Azure.Core` used by latest code and bump version to expected.
2. Compare dependencies of `Azure.Core` on [nuget.org](https://www.nuget.org/packages/Azure.Core/) between current version and expected version.
3. Extract DLL file in nuget package folder `lib/netcoreapp2.1` of `Azure.Core` and changed dependencies and copy them to `src/lib/NetCorePreloadAssemblies`. You need to ensure the version CANNOT be higher than existing assembly if PowerShell already includes it. 
4. Update assembly version of `Azure.Core` and changed dependencies to .NET Stardard 2.0 in `/src/Accounts/AuthenticationAssemblyLoadContext/AzAssemblyLoadContextInitializer.cs`.
5. Extract DLL file in nuget package folder `lib/net461` (alternatively, `netstandard2.0`) of `Azure.Core` and changed dependencies and copy them to `src/lib/NetFxPreloadAssemblies`. As one of dependencies, `Microsoft.Identity.Client` needs its net461 version because of known issue with certificates.
6. Update assembly version of `Azure.Core` and changed dependencies to .NET Framework in `/src/Accounts/Authentication/Utilities/CustomAssemblyResolver.cs`.
7. Verify built `Az.Accounts` can work with existing Azure PowerShell modules on PowerShell 7 and Windows PowerShell.
   - Import module into PowerShell 7 or Windows PowerShell, and ensure there is no error in verbose output
    ```powershell
    $VerbosePreference = "Continue"
    Import-Module .\artifacts\Release\Az.Accounts\Az.Accounts.psd1
    ```
   - Connect to Azure and switch to your test subscription
    ```powershell
    Connect-AzAccount
    Set-AzContext -Subscription <target subscription name>
    ```
   - Execute sanity test and ensure all modules can be imported correctly
    ```powershell
    (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/main/tools/Test/SmokeTest/RmCoreSmokeTests.ps1").Content | Invoke-Expression
    ```

Please note `Azure.Core` **CANNOT** be upgraded till the next Az major release if above test is failed. 

## FAQ
### How to list all loaded assemblies in PowerShell session?
Below script can be used to list all loaded assemblies when modules are imported. It is also used to detect the imported module which loads lower version of assembly and blocks Azure PowerShell modules.
```powershell
[System.AppDomain]::CurrentDomain.GetAssemblies() | Where-Object Location | Sort-Object -Property FullName | Select-Object -Property FullName, Location
```

### How to check version and target framework of assembly?
We recommend [ILSpy](https://github.com/icsharpcode/ILSpy). 

### How to get detailed information for assembly binds?
PowerShell normally shows brief information when required assembly cannot be found or loaded. Assembly Binding Log Viewer can help to display details. This tool is installed with Visual Studio together. You need to run `Visual Studio Developer PowerShell` with administrator privileges and execute `fuslogvw` to invoke this tool.

For more information, please reference https://docs.microsoft.com/en-us/dotnet/framework/tools/fuslogvw-exe-assembly-binding-log-viewer