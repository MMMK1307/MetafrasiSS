using ArchitectureTests.Common.Constants;
using FluentAssertions;
using MediatR;
using MetafrasiSS.Web.Common.Constants;
using NetArchTest.Rules;

namespace ArchitectureTests.Application;

public class HandlersTest
{
    [Fact]
    public void Handlers_Should_HaveDependencyOnDomain()
    {
        var testResult = Types
            .InAssembly(AssemblyReferences.Application)
            .That()
            .HaveNameEndingWith("Handlers")
            .Should()
            .HaveDependencyOn(Namespace.Domain)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationHandlers_Should_HaveHandlerPostfix()
    {
        var testResult = Types.
            InAssembly(AssemblyReferences.Application)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should()
            .HaveNameEndingWith("Handler")
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }
}