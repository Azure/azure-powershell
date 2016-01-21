using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatParser
{
    public static class XmlConstants
    {
        public const string ViewDefinitions = "ViewDefinitions";
        public const string View = "View";
        public const string ViewType = "ViewSelectedBy";
        public const string ListControl = "ListControl";
        public const string ListEntries = "ListEntries";
        public const string ListEntry = "ListEntry";
        public const string ListItems = "ListItems";
        public const string ListItem = "ListItem";
        public const string TableControl = "TableControl";
        public const string TableRowEntries = "TableRowEntries";
        public const string TableRowEntry = "TableRowEntry";
        public const string TableColumnItems = "TableColumnItems";
        public const string TableColumnItem = "TableColumnItem";
        public const string LabelItem = "Label";
        public static readonly string[] RequiredFormatEntries = new[] {"Property", "PropertyName"};
    }
}
