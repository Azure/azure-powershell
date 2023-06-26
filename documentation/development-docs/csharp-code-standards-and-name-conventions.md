# C# Coding Standards and Naming Conventions

| Name Kind       | Rule                |
| --------------- | ------------------- |
| Namespace       | `PascalCase`        |
| Class           | `PascalCase`        |
| Private Field   | `camelCase` or `_camelCase` |
| Public/Protected Field   | `camelCase`|
| Property        | `PascalCase`        |
| Method          | `PascalCase`        |
| Event           | `PascalCase`        |
| Enum Type       | `PascalCase`        |
| Enum Value      | `PascalCase`        |
| Interface       | `IPascalCase`       |
| Local Variable  | `camelCase`         |
| Parameter       | `camelCase`         |

#### 1. Do use PascalCasing for class names and method names:

```csharp
public class ClientActivity
{
  public void ClearStatistics()
  {
    //...
  }
  public void CalculateStatistics()
  {
    //...
  }
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 2. Do use camelCasing for method arguments and local variables:

```csharp
public class UserLog
{
  public void Add(LogEvent logEvent)
  {
    int itemCount = logEvent.Items.Count;
    // ...
  }
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 3. Do not use Hungarian notation or any other type identification in identifiers

```csharp
// Correct
int counter;
string name;    
// Avoid
int iCounter;
string strName;
```

***Why: consistent with the Microsoft's .NET Framework and Visual Studio IDE makes determining types very easy (via tooltips). In general, you want to avoid type indicators in any identifier.***

#### 4. Do not use Screaming Caps for constants or readonly variables:

```csharp
// Correct
public const string ShippingType = "DropShip";
// Avoid
public const string SHIPPINGTYPE = "DropShip";
```

***Why: consistent with the Microsoft's .NET Framework. Caps grab too much attention.***

#### 5. Use meaningful names for variables. The following example uses seattleCustomers for customers who are located in Seattle:

```csharp
var seattleCustomers = from customer in customers
  where customer.City == "Seattle" 
  select customer.Name;
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 6. Avoid using Abbreviations. Exceptions: abbreviations commonly used as names, such as Id, Xml, Ftp, Uri.

```csharp    
// Correct
UserGroup userGroup;
Assignment employeeAssignment;     
// Avoid
UserGroup usrGrp;
Assignment empAssignment; 
// Exceptions
CustomerId customerId;
XmlDocument xmlDocument;
FtpHelper ftpHelper;
UriPart uriPart;
```

***Why: consistent with the Microsoft's .NET Framework and prevents inconsistent abbreviations.***


#### 7. Do use PascalCasing or camelCasing (Depending on the identifier type) for abbreviations 3 characters or more (2 chars are both uppercase when PascalCasing is appropriate or inside the identifier).:

```csharp  
HtmlHelper htmlHelper;
FtpTransfer ftpTransfer, fastFtpTransfer;
UIControl uiControl, nextUIControl;
```

***Why: consistent with the Microsoft's .NET Framework. Caps would grab visually too much attention.***

#### 8. Do not use Underscores in identifiers. Exception: you can prefix private fields with an underscore:

```csharp 
// Correct
public DateTime clientAppointment;
public TimeSpan timeLeft;    
// Avoid
public DateTime client_Appointment;
public TimeSpan time_Left; 
// Exception (Class field)
private DateTime _registrationDate;
```

***Why: consistent with the Microsoft's .NET Framework and makes code more natural to read (without 'slur'). Also avoids underline stress (inability to see underline).***

#### 9. Do use predefined type names (C# aliases) like `int`, `float`, `string` for local, parameter and member declarations. Do use .NET Framework names like `Int32`, `Single`, `String` when accessing the type's static members like `Int32.TryParse` or `String.Join`.

```csharp
// Correct
string firstName;
int lastIndex;
bool isSaved;
string commaSeparatedNames = String.Join(", ", names);
int index = Int32.Parse(input);
// Avoid
String firstName;
Int32 lastIndex;
Boolean isSaved;
string commaSeparatedNames = string.Join(", ", names);
int index = int.Parse(input);
```

***Why: consistent with the Microsoft's .NET Framework and makes code more natural to read.*** 

#### 11. Do use noun or noun phrases to name a class. 

```csharp 
public class Employee
{
}
public class BusinessLocation
{
}
public class DocumentCollection
{
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to remember.***

#### 12. Do prefix interfaces with the letter I. Interface names are noun (phrases) or adjectives.

```csharp     
public interface IShape
{
}
public interface IShapeCollection
{
}
public interface IGroupable
{
}
```

***Why: consistent with the Microsoft's .NET Framework.***

#### 13. Do name source files according to their main classes. Exception: file names with partial classes reflect their source or purpose, e.g. designer, generated, etc. 

```csharp 
// Located in Task.cs
public partial class Task
{
}
// Located in Task.generated.cs
public partial class Task
{
}
```

***Why: consistent with the Microsoft practices. Files are alphabetically sorted and partial classes remain adjacent.***

#### 14. Do organize namespaces with a clearly defined structure: 

```csharp 
// Examples
namespace Company.Technology.Feature.Subnamespace
{
}
namespace Company.Product.Module.SubModule
{
}
namespace Product.Module.Component
{
}
namespace Product.Layer.Module.Group
{
}
```

***Why: consistent with the Microsoft's .NET Framework. Maintains good organization of your code base.***

#### 15. Do vertically align curly brackets: 

```csharp 
// Correct
class Program
{
  static void Main(string[] args)
  {
    //...
  }
}
```

***Why: Microsoft has a different standard, but developers have overwhelmingly preferred vertically aligned brackets.***

#### 17. Do use singular names for enums. Exception: bit field enums.

```csharp 
// Correct
public enum Color
{
  Red,
  Green,
  Blue,
  Yellow,
  Magenta,
  Cyan
} 
// Exception
[Flags]
public enum Dockings
{
  None = 0,
  Top = 1,
  Right = 2, 
  Bottom = 4,
  Left = 8
}
```

***Why: consistent with the Microsoft's .NET Framework and makes the code more natural to read. Plural flags because enum can hold multiple values (using bitwise 'OR').***


#### 19. Do not use an "Enum" suffix in enum type names:

```csharp     
// Don't
public enum CoinEnum
{
  Penny,
  Nickel,
  Dime,
  Quarter,
  Dollar
} 
// Correct
public enum Coin
{
  Penny,
  Nickel,
  Dime,
  Quarter,
  Dollar
}
```

***Why: consistent with the Microsoft's .NET Framework and consistent with prior rule of no type indicators in identifiers.***

#### 20. Do not use "Flag" or "Flags" suffixes in enum type names:

```csharp 
// Don't
[Flags]
public enum DockingsFlags
{
  None = 0,
  Top = 1,
  Right = 2, 
  Bottom = 4,
  Left = 8
}
// Correct
[Flags]
public enum Dockings
{
  None = 0,
  Top = 1,
  Right = 2, 
  Bottom = 4,
  Left = 8
}
```

***Why: consistent with the Microsoft's .NET Framework and consistent with prior rule of no type indicators in identifiers.***

#### 21. Do use suffix EventArgs at creation of the new classes comprising the information on event:

```csharp 
// Correct
public class BarcodeReadEventArgs : System.EventArgs
{
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 22. Do name event handlers (delegates used as types of events) with the "EventHandler" suffix, as shown in the following example:

```csharp 
public delegate void ReadBarcodeEventHandler(object sender, ReadBarcodeEventArgs e);
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 23. Do not create names of parameters in methods (or constructors) which differ only by the register:

```csharp 
// Avoid
private void MyFunction(string name, string Name)
{
  //...
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to read, and also excludes possibility of occurrence of conflict situations.***

#### 24. DO use two parameters named sender and e in event handlers. The sender parameter represents the object that raised the event. The sender parameter is typically of type object, even if it is possible to employ a more specific type.

```csharp
public void ReadBarcodeEventHandler(object sender, ReadBarcodeEventArgs e)
{
  //...
}
```

***Why: consistent with the Microsoft's .NET Framework and consistent with prior rule of no type indicators in identifiers.***

#### 25. Do use suffix Exception at creation of the new classes comprising the information on exception:

```csharp 
// Correct
public class BarcodeReadException : System.Exception
{
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 26. Do use prefix Any, Is, Have or similar keywords for boolean identifier:

```csharp 
// Correct
public static bool IsNullOrEmpty(string value) {
    return (value == null || value.Length == 0);
}
```

***Why: consistent with the Microsoft's .NET Framework and easy to read.***

#### 27. Use Named Arguments in method calls:
When calling a method, arguments are passed with the parameter name followed by a colon and a value. 

```csharp
// Method
public void DoSomething(string foo, int bar) 
{
...
}

// Avoid
DoSomething("someString", 1);
// Correct
DoSomething(foo: "someString", bar: 1);
```

***Why: consistent with the Microsoft's .NET Framework and easy to read. In Named Arguments, we do not need to pass the parameters in order as defined on method definition, so we can pass the arguments in any order on method calling.***

#### 28. Use Async suffix for async methods:
When defining async method, add `Async` suffix to indicate it is awaitable method. 

```csharp
// Correct
public async Task DoSomethingAsync() 
{
...
}

// Avoid
public async Task DoSomething() 
{
...
}
```

***Why: align with common pratice for async method.***


## Offical Reference

1. [MSDN General Naming Conventions](http://msdn.microsoft.com/en-us/library/ms229045(v=vs.110).aspx)
2. [C# Coding Standards and Naming Conventions](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md) 
3. [MSDN Naming Guidelines](http://msdn.microsoft.com/en-us/library/xzf533w0%28v=vs.71%29.aspx)
4. [MSDN Framework Design Guidelines](http://msdn.microsoft.com/en-us/library/ms229042.aspx)