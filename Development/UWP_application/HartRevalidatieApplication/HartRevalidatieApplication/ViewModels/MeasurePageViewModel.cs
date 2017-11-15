using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class MeasurePageViewModel
    {
        public static MeasurePageViewModel SingleInstance { get; } = new MeasurePageViewModel();

        public MeasurePageViewModel() { }
    }
}
