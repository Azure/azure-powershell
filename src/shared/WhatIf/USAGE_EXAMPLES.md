# WhatIf 共享库使用示例

这个文件包含了如何在不同场景下使用 WhatIf 共享库的示例代码。

## 示例 1: 基本 JSON 格式化

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
using Newtonsoft.Json.Linq;

public class Example1_BasicJsonFormatting
{
    public static void Run()
    {
        // 创建一些示例 JSON 数据
        var jsonData = new JObject
        {
            ["name"] = "myStorageAccount",
            ["location"] = "eastus",
            ["sku"] = new JObject
            {
                ["name"] = "Standard_LRS"
            },
            ["properties"] = new JObject
            {
                ["supportsHttpsTrafficOnly"] = true,
                ["encryption"] = new JObject
                {
                    ["services"] = new JObject
                    {
                        ["blob"] = new JObject { ["enabled"] = true },
                        ["file"] = new JObject { ["enabled"] = true }
                    }
                }
            }
        };

        // 使用静态方法格式化
        string formattedOutput = WhatIfJsonFormatter.FormatJson(jsonData);
        
        // 输出到控制台（会显示颜色）
        Console.WriteLine(formattedOutput);
    }
}
```

## 示例 2: 使用 ColoredStringBuilder

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;

public class Example2_ColoredStringBuilder
{
    public static void FormatResourceChanges(int createCount, int modifyCount, int deleteCount)
    {
        var builder = new ColoredStringBuilder();
        
        // 标题
        builder.AppendLine("Resource changes:");
        builder.AppendLine();
        
        // 创建操作
        if (createCount > 0)
        {
            builder.Append("  ");
            builder.Append(Symbol.Plus, Color.Green);
            builder.Append(" ", Color.Reset);
            builder.Append($"{createCount} to create", Color.Green);
            builder.AppendLine();
        }
        
        // 修改操作
        if (modifyCount > 0)
        {
            builder.Append("  ");
            builder.Append(Symbol.Tilde, Color.Purple);
            builder.Append(" ", Color.Reset);
            builder.Append($"{modifyCount} to modify", Color.Purple);
            builder.AppendLine();
        }
        
        // 删除操作
        if (deleteCount > 0)
        {
            builder.Append("  ");
            builder.Append(Symbol.Minus, Color.Orange);
            builder.Append(" ", Color.Reset);
            builder.Append($"{deleteCount} to delete", Color.Orange);
            builder.AppendLine();
        }
        
        Console.WriteLine(builder.ToString());
    }
}
```

## 示例 3: 使用颜色作用域

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;

public class Example3_ColorScopes
{
    public static void FormatHierarchicalData()
    {
        var builder = new ColoredStringBuilder();
        
        builder.AppendLine("Deployment scope: /subscriptions/xxx/resourceGroups/myRG");
        builder.AppendLine();
        
        // 使用 using 语句自动管理颜色作用域
        using (builder.NewColorScope(Color.Green))
        {
            builder.Append("  ");
            builder.Append(Symbol.Plus);
            builder.Append(" Microsoft.Storage/storageAccounts/myAccount");
            builder.AppendLine();
            
            // 嵌套作用域
            using (builder.NewColorScope(Color.Reset))
            {
                builder.AppendLine("    location: eastus");
                builder.AppendLine("    sku.name: Standard_LRS");
            }
        }
        
        builder.AppendLine();
        
        using (builder.NewColorScope(Color.Purple))
        {
            builder.Append("  ");
            builder.Append(Symbol.Tilde);
            builder.Append(" Microsoft.Network/virtualNetworks/myVnet");
            builder.AppendLine();
        }
        
        Console.WriteLine(builder.ToString());
    }
}
```

## 示例 4: 自定义 Formatter 类

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
using Newtonsoft.Json.Linq;

public class MyResourceWhatIfFormatter : WhatIfJsonFormatter
{
    public MyResourceWhatIfFormatter(ColoredStringBuilder builder) : base(builder)
    {
    }
    
    public string FormatResourceChange(
        string changeType,
        string resourceId,
        JObject beforeState,
        JObject afterState)
    {
        // 根据变更类型选择颜色
        Color changeColor = changeType switch
        {
            "Create" => Color.Green,
            "Modify" => Color.Purple,
            "Delete" => Color.Orange,
            _ => Color.Reset
        };
        
        Symbol changeSymbol = changeType switch
        {
            "Create" => Symbol.Plus,
            "Modify" => Symbol.Tilde,
            "Delete" => Symbol.Minus,
            _ => Symbol.Equal
        };
        
        using (this.Builder.NewColorScope(changeColor))
        {
            // 格式化资源标题
            this.Builder.Append("  ");
            this.Builder.Append(changeSymbol);
            this.Builder.Append(" ");
            this.Builder.Append(resourceId);
            this.Builder.AppendLine();
            this.Builder.AppendLine();
            
            // 格式化 before/after 状态
            if (changeType == "Modify" && beforeState != null && afterState != null)
            {
                this.Builder.AppendLine("    Before:");
                this.FormatJson(beforeState, indentLevel: 3);
                
                this.Builder.AppendLine();
                this.Builder.AppendLine("    After:");
                this.FormatJson(afterState, indentLevel: 3);
            }
            else if (changeType == "Create" && afterState != null)
            {
                this.FormatJson(afterState, indentLevel: 2);
            }
            else if (changeType == "Delete" && beforeState != null)
            {
                this.FormatJson(beforeState, indentLevel: 2);
            }
        }
        
        return this.Builder.ToString();
    }
}

// 使用示例
public class Example4_CustomFormatter
{
    public static void Run()
    {
        var builder = new ColoredStringBuilder();
        var formatter = new MyResourceWhatIfFormatter(builder);
        
        var afterState = new JObject
        {
            ["name"] = "myResource",
            ["location"] = "eastus",
            ["properties"] = new JObject
            {
                ["enabled"] = true
            }
        };
        
        string output = formatter.FormatResourceChange(
            "Create",
            "/subscriptions/xxx/resourceGroups/rg/providers/Microsoft.MyService/resources/myResource",
            null,
            afterState);
        
        Console.WriteLine(output);
    }
}
```

## 示例 5: 格式化诊断信息

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
using static Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions.DiagnosticExtensions;

public class Example5_Diagnostics
{
    public class DiagnosticMessage
    {
        public string Level { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
    }
    
    public static void FormatDiagnostics(List<DiagnosticMessage> diagnostics)
    {
        var builder = new ColoredStringBuilder();
        
        builder.AppendLine($"Diagnostics ({diagnostics.Count}):");
        builder.AppendLine();
        
        foreach (var diagnostic in diagnostics)
        {
            // 使用扩展方法将级别转换为颜色
            Color levelColor = diagnostic.Level.ToColor();
            
            using (builder.NewColorScope(levelColor))
            {
                builder.Append($"  [{diagnostic.Level}] ");
                builder.Append($"{diagnostic.Code}: ");
                builder.Append(diagnostic.Message);
                
                if (!string.IsNullOrEmpty(diagnostic.Target))
                {
                    builder.Append($" (Target: {diagnostic.Target})");
                }
                
                builder.AppendLine();
            }
        }
        
        Console.WriteLine(builder.ToString());
    }
    
    public static void Run()
    {
        var diagnostics = new List<DiagnosticMessage>
        {
            new DiagnosticMessage
            {
                Level = Level.Warning,
                Code = "W001",
                Message = "Resource will be created in a different region than the resource group",
                Target = "/subscriptions/xxx/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/sa"
            },
            new DiagnosticMessage
            {
                Level = Level.Error,
                Code = "E001",
                Message = "Invalid SKU specified for this region",
                Target = "/subscriptions/xxx/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm"
            },
            new DiagnosticMessage
            {
                Level = Level.Info,
                Code = "I001",
                Message = "Using default value for unspecified property",
                Target = null
            }
        };
        
        FormatDiagnostics(diagnostics);
    }
}
```

## 示例 6: 从 Resources 模块迁移

### 迁移前的代码 (Resources 模块)

```csharp
// 旧的 namespace
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

public class OldResourcesCode
{
    public void Format()
    {
        var builder = new ColoredStringBuilder();
        builder.Append("Creating ", Color.Reset);
        builder.Append("resource", Color.Green);
        
        // 使用 JTokenExtensions
        var json = JObject.Parse("...");
        if (json.IsNonEmptyObject())
        {
            // ...
        }
    }
}
```

### 迁移后的代码 (使用共享库)

```csharp
// 新的 namespace
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;

public class NewSharedLibraryCode
{
    public void Format()
    {
        // API 完全相同，只需要更改 using 语句
        var builder = new ColoredStringBuilder();
        builder.Append("Creating ", Color.Reset);
        builder.Append("resource", Color.Green);
        
        // 使用 JTokenExtensions
        var json = JObject.Parse("...");
        if (json.IsNonEmptyObject())
        {
            // ...
        }
    }
}
```

## 示例 7: 在其他 RP 模块中使用

```csharp
// 例如在 Compute 模块中
namespace Microsoft.Azure.Commands.Compute.Whatif
{
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
    using Newtonsoft.Json.Linq;

    public class ComputeWhatIfFormatter : WhatIfJsonFormatter
    {
        public ComputeWhatIfFormatter(ColoredStringBuilder builder) : base(builder)
        {
        }
        
        public void FormatVMChange(string vmName, string changeType, JObject vmConfig)
        {
            Color color = changeType switch
            {
                "Create" => Color.Green,
                "Modify" => Color.Purple,
                "Delete" => Color.Orange,
                _ => Color.Reset
            };
            
            using (this.Builder.NewColorScope(color))
            {
                this.Builder.AppendLine($"Virtual Machine: {vmName}");
                this.Builder.AppendLine($"Change Type: {changeType}");
                this.Builder.AppendLine();
                
                if (vmConfig != null)
                {
                    this.FormatJson(vmConfig, indentLevel: 1);
                }
            }
        }
    }
}

// 在 Storage 模块中类似使用
namespace Microsoft.Azure.Commands.Storage.Whatif
{
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;

    public class StorageWhatIfFormatter : WhatIfJsonFormatter
    {
        public StorageWhatIfFormatter(ColoredStringBuilder builder) : base(builder)
        {
        }
        
        // 添加 Storage 特定的格式化逻辑
    }
}
```

## 编译和引用

确保您的项目文件（.csproj）包含对共享代码的引用。如果文件在同一个解决方案中，它们应该自动包含。

如果需要显式引用，可以使用：

```xml
<ItemGroup>
  <Compile Include="..\..\shared\WhatIf\**\*.cs" />
</ItemGroup>
```

或者如果使用项目引用：

```xml
<ItemGroup>
  <ProjectReference Include="..\..\shared\SharedLibrary.csproj" />
</ItemGroup>
```

## 注意事项

1. **颜色支持**: ANSI 颜色代码在大多数现代终端中工作，但在某些环境（如旧版 Windows CMD）中可能不显示
2. **性能**: ColoredStringBuilder 在内部使用 StringBuilder，对大量文本操作是高效的
3. **线程安全**: 这些类不是线程安全的，应在单线程上下文中使用
4. **内存**: 对于非常大的 JSON 对象，考虑分段格式化以节省内存

## 更多资源

- 查看 `/src/shared/WhatIf/README.md` 了解库的详细文档
- 查看 Resources 模块中的现有使用示例
- 参考单元测试了解更多用法场景
