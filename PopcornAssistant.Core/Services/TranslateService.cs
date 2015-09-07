using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PopcornAssistant.Core.Services
{
    public enum LANGUEGE
    {
        ENG
    }

    public class TranslateServiceKeys
    {
        public const string CurrentAmplitude = "current_amplitude";
        public const string Decibal = "decibal";
        public const string MesuringAplitude = "mesuring_aplitude";
        public const string SplashScreenGreetings = "splashscreen_greetings";
        public const string MaximimAmplitude = "max_amplitude";
        public const string Reset = "reset";
        public const string Strat = "start";
        public const string Stop = "stop";
        public const string Pop = "POP";
    }

    public class TranslateService
    {
        public TranslateService()
        {
            
        }

        public void Init(LANGUEGE lang)
        {
            if (lang == LANGUEGE.ENG)
            {
                InitEnglishValues();
            }
        }

        Dictionary<string, string> _dictionary;

        public string this[string key]
        {
            get
            {
                return _dictionary[key];
            }
        }

        private void InitEnglishValues()
        {
            _dictionary = new Dictionary<string, string>();
            _dictionary[TranslateServiceKeys.CurrentAmplitude] = "Current Amplitude";
            _dictionary[TranslateServiceKeys.MaximimAmplitude] = "Maximum Amplitude";
            _dictionary[TranslateServiceKeys.Decibal] = "dB";
            _dictionary[TranslateServiceKeys.MesuringAplitude] = "Mesuring Noise";
            _dictionary[TranslateServiceKeys.SplashScreenGreetings] = "Noice Mesuring App";
            _dictionary[TranslateServiceKeys.Reset] = "Reset";
            _dictionary[TranslateServiceKeys.Stop] = "Stop";
            _dictionary[TranslateServiceKeys.Strat] = "Start";
            _dictionary[TranslateServiceKeys.Pop] = "pop";
        }
    }
}
