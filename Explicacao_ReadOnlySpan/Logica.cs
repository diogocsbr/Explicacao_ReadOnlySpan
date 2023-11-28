using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Explicacao_ReadOnlySpan;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80, baseline: true)]

[RPlotExporter]

[MemoryDiagnoser(true)]
public class Logica
{
    private string _data;

    [GlobalSetup]
    public void Setup()
    {
        _data = new string('a', 1000);
    }

    [Benchmark]
    public int ComReadOnlySpan()
    {
        ReadOnlySpan<char> span = _data.AsSpan();
        int count = 0;
        for (int i = 0; i < span.Length; i++)
        {
            if (span[i] == 'a')
            {
                count++;
            }
        }
        return count;
    }

    [Benchmark]
    public int SemReadOnlySpan()
    {
        int count = 0;
        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i] == 'a')
            {
                count++;
            }
        }
        return count;
    }
}