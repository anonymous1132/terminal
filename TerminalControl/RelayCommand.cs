﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace npcook.Terminal.Controls
{
	class RelayCommand : ICommand
	{
		readonly Action<object> execute;
		readonly Predicate<object> canExecute;

		public RelayCommand(Action<object> execute)
			: this(execute, null)
		{ }

		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null || canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}
}
