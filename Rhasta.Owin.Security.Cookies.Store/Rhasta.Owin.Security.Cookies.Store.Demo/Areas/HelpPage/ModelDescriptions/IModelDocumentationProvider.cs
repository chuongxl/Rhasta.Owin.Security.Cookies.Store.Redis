using System;
using System.Reflection;

namespace Rhasta.Owin.Security.Cookies.Store.Demo.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}