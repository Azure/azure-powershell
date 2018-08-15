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

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace NetCoreCsProjSync.NewModel
{
    public class XmlBool : IXmlSerializable, IEquatable<XmlBool>, IEquatable<bool?>
    {
        private bool? _value;

        public XmlBool() : this(null)
        {
        }

        public XmlBool(bool? value)
        {
            _value = value;
        }

        public bool Equals(XmlBool other) => other != null && _value == other._value;

        public bool Equals(bool? other) => other != null && _value == other;

        public static implicit operator bool?(XmlBool xmlBool) => xmlBool._value;

        public static implicit operator bool(XmlBool xmlBool) => xmlBool._value ?? false;

        public static implicit operator XmlBool(bool? value) => new XmlBool(value);

        public static implicit operator XmlBool(bool value) => new XmlBool(value);

        //https://www.codeproject.com/Articles/43237/How-to-Implement-IXmlSerializable-Correctly
        public XmlSchema GetSchema() => null;
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            _value = reader.IsEmptyElement ? null : new bool?(bool.Parse(reader.ReadElementContentAsString().ToLowerInvariant()));
        }

        public void WriteXml(XmlWriter writer) => writer.WriteValue(_value.ToString().ToLowerInvariant());
    }
}
