﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitePlugin;
using System.Windows.Media;
using System.Windows;

namespace MultiCommentViewer
{
    public class McvCommentViewModel
    {
        private readonly ICommentViewModel _cvm;
        private readonly ConnectionName _connectionName;

        public McvCommentViewModel(ICommentViewModel cvm, ConnectionName connectionName)
        {
            _cvm = cvm;
            _connectionName = connectionName;
            _connectionName.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(_connectionName.Name):
                        RaisePropertyChanged(nameof(connectionName));
                        break;
                }
            };
        }

        public ConnectionName ConnectionName => _connectionName;

        public IEnumerable<IMessagePart> NameItems => _cvm.NameItems;

        public IEnumerable<IMessagePart> MessageItems => _cvm.MessageItems;

        public string Info => _cvm.Info;

        public string Id => _cvm.Id;

        public string UserId => _cvm.UserId;

        //public IUser User => _cvm.User;

        public ICommentProvider CommentProvider => _cvm.CommentProvider;

        public bool IsInfo => _cvm.IsInfo;

        public IMessageImage Thumbnail => _cvm.Thumbnail;

        public FontFamily FontFamily => _cvm.FontFamily;

        public FontStyle FontStyle => _cvm.FontStyle;

        public FontWeight FontWeight => _cvm.FontWeight;

        public int FontSize => _cvm.FontSize;

        public SolidColorBrush Foreground => _cvm.Foreground;

        public SolidColorBrush Background => _cvm.Background;

        public bool IsVisible => _cvm.IsVisible;

        public Task AfterCommentAdded()
        {
            throw new NotImplementedException();
        }
        #region INotifyPropertyChanged
        [NonSerialized]
        private System.ComponentModel.PropertyChangedEventHandler _propertyChanged;
        /// <summary>
        /// 
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            _propertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
