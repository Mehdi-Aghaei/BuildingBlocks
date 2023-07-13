// -------------------------------------------------------
// Copyright © Coalition of the Good-Hearted Engineers
// -------------------------------------------------------

using BuildingBlocks.Common.Validations;

namespace BuildingBlocks.Tests.Common;

public class ValidationExtensionsTests
{
	[Fact]
	public void Validate_ValidationPredicates_True()
	{
		// Arrange
		IEnumerable<int> randomNumbers = GenrateRandomNumbers(10,30);
		Func<IEnumerable<int>, bool> allPositive = (x) => x.All(x => x > 0);
		Func<IEnumerable<int>, bool> allInRange = (x) => x.All(x => x < 100);
		Func<IEnumerable<int>, bool> correctCount = (x) => x.Count() is 10;

		// Act 
		var result = randomNumbers.Validate(allPositive, allInRange, correctCount);

		// Assert
		result.Should().BeTrue();
	}

	private static int[] GenrateRandomNumbers(int length, int maxValue)
	{
		var random = new Random();
		
		return Enumerable.Range(1, length).Select(s => random.Next(maxValue))
		.Where(a => a > 0).ToArray();
	}
}
