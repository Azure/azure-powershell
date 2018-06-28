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

using System;

namespace Microsoft.WindowsAzure.Commands.Common.Attributes
{
    [Flags]
    public enum ViewControl
    {
        None = 0,
        Table,
        List,
        All = Table | List,
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public sealed class Ps1XmlAttribute : Attribute
    {
        public string Label { get; set; }

        public ViewControl Target { get; set; } = ViewControl.Table;

        public string ScriptBlock { get; set; }

        public bool GroupByThis { get; set; }

        public uint TableColumnWidth { get; set; }

        public uint Position { get; set; } = Ps1XmlConstants.DefaultPosition;
    }

    public static class Ps1XmlConstants
    {
        public static uint DefaultPosition = 1000;
    }
}
