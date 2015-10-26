// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Microsoft.Azure.Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// </summary>
    public partial class MAMPolicyProperties
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Possible values for this property include: 'none',
        /// 'policyManagedApps', 'allApps'.
        /// </summary>
        [JsonProperty(PropertyName = "appSharingFromLevel")]
        public string AppSharingFromLevel { get; set; }

        /// <summary>
        /// Possible values for this property include: 'none',
        /// 'policyManagedApps', 'allApps'.
        /// </summary>
        [JsonProperty(PropertyName = "appSharingToLevel")]
        public string AppSharingToLevel { get; set; }

        /// <summary>
        /// Possible values for this property include: 'required',
        /// 'notRequired'.
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public string Authentication { get; set; }

        /// <summary>
        /// Possible values for this property include: 'blocked',
        /// 'policyManagedApps', 'policyManagedAppsWithPasteIn', 'allApps'.
        /// </summary>
        [JsonProperty(PropertyName = "clipboardSharingLevel")]
        public string ClipboardSharingLevel { get; set; }

        /// <summary>
        /// Possible values for this property include: 'allow', 'block'.
        /// </summary>
        [JsonProperty(PropertyName = "dataBackup")]
        public string DataBackup { get; set; }

        /// <summary>
        /// Possible values for this property include: 'allow', 'block'.
        /// </summary>
        [JsonProperty(PropertyName = "fileSharingSaveAs")]
        public string FileSharingSaveAs { get; set; }

        /// <summary>
        /// Possible values for this property include: 'required',
        /// 'notRequired'.
        /// </summary>
        [JsonProperty(PropertyName = "pin")]
        public string Pin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pinNumRetry")]
        public int? PinNumRetry { get; set; }

        /// <summary>
        /// Possible values for this property include: 'enable', 'disable'.
        /// </summary>
        [JsonProperty(PropertyName = "deviceCompliance")]
        public string DeviceCompliance { get; set; }

        /// <summary>
        /// Possible values for this property include: 'required',
        /// 'notRequired'.
        /// </summary>
        [JsonProperty(PropertyName = "managedBrowser")]
        public string ManagedBrowser { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "accessRecheckOfflineTimeout")]
        public string AccessRecheckOfflineTimeout { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "accessRecheckOnlineTimeout")]
        public string AccessRecheckOnlineTimeout { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "offlineWipeTimeout")]
        public string OfflineWipeTimeout { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "numOfApps")]
        public int? NumOfApps { get; private set; }

        /// <summary>
        /// Possible values for this property include: 'notTargeted',
        /// 'targeted'.
        /// </summary>
        [JsonProperty(PropertyName = "groupStatus")]
        public string GroupStatus { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedTime")]
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (FriendlyName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FriendlyName");
            }
        }
    }
}
