# WhatIf 格式化器共享库 - 快速开始

## 简介

这个库提供了一套可重用的 WhatIf 格式化工具，可以被任何 Azure PowerShell RP 模块使用。

## 快速开始

### 1. 添加 using 语句

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
```

### 2. 格式化 JSON

```csharp
var jsonData = JObject.Parse(@"{ ""name"": ""myResource"" }");
string output = WhatIfJsonFormatter.FormatJson(jsonData);
Console.WriteLine(output);
```

### 3. 使用颜色

```csharp
var builder = new ColoredStringBuilder();
builder.Append("Creating: ", Color.Reset);
builder.Append("myResource", Color.Green);
builder.AppendLine();
```

## 可用组件

| 组件 | 用途 |
|------|------|
| `Color` | ANSI 颜色定义 (Green, Orange, Purple, Blue, Gray, Red, etc.) |
| `Symbol` | 操作符号 (+, -, ~, !, =, *, x) |
| `ColoredStringBuilder` | 带颜色支持的字符串构建器 |
| `WhatIfJsonFormatter` | JSON 格式化基类 |
| `JTokenExtensions` | JSON 扩展方法 (IsLeaf, IsNonEmptyArray, etc.) |
| `DiagnosticExtensions` | 诊断级别到颜色的转换 |

## 颜色映射

| 颜色 | 用途 |
|------|------|
| 🟢 Green | 创建操作 |
| 🟣 Purple | 修改操作 |
| 🟠 Orange | 删除操作 |
| 🔵 Blue | 部署操作 |
| ⚪ Gray | 无影响/忽略操作 |
| 🔴 Red | 错误 |
| 🟡 DarkYellow | 警告 |

## 符号映射

| 符号 | 含义 |
|------|------|
| `+` | 创建 (Create) |
| `-` | 删除 (Delete) |
| `~` | 修改 (Modify) |
| `!` | 部署 (Deploy) |
| `=` | 无变化 (NoChange) |
| `*` | 忽略 (Ignore) |
| `x` | 不支持/无影响 (Unsupported/NoEffect) |

## 完整示例

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
using Newtonsoft.Json.Linq;

public class MyWhatIfCommand
{
    public void ExecuteWhatIf()
    {
        var builder = new ColoredStringBuilder();
        
        // 标题
        builder.AppendLine("Resource and property changes are indicated with these symbols:");
        builder.Append("  ");
        builder.Append(Symbol.Plus, Color.Green);
        builder.AppendLine(" Create");
        builder.Append("  ");
        builder.Append(Symbol.Tilde, Color.Purple);
        builder.AppendLine(" Modify");
        builder.AppendLine();
        
        // 资源变更
        builder.AppendLine("Scope: /subscriptions/xxx/resourceGroups/myRG");
        builder.AppendLine();
        
        using (builder.NewColorScope(Color.Green))
        {
            builder.Append("  ");
            builder.Append(Symbol.Plus);
            builder.AppendLine(" Microsoft.Storage/storageAccounts/myAccount");
            
            var resourceConfig = new JObject
            {
                ["location"] = "eastus",
                ["sku"] = new JObject { ["name"] = "Standard_LRS" }
            };
            
            builder.AppendLine();
            var formatter = new WhatIfJsonFormatter(builder);
            formatter.FormatJson(resourceConfig, indentLevel: 2);
        }
        
        builder.AppendLine();
        builder.Append("Resource changes: ");
        builder.Append("1 to create", Color.Green);
        builder.AppendLine(".");
        
        Console.WriteLine(builder.ToString());
    }
}
```

## 更多信息

- 详细文档: `/src/shared/WhatIf/README.md`
- 使用示例: `/src/shared/WhatIf/USAGE_EXAMPLES.md`
- 原始实现: `/src/Resources/ResourceManager/Formatters/`

## 迁移指南

如果你正在从 `Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters` 迁移：

**只需要更改 namespace！** API 保持完全兼容。

```diff
- using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
- using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
+ using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
+ using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
```

其他代码无需修改！
