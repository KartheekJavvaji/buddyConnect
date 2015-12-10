using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyConnect.View_Models
{
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel()
        {
            if (this.IsInDesignMode)
            {
                LoadDesignTimeData();
            }
        }

        protected virtual void LoadDesignTimeData() { }

        private bool isLoading;
        public virtual bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                RaisePropertyChanged();
            }
        }

        #region State Management

        public virtual void LoadState(object navParameter, Dictionary<string, object> state) { }

        public virtual void SaveState(Dictionary<string, object> state) { }

        protected virtual T RestoreStateItem<T>(Dictionary<string, object> state, string stateKey, T defaultValue = default(T))
        {
            return state != null && state.ContainsKey(stateKey) && state[stateKey] != null && state[stateKey] is T ? (T)state[stateKey] : defaultValue;
        }

        #endregion
        
    }
}
