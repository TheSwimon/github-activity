using github_activity;
using github_activity.Models;
using System.Text.Json;
using System.Text.Json.Serialization;



GithubActivityClient client = new GithubActivityClient();
GithubActivityUI terminal = new GithubActivityUI();


var events = await client.GetGithubActivity(args.Length > 0 ? args[0] : "kamranahmedse");
terminal.DisplayActivity(events);
