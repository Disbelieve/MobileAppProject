using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class ContactPageViewModel
    {
        public static ContactPageViewModel SingleInstance { get; } = new ContactPageViewModel();

        public ContactPageViewModel() { }
    }
}
