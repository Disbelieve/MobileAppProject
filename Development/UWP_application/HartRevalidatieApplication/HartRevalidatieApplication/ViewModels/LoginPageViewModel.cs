using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class LoginPageViewModel
    {
        public static LoginPageViewModel SingleInstance { get; } = new LoginPageViewModel();

        public LoginPageViewModel() { }
    }
}
