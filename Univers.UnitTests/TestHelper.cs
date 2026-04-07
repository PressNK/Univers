using FluentAssertions.Execution;

namespace Univers.UnitTests;
public static class TestHelper
{
    public static string GenererString(char lettre, int nombreRepetitions) 
    {
        return new(lettre, nombreRepetitions);
    }

    public static bool VerifierAssertion(Action assertion)
    {
        using var assertionScope = new AssertionScope();
        assertion();

        return assertionScope.Discard().Length == 0;
    }

    public static async Task<bool> VerifierAssertion(Func<Task> assertion)
    {
        using var assertionScope = new AssertionScope();
        await assertion();

        return assertionScope.Discard().Length == 0;
    }
}