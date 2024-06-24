using System.Reflection;

namespace MetafrasiSS.Web.Common.Constants;

internal static class AssemblyReferences
{
    public static Assembly Domain => typeof(Domain.IAssemblyReference).Assembly;
    public static Assembly Application => typeof(Application.DependencyConfiguration).Assembly;
    public static Assembly Infra => typeof(Infra.IAssemblyReference).Assembly;
    public static Assembly Web => typeof(Web.IAssemblyReference).Assembly;
}