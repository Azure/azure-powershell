# How to define AssemblyLoadContext for module

We'll use Compute module as example to explain how to define its own AssemlbyLoadContext.

## Create ALC Wrapper Project

Create one ALC wrapper project named Compute.AlcWrapper.csproj which wraps the usaged of Azure.Storage.Blobs

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <PsModuleName>Compute</PsModuleName>
    <OmitJsonPackage>true</OmitJsonPackage>
  </PropertyGroup>

  <Import Project="$(MSBuildThisFileDirectory)..\..\Az.props" />

  <PropertyGroup>
    <RootNamespace>$(LegacyAssemblyPrefix)$(PsModuleName).AlcWrapper</RootNamespace>
    <AssemblyName>$(LegacyAssemblyPrefix)$(PsModuleName).AlcWrapper</AssemblyName>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Azure.Storage.Blobs" Version="12.1.0" />
  </ItemGroup>

</Project>
```

## Define Public APIs within ALC Wrapper Project

As Compute.csproj project must not reference to storage SDK, the types of parameters and return values of public APIs within this project should not expose any types defined in storage SDK.

```csharp
    public class AzureStorageService
    {
        public AzureStorageService()
        {
        }

        public void UseBlobClientOptions()
        {
            var options = new BlobClientOptions();
        }

        public PSBlobDownloadInfo DownloadBlob()
        {
            //TODO: Please repalce with your real account
            BlobClient client = new BlobClient("", "", "");
            BlobDownloadInfo info = client.Download().Value;
            return new PSBlobDownloadInfo(info);
        }
    }

    //Classes from storage SDK should be wrapped and must not be exposed as public here  
    public class PSBlobDownloadInfo
    {
        private BlobDownloadInfo _blobDownloadInfo;

        internal PSBlobDownloadInfo(BlobDownloadInfo info)
        {
            _blobDownloadInfo = info;
        }

        public long ContentLength { get { return _blobDownloadInfo.ContentLength; } }

        public Stream Content { get { return _blobDownloadInfo.Content; } }

        public string ContentType { get { return _blobDownloadInfo.ContentType; } }
    }
```

## Update Module Project to Use Public APIs of ALC Wrapper Project

1. Add project reference to Compute.AlcWrapper and update Compute project code to use public APIs defined in above steps.

1. Update `Debug` tab of Compute project for debugging. **You must replace 'C:\AME\erich-powershell' with real solution directory of azure-powershell on your PC**

    - **Launch**: Executable
    - **Executable**: pwsh
    - **Application arguments**: -NoExit -Command "Import-Module C:\AME\erich-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1;Import-Module C:\AME\erich-powershell\artifacts\Debug\Az.Compute\Az.Compute.psd1;"

1. [To Be Automated]Update Compute.csproj to define property `ModuleAlcEntryAssembly` and `ModuleAlcRefAssembly`. `ModuleAlcEntryAssembly` is entry assembly of separate AssemblyLoadContext referenced by module project; `ModuleAlcRefAssembly` is collection of assembly referenced by `ModuleAlcEntryAssembly`

    ```xml
    <PropertyGroup>
      <ModuleAlcEntryAssembly>Microsoft.Azure.Commands.Compute.AlcWrapper</ModuleAlcEntryAssembly>
    </PropertyGroup>

    <ItemGroup>
      <ModuleAlcRefAssembly Include="Azure.Storage.Blobs" />
      <ModuleAlcRefAssembly Include="Azure.Storage.Common" />
    </ItemGroup>
    ```

1. [To Be Automated]Add new build targets file src/Compute/Compute/Directory.Build.targets

    ```xml
    <Project>
      <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory).., Directory.Build.targets))\Directory.Build.targets" />
      <Target Name="AddAccountsPsm1Dependency" AfterTargets="Build" Condition="'$(Configuration)' == 'Debug'">
        <Exec Command="pwsh -NonInteractive -NoLogo -NoProfile -Command &quot;. '$(OutDir)../../../tools/AddModulePsm1Dependency.ps1' -ModuleFolder '$(OutDir)' -IgnorePwshVersion &quot;" />
      </Target>
      <Target Name="PostBuildModuleAlc" AfterTargets="Build" Condition="'$(ModuleAlcEntryAssembly)' != ''">
        <!--generate ps1; move ALC assembly to sub folder-->
        <Exec Command="pwsh -NonInteractive -NoLogo -NoProfile -Command &quot;. '$(OutDir)../../../tools/PostBuildModuleAlc.ps1' -ModuleFolder '$(OutDir)' -AlcEntryAssembly '$(ModuleAlcEntryAssembly)' -AlcRefAssembly '@(ModuleAlcRefAssembly)' -Configuration '$(Configuration)' &quot;" />
      </Target>
    </Project>
    ```
