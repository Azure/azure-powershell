using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.CLU.Common;
using System.Diagnostics;

namespace Microsoft.CLU.Helpers
{
    internal static class FormatReader
    {
        /// <summary>
        /// Looks for and reads an XML file containing output-type formatting rules.
        /// </summary>
        /// <param name="package">The local package containing he rules.</param>
        /// <param name="assembly">The assembly containing the cmdlet that is generating the type.</param>
        /// <param name="outputType">The output type.</param>
        /// <returns></returns>
        internal static ViewDescriptor ReadFormatFile(LocalPackage package, string assembly, Type outputType)
        {
            Debug.Assert(package != null);
            Debug.Assert(!string.IsNullOrEmpty(assembly));
            Debug.Assert(outputType != null);

            var path = Path.Combine(package.FullPath, Constants.ContentFolder, assembly + ".format.ps1xml");

            if (File.Exists(path))
            {
                var doc = XDocument.Load(path);

                var viewDefinitions = doc.Root;

                XElement foundView = FindMatchingView(outputType, viewDefinitions);

                if (foundView != null)
                {
                    var viewName = GetChildrenMatching(foundView, "Name").FirstOrDefault();

                    var listControl = GetChildrenMatching(foundView, "ListControl").FirstOrDefault();

                    if (listControl != null)
                    {
                        var view = new ListDescriptor();

                        if (viewName != null)
                            view.ViewName = viewName.Value;

                        GetListItems(view, listControl);

                        return view;
                    }

                    var tableControl = GetChildrenMatching(foundView, "TableControl").FirstOrDefault();

                    if (tableControl != null)
                    {
                        var view = new TableDescriptor();

                        if (viewName != null)
                            view.ViewName = viewName.Value;

                        GetTableHeaders(view, tableControl);
                        GetTableColumnItems(view, tableControl);

                        return view;
                    }
                }
            }

            // No formatting file -- just get the public properties.

            var table = new TableDescriptor();

            foreach (var property in outputType.GetProperties())
            {
                var column = new ColumnDescriptor { Header = property.Name, ItemName = property.Name };
                table.Columns.Add(column);
            }

            return table;
        }

        private static void GetTableHeaders(TableDescriptor table, XElement tableControl)
        {
            var tableHeaders = GetChildrenMatching(tableControl, "TableHeaders").FirstOrDefault();

            if (tableHeaders != null)
            {
                foreach (var header in GetChildrenMatching(tableHeaders, "TableColumnHeader"))
                {
                    var column = new ColumnDescriptor();

                    var label = GetChildrenMatching(header, "Label").FirstOrDefault();
                    var width = GetChildrenMatching(header, "Width").FirstOrDefault();

                    if (label != null && !string.IsNullOrEmpty(label.Value))
                    {
                        column.Header = label.Value;
                        table.Columns.Add(column);
                    }
                    if (width != null && !string.IsNullOrEmpty(width.Value))
                    {
                        column.Width = int.Parse(width.Value);
                    }
                }
            }
        }

        private static void GetTableColumnItems(TableDescriptor table, XElement tableControl)
        {
            var tableHeaders = GetChildrenMatching(tableControl, "TableRowEntries").FirstOrDefault();

            if (tableHeaders != null)
            {
                foreach (var entry in GetChildrenMatching(tableHeaders, "TableRowEntry"))
                {
                    foreach (var items in GetChildrenMatching(entry, "TableColumnItems"))
                    {
                        var colIdx = 0;
                        foreach (var item in GetChildrenMatching(items, "TableColumnItem"))
                        {
                            var column = table.Columns[colIdx];
                            var propertyName = GetChildrenMatching(item, "PropertyName").FirstOrDefault();
                            if (propertyName != null && !string.IsNullOrEmpty(propertyName.Value))
                            {
                                column.ItemName = propertyName.Value;
                            }
                            colIdx += 1;
                        }
                    }
                }
            }
        }

        private static void GetListItems(ListDescriptor list, XElement listControl)
        {
            var listEntries = GetChildrenMatching(listControl, "ListEntries").FirstOrDefault();

            if (listEntries != null)
            {
                foreach (var entry in GetChildrenMatching(listEntries, "ListEntry"))
                {
                    foreach (var items in GetChildrenMatching(entry, "ListItems"))
                    {
                        foreach (var item in GetChildrenMatching(items, "ListItem"))
                        {
                            var column = new ColumnDescriptor();

                            var label = GetChildrenMatching(item, "Label").FirstOrDefault();
                            var propertyName = GetChildrenMatching(item, "PropertyName").FirstOrDefault();
                            var property = GetChildrenMatching(item, "Property").FirstOrDefault();

                            if (label != null && !string.IsNullOrEmpty(label.Value))
                            {
                                column.Header = label.Value;
                            }
                            if (propertyName != null && !string.IsNullOrEmpty(propertyName.Value))
                            {
                                column.ItemName = propertyName.Value;
                                if (string.IsNullOrEmpty(column.Header))
                                {
                                    column.Header = propertyName.Value;
                                }
                            }

                            if (property != null && !string.IsNullOrEmpty(property.Value) &&
                                string.IsNullOrEmpty(column.ItemName))
                            {
                                column.ItemName = property.Value;
                            }

                            if (!string.IsNullOrEmpty(column.ItemName) && !string.IsNullOrEmpty(column.Header))
                                list.Properties.Add(column);
                        }
                    }
                }
            }
        }

        private static XElement FindMatchingView(Type outputType, XElement viewDefinitions)
        {
            foreach (var definition in GetChildrenMatching(viewDefinitions, "ViewDefinitions"))
            {
                foreach (var view in GetChildrenMatching(definition, "View"))
                {
                    foreach (var selectedBy in GetChildrenMatching(view, "ViewSelectedBy"))
                    {
                        foreach (var typeName in GetChildrenMatching(selectedBy, "TypeName"))
                        {
                            if (typeName.Value.Equals(outputType.FullName))
                            {
                                // This is our view!
                                return view;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private static IEnumerable<XElement> GetChildrenMatching(XElement node, string name)
        {
            return node.Nodes().Where(c => Matches(c as XElement, name)).Select(c => c as XElement);
        }

        private static IEnumerable<XAttribute> GetAttributeMatching(XElement node, string name)
        {
            return node.Attributes().Where(c => Matches(c, name));
        }

        private static bool Matches(XElement node, string name)
        {
            return node != null && node.Name.LocalName.Equals(name);
        }

        private static bool Matches(XAttribute node, string name)
        {
            return node != null && node.Name.LocalName.Equals(name);
        }

        /// <summary>
        /// Represents the shared elements of table and list views.
        /// </summary>
        internal abstract class ViewDescriptor
        {
            public string ViewName { get; set; }

            public abstract string FormatHeader(int lineLength);
            public abstract string FormatObject(object obj);
        }

        /// <summary>
        /// Represents a table view
        /// </summary>
        internal class TableDescriptor : ViewDescriptor
        {
            public override string FormatHeader(int lineLength)
            {
                var remainingWidth = lineLength-1;
                var undefinedColumns = 0;

                foreach (var column in Columns)
                {
                    if (column.Width == -1)
                        undefinedColumns += 1;
                    else
                        remainingWidth -= column.Width+1;
                }

                var perColumnWidth = (undefinedColumns > 0) ? remainingWidth / undefinedColumns : 0;

                StringBuilder bldr1 = new StringBuilder();
                foreach (var column in Columns)
                {
                    var hdr = column.Header ?? "";
                    if (column.Width == -1)
                        column.Width = perColumnWidth-1;
                    if (hdr.Length > column.Width)
                        hdr = hdr.Substring(0, column.Width);
                    var delta = column.Width - hdr.Length;
                    bldr1.Append(hdr).Append(new string(' ', delta+1));
                }
                bldr1.Append('\n');
                StringBuilder bldr2 = new StringBuilder();
                foreach (var column in Columns)
                {
                    var hdr = column.Header ?? "";
                    if (column.Width == -1)
                        column.Width = perColumnWidth - 1;
                    if (hdr.Length > column.Width)
                        hdr = hdr.Substring(0, column.Width);
                    var delta = column.Width - hdr.Length;
                    bldr2.Append(new string('-', hdr.Length)).Append(new string(' ', delta + 1));
                }
                return bldr1.Append(bldr2).ToString();
            }

            public override string FormatObject(object obj)
            {
                StringBuilder bldr = new StringBuilder();
                foreach (var column in Columns)
                {
                    if (!string.IsNullOrEmpty(column.ItemName))
                    {
                        var pInfo = obj.GetType().GetProperty(column.ItemName);
                        if (pInfo != null)
                        {
                            var value = pInfo.GetValue(obj);
                            var str = (value != null) ? value.ToString() : "null";
                            if (str.Length > column.Width)
                                str = str.Substring(0, column.Width);
                            bldr.Append(str).Append(new string(' ', column.Width - str.Length + 1));
                        }
                        else
                        {
                            bldr.Append(new string(' ', column.Width + 1));
                        }
                    }
                    else
                    {
                        bldr.Append(new string(' ', column.Width + 1));
                    }
                }
                return bldr.ToString();
            }

            public List<ColumnDescriptor> Columns { get; } = new List<ColumnDescriptor>();
        }

        /// <summary>
        /// Represents a list view.
        /// </summary>
        internal class ListDescriptor : ViewDescriptor
        {
            public override string FormatHeader(int lineLength)
            {
                return "";
            }

            public override string FormatObject(object obj)
            {
                int max = Properties.Select(p => p.Header.Length).Max<int>();

                StringBuilder bldr = new StringBuilder();
                foreach (var column in Properties)
                {
                    bldr.Append(column.Header).Append(new string(' ', max - column.Header.Length)).Append(": ");

                    if (!string.IsNullOrEmpty(column.ItemName))
                    {
                        var pInfo = obj.GetType().GetProperty(column.ItemName);
                        if (pInfo != null)
                        {
                            var value = pInfo.GetValue(obj);
                            var str = (value != null) ? value.ToString() : "null";
                            bldr.Append(str).Append("\n");
                        }
                        else
                        {
                            bldr.Append("\n");
                        }
                    }
                    else
                    {
                        bldr.Append("\n");
                    }
                }

                return bldr.ToString();
            }

            public List<ColumnDescriptor> Properties { get; } = new List<ColumnDescriptor>();
        }

        internal class ColumnDescriptor
        {
            public string Header { get; set; }
            public string ItemName { get; set; }
            public int Width { get; set; } = -1;
        }
    }
}
