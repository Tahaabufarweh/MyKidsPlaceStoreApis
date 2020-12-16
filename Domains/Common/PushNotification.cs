using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Common
{
    public class PushNotification
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string DeviceToken { get; set; }
        public long? UserId { get; set; }
        public string Type { get; set; }
        public object Data { get; set; }
        public string Role { get; set; }
        public int DeviceType { get; set; }
    }
}
