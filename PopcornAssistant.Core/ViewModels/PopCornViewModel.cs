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
    class PopCornViewModel : BaseViewModel
    {
        public PopCornViewModel()
        {
            //....
        }

        public void Init()
        {
            TolleranceCollection = new List<int>();

            for (int i = 5; i < 105; i += 5)
            {
                TolleranceCollection.Add(i);
            }


            RaisePropertyChanged(() => TolleranceCollection);
        }
        public override void Start()
        {
            base.Start();
            _popcornService = Mvx.Resolve<PopcornService>();
            _popcornService.Start();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _popcornService.OnPopcornReady += _popcornService_OnPopcornReady;
            _popcornService.OnPopDetected += _popcornService_OnPopDetected;
            _popcornService.OnPopEnd += _popcornService_OnPopEnd;
        }

        private void _popcornService_OnPopEnd()
        {
            PopDetected = false;
        }

        private void _popcornService_OnPopDetected()
        {
            PopDetected = true;
        }

        private void _popcornService_OnPopcornReady()
        {
            
        }


        #region Members

        PopcornService _popcornService;

        #endregion

        #region Binded Properties

        List<int> _tolleranceCollection;

        public List<int> TolleranceCollection
        {
            get
            {
                return _tolleranceCollection;
            }

            set
            {
                _tolleranceCollection = value;
                RaisePropertyChanged();
            }
        }



        bool _popDetected;

        public bool PopDetected
        {
            get
            {
                return _popDetected;
            }

            set
            {
                _popDetected = value;
                RaisePropertyChanged();
            }
        }


        bool _isPopCornReady;
        public bool IsPopCornReady
        {
            get
            {
                return _isPopCornReady;
            }

            set
            {
                _isPopCornReady = value;
                RaisePropertyChanged();
            }
        }

        int _selectedTollerance;
        public int SelectedTollerance
        {
            set
            {
                _popcornService.SetPopUpTollerance(value);
            }
        }


        #endregion
    }
}
