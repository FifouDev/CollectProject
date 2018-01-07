using Newtonsoft.Json;
using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPro.Models
{
    public class Volume
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("VolumeName")]
        public string Name { get; set; }
        [JsonProperty("VolumeDescription")]
        public string Description { get; set; }
        [JsonProperty("VolumeImageUrl")]
        public string ImageUrl { get; set; }
    }
}
