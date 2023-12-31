﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTreeViewControl.Commands
{
    internal class RelayCommand<T> : ICommand
    {
        #region Fields
        private readonly Action<T> mExecute = null;
        private readonly Predicate<T> mCanExecute = null;
        #endregion // Fields

        #region Constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<T> execute)
          : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.mExecute = execute;
            this.mCanExecute = canExecute;
        }

        #endregion // Constructors

        #region events
        /// <summary>
        /// Eventhandler to re-evaluate whether this command can execute or not
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.mCanExecute != null)
                    CommandManager.RequerySuggested += value;
            }

            remove
            {
                if (this.mCanExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Determine whether this pre-requisites to execute this command are given or not.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.mCanExecute == null ? true : this.mCanExecute((T)parameter);
        }

        /// <summary>
        /// Execute the command method managed in this class.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.mExecute((T)parameter);
        }
        #endregion methods
    }
}
