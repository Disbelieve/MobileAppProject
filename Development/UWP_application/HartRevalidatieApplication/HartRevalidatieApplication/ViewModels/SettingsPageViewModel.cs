using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class SettingsPageViewModel
    {
        public static SettingsPageViewModel SingleInstance { get; } = new SettingsPageViewModel();

        public SettingsPageViewModel() { }
    }
}
