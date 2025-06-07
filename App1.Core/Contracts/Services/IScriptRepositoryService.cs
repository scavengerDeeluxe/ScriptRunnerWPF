using App1.Core.Models;

namespace App1.Core.Contracts.Services;

public interface IScriptRepositoryService
{
    Task<IEnumerable<ScriptInfo>> GetScriptsAsync();
}
