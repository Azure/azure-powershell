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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class PSContainerRegistryWebhookEvent
    {
        public PSContainerRegistryWebhookEvent(EventModel webhookEvent)
        {
            Id = webhookEvent?.Id;
            EventRequestMessage = new PSEventRequestMessage(webhookEvent?.EventRequestMessage);
            EventResponseMessage = webhookEvent?.EventResponseMessage;
        }

        public string Id { get; set; }
        public PSEventRequestMessage EventRequestMessage { get; set; }
        public EventResponseMessage EventResponseMessage { get; set; }
    }

    public class PSEventResponseMessage
    {
        public PSEventResponseMessage(EventResponseMessage responseMessage)
        {
            Content = responseMessage?.Content;
            Headers = responseMessage?.Headers;
            ReasonPhrase = responseMessage?.ReasonPhrase;
            StatusCode = responseMessage?.StatusCode;
            Version = responseMessage?.Version;
        }

        public string Content { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public string ReasonPhrase { get; set; }
        public string StatusCode { get; set; }
        public string Version { get; set; }
    }

    public class PSEventRequestMessage
    {
        public PSEventRequestMessage(EventRequestMessage requestMessage)
        {
            Content = new PSEventContent(requestMessage?.Content);
            Headers = requestMessage?.Headers;
            Method = requestMessage?.Method;
            RequestUri = requestMessage?.RequestUri;
            Version = requestMessage?.Version;
        }
        public PSEventContent Content { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public string Method { get; set; }
        public string RequestUri { get; set; }
        public string Version { get; set; }
    }

    public class PSEventContent
    {
        public PSEventContent(EventContent eventContent)
        {
            Id = eventContent?.Id;
            Timestamp = eventContent?.Timestamp;
            Action = eventContent?.Action;
            Target = new PSTarget(eventContent?.Target);
            Request = new PSRequest(eventContent?.Request);
            ActorName = eventContent?.Actor?.Name;
            Source = new PSSource(eventContent?.Source);
        }

        public string Id { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Action { get; set; }
        public PSTarget Target { get; set; }
        public PSRequest Request { get; set; }
        public string ActorName { get; set; }
        public PSSource Source { get; set; }
    }

    public class PSTarget
    {
        public PSTarget(Target target)
        {
            MediaType = target?.MediaType;
            Size = target?.Size;
            Digest = target?.Digest;
            Length = target?.Length;
            Repository = target?.Repository;
            Url = target?.Url;
            Tag = target?.Tag;
        }

        public string MediaType { get; set; }
        public long? Size { get; set; }
        public string Digest { get; set; }
        public long? Length { get; set; }
        public string Repository { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
    }

    public class PSRequest
    {
        public PSRequest(Request request)
        {
            Id = request?.Id;
            Addr = request?.Addr;
            Host = request?.Host;
            Method = request?.Method;
            Useragent = request?.Useragent;
        }
        public string Id { get; set; }
        public string Addr { get; set; }
        public string Host { get; set; }
        public string Method { get; set; }
        public string Useragent { get; set; }
    }

    public class PSSource
    {
        public PSSource(Source source)
        {
            Addr = source?.Addr;
            InstanceID = source?.InstanceID;
        }

        public string Addr { get; set; }
        public string InstanceID { get; set; }
    }
}
