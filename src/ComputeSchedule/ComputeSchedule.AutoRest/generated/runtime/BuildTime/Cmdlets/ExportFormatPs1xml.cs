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

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
  [Cmdlet(VerbsData.Export, "FormatPs1xml")]
  [DoNotExport]
  public class ExportFormatPs1xml : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string FilePath { get; set; }

    private const string ModelNamespace = @"Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models";
    private const string SupportNamespace = @"${$project.supportNamespace.fullName}";
    private const string PropertiesExcludedForTableview = @"Id,Type";

    private static readonly bool IsAzure = Convert.ToBoolean(@"true");

    private static string SelectedBySuffix = @"#Multiple";
    
    protected override void ProcessRecord()
    {
      try
      {
        var viewModels = GetFilteredViewParameters().Select(CreateViewModel).ToList();
        var ps1xml = new Configuration
        {
          ViewDefinitions = new ViewDefinitions
          {
            Views = viewModels
          }
        };
        File.WriteAllText(FilePath, ps1xml.ToXmlString());
      }
      catch (Exception ee)
      {
        Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }

    private static IEnumerable<ViewParameters> GetFilteredViewParameters()
    {
      //https://stackoverflow.com/a/79738/294804
      //https://stackoverflow.com/a/949285/294804
      var types = Assembly.GetExecutingAssembly().GetExportedTypes()
          .Where(t => t.IsClass
                      && (t.Namespace.StartsWith(ModelNamespace) || t.Namespace.StartsWith(SupportNamespace))
                      && !t.GetCustomAttributes<DoNotFormatAttribute>().Any());
      return types.Select(t => new ViewParameters(t, t.GetProperties()
          .Select(p => new PropertyFormat(p))
          .Where(pf => !pf.Property.GetCustomAttributes<DoNotFormatAttribute>().Any()
                       && (!PropertiesExcludedForTableview.Split(',').Contains(pf.Property.Name))
                       && (pf.FormatTable != null || (pf.Origin != PropertyOrigin.Inlined && pf.Property.PropertyType.IsPsSimple())))
          .OrderByDescending(pf => pf.Index.HasValue)
          .ThenBy(pf => pf.Index)
          .ThenByDescending(pf => pf.Origin.HasValue)
          .ThenBy(pf => pf.Origin))).Where(vp => vp.Properties.Any());
    }

    private static View CreateViewModel(ViewParameters viewParameters)
    {
      var entries = viewParameters.Properties.Select(pf =>
          (TableColumnHeader: new TableColumnHeader { Label = pf.Label, Width = pf.Width },
           TableColumnItem: new TableColumnItem { PropertyName = pf.Property.Name })).ToArray();

      return new View
      {
        Name = viewParameters.Type.FullName,
        ViewSelectedBy = new ViewSelectedBy
        {
          TypeName = string.Concat(viewParameters.Type.FullName, SelectedBySuffix)
        },
        TableControl = new TableControl
        {
          TableHeaders = new TableHeaders
          {
            TableColumnHeaders = entries.Select(e => e.TableColumnHeader).ToList()
          },
          TableRowEntries = new TableRowEntries
          {
            TableRowEntry = new TableRowEntry
            {
              TableColumnItems = new TableColumnItems
              {
                TableItems = entries.Select(e => e.TableColumnItem).ToList()
              }
            }
          }
        }
      };
    }
  }
}
