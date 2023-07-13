// -------------------------------------------------------
// Copyright © Coalition of the Good-Hearted Engineers
// -------------------------------------------------------

namespace BuildingBlocks.Common.Validations;

public static class ValidationEtensions
{
	public static bool Validate<TInput>(this TInput input, params Func<TInput, bool>[] predicates) =>
		Array.TrueForAll(predicates, x => x(input));
}
