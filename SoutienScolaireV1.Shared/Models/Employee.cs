using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoutienScolaireV1.Shared.Models
{
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; } = Guid.NewGuid().GetHashCode();
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "department")]
        public string Department { get; set; }
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }
    }
}
