using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace FriendlyId.Net.Tests
{
    public class AnalyzeGeneratedIdsTest
	{
		private List<String> _ids = new List<string>();
		[Test]
		public void AnalyzeGeneratedValueStatistics()
		{
			for (int i = 0; i < 100_000; i++)
			{
				_ids.Add(Base62.Encode(GuidConverter.ToBigInteger(Guid.NewGuid())));
			}
			var stats = _ids.Select(x => x.Length);

			Debug.WriteLine("Results:");
			Debug.WriteLine($"Min: {stats.Min()}");
			Debug.WriteLine($"Max: {stats.Max()}");
			Debug.WriteLine($"Avg: {stats.Average()}");
			Debug.WriteLine($"Count: {stats.Count()}");

			Assert.That(stats.Max() == 22);
			Assert.That(stats.Min() >= 17);
			Assert.That(stats.Average() <= 22);
		}
	}
}
