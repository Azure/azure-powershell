# WhatIf Formatter Shared Library

## 概述

这是一个用于格式化 Azure PowerShell WhatIf 操作结果的共享库。它提供了一套可重用的格式化器、扩展方法和比较器，可以被不同的资源提供程序（RP）模块使用。

## 目录结构

```
src/shared/WhatIf/
├── Formatters/           # 格式化器类
│   ├── Color.cs         # ANSI 颜色定义
│   ├── Symbol.cs        # 符号定义（+, -, ~, 等）
│   ├── ColoredStringBuilder.cs  # 带颜色的字符串构建器
│   └── WhatIfJsonFormatter.cs   # JSON 格式化器基类
├── Extensions/          # 扩展方法
│   ├── JTokenExtensions.cs      # JSON Token 扩展
│   └── DiagnosticExtensions.cs  # 诊断信息扩展
└── README.md           # 本文档
```

## 核心组件

### 1. Formatters（格式化器）

#### Color
定义了 ANSI 颜色代码，用于终端输出：
- `Color.Green` - 用于创建操作
- `Color.Orange` - 用于删除操作
- `Color.Purple` - 用于修改操作
- `Color.Blue` - 用于部署操作
- `Color.Gray` - 用于无影响操作
- `Color.Red` - 用于错误
- `Color.DarkYellow` - 用于警告
- `Color.Reset` - 重置颜色

#### Symbol
定义了用于表示不同操作类型的符号：
- `Symbol.Plus` (+) - 创建
- `Symbol.Minus` (-) - 删除
- `Symbol.Tilde` (~) - 修改
- `Symbol.ExclamationPoint` (!) - 部署
- `Symbol.Equal` (=) - 无变化
- `Symbol.Asterisk` (*) - 忽略
- `Symbol.Cross` (x) - 不支持/无影响

#### ColoredStringBuilder
一个支持 ANSI 颜色代码的字符串构建器。提供：
- 基本的字符串追加操作
- 带颜色的文本追加
- 颜色作用域管理（使用 `using` 语句）

示例：
```csharp
var builder = new ColoredStringBuilder();
builder.Append("Creating resource: ", Color.Reset);
builder.Append("resourceName", Color.Green);
builder.AppendLine();

// 使用颜色作用域
using (builder.NewColorScope(Color.Blue))
{
    builder.Append("Deploying...");
}
```

#### WhatIfJsonFormatter
格式化 JSON 数据为带颜色的、易读的输出。主要功能：
- 自动缩进
- 路径对齐
- 支持嵌套对象和数组
- 叶子节点的类型感知格式化

### 2. Extensions（扩展方法）

#### JTokenExtensions
Newtonsoft.Json JToken 的扩展方法：
- `IsLeaf()` - 检查是否为叶子节点
- `IsNonEmptyArray()` - 检查是否为非空数组
- `IsNonEmptyObject()` - 检查是否为非空对象
- `ToPsObject()` - 转换为 PowerShell 对象
- `ConvertPropertyValueForPsObject()` - 转换属性值

#### DiagnosticExtensions
诊断信息的扩展方法：
- `ToColor(this string level)` - 将诊断级别（Error/Warning/Info）转换为颜色
- `Level` 静态类 - 提供标准诊断级别常量

## 使用方法

### 基本 JSON 格式化

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Newtonsoft.Json.Linq;

var jsonData = JObject.Parse(@"{
    ""name"": ""myResource"",
    ""location"": ""eastus"",
    ""properties"": {
        ""enabled"": true
    }
}");

string formattedOutput = WhatIfJsonFormatter.FormatJson(jsonData);
Console.WriteLine(formattedOutput);
```

### 使用 ColoredStringBuilder

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;

var builder = new ColoredStringBuilder();

builder.Append("Resource changes: ");
builder.Append("3 to create", Color.Green);
builder.Append(", ");
builder.Append("1 to modify", Color.Purple);
builder.AppendLine();

string output = builder.ToString();
```

### 在自定义 Formatter 中使用

如果您需要创建自定义的 WhatIf formatter：

```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;

public class MyCustomFormatter : WhatIfJsonFormatter
{
    public MyCustomFormatter(ColoredStringBuilder builder) : base(builder)
    {
    }

    public void FormatMyData(MyDataType data)
    {
        using (this.Builder.NewColorScope(Color.Blue))
        {
            this.Builder.AppendLine("Custom formatting:");
            // 使用基类的 FormatJson 方法
            this.FormatJson(data.JsonContent);
        }
    }
}
```

## 扩展这个库

### 为您的 RP 添加支持

如果您想在您的 RP 模块中使用这个库：

1. **添加项目引用**（如果需要）或确保文件包含在编译中

2. **添加 using 语句**：
```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
```

3. **实现您的格式化器**：
```csharp
public class MyRPWhatIfFormatter : WhatIfJsonFormatter
{
    // 添加 RP 特定的格式化逻辑
}
```

### 添加新的扩展

如果需要添加新的扩展方法：

1. 在 `Extensions` 目录下创建新文件
2. 使用命名空间 `Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions`
3. 创建静态扩展类
4. 更新此 README

## 依赖项

- Newtonsoft.Json - JSON 处理
- System.Management.Automation - PowerShell 对象支持

## 迁移指南

### 从 Resources 模块迁移

如果您正在从 `Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters` 迁移：

**旧代码**:
```csharp
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

var builder = new ColoredStringBuilder();
string output = WhatIfJsonFormatter.FormatJson(jsonData);
```

**新代码**:
```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;

var builder = new ColoredStringBuilder();
string output = WhatIfJsonFormatter.FormatJson(jsonData);
```

主要变化：
- Namespace 从 `Microsoft.Azure.Commands.ResourceManager.Cmdlets` 改为 `Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf`
- API 保持不变，只需要更新 using 语句

## 贡献

如果您需要添加新功能或修复 bug：

1. 确保更改不会破坏现有 API
2. 添加适当的 XML 文档注释
3. 更新此 README
4. 考虑向后兼容性

## 使用接口实现

该库提供了一组接口，允许不同的 RP 模块实现自己的 WhatIf 模型，同时使用共享的格式化逻辑。

### 接口定义

- `IWhatIfOperationResult` - WhatIf 操作结果
- `IWhatIfChange` - 资源变更
- `IWhatIfPropertyChange` - 属性变更
- `IWhatIfDiagnostic` - 诊断信息
- `IWhatIfError` - 错误信息

### 实现示例

```csharp
// 1. 实现接口（在您的 RP 模块中）
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using Microsoft.Azure.Management.YourService.Models;

public class PSWhatIfChange : IWhatIfChange
{
    private readonly WhatIfChange sdkChange;
    
    public PSWhatIfChange(WhatIfChange sdkChange)
    {
        this.sdkChange = sdkChange;
        // 初始化属性...
    }
    
    public string Scope { get; set; }
    public string RelativeResourceId { get; set; }
    public string FullyQualifiedResourceId => sdkChange.ResourceId;
    public ChangeType ChangeType => sdkChange.ChangeType;
    public string ApiVersion { get; set; }
    public string UnsupportedReason { get; set; }
    public JToken Before { get; set; }
    public JToken After { get; set; }
    public IList<IWhatIfPropertyChange> Delta { get; set; }
}

public class PSWhatIfOperationResult : IWhatIfOperationResult
{
    public string Status { get; set; }
    public IList<IWhatIfChange> Changes { get; set; }
    public IList<IWhatIfChange> PotentialChanges { get; set; }
    public IList<IWhatIfDiagnostic> Diagnostics { get; set; }
    public IWhatIfError Error { get; set; }
}

// 2. 使用格式化器
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;

IWhatIfOperationResult result = GetWhatIfResult(); // 您的实现
string formattedOutput = WhatIfOperationResultFormatter.Format(result);
Console.WriteLine(formattedOutput);
```

### 自定义格式化

您也可以继承 `WhatIfOperationResultFormatter` 来自定义格式化行为：

```csharp
public class CustomWhatIfFormatter : WhatIfOperationResultFormatter
{
    public CustomWhatIfFormatter(ColoredStringBuilder builder) : base(builder)
    {
    }
    
    // 重写方法来自定义行为
    protected override void FormatNoiseNotice(string noiseNotice = null)
    {
        // 自定义提示信息
        this.Builder.AppendLine("自定义提示: 这是预测结果，仅供参考。").AppendLine();
    }
    
    protected override string FormatChangeTypeCount(ChangeType changeType, int count)
    {
        // 自定义统计信息格式
        return changeType switch
        {
            ChangeType.Create => $"{count} 个资源将被创建",
            ChangeType.Delete => $"{count} 个资源将被删除",
            _ => base.FormatChangeTypeCount(changeType, count)
        };
    }
}
```

## 版本历史

- **1.0.0** (2025-01) - 初始版本，从 Resources 模块提取
  - 核心格式化器（Color, Symbol, ColoredStringBuilder）
  - WhatIfJsonFormatter 基类
  - JTokenExtensions 和 DiagnosticExtensions
  - WhatIfOperationResultFormatter 完整实现
  - 模型接口（IWhatIfOperationResult, IWhatIfChange, IWhatIfPropertyChange, etc.）
  - 枚举类型（ChangeType, PropertyChangeType, PSChangeType）
  - 比较器（ChangeTypeComparer, PropertyChangeTypeComparer, PSChangeTypeComparer）
  - 类型扩展（ChangeTypeExtensions, PropertyChangeTypeExtensions, PSChangeTypeExtensions）

