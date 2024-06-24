using FluentAssertions;
using FluentValidation;
using MetafrasiSS.Web.Common.Constants;
using NetArchTest.Rules;

namespace ArchitectureTests.Application;

public class ValidatorsTests
{
    [Fact]
    public void ApplicationValidators_Should_HaveValidatorPostfix()
    {
        var testResult = Types.
            InAssembly(AssemblyReferences.Application)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }
}