using HartRevalidatieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class SettingsPageViewModel
    {
        public static SettingsPageViewModel SingleInstance { get; } = new SettingsPageViewModel();

        public SettingsPageViewModel()
        {
        }
    }
}
