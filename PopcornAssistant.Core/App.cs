using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using PopcornAssistant.Core.ViewModels;
using System;

namespace PopcornAssistant.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service").AsTypes()
                .RegisterAsSingleton();

            RegisterAppStart<SplashScreenViewModel>();

        }
    }
}
