using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace benchmark;

    [MemoryDiagnoser]
public class Program
{
    static void Main(string[] args)
    {
        var config = new ManualConfig()
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            .AddValidator(JitOptimizationsValidator.DontFailOnError)
            .AddLogger(ConsoleLogger.Default)
            .AddColumnProvider(DefaultColumnProviders.Instance);
        
        var summary = BenchmarkRunner.Run<Program>(config);
        
    }

    [Benchmark]
    public string Fa2En()
    {
        string str = "593475237523975209357374593745";
        return str.Replace("۰", "0")
            .Replace("۱", "1")
            .Replace("۲", "2")
            .Replace("۳", "3")
            .Replace("۴", "4")
            .Replace("۵", "5")
            .Replace("۶", "6")
            .Replace("۷", "7")
            .Replace("۸", "8")
            .Replace("۹", "9");
    }

    [Benchmark]
    public string PersianToEnglish()
    {
        string persianStr = "593475237523975209357374593745";
        Dictionary<string, string> LettersDictionary = new Dictionary<string, string>
        {
            ["۰"] = "0",["۱"] = "1",["۲"] = "2",["۳"] = "3",["۴"] = "4",["۵"] = "5",["۶"] = "6",["۷"] = "7",["۸"] = "8",["۹"] = "9"
        };
        return LettersDictionary.Aggregate(persianStr, (current, item) =>
            current.Replace(item.Key, item.Value));
    }
}
