/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell
{
  [Cmdlet(VerbsData.Export, "ModelSurface")]
  [DoNotExport]
  public class ExportModelSurface : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string OutputFolder { get; set; }

    [Parameter]
    public bool UseExpandedFormat { get; set; }

    private const string ModelNamespace = @"Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models";
    private const string SupportNamespace = @"Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support";

    protected override void ProcessRecord()
    {
      try
      {
        var types = Assembly.GetExecutingAssembly().GetExportedTypes()
            .Where(t => t.IsClass && (t.Namespace.StartsWith(ModelNamespace) || t.Namespace.StartsWith(SupportNamespace)));
        var typeInfos = types.Select(t => new ModelTypeInfo
        {
          Type = t,
          TypeName = t.Name,
          Properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !p.GetIndexParameters().Any()).OrderBy(p => p.Name).ToArray(),
          NamespaceGroup = t.Namespace.Split('.').LastOrDefault().EmptyIfNull()
        }).Where(mti => mti.Properties.Any());
        var sb = UseExpandedFormat ? ExpandedFormat(typeInfos) : CondensedFormat(typeInfos);
        Directory.CreateDirectory(OutputFolder);
        File.WriteAllText(Path.Combine(OutputFolder, "ModelSurface.md"), sb.ToString());
      }
      catch (Exception ee)
      {
        Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }

    private static StringBuilder ExpandedFormat(IEnumerable<ModelTypeInfo> typeInfos)
    {
      var sb = new StringBuilder();
      foreach (var typeInfo in typeInfos.OrderBy(mti => mti.TypeName).ThenBy(mti => mti.NamespaceGroup))
      {
        sb.Append($"### {typeInfo.TypeName} [{typeInfo.NamespaceGroup}]{Environment.NewLine}");
        foreach (var property in typeInfo.Properties)
        {
          sb.Append($"  - {property.Name} `{property.PropertyType.ToSyntaxTypeName()}`{Environment.NewLine}");
        }
        sb.AppendLine();
      }

      return sb;
    }

    private static StringBuilder CondensedFormat(IEnumerable<ModelTypeInfo> typeInfos)
    {
      var sb = new StringBuilder();
      var typeGroups = typeInfos
          .GroupBy(mti => mti.TypeName)
          .Select(tig => (
              Types: tig.Select(mti => mti.Type).ToArray(),
              TypeName: tig.Key,
              Properties: tig.SelectMany(mti => mti.Properties).DistinctBy(p => p.Name).OrderBy(p => p.Name).ToArray(),
              NamespaceGroups: tig.Select(mti => mti.NamespaceGroup).OrderBy(ng => ng).ToArray()
          ))
          .OrderBy(tg => tg.TypeName);
      foreach (var typeGroup in typeGroups)
      {
        var aType = typeGroup.Types.Select(GetAssociativeType).FirstOrDefault(t => t != null);
        var aText = aType != null ? $@" \<{aType.ToSyntaxTypeName()}\>" : String.Empty;
        sb.Append($"### {typeGroup.TypeName}{aText} [{String.Join(", ", typeGroup.NamespaceGroups)}]{Environment.NewLine}");
        foreach (var property in typeGroup.Properties)
        {
          var propertyAType = GetAssociativeType(property.PropertyType);
          var propertyAText = propertyAType != null ? $" <{propertyAType.ToSyntaxTypeName()}>" : String.Empty;
          var enumNames = GetEnumFieldNames(property.PropertyType.Unwrap());
          var enumNamesText = enumNames.Any() ? $" **{{{String.Join(", ", enumNames)}}}**" : String.Empty;
          sb.Append($"  - {property.Name} `{property.PropertyType.ToSyntaxTypeName()}{propertyAText}`{enumNamesText}{Environment.NewLine}");
        }
        sb.AppendLine();
      }

      return sb;
    }

    //https://stackoverflow.com/a/4963190/294804
    private static Type GetAssociativeType(Type type) =>
        type.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAssociativeArray<>))?.GetGenericArguments().First();

    private static string[] GetEnumFieldNames(Type type) =>
        type.IsValueType && !type.IsPrimitive && type != typeof(decimal) && type != typeof(DateTime)
            ? type.GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => f.FieldType == type).Select(p => p.Name).ToArray()
            : new string[] { };

    private class ModelTypeInfo
    {
      public Type Type { get; set; }
      public string TypeName { get; set; }
      public PropertyInfo[] Properties { get; set; }
      public string NamespaceGroup { get; set; }
    }
  }
}
