using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text;
using Newtonsoft.Json.Linq;
//using Gurock.TestRail;
using Newtonsoft.Json;

namespace AmplifyAutomation.Utils
{
        public static class TestRailHelper
        {
            private static readonly string testRailUrl = "https://yourcompany.testrail.io/";
            private static readonly string username = "your.email@domain.com";
            private static readonly string apiKey = "your_api_key_here";
            private static readonly int testRunId = 1234; // Your TestRail run ID

            public static void AddResultForTestCase(int caseId, int statusId, string comment = "")
            {
                var client = new RestClient($"{testRailUrl}index.php?/api/v2/add_result_for_case/{testRunId}/{caseId}");
            var request = new RestRequest();
            request.Method = Method.Post;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{apiKey}"));

                request.AddHeader("Authorization", $"Basic {credentials}");
                request.AddHeader("Content-Type", "application/json");

                var body = new JObject
            {
                { "status_id", statusId },
                { "comment", comment }
            };

                request.AddJsonBody(body.ToString());

                var response = client.Execute(request);
                Console.WriteLine($"TestRail update for C{caseId}: {response.StatusCode}");
            }
        }
}

