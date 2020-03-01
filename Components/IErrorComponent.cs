using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
    //https://nightbaker.github.io/gitflow/azure/piplines/2020/01/22/blazor-error-component/
    public interface IErrorComponent
    {
        void ShowError(string title, string message);
    }
}
