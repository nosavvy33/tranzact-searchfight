using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchFight.ApplicationDomain.Interfaces.IServices;
using SearchFight.ConsoleApplication.Helper;

namespace SearchFight.ConsoleApplication
{
    public class SearchFight
    {
        private readonly IReportService _reportService;
        private readonly IResultPrinter _resultPrinter;

        public SearchFight(IReportService reportService, IResultPrinter resultPrinter)
        {
            _reportService = reportService;
            _resultPrinter = resultPrinter;
        }

        /// <summary>
        /// Run search fight query
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            var args = Environment.CommandLine;
            args = args.Substring(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Length);
            string stringArgs;

            var listArgs = new List<string>();

            if (args.Length == 0)
            {
                Console.WriteLine("Enter values to search");

                stringArgs = Console.ReadLine();
                if (!string.IsNullOrEmpty(stringArgs))
                {
                    listArgs = ArgsHelper.ExtractArgs(stringArgs);
                }
            }
            else
            {
                stringArgs = string.Join(" ", args);
                listArgs = ArgsHelper.ExtractArgs(stringArgs);
            }

            try
            {
                var report = await _reportService.ExecuteSearchFightAsync(listArgs);

                _resultPrinter.DisplayReport(report);
                
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
