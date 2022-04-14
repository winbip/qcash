using System;
using System.ComponentModel;

namespace CustomObjects
{
    public abstract class ObjectBase : INotifyPropertyChanged, INotifyPropertyChanging
    {

        #region Constructors

        protected ObjectBase()
        {
            Initialize();
            //InitializeBusinessRules();
            //InitializeAuthorizationRules();
        }

        #endregion

        #region Initialize

        /// <summary>
        /// Override this method to set up event handlers so user
        /// code in a partial class can respond to events raised by
        /// generated code.
        /// </summary>
        protected virtual void Initialize()
        { /* allows subclass to initialize events before any other activity occurs */ }

        #endregion

        #region INotify Members
        //PropertyChanged Event and Method=====================================
        public event PropertyChangedEventHandler PropertyChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPropertyChanged(string ChangedPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(ChangedPropertyName));

                //Note: If above line create problem, then use the following
                //PropertyChanged(this, new PropertyChangedEventArgs(ChangedPropertyName));
            }
        }
        //=====================================================================


        //PropertyChanging Event and Method====================================
        public event PropertyChangingEventHandler PropertyChanging;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPropertyChanging(string ChangingPropertyName)
        {

            if (PropertyChanging != null)
            {
                PropertyChanging.Invoke(this, new PropertyChangingEventArgs(ChangingPropertyName));
            }
        }
        //=====================================================================
        #endregion

        #region IsNew, IsDeleted, IsDirty, IsSavable

        // keep track of whether we are new, deleted or dirty
        private bool _isNew = true;
        private bool _isDeleted;
        private bool _isDirty = false;

        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }

        [Browsable(false)]
        public bool IsDeleted
        {
            get { return _isDeleted; }
        }

        [Browsable(false)]
        public virtual bool IsDirty
        {
            get { return IsSelfDirty; }
        }

        [Browsable(false)]
        public virtual bool IsSelfDirty
        {
            get { return _isDirty; }
        }

        protected virtual void MarkNew()
        {
            _isNew = true;
            _isDeleted = false;
            //MarkDirty();
        }

        protected virtual void MarkOld()
        {
            _isNew = false;
            MarkClean();
        }

        protected void MarkDeleted()
        {
            _isDeleted = true;
            MarkDirty();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void MarkDirty()
        {
            _isDirty = true;
        }

        protected virtual void PropertyHasChanged(string propertyName)
        {
            MarkDirty();
            OnPropertyChanged(propertyName);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void MarkClean()
        {
            _isDirty = false;
        }


        #endregion
    }
}
