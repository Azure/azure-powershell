/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell
{
    internal class ViewParameters
    {
        public Type Type { get; }
        public IEnumerable<PropertyFormat> Properties { get; }

        public ViewParameters(Type type, IEnumerable<PropertyFormat> properties)
        {
            Type = type;
            Properties = properties;
        }
    }

    internal class PropertyFormat
    {
        public PropertyInfo Property { get; }
        public FormatTableAttribute FormatTable { get; }

        public int? Index { get; }
        public string Label { get; }
        public int? Width { get; }
        public PropertyOrigin? Origin { get; }

        public PropertyFormat(PropertyInfo propertyInfo)
        {
            Property = propertyInfo;
            FormatTable = Property.GetCustomAttributes<FormatTableAttribute>().FirstOrDefault();
            var origin = Property.GetCustomAttributes<OriginAttribute>().FirstOrDefault();

            Index = FormatTable?.HasIndex ?? false ? (int?)FormatTable.Index : null;
            Label = FormatTable?.Label ?? propertyInfo.Name;
            Width = FormatTable?.HasWidth ?? false ? (int?)FormatTable.Width : null;
            // If we have an index, we don't want to use Origin.
            Origin = FormatTable?.HasIndex ?? false ? null : origin?.Origin;
        }
    }

    [Serializable]
    [XmlRoot(nameof(Configuration))]
    public class Configuration
    {
        [XmlElement("ViewDefinitions")]
        public ViewDefinitions ViewDefinitions { get; set; }
    }

    [Serializable]
    public class ViewDefinitions
    {
        //https://stackoverflow.com/a/10518657/294804
        [XmlElement("View")]
        public List<View> Views { get; set; }
    }

    [Serializable]
    public class View
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; }
        [XmlElement(nameof(ViewSelectedBy))]
        public ViewSelectedBy ViewSelectedBy { get; set; }
        [XmlElement(nameof(TableControl))]
        public TableControl TableControl { get; set; }
    }

    [Serializable]
    public class ViewSelectedBy
    {
        [XmlElement(nameof(TypeName))]
        public string TypeName { get; set; }
    }

    [Serializable]
    public class TableControl
    {
        [XmlElement(nameof(TableHeaders))]
        public TableHeaders TableHeaders { get; set; }
        [XmlElement(nameof(TableRowEntries))]
        public TableRowEntries TableRowEntries { get; set; }
    }

    [Serializable]
    public class TableHeaders
    {
        [XmlElement("TableColumnHeader")]
        public List<TableColumnHeader> TableColumnHeaders { get; set; }
    }

    [Serializable]
    public class TableColumnHeader
    {
        [XmlElement(nameof(Label))]
        public string Label { get; set; }
        [XmlElement(nameof(Width))]
        public int? Width { get; set; }

        //https://stackoverflow.com/a/4095225/294804
        public bool ShouldSerializeWidth() => Width.HasValue;
    }

    [Serializable]
    public class TableRowEntries
    {
        [XmlElement(nameof(TableRowEntry))]
        public TableRowEntry TableRowEntry { get; set; }
    }

    [Serializable]
    public class TableRowEntry
    {
        [XmlElement(nameof(TableColumnItems))]
        public TableColumnItems TableColumnItems { get; set; }
    }

    [Serializable]
    public class TableColumnItems
    {
        [XmlElement("TableColumnItem")]
        public List<TableColumnItem> TableItems { get; set; }
    }

    [Serializable]
    public class TableColumnItem
    {
        [XmlElement(nameof(PropertyName))]
        public string PropertyName { get; set; }
    }
}
