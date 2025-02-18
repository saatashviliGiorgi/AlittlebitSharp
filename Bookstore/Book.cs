using MediaBrowser.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class Book
    {
        private string _Title;

        public string Title {
            get => _Title;
            set
            {
                if (value == "")
                    throw new Exception("the book title can't be undefined");
                _Title = value;
            }
        }
        private string _Author;
        public string Author {
            get => _Author;
            set
            {
                if (value.Length < 5 || value.Length > 20)
                    throw new Exception("the Author's name must be includeed between 5-20 letter");
                _Author = value;
            }
        }
        private int _Year;
        public int Year { 
            get => _Year;
            set
            {
                if(value < 1000 || value > 2026)
                {
                    throw new Exception("year must be between 1000 - 2026");
                }
                _Year = value;
            }
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Year: {Year}";
        }
    }
}
