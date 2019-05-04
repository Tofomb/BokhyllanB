using BokhyllanB.Model;
using BokhyllanB.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BokhyllanB.UI.ViewModel
{

    public class MainViewModel:ViewModelBase
    {
        public MainViewModel(IBookDataService bookDataService)
        {
            Books = new ObservableCollection<Book>();
            _bookDataService = bookDataService;
           

        }

        public void Load()
        {
            //test
            //_bookDataService.CreateNewBook();
            //_bookDataService.DeleteBook(5);
           // _bookDataService.UpdateBook(4,"Essenduverse","Me","");

            var books = _bookDataService.getAll();
            Books.Clear();
            foreach(var book in books)
            {
                Books.Add(book);
            }
        }

        public ObservableCollection<Book> Books { get; set; }



        private IBookDataService _bookDataService;

        private Book _selectedBook;

        public Book SelectedBook // CallerMemberName
        {
            get { return _selectedBook; }
            set { _selectedBook = value;
                OnPropertyChanged();
            }
        }

        //Create

        public ICommand _createCommand { get; set; }

        public ICommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new RelayCommand(
                        param => this.CreateObject(),
                        param => this.CanCreate()
                    );
                }
                return _createCommand;
            }
        }

        private bool CanCreate()
        {
            // Verify command can be executed here
            return true;
        }

        private void CreateObject()
        {
            _bookDataService.CreateNewBook();
            Load();

        }


        //Delete
        public ICommand _deleteCommand { get; set; }

       public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => this.DeleteObject(),
                        param => this.CanDelete()
                    );
                }
                return _deleteCommand;
            }
        }

        private bool CanDelete()
        {
            // Verify command can be executed here
                return true;
        }

        private void DeleteObject()
        {
            _bookDataService.DeleteBook(_selectedBook.Id);
            Load();

        }


        //Save
        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.SaveObject(),
                        param => this.CanSave()
                    );
                }
                return _saveCommand;
            }
        }

        private bool CanSave()
        {
            // Verify command can be executed here
            return true;
        }

        private void SaveObject()
        {
            _bookDataService.UpdateBook(_selectedBook.Id ,_selectedBook.Title, _selectedBook.Author, _selectedBook.Description);
            
        }





    }








    // RelayCommand
    public class RelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }

        #endregion // ICommand Members
    }

}
