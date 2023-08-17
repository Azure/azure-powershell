# Introduction
Output is the most important part of any interactive console application including Powershell. PowerShell has a set of  [format cmdlets](https://learn.microsoft.com/en-us/powershell/scripting/getting-started/cookbooks/using-format-commands-to-change-output-view?view=powershell-6) that allow you to control the cmdlet output format:
1. Format-Wide
2. Format-List
3. Format-Table
4. Format-Custom

Each format cmdlet has default properties that will be used if you do not specify specific properties to display. Each cmdlet also uses the same parameter name, **Property**, to specify which properties you want to display.

Our team trends to make the cmdlets output more convenient and consistent across all the resource providers and chasing the following goals:
1. Default output for cmdlets should be displayed in a table view.
2. Output should include only essential properties with clear labels.


# How table view output works by default.

 As an example let's consider [Get-AzSubscription](https://github.com/Azure/azure-powershell/blob/master/src/Accounts/Accounts/Subscription/GetAzureRMSubscription.cs) cmdlet. 

The cmdlet class specifies the ```PSAzureSubscription``` class as an output type with the **OutputType attribute**:

```Cs
namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzSubscription", DefaultParameterSetName = ListByIdInTenantParameterSet),
        OutputType(typeof(PSAzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRmLongRunningCmdlet
    {
        public const string ListByIdInTenantParameterSet = "ListByIdInTenant";
        public const string ListByNameInTenantParameterSet = "ListByNameInTenant";

// omitted for brevity the rest of the definition.
```

The [PSAzureSubscription](https://github.com/Azure/azure-powershell-common/blob/master/src/Authentication.ResourceManager/Models/PSAzureSubscription.cs) class contains several public properties. 

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
PS C:\> Get-AzSubscription | Format-Table

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

To provide a better PowerShell Azure cmdlets output experience we worked out a mechanism to quickly generate a [format.ps1xml](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_format.ps1xml?view=powershell-6) file:


1. Mark all the cmdlet output type public properties that should go to the table output with the *Ps1XmlAttribute* attribute.
2. Run the New-FormatPs1Xml cmdlet to generate the format.ps1xml file.

---
 We presume that for the [output type](./design-guidelines/cmdlet-best-practices.md#output-type) you created a new class that, for example,  wraps a returning .NET SDK type, rather than PSObject.

---


#  Ps1XmlAttribute attribute.

The key element of the mechanism is the **Ps1XmlAttribute** attribute located in the [Commands.Common](https://github.com/Azure/azure-powershell-common/blob/master/src/Common/Attributes/Ps1XmlAttribute.cs) project. Below is the attribute definition:

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

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public sealed class Ps1XmlAttribute : Attribute
    {
        public string Label { get; set; }

        public ViewControl Target { get; set; } = ViewControl.Table;

        public string ScriptBlock { get; set; }

        public bool GroupByThis { get; set; }

        public uint TableColumnWidth { get; set; }

        public uint Position { get; set; } = Ps1XmlConstants.DefaultPosition;
    }
}

```

With the attribute you can specify for a public property (or field) a target view (table view is default) and a label.

# Ps1XmlAttribute attribute usage.

## Properties of primitive types.

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

        [Ps1Xml(Label = "SubscriptionId", Target = ViewControl.Table)]
        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Label = "State", Target = ViewControl.Table)]
        public string State { get; set; }

        public string SubscriptionId { get { return Id; } }

        [Ps1Xml(Label = "TenantId", Target = ViewControl.Table)]
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

* Since the **Ps1Xml attribute** definition is located in the [Commands.Common](https://github.com/Azure/azure-powershell-common/tree/master/src/Common) project and the Command.Common project is likely referenced from your project - to make the attribute visible - you only need to add ```using Microsoft.WindowsAzure.Commands.Common.Attributes;``` statement.

## Properties of complex types.

If you have a property of a complex type, for example, Account of type IAzureAccount:
```Cs
    public class PSAzureContext : IAzureContext
    {
        // code omitted for brevity

        public IAzureAccount Account { get; set; }

        // code omitted for brevity
    }

```
where the IAzureAccount type has its own properties :

```Cs
    public interface IAzureAccount : IExtensibleModel
    {
        string Id { get; set; }

        string Credential { get; set; }

        string Type { get; set; }

        IDictionary<string, string> TenantMap { get; }
    }
```

To specify what goes into the table view - use the **ScriptBlock** attribute property. You can use as many attributes as you need to specify all desired complex type properties: 
```Cs
    public class PSAzureContext : IAzureContext
    {
        // code omitted for brevity

        [Ps1Xml(Label = "Account.Id", Target = ViewControl.Table, ScriptBlock = "$_.Account.Id")]
        [Ps1Xml(Label = "Account.Type", Target = ViewControl.Table, ScriptBlock = "$_.Account.Type")]
        public IAzureAccount Account { get; set; }

        // code omitted for brevity
    }

```
Note: **$_** symbol in PowerShell means the same as **this** key word means in C#. 

These two attribute will result in 2 column in the table view:
```Ps
    Account.Id   Account.Type
    ==========   ============
```
## GroupBy a property.

If you need to group by a property - use the **GroupByThis** attribute property like this:
```Cs
public class PSAzureSubscription : IAzureSubscription
{

// code omitted for brevity

    [Ps1Xml(Label = "SubscriptionId", Target = ViewControl.Table, GroupByThis = true)]
    public string Id { get; set; }

// code omitted for brevity 
``` 
## Column order.

The column order in the output table will be the same as the order of the properties in the class. If you need to change this behavior - use the **Position** (zero-based) attribute property like this:
```Cs
public class PSAzureSubscription : IAzureSubscription
{

// code omitted for brevity

    [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
    public string Name { get; set; }

// code omitted for brevity 
``` 

This will place the column at the very beginning of the table.


# How to generate format.ps1xml file.

## Let's consider how to generate a format.ps1xml file for the Az.Storage and Az.Account modules.
1. Start PowerShell 6
2. Build and import the FormatPs1XmlGenerator module.
    * Go to the generator directory
    ```Powershell
    PS C:\Users\you> cd E:\git\azure-powershell\tools\FormatPs1XmlGenerator\
    ```
    * Build the generator solution
    ```Powershell
    PS E:\git\azure-powershell\tools\FormatPs1XmlGenerator> dotnet build
    ```
    * Import the generator module
    ```Powershell
    PS E:\git\azure-powershell\tools\FormatPs1XmlGenerator> Import-Module .\FormatPs1XmlGenerator\bin\Debug\FormatPs1XmlGenerator.psd1
    ```

3. Build the Az.Storage module.
    * Go to the Storage directory
    ```Powershell
    PS C:\Users\you>cd E:\git\azure-powershell\src\Storage
    ```
    * Build the module
    ```Powershell
    PS E:\git\azure-powershell\src\Storage>dotnet build
    ```
    * Go to the repository root folder
    ```Powershell
    PS E:\git\azure-powershell\src\Storage>cd E:\git\azure-powershell\
    ```
    * Check the artifacts folder - all built modules should be there. Since Az.Storage depends on the Az.Accounts module both Az.Accounts and Az.Storage modules should be there:
    ```Powershell
    PS E:\git\azure-powershell> ls .\artifacts\Debug\


    Directory: E:\git\azure-powershell\artifacts\Debug


    Mode                LastWriteTime         Length Name
    ----                -------------         ------ ----
    d-----        1/29/2019   2:18 PM                Az.Accounts
    d-----        1/29/2019   2:18 PM                Az.Storage
    ```
4. Run the **New-FormatPs1Xml** cmdlet. 
    * The cmdlet has one required parameter **-ModulePath** - a path to a module manifest (psd1) file.
    * Also with the cmdlet we need to use **-OnlyMarkedProperties** switch.
    * You may also want to specify an output path for the generated file with the **-OutputPath** argument. If not specified this is current folder.
    * After a successful run the cmdlet outputs the full path to the generated format.ps1xml file.

    * Below is an example of how to generate a format.ps1xml file for the ```Az.Storage``` module:
    ```Powershell
    PS E:\git\azure-powershell> New-FormatPs1Xml -OnlyMarkedProperties -ModulePath .\artifacts\Debug\Az.Storage\Az.Storage.psd1
    E:\git\azure-powershell\Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.generated.format.ps1xml
    E:\git\azure-powershell\Microsoft.Azure.PowerShell.Cmdlets.Storage.generated.format.ps1xml
    ```
    * Below is an example of how to generate a format.ps1xml file for the ```Az.Account``` module:
    ```powershell
    PS E:\git\azure-powershell> New-FormatPs1Xml -OnlyMarkedProperties -ModulePath .\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
    E:\git\azure-powershell\Microsoft.Azure.PowerShell.Cmdlets.Accounts.generated.format.ps1xml
    PS E:\git\azure-powershell>
    ```

# How to test the format.ps1xml file.

## Let's take a look at how to check the newly created format.ps1xml file for the ```Az.Account``` module.
**Note:** All the paths used in the example in the section are under **_azure-powershell/artifacts/Debug_**

1. **Copy** the generated format.ps1xml file to the built module folder (this is where your module manifest file psd1 is located). In our example the module folder is 
```
E:\git\azure-powershell\artifacts\Debug\Az.Accounts
```

2. Modify your module manifest file. 
* In our example the module manifest is Az.Accounts.psd1: 
```
E:\git\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1 
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
3. Open a **PowerShell window** and **import** your module. In our example it is Az.Accounts:
```Powershell
PS C:\> Import-Module E:\git\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
```

4. Try your cmdlet out. In our example it is Get-AuzreRmSubsription:
```Powershell
PS C:\> Get-AzSubscription

SubscriptionId                       Name                      State   TenantId
---------------                      -----------------         -----   ---------
c9cbd920-c00c-427c-852b-c329e824c3a8 Azure SDK Powershell Test Enabled 72f988bf-86f1-41af-91ab-7a64d1d63df5
6b085460-5f21-477e-ba44-4cd9fbd030ef Azure SDK Infrastructure  Enabled 72f988bf-86f1-41af-91ab-7a64d1d63df5
```
* Note the table output happens without ```| Format-Table``` cmdlet usage.


# How to add the format.ps1xml file to your project.

**Note:** All the paths used in the example in the section are under **_azure-powershell/src/Accounts_**

1. Copy the generated file into your project source folder. In our example this is [src/Accounts/Accounts](https://github.com/Azure/azure-powershell/tree/master/src/Accounts/Accounts) folder.

2. Reference the generated format.ps1xml file form your project. In our example this is [Accounts.csproj](https://github.com/Azure/azure-powershell/blob/master/src/Accounts/Accounts/Accounts.csproj) file.
- **Note**: This is now automatically referenced based on `Az.props` being imported in your csproj file.

3. Add the generated format.ps1xml file to your source module manifest **FormatsToProcess** variable. In our example this is [src/Accounts/Az.Accounts.psd1](https://github.com/Azure/azure-powershell/blob/master/src/Accounts/Az.Accounts.psd1) file:
```Powershell
# script omitted for brevity

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = '.\Accounts.generated.format.ps1xml', '.\Accounts.format.ps1xml'

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
NestedModules = @('.\Microsoft.Azure.PowerShell.Cmdlets.Profile.dll')

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = @()

# script omitted for brevity
```

