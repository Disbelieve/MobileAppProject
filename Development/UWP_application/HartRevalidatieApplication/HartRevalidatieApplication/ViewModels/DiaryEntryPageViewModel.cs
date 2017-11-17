using HartRevalidatieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class DiaryEntryPageViewModel
    {
        public static DiaryEntryPageViewModel SingleInstance { get; } = new DiaryEntryPageViewModel();
        public Measurement diaryEntry { get; set; }

        public DiaryEntryPageViewModel() { }
    }
}
