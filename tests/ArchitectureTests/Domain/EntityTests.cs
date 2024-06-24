using FluentAssertions;
using MetafrasiSS.Domain.Common.Models;
using MetafrasiSS.Web.Common.Constants;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchitectureTests.Domain;

public class EntityTests
{
    [Fact]
    public void Entities_Should_HavePrivateParameterlessConstructor()
    {
        var entityTypes = Types.InAssembly(AssemblyReferences.Domain)
            .That()
            .Inherit(typeof(Entity<>))
            .GetTypes();

        var fallingTypes = new List<Type>();

        foreach (var entityType in entityTypes)
        {
            var constructors = entityType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (!constructors.Any(c => (!c.IsPublic) && c.GetParameters().Length == 0))
            {
                fallingTypes.Add(entityType);
            }
        }

        fallingTypes.Should().BeEmpty();
    }
}