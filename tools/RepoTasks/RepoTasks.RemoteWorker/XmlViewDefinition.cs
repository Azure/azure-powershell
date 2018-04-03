// ----------------------------------------------------------------------------------
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

namespace RepoTasks.RemoteWorker
{
    using System;
    using System.Xml.Serialization;

    public class Configuration
    {
        public ViewDefinitions ViewDefinitions { get; set; }
    }

    public class ViewDefinitions
    {
        [XmlElement("View")]
        public View[] Views { get; set; }
    }

    public class View
    {
        public string Name { get; set; }
        public ViewSelectedBy ViewSelectedBy { get; set; }
        public TableControl TableControl { get; set; }
        public ListControl ListControl { get; set; }
    }

    public class ViewSelectedBy
    {
        public string TypeName { get; set; }
    }

    #region ListControl

    public class ListControl
    {
        public ListEntry[] ListEntries { get; set; }
    }

    public class ListEntry
    {
        public EntrySelectedBy EntrySelectedBy { get; set; }
        public ListItem[] ListItems { get; set; }
    }

    public class EntrySelectedBy
    {
        public string TypeName { get; set; }
        public string SelectionSetName { get; set; }
        public SelectionCondition SelectionCondition { get; set; }
    }

    public class SelectionCondition
    {
        public string TypeName { get; set; }
        public string SelectionSetName { get; set; }
        public string PropertyName { get; set; }
        public string ScriptBlock { get; set; }
    }

    public class ListItem
    {
        public string PropertyName { get; set; }
        public string ScriptBlock { get; set; }
        public string Label { get; set; }
        public string FormatString { get; set; }
        public ItemSelectionCondition ItemSelectionCondition { get; set; }
    }

    public class ItemSelectionCondition
    {
        public string PropertyName { get; set; }
        public string ScriptBlock { get; set; }
    }

    #endregion

    #region TableControl

    public class TableControl
    {
        public TableColumnHeader[] TableHeaders { get; set; }
        public TableRowEntry[] TableRowEntries { get; set; }
    }

    public class TableColumnHeader : Alignable
    {
        public string Label { get; set; }
        public int? Width { get; set; }
        public bool ShouldSerializeWidth()
        {
            return Width.HasValue;
        }

        // Alignment comes from base class
    }

    public class TableRowEntry
    {
        public TableColumnItem[] TableColumnItems { get; set; }
    }

    public class TableColumnItem : Alignable
    {
        // Alignment comes from base class
        public string PropertyName { get; set; }
        public string FormatString { get; set; }
        public string ScriptBlock { get; set; }
    }

    #endregion

    #region Helpers

    public enum Alignment
    {
        Left, Right, Center
    }

    public class Alignable
    {
        protected Alignable()
        {
            this.Alignment = Alignment.Left;
        }

        private string _alignment;

        public Alignment Alignment
        {
            set { this._alignment = value.ToString("F"); }
            get { return (Alignment)Enum.Parse(typeof(Alignment), this._alignment); }
        }
    }

    #endregion
}
