using FluentAssertions;
using MediatR;
using MetafrasiSS.Web.Common.Constants;
using NetArchTest.Rules;

namespace ArchitectureTests.Application;

public class CommandsTests
{
    [Fact]
    public void ApplicationCommands_Should_HaveCommandPostfix()
    {
        var testResult = Types.
            InAssembly(AssemblyReferences.Application)
            .That()
            .ImplementInterface(typeof(IRequest<>))
            .Should()
            .HaveNameEndingWith("Command")
            .Or()
            .HaveNameEndingWith("Query")
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }
}