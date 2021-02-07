using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchFight.ConsoleApplication.Helper
{
    public static class ArgsHelper
    {
        /// <summary>
        /// Get console input as string params
        /// </summary>
        /// <param name="argsString">Console params</param>
        /// <returns>Params string List</returns>
        public static List<string> ExtractArgs(string argsString)
        {
            return Regex.Matches(argsString, @"[\""].+?[\""]|[^ ]+")
                .Cast<Match>()
                .Select(m => m.Value.Replace("\"", "")).ToList();
        }
    }
}
