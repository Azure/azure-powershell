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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;
using System.Xml;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Topic
{
    /// <summary>
    /// 'New-AzureRmServiceBusTopic' Cmdlet creates a new ServiceBus Topic
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServicebusTopicVerb, SupportsShouldProcess = true), OutputType(typeof(TopicAttributes))]
    public class NewAzureRmServiceBusTopic : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Topic Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasTopicName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "EnablePartitioning")]
        [ValidateSet("TRUE", "FALSE",
             IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnablePartitioning { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Auto Delete On Idle - the TimeSpan idle interval after which the queue is automatically deleted. The minimum duration is 5 minutes.")]
        [ValidateNotNullOrEmpty]
        public string AutoDeleteOnIdle { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Timespan to live value. This is the duration after which the message expires, starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself. For Standard = Timespan.Max and Basic = 14 dyas")]
        [ValidateNotNullOrEmpty]
        public string DefaultMessageTimeToLive { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Duplicate Detection History Time Window - TimeSpan, that defines the duration of the duplicate detection history. The default value is 10 minutes.")]
        [ValidateNotNullOrEmpty]
        public string DuplicateDetectionHistoryTimeWindow { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Batched Operations - value that indicates whether server-side batched operations are enabled")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnableBatchedOperations { get; set; }        

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "EnableExpress - a value that indicates whether Express Entities are enabled. An express queue holds a message in memory temporarily before writing it to persistent storage.")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnableExpress { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "MaxSizeInMegabytes - the maximum size of the queue in megabytes, which is the size of memory allocated for the queue.")]
        [ValidateNotNullOrEmpty]
        public long? MaxSizeInMegabytes { get; set; }
        
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RequiresDuplicateDetection - a value that indicates whether the queue supports the concept of session")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? RequiresDuplicateDetection { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SupportOrdering - the value indicating it supports ordering.")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? SupportOrdering { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SizeInBytes - the size of the queue in bytes.")]
        [ValidateNotNullOrEmpty]
        public long? SizeInBytes { get; set; }

        public override void ExecuteCmdlet()
        {
            TopicAttributes topicAttributes = new TopicAttributes();

            NamespaceAttributes getNamespaceLoc = Client.GetNamespace(ResourceGroupName, Namespace);            
            
            topicAttributes.Name = Name;

            if(EnablePartitioning != null)
            topicAttributes.EnablePartitioning = EnablePartitioning;
            
            
            if (AutoDeleteOnIdle != null)
                topicAttributes.AutoDeleteOnIdle = AutoDeleteOnIdle;

            if (DefaultMessageTimeToLive != null)
                topicAttributes.DefaultMessageTimeToLive = DefaultMessageTimeToLive;

            if (DuplicateDetectionHistoryTimeWindow != null)
                topicAttributes.DuplicateDetectionHistoryTimeWindow = DuplicateDetectionHistoryTimeWindow;


            if (EnableBatchedOperations != null)
                topicAttributes.EnableBatchedOperations = EnableBatchedOperations;

            

            if (EnableExpress != null)
                topicAttributes.EnableExpress = EnableExpress;
            

            if (MaxSizeInMegabytes != null)
                topicAttributes.MaxSizeInMegabytes = (int?)MaxSizeInMegabytes;

            if (RequiresDuplicateDetection != null)
                topicAttributes.RequiresDuplicateDetection = RequiresDuplicateDetection;

            if (SupportOrdering != null)
                topicAttributes.SupportOrdering = SupportOrdering;

            if (SizeInBytes != null)
                topicAttributes.SizeInBytes = SizeInBytes;
            
            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateTopic, Name, Namespace)))
            {
                WriteObject(Client.CreateUpdateTopic(ResourceGroupName, Namespace, Name, topicAttributes));
            }
        }
    }
}
