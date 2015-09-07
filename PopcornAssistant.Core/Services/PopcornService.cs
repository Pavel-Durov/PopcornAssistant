using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopcornAssistant.Core.Services
{
    class PopcornService
    {
        public PopcornService()
        {
            _audioService = Mvx.Resolve<AudioService>();
            
        }

        AudioService _audioService;
        public event Action OnPopDetected;
        public event Action OnPopEnd;
        public event Action OnPopcornReady;

        double _prevAmplitude;

        internal void Start()
        {
            _audioService.OnAmplitudeReading += _audioService_OnAmplitudeReading;
            _audioService.Start();
        }

        internal void Stop()
        {
            _audioService.OnAmplitudeReading -= _audioService_OnAmplitudeReading;
            _audioService.Stop();
        }


        double _popTollerance;
        const double POP_SOUND_TOLERANCE = 5;
        const double POP_READY_SECONDS_TOLERANCE = 15;

        DateTime _lastPoptimeStamp;

        object _syncAmplitude = new object();
        bool _popSoundDetected;

        public void Reset()
        {
            Mvx.Trace("Reset Popcorn Service.");
            _popSoundDetected = false;
            _prevAmplitude = 0;
        }

        public void _audioService_OnAmplitudeReading(double amplitude)
        {
            lock (_syncAmplitude)
            {
                if (CheckIfReady() && _popSoundDetected)
                {
                    RaiseEvent(OnPopcornReady);
                    //Debug.WriteLine("Popcorn is ready!!");
                }
                else
                {
                    if (CheckForPop(amplitude))
                    {
                        _popSoundDetected = true;
                        RaiseEvent(OnPopDetected);
                        //Debug.WriteLine("POP DETECTED");
                        _lastPoptimeStamp = DateTime.Now;
                    }
                    else
                    {
                        RaiseEvent(OnPopEnd);
                        //Debug.WriteLine("NO POP DETECTED");
                    }
                    _prevAmplitude = amplitude;
                }
            }
        }

        private void RaiseEvent(Action _event)
        {
            if (_event != null)
            {
                _event();
            }
        }

        private bool CheckIfReady()
        {
            return (DateTime.Now - _lastPoptimeStamp).Seconds > POP_READY_SECONDS_TOLERANCE;
        }

        private bool CheckForPop(double amplitude)
        {
            return amplitude - _prevAmplitude > _popTollerance;
        }

        internal void Init()
        {
            Start();
        }

        public void SetPopUpTollerance(double toll)
        {
            this._popTollerance = toll;
        }
    }
}
