using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using PopcornAssistant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopcornAssistant.Core.ViewModels
{

    public abstract class BaseViewModel : MvxViewModel
    {
        public BaseViewModel()
        {
            InitDictionary();
        }

        TranslateService _service;
        private void InitDictionary()
        {
            _service = Mvx.Resolve<TranslateService>();
            _service.Init(LANGUEGE.ENG);
        }

        public string this[string key]
        {
            get
            {
                return _service[key];
            }
        }

    }

}
