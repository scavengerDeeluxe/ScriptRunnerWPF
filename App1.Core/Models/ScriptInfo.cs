codex/update-listdetailspage-to-display-script-repository
using Newtonsoft.Json.Linq;
master
namespace App1.Core.Models;

public class ScriptInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string SourceUrl { get; set; }
    public int Rating { get; set; }
    public int Risk { get; set; }

}
