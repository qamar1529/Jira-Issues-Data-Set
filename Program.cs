using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JiraIssuesDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int currentCount = 0;
                List<Issues> allIssues = new List<Issues>();
                //List<int> issueTypes = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 10000, 10100, 10200, 10300, 10400, 10401, 10500, 10600, 10700 };
                List<int> issueTypes = new List<int>() { 1 };
                //string url = @"https://jira.mongodb.org/rest/api/2/search?jql=issuetype=";
                string url = @"https://jira.atlassian.com/rest/api/2/search?jql=issuetype=";
                foreach (int issueType in issueTypes)
                {
                    int maxCount = 0;
                    int start = 0;
                    
                    do
                    {
                        string tempUrl = url + issueType + "&maxResults=1000&expand=changelog&startAt=" + start;
                        string responseJson = GetReponseFromURL(tempUrl);
                        if (!string.IsNullOrEmpty(responseJson))
                        {
                            Response responseObject = JsonConvert.DeserializeObject<Response>(responseJson);
                            if (responseObject != null)
                            {
                                maxCount = responseObject.total;
                                start = start + 1000;
                                if (responseObject.issues != null && responseObject.issues.Count > 0)
                                {
                                    foreach (Issues issue in responseObject.issues)
                                    {
                                        currentCount++;
                                        Console.WriteLine("Current Count is: " + currentCount);
                                        if (issue.fields != null)
                                        {
                                            try
                                            {
                                                if (issue.fields.components != null && issue.fields.components.Count > 0)
                                                {
                                                    foreach (Component component in issue.fields.components)
                                                    {
                                                        if (!string.IsNullOrEmpty(component.self))
                                                        {
                                                            string componentResponse = GetReponseFromURL(component.self);
                                                            if (!string.IsNullOrEmpty(componentResponse))
                                                            {
                                                                Component tempComponent = JsonConvert.DeserializeObject<Component>(componentResponse);
                                                                if (tempComponent != null)
                                                                {
                                                                    if (tempComponent.lead != null)
                                                                    {
                                                                        component.lead = tempComponent.lead;
                                                                    }
                                                                    if (!string.IsNullOrEmpty(tempComponent.project))
                                                                    {
                                                                        component.project = tempComponent.project;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (issue.fields.versions != null && issue.fields.versions.Count > 0)
                                                {
                                                    foreach (Version version in issue.fields.versions)
                                                    {
                                                        GetVersionDetails(version);
                                                    }
                                                }
                                                if (issue.fields.fixVersions != null && issue.fields.fixVersions.Count > 0)
                                                {
                                                    foreach (Version fixVersion in issue.fields.fixVersions)
                                                    {
                                                        GetVersionDetails(fixVersion);
                                                    }
                                                }
                                                issue.fields.comments = GetComments(issue.id);
                                            }
                                            catch (Exception ex)
                                            {
                                                File.WriteAllText(@"C:\Users\halfb\source\repos\JiraIssuesDataSet\Exception" + DateTime.Now.Ticks + ".txt", JsonConvert.SerializeObject(ex));
                                            }
                                        }
                                    }
                                    allIssues.AddRange(responseObject.issues);
                                }
                            }
                        }
                        Thread.Sleep(2000);
                    } while (start <= maxCount);
                }
                if (allIssues != null && allIssues.Count > 0)
                {
                    File.WriteAllText(@"C:\Users\halfb\source\repos\JiraIssuesDataSet\Dataset.txt", JsonConvert.SerializeObject(allIssues));
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Users\halfb\source\repos\JiraIssuesDataSet\Exception.txt", JsonConvert.SerializeObject(ex));
            }
        }

        private static void GetVersionDetails(Version version)
        {
            try
            {
                if (!string.IsNullOrEmpty(version.self))
                {
                    string versionResponse = GetReponseFromURL(version.self);
                    if (!string.IsNullOrEmpty(versionResponse))
                    {
                        Version tempVersion = JsonConvert.DeserializeObject<Version>(versionResponse);
                        if (tempVersion != null)
                        {
                            if (tempVersion.releaseDate != null)
                            {
                                version.releaseDate = tempVersion.releaseDate;
                            }
                            if (!string.IsNullOrEmpty(tempVersion.userReleaseDate))
                            {
                                version.userReleaseDate = tempVersion.userReleaseDate;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Users\halfb\source\repos\JiraIssuesDataSet\Exception" + DateTime.Now.Ticks + ".txt", JsonConvert.SerializeObject(ex));
            }
        }

        private static List<Comment> GetComments(string issueId)
        {
            List<Comment> comments = null;
            try
            {
                if (!string.IsNullOrEmpty(issueId))
                {
                    string commentURL = "https://jira.atlassian.com/rest/api/2/issue/" + issueId + "/comment";
                    string commentResponseJSON = GetReponseFromURL(commentURL);
                    if (!string.IsNullOrEmpty(commentResponseJSON))
                    {
                        CommentResponse commentResponse = JsonConvert.DeserializeObject<CommentResponse>(commentResponseJSON);
                        if (commentResponse != null && commentResponse.comments != null && commentResponse.comments.Count > 0)
                        {
                            comments = commentResponse.comments;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Users\halfb\source\repos\JiraIssuesDataSet\Exception" + DateTime.Now.Ticks + ".txt", JsonConvert.SerializeObject(ex));
            }
            return comments;
        }

        private static string GetReponseFromURL(string url)
        {
            string responseJson;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseJson = reader.ReadToEnd();
            }
            //Thread.Sleep(400);
            return responseJson;
        }
    }
}
