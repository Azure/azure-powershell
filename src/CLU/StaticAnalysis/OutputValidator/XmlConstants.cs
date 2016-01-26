// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace StaticAnalysis.OutputValidator
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
