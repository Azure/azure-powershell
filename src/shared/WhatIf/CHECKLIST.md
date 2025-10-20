# WhatIf 共享库 - 迁移和使用清单

## ✅ 已完成的工作

### 1. 目录结构
```
src/shared/WhatIf/
├── Formatters/           # 格式化器
│   ├── Color.cs
│   ├── Symbol.cs
│   ├── ColoredStringBuilder.cs
│   ├── WhatIfJsonFormatter.cs
│   └── WhatIfOperationResultFormatter.cs
├── Extensions/          # 扩展方法
│   ├── JTokenExtensions.cs
│   ├── DiagnosticExtensions.cs
│   ├── ChangeTypeExtensions.cs
│   ├── PropertyChangeTypeExtensions.cs
│   └── PSChangeTypeExtensions.cs
├── Comparers/          # 排序比较器
│   ├── ChangeTypeComparer.cs
│   ├── PropertyChangeTypeComparer.cs
│   └── PSChangeTypeComparer.cs
├── Models/             # 数据模型
│   ├── ChangeType.cs (enum)
│   ├── PropertyChangeType.cs (enum)
│   ├── PSChangeType.cs (enum)
│   ├── IWhatIfOperationResult.cs (interface)
│   ├── IWhatIfChange.cs (interface)
│   ├── IWhatIfPropertyChange.cs (interface)
│   ├── IWhatIfDiagnostic.cs (interface)
│   └── IWhatIfError.cs (interface)
├── Utilities/          # 工具类
│   └── ResourceIdUtility.cs
├── README.md           # 主文档
├── USAGE_EXAMPLES.md   # 使用示例
├── QUICKSTART.md       # 快速开始
└── INTEGRATION_GUIDE.md # 集成指南
```

### 2. 核心功能

#### ✅ Formatters（格式化器）
- **Color.cs**: ANSI 颜色代码定义
  - 7 种颜色：Green, Orange, Purple, Blue, Gray, Red, DarkYellow, Reset
  
- **Symbol.cs**: 操作符号定义
  - 7 种符号：+, -, ~, !, =, *, x, 以及方括号和空格
  
- **ColoredStringBuilder.cs**: 带颜色的字符串构建器
  - 支持 ANSI 颜色代码
  - 颜色作用域管理（AnsiColorScope）
  - 自动颜色栈管理
  
- **WhatIfJsonFormatter.cs**: JSON 格式化基类
  - 格式化叶子节点
  - 格式化数组和对象
  - 路径对齐
  - 缩进管理
  
- **WhatIfOperationResultFormatter.cs**: 完整的 WhatIf 结果格式化器
  - 支持接口驱动（IWhatIfOperationResult）
  - 格式化资源变更
  - 格式化属性变更
  - 格式化诊断信息
  - 图例显示
  - 统计信息

#### ✅ Extensions（扩展方法）
- **JTokenExtensions.cs**: Newtonsoft.Json 扩展
  - IsLeaf(), IsNonEmptyArray(), IsNonEmptyObject()
  - ToPsObject(), ConvertPropertyValueForPsObject()
  
- **DiagnosticExtensions.cs**: 诊断信息扩展
  - ToColor(): 级别 → 颜色映射
  - Level 常量类
  
- **ChangeTypeExtensions.cs**: ChangeType 扩展
  - ToColor(): 变更类型 → 颜色
  - ToSymbol(): 变更类型 → 符号
  - ToPSChangeType(): 类型转换
  
- **PropertyChangeTypeExtensions.cs**: PropertyChangeType 扩展
  - ToColor(), ToSymbol(), ToPSChangeType()
  - IsDelete(), IsCreate(), IsModify(), IsArray() 辅助方法
  
- **PSChangeTypeExtensions.cs**: PSChangeType 扩展
  - ToColor(), ToSymbol()

#### ✅ Comparers（比较器）
- **ChangeTypeComparer.cs**: ChangeType 排序
  - 权重字典：Delete(0) → Create(1) → Deploy(2) → ... → Ignore(6)
  
- **PropertyChangeTypeComparer.cs**: PropertyChangeType 排序
  - 权重字典：Delete(0) → Create(1) → Modify/Array(2) → NoEffect(3)
  
- **PSChangeTypeComparer.cs**: PSChangeType 排序
  - 8 个权重级别

#### ✅ Models（模型）
- **枚举类型**:
  - ChangeType: Create, Delete, Deploy, Ignore, Modify, NoChange, Unsupported
  - PropertyChangeType: Create, Delete, Modify, Array, NoEffect
  - PSChangeType: 合并了上述两者的所有值
  
- **接口**:
  - IWhatIfOperationResult: 操作结果顶层接口
  - IWhatIfChange: 资源变更接口
  - IWhatIfPropertyChange: 属性变更接口
  - IWhatIfDiagnostic: 诊断信息接口
  - IWhatIfError: 错误信息接口

#### ✅ Utilities（工具类）
- **ResourceIdUtility.cs**: 资源 ID 处理工具
  - SplitResourceId(): 拆分为 scope + relativeResourceId
  - GetScope(), GetRelativeResourceId()
  - GetResourceGroupName(), GetSubscriptionId()

#### ✅ 文档
- **README.md**: 完整库文档
  - 组件概述
  - 使用方法
  - 迁移指南
  - 接口实现示例
  
- **USAGE_EXAMPLES.md**: 7 个详细示例
  - 基础 JSON 格式化
  - ColoredStringBuilder 使用
  - 颜色作用域
  - 自定义格式化器
  - 诊断信息
  - 迁移指南
  - RP 模块示例
  
- **QUICKSTART.md**: 快速参考
  - 颜色/符号映射表
  - 最小代码示例
  - 迁移检查清单
  
- **INTEGRATION_GUIDE.md**: 完整集成指南
  - 完整 Compute 模块示例
  - 接口实现步骤
  - Cmdlet 集成
  - 自定义格式化器
  - 项目引用配置
  - 单元测试示例
  - 最佳实践
  - 常见问题解答

## 🎯 设计特点

### 1. 完全独立
- ✅ 不依赖 Resources 模块
- ✅ 所有类型都在 shared 中定义
- ✅ 可被任意 RP 模块使用

### 2. 接口驱动
- ✅ 使用接口而非具体类型
- ✅ 灵活适配不同 SDK 模型
- ✅ 易于测试和模拟

### 3. 可扩展性
- ✅ 所有格式化方法都是 virtual
- ✅ 可继承并重写行为
- ✅ 支持自定义格式化器

### 4. 类型安全
- ✅ 强类型枚举
- ✅ 类型转换扩展方法
- ✅ 编译时类型检查

### 5. 性能优化
- ✅ Lazy<T> 延迟加载
- ✅ 最小化字符串操作
- ✅ 高效的颜色管理

## 📋 使用检查清单

### 对于 RP 模块开发者

#### 1. 项目引用
```xml
<ItemGroup>
  <Compile Include="..\..\shared\WhatIf\**\*.cs" LinkBase="Shared\WhatIf" />
</ItemGroup>
```

#### 2. 实现接口
- [ ] 创建 `PSYourServiceWhatIfChange : IWhatIfChange`
- [ ] 创建 `PSYourServiceWhatIfPropertyChange : IWhatIfPropertyChange`
- [ ] 创建 `PSYourServiceWhatIfOperationResult : IWhatIfOperationResult`
- [ ] 创建 `PSYourServiceWhatIfDiagnostic : IWhatIfDiagnostic`（可选）
- [ ] 创建 `PSYourServiceWhatIfError : IWhatIfError`（可选）

#### 3. 在 Cmdlet 中使用
```csharp
using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;

var psResult = new PSYourServiceWhatIfOperationResult(sdkResult);
string output = WhatIfOperationResultFormatter.Format(psResult);
WriteObject(output);
```

#### 4. 测试
- [ ] 单元测试：格式化输出
- [ ] 集成测试：端到端 WhatIf 流程
- [ ] 手动测试：颜色显示正确

### 对于 Resources 模块（迁移）

#### 1. 更新命名空间
- [ ] `using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;`
  → `using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;`
- [ ] `using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;`
  → `using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;`

#### 2. 更新类型引用
- [ ] `ChangeType` → 从 shared 引用
- [ ] `PropertyChangeType` → 从 shared 引用
- [ ] `PSChangeType` → 从 shared 引用

#### 3. 实现接口（可选）
- [ ] `PSWhatIfChange : IWhatIfChange`
- [ ] `PSWhatIfPropertyChange : IWhatIfPropertyChange`
- [ ] `PSWhatIfOperationResult : IWhatIfOperationResult`

#### 4. 验证
- [ ] 现有测试通过
- [ ] WhatIf 输出格式一致
- [ ] 颜色显示正常

## 🚀 后续步骤

### 立即可用
该库现在可以立即在任何 RP 模块中使用。

### 推荐集成顺序
1. **新 RP 模块**: 直接使用接口实现
2. **现有 RP 模块**: 
   - 先添加项目引用
   - 实现接口
   - 逐步迁移现有代码
3. **Resources 模块**:
   - 保持现有架构不变
   - 添加接口实现（向后兼容）
   - 内部逐步切换到 shared 库

### 优化建议
1. 考虑创建 NuGet 包（如果跨仓库使用）
2. 添加 XML 文档注释（已部分完成）
3. 添加单元测试项目
4. 性能基准测试

## 📞 支持

如有问题，请参考：
1. `README.md` - 完整文档
2. `INTEGRATION_GUIDE.md` - 集成步骤
3. `USAGE_EXAMPLES.md` - 代码示例
4. `QUICKSTART.md` - 快速参考

## 📝 版本信息

- **版本**: 1.0.0
- **创建日期**: 2025-01
- **Namespace**: Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf
- **Target Framework**: .NET Standard 2.0
- **依赖**: 
  - Newtonsoft.Json (≥ 13.0.1)
  - System.Management.Automation (≥ 7.0.0)
