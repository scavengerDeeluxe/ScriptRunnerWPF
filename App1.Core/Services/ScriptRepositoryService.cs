using App1.Core.Contracts.Services;
using App1.Core.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
codex/update-listdetailspage-to-display-script-repository
using System;
master

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

                    });
                }
            }
        }

        return results;
    }
}
