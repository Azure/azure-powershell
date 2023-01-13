# Common Assemblies
It is common scenario that 2 different modules take dependency on different versions of one assembly. It won't be big issue for Windows PowerShell as .NET Framework allows to load different versions of one assembly into one process. However, .NET Core and .NET 5+ do not allow to load 2 different versions of one assembly into the same [AssemblyLoadContext](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext).

As a platform, PowerShell allows user to import modules on demand. Modules may probably share the same dependency but with different versions. Assembly conflict is a common problem in PowerShell. Although Azure PowerShell cannot resolve it completely, we introduce techniques across modules of Azure PowerShell to mitigate this problem. The idea come from [Resolving PowerShell Module Assembly Dependency Conflicts](https://devblogs.microsoft.com/powershell/resolving-powershell-module-assembly-dependency-conflicts/)

To minimize conflicts among modules, shared assemblies are loaded by Az.Accounts during being imported. All assemblies should be referenced by `Common.Netcore.Dependencies.targets` and stored under `src/lib/{framework}/` according to target framework.

## PowerShell 7+ with .NET 5+
Since .NET Core and .NET 5+ cannot load 2 different versions of one assembly into the same assembly load context. `Az.Accounts` creates a dedicated context during initialization to load all the **shared** assemblies. We select shared assemblies according to their popularity, such as [Microsoft Authentication Library (MSAL.NET)](https://www.nuget.org/packages/Microsoft.Identity.Client/), [`Azure.Core`](https://www.nuget.org/packages/Azure.Core), and [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity).

Service modules of Azure PowerShell also can create their own assembly load context when they must depend on an assembly of different version from other modules. The page [How to define AssemblyLoadContext for module](/src/Accounts/AuthenticationAssemblyLoadContext) provides a comprehensive sample used by `Az.Compute`.

## Windows PowerShell with .NET Framework
The major problem on Windows PowerShell is required assembly may not be offered by Windows PowerShell or .NET Framework. `Az.Accounts` registers a handler in `CustomAssemblyResolver` to handle event that required assembly could not be resolved. It means target assembly cannot be found from the probing path of .NET Framework or Windows PowerShell. Then, resolver compares expected version and loads target from directory `/lib` in `Az.Accounts` (`src/lib/` in source code) if major version is the same. Here, we assume there is no breaking change across minor or patch versions, but it cannot be guaranteed.

For further reading, please visit https://docs.microsoft.com/en-us/dotnet/standard/assembly/resolve-loads#how-the-assemblyresolve-event-works

## Example: How to upgrade `Azure.Core`
`Azure.Core` is a common library used by management plane and data plane track 2 SDKs. Below are the steps to upgrade its version.
1. Navigate to [Common.Netcore.Dependencies.targets](/tools/Common.Netcore.Dependencies.targets) to check current version of `Azure.Core` used by latest code and bump version to expected.
2. Compare dependencies of `Azure.Core` on [nuget.org](https://www.nuget.org/packages/Azure.Core/) between current version and expected version, including the dependencies of the dependencies. Identify which of the dependencies are updated or newly introduced.
   1. You need to ensure the version CANNOT be higher than existing assembly if PowerShell already includes it.
3. For each updated assembly (including `Azure.Core`)
   1. Look for it in `src/Accounts/AssemblyLoading/ConditionalAssemblyProvider.cs`. Note down its target framework. It should be one of "netcoreapp*", "netstandard*" and "netfx" (stand for ".NET framework").
   2. Download the nuget package from nuget.org, decompress it, find the DLL with the correct framework in `lib/{framework}` and replace the one in `src/lib/{framework}` with it.
   3. Update `src/Accounts/AssemblyLoading/ConditionalAssemblyProvider.cs` with the new assembly version. To get the version, open the DLL file with [ILSpy](https://github.com/icsharpcode/ILSpy).
4. For each newly introduced assembly
   1. Download the nuget package. Decompress it.
   2. Find the assembly with desired target framework. In most cases we should choose "netstandard*" (* <= 2.0).
      - As an exception, `Microsoft.Identity.Client` needs its net461 version because of known issue with certificates.
   3. Copy the assembly to `src/lib/{framework}`.
   4. Update `src/Accounts/AssemblyLoading/ConditionalAssemblyProvider.cs` with the new assembly. To get the assembly version, open the DLL file with [ILSpy](https://github.com/icsharpcode/ILSpy).
5. Verify built `Az.Accounts` can work with existing Azure PowerShell modules on PowerShell 7 and Windows PowerShell.
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