using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class ContactFinishedPageViewModel
    {
        public static ContactFinishedPageViewModel SingleInstance { get; } = new ContactFinishedPageViewModel();

        public ContactFinishedPageViewModel() { }
    }
}
