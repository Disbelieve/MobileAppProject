using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class DiaryPageViewModel
    {
        public static DiaryPageViewModel SingleInstance { get; } = new DiaryPageViewModel();
        public ObservableIncrementalLoadingCollection<Measurement> diary { get; set; } = new ObservableIncrementalLoadingCollection<Measurement>();

        public DiaryPageViewModel()
        {
            diary.Add(new Measurement());
            diary.Add(new Measurement());
            diary.Add(new Measurement());
            diary.Add(new Measurement());
            diary.Add(new Measurement());
            diary.Add(new Measurement());
            diary.Add(new Measurement());
            diary.Add(new Measurement());
        }
    }
}
