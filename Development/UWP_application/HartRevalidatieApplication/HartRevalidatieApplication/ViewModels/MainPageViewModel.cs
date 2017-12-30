using HartRevalidatieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class MainPageViewModel
    {
        public static MainPageViewModel SingleInstance { get; } = new MainPageViewModel();

        public MainPageViewModel()
        {
        }
    }
}
