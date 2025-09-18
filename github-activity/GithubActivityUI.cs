using github_activity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace github_activity
{
    public class GithubActivityUI
    {

        public GithubActivityUI()
        {

        }

        public void DisplayActivity(List<GithubEvent> events)
        {
            string action = "";
            foreach (var ev in events)
            {
                switch (ev.Type)
                {
                    case "PushEvent":
                        var commitAmount = ev.Payload.GetProperty("commits").GetArrayLength();
                        action = $"Pushed {commitAmount} commits to {ev.Repo.Name}";
                        break;
                    case "PullRequestEvent":
                        action = $"{ev.Payload.GetProperty("action")} pull request #{ev.Payload.GetProperty("number")} in {ev.Repo.Name}";
                        break;
                    case "IssueCommentEvent":
                        action = $"{ev.Payload.GetProperty("action")} comment in {ev.Repo.Name}";
                        break;
                    case "DeleteEvent":
                        action = $"Deleted {ev.Payload.GetProperty("ref_type")} {ev.Payload.GetProperty("ref")} in {ev.Repo.Name}";
                        break;
                    case "ReleaseEvent":
                        action = $"{ev.Payload.GetProperty("action")} release {(ev.Payload.GetProperty("release")).GetProperty("name")} in {ev.Repo.Name}";
                        break;
                    case "PullRequestReviewEvent":
                        action = $"{ev.Payload.GetProperty("action")} review on pull request #{ev.Payload.GetProperty("number")} in {ev.Repo.Name}";
                        break;
                    case "PullRequestReviewCommentEvent":
                        action = $"{ev.Payload.GetProperty("action")} review comment on pull request #{ev.Payload.GetProperty("number")} in {ev.Repo.Name}";
                        break;
                    case "CommitCommentEvent":
                        action = $"{ev.Payload.GetProperty("action")} comment in {ev.Repo.Name}";
                        break;
                    case "GollumEvent":
                        action = $"Created/Updated wiki page {ev.Payload.GetProperty("pages[][page_name]")} in {ev.Repo.Name}";
                        break;
                    case "SponsorshipEvent":
                        action = $"{ev.Payload.GetProperty("action")} sponsorship";
                        break;
                    case "IssueEvent":
                        action = $"{ev.Payload.GetProperty("action")[0].ToString().ToUpper()} + {ev.Payload.GetProperty("action").ToString().Substring(1)} an issue in {ev.Repo.Name}";
                        break;
                    case "WatchEvent":
                        action = $"Starred {ev.Repo.Name}";
                        break;
                    case "ForkEvent":
                        action = $"Forked {ev.Repo.Name}";
                        break;
                    case "CreateEvent":
                        action = $"Created {ev.Payload.GetProperty("ref_type")} {ev.Payload.GetProperty("ref")} in {ev.Repo.Name}";
                        break;
                    default:
                        action = $"{ev.Type?.Replace("Event", "")} in {ev.Repo.Name}";
                        break;
                }
                Console.WriteLine(action);
            }
        }
    }
}