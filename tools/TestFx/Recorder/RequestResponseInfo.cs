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
using System.Linq;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class RequestResponseInfo
    {
        public RecordEntry InternalRecordEntry { get; internal set; }

        public LongRunningOperationInfo LroInfo { get; internal set; }

        public RequestResponseInfo(RecordEntry entry)
        {
            InternalRecordEntry = entry;
            LroInfo = new LongRunningOperationInfo(entry);
        }
    }

    public class LongRunningOperationInfo
    {
        const string perfImpactKey = "RecordPlaybackPerfImpact";

        const string operationKey = "LroOperation";

        public string OperationVerb { get; internal set; }

        public bool IsPlaybackPerfImpacted { get; internal set; }

        public LROHeaderInfo LroHeader { get; internal set; }

        public LroInfoId LroId { get; internal set; }

        public LongRunningOperationInfo(RecordEntry entry)
        {
            IsPlaybackPerfImpacted = false;

            LroHeader = new LROHeaderInfo(entry.RequestHeaders);
            InitDataFromHeaders(entry.RequestHeaders);
            LroId = new LroInfoId(entry.RequestHeaders);
        }

        void InitDataFromHeaders(Dictionary<string, List<string>> headers)
        {
            foreach (KeyValuePair<string, List<string>> kv in headers)
            {
                if (kv.Key.Equals(operationKey, StringComparison.OrdinalIgnoreCase))
                {
                    OperationVerb = kv.Value?.SingleOrDefault();
                }

                if (kv.Key.Equals(perfImpactKey, StringComparison.OrdinalIgnoreCase))
                {
                    IsPlaybackPerfImpacted = Convert.ToBoolean(kv.Value?.SingleOrDefault());
                }
            }
        }
    }

    public class LroInfoId
    {
        const string sessionIdKey = "LroSessionId";

        const string sessionPollingIdKey = "LroPollingId";

        private string internalSessionPollingId { get; set; }

        public long SessionId { get; internal set; }

        public long PollingId { get; internal set; }

        public int PollingCount { get; internal set; }

        public LroInfoId(Dictionary<string, List<string>> headers)
        {
            SessionId = 0;
            PollingId = 0;
            PollingCount = 0;
            DeconstructSessionPollingId(headers);
        }

        void DeconstructSessionPollingId(Dictionary<string, List<string>> headers)
        {
            foreach (KeyValuePair<string, List<string>> kv in headers)
            {
                if (kv.Key.Equals(sessionIdKey, StringComparison.OrdinalIgnoreCase))
                {
                    SessionId = Convert.ToInt64(kv.Value?.SingleOrDefault());
                }

                if (kv.Key.Equals(sessionPollingIdKey, StringComparison.OrdinalIgnoreCase))
                {
                    internalSessionPollingId = kv.Value?.Single();
                }
            }

            if (!string.IsNullOrEmpty(internalSessionPollingId))
            {
                string[] sessionPollingTokens = internalSessionPollingId.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (sessionPollingTokens != null)
                {
                    if (sessionPollingTokens.Length == 3)
                    {
                        PollingId = Convert.ToInt64(sessionPollingTokens[1]);
                        PollingCount = Convert.ToInt32(sessionPollingTokens[2]);
                    }
                }
            }
        }

        public static bool operator >(LroInfoId lhId, LroInfoId rhId)
        {
            bool greaterThan;

            if ((lhId.SessionId > rhId.SessionId) &&
                (lhId.PollingId > rhId.PollingId) &&
                (lhId.PollingCount > rhId.PollingCount))
            {
                greaterThan = true;
            }
            else if ((lhId.SessionId == rhId.SessionId) &&
                     (lhId.PollingId > rhId.PollingId) &&
                     (lhId.PollingCount > rhId.PollingCount))
            {
                greaterThan = true;
            }
            else if ((lhId.SessionId == rhId.SessionId) &&
                     (lhId.PollingId == rhId.PollingId) &&
                     (lhId.PollingCount > rhId.PollingCount))
            {
                greaterThan = true;
            }
            else
                greaterThan = false;

            return greaterThan;
        }

        public static bool operator <(LroInfoId lhId, LroInfoId rhId)
        {
            bool lessThan;

            if ((lhId.SessionId < rhId.SessionId) &&
                (lhId.PollingId < rhId.PollingId) &&
                (lhId.PollingCount < rhId.PollingCount))
            {
                lessThan = true;
            }
            else if ((lhId.SessionId == rhId.SessionId) &&
                     (lhId.PollingId < rhId.PollingId) &&
                     (lhId.PollingCount < rhId.PollingCount))
            {
                lessThan = true;
            }
            else if ((lhId.SessionId == rhId.SessionId) &&
                     (lhId.PollingId == rhId.PollingId) &&
                     (lhId.PollingCount < rhId.PollingCount))
            {
                lessThan = true;
            }
            else
                lessThan = false;

            return lessThan;
        }

        public override string ToString()
        {
            return internalSessionPollingId;
        }
    }

    public class LROHeaderInfo
    {
        const string LocHeaderKey = "Location";
        const string AzAsyncHeaderKey = "Azure-AsyncOperation";

        public string LocationHeader { get; private set; }

        public string AzureAsyncOperationHeader { get; private set; }

        private LroHeaderKind HeaderKind { get; set; }

        public LROHeaderInfo(Dictionary<string, List<string>> headers)
        {
            LocationHeader = string.Empty;
            AzureAsyncOperationHeader = string.Empty;

            foreach (KeyValuePair<string, List<string>> kv in headers)
            {
                if (kv.Key.Equals(LocHeaderKey, StringComparison.OrdinalIgnoreCase))
                {
                    LocationHeader = kv.Value?.FirstOrDefault();
                }

                if (kv.Key.Equals(AzAsyncHeaderKey, StringComparison.OrdinalIgnoreCase))
                {
                    AzureAsyncOperationHeader = kv.Value?.FirstOrDefault();
                }
            }

            UpdateHeaderKind();
        }

        private void UpdateHeaderKind()
        {
            bool validLoc = false, validAzAsync = false;

            if (IsValidUri(LocationHeader))
            {
                validLoc = true;
                HeaderKind = LroHeaderKind.Location;
            }

            if (IsValidUri(AzureAsyncOperationHeader))
            {
                validAzAsync = true;
                HeaderKind = LroHeaderKind.AzureAsync;
            }

            if (validLoc && validAzAsync)
                HeaderKind = LroHeaderKind.Location_AzureAsync;
        }

        private Uri GetValidUri(string uriString)
        {
            Uri validUri = null;
            try
            {
                validUri = new Uri(uriString);
            }
            catch { }

            return validUri;
        }

        private bool IsValidUri(string uriString)
        {
            if (GetValidUri(uriString) == null)
                return false;

            return true;
        }

        public enum LroHeaderKind
        {
            Location,
            AzureAsync,
            Location_AzureAsync
        }
    }
}
