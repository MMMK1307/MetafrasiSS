using ArchitectureTests.Common.Constants;
using FluentAssertions;
using MetafrasiSS.Web.Common.Constants;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class LayerTests
{
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            Namespace.Application,
            Namespace.Infra,
            Namespace.Web,
        };

        var testResult = Types.InAssembly(AssemblyReferences.Domain)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            Namespace.Infra,
            Namespace.Web,
        };

        var testResult = Types.InAssembly(AssemblyReferences.Application)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infra_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            Namespace.Web,
        };

        var testResult = Types.InAssembly(AssemblyReferences.Infra)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Web_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[] { "" };

        var testResult = Types.InAssembly(AssemblyReferences.Web)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }
}