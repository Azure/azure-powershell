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
using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.ServiceBus
{
    public class ServiceBusConstants
    {
        public const string ServiceBusXNamespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect";
        public const string AtomNamespaceName = "http://www.w3.org/2005/Atom";
        public const string NamespaceNamePattern = "^[a-zA-Z][a-zA-Z0-9-]*$";
    }

    public class CustomBodyWriter : BodyWriter
    {
        string body;

        public CustomBodyWriter(string body)
            : base(true)
        {
            this.body = body;
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            XmlReader r = XmlReader.Create(new StringReader(body));
            writer.WriteNode(r, false);
        }
    }

    public class ServiceBusFormatter<T> : IClientMessageFormatter where T : class, new()
    {
        private IClientMessageFormatter originalFormatter;

        public ServiceBusFormatter(IClientMessageFormatter originalFormatter)
        {
            this.originalFormatter = originalFormatter;
        }

        public object DeserializeReply(Message message, object[] parameters)
        {
            XDocument response = XDocument.Parse(ServiceManagementUtilities.ReadMessageBody(ref message));
            List<T> results = new List<T>();
            IEnumerable<XElement> contents = response.Descendants(XName.Get("content", ServiceBusConstants.AtomNamespaceName));
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            foreach (XElement content in contents)
            {
                XElement data = content.Elements().First<XElement>();
                results.Add((T)serializer.Deserialize(new StringReader(data.ToString())));
            }

            if (response.Root.Name == XName.Get("feed", ServiceBusConstants.AtomNamespaceName))
            {
                List<T> collection = new List<T>();
                collection.AddRange(results);
                return collection;
            }
            else
            {
                return results[0];
            }
        }

        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            T data = null;
            string body = string.Empty;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            Message originalMessage = originalFormatter.SerializeRequest(messageVersion, parameters);

            foreach (object parameter in parameters)
            {
                if (parameter is T)
                {
                    data = parameter as T;
                    break;
                }
            }

            if (data == null)
            {
                return originalMessage;
            }

            using (StringWriter bodyWriter = new StringWriter())
            {
                serializer.Serialize(bodyWriter, data);
                body = bodyWriter.ToString();
            }

            body = new XDocument(
                new XElement(XName.Get("entry", ServiceBusConstants.AtomNamespaceName),
                    new XElement(XName.Get("content", ServiceBusConstants.AtomNamespaceName),
                            new XAttribute("type", "application/xml"),
                            XDocument.Parse(body).Root))).ToString();
            Message finalMessage = Message.CreateMessage(messageVersion, null, new CustomBodyWriter(body));
            finalMessage.Headers.CopyHeadersFrom(originalMessage);
            finalMessage.Properties.CopyProperties(originalMessage.Properties);
            HttpRequestMessageProperty property = finalMessage.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            property.Headers.Add("content-type", "application/xml");
            property.Headers.Add("type", "entry");
            property.Headers.Add("charset", "utf-8");

            return finalMessage;
        }
    }

    public class ServiceBusBehaviorAttribute : Attribute, IOperationBehavior
    {
        private Type dataContractType;

        public ServiceBusBehaviorAttribute(Type formatterType)
        {
            this.dataContractType = formatterType;
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            // Do nothing.
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            Type genericFormatterType = typeof(ServiceBusFormatter<>);
            Type formatterType = genericFormatterType.MakeGenericType(new Type[] { dataContractType });
            ConstructorInfo ctor = formatterType.GetConstructor(new Type[] { typeof(IClientMessageFormatter) });
            IClientMessageFormatter newFormatter = ctor.Invoke(new object[] { clientOperation.Formatter }) as IClientMessageFormatter;
            clientOperation.Formatter = newFormatter;
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            throw new NotImplementedException();
        }

        public void Validate(OperationDescription operationDescription)
        {

        }
    }
}
