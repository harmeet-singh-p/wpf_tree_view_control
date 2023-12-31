﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeViewControl.ViewModels.Base
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Standard event handler of the <seealso cref="INotifyPropertyChanged"/> interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Tell bound controls (via WPF binding) to refresh their display.
        /// 
        /// Sample call: this.NotifyPropertyChanged(() => this.IsSelected);
        /// where 'this' is derived from <seealso cref="BaseViewModel"/>
        /// and IsSelected is a property.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        public void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
                memberExpression = (MemberExpression)lambda.Body;

            this.OnPropertyChanged(memberExpression.Member.Name);
        }

        /// <summary>
        /// Tell bound controls (via WPF binding) to refresh their display.
        /// 
        /// Sample call: this.OnPropertyChanged("IsSelected");
        /// where 'this' is derived from <seealso cref="BaseViewModel"/>
        /// and IsSelected is a property.
        /// </summary>
        /// <param name="propertyName">Name of property to refresh</param>
        public void OnPropertyChanged(string propertyName)
        {
            try
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            catch
            {
            }
        }
    }
}
