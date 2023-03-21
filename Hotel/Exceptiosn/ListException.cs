using System;

namespace WpfMVVMAgendaCommands.Exceptions
{
    class ListException : ApplicationException
    {
        public ListException(string message)
            : base(message)
        {
        }
    }
}
