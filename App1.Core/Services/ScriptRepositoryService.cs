using App1.Core.Contracts.Services;
using App1.Core.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace App1.Core.Services;

public class ScriptRepositoryService : IScriptRepositoryService
{
    private readonly HttpClient _httpClient;
    private const string RepositoryApiUrl = "https://api.github.com/repos/scavengerDeeluxe/PowerShellUI/contents/PowerShellUI/Scripts";

    public ScriptRepositoryService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ScriptRunnerWPF");
    }

    public async Task<IEnumerable<ScriptInfo>> GetScriptsAsync()
    {
        var results = new List<ScriptInfo>();
        var response = await _httpClient.GetStringAsync(RepositoryApiUrl);
        var files = JArray.Parse(response);

        foreach (var file in files)
        {
            var downloadUrl = file.Value<string>("download_url");
            var name = file.Value<string>("name");
            if (name != null && name.EndsWith(".json") && downloadUrl != null)
            {
                var json = await _httpClient.GetStringAsync(downloadUrl);
                var obj = JObject.Parse(json);
                var script = obj["script"];
                if (script != null)
                {
                    results.Add(new ScriptInfo
                    {
                        Name = script.Value<string>("name") ?? name,
                        Description = script.Value<string>("description"),
                        SourceUrl = script.Value<string>("source_url"),
                        Rating = script.Value<int?>("rating") ?? 0,
                        Risk = script.Value<int?>("risk") ?? 0,
                        JsonUrl = downloadUrl,
                        Definition = obj
                    });
                }
            }
        }

        return results;
    }
}
