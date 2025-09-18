using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace github_activity.Models
{
    public class GithubEvent
    {
        public string? Type { get; set; }

        public JsonElement Payload { get; set; }

        public Repo Repo { get; set; } = new Repo();
    }
}
