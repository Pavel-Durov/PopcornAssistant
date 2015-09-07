using PopcornAssistant.Core.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;

namespace PopcornAssistant.Core.Services
{
    class AudioService
    {
        public AudioService()
        {
            Init();
        }


        MediaCapture _mediaCapture;
        AudioAmplitudeStream _audioStream;

        public event Action<double> OnAmplitudeReading;

        internal async void Stop()
        {
            await _mediaCapture.StopPreviewAsync();
            bool flushed = await _audioStream.FlushAsync();
        }

        protected async void Init()
        {
            _mediaCapture = new MediaCapture();
            await _mediaCapture.InitializeAsync(GetSettings());
        }


        void AmplitudeReading(object sender, double reading)
        {
            //Mvx.Resolve<FftService>().Convert(reading);
            if (OnAmplitudeReading != null)
            {
                OnAmplitudeReading(reading);
            }
        }


        public async void Start()
        {
            _audioStream = new AudioAmplitudeStream();
            await _mediaCapture.StartRecordToStreamAsync(MediaEncodingProfile.CreateWav(AudioEncodingQuality.Low), _audioStream);
            _audioStream.AmplitudeReading += AmplitudeReading;
        }


        private MediaCaptureInitializationSettings GetSettings()
        {
            MediaCaptureInitializationSettings result = new MediaCaptureInitializationSettings();
            result.StreamingCaptureMode = StreamingCaptureMode.Audio;
            result.AudioProcessing = Windows.Media.AudioProcessing.Default;
            return result;
        }
    }
}
