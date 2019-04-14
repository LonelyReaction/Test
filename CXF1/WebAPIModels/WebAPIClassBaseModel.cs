using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPIModels
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WebAPIClassBaseModel
    {
        [JsonProperty("StringData")]
        public string StringData { get; protected set; }
        [JsonProperty("IntData")]
        public int IntData { get; protected set; }
        [JsonProperty("TimeData")]
        public DateTime TimeData { get; protected set; }
    }
}
