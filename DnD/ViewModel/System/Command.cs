using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnD.ViewModel.System
{
	internal class Command : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => _CanExecute(parameter);
		private Func<object?, bool> _CanExecute;

		public void Execute(object? parameter)
		{
			_Execute(parameter);
		}
		private Action<object?> _Execute;

		public Command(Action<object?> execute, Func<object?, bool>? canExecute = null)
		{
			_Execute = execute;
			_CanExecute = canExecute ?? (p => true);
		}

		internal void Update()
		{
			CanExecuteChanged?.Invoke(this, new EventArgs());
		}
	}
}
