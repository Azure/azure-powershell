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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace StaticAnalysis.OutputValidator
{
    public class FormatParser
    {
        private XDocument _formatFile;
        private string _target;
        private IEnumerable<XElement> _views;
        private IToolsLogger _logger;
        public FormatParser(IToolsLogger logger, string path)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger;
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            _target = path;
            if (!File.Exists(path))
            {
                throw new ArgumentOutOfRangeException(nameof(path), "Path to xml document must exist");
            }

            _formatFile = XDocument.Load(new FileStream(path, FileMode.Open));
            var root = _formatFile.Root;
            _views = GetViews(root);
        }

        /// <summary>
        /// Get the list of valid type formats in this format file
        /// </summary>
        /// <returns>The list of valid type formats contained in this format file</returns>
        public IEnumerable<string> GetValidTypeList()
        {
            return _views.Where(CheckValidFormat).Select(GetViewType);
        }

        /// <summary>
        /// Get the list of invalid type formats in this format file
        /// </summary>
        /// <returns>The list of invalid type formats contained in this format file</returns>
        public IEnumerable<string> GetInvalidTypeList()
        {
            return _views.Where( e => !CheckValidFormat(e)).Select(GetViewType);
        }

        public bool ValidateFormat()
        {
            return _views.All(CheckValidFormat);
        }

        private string GetViewType(XElement viewElement)
        {
            string result = null;
            var viewTypeElement = viewElement.GetChildElement(XmlConstants.ViewType);
            if (viewTypeElement != null)
            {
                result = viewTypeElement.Value;
            }

            return result;
        }

        public bool CheckValidFormat(XElement viewElement)
        {
            var result = false;
            var name = GetViewType(viewElement);
            var listControl = viewElement.GetChildElement(XmlConstants.ListControl);
            var tableControl = viewElement.GetChildElement(XmlConstants.TableControl);
            if (listControl == null && tableControl == null)
            {
                _logger.WriteError($"No valid list or table control for type: '{name}'");
            }
            else if (listControl != null)
            {
                result = CheckValidListControl(listControl, name);
            }
            else
            {
                result = CheckValidTableControl(tableControl, name);
            }

            return result;
        }

        private bool CheckValidTableControl(XElement tableControl, string typeName)
        {
            var result = true;
            foreach (var tableColumnItem in GetTableCoumnItems(tableControl))
            {
                if (!tableColumnItem.ContainsChildElement(XmlConstants.RequiredFormatEntries))
                {
                    var label = tableColumnItem.GetChildElement(XmlConstants.LabelItem)?.Value;
                    string error = $"Type '{typeName}' contains invalid table column format. ";
                    if (label != null)
                    {
                        error += $" Column label: '{label}'";
                    }

                    _logger.WriteError(error);
                    _logger.LogRecord(new ValidationRecord {Target = typeName, Severity = 0, Description = error,
                        Remediation = $"Replace unsupported format elements in {_target} table control for {typeName}"});
                    result = false;
                }
            }

            return result;
        }

        private IEnumerable<XElement> GetTableCoumnItems(XElement tableControl)
        {
                return tableControl.GetChildElement(XmlConstants.TableRowEntries)?
                    .GetChildElements(XmlConstants.TableRowEntry)
                    .SelectMany(i => i.GetChildElement(XmlConstants.TableColumnItems)?.GetChildElements(XmlConstants.TableColumnItem));
        }

        private bool CheckValidListControl(XElement listControl, string typeName)
        {
            var result = true;
            foreach (var listItem in GetListItems(listControl))
            {
                if (!listItem.ContainsChildElement(XmlConstants.RequiredFormatEntries))
                {
                    var label = listItem.GetChildElement(XmlConstants.LabelItem)?.Value;
                    string error = $"Type '{typeName}' contains invalid list column format. ";
                    if (label != null)
                    {
                        error += $" Item label: '{label}'";
                    }

                    _logger.WriteError(error);
                    _logger.LogRecord(new ValidationRecord { Target = typeName, Severity = 0, Description = error,
                        Remediation = $"Replace unsupported format elements in {_target} table control for {typeName}" });
                    result = false;
                }
            }

            return result;
        }

        private IEnumerable<XElement> GetListItems(XElement listControl)
        {
            return listControl.GetChildElement(XmlConstants.ListEntries)?
                .GetChildElements(XmlConstants.ListEntry)
                .SelectMany(i => i.GetChildElement(XmlConstants.ListItems)?.GetChildElements(XmlConstants.ListItem));
        }

        private IEnumerable<XElement> GetViews(XElement root)
        {
            IEnumerable<XElement> result = null;
            var viewDefinitions = root.GetChildElement(XmlConstants.ViewDefinitions);
            if (viewDefinitions != null)
            {
                result = viewDefinitions.GetChildElements(XmlConstants.View);
            }

            return result;
        }
    }
}
