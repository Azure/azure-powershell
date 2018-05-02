# Introduction
Output is the most important part of any interactive console application including Powershell. PowerShell has a set of  [format cmdlets](https://docs.microsoft.com/en-us/powershell/scripting/getting-started/cookbooks/using-format-commands-to-change-output-view?view=powershell-6) that allow you to control the cmdlet output format:
1. Format-Wide
2. Format-List
3. Format-Table
4. Format-Custom

Each format cmdlet has default properties that will be used if you do not specify specific properties to display. Each cmdlet also uses the same parameter name, **Property**, to specify which properties you want to display.

Our team trends to make the cmdlets output more convenient and consistent across all the resource providers and chasing the following goals:
1. Default output for cmdlets should be displayed in a table view.
2. Output should include only essential properties with clear labels.


# How table view output works by default.

 As an example let's consider [Get-AzureRmSubscription](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Profile/Commands.Profile/Subscription/GetAzureRMSubscription.cs) cmdlet. 

The cmdlet class specifies the ```PSAzureSubscription``` class as an output type with the **OutputType attribute**:

```Cs
namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSubscription", DefaultParameterSetName = ListByIdInTenantParameterSet),
        OutputType(typeof(PSAzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRmLongRunningCmdlet
    {
        public const string ListByIdInTenantParameterSet = "ListByIdInTenant";
        public const string ListByNameInTenantParameterSet = "ListByNameInTenant";

// omitted for brevity the rest of the definition.
```

The [PSAzureSubscription](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Common/Commands.Common.Authentication.ResourceManager/Models/PSAzureSubscription.cs) class contains several public properties. 

* Id
* Name
* State
* SubscriptionId
* TenantId
* CurrentStorageAccountName
* ExtendedProperties

```Cs
// code omitted for brevity 
namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSAzureSubscription : IAzureSubscription
    {

// code omitted for brevity 

        public string Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string SubscriptionId { get { return Id; } }

        public string TenantId
        {
            get
            {
                return this.GetTenant();
            }
            set
            {
                this.SetTenant(value);
            }
        }

        public string CurrentStorageAccountName
        {
            get
            {
                return GetAccountName(CurrentStorageAccount);
            }
        }

        public IDictionary<string, string> ExtendedProperties { get; }

// code omitted for brevity 
```

PowerShell uses these properties for the cmdlet table formated output:

```PowerShell
PS C:\> Get-AzureRmSubscription | Format-Table

Id                                   Name                      State   SubscriptionId                       TenantId                             CurrentStorageAcc
                                                                                                                                                 ountName
--                                   ----                      -----   --------------                       --------                             -----------------
c9cbd920-c00c-427c-852b-c329e824c3a8 Azure SDK Powershell Test Enabled c9cbd920-c00c-427c-852b-c329e824c3a8 72f988bf-86f1-41af-91ab-7a64d1d63df5
6b085460-5f21-477e-ba44-4cd9fbd030ef Azure SDK Infrastructure  Enabled 6b085460-5f21-477e-ba44-4cd9fbd030ef 72f988bf-86f1-41af-91ab-7a64d1d63df5


```

The default table output reveals some issues:
* The selected fields don't fit in a standard window
* The columns are not displayed in order of importance to the customer for doing their work.
* **SubscriptionId** property values duplicates the **Id** property values, 
* **CurrentStorageAccountName** property values are empty 
* **ExtendedProperties** property values don't fit in the console window and omitted.

# File format.ps1xml.

Powershell allows to configure cmdlets output view with the [format.ps1xml](https://msdn.microsoft.com/en-us/library/gg580992) files.

To provide a better PowerShell Azure cmdlets output experience we worked out a mechanism to quickly generate a [format.ps1xml](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_format.ps1xml?view=powershell-6) file:


1. Mark all the cmdlet output type public properties that should go to the table output with the *Ps1XmlAttribute* attribute.
2. Run the New-FormatPs1Xml cmdlet to generate the format.ps1xml file.

---
 We presume that for the [output type](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/azure-powershell-design-guidelines.md#output-type) you created a new class that, for example,  wraps a returning .NET SDK type, rather than PSObject.

---


#  Ps1XmlAttribute attribute.

The key element of the mechanism is the **Ps1XmlAttribute** attribute located in the [Commands.Common](https://github.com/Azure/azure-powershell/blob/preview/src/Common/Commands.Common/Attributes/Ps1XmlAttribute.cs) project. Below is the attribute definition:

```Cs
namespace Microsoft.WindowsAzure.Commands.Common.Attributes
{
    [Flags]
    public enum ViewControl
    {
        None = 0,
        Table,
        List,
        All = Table | List,
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class Ps1XmlAttribute : Attribute
    {
        public string Label { get; set; }

        public ViewControl Target { get; set; } = ViewControl.Table;
    }
}

```

With the attribute you can specify for a public property (or field) a target view (table view is default) and a label.

# Ps1XmlAttribute attribute usage.

Let's say for our example we want to only show these parameters in the output:
* Id
* Name
* State
* TenantId

We just need to add the Ps1Xml attribute to the selected properties:

```Cs
// code omitted for brevity
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSAzureSubscription : IAzureSubscription
    {

// code omitted for brevity

        [Ps1Xml(Label = "Subscription Id", Target = ViewControl.Table)]
        public string Id { get; set; }

        [Ps1Xml(Label = "Subscription Name", Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Label = "State", Target = ViewControl.Table)]
        public string State { get; set; }

        public string SubscriptionId { get { return Id; } }

        [Ps1Xml(Label = "Tenant Id", Target = ViewControl.Table)]
        public string TenantId
        {
            get
            {
                return this.GetTenant();
            }
            set
            {
                this.SetTenant(value);
            }
        }

        public string CurrentStorageAccountName
        {
            get
            {
                return GetAccountName(CurrentStorageAccount);
            }
        }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

// code omitted for brevity 
```
* The column order in the output table will be the same as the order of the properties in the class:
  ```
  Id Name State TenantId
  == ==== ===== ========
  ```
* If **Label** is not specified - the property name will be used. 

* Since the **Ps1Xml attribute** definition is located in the [Commands.Common](https://github.com/Azure/azure-powershell/tree/preview/src/Common/Commands.Common) project and the Command.Common project is likely referenced from your project - to make the attribute visible - you only need to add ```using Microsoft.WindowsAzure.Commands.Common.Attributes;``` statement.


# How to generate format.ps1xml file.

1. First of all you need to [build](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/azure-powershell-developer-guide.md#building-the-environment) PowerShell Azure:

```Powershell
PS E:\git\azure-powershell> msbuild build.proj /p:SkipHelp=true
```

* After the build is completed you can find build artifacts in the ```.\src\Package\Debug``` folder:

```Powershell
PS E:\git\azure-powershell> ls .\src\Package\Debug\


    Directory: E:\git\azure-powershell\src\Package\Debug


Mode                LastWriteTime         Length Name
----                -------------         ------ ----
d-----        4/25/2018   4:37 PM                ResourceManager
d-----        4/25/2018   4:35 PM                ServiceManagement
d-----        4/25/2018   4:35 PM                Storage
-a----        4/25/2018   4:31 PM          11384 AzureRM.psd1
-a----        4/25/2018   4:50 PM           8708 AzureRM.psm1

```

2. Import the **RepoTask cmdlets**:

```PowerShell
PS E:\git\azure-powershell> Import-Module E:\git\azure-powershell\tools\RepoTasks\RepoTasks.Cmdlets\bin\Debug\RepoTasks.Cmdlets.dll
```
3. Run the **New-FormatPs1Xml** cmdlet. 
* The cmdlet has one required argument **-ModulePath** - a path to a module manifest (psd1) file. Since in our example we are using the Get-AzureRmSubscription cmdlet from the AzureRM.Profile module we need to specify path to the AzureRm.Profile module manifest which is 
```
E:\git\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1 
``` 
* Also with the cmdlet we need to use **-OnlyMarkedProperties** switch.
* You may also want to specify an output path for the generated file with the **-OutputPath** argument. If not specified this is current folder.

```
PS E:\git\azure-powershell> New-FormatPs1Xml -ModulePath .\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1 -OnlyMarkedProperties

E:\git\azure-powershell\Microsoft.Azure.Commands.Profile.generated.format.ps1xml
```
* After a successful run the cmdlet outputs the full path to the generated format.ps1xml file.

# How to test the format.ps1xml file.

**Note:** All the paths used in the example in the section are under **_azure-powershell/src/Package/Debug_**

1. **Copy** the generated format.ps1xml file to the built module folder (this is where your module manifest file psd1 is located). In our example the module folder is 
```
E:\git\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile
```

2. Modify your module manifest file. 
* In our example the module manifest is AzureRM.Profile.psd1: 
```
E:\git\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1 
``` 

* In the module manifest file there is a variable called **FormatsToProcess** to reference format.ps1xml files.
If the variable already has a value - **insert** you generated file before the value following by comma (or just replace it).
In our example insert the generated file ```'.\Microsoft.Azure.Commands.Profile.generated.format.ps1xml'``` before the existing one ```'.\Microsoft.Azure.Commands.Profile.format.ps1xml'```:

```Powershell
# script omitted for brevity

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = '.\Microsoft.Azure.Commands.Profile.generated.format.ps1xml', '.\Microsoft.Azure.Commands.Profile.format.ps1xml'

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
NestedModules = @('.\Microsoft.Azure.Commands.Profile.dll')

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = @()

# script omitted for brevity
```
3. Open a **PowerShell window** and **import** your module. In our example it is AzureRm.Profile:
```Powershell
PS C:\> Import-Module E:\git\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1
```

4. Try your cmdlet out. In our example it is Get-AuzreRmSubsription:
```Powershell
PS C:\> Get-AzureRmSubscription

Subscription Id                      Subscription Name         State   Tenant Id
---------------                      -----------------         -----   ---------
c9cbd920-c00c-427c-852b-c329e824c3a8 Azure SDK Powershell Test Enabled 72f988bf-86f1-41af-91ab-7a64d1d63df5
6b085460-5f21-477e-ba44-4cd9fbd030ef Azure SDK Infrastructure  Enabled 72f988bf-86f1-41af-91ab-7a64d1d63df5
```
* Note the table output happens without ```| Format-Table``` cmdlet usage.


# How to add the format.ps1xml file to your project.

**Note:** All the paths used in the example in the section are under **_azure-powershell/src/ResourceManager/Profile_**


1. Copy the generated file into your project source folder. In our example this is [src/ResourceManager/Profile/Commands.Profile](https://github.com/Azure/azure-powershell/tree/preview/src/ResourceManager/Profile/Commands.Profile) folder.

2. Reference the generated format.ps1xml file form your project. In our example this is [Commands.Profile.csproj](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Profile/Commands.Profile/Commands.Profile.csproj) file:

```Xml
  <ItemGroup>
    <Content Include="Microsoft.Azure.Commands.Profile.generated.format.ps1xml">
      <SubType>Designer</SubType>
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <Content Include="Microsoft.Azure.Commands.Profile.format.ps1xml">
      <SubType>Designer</SubType>
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <None Include="..\AzureRM.Profile.psd1">
      <Link>AzureRM.Profile.psd1</Link>
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <Content Include="Microsoft.Azure.Commands.Profile.types.ps1xml">
      <SubType>Designer</SubType>
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <None Include="MSSharedLibKey.snk" />
    <None Include="packages.config" />
    <None Include="StartupScripts\*.ps1">
      <!-- <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory> -->
    </None>
  </ItemGroup>
```
3. Add the generated format.ps1xml file to your source module manifest **FormatsToProcess** variable. In our example this is [src/ResourceManager/Profile/AzureRM.Profile.psd1](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Profile/AzureRM.Profile.psd1) file:
```Powershell
# script omitted for brevity

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = '.\Microsoft.Azure.Commands.Profile.generated.format.ps1xml', '.\Microsoft.Azure.Commands.Profile.format.ps1xml'

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
NestedModules = @('.\Microsoft.Azure.Commands.Profile.dll')

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = @()

# script omitted for brevity
```

