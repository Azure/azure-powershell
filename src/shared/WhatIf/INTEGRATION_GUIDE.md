# 完整实现示例

本文档展示如何在您的 RP 模块中集成和使用 WhatIf 共享库。

## 场景：在 Compute 模块中实现 WhatIf 功能

### 步骤 1: 实现接口

首先，在您的 RP 模块中创建实现 WhatIf 接口的类：

```csharp
// File: src/Compute/Compute/Models/PSComputeWhatIfPropertyChange.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Compute.Models
{
    /// <summary>
    /// Compute-specific implementation of IWhatIfPropertyChange
    /// </summary>
    public class PSComputeWhatIfPropertyChange : IWhatIfPropertyChange
    {
        private readonly WhatIfPropertyChange sdkPropertyChange;
        private readonly Lazy<JToken> before;
        private readonly Lazy<JToken> after;
        private readonly Lazy<IList<IWhatIfPropertyChange>> children;

        public PSComputeWhatIfPropertyChange(WhatIfPropertyChange sdkPropertyChange)
        {
            this.sdkPropertyChange = sdkPropertyChange;
            this.before = new Lazy<JToken>(() => sdkPropertyChange.Before.ToJToken());
            this.after = new Lazy<JToken>(() => sdkPropertyChange.After.ToJToken());
            this.children = new Lazy<IList<IWhatIfPropertyChange>>(() =>
                sdkPropertyChange.Children?.Select(pc => new PSComputeWhatIfPropertyChange(pc) as IWhatIfPropertyChange).ToList());
        }

        public string Path => sdkPropertyChange.Path;
        public PropertyChangeType PropertyChangeType => sdkPropertyChange.PropertyChangeType;
        public JToken Before => before.Value;
        public JToken After => after.Value;
        public IList<IWhatIfPropertyChange> Children => children.Value;
    }
}
```

```csharp
// File: src/Compute/Compute/Models/PSComputeWhatIfChange.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Utilities;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Compute.Models
{
    /// <summary>
    /// Compute-specific implementation of IWhatIfChange
    /// </summary>
    public class PSComputeWhatIfChange : IWhatIfChange
    {
        private readonly WhatIfChange sdkChange;
        private readonly Lazy<JToken> before;
        private readonly Lazy<JToken> after;
        private readonly Lazy<IList<IWhatIfPropertyChange>> delta;
        private readonly Lazy<string> apiVersion;

        public PSComputeWhatIfChange(WhatIfChange sdkChange)
        {
            this.sdkChange = sdkChange;

            // Split resource ID into scope and relative path
            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(sdkChange.ResourceId);
            this.Scope = scope;
            this.RelativeResourceId = relativeResourceId;
            this.UnsupportedReason = sdkChange.UnsupportedReason;

            this.apiVersion = new Lazy<string>(() =>
                this.Before?["apiVersion"]?.Value<string>() ?? this.After?["apiVersion"]?.Value<string>());
            this.before = new Lazy<JToken>(() => sdkChange.Before.ToJToken());
            this.after = new Lazy<JToken>(() => sdkChange.After.ToJToken());
            this.delta = new Lazy<IList<IWhatIfPropertyChange>>(() =>
                sdkChange.Delta?.Select(pc => new PSComputeWhatIfPropertyChange(pc) as IWhatIfPropertyChange).ToList());
        }

        public string Scope { get; }
        public string RelativeResourceId { get; }
        public string UnsupportedReason { get; }
        public string FullyQualifiedResourceId => sdkChange.ResourceId;
        public ChangeType ChangeType => sdkChange.ChangeType;
        public string ApiVersion => apiVersion.Value;
        public JToken Before => before.Value;
        public JToken After => after.Value;
        public IList<IWhatIfPropertyChange> Delta => delta.Value;
    }
}
```

```csharp
// File: src/Compute/Compute/Models/PSComputeWhatIfDiagnostic.cs
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSComputeWhatIfDiagnostic : IWhatIfDiagnostic
    {
        public PSComputeWhatIfDiagnostic(DeploymentDiagnosticsDefinition diagnostic)
        {
            this.Code = diagnostic.Code;
            this.Message = diagnostic.Message;
            this.Level = diagnostic.Level;
            this.Target = diagnostic.Target;
            this.Details = diagnostic.Details;
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Target { get; set; }
        public string Details { get; set; }
    }
}
```

```csharp
// File: src/Compute/Compute/Models/PSComputeWhatIfError.cs
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSComputeWhatIfError : IWhatIfError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
    }
}
```

```csharp
// File: src/Compute/Compute/Models/PSComputeWhatIfOperationResult.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSComputeWhatIfOperationResult : IWhatIfOperationResult
    {
        private readonly WhatIfOperationResult sdkResult;
        private readonly Lazy<IList<IWhatIfChange>> changes;
        private readonly Lazy<IList<IWhatIfChange>> potentialChanges;
        private readonly Lazy<IList<IWhatIfDiagnostic>> diagnostics;
        private readonly Lazy<IWhatIfError> error;

        public PSComputeWhatIfOperationResult(WhatIfOperationResult sdkResult)
        {
            this.sdkResult = sdkResult;
            
            this.changes = new Lazy<IList<IWhatIfChange>>(() =>
                sdkResult.Changes?.Select(c => new PSComputeWhatIfChange(c) as IWhatIfChange).ToList());
            
            this.potentialChanges = new Lazy<IList<IWhatIfChange>>(() =>
                sdkResult.PotentialChanges?.Select(c => new PSComputeWhatIfChange(c) as IWhatIfChange).ToList());
            
            this.diagnostics = new Lazy<IList<IWhatIfDiagnostic>>(() =>
                sdkResult.Diagnostics?.Select(d => new PSComputeWhatIfDiagnostic(d) as IWhatIfDiagnostic).ToList());
            
            this.error = new Lazy<IWhatIfError>(() =>
                sdkResult.Error != null ? new PSComputeWhatIfError
                {
                    Code = sdkResult.Error.Code,
                    Message = sdkResult.Error.Message,
                    Target = sdkResult.Error.Target
                } : null);
        }

        public string Status => sdkResult.Status;
        public IList<IWhatIfChange> Changes => changes.Value;
        public IList<IWhatIfChange> PotentialChanges => potentialChanges.Value;
        public IList<IWhatIfDiagnostic> Diagnostics => diagnostics.Value;
        public IWhatIfError Error => error.Value;
    }
}
```

### 步骤 2: 在 Cmdlet 中使用

```csharp
// File: src/Compute/Compute/Cmdlets/VirtualMachine/NewAzureVMWhatIf.cs
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.Management.Compute;

namespace Microsoft.Azure.Commands.Compute.Cmdlets.VirtualMachine
{
    [Cmdlet(VerbsCommon.New, "AzVM", SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeWhatIfOperationResult))]
    public class NewAzureVMWhatIfCommand : ComputeClientBaseCmdlet
    {
        [Parameter(Mandatory = true)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        public string Location { get; set; }

        // ... 其他参数 ...

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, "Create Virtual Machine"))
            {
                // 1. 调用 WhatIf API
                var whatIfResult = ComputeClient.VirtualMachines.WhatIf(
                    ResourceGroupName,
                    Name,
                    new VirtualMachine
                    {
                        Location = Location,
                        // ... 其他属性 ...
                    }
                );

                // 2. 包装为 PS 对象（实现接口）
                var psResult = new PSComputeWhatIfOperationResult(whatIfResult);

                // 3. 格式化输出
                string formattedOutput = WhatIfOperationResultFormatter.Format(
                    psResult,
                    noiseNotice: "Note: This is a preview. The actual deployment may differ."
                );

                // 4. 输出到控制台
                WriteObject(formattedOutput);

                // 5. 也可以返回结构化对象供管道使用
                WriteObject(psResult);
            }
        }
    }
}
```

### 步骤 3: 自定义格式化（可选）

如果需要自定义输出格式：

```csharp
// File: src/Compute/Compute/Formatters/ComputeWhatIfFormatter.cs
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;

namespace Microsoft.Azure.Commands.Compute.Formatters
{
    public class ComputeWhatIfFormatter : WhatIfOperationResultFormatter
    {
        public ComputeWhatIfFormatter(ColoredStringBuilder builder) : base(builder)
        {
        }

        // 自定义 Compute 特有的提示信息
        protected override void FormatNoiseNotice(string noiseNotice = null)
        {
            this.Builder
                .AppendLine("=== Azure Compute WhatIf Analysis ===")
                .AppendLine("Note: Virtual machine configurations may have additional dependencies.")
                .AppendLine();
        }

        // 自定义统计信息格式
        protected override string FormatChangeTypeCount(ChangeType changeType, int count)
        {
            return changeType switch
            {
                ChangeType.Create => $"{count} VM(s) to create",
                ChangeType.Delete => $"{count} VM(s) to delete",
                ChangeType.Modify => $"{count} VM(s) to modify",
                _ => base.FormatChangeTypeCount(changeType, count)
            };
        }

        // 静态便捷方法
        public static string FormatComputeResult(IWhatIfOperationResult result)
        {
            var builder = new ColoredStringBuilder();
            var formatter = new ComputeWhatIfFormatter(builder);
            
            formatter.FormatNoiseNotice();
            formatter.FormatLegend(result.Changes, result.PotentialChanges);
            formatter.FormatResourceChanges(result.Changes, true);
            formatter.FormatStats(result.Changes, true);
            formatter.FormatResourceChanges(result.PotentialChanges, false);
            formatter.FormatStats(result.PotentialChanges, false);
            formatter.FormatDiagnostics(result.Diagnostics, result.Changes, result.PotentialChanges);
            
            return builder.ToString();
        }
    }
}

// 在 Cmdlet 中使用自定义格式化器
string formattedOutput = ComputeWhatIfFormatter.FormatComputeResult(psResult);
```

## 项目引用

在您的 RP 模块的 `.csproj` 文件中添加共享库引用：

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <!-- 引用共享 WhatIf 库 -->
    <Compile Include="..\..\shared\WhatIf\**\*.cs" LinkBase="Shared\WhatIf" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="13.0.1" />
    <PackageReference Include="System.Management.Automation" Version="7.2.0" />
    <!-- 其他依赖... -->
  </ItemGroup>
</Project>
```

或者使用项目引用（如果 shared 是独立项目）：

```xml
<ItemGroup>
  <ProjectReference Include="..\..\shared\Shared.csproj" />
</ItemGroup>
```

## 单元测试示例

```csharp
// File: src/Compute/Compute.Test/WhatIfFormatterTests.cs
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test
{
    public class WhatIfFormatterTests
    {
        [Fact]
        public void TestBasicFormatting()
        {
            // Arrange
            var mockResult = new MockWhatIfOperationResult
            {
                Status = "Succeeded",
                Changes = new List<IWhatIfChange>
                {
                    new MockWhatIfChange
                    {
                        ChangeType = ChangeType.Create,
                        RelativeResourceId = "Microsoft.Compute/virtualMachines/testVM",
                        Scope = "/subscriptions/sub-id/resourceGroups/rg1"
                    }
                }
            };

            // Act
            string output = WhatIfOperationResultFormatter.Format(mockResult);

            // Assert
            Assert.Contains("to create", output);
            Assert.Contains("testVM", output);
            Assert.Contains("+", output); // 创建符号
        }
    }
}
```

## 最佳实践

1. **性能优化**: 使用 `Lazy<T>` 延迟加载大型数据结构
2. **错误处理**: 在包装 SDK 对象时捕获并适当处理异常
3. **可测试性**: 通过接口实现使代码易于模拟和测试
4. **文档**: 为您的 PS 类添加 XML 文档注释
5. **向后兼容**: 如果已有 WhatIf 实现，逐步迁移，保持向后兼容

## 常见问题

**Q: 为什么使用接口而不是继承？**
A: 接口提供了更大的灵活性，允许不同 RP 模块根据各自的 SDK 模型实现，而无需共享基类的限制。

**Q: 我需要实现所有接口吗？**
A: 如果只使用基本的 JSON 格式化功能（WhatIfJsonFormatter），则不需要。如果要使用 WhatIfOperationResultFormatter，则需要实现相关接口。

**Q: 可以扩展现有的格式化器吗？**
A: 可以！所有格式化方法都是 `virtual` 或 `protected virtual` 的，您可以继承并重写它们来自定义行为。

**Q: 如何处理 SDK 类型不匹配？**
A: 使用适配器模式。在您的 PS 类中包装 SDK 对象，并在属性 getter 中进行必要的类型转换。
