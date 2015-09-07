using Cirrious.MvvmCross.ViewModels;
using PopcornAssistant.Core.Constants;
using PopcornAssistant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopcornAssistant.Core.ViewModels
{
    class SplashScreenViewModel : BaseViewModel
    {
        public SplashScreenViewModel()
        {
        }


        public override async void Start()
        {
            base.Start();
            await Task.Delay(GlobalConst.SPLASH_DELAY_MS);
            ShowViewModel<PopCornViewModel>();
        }

    }
}
